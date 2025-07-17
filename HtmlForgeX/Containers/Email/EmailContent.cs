using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

/// <summary>
/// EmailContent provides a single-column content wrapper that matches EmailColumn alignment.
/// Use this for consistent padding when you need single-column content that aligns with multi-column layouts.
/// </summary>
public class EmailContent : Element {
    private readonly List<Element> _elements = new();
    private string _padding = "0px";
    private string _alignment = "left";

    /// <summary>
    /// Sets the internal padding for the content area.
    /// </summary>
    /// <param name="padding">The padding value (e.g., "8px", "16px")</param>
    /// <returns>The EmailContent object, allowing for method chaining.</returns>
    public EmailContent WithPadding(string padding) {
        _padding = padding;
        return this;
    }

    /// <summary>
    /// Sets the text alignment for the content.
    /// </summary>
    /// <param name="alignment">The alignment value ("left", "center", "right")</param>
    /// <returns>The EmailContent object, allowing for method chaining.</returns>
    /// <summary>
    /// Sets the text alignment for the content.
    /// </summary>
    /// <param name="alignment">The alignment option.</param>
    /// <returns>The <see cref="EmailContent"/> instance.</returns>
    public EmailContent WithAlignment(Alignment alignment) {
        alignment.ValidateEmailAlignment();
        _alignment = alignment.ToCssValue();
        return this;
    }

    /// <summary>
    /// Adds an EmailText element to this content area.
    /// </summary>
    /// <param name="text">The text content</param>
    /// <returns>EmailText object for method chaining</returns>
    public EmailText EmailText(string text) {
        var emailText = new EmailText(text);
        _elements.Add(emailText);
        return emailText;
    }

    /// <summary>
    /// Adds an EmailText element with a configuration action.
    /// </summary>
    /// <param name="text">The text content</param>
    /// <param name="configure">Action to configure the EmailText</param>
    /// <returns>The EmailContent object, allowing for method chaining.</returns>
    public EmailContent EmailText(string text, Action<EmailText> configure) {
        var emailText = new EmailText(text);
        configure(emailText);
        _elements.Add(emailText);
        return this;
    }

    /// <summary>
    /// Adds an EmailButton to this content area.
    /// </summary>
    /// <param name="text">The button text</param>
    /// <param name="href">The button URL</param>
    /// <returns>EmailButton object for method chaining</returns>
    public EmailButton EmailButton(string text, string href) {
        var button = new EmailButton(text, href);
        _elements.Add(button);
        return button;
    }

    /// <summary>
    /// Adds an EmailTable to this content area.
    /// </summary>
    /// <param name="configure">Action to configure the EmailTable</param>
    /// <returns>The EmailContent object, allowing for method chaining.</returns>
    public EmailContent EmailTable(Action<EmailTable> configure) {
        var table = new EmailTable();
        configure(table);
        _elements.Add(table);
        return this;
    }

    /// <summary>
    /// Adds any Element to this content area.
    /// </summary>
    /// <param name="element">The element to add</param>
    /// <returns>The EmailContent object, allowing for method chaining.</returns>
    public new EmailContent Add(Element element) {
        base.Add(element);
        _elements.Add(element);
        return this;
    }

    /// <summary>
    /// Renders the EmailContent as HTML with consistent single-column structure.
    /// </summary>
    /// <returns>The HTML string</returns>
    public override string ToString() {
        var html = new StringBuilder();
        var contentPadding = string.IsNullOrEmpty(_padding) || _padding == "0px" ?
            EmailLayout.GetContentPadding() : _padding;

        // Create a single-column structure that matches EmailColumn alignment
        html.AppendLine($@"<table cellspacing=""0"" cellpadding=""0"" style=""font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: collapse; width: 100%;"">");
        html.AppendLine($@"<tr>");
        html.AppendLine($@"<td style=""font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; padding: {contentPadding}; text-align: {_alignment}; vertical-align: top;"">");

        // Render all child elements
        foreach (var element in _elements) {
            html.AppendLine(element.ToString().TrimEnd('\r', '\n'));
        }

        html.AppendLine("</td>");
        html.AppendLine("</tr>");
        html.AppendLine("</table>");

        return html.ToString();
    }
}