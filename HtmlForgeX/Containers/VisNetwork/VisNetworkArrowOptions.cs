namespace HtmlForgeX;

/// <summary>
/// Arrow configuration options for edges.
/// </summary>
public class VisNetworkArrowOptions {
    /// <summary>Gets or sets the to.</summary>
    [JsonPropertyName("to")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? To { get; set; }

    /// <summary>Gets or sets the from.</summary>
    [JsonPropertyName("from")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? From { get; set; }

    /// <summary>Gets or sets the middle.</summary>
    [JsonPropertyName("middle")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Middle { get; set; }

    /// <summary>Configures the to.</summary>
    public VisNetworkArrowOptions WithTo(bool enabled = true) {
        To = enabled;
        return this;
    }

    /// <summary>Configures the to.</summary>
    public VisNetworkArrowOptions WithTo(VisNetworkArrowTypeOptions options) {
        To = options;
        return this;
    }

    /// <summary>Configures the to.</summary>
    public VisNetworkArrowOptions WithTo(Action<VisNetworkArrowTypeOptions> configure) {
        var options = new VisNetworkArrowTypeOptions();
        configure(options);
        To = options;
        return this;
    }

    /// <summary>Configures the from.</summary>
    public VisNetworkArrowOptions WithFrom(bool enabled = true) {
        From = enabled;
        return this;
    }

    /// <summary>Configures the from.</summary>
    public VisNetworkArrowOptions WithFrom(VisNetworkArrowTypeOptions options) {
        From = options;
        return this;
    }

    /// <summary>Configures the from.</summary>
    public VisNetworkArrowOptions WithFrom(Action<VisNetworkArrowTypeOptions> configure) {
        var options = new VisNetworkArrowTypeOptions();
        configure(options);
        From = options;
        return this;
    }

    /// <summary>Configures the middle.</summary>
    public VisNetworkArrowOptions WithMiddle(bool enabled = true) {
        Middle = enabled;
        return this;
    }

    /// <summary>Configures the middle.</summary>
    public VisNetworkArrowOptions WithMiddle(VisNetworkArrowTypeOptions options) {
        Middle = options;
        return this;
    }

    /// <summary>Configures the middle.</summary>
    public VisNetworkArrowOptions WithMiddle(Action<VisNetworkArrowTypeOptions> configure) {
        var options = new VisNetworkArrowTypeOptions();
        configure(options);
        Middle = options;
        return this;
    }
}
