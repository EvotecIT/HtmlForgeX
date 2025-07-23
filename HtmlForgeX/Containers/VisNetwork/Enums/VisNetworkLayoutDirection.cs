using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Hierarchical layout direction options.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkLayoutDirection>))]
public enum VisNetworkLayoutDirection {
    /// <summary>
    /// Top to bottom layout.
    /// </summary>
    Ud,  // up-down

    /// <summary>
    /// Bottom to top layout.
    /// </summary>
    Du,  // down-up

    /// <summary>
    /// Left to right layout.
    /// </summary>
    Lr,  // left-right

    /// <summary>
    /// Right to left layout.
    /// </summary>
    Rl   // right-left
}