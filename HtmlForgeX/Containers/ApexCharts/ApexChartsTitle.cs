using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace HtmlForgeX;
public class ApexChartsTitle {
    [JsonPropertyName("text")]
    public string TitleText { get; set; }
    [JsonPropertyName("align")]
    public string TitleAlign { get; set; } = "center";
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

    public ApexChartsTitle Text(string text) {
        TitleText = text;
        return this;
    }

    public ApexChartsTitle Color(string color) {
        Style["color"] = color;
        return this;
    }

    public ApexChartsTitle Color(RGBColor color) {
        Style["color"] = color.ToHex();
        return this;
    }

    public ApexChartsTitle FontSize(string fontSize) {
        Style["fontSize"] = fontSize;
        return this;
    }

    public ApexChartsTitle FontWeight(string fontWeight) {
        Style["fontWeight"] = fontWeight;
        return this;
    }
}

public class ApexChartSubtitle {
    [JsonPropertyName("text")]
    public string SubTitleText { get; set; }
    public string SubTitleAlign { get; set; } = "center";
    public Dictionary<string, string> Style { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// Gets a value indicating whether ApexChartSubtitle is set.
    /// </summary>
    /// <value>
    ///   <c>true</c> if this instance is set; otherwise, <c>false</c>.
    /// </value>
    [JsonIgnore]
    public bool IsSet => !string.IsNullOrEmpty(SubTitleText);

    public ApexChartSubtitle Text(string text) {
        SubTitleText = text;
        return this;
    }

    public ApexChartSubtitle Color(string color) {
        Style["color"] = color;
        return this;
    }

    public ApexChartSubtitle Color(RGBColor color) {
        Style["color"] = color.ToHex();
        return this;
    }

    public ApexChartSubtitle FontSize(string fontSize) {
        Style["fontSize"] = fontSize;
        return this;
    }

    public ApexChartSubtitle FontWeight(string fontWeight) {
        Style["fontWeight"] = fontWeight;
        return this;
    }
}