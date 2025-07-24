using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Grid related options controlling layout around the chart.
/// </summary>
public class ApexGridOptions {
    /// <summary>
    /// Gets or sets padding around the chart area.
    /// </summary>
    [JsonPropertyName("padding")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApexGridPadding? Padding { get; set; }

    /// <summary>
    /// Configures the padding values using a fluent builder.
    /// </summary>
    /// <param name="configure">Delegate used to configure padding.</param>
    /// <returns>The current <see cref="ApexGridOptions"/> instance.</returns>
    public ApexGridOptions PaddingOptions(Action<ApexGridPadding> configure) {
        Padding ??= new ApexGridPadding();
        configure(Padding);
        return this;
    }
}