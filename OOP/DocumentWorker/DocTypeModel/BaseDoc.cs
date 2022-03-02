using System;

namespace DocumentWorker.DocTypeModel
{
    public class BaseDoc
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime DatePublished { get; set; }
    }
}
