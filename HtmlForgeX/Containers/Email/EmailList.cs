using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Represents a list element for email layouts with email-safe styling.
/// Provides ordered and unordered lists with customizable items.
/// </summary>
public class EmailList : Element {
    /// <summary>
    /// Gets or sets whether this is an ordered list (true) or unordered list (false).
    /// </summary>
    public bool IsOrdered { get; set; } = false;

    /// <summary>
    /// Gets or sets the font family for the list.
    /// </summary>
    public string FontFamily { get; set; } = "Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif";

    /// <summary>
    /// Gets or sets the font size for the list.
    /// </summary>
    public string FontSize { get; set; } = "15px";

    /// <summary>
    /// Gets or sets the line height for the list.
    /// </summary>
    public string LineHeight { get; set; } = "160%";

    /// <summary>
    /// Gets or sets the text color for the list.
    /// </summary>
    public string Color { get; set; } = "#4b5563";

    /// <summary>
    /// Gets or sets the margin for the list.
    /// </summary>
    public string Margin { get; set; } = "0 0 16px 0";

    /// <summary>
    /// Gets or sets the padding for the list.
    /// </summary>
    public string Padding { get; set; } = "0 0 0 20px";

    /// <summary>
    /// Gets the list items.
    /// </summary>
    public List<EmailListItem> Items { get; } = new List<EmailListItem>();

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailList"/> class.
    /// </summary>
    public EmailList() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailList"/> class.
    /// </summary>
    /// <param name="isOrdered">Whether this is an ordered list.</param>
    public EmailList(bool isOrdered) {
        IsOrdered = isOrdered;
    }

    /// <summary>
    /// Sets whether this is an ordered list.
    /// </summary>
    /// <param name="isOrdered">True for ordered list, false for unordered.</param>
    /// <returns>The EmailList object, allowing for method chaining.</returns>
    public EmailList SetOrdered(bool isOrdered = true) {
        IsOrdered = isOrdered;
        return this;
    }

    /// <summary>
    /// Sets the font family.
    /// </summary>
    /// <param name="fontFamily">The font family.</param>
    /// <returns>The EmailList object, allowing for method chaining.</returns>
    public EmailList WithFontFamily(string fontFamily) {
        FontFamily = fontFamily;
        return this;
    }

    /// <summary>
    /// Sets the font size.
    /// </summary>
    /// <param name="fontSize">The font size.</param>
    /// <returns>The EmailList object, allowing for method chaining.</returns>
    public EmailList WithFontSize(string fontSize) {
        FontSize = fontSize;
        return this;
    }

    /// <summary>
    /// Sets the text color.
    /// </summary>
    /// <param name="color">The text color.</param>
    /// <returns>The EmailList object, allowing for method chaining.</returns>
    public EmailList WithColor(string color) {
        Color = color;
        return this;
    }

    /// <summary>
    /// Sets the text color using RGBColor.
    /// </summary>
    /// <param name="color">The text color.</param>
    /// <returns>The EmailList object, allowing for method chaining.</returns>
    public EmailList WithColor(RGBColor color) {
        Color = color.ToString();
        return this;
    }

    /// <summary>
    /// Adds a list item.
    /// </summary>
    /// <param name="text">The item text.</param>
    /// <returns>The EmailListItem object for further configuration.</returns>
    public EmailListItem AddItem(string text) {
        var item = new EmailListItem(text);
        Items.Add(item);
        return item;
    }

    /// <summary>
    /// Adds a list item with configuration.
    /// </summary>
    /// <param name="config">Configuration action for the item.</param>
    /// <returns>The EmailList object, allowing for method chaining.</returns>
    public EmailList AddItem(Action<EmailListItem> config) {
        var item = new EmailListItem();
        config(item);
        Items.Add(item);
        return this;
    }

    /// <summary>
    /// Adds content to the list using a configuration action.
    /// </summary>
    /// <param name="config">Configuration action for nested content.</param>
    /// <returns>The EmailList object, allowing for method chaining.</returns>
    public EmailList Add(Action<EmailList> config) {
        config(this);
        return this;
    }

    /// <summary>
    /// Converts the EmailList to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the email list.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        // Build inline style
        var style = $"font-family: {FontFamily}; font-size: {FontSize}; line-height: {LineHeight}; color: {Color}; margin: {Margin}; padding: {Padding};";

        var listTag = IsOrdered ? "ol" : "ul";

        html.AppendLine($@"
<tr>
<td style=""font-family: {FontFamily};"">
<{listTag} style=""{style}"">
");

        // Render items
        foreach (var item in Items.WhereNotNull()) {
            html.AppendLine(item.ToString().TrimEnd('\r', '\n'));
        }

        // Render child elements (nested lists, etc.)
        foreach (var child in Children.WhereNotNull()) {
            html.AppendLine(child.ToString().TrimEnd('\r', '\n'));
        }

        html.AppendLine($@"
</{listTag}>
</td>
</tr>
");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}

/// <summary>
/// Represents a list item for EmailList with customizable styling.
/// </summary>
public class EmailListItem {
    /// <summary>
    /// Gets or sets the item text.
    /// </summary>
    public string Text { get; set; } = "";

    /// <summary>
    /// Gets or sets the text color.
    /// </summary>
    public string Color { get; set; } = "";

    /// <summary>
    /// Gets or sets the font weight.
    /// </summary>
    public string FontWeight { get; set; } = "";

    /// <summary>
    /// Gets or sets the text decoration.
    /// </summary>
    public string TextDecoration { get; set; } = "";

    /// <summary>
    /// Gets or sets the font style.
    /// </summary>
    public string FontStyle { get; set; } = "";

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailListItem"/> class.
    /// </summary>
    public EmailListItem() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailListItem"/> class with text.
    /// </summary>
    /// <param name="text">The item text.</param>
    public EmailListItem(string text) {
        Text = text;
    }

    /// <summary>
    /// Sets the item text.
    /// </summary>
    /// <param name="text">The item text.</param>
    /// <returns>The EmailListItem object, allowing for method chaining.</returns>
    public EmailListItem SetText(string text) {
        Text = text;
        return this;
    }

    /// <summary>
    /// Sets the text color.
    /// </summary>
    /// <param name="color">The text color.</param>
    /// <returns>The EmailListItem object, allowing for method chaining.</returns>
    public EmailListItem WithColor(string color) {
        Color = color;
        return this;
    }

    /// <summary>
    /// Sets the text color using RGBColor.
    /// </summary>
    /// <param name="color">The text color.</param>
    /// <returns>The EmailListItem object, allowing for method chaining.</returns>
    public EmailListItem WithColor(RGBColor color) {
        Color = color.ToString();
        return this;
    }

    /// <summary>
    /// Sets the font weight.
    /// </summary>
    /// <param name="fontWeight">The font weight.</param>
    /// <returns>The EmailListItem object, allowing for method chaining.</returns>
    public EmailListItem WithFontWeight(string fontWeight) {
        FontWeight = fontWeight;
        return this;
    }

    /// <summary>
    /// Sets the font weight using predefined values.
    /// </summary>
    /// <param name="fontWeight">The predefined font weight.</param>
    /// <returns>The <see cref="EmailListItem"/> instance.</returns>
    public EmailListItem WithFontWeight(FontWeight fontWeight) {
        FontWeight = fontWeight.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets the text decoration.
    /// </summary>
    /// <param name="textDecoration">The text decoration.</param>
    /// <returns>The EmailListItem object, allowing for method chaining.</returns>
    public EmailListItem WithTextDecoration(string textDecoration) {
        TextDecoration = textDecoration;
        return this;
    }

    /// <summary>
    /// Sets the text decoration using predefined options.
    /// </summary>
    /// <param name="decoration">The decoration option.</param>
    /// <returns>The <see cref="EmailListItem"/> instance.</returns>
    public EmailListItem WithTextDecoration(TextDecoration decoration) {
        TextDecoration = decoration.EnumToString();
        return this;
    }

    /// <summary>
    /// Sets the font style.
    /// </summary>
    /// <param name="fontStyle">The font style.</param>
    /// <returns>The EmailListItem object, allowing for method chaining.</returns>
    public EmailListItem WithFontStyle(string fontStyle) {
        FontStyle = fontStyle;
        return this;
    }

    /// <summary>
    /// Converts the EmailListItem to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the list item.</returns>
    public override string ToString() {
        var styles = new List<string>();

        if (!string.IsNullOrEmpty(Color)) styles.Add($"color: {Color}");
        if (!string.IsNullOrEmpty(FontWeight)) styles.Add($"font-weight: {FontWeight}");
        if (!string.IsNullOrEmpty(TextDecoration)) styles.Add($"text-decoration: {TextDecoration}");
        if (!string.IsNullOrEmpty(FontStyle)) styles.Add($"font-style: {FontStyle}");

        var styleAttr = styles.Count > 0 ? $" style=\"{string.Join("; ", styles)}\"" : "";
        var encodedText = Helpers.HtmlEncode(Text);

        return $"<li{styleAttr}>{encodedText}</li>";
    }
}