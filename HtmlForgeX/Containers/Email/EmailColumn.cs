using System.Text;

namespace HtmlForgeX;

/// <summary>
/// Represents a table-based column layout for email compatibility.
/// Uses HTML table cells instead of CSS flexbox/grid for maximum email client support.
/// </summary>
public class EmailColumn : Element {
    /// <summary>
    /// Gets or sets additional CSS classes for the column.
    /// </summary>
    public string CssClass { get; set; } = "col";

    /// <summary>
    /// Gets or sets the width of the column.
    /// </summary>
    public string Width { get; set; } = "";

    /// <summary>
    /// Gets or sets the vertical alignment of the column content.
    /// </summary>
    public string VerticalAlign { get; set; } = "top";

    /// <summary>
    /// Gets or sets the text alignment of the column content.
    /// </summary>
    public string TextAlign { get; set; } = "left";

    /// <summary>
    /// Gets or sets additional inline styles for the column.
    /// </summary>
    public string InlineStyle { get; set; } = "";

    /// <summary>
    /// Gets or sets the text wrapping mode for controlling how text breaks and wraps in this column.
    /// </summary>
    public EmailTextWrapMode WrapMode { get; set; } = EmailTextWrapMode.Default;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailColumn"/> class.
    /// </summary>
    public EmailColumn() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailColumn"/> class with a custom CSS class.
    /// </summary>
    /// <param name="cssClass">The CSS class to apply.</param>
    public EmailColumn(string cssClass) {
        CssClass = cssClass;
    }

    /// <summary>
    /// Sets the width of the column.
    /// </summary>
    /// <param name="width">The width (e.g., "50%", "200px", "auto").</param>
    /// <returns>The EmailColumn object, allowing for method chaining.</returns>
    public EmailColumn SetWidth(string width) {
        Width = width;
        return this;
    }

    /// <summary>
    /// Sets the vertical alignment of the column content.
    /// </summary>
    /// <param name="alignment">The vertical alignment (top, middle, bottom).</param>
    /// <returns>The EmailColumn object, allowing for method chaining.</returns>
    public EmailColumn SetVerticalAlign(string alignment) {
        VerticalAlign = alignment;
        return this;
    }

    /// <summary>
    /// Adds inline CSS style to the column.
    /// </summary>
    /// <param name="style">The CSS style to add.</param>
    /// <returns>The EmailColumn object, allowing for method chaining.</returns>
    public EmailColumn AddStyle(string style) {
        if (!string.IsNullOrEmpty(InlineStyle)) {
            InlineStyle += " ";
        }
        InlineStyle += style;
        return this;
    }

    /// <summary>
    /// Adds padding to the column.
    /// </summary>
    /// <param name="padding">The padding value (e.g., "10px", "5px 10px").</param>
    /// <returns>The EmailColumn object, allowing for method chaining.</returns>
    public EmailColumn SetPadding(string padding) {
        AddStyle($"padding: {padding};");
        return this;
    }

    /// <summary>
    /// Sets the text alignment of the column content.
    /// </summary>
    /// <param name="alignment">The text alignment (left, center, right).</param>
    /// <returns>The EmailColumn object, allowing for method chaining.</returns>
    /// <summary>
    /// Sets the text alignment of the column content.
    /// </summary>
    /// <param name="alignment">The alignment option.</param>
    /// <returns>The <see cref="EmailColumn"/> instance.</returns>
    public EmailColumn SetAlignment(Alignment alignment) {
        alignment.ValidateEmailAlignment();
        TextAlign = alignment.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets the text wrapping mode for controlling how text breaks and wraps in this column.
    /// </summary>
    /// <param name="wrapMode">The text wrapping mode.</param>
    /// <returns>The EmailColumn object, allowing for method chaining.</returns>
    public EmailColumn SetWrapMode(EmailTextWrapMode wrapMode) {
        WrapMode = wrapMode;
        return this;
    }

    /// <summary>
    /// Sets natural text wrapping for this column - only breaks at word boundaries.
    /// Perfect for columns containing method names like "ConfigureImageOptimization".
    /// </summary>
    /// <returns>The EmailColumn object, allowing for method chaining.</returns>
    public EmailColumn WithNaturalWrapping() {
        WrapMode = EmailTextWrapMode.Natural;
        return this;
    }

    /// <summary>
    /// Sets smart text wrapping for this column - tries to keep camelCase and method names intact.
    /// Best for technical documentation and API reference columns.
    /// </summary>
    /// <returns>The EmailColumn object, allowing for method chaining.</returns>
    public EmailColumn WithSmartWrapping() {
        WrapMode = EmailTextWrapMode.Smart;
        return this;
    }

            /// <summary>
    /// Adds an element to the column.
    /// </summary>
    /// <param name="element">The element to add.</param>
    /// <returns>The EmailColumn object, allowing for method chaining.</returns>
    public override Element Add(Element element) {
        // Set a parent reference so child elements know they're in a column
        element.ParentColumn = this;

        // Propagate Email reference to child elements for configuration access
        if (element != null && this.Email != null) {
            element.Email = this.Email;
        }

        // Call the base implementation to handle the rest
        base.Add(element);

        return this;
    }

    /// <summary>
    /// Adds an EmailImage to the column.
    /// </summary>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage EmailImage() {
        var image = new EmailImage();
        Add(image);
        return image;
    }

    /// <summary>
    /// Adds an EmailImage to the column with a source.
    /// </summary>
    /// <param name="source">The image source URL or file path.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public new EmailImage EmailImage(string source) {
        var image = new EmailImage(source);
        Add(image);
        return image;
    }

    /// <summary>
    /// Adds an EmailImage to the column with source and dimensions.
    /// </summary>
    /// <param name="source">The image source URL or file path.</param>
    /// <param name="width">The image width.</param>
    /// <param name="height">The image height.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage EmailImage(string source, string width, string height = "") {
        var image = new EmailImage(source, width, height);
        Add(image);
        return image;
    }

    /// <summary>
    /// Adds content to the column using a configuration action.
    /// </summary>
    /// <param name="config">The configuration action for the content.</param>
    /// <returns>The EmailColumn object, allowing for method chaining.</returns>
    public EmailColumn Add(Action<BasicElement> config) {
        var element = new BasicElement();
        config(element);
        this.Add(element);
        return this;
    }

    /// <summary>
    /// Adds text content to the column.
    /// </summary>
    /// <param name="text">The text to add.</param>
    /// <returns>The EmailColumn object, allowing for method chaining.</returns>
    public EmailColumn AddText(string text) {
        var textElement = new BasicElement(text);
        this.Add(textElement);
        return this;
    }

    /// <summary>
    /// Gets the content string for the column (used internally by EmailRow).
    /// </summary>
    /// <returns>HTML string representing the column content.</returns>
    internal string GetContentString() {
        if (Children.Count == 0) {
            return string.Empty;
        }

        var content = StringBuilderCache.Acquire();

        foreach (var child in Children) {
            var childContent = child.ToString();
            if (!string.IsNullOrEmpty(childContent)) {
                content.AppendLine(childContent);
            }
        }

        return StringBuilderCache.GetStringAndRelease(content);
    }

    /// <summary>
    /// Converts the EmailColumn to its HTML representation.
    /// Note: This should typically not be called directly - columns are rendered by EmailRow.
    /// </summary>
    /// <returns>HTML string representing the email column.</returns>
    public override string ToString() {
        // Build cell style with configurable wrapping behavior
        var wrapCss = WrapMode.ToCssProperties();
        var cellStyles = new List<string> {
            "font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif",
            wrapCss
        };

        if (!string.IsNullOrEmpty(Width)) {
            cellStyles.Add($"width: {Width}");
            cellStyles.Add($"max-width: {Width}");
        }

        if (!string.IsNullOrEmpty(TextAlign) && TextAlign != "left") {
            cellStyles.Add($"text-align: {TextAlign}");
        }

        if (!string.IsNullOrEmpty(InlineStyle)) {
            cellStyles.Add(InlineStyle);
        }

        var cellStyle = string.Join("; ", cellStyles);
        var alignAttr = !string.IsNullOrEmpty(TextAlign) && TextAlign != "left" ? $@" align=""{TextAlign}""" : "";

        var html = StringBuilderCache.Acquire();
        html.AppendLine($@"<td class=""{CssClass}"" style=""{cellStyle}"" valign=""{VerticalAlign}""{alignAttr}>");

        // Render child content
        var contentString = GetContentString();
        if (!string.IsNullOrEmpty(contentString)) {
            html.AppendLine(contentString);
        }

        html.AppendLine("</td>");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}