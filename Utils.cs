using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace WebTrade;

public static class Utils
{
    public async static Task SimulateDbQuery()
    {
        Random random = new();
        await Task.Delay(random.Next(100, 401));
    }

    public static string GetCachePrefix(string prefix, string id = null) => $"{prefix}{(!string.IsNullOrWhiteSpace(id) ? $"_{id}" : string.Empty)}";

    #region Extension methods
    public static async Task SetAsync<T>(this IDistributedCache distributedCache, string key, T value, DistributedCacheEntryOptions options, CancellationToken token = default) where T : class
    {
        var v = JsonConvert.SerializeObject(value, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        await distributedCache.SetStringAsync(key, v, options, token);
    }

    public static async Task<T> GetAsync<T>(this IDistributedCache distributedCache, string key, CancellationToken token = default) where T : class
    {
        var result = await distributedCache.GetStringAsync(key, token);
        return result == null ? null : JsonConvert.DeserializeObject<T>(result);
    }

    public static T DeepCopy<T>(this T self)
    {
        var serialized = JsonConvert.SerializeObject(self);
        return JsonConvert.DeserializeObject<T>(serialized);
    }
    #endregion
}
