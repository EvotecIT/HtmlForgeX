using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// A concrete implementation of <see cref="Element"/> for basic content
/// containers such as paragraphs or generic block containers.
/// </summary>
public class BasicElement : Element {
    /// <summary>
    /// Gets or sets the text content of this element.
    /// </summary>
    public string TextContent { get; set; } = "";

    /// <summary>
    /// Gets or sets the HTML content of this element.
    /// </summary>
    public string HtmlContent { get; set; } = "";

    /// <summary>
    /// Initializes a new instance of the <see cref="BasicElement"/> class.
    /// </summary>
    public BasicElement() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="BasicElement"/> class with text content.
    /// </summary>
    /// <param name="text">The text content.</param>
    public BasicElement(string text) {
        TextContent = text;
    }

    /// <summary>
    /// Sets the text content of this element.
    /// </summary>
    /// <param name="text">The text content.</param>
    /// <returns>The BasicElement object, allowing for method chaining.</returns>
    public BasicElement SetText(string text) {
        TextContent = text;
        HtmlContent = "";
        return this;
    }

    /// <summary>
    /// Sets the HTML content of this element.
    /// </summary>
    /// <param name="html">The HTML content.</param>
    /// <returns>The BasicElement object, allowing for method chaining.</returns>
    public BasicElement SetHtml(string html) {
        HtmlContent = html;
        TextContent = "";
        return this;
    }

    /// <summary>
    /// Converts the BasicElement to its string representation.
    /// </summary>
    /// <returns>HTML string representing the element.</returns>
    public override string ToString() {
        if (string.IsNullOrEmpty(HtmlContent) && string.IsNullOrEmpty(TextContent) && Children.Count == 0) {
            return string.Empty;
        }

        var html = StringBuilderCache.Acquire();

        // Render HTML content if available, otherwise text content
        if (!string.IsNullOrEmpty(HtmlContent)) {
            html.AppendLine(HtmlContent);
        } else if (!string.IsNullOrEmpty(TextContent)) {
            html.AppendLine(Helpers.HtmlEncode(TextContent));
        }

        // Render child elements
        foreach (var child in Children.WhereNotNull()) {
            var childContent = child.ToString();
            if (!string.IsNullOrEmpty(childContent)) {
                html.AppendLine(childContent);
            }
        }

        return StringBuilderCache.GetStringAndRelease(html);
    }
}