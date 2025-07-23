using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Defines arrow positioning on an edge.
/// </summary>
[Flags]
public enum VisNetworkArrows {
    /// <summary>
    /// No arrows are rendered on the edge.
    /// </summary>
    None = 0,

    /// <summary>
    /// Draws an arrow pointing towards the target node.
    /// </summary>
    To = 1,

    /// <summary>
    /// Draws an arrow pointing away from the source node.
    /// </summary>
    From = 2,

    /// <summary>
    /// Draws an arrow in the middle of the edge.
    /// </summary>
    Middle = 4
}