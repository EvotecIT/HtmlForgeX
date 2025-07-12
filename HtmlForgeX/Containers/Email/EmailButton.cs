namespace HtmlForgeX;

/// <summary>
/// Represents an email-compatible button component using table-based layout.
/// </summary>
public class EmailButton : Element {
    /// <summary>
    /// Gets or sets the button text.
    /// </summary>
    public string Text { get; set; } = "";

    /// <summary>
    /// Gets or sets the button link URL.
    /// </summary>
    public string Href { get; set; } = "";

    /// <summary>
    /// Gets or sets the button style type.
    /// </summary>
    public EmailButtonStyle Style { get; set; } = EmailButtonStyle.Primary;

    /// <summary>
    /// Gets or sets the button size.
    /// </summary>
    public EmailButtonSize Size { get; set; } = EmailButtonSize.Medium;

    /// <summary>
    /// Gets or sets the background color for custom styling.
    /// </summary>
    public string BackgroundColor { get; set; } = "";

    /// <summary>
    /// Gets or sets the text color for custom styling.
    /// </summary>
    public string TextColor { get; set; } = "";

    /// <summary>
    /// Gets or sets the border color for custom styling.
    /// </summary>
    public string BorderColor { get; set; } = "";

    /// <summary>
    /// Gets or sets the border radius.
    /// </summary>
    public string BorderRadius { get; set; } = "8px";

    /// <summary>
    /// Gets or sets additional CSS classes.
    /// </summary>
    public string CssClass { get; set; } = "";

    /// <summary>
    /// Gets or sets whether the button should be full width.
    /// </summary>
    public bool FullWidth { get; set; } = false;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailButton"/> class.
    /// </summary>
    public EmailButton() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailButton"/> class with text and URL.
    /// </summary>
    /// <param name="text">The button text.</param>
    /// <param name="href">The button link URL.</param>
    /// <param name="style">The button style.</param>
    public EmailButton(string text, string href, EmailButtonStyle style = EmailButtonStyle.Primary) {
        Text = text;
        Href = href;
        Style = style;
    }

    /// <summary>
    /// Sets the button text.
    /// </summary>
    /// <param name="text">The button text.</param>
    /// <returns>The EmailButton object, allowing for method chaining.</returns>
    public EmailButton SetText(string text) {
        Text = text;
        return this;
    }

    /// <summary>
    /// Sets the button URL.
    /// </summary>
    /// <param name="href">The button link URL.</param>
    /// <returns>The EmailButton object, allowing for method chaining.</returns>
    public EmailButton SetHref(string href) {
        Href = href;
        return this;
    }

    /// <summary>
    /// Sets the button style.
    /// </summary>
    /// <param name="style">The button style.</param>
    /// <returns>The EmailButton object, allowing for method chaining.</returns>
    public EmailButton SetStyle(EmailButtonStyle style) {
        Style = style;
        return this;
    }

    /// <summary>
    /// Sets the button size.
    /// </summary>
    /// <param name="size">The button size.</param>
    /// <returns>The EmailButton object, allowing for method chaining.</returns>
    public EmailButton SetSize(EmailButtonSize size) {
        Size = size;
        return this;
    }

    /// <summary>
    /// Sets custom colors for the button.
    /// </summary>
    /// <param name="backgroundColor">The background color.</param>
    /// <param name="textColor">The text color.</param>
    /// <param name="borderColor">The border color (optional).</param>
    /// <returns>The EmailButton object, allowing for method chaining.</returns>
    public EmailButton SetColors(string backgroundColor, string textColor, string borderColor = "") {
        BackgroundColor = backgroundColor;
        TextColor = textColor;
        BorderColor = string.IsNullOrEmpty(borderColor) ? backgroundColor : borderColor;
        Style = EmailButtonStyle.Custom;
        return this;
    }

    /// <summary>
    /// Sets custom colors for the button.
    /// </summary>
    /// <param name="backgroundColor">The background color.</param>
    /// <param name="textColor">The text color.</param>
    /// <param name="borderColor">The border color (optional).</param>
    /// <returns>The EmailButton object, allowing for method chaining.</returns>
    public EmailButton SetColors(RGBColor backgroundColor, RGBColor textColor, RGBColor? borderColor = null) {
        BackgroundColor = backgroundColor.ToString();
        TextColor = textColor.ToString();
        BorderColor = borderColor?.ToString() ?? backgroundColor.ToString();
        Style = EmailButtonStyle.Custom;
        return this;
    }

    /// <summary>
    /// Makes the button full width.
    /// </summary>
    /// <returns>The EmailButton object, allowing for method chaining.</returns>
    public EmailButton SetFullWidth() {
        FullWidth = true;
        return this;
    }

    /// <summary>
    /// Converts the EmailButton to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the email button.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        // Get style-specific properties
        var (bgColor, txtColor, borderColor) = GetStyleColors();
        var (fontSize, padding) = GetSizeProperties();

        // Build button classes
        var buttonClasses = $"btn {GetStyleClass()}";
        if (!string.IsNullOrEmpty(CssClass)) {
            buttonClasses += $" {CssClass}";
        }

        // Build table width
        var tableWidth = FullWidth ? "100%" : "100%";

        html.AppendLine($@"
<!-- BUTTON -->
<table cellspacing=""0"" cellpadding=""0"" role=""presentation"" style=""font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: collapse; width: 100%;"">
<tr>
<td align=""center"" style=""font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;"">
<table cellpadding=""0"" cellspacing=""0"" border=""0"" class=""{GetStyleClass()} rounded-lg"" role=""presentation"" style=""font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: separate; width: {tableWidth}; color: {txtColor}; border-radius: {BorderRadius};"" bgcolor=""{bgColor}"">
<tr>
<td align=""center"" valign=""top"" class=""lh-1"" style=""font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; line-height: 100%;"">
<a href=""{Helpers.HtmlEncode(Href)}"" class=""{buttonClasses}"" style=""color: {txtColor}; text-decoration: none; white-space: nowrap; font-weight: 500; font-size: {fontSize}; border-radius: {BorderRadius}; line-height: 125%; display: block; background-color: {bgColor}; padding: {padding}; border: 1px solid {borderColor};"">
<span class=""btn-span"" style=""color: {txtColor}; font-size: 14px; text-decoration: none; white-space: nowrap; font-weight: 500; line-height: 100%;"">{Helpers.HtmlEncode(Text)}</span>
</a>
</td>
</tr>
</table>
</td>
</tr>
</table>
<!-- /BUTTON -->
");

        return StringBuilderCache.GetStringAndRelease(html);
    }

    private (string bgColor, string txtColor, string borderColor) GetStyleColors() {
        if (Style == EmailButtonStyle.Custom && !string.IsNullOrEmpty(BackgroundColor)) {
            return (BackgroundColor, TextColor, BorderColor);
        }

        return Style switch {
            EmailButtonStyle.Primary => ("#066FD1", "#ffffff", "#066FD1"),
            EmailButtonStyle.Secondary => ("#f0f1f3", "#4b5563", "#e8ebee"),
            EmailButtonStyle.Success => ("#2ca73f", "#ffffff", "#2ca73f"),
            EmailButtonStyle.Danger => ("#d32c2c", "#ffffff", "#d32c2c"),
            EmailButtonStyle.Warning => ("#e69500", "#ffffff", "#e69500"),
            EmailButtonStyle.Info => ("#1596aa", "#ffffff", "#1596aa"),
            EmailButtonStyle.Light => ("#ffffff", "#4b5563", "#e8ebee"),
            EmailButtonStyle.Dark => ("#111827", "#ffffff", "#111827"),
            _ => ("#066FD1", "#ffffff", "#066FD1")
        };
    }

    private (string fontSize, string padding) GetSizeProperties() {
        return Size switch {
            EmailButtonSize.Small => ("14px", "8px 24px"),
            EmailButtonSize.Medium => ("16px", "12px 32px"),
            EmailButtonSize.Large => ("18px", "16px 40px"),
            _ => ("16px", "12px 32px")
        };
    }

    private string GetStyleClass() {
        return Style switch {
            EmailButtonStyle.Primary => "bg-blue border-blue",
            EmailButtonStyle.Secondary => "bg-secondary border-secondary",
            EmailButtonStyle.Success => "bg-green border-green",
            EmailButtonStyle.Danger => "bg-red border-red",
            EmailButtonStyle.Warning => "bg-yellow border-yellow",
            EmailButtonStyle.Info => "bg-cyan border-cyan",
            EmailButtonStyle.Light => "bg-white border-light",
            EmailButtonStyle.Dark => "bg-dark border-dark",
            EmailButtonStyle.Custom => "bg-custom border-custom",
            _ => "bg-blue border-blue"
        };
    }
}

/// <summary>
/// Enum for email button styles.
/// </summary>
public enum EmailButtonStyle {
    Primary,
    Secondary,
    Success,
    Danger,
    Warning,
    Info,
    Light,
    Dark,
    Custom
}

/// <summary>
/// Enum for email button sizes.
/// </summary>
public enum EmailButtonSize {
    Small,
    Medium,
    Large
}