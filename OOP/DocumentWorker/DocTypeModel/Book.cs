namespace DocumentWorker.DocTypeModel
{
    public class Book : BaseDoc
    {
        public string ISBN { get; set; }

        public string Authors { get; set; }

        public short NumberOfPages { get; set; }

        public string Publisher { get; set; }

        public override string ToString()
        {
            return $"Book, Id = {Id}, Title = {Title}, DatePublished = {DatePublished}, ISBN = {ISBN}, Authors = {Authors}, " +
                   $"NumberOfPages = {NumberOfPages}, Publisher = {Publisher},";
        }
    }
}
