using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Options for the focus() method.
/// </summary>
public class VisNetworkFocusOptions {
    /// <summary>
    /// Gets or sets the zoom scale where <c>1.0</c> represents 100&#x25;.
    /// </summary>
    [JsonPropertyName("scale")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Scale { get; set; }

    /// <summary>
    /// Gets or sets the offset from the viewport center.
    /// </summary>
    [JsonPropertyName("offset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkPosition? Offset { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the view remains locked to the node.
    /// </summary>
    [JsonPropertyName("locked")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Locked { get; set; }

    /// <summary>
    /// Gets or sets the animation configuration. Can be a boolean or a complex options object.
    /// </summary>
    [JsonPropertyName("animation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Animation { get; set; }

    /// <summary>
    /// Sets the zoom scale (1.0 = 100%).
    /// </summary>
    public VisNetworkFocusOptions WithScale(double scale) {
        Scale = scale;
        return this;
    }

    /// <summary>
    /// Sets the offset from center.
    /// </summary>
    public VisNetworkFocusOptions WithOffset(double x, double y) {
        Offset = new VisNetworkPosition { X = x, Y = y };
        return this;
    }

    /// <summary>
    /// Sets whether the view remains locked to the node.
    /// </summary>
    public VisNetworkFocusOptions WithLocked(bool locked = true) {
        Locked = locked;
        return this;
    }

    /// <summary>
    /// Enables animation with default settings.
    /// </summary>
    public VisNetworkFocusOptions WithAnimation(bool enabled = true) {
        Animation = enabled;
        return this;
    }

    /// <summary>
    /// Configures animation options.
    /// </summary>
    public VisNetworkFocusOptions WithAnimation(Action<VisNetworkAnimationOptions> configure) {
        var animOptions = new VisNetworkAnimationOptions();
        configure(animOptions);
        Animation = animOptions;
        return this;
    }
}