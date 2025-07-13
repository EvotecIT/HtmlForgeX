namespace HtmlForgeX;

/// <summary>
/// Represents a link element for email layouts with email-safe styling and attributes.
/// Provides clickable text links with customizable fonts, colors, and text formatting.
/// </summary>
public class EmailLink : Element {
    /// <summary>
    /// Gets or sets the link text content.
    /// </summary>
    public string Content { get; set; } = "";

    /// <summary>
    /// Gets or sets the link URL.
    /// </summary>
    public string Href { get; set; } = "";

    /// <summary>
    /// Gets or sets the font family.
    /// </summary>
    public string FontFamily { get; set; } = "Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif";

    /// <summary>
    /// Gets or sets the font size.
    /// </summary>
    public string FontSize { get; set; } = "15px";

    /// <summary>
    /// Gets or sets the line height.
    /// </summary>
    public string LineHeight { get; set; } = "160%";

    /// <summary>
    /// Gets or sets the link color.
    /// </summary>
    public string Color { get; set; } = "#066FD1";

    /// <summary>
    /// Gets or sets the text alignment.
    /// </summary>
    public string TextAlign { get; set; } = "left";

    /// <summary>
    /// Gets or sets the font weight.
    /// </summary>
    public string FontWeight { get; set; } = "normal";

    /// <summary>
    /// Gets or sets the text decoration.
    /// </summary>
    public string TextDecoration { get; set; } = "none";

    /// <summary>
    /// Gets or sets the margin.
    /// </summary>
    public string Margin { get; set; } = "0";

    /// <summary>
    /// Gets or sets the padding.
    /// </summary>
    public string Padding { get; set; } = "0";

    /// <summary>
    /// Gets or sets whether the link should open in a new window.
    /// </summary>
    public bool OpenInNewWindow { get; set; } = false;

    /// <summary>
    /// Gets or sets the link title (tooltip text).
    /// </summary>
    public string Title { get; set; } = "";

    /// <summary>
    /// Gets or sets additional CSS classes for the link.
    /// </summary>
    public string CssClass { get; set; } = "";

    /// <summary>
    /// Gets or sets additional inline styles.
    /// </summary>
    public string InlineStyle { get; set; } = "";

    /// <summary>
    /// Gets or sets the hover color for the link.
    /// </summary>
    public string HoverColor { get; set; } = "#0056B3";

    /// <summary>
    /// Gets or sets whether to underline the link on hover.
    /// </summary>
    public bool UnderlineOnHover { get; set; } = true;

    /// <summary>
    /// Gets the appropriate link color based on theme mode.
    /// </summary>
    public string GetThemeColor() {
        // If a custom color was explicitly set (not default), use it
        if (Color != "#066FD1") {
            return Color;
        }

        // Use theme-appropriate default color
        if (Email?.Configuration?.Email?.ThemeMode == EmailThemeMode.Dark) {
            return "#60a5fa"; // Dark mode link color (light blue)
        }
        return Color; // Light mode link color
    }

    /// <summary>
    /// Gets the appropriate hover color based on theme mode.
    /// </summary>
    public string GetThemeHoverColor() {
        // If a custom hover color was explicitly set (not default), use it
        if (HoverColor != "#0056B3") {
            return HoverColor;
        }

        // Use theme-appropriate default hover color
        if (Email?.Configuration?.Email?.ThemeMode == EmailThemeMode.Dark) {
            return "#93c5fd"; // Dark mode hover color (lighter blue)
        }
        return HoverColor; // Light mode hover color
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailLink"/> class.
    /// </summary>
    public EmailLink() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailLink"/> class with content and URL.
    /// </summary>
    /// <param name="content">The link text content.</param>
    /// <param name="href">The link URL.</param>
    public EmailLink(string content, string href) {
        Content = content;
        Href = href;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailLink"/> class with content, URL, and new window setting.
    /// </summary>
    /// <param name="content">The link text content.</param>
    /// <param name="href">The link URL.</param>
    /// <param name="openInNewWindow">Whether to open in a new window.</param>
    public EmailLink(string content, string href, bool openInNewWindow) {
        Content = content;
        Href = href;
        OpenInNewWindow = openInNewWindow;
    }

    /// <summary>
    /// Sets the link text content.
    /// </summary>
    /// <param name="content">The link text content.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithContent(string content) {
        Content = content;
        return this;
    }

    /// <summary>
    /// Sets the link URL.
    /// </summary>
    /// <param name="href">The link URL.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithHref(string href) {
        Href = href;
        return this;
    }

    /// <summary>
    /// Sets the font family.
    /// </summary>
    /// <param name="fontFamily">The font family.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithFontFamily(string fontFamily) {
        FontFamily = fontFamily;
        return this;
    }

    /// <summary>
    /// Sets the font size.
    /// </summary>
    /// <param name="fontSize">The font size.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithFontSize(string fontSize) {
        FontSize = fontSize;
        return this;
    }

    /// <summary>
    /// Sets the font size using predefined values.
    /// </summary>
    /// <param name="fontSize">The predefined font size.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithFontSize(EmailFontSize fontSize) {
        FontSize = fontSize.ToCssValue();

        // Auto-set appropriate line height and margin if they haven't been manually changed
        if (LineHeight == "160%") { // Default line height
            LineHeight = fontSize.ToLineHeight();
        }
        if (Margin == "0") { // Default margin
            Margin = fontSize.ToDefaultMargin();
        }

        return this;
    }

    /// <summary>
    /// Sets the line height.
    /// </summary>
    /// <param name="lineHeight">The line height.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithLineHeight(string lineHeight) {
        LineHeight = lineHeight;
        return this;
    }

    /// <summary>
    /// Sets the link color.
    /// </summary>
    /// <param name="color">The link color.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithColor(string color) {
        Color = color;
        return this;
    }

    /// <summary>
    /// Sets the link color using RGBColor.
    /// </summary>
    /// <param name="color">The link color.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithColor(RGBColor color) {
        Color = color.ToString();
        return this;
    }

    /// <summary>
    /// Sets the hover color for the link.
    /// </summary>
    /// <param name="hoverColor">The hover color.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithHoverColor(string hoverColor) {
        HoverColor = hoverColor;
        return this;
    }

    /// <summary>
    /// Sets the text alignment.
    /// </summary>
    /// <param name="alignment">The text alignment.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    /// <summary>
    /// Sets the text alignment.
    /// </summary>
    /// <param name="alignment">The alignment option.</param>
    /// <returns>The <see cref="EmailLink"/> instance.</returns>
    public EmailLink WithAlignment(Alignment alignment) {
        alignment.ValidateEmailAlignment();
        TextAlign = alignment.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets the font weight.
    /// </summary>
    /// <param name="fontWeight">The font weight.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithFontWeight(string fontWeight) {
        FontWeight = fontWeight;
        return this;
    }

    /// <summary>
    /// Sets the font weight using predefined values.
    /// </summary>
    /// <param name="fontWeight">The predefined font weight.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithFontWeight(FontWeight fontWeight) {
        FontWeight = fontWeight.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets the text decoration.
    /// </summary>
    /// <param name="textDecoration">The text decoration.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithTextDecoration(string textDecoration) {
        TextDecoration = textDecoration;
        return this;
    }

    /// <summary>
    /// Sets the text decoration using predefined options.
    /// </summary>
    /// <param name="decoration">The decoration option.</param>
    /// <returns>The <see cref="EmailLink"/> instance.</returns>
    public EmailLink WithTextDecoration(TextDecoration decoration) {
        TextDecoration = decoration.EnumToString();
        return this;
    }

    /// <summary>
    /// Sets the margin.
    /// </summary>
    /// <param name="margin">The margin value.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithMargin(string margin) {
        margin.ValidateMargin();
        Margin = margin;
        return this;
    }

    /// <summary>
    /// Sets the margin using predefined spacing values.
    /// </summary>
    /// <param name="spacing">The predefined spacing value for all sides.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithMargin(EmailSpacing spacing) {
        Margin = spacing.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets the margin using predefined spacing values for vertical and horizontal.
    /// </summary>
    /// <param name="vertical">The predefined vertical spacing (top and bottom).</param>
    /// <param name="horizontal">The predefined horizontal spacing (left and right).</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithMargin(EmailSpacing vertical, EmailSpacing horizontal) {
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
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithMargin(EmailSpacing top, EmailSpacing right, EmailSpacing bottom, EmailSpacing left) {
        Margin = $"{top.ToCssValue()} {right.ToCssValue()} {bottom.ToCssValue()} {left.ToCssValue()}";
        return this;
    }

    /// <summary>
    /// Sets the padding.
    /// </summary>
    /// <param name="padding">The padding value.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithPadding(string padding) {
        Padding = padding;
        return this;
    }

    /// <summary>
    /// Sets the link title (tooltip text).
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithTitle(string title) {
        Title = title;
        return this;
    }

    /// <summary>
    /// Sets the CSS class for the link.
    /// </summary>
    /// <param name="cssClass">The CSS class.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithCssClass(string cssClass) {
        CssClass = cssClass;
        return this;
    }

    /// <summary>
    /// Sets whether the link should open in a new window.
    /// </summary>
    /// <param name="openInNewWindow">Whether to open in a new window.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithNewWindow(bool openInNewWindow = true) {
        OpenInNewWindow = openInNewWindow;
        return this;
    }

    /// <summary>
    /// Disables underline on hover.
    /// </summary>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithoutUnderlineOnHover() {
        UnderlineOnHover = false;
        return this;
    }

    /// <summary>
    /// Enables underline on hover.
    /// </summary>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithUnderlineOnHover() {
        UnderlineOnHover = true;
        return this;
    }

    /// <summary>
    /// Adds custom inline styles.
    /// </summary>
    /// <param name="style">The inline style to add.</param>
    /// <returns>The EmailLink object, allowing for method chaining.</returns>
    public EmailLink WithInlineStyle(string style) {
        if (!string.IsNullOrEmpty(InlineStyle)) {
            InlineStyle += " ";
        }
        InlineStyle += style;
        return this;
    }

    /// <summary>
    /// Converts the EmailLink to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the email link.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        // Build link attributes
        var linkAttributes = new List<string>();
        linkAttributes.Add($"href=\"{Helpers.HtmlEncode(Href)}\"");

        if (OpenInNewWindow) {
            linkAttributes.Add("target=\"_blank\"");
        }

        if (!string.IsNullOrEmpty(Title)) {
            linkAttributes.Add($"title=\"{Helpers.HtmlEncode(Title)}\"");
        }

        // Add theme-aware CSS classes
        var cssClasses = new List<string>();
        if (!string.IsNullOrEmpty(CssClass)) {
            cssClasses.Add(CssClass);
        }

        // Add theme class for CSS targeting
        var themeClass = Email?.Configuration?.Email?.ThemeMode switch {
            EmailThemeMode.Dark => "theme-dark",
            EmailThemeMode.Auto => "auto-dark-mode",
            _ => ""
        };

        if (!string.IsNullOrEmpty(themeClass)) {
            cssClasses.Add($"email-link-{themeClass}");
        }

        if (cssClasses.Count > 0) {
            linkAttributes.Add($"class=\"{string.Join(" ", cssClasses)}\"");
        }

        // Get theme-aware colors
        var actualColor = GetThemeColor();

        // Build inline style
        var linkStyle = new List<string>();
        linkStyle.Add($"font-family: {FontFamily}");
        linkStyle.Add($"font-size: {FontSize}");
        linkStyle.Add($"line-height: {LineHeight}");
        linkStyle.Add($"color: {actualColor}");
        linkStyle.Add($"text-align: {TextAlign}");
        linkStyle.Add($"font-weight: {FontWeight}");
        linkStyle.Add($"text-decoration: {TextDecoration}");
        linkStyle.Add($"margin: {Margin}");
        linkStyle.Add($"padding: {Padding}");

        if (!string.IsNullOrEmpty(InlineStyle)) {
            linkStyle.Add(InlineStyle);
        }

        var linkStyleAttr = $" style=\"{string.Join("; ", linkStyle)}\"";

        // Get theme class for table cell
        var cellThemeClass = Email?.Configuration?.Email?.ThemeMode switch {
            EmailThemeMode.Dark => " theme-dark",
            EmailThemeMode.Auto => " auto-dark-mode",
            _ => ""
        };

        // Check if we're being rendered inside an EmailColumn (part of a row)
        // If so, don't wrap in table structure - just return the content
        var isInColumn = IsInEmailColumn();

        if (isInColumn) {
            // When inside a column, render as a div, not a table
            // Inherit alignment from parent column if not explicitly set
            var effectiveAlignment = TextAlign;
            if (TextAlign == "left" && ParentColumn != null && !string.IsNullOrEmpty(ParentColumn.TextAlign)) {
                effectiveAlignment = ParentColumn.TextAlign;
            }

            var divStyle = $"margin: {Margin}; padding: {Padding}; text-align: {effectiveAlignment}; font-family: {FontFamily};";
            html.AppendLine($@"<div class=""email-link{cellThemeClass}"" style=""{divStyle}"">");
            html.AppendLine($@"<a {string.Join(" ", linkAttributes)}{linkStyleAttr}>{Helpers.HtmlEncode(Content)}</a>");
            html.AppendLine($@"</div>");
        } else {
            // When standalone, use table structure for email compatibility
            html.AppendLine($@"
<tr>
<td class=""email-link{cellThemeClass}"" style=""margin: {Margin}; padding: {Padding}; text-align: {TextAlign}; font-family: {FontFamily};"">
<a {string.Join(" ", linkAttributes)}{linkStyleAttr}>{Helpers.HtmlEncode(Content)}</a>
</td>
</tr>
");
        }

        return StringBuilderCache.GetStringAndRelease(html);
    }

    /// <summary>
    /// Checks if this EmailLink is being rendered inside an EmailColumn.
    /// </summary>
    /// <returns>True if inside an EmailColumn, false otherwise.</returns>
    private bool IsInEmailColumn() {
        return ParentColumn != null;
    }
}