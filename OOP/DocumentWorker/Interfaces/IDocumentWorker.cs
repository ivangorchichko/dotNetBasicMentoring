using System.Collections.Generic;
using DocumentWorker.DocTypeModel;

namespace DocumentWorker.Interfaces
{
    public interface IDocumentWorker
    {
        T GetDocumentCard<T>(int documentNumber) where T : BaseDoc;

        void AddCards<T>(IEnumerable<T> documentCards) where T : BaseDoc;
    }
}
