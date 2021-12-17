using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task1Advanced.FileSystem
{
    public class FileSystemVisitor
    {
        private readonly string _root;
        private DirectoryInfo _mainDirectoryInfo;
        private IEnumerable<FileSystemObject> _folderObjects;
        private readonly Predicate<string> _filter = (x) => true;
        public FileSystemVisitor(string root)
        {
            if (root == null && !Directory.Exists(root))
            {
                throw new ArgumentNullException("File path does not exist!");
            }
            _root = root;
            _mainDirectoryInfo = new DirectoryInfo(_root);
            _folderObjects = new List<FileSystemObject>();
        }

        public FileSystemVisitor(string root, Predicate<string> algorithm)
        {
            _folderObjects = new List<FileSystemObject>();
            _root = root;
            _filter = algorithm;
        }

        public IEnumerable<FileSystemObject> GetDirectoryComponents()
        {
            foreach (var component in GetFoldersInDirectory(_root))
            {
                yield return component;
            }
        }

        private IEnumerable<FileSystemObject> GetFoldersInDirectory(string root)
        {
            _mainDirectoryInfo = new DirectoryInfo(root);
            yield return new FileSystemObject()
            {
                Name = _mainDirectoryInfo.Name,
                ParentDirectoryPath = _mainDirectoryInfo.Parent.FullName,
                Type = "Directory",
            };

            foreach (var subFolder in Directory.EnumerateDirectories(root))
            {
                foreach (var item in GetFoldersInDirectory(subFolder))
                {
                    yield return item;
                }
            }

            foreach (var file in GetFilesInDictionary(root))
            {
                yield return file;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------end of folder------------ }\n");
        }

        private IEnumerable<FileSystemObject> GetFilesInDictionary(string folder)
        {
            _mainDirectoryInfo = new DirectoryInfo(folder);
            foreach (var file in _mainDirectoryInfo.EnumerateFiles())
            {
                yield return new FileSystemObject()
                {
                    Name = file.Name,
                    ParentDirectoryPath = file.DirectoryName,
                    Type = file.Extension,
                };
            }
        }
    }
}
