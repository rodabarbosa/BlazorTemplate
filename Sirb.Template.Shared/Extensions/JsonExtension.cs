using System.Text.Json;

namespace Sirb.Template.Shared.Extensions
{
    public static class JsonExtension
    {
        public static string ToJson(this object value) => JsonSerializer.Serialize(value);

        public static T FromJson<T>(this string value) where T : class
        {
            if (string.IsNullOrEmpty(value?.Trim()))
                return default!;

            return JsonSerializer.Deserialize<T>(value)!;
        }
    }
}
