using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Options for the moveTo() method.
/// </summary>
public class VisNetworkMoveToOptions {
    /// <summary>
    /// Gets or sets the absolute position to move the viewport to.
    /// </summary>
    [JsonPropertyName("position")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkPosition? Position { get; set; }

    /// <summary>
    /// Gets or sets the zoom level after moving.
    /// </summary>
    [JsonPropertyName("scale")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Scale { get; set; }

    /// <summary>
    /// Gets or sets the offset relative to the target position.
    /// </summary>
    [JsonPropertyName("offset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public VisNetworkPosition? Offset { get; set; }

    /// <summary>
    /// Gets or sets the animation configuration. Can be a boolean or a complex options object.
    /// </summary>
    [JsonPropertyName("animation")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Animation { get; set; }

    /// <summary>
    /// Sets the position to move to.
    /// </summary>
    public VisNetworkMoveToOptions WithPosition(double x, double y) {
        Position = new VisNetworkPosition { X = x, Y = y };
        return this;
    }

    /// <summary>
    /// Sets the zoom scale.
    /// </summary>
    public VisNetworkMoveToOptions WithScale(double scale) {
        Scale = scale;
        return this;
    }

    /// <summary>
    /// Sets the offset.
    /// </summary>
    public VisNetworkMoveToOptions WithOffset(double x, double y) {
        Offset = new VisNetworkPosition { X = x, Y = y };
        return this;
    }

    /// <summary>
    /// Enables animation with default settings.
    /// </summary>
    public VisNetworkMoveToOptions WithAnimation(bool enabled = true) {
        Animation = enabled;
        return this;
    }

    /// <summary>
    /// Configures animation options.
    /// </summary>
    public VisNetworkMoveToOptions WithAnimation(Action<VisNetworkAnimationOptions> configure) {
        var animOptions = new VisNetworkAnimationOptions();
        configure(animOptions);
        Animation = animOptions;
        return this;
    }
}
