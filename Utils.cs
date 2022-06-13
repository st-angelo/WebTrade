using Newtonsoft.Json;

namespace WebTrade;

public static class Utils
{
    public async static Task SimulateDbQuery()
    {
        Random random = new();
        await Task.Delay(random.Next(100, 501));
    }

    public static T DeepCopy<T>(this T self)
    {
        var serialized = JsonConvert.SerializeObject(self);
        return JsonConvert.DeserializeObject<T>(serialized);
    }
}
