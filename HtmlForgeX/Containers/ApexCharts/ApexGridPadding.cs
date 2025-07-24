using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Padding configuration applied to the grid surrounding the chart.
/// </summary>
public class ApexGridPadding {
    /// <summary>
    /// Gets or sets the padding above the chart area.
    /// </summary>
    [JsonPropertyName("top")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Top { get; set; }

    /// <summary>
    /// Gets or sets the padding on the right side of the chart area.
    /// </summary>
    [JsonPropertyName("right")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Right { get; set; }

    /// <summary>
    /// Gets or sets the padding below the chart area.
    /// </summary>
    [JsonPropertyName("bottom")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Bottom { get; set; }

    /// <summary>
    /// Gets or sets the padding on the left side of the chart area.
    /// </summary>
    [JsonPropertyName("left")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Left { get; set; }

    /// <summary>
    /// Sets the top padding value.
    /// </summary>
    /// <param name="value">Padding in pixels.</param>
    /// <returns>The current <see cref="ApexGridPadding"/> instance.</returns>
    public ApexGridPadding TopPadding(int value) {
        Top = value;
        return this;
    }

    /// <summary>
    /// Sets the right padding value.
    /// </summary>
    /// <param name="value">Padding in pixels.</param>
    /// <returns>The current <see cref="ApexGridPadding"/> instance.</returns>
    public ApexGridPadding RightPadding(int value) {
        Right = value;
        return this;
    }

    /// <summary>
    /// Sets the bottom padding value.
    /// </summary>
    /// <param name="value">Padding in pixels.</param>
    /// <returns>The current <see cref="ApexGridPadding"/> instance.</returns>
    public ApexGridPadding BottomPadding(int value) {
        Bottom = value;
        return this;
    }

    /// <summary>
    /// Sets the left padding value.
    /// </summary>
    /// <param name="value">Padding in pixels.</param>
    /// <returns>The current <see cref="ApexGridPadding"/> instance.</returns>
    public ApexGridPadding LeftPadding(int value) {
        Left = value;
        return this;
    }

    /// <summary>
    /// Sets all padding values to the same amount.
    /// </summary>
    /// <param name="value">Padding in pixels.</param>
    /// <returns>The current <see cref="ApexGridPadding"/> instance.</returns>
    public ApexGridPadding All(int value) {
        Top = value;
        Right = value;
        Bottom = value;
        Left = value;
        return this;
    }
}