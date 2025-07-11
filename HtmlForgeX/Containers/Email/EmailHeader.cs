namespace HtmlForgeX;

/// <summary>
/// Represents a flexible email header section that works like Body.
/// Users can directly call email.Header.EmailRow(), email.Header.EmailContent(), etc.
/// </summary>
public class EmailHeader : Element {
    /// <summary>
    /// Gets the child elements of the header.
    /// </summary>
    public List<Element> Children { get; private set; } = new List<Element>();

    /// <summary>
    /// Gets or sets the padding for the header section.
    /// </summary>
    public string Padding { get; set; } = "24px";

    /// <summary>
    /// Gets or sets the background color for the header section.
    /// </summary>
    public string BackgroundColor { get; set; } = "transparent";

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailHeader"/> class.
    /// </summary>
    public EmailHeader() {
        // Header is just a container - no complex setup needed
    }

    /// <summary>
    /// Adds an element to the header.
    /// </summary>
    /// <param name="element">The element to add.</param>
    /// <returns>The EmailHeader object, allowing for method chaining.</returns>
    public EmailHeader Add(Element element) {
        element.Email = this.Email;
        Children.Add(element);
        return this;
    }

    /// <summary>
    /// Adds an EmailRow to the header.
    /// </summary>
    /// <param name="configure">Action to configure the row.</param>
    /// <returns>The EmailHeader object, allowing for method chaining.</returns>
    public EmailHeader EmailRow(Action<EmailRow> configure) {
        var row = new EmailRow();
        configure(row);
        Add(row);
        return this;
    }

    /// <summary>
    /// Adds an EmailContent section to the header.
    /// </summary>
    /// <param name="configure">Action to configure the content.</param>
    /// <returns>The EmailHeader object, allowing for method chaining.</returns>
    public EmailHeader EmailContent(Action<EmailContent> configure) {
        var content = new EmailContent();
        configure(content);
        Add(content);
        return this;
    }

    /// <summary>
    /// Adds an EmailText to the header.
    /// </summary>
    /// <param name="text">The text content.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText EmailText(string text) {
        var textElement = new EmailText(text);
        Add(textElement);
        return textElement;
    }

    /// <summary>
    /// Adds an EmailImage to the header.
    /// </summary>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage EmailImage() {
        var image = new EmailImage();
        Add(image);
        return image;
    }

    /// <summary>
    /// Adds an EmailImage to the header with a source.
    /// </summary>
    /// <param name="source">The image source URL or file path.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage EmailImage(string source) {
        var image = new EmailImage(source);
        Add(image);
        return image;
    }

    /// <summary>
    /// Adds an EmailLink to the header.
    /// </summary>
    /// <param name="text">The link text.</param>
    /// <param name="url">The link URL.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink EmailLink(string text, string url) {
        var link = new EmailLink(text, url);
        Add(link);
        return link;
    }

    /// <summary>
    /// Sets the header padding.
    /// </summary>
    /// <param name="padding">The padding value.</param>
    /// <returns>The EmailHeader object, allowing for method chaining.</returns>
    public EmailHeader SetPadding(string padding) {
        Padding = padding;
        return this;
    }

    /// <summary>
    /// Sets the header background color.
    /// </summary>
    /// <param name="color">The background color.</param>
    /// <returns>The EmailHeader object, allowing for method chaining.</returns>
    public EmailHeader SetBackgroundColor(string color) {
        BackgroundColor = color;
        return this;
    }

    /// <summary>
    /// Converts the EmailHeader to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the email header.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        html.AppendLine($@"<!-- HEADER -->");
        html.AppendLine($@"<table role=""presentation"" cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"" style=""background-color: {BackgroundColor};"">");
        html.AppendLine($@"  <tr>");
        html.AppendLine($@"    <td style=""padding: {Padding};"">");

        foreach (var child in Children) {
            html.AppendLine(child.ToString());
        }

        html.AppendLine($@"    </td>");
        html.AppendLine($@"  </tr>");
        html.AppendLine($@"</table>");
        html.AppendLine($@"<!-- /HEADER -->");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}