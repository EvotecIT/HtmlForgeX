using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Text alignment options for labels and other text elements.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkAlign>))]
public enum VisNetworkAlign {
    /// <summary>
    /// Align text to the left.
    /// </summary>
    Left,

    /// <summary>
    /// Center text.
    /// </summary>
    Center,

    /// <summary>
    /// Align text to the right.
    /// </summary>
    Right
}