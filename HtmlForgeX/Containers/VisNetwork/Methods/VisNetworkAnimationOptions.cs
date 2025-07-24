using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Animation options for network methods.
/// </summary>
public class VisNetworkAnimationOptions {
    /// <summary>
    /// Gets or sets the animation duration in milliseconds.
    /// </summary>
    [JsonPropertyName("duration")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Duration { get; set; }

    /// <summary>
    /// Gets or sets the name of the easing function to apply.
    /// </summary>
    [JsonPropertyName("easingFunction")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? EasingFunction { get; set; }

    /// <summary>
    /// Sets the animation duration in milliseconds.
    /// </summary>
    public VisNetworkAnimationOptions WithDuration(int milliseconds) {
        Duration = milliseconds;
        return this;
    }

    /// <summary>
    /// Sets the easing function.
    /// </summary>
    public VisNetworkAnimationOptions WithEasingFunction(VisNetworkEasingFunction easing) {
        // Convert to camelCase for vis-network compatibility
        var easingString = easing.ToString();
        EasingFunction = char.ToLowerInvariant(easingString[0]) + easingString.Substring(1);
        return this;
    }
}