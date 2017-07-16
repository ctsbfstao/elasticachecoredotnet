using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCache.Helper
{
    public static class CacheExtensions
    {
        public static void Set<TItem>(this IMemoryCache cache, string key, TItem value, FileCacheDependency dependency)
        {
            var fileInfo = new FileInfo(dependency.FileName);
            var fileProvider = new PhysicalFileProvider(fileInfo.DirectoryName);
            cache.Set(key, value, new MemoryCacheEntryOptions()
                                .AddExpirationToken(fileProvider.Watch(fileInfo.Name)));

        }

    }
}
