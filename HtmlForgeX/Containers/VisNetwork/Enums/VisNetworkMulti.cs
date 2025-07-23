using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Multi-line text formatting options for labels.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkMulti>))]
public enum VisNetworkMulti {
    /// <summary>
    /// Multi-line text is disabled.
    /// </summary>
    False,

    /// <summary>
    /// Multi-line text is enabled.
    /// </summary>
    True,

    /// <summary>
    /// Interpret text as HTML markup.
    /// </summary>
    Html,

    /// <summary>
    /// Interpret text as Markdown.
    /// </summary>
    Markdown
}