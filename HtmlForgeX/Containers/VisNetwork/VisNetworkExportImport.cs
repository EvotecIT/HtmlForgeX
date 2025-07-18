using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents the exported data from a VisNetwork instance.
/// </summary>
public class VisNetworkExportData {
    /// <summary>
    /// Gets or sets the nodes data.
    /// </summary>
    [JsonPropertyName("nodes")]
    public List<Dictionary<string, object>>? Nodes { get; set; }

    /// <summary>
    /// Gets or sets the edges data.
    /// </summary>
    [JsonPropertyName("edges")]
    public List<Dictionary<string, object>>? Edges { get; set; }

    /// <summary>
    /// Gets or sets the node positions.
    /// </summary>
    [JsonPropertyName("positions")]
    public Dictionary<string, VisNetworkPosition>? Positions { get; set; }

    /// <summary>
    /// Gets or sets the viewport position and scale.
    /// </summary>
    [JsonPropertyName("viewport")]
    public VisNetworkViewport? Viewport { get; set; }

    /// <summary>
    /// Gets or sets the network options.
    /// </summary>
    [JsonPropertyName("options")]
    public Dictionary<string, object>? Options { get; set; }

    /// <summary>
    /// Gets or sets the export timestamp.
    /// </summary>
    [JsonPropertyName("timestamp")]
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the export version.
    /// </summary>
    [JsonPropertyName("version")]
    public string Version { get; set; } = "1.0";
}

/// <summary>
/// Represents the viewport state of a VisNetwork.
/// </summary>
public class VisNetworkViewport {
    /// <summary>
    /// Gets or sets the center position.
    /// </summary>
    [JsonPropertyName("position")]
    public VisNetworkPosition? Position { get; set; }

    /// <summary>
    /// Gets or sets the zoom scale.
    /// </summary>
    [JsonPropertyName("scale")]
    public double Scale { get; set; } = 1.0;
}

/// <summary>
/// Options for exporting network data.
/// </summary>
public class VisNetworkExportOptions {
    /// <summary>
    /// Gets or sets whether to include node positions.
    /// </summary>
    public bool IncludePositions { get; set; } = true;

    /// <summary>
    /// Gets or sets whether to include viewport state.
    /// </summary>
    public bool IncludeViewport { get; set; } = true;

    /// <summary>
    /// Gets or sets whether to include network options.
    /// </summary>
    public bool IncludeOptions { get; set; } = false;

    /// <summary>
    /// Gets or sets whether to include hidden nodes/edges.
    /// </summary>
    public bool IncludeHidden { get; set; } = true;
}