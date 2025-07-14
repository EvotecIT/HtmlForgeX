using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Options controlling tooltip behaviour.
/// </summary>
public class ApexTooltipOptions {
    /// <summary>
    /// Gets or sets a value indicating whether tooltips are enabled.
    /// </summary>
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    /// <summary>
    /// Enables or disables tooltips.
    /// </summary>
    /// <param name="enabled">True to enable tooltips.</param>
    /// <returns>The current <see cref="ApexTooltipOptions"/> instance.</returns>
    public ApexTooltipOptions Enable(bool enabled) {
        Enabled = enabled;
        return this;
    }
}
