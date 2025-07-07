namespace HtmlForgeX;

/// <summary>
/// Represents a content box container for email layouts.
/// Provides email-compatible styling with background colors, borders, and shadows.
/// </summary>
public class EmailBox : Element {
    /// <summary>
    /// Gets or sets the background color of the box.
    /// </summary>
    public string BackgroundColor { get; set; } = "#ffffff";

    /// <summary>
    /// Gets or sets the border radius of the box.
    /// </summary>
    public string BorderRadius { get; set; } = "8px";

    /// <summary>
    /// Gets or sets the border color of the box.
    /// </summary>
    public string BorderColor { get; set; } = "#e8ebee";

    /// <summary>
    /// Gets or sets the border width of the box.
    /// </summary>
    public string BorderWidth { get; set; } = "1px";

    /// <summary>
    /// Gets or sets whether to include box shadow.
    /// </summary>
    public bool IncludeBoxShadow { get; set; } = true;

    /// <summary>
    /// Gets or sets the box shadow CSS.
    /// </summary>
    public string BoxShadow { get; set; } = "0 1px 4px rgba(0, 0, 0, 0.05)";

    /// <summary>
    /// Gets or sets additional CSS classes for the box.
    /// </summary>
    public string CssClass { get; set; } = "box";

    /// <summary>
    /// Gets or sets the padding inside the box.
    /// </summary>
    public string Padding { get; set; } = EmailLayout.GetContainerPadding();

    /// <summary>
    /// Gets or sets additional inline styles.
    /// </summary>
    public string InlineStyle { get; set; } = "";

    /// <summary>
    /// Gets or sets whether to use consistent spacing between elements.
    /// When true, applies consistent vertical spacing between child elements.
    /// </summary>
    public bool UseConsistentSpacing { get; set; } = true;

    /// <summary>
    /// Gets or sets the spacing between child elements.
    /// </summary>
    public string ChildSpacing { get; set; } = EmailLayout.ChildSpacing;

    /// <summary>
    /// Gets or sets the outer margin around the entire box.
    /// </summary>
    public string OuterMargin { get; set; } = $"0 auto {EmailLayout.BoxSpacing} auto";

    /// <summary>
    /// Gets or sets the maximum width of the box.
    /// </summary>
    public string MaxWidth { get; set; } = "600px";

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailBox"/> class.
    /// </summary>
    public EmailBox() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailBox"/> class with custom styling.
    /// </summary>
    /// <param name="backgroundColor">The background color.</param>
    /// <param name="padding">The padding inside the box.</param>
    public EmailBox(string backgroundColor, string padding = "48px") {
        BackgroundColor = backgroundColor;
        Padding = padding;
    }

    /// <summary>
    /// Sets the background color of the box.
    /// </summary>
    /// <param name="color">The background color.</param>
    /// <returns>The EmailBox object, allowing for method chaining.</returns>
    public EmailBox SetBackgroundColor(string color) {
        BackgroundColor = color;
        return this;
    }

    /// <summary>
    /// Sets the padding of the box.
    /// </summary>
    /// <param name="padding">The padding value.</param>
    /// <returns>The EmailBox object, allowing for method chaining.</returns>
    public EmailBox SetPadding(string padding) {
        Padding = padding;
        return this;
    }

    /// <summary>
    /// Sets the border radius of the box.
    /// </summary>
    /// <param name="radius">The border radius value.</param>
    /// <returns>The EmailBox object, allowing for method chaining.</returns>
    public EmailBox SetBorderRadius(string radius) {
        BorderRadius = radius;
        return this;
    }

    /// <summary>
    /// Sets the border color of the box.
    /// </summary>
    /// <param name="color">The border color.</param>
    /// <returns>The EmailBox object, allowing for method chaining.</returns>
    public EmailBox SetBorderColor(string color) {
        BorderColor = color;
        return this;
    }

    /// <summary>
    /// Disables the box shadow.
    /// </summary>
    /// <returns>The EmailBox object, allowing for method chaining.</returns>
    public EmailBox DisableBoxShadow() {
        IncludeBoxShadow = false;
        return this;
    }

    /// <summary>
    /// Sets the consistent spacing between child elements.
    /// </summary>
    /// <param name="spacing">The spacing value.</param>
    /// <returns>The EmailBox object, allowing for method chaining.</returns>
    public EmailBox SetChildSpacing(string spacing) {
        ChildSpacing = spacing;
        UseConsistentSpacing = true;
        return this;
    }

    /// <summary>
    /// Disables consistent spacing between child elements.
    /// </summary>
    /// <returns>The EmailBox object, allowing for method chaining.</returns>
    public EmailBox DisableConsistentSpacing() {
        UseConsistentSpacing = false;
        return this;
    }

    /// <summary>
    /// Sets the outer margin around the box.
    /// </summary>
    /// <param name="margin">The margin value (e.g., "0 auto 24px auto").</param>
    /// <returns>The EmailBox object, allowing for method chaining.</returns>
    public EmailBox SetOuterMargin(string margin) {
        OuterMargin = margin;
        return this;
    }

    /// <summary>
    /// Sets the maximum width of the box.
    /// </summary>
    /// <param name="maxWidth">The maximum width value.</param>
    /// <returns>The EmailBox object, allowing for method chaining.</returns>
    public EmailBox SetMaxWidth(string maxWidth) {
        MaxWidth = maxWidth;
        return this;
    }

    /// <summary>
    /// Centers the box with specific horizontal margins.
    /// </summary>
    /// <param name="verticalMargin">The vertical margin (top and bottom).</param>
    /// <returns>The EmailBox object, allowing for method chaining.</returns>
    public EmailBox CenterWithMargin(string verticalMargin = "24px") {
        OuterMargin = $"{verticalMargin} auto";
        return this;
    }

    /// <summary>
    /// Adds an element to the box.
    /// </summary>
    /// <param name="element">The element to add.</param>
    /// <returns>The EmailBox object, allowing for method chaining.</returns>
    public EmailBox Add(Element element) {
        element.Email = this.Email;
        Children.Add(element);
        return this;
    }

    /// <summary>
    /// Adds content to the box using a configuration action.
    /// </summary>
    /// <param name="config">The configuration action for the content.</param>
    /// <returns>The EmailBox object, allowing for method chaining.</returns>
    public EmailBox Add(Action<BasicElement> config) {
        var element = new BasicElement();
        element.Email = this.Email;
        config(element);
        Children.Add(element);
        return this;
    }

    /// <summary>
    /// Converts the EmailBox to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the email box.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        // Build the inline style for the box div
        var boxStyle = $"background-color: {BackgroundColor}; border-radius: {BorderRadius};";

        if (IncludeBoxShadow) {
            boxStyle += $" -webkit-box-shadow: {BoxShadow}; box-shadow: {BoxShadow};";
        }

        boxStyle += $" border: {BorderWidth} solid {BorderColor};";

        if (!string.IsNullOrEmpty(InlineStyle)) {
            boxStyle += " " + InlineStyle;
        }

        // Create the main content div with outer margin and max width
        var outerStyle = $"margin: {OuterMargin}; max-width: {MaxWidth};";
        html.AppendLine($@"
<div class=""main-content"" style=""{outerStyle}"">
<div class=""{CssClass}"" style=""{boxStyle}"">
<table class=""box-table"" cellpadding=""0"" cellspacing=""0"" style=""font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: collapse; width: 100%; border-radius: {BorderRadius};"" bgcolor=""{BackgroundColor}"">
<tr>
<td style=""font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;"">
<table cellpadding=""0"" cellspacing=""0"" style=""font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: collapse; width: 100%;"">
");

        // Add content rows
        for (int i = 0; i < Children.Count; i++) {
            var child = Children[i];
            var isLastChild = i == Children.Count - 1;

            // Apply consistent spacing or use default padding
            var cellPadding = UseConsistentSpacing && !isLastChild
                ? $"{Padding} {Padding} {ChildSpacing} {Padding}"  // top right bottom left
                : Padding;

            html.AppendLine($@"
<tr>
<td class=""content"" style=""font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; padding: {cellPadding};"">
");

            var childContent = child.ToString();
            if (!string.IsNullOrEmpty(childContent)) {
                html.AppendLine(childContent);
            }

            html.AppendLine($@"
</td>
</tr>
");
        }

        // Close the table structure
        html.AppendLine($@"
</table>
</td>
</tr>
</table>
</div>
</div>
");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}