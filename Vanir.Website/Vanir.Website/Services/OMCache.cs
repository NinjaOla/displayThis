using Microsoft.Extensions.Caching.Memory;

namespace Vanir.Website.Services
{
    public class OMCache
    {

        public OMCache(IMemoryCache cache)
        {
            Cache = cache;
        }

        public IMemoryCache Cache { get; init; }

    }
}
