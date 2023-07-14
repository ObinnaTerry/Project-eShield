using Microsoft.Extensions.Caching.Memory;


namespace ProxyService.Utils
{
    public static class CacheRepo
    {
        private static readonly IMemoryCache _proxyStats = new MemoryCache(new MemoryCacheOptions());

        public static IMemoryCache ProxyStatsCache { get { return _proxyStats; } }
    }
}
