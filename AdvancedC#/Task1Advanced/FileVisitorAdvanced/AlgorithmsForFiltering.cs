using System;

namespace Task1Advanced.FileSystem
{
    public static class AlgorithmsForFiltering
    {
        public static Predicate<FileSystemObjectEventArgs> FilterByNameContainsString { get; set; }

        public static Predicate<FileSystemObjectEventArgs> FilterByType { get; set; }

        public static Predicate<FileSystemObjectEventArgs> FilterByCreatingDate { get; set; }

        public static Predicate<FileSystemObjectEventArgs> GetFilter(string activeButtonText, string inputValue)
        {
            if(string.IsNullOrEmpty(activeButtonText))
                return null;
            if (activeButtonText.Contains("Name contains substring"))
            {
                return FilterByNameContainsString = (name) => name.Name.Contains(inputValue);
            }
            else if(activeButtonText.Contains("Type"))
            {
                return FilterByType = (type) => type.Type.Contains(inputValue);
            }
            else if(activeButtonText.Contains("By creating time \r\n(files found more \r\nthen input time)\r\nformat :\r\nYYYY-MM-DD\r\n"))
            {
                return FilterByCreatingDate = (createDate)
                    => createDate.CreatingDate >= DateTime.Parse(inputValue);
            }

            return null;
        }
    }
}
