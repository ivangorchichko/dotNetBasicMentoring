using System;
using System.Collections.Generic;
using System.Text;

namespace Task1Advanced.FileSystem
{
    public class FileSystemObject
    {
        public string ParentDirectoryPath { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return $"Object name: {Name}, object type: {Type}, object directory: {ParentDirectoryPath}" + " {\n" ;
        }
    }
}
