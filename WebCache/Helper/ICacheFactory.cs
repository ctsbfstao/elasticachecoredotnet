using System;
using WebCache.Models;

namespace WebCache.Helper
{
    public interface ICacheFactory
    {
        CacheFactoryResponse<TDeserializedObject> RetrieveOrUpdateRedis<TDeserializedObject>();

        void InvalidateCache();
    }
}