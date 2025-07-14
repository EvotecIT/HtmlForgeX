using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Configuration options for a <see cref="QuillEditor"/> instance.
/// </summary>
public class QuillEditorOptions {
    [JsonPropertyName("theme")]
    /// <summary>
    /// Gets or sets the editor theme.
    /// </summary>
    public QuillTheme Theme { get; set; } = QuillTheme.Snow;

    [JsonPropertyName("readOnly")]
    /// <summary>
    /// Gets or sets a value indicating whether the editor is read only.
    /// </summary>
    public bool ReadOnly { get; set; }

    [JsonPropertyName("placeholder")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    /// <summary>
    /// Gets or sets placeholder text displayed when the editor is empty.
    /// </summary>
    public string? Placeholder { get; set; }

    [JsonPropertyName("modules")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    /// <summary>
    /// Gets or sets module configuration.
    /// </summary>
    public QuillModules? Modules { get; set; }

    [JsonPropertyName("formats")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(EnumListDescriptionConverter<QuillFormat>))]
    /// <summary>
    /// Gets or sets the enabled formatting options.
    /// </summary>
    public List<QuillFormat>? Formats { get; set; }
}
