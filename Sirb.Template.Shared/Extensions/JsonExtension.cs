using System.Text.Json;

namespace Sirb.Template.Shared.Extensions
{
    public static class JsonExtension
    {
        public static string ToJson(this object value)
        {
            return JsonSerializer.Serialize(value);
        }

        public static T FromJson<T>(this string value) where T : class
        {
            return JsonSerializer.Deserialize<T>(value);
        }
    }

}