using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Represents a flexible email header section that works like Body.
/// Users can directly call email.Header.EmailRow(), email.Header.EmailContent(), etc.
/// </summary>
public class EmailHeader : Element {
    // Remove the shadowing Children property - use the base Element.Children instead

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
    public new EmailHeader Add(Element element) {
        // Propagate the Email reference to child elements for configuration access
        if (element != null && this.Email != null) {
            PropagateEmailReference(element, this.Email);
        }

        base.Add(element);
        return this;
    }

    /// <summary>
    /// Recursively propagates the Email reference to an element and all its children.
    /// </summary>
    /// <param name="element">The element to propagate to.</param>
    /// <param name="email">The Email instance to propagate.</param>
    private static void PropagateEmailReference(Element element, Email email) {
        if (element == null || email == null) return;

        element.Email = email;

        // Recursively propagate to all children
        foreach (var child in element.Children.WhereNotNull()) {
            PropagateEmailReference(child, email);
        }
    }

    /// <summary>
    /// Adds an EmailRow to the header.
    /// </summary>
    /// <param name="configure">Action to configure the row.</param>
    /// <returns>The EmailHeader object, allowing for method chaining.</returns>
    public new EmailHeader EmailRow(Action<EmailRow> configure) {
        var row = new EmailRow();
        // Set Email reference BEFORE configuration so child elements can access it
        row.Email = this.Email;
        configure(row);
        Add(row);
        return this;
    }

    /// <summary>
    /// Adds an EmailContent section to the header.
    /// </summary>
    /// <param name="configure">Action to configure the content.</param>
    /// <returns>The EmailHeader object, allowing for method chaining.</returns>
    public new EmailHeader EmailContent(Action<EmailContent> configure) {
        var content = new EmailContent();
        // Set Email reference BEFORE configuration so child elements can access it
        content.Email = this.Email;
        configure(content);
        Add(content);
        return this;
    }

    /// <summary>
    /// Adds an EmailText to the header.
    /// </summary>
    /// <param name="text">The text content.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public new EmailText EmailText(string text) {
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
    public new EmailImage EmailImage(string source) {
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
    public new EmailLink EmailLink(string text, string url) {
        var link = new EmailLink(text, url);
        Add(link);
        return link;
    }

    /// <summary>
    /// Sets the header padding.
    /// </summary>
    /// <param name="padding">The padding value.</param>
    /// <returns>The EmailHeader object, allowing for method chaining.</returns>
    public EmailHeader WithPadding(string padding) {
        Padding = padding;
        return this;
    }

    /// <summary>
    /// Sets the header background color.
    /// </summary>
    /// <param name="color">The background color.</param>
    /// <returns>The EmailHeader object, allowing for method chaining.</returns>
    public EmailHeader WithBackground(string color) {
        BackgroundColor = color;
        return this;
    }

    /// <summary>
    /// Sets the header background color.
    /// </summary>
    /// <param name="color">The background color.</param>
    /// <returns>The EmailHeader object, allowing for method chaining.</returns>
    public EmailHeader WithBackground(RGBColor color) {
        BackgroundColor = color.ToString();
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

        foreach (var child in base.Children.WhereNotNull()) {
            html.AppendLine(child.ToString().TrimEnd('\r', '\n'));
        }

        html.AppendLine($@"    </td>");
        html.AppendLine($@"  </tr>");
        html.AppendLine($@"</table>");
        html.AppendLine($@"<!-- /HEADER -->");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}