#r "nuget: System.Text.Json, 9.0.0"

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

// Simplified enum
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkMulti>))]
public enum VisNetworkMulti {
    False,
    True,
    Html,
    Markdown
}

// Simplified converter
public class VisNetworkEnumConverter<T> : JsonConverter<T> where T : struct, Enum {
    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options) {
        var stringValue = value.ToString();
        
        if (typeof(T) == typeof(VisNetworkMulti)) {
            if (value.Equals(VisNetworkMulti.False)) {
                writer.WriteBooleanValue(false);
            } else if (value.Equals(VisNetworkMulti.True)) {
                writer.WriteBooleanValue(true);
            } else {
                writer.WriteStringValue(stringValue.ToLowerInvariant());
            }
        } else {
            writer.WriteStringValue(stringValue.ToLowerInvariant());
        }
    }
}

// Font options
public class VisNetworkFontOptions {
    [JsonPropertyName("multi")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkMulti? Multi { get; set; }
}

// Node options
public class VisNetworkNodeOptions {
    [JsonPropertyName("id")]
    public object? Id { get; set; }
    
    [JsonPropertyName("label")]
    public string? Label { get; set; }
    
    [JsonPropertyName("font")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkFontOptions? Font { get; set; }
}

// Test
var node = new VisNetworkNodeOptions {
    Id = 1,
    Label = "<b>Test</b>",
    Font = new VisNetworkFontOptions { Multi = VisNetworkMulti.Html }
};

var json = JsonSerializer.Serialize(node, new JsonSerializerOptions { 
    WriteIndented = true,
    DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
});

Console.WriteLine(json);