using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Theme related configuration for ApexCharts.
/// </summary>
public class ApexThemeOptions {
    /// <summary>
    /// Gets or sets the theme mode to apply.
    /// </summary>
    [JsonPropertyName("mode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApexThemeMode? Mode { get; set; }

    /// <summary>
    /// Sets the desired <see cref="ApexThemeMode"/>.
    /// </summary>
    /// <param name="mode">Theme mode value.</param>
    /// <returns>The current <see cref="ApexThemeOptions"/> instance.</returns>
    public ApexThemeOptions ModeValue(ApexThemeMode mode) {
        Mode = mode;
        return this;
    }
}