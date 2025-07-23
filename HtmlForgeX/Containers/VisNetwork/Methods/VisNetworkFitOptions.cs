using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Options for the fit() method.
/// </summary>
public class VisNetworkFitOptions {
    /// <summary>
    /// Gets or sets the node identifiers to fit. When <see langword="null"/>,
    /// all nodes are used.
    /// </summary>
    [JsonPropertyName("nodes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object[]? Nodes { get; set; }

    /// <summary>
    /// Gets or sets the minimum zoom level.
    /// </summary>
    [JsonPropertyName("minZoomLevel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MinZoomLevel { get; set; }

    /// <summary>
    /// Gets or sets the maximum zoom level.
    /// </summary>
    [JsonPropertyName("maxZoomLevel")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? MaxZoomLevel { get; set; }

    /// <summary>
    /// Gets or sets the animation configuration. Can be a boolean or a complex
    /// options object.
    /// </summary>
    [JsonPropertyName("animation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Animation { get; set; }

    /// <summary>
    /// Sets the nodes to fit. If not specified, fits all nodes.
    /// </summary>
    public VisNetworkFitOptions WithNodes(params object[] nodeIds) {
        Nodes = nodeIds;
        return this;
    }

    /// <summary>
    /// Sets the minimum zoom level.
    /// </summary>
    public VisNetworkFitOptions WithMinZoomLevel(double minZoom) {
        MinZoomLevel = minZoom;
        return this;
    }

    /// <summary>
    /// Sets the maximum zoom level.
    /// </summary>
    public VisNetworkFitOptions WithMaxZoomLevel(double maxZoom) {
        MaxZoomLevel = maxZoom;
        return this;
    }

    /// <summary>
    /// Enables animation with default settings.
    /// </summary>
    public VisNetworkFitOptions WithAnimation(bool enabled = true) {
        Animation = enabled;
        return this;
    }

    /// <summary>
    /// Configures animation options.
    /// </summary>
    public VisNetworkFitOptions WithAnimation(Action<VisNetworkAnimationOptions> configure) {
        var animOptions = new VisNetworkAnimationOptions();
        configure(animOptions);
        Animation = animOptions;
        return this;
    }
}
