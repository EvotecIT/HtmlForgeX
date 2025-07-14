using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents configuration for Quill modules.
/// </summary>
public class QuillModules {
    [JsonPropertyName("clipboard")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    /// <summary>
    /// Gets or sets clipboard module configuration.
    /// </summary>
    public object? Clipboard { get; set; }

    [JsonPropertyName("toolbar")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(EnumListDescriptionConverter<QuillFormat>))]
    /// <summary>
    /// Gets or sets a toolbar configuration defined as a list of formats.
    /// </summary>
    public List<QuillFormat>? Toolbar { get; set; }
}
