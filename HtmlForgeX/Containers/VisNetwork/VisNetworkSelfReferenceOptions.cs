namespace HtmlForgeX;

/// <summary>
/// Self reference configuration for edges that connect a node to itself.
/// </summary>
public class VisNetworkSelfReferenceOptions {
    /// <summary>Gets or sets the size.</summary>
    [JsonPropertyName("size")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Size { get; set; }

    /// <summary>Gets or sets the angle.</summary>
    [JsonPropertyName("angle")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Angle { get; set; }

    /// <summary>Gets or sets the render behind the node.</summary>
    [JsonPropertyName("renderBehindTheNode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? RenderBehindTheNode { get; set; }

    /// <summary>Configures the size.</summary>
    public VisNetworkSelfReferenceOptions WithSize(double size) {
        Size = size;
        return this;
    }

    /// <summary>Configures the angle.</summary>
    public VisNetworkSelfReferenceOptions WithAngle(double angle) {
        Angle = angle;
        return this;
    }

    /// <summary>Configures the render behind the node.</summary>
    public VisNetworkSelfReferenceOptions WithRenderBehindTheNode(bool renderBehind = true) {
        RenderBehindTheNode = renderBehind;
        return this;
    }
}