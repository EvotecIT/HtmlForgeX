using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Configuration options for a <see cref="QuillEditor"/> instance.
/// </summary>
public class QuillEditorOptions {
    /// <summary>
    /// Gets or sets the editor theme.
    /// </summary>
    [JsonPropertyName("theme")]
    public QuillTheme Theme { get; set; } = QuillTheme.Snow;

    /// <summary>
    /// Gets or sets a value indicating whether the editor is read only.
    /// </summary>
    [JsonPropertyName("readOnly")]
    public bool ReadOnly { get; set; }

    /// <summary>
    /// Gets or sets placeholder text displayed when the editor is empty.
    /// </summary>
    [JsonPropertyName("placeholder")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Placeholder { get; set; }

    /// <summary>
    /// Gets or sets module configuration.
    /// </summary>
    [JsonPropertyName("modules")]
    public QuillModules Modules { get; set; } = new();

    /// <summary>
    /// Gets or sets the enabled formatting options.
    /// </summary>
    [JsonPropertyName("formats")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonConverter(typeof(EnumListDescriptionConverter<QuillFormat>))]
    public List<QuillFormat>? Formats { get; set; }
}