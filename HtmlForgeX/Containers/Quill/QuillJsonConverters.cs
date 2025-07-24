using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Converts a list of enum values to and from their <see cref="DescriptionAttribute"/> values.
/// </summary>
public class EnumListDescriptionConverter<T> : JsonConverter<List<T>> where T : Enum {
    /// <inheritdoc />
    public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var list = JsonSerializer.Deserialize<List<string>>(ref reader, options) ?? new List<string>();
        var result = new List<T>();
        foreach (var item in list) {
            var value = ((T[])Enum.GetValues(typeof(T))).First(e => GetDescription(e) == item);
            result.Add(value);
        }
        return result;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options) {
        var list = value.Select(GetDescription).ToList();
        JsonSerializer.Serialize(writer, list, options);
    }

    /// <summary>
    /// Retrieves the description attribute value for the provided enum item.
    /// </summary>
    /// <param name="value">Enum value to retrieve description for.</param>
    /// <returns>Description string.</returns>
    private static string GetDescription(T value) {
        return value.GetType()
            .GetMember(value.ToString())
            .First()
            .GetCustomAttribute<DescriptionAttribute>()!
            .Description;
    }
}