using System;
using System.Collections.Generic;
using System.IO;


namespace Task1Advanced
{
    public class FileSystemVisitor
    {
        private readonly string _root;
        private DirectoryInfo _mainDirectoryInfo;
        private bool _shouldStop;
        private readonly Predicate<FileSystemObjectEventArgs> _filter = (x) => true;

        public event EventHandler<FileSystemObjectEventArgs> SearchStarted;
        public event EventHandler<FileSystemObjectEventArgs> SearchFinished;
        public event EventHandler<FileSystemObjectEventArgs> FileFound;
        public event EventHandler<FileSystemObjectEventArgs> DirectoryFound;
        public event EventHandler<FileSystemObjectEventArgs> FilteredFileFound;
        public event EventHandler<FileSystemObjectEventArgs> FilteredDirectoryFound;

        public FileSystemVisitor(string root)
        {
            if (root == null && !Directory.Exists(root))
            {
                throw new ArgumentNullException("File path does not exist!");
            }
            _root = root;
        }

        public FileSystemVisitor(string root, Predicate<FileSystemObjectEventArgs> filter) : this(root)
        {
            _filter = filter;
        }

        public IEnumerable<FileSystemObjectEventArgs> GetDirectoryComponents()
        {
            OnVisitStarted(null);

            foreach (var component in GetFoldersInDirectory(_root))
            {
                yield return component;
            }
            
            OnVisitFinished(null);
        }

        public virtual void OnVisitStarted(FileSystemObjectEventArgs args) 
            => SearchStarted?.Invoke(this, args);

        public virtual void OnVisitFinished(FileSystemObjectEventArgs args)
        {
            _shouldStop = true;
            SearchFinished?.Invoke(this, args);
        }

        public virtual void OnFileFound(FileSystemObjectEventArgs args)
            => FileFound?.Invoke(this, args);

        public virtual void OnDirectoryFound(FileSystemObjectEventArgs args)
            => DirectoryFound?.Invoke(this, args);

        public virtual void OnFilteredFileFound(FileSystemObjectEventArgs args)
            => FilteredFileFound?.Invoke(this, args);

        public virtual void OnFilteredDirectoryFound(FileSystemObjectEventArgs args) 
            => FilteredDirectoryFound?.Invoke(this, args);

        private IEnumerable<FileSystemObjectEventArgs> GetFoldersInDirectory(string root)
        {
            
            _mainDirectoryInfo = new DirectoryInfo(root);

            var dir = new FileSystemObjectEventArgs()
            {
                Name = _mainDirectoryInfo.Name,
                ParentDirectoryPath = _mainDirectoryInfo.Parent.FullName,
                Type = "Directory",
                CreatingDate = _mainDirectoryInfo.CreationTimeUtc.Date,
            };

            OnDirectoryFound(dir);
            if (!_shouldStop)
            {
                if (_filter == null)
                {
                    yield return dir;
                }

                if (_filter != null && _filter(dir))
                {
                    OnFilteredDirectoryFound(dir);
                    yield return dir;
                }

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
            }
        }

        private IEnumerable<FileSystemObjectEventArgs> GetFilesInDictionary(string folder)
        {
            _mainDirectoryInfo = new DirectoryInfo(folder);
            foreach (var file in _mainDirectoryInfo.EnumerateFiles())
            {
                var fileObj = new FileSystemObjectEventArgs()
                {
                    Name = file.Name,
                    ParentDirectoryPath = file.DirectoryName,
                    Type = file.Extension,
                    CreatingDate = file.CreationTimeUtc.Date,
                };

                OnFileFound(fileObj);

                if (_filter == null)
                {
                    yield return fileObj;
                }

                if (_filter != null && _filter(fileObj))
                {
                    OnFilteredFileFound(fileObj);
                    yield return fileObj;
                }
            }
        }
    }
}
