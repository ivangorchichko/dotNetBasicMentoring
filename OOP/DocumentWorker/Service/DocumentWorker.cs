using System.Collections.Generic;
using DocumentWorker.DocTypeModel;
using DocumentWorker.Interfaces;

namespace DocumentWorker.Service
{
    public class DocumentWorker : IDocumentWorker
    {
        private readonly IJsonFileWorker _jsonWorker;
        private readonly IDocumentCacheConverter _cacheConverter;

        public DocumentWorker(IJsonFileWorker jsonWorker, IDocumentCacheConverter cacheConverter)
        {
            _jsonWorker = jsonWorker;
            _cacheConverter = cacheConverter;
        }
        public T GetDocumentCard<T>(int documentNumber) where T : BaseDoc
        {
            var key = $"{typeof(T).Name}_#{{{documentNumber}}}";
            var documentCard = _cacheConverter.GetDocFromCache<T>(key);
            if (documentCard == null)
            {
                documentCard = _jsonWorker.Read<T>(documentNumber);
                _cacheConverter.CacheDocument(key, documentCard);
            }
            return documentCard;
        }

        public void AddCards<T>(IEnumerable<T> documentCards) where T : BaseDoc
        {
           _jsonWorker.Write(documentCards);
        }
    }
}
