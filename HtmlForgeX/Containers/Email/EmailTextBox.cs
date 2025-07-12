namespace HtmlForgeX;

/// <summary>
/// Represents a text box container for email layouts that groups text content with consistent styling.
/// Similar to EmailText but acts as a container for multiple text elements with shared properties.
/// </summary>
public class EmailTextBox : Element {
    /// <summary>
    /// Gets or sets the font family for all text in the box.
    /// </summary>
    public string FontFamily { get; set; } = "Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif";

    /// <summary>
    /// Gets or sets the font size for all text in the box.
    /// </summary>
    public string FontSize { get; set; } = "15px";

    /// <summary>
    /// Gets or sets the line height for all text in the box.
    /// </summary>
    public string LineHeight { get; set; } = "160%";

    /// <summary>
    /// Gets or sets the text color for all text in the box.
    /// </summary>
    public string Color { get; set; } = "#4b5563";

    /// <summary>
    /// Gets or sets the text alignment for all text in the box.
    /// </summary>
    public string TextAlign { get; set; } = "left";

    /// <summary>
    /// Gets or sets the font weight for all text in the box.
    /// </summary>
    public string FontWeight { get; set; } = "normal";

    /// <summary>
    /// Gets or sets the text decoration for all text in the box.
    /// </summary>
    public string TextDecoration { get; set; } = "none";

    /// <summary>
    /// Gets or sets the margin for the text box.
    /// </summary>
    public string Margin { get; set; } = "0 0 16px 0";

    /// <summary>
    /// Gets or sets the padding for the text box.
    /// </summary>
    public string Padding { get; set; } = "0";

    /// <summary>
    /// Gets the list of text content (strings) to be rendered.
    /// </summary>
    public List<string> TextContent { get; } = new List<string>();

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailTextBox"/> class.
    /// </summary>
    public EmailTextBox() { }

    /// <summary>
    /// Adds text content to the text box.
    /// </summary>
    /// <param name="text">The text to add.</param>
    /// <returns>The EmailTextBox object, allowing for method chaining.</returns>
    public EmailTextBox AddText(string text) {
        TextContent.Add(text);
        return this;
    }

    /// <summary>
    /// Adds multiple text lines to the text box.
    /// </summary>
    /// <param name="textLines">The text lines to add.</param>
    /// <returns>The EmailTextBox object, allowing for method chaining.</returns>
    public EmailTextBox AddText(params string[] textLines) {
        TextContent.AddRange(textLines);
        return this;
    }

    /// <summary>
    /// Sets the font family.
    /// </summary>
    /// <param name="fontFamily">The font family.</param>
    /// <returns>The EmailTextBox object, allowing for method chaining.</returns>
    public EmailTextBox WithFontFamily(string fontFamily) {
        FontFamily = fontFamily;
        return this;
    }

    /// <summary>
    /// Sets the font size.
    /// </summary>
    /// <param name="fontSize">The font size.</param>
    /// <returns>The EmailTextBox object, allowing for method chaining.</returns>
    public EmailTextBox WithFontSize(string fontSize) {
        FontSize = fontSize;
        return this;
    }

    /// <summary>
    /// Sets the line height.
    /// </summary>
    /// <param name="lineHeight">The line height.</param>
    /// <returns>The EmailTextBox object, allowing for method chaining.</returns>
    public EmailTextBox WithLineHeight(string lineHeight) {
        LineHeight = lineHeight;
        return this;
    }

    /// <summary>
    /// Sets the text color.
    /// </summary>
    /// <param name="color">The text color.</param>
    /// <returns>The EmailTextBox object, allowing for method chaining.</returns>
    public EmailTextBox WithColor(string color) {
        Color = color;
        return this;
    }

    /// <summary>
    /// Sets the text color using RGBColor.
    /// </summary>
    /// <param name="color">The text color.</param>
    /// <returns>The EmailTextBox object, allowing for method chaining.</returns>
    public EmailTextBox WithColor(RGBColor color) {
        Color = color.ToString();
        return this;
    }

    /// <summary>
    /// Sets the text alignment.
    /// </summary>
    /// <param name="alignment">The text alignment.</param>
    /// <returns>The EmailTextBox object, allowing for method chaining.</returns>
    /// <summary>
    /// Sets the text alignment.
    /// </summary>
    /// <param name="alignment">The alignment option.</param>
    /// <returns>The <see cref="EmailTextBox"/> instance.</returns>
    public EmailTextBox WithAlignment(FontAlignment alignment) {
        alignment.ValidateEmailAlignment();
        TextAlign = alignment.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets the font weight.
    /// </summary>
    /// <param name="fontWeight">The font weight.</param>
    /// <returns>The EmailTextBox object, allowing for method chaining.</returns>
    public EmailTextBox WithFontWeight(string fontWeight) {
        FontWeight = fontWeight;
        return this;
    }

    /// <summary>
    /// Sets the font weight using predefined values.
    /// </summary>
    /// <param name="fontWeight">The predefined font weight.</param>
    /// <returns>The <see cref="EmailTextBox"/> instance.</returns>
    public EmailTextBox WithFontWeight(FontWeight fontWeight) {
        FontWeight = fontWeight.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets the text decoration.
    /// </summary>
    /// <param name="textDecoration">The text decoration.</param>
    /// <returns>The EmailTextBox object, allowing for method chaining.</returns>
    public EmailTextBox WithTextDecoration(string textDecoration) {
        TextDecoration = textDecoration;
        return this;
    }

    /// <summary>
    /// Sets the text decoration using predefined options.
    /// </summary>
    /// <param name="decoration">The decoration option.</param>
    /// <returns>The <see cref="EmailTextBox"/> instance.</returns>
    public EmailTextBox WithTextDecoration(TextDecoration decoration) {
        TextDecoration = decoration.EnumToString();
        return this;
    }

    /// <summary>
    /// Sets the margin.
    /// </summary>
    /// <param name="margin">The margin value.</param>
    /// <returns>The EmailTextBox object, allowing for method chaining.</returns>
    public EmailTextBox WithMargin(string margin) {
        Margin = margin;
        return this;
    }

    /// <summary>
    /// Sets the padding.
    /// </summary>
    /// <param name="padding">The padding value.</param>
    /// <returns>The EmailTextBox object, allowing for method chaining.</returns>
    public EmailTextBox WithPadding(string padding) {
        Padding = padding;
        return this;
    }

    /// <summary>
    /// Converts the EmailTextBox to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the email text box.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        // Build inline style for the container
        var containerStyle = $"font-family: {FontFamily}; font-size: {FontSize}; line-height: {LineHeight}; color: {Color}; text-align: {TextAlign}; font-weight: {FontWeight}; text-decoration: {TextDecoration}; margin: {Margin}; padding: {Padding};";

        // Use div structure for text box content
        html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t<tr>");
        html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<td style=\"font-family: {FontFamily};\">");
        
        if (TextAlign == "center") {
            html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div align=\"center\">");
        } else {
            html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<div class=\"defaultText\">");
        }

        // Render text content
        if (TextContent.Count > 0) {
            for (int i = 0; i < TextContent.Count; i++) {
                var text = TextContent[i];
                var encodedText = Helpers.HtmlEncode(text);
                
                if (string.IsNullOrEmpty(text)) {
                    // Empty line
                    html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<span style=\"{containerStyle}\"></span>");
                } else {
                    html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<span style=\"{containerStyle}\">{encodedText}</span>");
                }

                // Add line break between lines (except for last line)
                if (i < TextContent.Count - 1) {
                    html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t<br />");
                }
            }
        }

        // Render child elements (nested content)
        foreach (var child in Children) {
            html.AppendLine(child.ToString());
        }

        html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</div>");
        html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t</td>");
        html.AppendLine($"\t\t\t\t\t\t\t\t\t\t\t\t\t\t</tr>");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}