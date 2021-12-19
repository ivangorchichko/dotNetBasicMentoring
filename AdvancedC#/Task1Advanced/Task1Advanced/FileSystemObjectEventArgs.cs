using System;

namespace Task1Advanced
{
    public class FileSystemObjectEventArgs : EventArgs
    {
        public string ParentDirectoryPath { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public DateTime CreatingDate { get; set; }
    }
}
