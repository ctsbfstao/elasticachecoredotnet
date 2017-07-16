using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading;
using Newtonsoft.Json;
using WebCache.Models;
using System.Diagnostics;

namespace WebCache.Helper
{
    public class CacheFactory : ICacheFactory
    {
        private const string _cacheKey = "ProductDataset";
        private const string _fileName = "products.json";
        private readonly IDistributedCache _distributedCache;

        public CacheFactory(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public CacheFactoryResponse<TDeserializedObject> RetrieveOrUpdateRedis<TDeserializedObject>()
        {
            var response = new CacheFactoryResponse<TDeserializedObject>();
            var watch = Stopwatch.StartNew();
                        
            var valueToReturn = _distributedCache.GetString(_cacheKey);
            if (valueToReturn != null)
            {
                response.DataLoadType = "From Redis";
            }
            else
            {
                valueToReturn = System.IO.File.ReadAllText(_fileName);
                Thread.Sleep(2000);

                var dependency = new DistributedCacheEntryOptions();
                dependency.SetSlidingExpiration(TimeSpan.FromSeconds(10));
                _distributedCache.SetString(_cacheKey, valueToReturn, dependency);
                
                response.DataLoadType = "From File";
            }
            watch.Stop();

            response.ElapsedMilliseconds = watch.ElapsedMilliseconds;
            response.CachedJsonContent = valueToReturn;
            response.DeserializedCachedContent = JsonConvert.DeserializeObject<TDeserializedObject>(valueToReturn);

            return response;
        }

        private string GetUpdatedFileContent(string jSONText)
        {
            var itemsFromjSON = JsonConvert.DeserializeObject<IEnumerable<ProductItem>>(jSONText);
            return JsonConvert.SerializeObject(itemsFromjSON);
        }


        public void InvalidateCache()
        {
            _distributedCache.Remove(_cacheKey);
        }
    }
}

