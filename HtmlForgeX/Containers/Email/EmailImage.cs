namespace HtmlForgeX;

/// <summary>
/// Represents an image element for email layouts with email-safe styling and attributes.
/// Provides image display with customizable dimensions, alignment, and accessibility features.
/// </summary>
public class EmailImage : Element {
    /// <summary>
    /// Gets or sets the image source URL.
    /// </summary>
    public string Source { get; set; } = "";

    /// <summary>
    /// Gets or sets the image width.
    /// </summary>
    public string Width { get; set; } = "";

    /// <summary>
    /// Gets or sets the image height.
    /// </summary>
    public string Height { get; set; } = "";

    /// <summary>
    /// Gets or sets the alternative text for accessibility.
    /// </summary>
    public string AlternativeText { get; set; } = "";

    /// <summary>
    /// Gets or sets the image alignment.
    /// </summary>
    public string Alignment { get; set; } = "left";

    /// <summary>
    /// Gets or sets the margin around the image.
    /// </summary>
    public string Margin { get; set; } = "0 0 16px 0";

    /// <summary>
    /// Gets or sets the padding around the image.
    /// </summary>
    public string Padding { get; set; } = "0";

    /// <summary>
    /// Gets or sets the border for the image.
    /// </summary>
    public string Border { get; set; } = "none";

    /// <summary>
    /// Gets or sets the border radius for the image.
    /// </summary>
    public string BorderRadius { get; set; } = "0";

    /// <summary>
    /// Gets or sets whether the image should be a link.
    /// </summary>
    public string LinkUrl { get; set; } = "";

    /// <summary>
    /// Gets or sets whether the image should open in a new window.
    /// </summary>
    public bool OpenInNewWindow { get; set; } = false;

    /// <summary>
    /// Gets or sets the CSS class for the image container.
    /// </summary>
    public string CssClass { get; set; } = "logo";

    /// <summary>
    /// Gets or sets whether the image should be embedded as base64.
    /// </summary>
    public bool EmbedAsBase64 { get; set; } = false;

    /// <summary>
    /// Gets or sets the base64 encoded image data.
    /// </summary>
    public string Base64Data { get; set; } = "";

    /// <summary>
    /// Gets or sets the image MIME type for embedded images.
    /// </summary>
    public string MimeType { get; set; } = "";

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailImage"/> class.
    /// </summary>
    public EmailImage() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailImage"/> class with source.
    /// </summary>
    /// <param name="source">The image source URL.</param>
    public EmailImage(string source) {
        Source = source;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailImage"/> class with source and dimensions.
    /// </summary>
    /// <param name="source">The image source URL.</param>
    /// <param name="width">The image width.</param>
    /// <param name="height">The image height.</param>
    public EmailImage(string source, string width, string height = "") {
        Source = source;
        Width = width;
        Height = height;
    }

    /// <summary>
    /// Sets the image source URL.
    /// </summary>
    /// <param name="source">The image source URL.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithSource(string source) {
        Source = source;
        return this;
    }

    /// <summary>
    /// Sets the image width.
    /// </summary>
    /// <param name="width">The image width.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithWidth(string width) {
        Width = width;
        return this;
    }

    /// <summary>
    /// Sets the image height.
    /// </summary>
    /// <param name="height">The image height.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithHeight(string height) {
        Height = height;
        return this;
    }

    /// <summary>
    /// Sets the alternative text for accessibility.
    /// </summary>
    /// <param name="altText">The alternative text.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithAlternativeText(string altText) {
        AlternativeText = altText;
        return this;
    }

    /// <summary>
    /// Sets the image alignment.
    /// </summary>
    /// <param name="alignment">The image alignment.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithAlignment(string alignment) {
        Alignment = alignment;
        return this;
    }

    /// <summary>
    /// Sets the margin around the image.
    /// </summary>
    /// <param name="margin">The margin value.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithMargin(string margin) {
        Margin = margin;
        return this;
    }

    /// <summary>
    /// Sets the border for the image.
    /// </summary>
    /// <param name="border">The border value.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithBorder(string border) {
        Border = border;
        return this;
    }

    /// <summary>
    /// Sets the border radius for the image.
    /// </summary>
    /// <param name="borderRadius">The border radius value.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithBorderRadius(string borderRadius) {
        BorderRadius = borderRadius;
        return this;
    }

    /// <summary>
    /// Makes the image a clickable link.
    /// </summary>
    /// <param name="url">The link URL.</param>
    /// <param name="openInNewWindow">Whether to open in new window.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithLink(string url, bool openInNewWindow = false) {
        LinkUrl = url;
        OpenInNewWindow = openInNewWindow;
        return this;
    }

    /// <summary>
    /// Sets the CSS class for the image container.
    /// </summary>
    /// <param name="cssClass">The CSS class.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithCssClass(string cssClass) {
        CssClass = cssClass;
        return this;
    }

        /// <summary>
    /// Embeds the image as base64 data URI.
    /// </summary>
    /// <param name="filePath">The file path to embed.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage EmbedFromFile(string filePath) {
        try {
            if (System.IO.File.Exists(filePath)) {
                var bytes = System.IO.File.ReadAllBytes(filePath);
                var extension = System.IO.Path.GetExtension(filePath).ToLower();

                MimeType = extension switch {
                    ".jpg" or ".jpeg" => "image/jpeg",
                    ".png" => "image/png",
                    ".gif" => "image/gif",
                    ".svg" => "image/svg+xml",
                    ".webp" => "image/webp",
                    _ => "image/png"
                };

                Base64Data = Convert.ToBase64String(bytes);
                EmbedAsBase64 = true;
                Source = $"data:{MimeType};base64,{Base64Data}";
            }
        } catch (Exception ex) {
            // Fallback to file path if embedding fails
            Source = filePath;
            Console.WriteLine($"Warning: Failed to embed image {filePath}: {ex.Message}");
        }
        return this;
    }

    /// <summary>
    /// Sets the margin using predefined spacing values.
    /// </summary>
    /// <param name="spacing">The predefined spacing value for all sides.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithMargin(EmailSpacing spacing) {
        Margin = spacing.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets the margin using predefined spacing values for vertical and horizontal.
    /// </summary>
    /// <param name="vertical">The predefined vertical spacing (top and bottom).</param>
    /// <param name="horizontal">The predefined horizontal spacing (left and right).</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithMargin(EmailSpacing vertical, EmailSpacing horizontal) {
        Margin = $"{vertical.ToCssValue()} {horizontal.ToCssValue()}";
        return this;
    }

    /// <summary>
    /// Sets the margin using predefined spacing values for all sides.
    /// </summary>
    /// <param name="top">The predefined top spacing.</param>
    /// <param name="right">The predefined right spacing.</param>
    /// <param name="bottom">The predefined bottom spacing.</param>
    /// <param name="left">The predefined left spacing.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithMargin(EmailSpacing top, EmailSpacing right, EmailSpacing bottom, EmailSpacing left) {
        Margin = $"{top.ToCssValue()} {right.ToCssValue()} {bottom.ToCssValue()} {left.ToCssValue()}";
        return this;
    }

    /// <summary>
    /// Converts the EmailImage to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the email image.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        // Build image attributes
        var imgAttributes = new List<string>();
        imgAttributes.Add($"src=\"{Helpers.HtmlEncode(Source)}\"");

        if (!string.IsNullOrEmpty(Width)) {
            imgAttributes.Add($"width=\"{Width}\"");
        }

        if (!string.IsNullOrEmpty(Height)) {
            imgAttributes.Add($"height=\"{Height}\"");
        }

        if (!string.IsNullOrEmpty(AlternativeText)) {
            imgAttributes.Add($"alt=\"{Helpers.HtmlEncode(AlternativeText)}\"");
        }

        // Build image style
        var imgStyle = new List<string>();
        imgStyle.Add("display: inline-block");
        imgStyle.Add("line-height: 100%");
        imgStyle.Add("outline: none");
        imgStyle.Add("text-decoration: none");
        imgStyle.Add("vertical-align: bottom");
        imgStyle.Add("font-size: 0");
        imgStyle.Add("border-style: none");
        imgStyle.Add("border-width: 0");

        if (!string.IsNullOrEmpty(Border) && Border != "none") {
            imgStyle.Add($"border: {Border}");
        }

        if (!string.IsNullOrEmpty(BorderRadius) && BorderRadius != "0") {
            imgStyle.Add($"border-radius: {BorderRadius}");
        }

        var imgStyleAttr = $" style=\"{string.Join("; ", imgStyle)}\"";

        // Create simple image structure
        html.AppendLine($@"
<tr>
<td style=""margin: {Margin}; padding: {Padding}; text-align: {Alignment}; font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;"">
");

        // Only wrap in link if LinkUrl is provided
        if (!string.IsNullOrEmpty(LinkUrl)) {
            var target = OpenInNewWindow ? " target=\"_blank\"" : "";
            html.AppendLine($@"<a href=""{Helpers.HtmlEncode(LinkUrl)}""{target} style=""color: #066FD1; text-decoration: none;"">");
            html.AppendLine($@"<img {string.Join(" ", imgAttributes)}{imgStyleAttr} />");
            html.AppendLine($@"</a>");
        } else {
            html.AppendLine($@"<img {string.Join(" ", imgAttributes)}{imgStyleAttr} />");
        }

        html.AppendLine($@"
</td>
</tr>
");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}