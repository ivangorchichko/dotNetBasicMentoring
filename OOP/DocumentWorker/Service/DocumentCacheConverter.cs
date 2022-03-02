using System;
using System.Collections.Generic;
using DocumentWorker.DocTypeModel;
using DocumentWorker.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace DocumentWorker.Service
{
    public class DocumentCacheConverter : IDocumentCacheConverter
    {
        private readonly IMemoryCache _memoryCache;
        private readonly IDictionary<Type, MemoryCacheEntryOptions> _cacheTime;

        public DocumentCacheConverter(IMemoryCache memoryCache,
        IDictionary<Type, MemoryCacheEntryOptions> cacheTime)
        {
            _memoryCache = memoryCache;
            _cacheTime = cacheTime;
        }

        public void CacheDocument<T>(object key, T documentCard) where T : BaseDoc
        {
            _memoryCache.Set(key, documentCard, _cacheTime[documentCard.GetType()]);
        }

        public T GetDocFromCache<T>(object key) where T : BaseDoc
        {
            return _memoryCache.Get<T>(key);
        }
    }
}
