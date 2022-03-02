namespace DocumentWorker.DocTypeModel
{
    public class LocalizedBook : BaseDoc
    {
        public string ISBN { get; set; }

        public string Authors { get; set; }

        public short NumberOfPages { get; set; }

        public string OriginalPublisher { get; set; }

        public string CountryOfLocalization { get; set; }

        public string LocalPublisher { get; set; }

        public override string ToString()
        {
            return $"LocalizedBook, Id = {Id}, Title = {Title}, DatePublished = {DatePublished}, ISBN = {ISBN}, Authors = {Authors}, " +
                   $"NumberOfPages = {NumberOfPages}, OriginalPublisher = {OriginalPublisher}," +
                   $" CountryOfLocalization = {CountryOfLocalization}, LocalPublisher = {LocalPublisher}";
        }
    }
}
