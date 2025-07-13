using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class QuillModules {
    [JsonPropertyName("clipboard")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Clipboard { get; set; }

    [JsonPropertyName("toolbar")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(EnumListDescriptionConverter<QuillFormat>))]
    public List<QuillFormat>? Toolbar { get; set; }
}
