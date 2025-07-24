using System.Net;
using System.Text;

namespace HtmlForgeX;

/// <summary>
/// Represents a VisNetwork node with full HTML support using the visjs-html-nodes plugin.
/// This allows for rich HTML content in nodes including divs, spans, lists, tables, images, and more.
/// 
/// Note: This requires the visjs-html-nodes plugin to be loaded. When using this node type,
/// the VisNetworkHtmlNodes library will be automatically registered.
/// </summary>
public class VisNetworkHtmlNode {
    private StringBuilder? _htmlContent;
    private bool _isHtmlNode = true;

    /// <summary>
    /// Gets the unique identifier of the node.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="VisNetworkHtmlNode"/> class.
    /// </summary>
    /// <param name="id">The unique identifier for the node</param>
    public VisNetworkHtmlNode(string id) {
        Id = id;
        _htmlContent = new StringBuilder();
    }

    /// <summary>
    /// Sets the raw HTML content for the node.
    /// This allows complete control over the node's HTML structure.
    /// </summary>
    /// <param name="html">The HTML content</param>
    /// <returns>The current instance for method chaining</returns>
    public VisNetworkHtmlNode WithHtmlContent(string html) {
        _htmlContent = new StringBuilder(html);
        return this;
    }

    /// <summary>
    /// Creates a card-style node with header and body sections.
    /// </summary>
    /// <param name="header">The header content</param>
    /// <param name="body">The body content</param>
    /// <param name="headerColor">Optional header background color</param>
    /// <returns>The current instance for method chaining</returns>
    public VisNetworkHtmlNode WithCard(string header, string body, string? headerColor = null) {
        var headerStyle = headerColor != null ? $" style='background-color: {headerColor}; color: white; padding: 8px;'" : " style='padding: 8px; background-color: #f5f5f5;'";

        _htmlContent = new StringBuilder();
        _htmlContent.Append($"<div style='border: 1px solid #ddd; border-radius: 4px; overflow: hidden;'>");
        _htmlContent.Append($"<div{headerStyle}><strong>{WebUtility.HtmlEncode(header)}</strong></div>");
        _htmlContent.Append($"<div style='padding: 8px;'>{WebUtility.HtmlEncode(body)}</div>");
        _htmlContent.Append("</div>");

        return this;
    }

    /// <summary>
    /// Creates a list-style node with items.
    /// </summary>
    /// <param name="title">The title of the list</param>
    /// <param name="items">The list items</param>
    /// <param name="ordered">Whether to use ordered list (numbers) or unordered (bullets)</param>
    /// <returns>The current instance for method chaining</returns>
    public VisNetworkHtmlNode WithList(string title, string[] items, bool ordered = false) {
        _htmlContent = new StringBuilder();
        _htmlContent.Append($"<div style='padding: 8px;'>");
        _htmlContent.Append($"<strong>{WebUtility.HtmlEncode(title)}</strong>");
        _htmlContent.Append(ordered ? "<ol>" : "<ul>");

        foreach (var item in items) {
            _htmlContent.Append($"<li>{WebUtility.HtmlEncode(item)}</li>");
        }

        _htmlContent.Append(ordered ? "</ol>" : "</ul>");
        _htmlContent.Append("</div>");

        return this;
    }

    /// <summary>
    /// Creates a table-style node.
    /// </summary>
    /// <param name="headers">The table headers</param>
    /// <param name="rows">The table rows (2D array)</param>
    /// <returns>The current instance for method chaining</returns>
    public VisNetworkHtmlNode WithTable(string[] headers, string[][] rows) {
        _htmlContent = new StringBuilder();
        _htmlContent.Append("<table style='border-collapse: collapse; width: 100%;'>");

        // Headers
        _htmlContent.Append("<thead><tr>");
        foreach (var header in headers) {
            _htmlContent.Append($"<th style='border: 1px solid #ddd; padding: 4px; background-color: #f2f2f2;'>{WebUtility.HtmlEncode(header)}</th>");
        }
        _htmlContent.Append("</tr></thead>");

        // Rows
        _htmlContent.Append("<tbody>");
        foreach (var row in rows) {
            _htmlContent.Append("<tr>");
            foreach (var cell in row) {
                _htmlContent.Append($"<td style='border: 1px solid #ddd; padding: 4px;'>{WebUtility.HtmlEncode(cell)}</td>");
            }
            _htmlContent.Append("</tr>");
        }
        _htmlContent.Append("</tbody></table>");

        return this;
    }

    /// <summary>
    /// Creates a progress bar node.
    /// </summary>
    /// <param name="label">The label for the progress</param>
    /// <param name="percentage">The percentage complete (0-100)</param>
    /// <param name="color">The color of the progress bar</param>
    /// <returns>The current instance for method chaining</returns>
    public VisNetworkHtmlNode WithProgressBar(string label, int percentage, string color = "#4CAF50") {
        percentage = Math.Max(0, Math.Min(100, percentage)); // Clamp to 0-100

        _htmlContent = new StringBuilder();
        _htmlContent.Append($"<div style='padding: 8px;'>");
        _htmlContent.Append($"<div>{WebUtility.HtmlEncode(label)}</div>");
        _htmlContent.Append($"<div style='width: 150px; background-color: #f0f0f0; border-radius: 4px; overflow: hidden;'>");
        _htmlContent.Append($"<div style='width: {percentage}%; background-color: {color}; height: 20px; text-align: center; color: white;'>{percentage}%</div>");
        _htmlContent.Append("</div></div>");

        return this;
    }

    /// <summary>
    /// Creates a badge/tag style node.
    /// </summary>
    /// <param name="text">The badge text</param>
    /// <param name="backgroundColor">The background color</param>
    /// <param name="textColor">The text color</param>
    /// <returns>The current instance for method chaining</returns>
    public VisNetworkHtmlNode WithBadge(string text, string backgroundColor = "#007bff", string textColor = "white") {
        _htmlContent = new StringBuilder();
        _htmlContent.Append($"<span style='background-color: {backgroundColor}; color: {textColor}; padding: 4px 8px; border-radius: 12px; font-size: 14px;'>");
        _htmlContent.Append(WebUtility.HtmlEncode(text));
        _htmlContent.Append("</span>");

        return this;
    }

    /// <summary>
    /// Creates a status indicator node with icon and text.
    /// </summary>
    /// <param name="status">The status text</param>
    /// <param name="iconColor">The color of the status indicator</param>
    /// <param name="description">Optional description text</param>
    /// <returns>The current instance for method chaining</returns>
    public VisNetworkHtmlNode WithStatus(string status, string iconColor, string? description = null) {
        _htmlContent = new StringBuilder();
        _htmlContent.Append($"<div style='padding: 8px; text-align: center;'>");
        _htmlContent.Append($"<div style='display: inline-block; width: 12px; height: 12px; border-radius: 50%; background-color: {iconColor}; margin-right: 8px;'></div>");
        _htmlContent.Append($"<strong>{WebUtility.HtmlEncode(status)}</strong>");

        if (description != null) {
            _htmlContent.Append($"<div style='font-size: 12px; color: #666; margin-top: 4px;'>{WebUtility.HtmlEncode(description)}</div>");
        }

        _htmlContent.Append("</div>");

        return this;
    }

    /// <summary>
    /// Creates an image node with optional caption.
    /// </summary>
    /// <param name="imageUrl">The URL of the image</param>
    /// <param name="caption">Optional caption text</param>
    /// <param name="width">Optional width in pixels</param>
    /// <param name="height">Optional height in pixels</param>
    /// <returns>The current instance for method chaining</returns>
    public VisNetworkHtmlNode WithImage(string imageUrl, string? caption = null, int? width = null, int? height = null) {
        _htmlContent = new StringBuilder();
        _htmlContent.Append("<div style='text-align: center;'>");

        var imgStyle = "max-width: 100%;";
        if (width.HasValue) imgStyle += $" width: {width}px;";
        if (height.HasValue) imgStyle += $" height: {height}px;";

        _htmlContent.Append($"<img src='{WebUtility.HtmlEncode(imageUrl)}' style='{imgStyle}' />");

        if (caption != null) {
            _htmlContent.Append($"<div style='font-size: 12px; color: #666; margin-top: 4px;'>{WebUtility.HtmlEncode(caption)}</div>");
        }

        _htmlContent.Append("</div>");

        return this;
    }

    /// <summary>
    /// Builds a custom HTML content using a fluent builder.
    /// </summary>
    /// <param name="builderAction">The action to configure the HTML builder</param>
    /// <returns>The current instance for method chaining</returns>
    public VisNetworkHtmlNode WithHtmlBuilder(Action<VisNetworkHtmlBuilder> builderAction) {
        var builder = new VisNetworkHtmlBuilder();
        builderAction(builder);
        _htmlContent = new StringBuilder(builder.Build());
        return this;
    }

    /// <summary>
    /// Gets the HTML content for this node.
    /// </summary>
    internal string GetHtmlContent() {
        return _htmlContent?.ToString() ?? string.Empty;
    }

    /// <summary>
    /// Indicates whether this is an HTML node (always true for this class).
    /// </summary>
    internal bool IsHtmlNode => _isHtmlNode;
}

/// <summary>
/// Provides a fluent API for building complex HTML content for VisNetwork HTML nodes.
/// This builder supports all HTML tags and styling when used with the visjs-html-nodes plugin.
/// </summary>
public class VisNetworkHtmlBuilder {
    private readonly StringBuilder _html;

    /// <summary>
    /// Initializes a new instance of the VisNetworkHtmlBuilder class.
    /// </summary>
    public VisNetworkHtmlBuilder() {
        _html = new StringBuilder();
    }

    /// <summary>
    /// Adds a div element with optional styling.
    /// </summary>
    /// <param name="content">The content of the div</param>
    /// <param name="style">Optional inline CSS style</param>
    /// <param name="className">Optional CSS class name</param>
    /// <returns>The builder for method chaining</returns>
    public VisNetworkHtmlBuilder Div(string content, string? style = null, string? className = null) {
        _html.Append("<div");
        if (!string.IsNullOrEmpty(style)) _html.Append($" style='{style}'");
        if (!string.IsNullOrEmpty(className)) _html.Append($" class='{className}'");
        _html.Append($">{content}</div>");
        return this;
    }

    /// <summary>
    /// Adds a span element with optional styling.
    /// </summary>
    /// <param name="content">The content of the span</param>
    /// <param name="style">Optional inline CSS style</param>
    /// <param name="className">Optional CSS class name</param>
    /// <returns>The builder for method chaining</returns>
    public VisNetworkHtmlBuilder Span(string content, string? style = null, string? className = null) {
        _html.Append("<span");
        if (!string.IsNullOrEmpty(style)) _html.Append($" style='{style}'");
        if (!string.IsNullOrEmpty(className)) _html.Append($" class='{className}'");
        _html.Append($">{WebUtility.HtmlEncode(content)}</span>");
        return this;
    }

    /// <summary>
    /// Adds a paragraph element.
    /// </summary>
    /// <param name="content">The content of the paragraph</param>
    /// <param name="style">Optional inline CSS style</param>
    /// <returns>The builder for method chaining</returns>
    public VisNetworkHtmlBuilder Paragraph(string content, string? style = null) {
        _html.Append("<p");
        if (!string.IsNullOrEmpty(style)) _html.Append($" style='{style}'");
        _html.Append($">{WebUtility.HtmlEncode(content)}</p>");
        return this;
    }

    /// <summary>
    /// Adds a heading element.
    /// </summary>
    /// <param name="level">The heading level (1-6)</param>
    /// <param name="content">The content of the heading</param>
    /// <param name="style">Optional inline CSS style</param>
    /// <returns>The builder for method chaining</returns>
    public VisNetworkHtmlBuilder Heading(int level, string content, string? style = null) {
        level = Math.Max(1, Math.Min(6, level)); // Clamp to 1-6
        _html.Append($"<h{level}");
        if (!string.IsNullOrEmpty(style)) _html.Append($" style='{style}'");
        _html.Append($">{WebUtility.HtmlEncode(content)}</h{level}>");
        return this;
    }

    /// <summary>
    /// Adds raw HTML content (use with caution).
    /// </summary>
    /// <param name="html">The raw HTML to add</param>
    /// <returns>The builder for method chaining</returns>
    public VisNetworkHtmlBuilder RawHtml(string html) {
        _html.Append(html);
        return this;
    }

    /// <summary>
    /// Adds a line break.
    /// </summary>
    /// <returns>The builder for method chaining</returns>
    public VisNetworkHtmlBuilder LineBreak() {
        _html.Append("<br>");
        return this;
    }

    /// <summary>
    /// Adds an unordered list.
    /// </summary>
    /// <param name="items">The list items</param>
    /// <param name="style">Optional inline CSS style for the list</param>
    /// <returns>The builder for method chaining</returns>
    public VisNetworkHtmlBuilder UnorderedList(string[] items, string? style = null) {
        _html.Append("<ul");
        if (!string.IsNullOrEmpty(style)) _html.Append($" style='{style}'");
        _html.Append(">");

        foreach (var item in items) {
            _html.Append($"<li>{WebUtility.HtmlEncode(item)}</li>");
        }

        _html.Append("</ul>");
        return this;
    }

    /// <summary>
    /// Adds an image.
    /// </summary>
    /// <param name="src">The image source URL</param>
    /// <param name="alt">The alt text</param>
    /// <param name="style">Optional inline CSS style</param>
    /// <returns>The builder for method chaining</returns>
    public VisNetworkHtmlBuilder Image(string src, string? alt = null, string? style = null) {
        _html.Append($"<img src='{WebUtility.HtmlEncode(src)}'");
        if (!string.IsNullOrEmpty(alt)) _html.Append($" alt='{WebUtility.HtmlEncode(alt)}'");
        if (!string.IsNullOrEmpty(style)) _html.Append($" style='{style}'");
        _html.Append(" />");
        return this;
    }

    /// <summary>
    /// Builds the final HTML string.
    /// </summary>
    /// <returns>The HTML content</returns>
    public string Build() {
        return _html.ToString();
    }
}