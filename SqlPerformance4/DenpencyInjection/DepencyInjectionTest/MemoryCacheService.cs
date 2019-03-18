using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Hr32bit
{
    public class MemoryCacheService : MemoryCache
    {
        public MemoryCacheService(IOptions<MemoryCacheOptions> optionsAccessor) : base(optionsAccessor)
        {
        }
    }
}