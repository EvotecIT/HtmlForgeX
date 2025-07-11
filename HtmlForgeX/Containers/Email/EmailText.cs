namespace HtmlForgeX;

/// <summary>
/// Represents a text element for email layouts with email-safe styling.
/// Provides text content with customizable fonts, colors, and spacing.
/// </summary>
public class EmailText : Element {
    /// <summary>
    /// Gets or sets the text content.
    /// </summary>
    public string Content { get; set; } = "";

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
    /// Gets or sets the text color.
    /// </summary>
    public string Color { get; set; } = "#4b5563";

    /// <summary>
    /// Gets the appropriate text color based on theme mode.
    /// </summary>
    public string GetThemeColor() {
        // If a custom color was explicitly set (not default), use it
        if (Color != "#4b5563") {
            return Color;
        }

        // Use theme-appropriate default color
        if (Email?.Configuration?.Email?.ThemeMode == EmailThemeMode.Dark) {
            return "rgba(255, 255, 255, 0.8)"; // Dark mode text color
        }
        return Color; // Light mode text color
    }

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
    public string Padding { get; set; } = "";

    /// <summary>
    /// Gets or sets whether to include line break.
    /// </summary>
    public bool LineBreak { get; set; } = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailText"/> class.
    /// </summary>
    public EmailText() {
        // Set default padding from EmailLayout for consistency
        Padding = EmailLayout.GetContentPadding();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailText"/> class with content.
    /// </summary>
    /// <param name="content">The text content.</param>
    public EmailText(string content) : this() {
        Content = content;
    }

    /// <summary>
    /// Sets the text content.
    /// </summary>
    /// <param name="content">The text content.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText Text(string content) {
        Content = content;
        return this;
    }

    /// <summary>
    /// Sets the font family.
    /// </summary>
    /// <param name="fontFamily">The font family.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithFontFamily(string fontFamily) {
        FontFamily = fontFamily;
        return this;
    }

    /// <summary>
    /// Sets the font size.
    /// </summary>
    /// <param name="fontSize">The font size.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithFontSize(string fontSize) {
        FontSize = fontSize;
        return this;
    }

    /// <summary>
    /// Sets the font size using predefined values.
    /// </summary>
    /// <param name="fontSize">The predefined font size.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithFontSize(EmailFontSize fontSize) {
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
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithLineHeight(string lineHeight) {
        LineHeight = lineHeight;
        return this;
    }

    /// <summary>
    /// Sets the text color.
    /// </summary>
    /// <param name="color">The text color.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithColor(string color) {
        Color = color;
        return this;
    }

    /// <summary>
    /// Sets the text color using RGBColor.
    /// </summary>
    /// <param name="color">The text color.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithColor(RGBColor color) {
        Color = color.ToString();
        return this;
    }

    /// <summary>
    /// Sets the text alignment.
    /// </summary>
    /// <param name="alignment">The text alignment.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithAlignment(string alignment) {
        TextAlign = alignment;
        return this;
    }

    /// <summary>
    /// Sets the font weight.
    /// </summary>
    /// <param name="fontWeight">The font weight.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithFontWeight(string fontWeight) {
        FontWeight = fontWeight;
        return this;
    }

    /// <summary>
    /// Sets the font weight using predefined values.
    /// </summary>
    /// <param name="fontWeight">The predefined font weight.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithFontWeight(EmailFontWeight fontWeight) {
        FontWeight = fontWeight.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets the text decoration.
    /// </summary>
    /// <param name="textDecoration">The text decoration.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithTextDecoration(string textDecoration) {
        TextDecoration = textDecoration;
        return this;
    }

    /// <summary>
    /// Sets the margin.
    /// </summary>
    /// <param name="margin">The margin value.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithMargin(string margin) {
        Margin = margin;
        return this;
    }

    /// <summary>
    /// Sets the margin using predefined spacing values.
    /// </summary>
    /// <param name="spacing">The predefined spacing value for all sides.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithMargin(EmailSpacing spacing) {
        Margin = spacing.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets the margin using predefined spacing values for vertical and horizontal.
    /// </summary>
    /// <param name="vertical">The predefined vertical spacing (top and bottom).</param>
    /// <param name="horizontal">The predefined horizontal spacing (left and right).</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithMargin(EmailSpacing vertical, EmailSpacing horizontal) {
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
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithMargin(EmailSpacing top, EmailSpacing right, EmailSpacing bottom, EmailSpacing left) {
        Margin = $"{top.ToCssValue()} {right.ToCssValue()} {bottom.ToCssValue()} {left.ToCssValue()}";
        return this;
    }

    /// <summary>
    /// Sets the padding.
    /// </summary>
    /// <param name="padding">The padding value.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithPadding(string padding) {
        Padding = padding;
        return this;
    }

    /// <summary>
    /// Sets the padding using predefined spacing values.
    /// </summary>
    /// <param name="spacing">The predefined spacing value for all sides.</param>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithPadding(EmailSpacing spacing) {
        Padding = spacing.ToCssValue();
        return this;
    }

    /// <summary>
    /// Enables line break after this text.
    /// </summary>
    /// <returns>The EmailText object, allowing for method chaining.</returns>
    public EmailText WithLineBreak() {
        LineBreak = true;
        return this;
    }

    /// <summary>
    /// Converts the EmailText to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the email text.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        // Get theme-aware color
        var actualColor = GetThemeColor();

        // Get theme class for CSS
        var themeClass = Email?.Configuration?.Email?.ThemeMode switch {
            EmailThemeMode.Dark => " theme-dark",
            EmailThemeMode.Auto => " auto-dark-mode",
            _ => ""
        };

        // Build inline style - consistent with other email components
        var style = new List<string>();
        style.Add($"font-family: {FontFamily}");
        style.Add($"font-size: {FontSize}");
        style.Add($"line-height: {LineHeight}");
        style.Add($"color: {actualColor}");
        style.Add($"text-align: {TextAlign}");
        style.Add($"font-weight: {FontWeight}");
        style.Add($"text-decoration: {TextDecoration}");
        style.Add($"margin: {Margin}");
        style.Add($"padding: {Padding}");

        var styleAttr = $"style=\"{string.Join("; ", style)}\"";

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

            // Build style with overflow protection
            var columnStyle = $@"font-family: {FontFamily}; font-size: {FontSize}; line-height: {LineHeight};
                color: {actualColor}; text-align: {effectiveAlignment}; font-weight: {FontWeight};
                text-decoration: {TextDecoration}; margin: {Margin}; padding: {Padding};
                word-wrap: break-word; overflow-wrap: break-word; max-width: 100%;";

            var content = Helpers.HtmlEncode(Content);
            var lineBreak = LineBreak ? "<br>" : "";

            html.AppendLine($@"<div class=""email-text{themeClass}"" style=""{columnStyle}"">{content}{lineBreak}</div>");
        } else {
            // When standalone, use table structure for email compatibility
            var content = Helpers.HtmlEncode(Content);
            var lineBreak = LineBreak ? "<br>" : "";

            html.AppendLine($@"<tr>
<td class=""email-text{themeClass}"" {styleAttr}>{content}{lineBreak}</td>
</tr>");
        }

        return StringBuilderCache.GetStringAndRelease(html);
    }

    /// <summary>
    /// Checks if this EmailText is being rendered inside an EmailColumn.
    /// </summary>
    /// <returns>True if inside an EmailColumn, false otherwise.</returns>
    private bool IsInEmailColumn() {
        return ParentColumn != null;
    }


}