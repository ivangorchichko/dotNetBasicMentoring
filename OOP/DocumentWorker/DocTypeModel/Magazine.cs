namespace DocumentWorker.DocTypeModel
{
    public class Magazine : BaseDoc
    {
        public string Publisher { get; set; }

        public int ReleaseNumber { get; set; }

        public override string ToString()
        {
            return $"Magazine, Id = {Id}, Title = {Title}, DatePublished = {DatePublished}, Publisher = {Publisher}," +
                   $" ReleaseNumber = {ReleaseNumber}";
        }
    }
}
