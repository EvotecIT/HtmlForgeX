using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Keyboard navigation speed options.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkKeyboardSpeed>))]
public enum VisNetworkKeyboardSpeed {
    /// <summary>
    /// Horizontal movement speed.
    /// </summary>
    X,

    /// <summary>
    /// Vertical movement speed.
    /// </summary>
    Y,

    /// <summary>
    /// Zoom speed.
    /// </summary>
    Zoom
}