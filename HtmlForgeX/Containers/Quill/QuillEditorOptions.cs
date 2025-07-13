using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class QuillEditorOptions {
    [JsonPropertyName("theme")]
    public QuillTheme Theme { get; set; } = QuillTheme.Snow;

    [JsonPropertyName("readOnly")]
    public bool ReadOnly { get; set; }

    [JsonPropertyName("placeholder")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Placeholder { get; set; }

    [JsonPropertyName("modules")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public QuillModules? Modules { get; set; }

    [JsonPropertyName("formats")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(EnumListDescriptionConverter<QuillFormat>))]
    public List<QuillFormat>? Formats { get; set; }
}
