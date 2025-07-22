using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents advanced color configuration options for VisNetwork edges.
/// Supports basic color, hover/highlight states, opacity, and inheritance.
/// </summary>
public class VisNetworkAdvancedColorOptions {
    /// <summary>
    /// Gets or sets the primary color.
    /// Can be a hex string, RGB string, or color name.
    /// </summary>
    [JsonPropertyName("color")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Color { get; set; }

    /// <summary>
    /// Gets or sets the color to use when the element is highlighted.
    /// </summary>
    [JsonPropertyName("highlight")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Highlight { get; set; }

    /// <summary>
    /// Gets or sets the color to use when hovering over the element.
    /// </summary>
    [JsonPropertyName("hover")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Hover { get; set; }

    /// <summary>
    /// Gets or sets the opacity of the element (0.0 to 1.0).
    /// </summary>
    [JsonPropertyName("opacity")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Opacity { get; set; }

    /// <summary>
    /// Gets or sets the color inheritance mode for edges.
    /// Can be "from", "to", "both", or false.
    /// </summary>
    [JsonPropertyName("inherit")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Inherit { get; set; }

    #region Fluent API

    /// <summary>
    /// Sets the primary color.
    /// </summary>
    /// <param name="color">The color value.</param>
    /// <returns>The color options for method chaining.</returns>
    public VisNetworkAdvancedColorOptions WithColor(string color) {
        Color = color;
        return this;
    }

    /// <summary>
    /// Sets the primary color using an RGBColor.
    /// </summary>
    /// <param name="color">The color value.</param>
    /// <returns>The color options for method chaining.</returns>
    public VisNetworkAdvancedColorOptions WithColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    /// <summary>
    /// Sets the highlight color.
    /// </summary>
    /// <param name="color">The highlight color value.</param>
    /// <returns>The color options for method chaining.</returns>
    public VisNetworkAdvancedColorOptions WithHighlight(string color) {
        Highlight = color;
        return this;
    }

    /// <summary>
    /// Sets the highlight color using an RGBColor.
    /// </summary>
    /// <param name="color">The highlight color value.</param>
    /// <returns>The color options for method chaining.</returns>
    public VisNetworkAdvancedColorOptions WithHighlight(RGBColor color) {
        Highlight = color.ToHex();
        return this;
    }

    /// <summary>
    /// Sets the hover color.
    /// </summary>
    /// <param name="color">The hover color value.</param>
    /// <returns>The color options for method chaining.</returns>
    public VisNetworkAdvancedColorOptions WithHover(string color) {
        Hover = color;
        return this;
    }

    /// <summary>
    /// Sets the hover color using an RGBColor.
    /// </summary>
    /// <param name="color">The hover color value.</param>
    /// <returns>The color options for method chaining.</returns>
    public VisNetworkAdvancedColorOptions WithHover(RGBColor color) {
        Hover = color.ToHex();
        return this;
    }

    /// <summary>
    /// Sets the opacity.
    /// </summary>
    /// <param name="opacity">The opacity value (0.0 to 1.0).</param>
    /// <returns>The color options for method chaining.</returns>
    public VisNetworkAdvancedColorOptions WithOpacity(double opacity) {
        Opacity = opacity;
        return this;
    }

    /// <summary>
    /// Sets the color inheritance mode.
    /// </summary>
    /// <param name="inherit">The inheritance mode.</param>
    /// <returns>The color options for method chaining.</returns>
    public VisNetworkAdvancedColorOptions WithInherit(VisNetworkColorInherit inherit) {
        Inherit = inherit switch {
            VisNetworkColorInherit.From => "from",
            VisNetworkColorInherit.To => "to",
            VisNetworkColorInherit.Both => "both",
            VisNetworkColorInherit.False => false,
            _ => null
        };
        return this;
    }

    #endregion
}