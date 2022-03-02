using DocumentWorker.DocTypeModel;

namespace DocumentWorker.Interfaces
{
    public interface IDocumentCacheConverter
    {
        void CacheDocument<T>(object key, T documentCard) where T : BaseDoc;
        
        T GetDocFromCache<T>(object key) where T : BaseDoc;
    }
}
