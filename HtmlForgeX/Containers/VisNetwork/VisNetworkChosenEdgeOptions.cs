namespace HtmlForgeX;

/// <summary>
/// Chosen edge configuration options.
/// </summary>
public class VisNetworkChosenEdgeOptions {
    /// <summary>Gets or sets the edge.</summary>
    [JsonPropertyName("edge")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Edge { get; set; }

    /// <summary>Gets or sets the label.</summary>
    [JsonPropertyName("label")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Label { get; set; }

    /// <summary>Configures the edge.</summary>
    public VisNetworkChosenEdgeOptions WithEdge(bool enabled = true) {
        Edge = enabled;
        return this;
    }

    /// <summary>Configures the label.</summary>
    public VisNetworkChosenEdgeOptions WithLabel(bool enabled = true) {
        Label = enabled;
        return this;
    }
}