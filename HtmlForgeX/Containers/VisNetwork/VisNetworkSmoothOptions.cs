namespace HtmlForgeX;

/// <summary>
/// Smooth curve configuration for edges.
/// </summary>
public class VisNetworkSmoothOptions {
    /// <summary>Gets or sets the enabled.</summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>Gets or sets the type.</summary>
    [JsonPropertyName("type")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkSmoothType? Type { get; set; }

    /// <summary>Gets or sets the force direction.</summary>
    [JsonPropertyName("forceDirection")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? ForceDirection { get; set; }

    /// <summary>Gets or sets the roundness.</summary>
    [JsonPropertyName("roundness")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Roundness { get; set; }

    /// <summary>Configures the enabled.</summary>
    public VisNetworkSmoothOptions WithEnabled(bool enabled = true) {
        Enabled = enabled;
        return this;
    }

    /// <summary>Configures the type.</summary>
    public VisNetworkSmoothOptions WithType(VisNetworkSmoothType type) {
        Type = type;
        return this;
    }

    /// <summary>Configures the force direction.</summary>
    public VisNetworkSmoothOptions WithForceDirection(VisNetworkForceDirection direction) {
        ForceDirection = direction;
        return this;
    }

    /// <summary>Configures the force direction.</summary>
    public VisNetworkSmoothOptions WithForceDirection(string direction) {
        // For backward compatibility
        ForceDirection = direction;
        return this;
    }

    /// <summary>Configures the force direction.</summary>
    public VisNetworkSmoothOptions WithForceDirection(bool enabled) {
        ForceDirection = enabled;
        return this;
    }

    /// <summary>Configures the roundness.</summary>
    public VisNetworkSmoothOptions WithRoundness(double roundness) {
        Roundness = roundness;
        return this;
    }
}