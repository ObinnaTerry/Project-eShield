using eShield_API.DTOs;
using Microsoft.Extensions.Caching.Memory;

namespace ProxyService.Utils
{
    public static class CacheReader
    {
        private static readonly object Lock = new object();
        public static void Set(IMemoryCache cache, string key, object value)
        {
            cache.Set(key, value);
        }

        public static bool TryGetValue<T>(IMemoryCache cache, string key, out T? value)
        {
            return cache.TryGetValue(key, out value);
        }

        public static void Remove(IMemoryCache cache, string key)
        {
            cache.Remove(key);
        }

        public static void Clear(IMemoryCache cache, string key)
        {
            TryGetValue(cache, key, out List<VisitedSiteDTO>? result);
            result!.Clear();
            Set(cache, key, result);
        }

        public static List<VisitedSiteDTO> Update(IMemoryCache cache,  string key, VisitedSiteDTO? value, bool clear = false)
        {
            lock (Lock)
            {
                TryGetValue(cache, key, out List<VisitedSiteDTO>? result);

                if (value != null)
                {
                    result!.Add(value);
                }
                if (clear)
                {
                    cache.Remove(key);
                    Set(cache, key, new List<VisitedSiteDTO>());
                }

                return result!;
            }
        }
    }
}
