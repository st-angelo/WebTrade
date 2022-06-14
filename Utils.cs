using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace WebTrade;

public static class Utils
{
    public async static Task SimulateDbWorkload()
    {
        Random random = new();
        await Task.Delay(random.Next(300, 601));
    }

    public static string GetCachePrefix(string prefix, string identifier = null) => $"{prefix}{(!string.IsNullOrWhiteSpace(identifier) ? $"_{identifier}" : string.Empty)}";

    #region Extension methods
    public static async Task SetAsync<T>(this IDistributedCache distributedCache, string key, T value, DistributedCacheEntryOptions options, CancellationToken token = default) where T : class
    {
        string val = JsonConvert.SerializeObject(value, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        await distributedCache.SetStringAsync(key, val, options, token);
    }

    public static async Task<T> GetAsync<T>(this IDistributedCache distributedCache, string key, CancellationToken token = default) where T : class
    {
        string result = await distributedCache.GetStringAsync(key, token);
        return result == null ? null : JsonConvert.DeserializeObject<T>(result);
    }

    public static void Deconstruct(this string[] array, out string key, out string value)
    {
        key = array.Length > 0 ? array[0] : default;
        value = array.Length > 1 ? array[1] : default;
    }

    public static T DeepCopy<T>(this T self)
    {
        string serialized = JsonConvert.SerializeObject(self, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        return JsonConvert.DeserializeObject<T>(serialized);
    }
    #endregion
}
