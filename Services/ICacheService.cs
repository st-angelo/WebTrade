namespace WebTrade.Services
{
    public interface ICacheService
    {
        Task<T> GetAsync<T>(string key, CancellationToken token = default) where T : class;
        Task SetAsync<T>(string key, T value, CancellationToken token = default) where T : class;
        void InvalidateKeys(params string[] keys);
        void InvalidateByPatterns(params string[] patterns);
        void Reset();
    }
}
