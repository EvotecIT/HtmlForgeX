using System.Net;
using System.Text;

namespace HtmlForgeX;

/// <summary>
/// Provides a fluent API for building HTML-formatted labels for VisNetwork nodes and edges.
/// </summary>
public class VisNetworkLabelBuilder {
    private readonly StringBuilder _html;
    private bool _inElement;

    /// <summary>
    /// Initializes a new instance of the VisNetworkLabelBuilder class.
    /// </summary>
    public VisNetworkLabelBuilder() {
        _html = new StringBuilder();
        _inElement = false;
    }

    /// <summary>
    /// Adds bold text to the label.
    /// </summary>
    /// <param name="text">The text to make bold</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder Bold(string text) {
        _html.Append($"<b>{WebUtility.HtmlEncode(text)}</b>");
        return this;
    }

    /// <summary>
    /// Adds italic text to the label.
    /// </summary>
    /// <param name="text">The text to make italic</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder Italic(string text) {
        _html.Append($"<i>{WebUtility.HtmlEncode(text)}</i>");
        return this;
    }

    /// <summary>
    /// Adds underlined text to the label.
    /// </summary>
    /// <param name="text">The text to underline</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder Underline(string text) {
        _html.Append($"<u>{WebUtility.HtmlEncode(text)}</u>");
        return this;
    }

    /// <summary>
    /// Adds plain text to the label.
    /// </summary>
    /// <param name="text">The text to add</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder Text(string text) {
        _html.Append(WebUtility.HtmlEncode(text));
        return this;
    }

    /// <summary>
    /// Adds colored text to the label.
    /// </summary>
    /// <param name="text">The text to color</param>
    /// <param name="color">The color (CSS color value)</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder ColoredText(string text, string color) {
        _html.Append($"<span style='color: {WebUtility.HtmlEncode(color)}'>{WebUtility.HtmlEncode(text)}</span>");
        return this;
    }

    /// <summary>
    /// Adds colored text to the label using RGBColor.
    /// </summary>
    /// <param name="text">The text to color</param>
    /// <param name="color">The color as RGBColor</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder ColoredText(string text, RGBColor color) {
        return ColoredText(text, color.ToHex());
    }

    /// <summary>
    /// Adds a line break to the label.
    /// </summary>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder LineBreak() {
        _html.Append("<br>");
        return this;
    }

    /// <summary>
    /// Adds a heading to the label.
    /// </summary>
    /// <param name="text">The heading text</param>
    /// <param name="level">The heading level (1-6)</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder Heading(string text, int level = 3) {
        if (level < 1) level = 1;
        if (level > 6) level = 6;
        _html.Append($"<h{level}>{WebUtility.HtmlEncode(text)}</h{level}>");
        return this;
    }

    /// <summary>
    /// Adds small text to the label.
    /// </summary>
    /// <param name="text">The text to make small</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder Small(string text) {
        _html.Append($"<small>{WebUtility.HtmlEncode(text)}</small>");
        return this;
    }

    /// <summary>
    /// Adds text with specific font size.
    /// </summary>
    /// <param name="text">The text to add</param>
    /// <param name="size">The font size in pixels</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder FontSize(string text, int size) {
        _html.Append($"<span style='font-size: {size}px'>{WebUtility.HtmlEncode(text)}</span>");
        return this;
    }

    /// <summary>
    /// Starts a centered section.
    /// </summary>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder StartCenter() {
        _html.Append("<div style='text-align: center'>");
        _inElement = true;
        return this;
    }

    /// <summary>
    /// Ends the current section.
    /// </summary>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder EndSection() {
        if (_inElement) {
            _html.Append("</div>");
            _inElement = false;
        }
        return this;
    }

    /// <summary>
    /// Starts an unordered list.
    /// </summary>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder StartList() {
        _html.Append("<ul>");
        return this;
    }

    /// <summary>
    /// Adds a list item.
    /// </summary>
    /// <param name="text">The item text</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder ListItem(string text) {
        _html.Append($"<li>{WebUtility.HtmlEncode(text)}</li>");
        return this;
    }

    /// <summary>
    /// Ends the current list.
    /// </summary>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder EndList() {
        _html.Append("</ul>");
        return this;
    }

    /// <summary>
    /// Builds the final HTML label string.
    /// </summary>
    /// <returns>The HTML-formatted label</returns>
    public string Build() {
        if (_inElement) {
            EndSection();
        }
        return _html.ToString();
    }

    /// <summary>
    /// Implicitly converts the builder to a string.
    /// </summary>
    /// <param name="builder">The label builder</param>
    public static implicit operator string(VisNetworkLabelBuilder builder) {
        return builder.Build();
    }
}