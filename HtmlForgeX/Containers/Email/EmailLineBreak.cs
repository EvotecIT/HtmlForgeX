namespace HtmlForgeX;

/// <summary>
/// Represents a line break for email layouts that adds vertical spacing.
/// </summary>
public class EmailLineBreak : Element {
    /// <summary>
    /// Gets or sets the height of the line break.
    /// </summary>
    public string Height { get; set; } = "16px";

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailLineBreak"/> class.
    /// </summary>
    public EmailLineBreak() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailLineBreak"/> class with a specific height.
    /// </summary>
    /// <param name="height">The height of the line break.</param>
    public EmailLineBreak(string height) {
        Height = height;
    }

    /// <summary>
    /// Sets the height of the line break.
    /// </summary>
    /// <param name="height">The height value.</param>
    /// <returns>The EmailLineBreak object, allowing for method chaining.</returns>
    public EmailLineBreak WithHeight(string height) {
        Height = height;
        return this;
    }

    /// <summary>
    /// Converts the EmailLineBreak to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the email line break.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        html.AppendLine($"<tr>");
        html.AppendLine($"<td style=\"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; height: {Height}; line-height: {Height};\"></td>");
        html.AppendLine($"</tr>");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}