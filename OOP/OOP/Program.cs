using System;
using System.Collections.Generic;
using DocumentWorker.Service;
using DocumentWorker.DocTypeModel;
using Microsoft.Extensions.Caching.Memory;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var books = new List<Book>()
            {
                new Book
                {
                    Id = 1,
                    Title = "book1",
                    DatePublished = DateTime.MinValue,
                    Authors = "author1",
                    ISBN = "isbn1",
                    NumberOfPages = 1,
                    Publisher = "publisher1"
                },
                new Book
                {
                    Id = 2,
                    Title = "book2",
                    DatePublished = DateTime.MaxValue,
                    Authors = "author2",
                    ISBN = "isbn2",
                    NumberOfPages = 2,
                    Publisher = "publisher2"
                }
            };
            var localizedBooks = new List<LocalizedBook>()
            {
                new LocalizedBook
                {
                    Id = 1,
                    Title = "localizedBook1",
                    Authors = "author1",
                    DatePublished = DateTime.MinValue,
                    ISBN = "isbn1",
                    NumberOfPages = 1,
                    OriginalPublisher = "publisher1",
                    CountryOfLocalization = "country1",
                    LocalPublisher = "localPublisher1"
                },
                new LocalizedBook
                {
                    Id = 2,
                    Title = "localizedBook2",
                    Authors = "author2",
                    DatePublished = DateTime.MaxValue,
                    ISBN = "isbn2",
                    NumberOfPages = 2,
                    OriginalPublisher = "publisher2",
                    CountryOfLocalization = "country2",
                    LocalPublisher = "localPublisher2"
                }
            };
            var magazines = new List<Magazine>()
            {
                new Magazine
                {
                    Id = 1,
                    Title = "magazine1",
                    DatePublished = DateTime.MinValue,
                    Publisher = "publisher1",
                    ReleaseNumber = 1
                }, 
                new Magazine
                {
                    Id = 2,
                    Title = "magazine2",
                    DatePublished = DateTime.MaxValue,
                    Publisher = "publisher2",
                    ReleaseNumber = 2
                }
            };
            var patents = new List<Patent>()
            {
                new Patent
                {
                    Id = 1,
                    Title = "patent1",
                    Authors = "author1",
                    DatePublished = DateTime.MinValue,
                    UniqueId = 1,
                    ExpirationDate = DateTime.MinValue
                },
                new Patent
                {
                    Id = 2,
                    Title = "patent2",
                    Authors = "author2",
                    DatePublished = DateTime.MaxValue,
                    UniqueId = 2,
                    ExpirationDate = DateTime.MaxValue
                }
            };

            var jsonWorker = new JsonWorker();

            var cacheTime = new Dictionary<Type, MemoryCacheEntryOptions>
            {
                {typeof(Book), new MemoryCacheEntryOptions()},
                {typeof(LocalizedBook), new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(5))},
                {typeof(Magazine), new MemoryCacheEntryOptions()},
                {typeof(Patent), new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromSeconds(5))},
            };
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var documentCacheConverter = new DocumentCacheConverter(memoryCache, cacheTime);

            var documentWorker = new DocumentWorker.Service.DocumentWorker(jsonWorker, documentCacheConverter);

            documentWorker.AddCards(books);
            documentWorker.AddCards(localizedBooks);
            documentWorker.AddCards(magazines);
            documentWorker.AddCards(patents);

            var documents = new List<BaseDoc>()
            {
                documentWorker.GetDocumentCard<Book>(1),
                documentWorker.GetDocumentCard<LocalizedBook>(1),
                documentWorker.GetDocumentCard<Magazine>(1),
                documentWorker.GetDocumentCard<Patent>(1),
                documentWorker.GetDocumentCard<Book>(2),
                documentWorker.GetDocumentCard<LocalizedBook>(2),
                documentWorker.GetDocumentCard<Magazine>(2),
                documentWorker.GetDocumentCard<Patent>(2),
            };

            foreach (var document in documents)
            {
                Console.WriteLine(document.ToString());
            }
        }
    }
}
