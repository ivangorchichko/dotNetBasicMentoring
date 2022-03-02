using System.Collections.Generic;
using DocumentWorker.DocTypeModel;

namespace DocumentWorker.Interfaces
{
    public interface IJsonFileWorker
    {
        void Write<T>(IEnumerable<T> documents) where T : BaseDoc;

        T Read<T>(int documentNumber) where T : BaseDoc;
    }
}
