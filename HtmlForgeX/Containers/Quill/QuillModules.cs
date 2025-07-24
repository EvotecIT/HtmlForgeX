using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents configuration for Quill modules.
/// </summary>
public class QuillModules {
    /// <summary>
    /// Gets or sets clipboard module configuration.
    /// </summary>
    [JsonPropertyName("clipboard")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Clipboard { get; set; }

    /// <summary>
    /// Gets or sets a toolbar configuration.
    /// Can be a simple array of formats, an array of arrays for grouped buttons,
    /// or custom toolbar configuration object.
    /// </summary>
    [JsonPropertyName("toolbar")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(QuillToolbarConverter))]
    public object? Toolbar { get; set; }
}