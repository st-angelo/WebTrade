using WebTrade.Entities;
using WebTrade.Services;

namespace WebTrade.Repositories;

public class CacheRepository : ICacheRepository
{
    private readonly ICacheRepository _inner;
    private readonly ICacheService _cache;

    public CacheRepository(ICacheRepository inner, ICacheService cache)
    {
        _inner = inner;
        _cache = cache;
    }

    public async Task<IEnumerable<Trade>> GetTrades(Guid? userId = null)
    {
        var _key = Utils.GetCachePrefix(CacheKey.Trades, userId.ToString());
        IEnumerable<Trade> result = await _cache.GetAsync<IEnumerable<Trade>>(_key);

        if (result == null)
        {
            result = await _inner.GetTrades(userId);
            await _cache.SetAsync(_key, result);
        }

        return result;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        var _key = Utils.GetCachePrefix(CacheKey.Users);
        IEnumerable<User> result = await _cache.GetAsync<IEnumerable<User>>(_key);

        if (result == null)
        {
            result = await _inner.GetUsers();
            await _cache.SetAsync(_key, result);
        }

        return result;
    }

    public async Task<User> GetUser(Guid id)
    {
        var _key = Utils.GetCachePrefix(CacheKey.User, id.ToString());
        User result = await _cache.GetAsync<User>(_key);

        if (result == null)
        {
            result = await _inner.GetUser(id);
            await _cache.SetAsync(_key, result);
        }

        return result;
    }

    public async Task<IEnumerable<Security>> GetSecurities()
    {
        var _key = Utils.GetCachePrefix(CacheKey.Securities);
        IEnumerable<Security> result = await _cache.GetAsync<IEnumerable<Security>>(_key);

        if (result == null)
        {
            result = await _inner.GetSecurities();
            await _cache.SetAsync(_key, result);
        }

        return result;
    }

    public async Task<Security> GetSecurity(Guid id)
    {
        var _key = Utils.GetCachePrefix(CacheKey.Security, id.ToString());
        Security result = await _cache.GetAsync<Security>(_key);

        if (result == null)
        {
            result = await _inner.GetSecurity(id);
            await _cache.SetAsync(_key, result);
        }

        return result;
    }
}
