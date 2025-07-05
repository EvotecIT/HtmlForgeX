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
    public string Padding { get; set; } = "48px";

    /// <summary>
    /// Gets or sets additional inline styles.
    /// </summary>
    public string InlineStyle { get; set; } = "";

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

        // Create the main content div
        html.AppendLine($"\t\t\t\t\t\t\t\t<div class=\"main-content\">");
        html.AppendLine($"\t\t\t\t\t\t\t\t\t<div class=\"{CssClass}\" style=\"{boxStyle}\">");

        // Create the inner table structure for email compatibility
        html.AppendLine($"\t\t\t\t\t\t\t\t\t\t<table class=\"box-table\" cellpadding=\"0\" cellspacing=\"0\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: collapse; width: 100%; border-radius: {BorderRadius};\" bgcolor=\"{BackgroundColor}\">");
        html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t<tr>");
        html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t<td style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;\">");
        html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t<table cellpadding=\"0\" cellspacing=\"0\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: collapse; width: 100%;\">");

        // Add content rows
        foreach (var child in Children) {
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t<tr>");
            html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<td class=\"content\" style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; padding: {Padding};\">");
            
            var childContent = child.ToString();
            if (!string.IsNullOrEmpty(childContent)) {
                html.AppendLine(childContent);
            }
            
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</td>");
            html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t\t</tr>");
        }

        // Close the table structure
        html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t\t</table>");
        html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t\t</td>");
        html.AppendLine("\t\t\t\t\t\t\t\t\t\t\t</tr>");
        html.AppendLine("\t\t\t\t\t\t\t\t\t\t</table>");
        html.AppendLine("\t\t\t\t\t\t\t\t\t</div>");
        html.AppendLine("\t\t\t\t\t\t\t\t</div>");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}