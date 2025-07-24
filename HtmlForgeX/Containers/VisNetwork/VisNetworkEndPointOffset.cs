namespace HtmlForgeX;

/// <summary>
/// End point offset configuration for edges.
/// </summary>
public class VisNetworkEndPointOffset {
    /// <summary>Gets or sets the from.</summary>
    [JsonPropertyName("from")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? From { get; set; }

    /// <summary>Gets or sets the to.</summary>
    [JsonPropertyName("to")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? To { get; set; }

    /// <summary>Configures the from.</summary>
    public VisNetworkEndPointOffset WithFrom(double offset) {
        From = offset;
        return this;
    }

    /// <summary>Configures the to.</summary>
    public VisNetworkEndPointOffset WithTo(double offset) {
        To = offset;
        return this;
    }
}