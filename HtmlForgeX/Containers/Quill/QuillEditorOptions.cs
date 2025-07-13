using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class QuillEditorOptions {
    [JsonPropertyName("theme")]
    public string Theme { get; set; } = "snow";

    [JsonPropertyName("readOnly")]
    public bool ReadOnly { get; set; }

    [JsonPropertyName("placeholder")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Placeholder { get; set; }

    [JsonPropertyName("modules")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Dictionary<string, object>? Modules { get; set; }
}
