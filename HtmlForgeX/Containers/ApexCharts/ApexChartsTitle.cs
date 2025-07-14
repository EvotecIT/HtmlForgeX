using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HtmlForgeX;
/// <summary>
/// Builder for configuring chart title appearance when using ApexCharts. Allows
/// setting main titles and subtitles with styling.
/// </summary>
public class ApexChartsTitle {
    /// <summary>
    /// Gets or sets the title text.
    /// </summary>
    [JsonPropertyName("text")]
    public string? TitleText { get; set; }
    /// <summary>
    /// Gets or sets the title alignment.
    /// </summary>
    [JsonPropertyName("align")]
    public string TitleAlign { get; set; } = "center";
    /// <summary>
    /// Gets the style dictionary applied to the title.
    /// </summary>
    [JsonPropertyName("style")]
    public Dictionary<string, string> Style { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// Gets a value indicating whether ApexChartTitle is set.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is set; otherwise, <c>false</c>.
    /// </value>
    [JsonIgnore]
    public bool IsSet => !string.IsNullOrEmpty(TitleText);

    /// <summary>
    /// Sets the title text.
    /// </summary>
    /// <param name="text">Text to display.</param>
    /// <returns>The current <see cref="ApexChartsTitle"/> instance.</returns>
    public ApexChartsTitle Text(string text) {
        TitleText = text;
        return this;
    }

    /// <summary>
    /// Sets the title color using a CSS string value.
    /// </summary>
    /// <param name="color">Color value.</param>
    /// <returns>The current <see cref="ApexChartsTitle"/> instance.</returns>
    public ApexChartsTitle Color(string color) {
        Style["color"] = color;
        return this;
    }

    /// <summary>
    /// Sets the title color from an <see cref="RGBColor"/>.
    /// </summary>
    /// <param name="color">Color value.</param>
    /// <returns>The current <see cref="ApexChartsTitle"/> instance.</returns>
    public ApexChartsTitle Color(RGBColor color) {
        Style["color"] = color.ToString();
        return this;
    }

    /// <summary>
    /// Sets the title font size.
    /// </summary>
    /// <param name="fontSize">Size value with units.</param>
    /// <returns>The current <see cref="ApexChartsTitle"/> instance.</returns>
    public ApexChartsTitle FontSize(string fontSize) {
        Style["fontSize"] = fontSize;
        return this;
    }

    /// <summary>
    /// Sets the title font weight.
    /// </summary>
    /// <param name="fontWeight">Font weight value.</param>
    /// <returns>The current <see cref="ApexChartsTitle"/> instance.</returns>
    public ApexChartsTitle FontWeight(string fontWeight) {
        Style["fontWeight"] = fontWeight;
        return this;
    }
}

/// <summary>
/// Builder for configuring a chart subtitle.
/// </summary>
public class ApexChartSubtitle {
    /// <summary>
    /// Gets or sets the subtitle text.
    /// </summary>
    [JsonPropertyName("text")]
    public string? SubTitleText { get; set; }
    /// <summary>
    /// Gets or sets the subtitle alignment.
    /// </summary>
    public string SubTitleAlign { get; set; } = "center";
    /// <summary>
    /// Gets the style dictionary applied to the subtitle.
    /// </summary>
    public Dictionary<string, string> Style { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// Gets a value indicating whether ApexChartSubtitle is set.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is set; otherwise, <c>false</c>.
    /// </value>
    [JsonIgnore]
    public bool IsSet => !string.IsNullOrEmpty(SubTitleText);

    /// <summary>
    /// Sets the subtitle text.
    /// </summary>
    /// <param name="text">Text to display.</param>
    /// <returns>The current <see cref="ApexChartSubtitle"/> instance.</returns>
    public ApexChartSubtitle Text(string text) {
        SubTitleText = text;
        return this;
    }

    /// <summary>
    /// Sets the subtitle color using a CSS value.
    /// </summary>
    /// <param name="color">Color value.</param>
    /// <returns>The current <see cref="ApexChartSubtitle"/> instance.</returns>
    public ApexChartSubtitle Color(string color) {
        Style["color"] = color;
        return this;
    }

    /// <summary>
    /// Sets the subtitle color from an <see cref="RGBColor"/> instance.
    /// </summary>
    /// <param name="color">Color value.</param>
    /// <returns>The current <see cref="ApexChartSubtitle"/> instance.</returns>
    public ApexChartSubtitle Color(RGBColor color) {
        Style["color"] = color.ToHex();
        return this;
    }

    /// <summary>
    /// Sets the subtitle font size.
    /// </summary>
    /// <param name="fontSize">Size value with units.</param>
    /// <returns>The current <see cref="ApexChartSubtitle"/> instance.</returns>
    public ApexChartSubtitle FontSize(string fontSize) {
        Style["fontSize"] = fontSize;
        return this;
    }

    /// <summary>
    /// Sets the subtitle font weight.
    /// </summary>
    /// <param name="fontWeight">Font weight value.</param>
    /// <returns>The current <see cref="ApexChartSubtitle"/> instance.</returns>
    public ApexChartSubtitle FontWeight(string fontWeight) {
        Style["fontWeight"] = fontWeight;
        return this;
    }
}