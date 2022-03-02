using System;

namespace DocumentWorker.DocTypeModel
{
    public class Patent : BaseDoc
    {
        public string Authors { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int UniqueId { get; set; }

        public override string ToString()
        {
            return $"Patent, Id = {Id}, Title = {Title}, DatePublished = {DatePublished}," +
                   $"Authors = {Authors}, ExpirationDate = {ExpirationDate}, UniqueId = {UniqueId}";
        }
    }
}
