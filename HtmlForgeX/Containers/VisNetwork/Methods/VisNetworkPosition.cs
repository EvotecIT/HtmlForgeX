using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Position representation.
/// </summary>
public class VisNetworkPosition {
    /// <summary>
    /// Gets or sets the horizontal coordinate.
    /// </summary>
    [JsonPropertyName("x")]
    public double X { get; set; }

    /// <summary>
    /// Gets or sets the vertical coordinate.
    /// </summary>
    [JsonPropertyName("y")]
    public double Y { get; set; }
}
