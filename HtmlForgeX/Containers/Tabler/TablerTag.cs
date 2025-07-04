namespace HtmlForgeX;

/// <summary>
/// Represents a <c>span</c> element styled as a Tabler tag.
/// </summary>
public class TablerTag : Element {
    private string Text { get; }
    private TablerColor? Color { get; set; }
    private bool Dismiss { get; set; }
    private TablerTagSize Size { get; set; } = TablerTagSize.Normal;

    /// <summary>
    /// Initializes a new instance of the <see cref="TablerTag"/> class.
    /// </summary>
    /// <param name="text">Text displayed inside the tag.</param>
    /// <param name="color">Optional background color.</param>
    public TablerTag(string text, TablerColor? color = null) {
        Text = text;
        Color = color;
    }

    /// <summary>
    /// Sets the tag background color.
    /// </summary>
    /// <param name="color">Color to apply.</param>
    /// <returns>The current instance.</returns>
    public TablerTag TagColor(TablerColor color) {
        Color = color;
        return this;
    }

    /// <summary>
    /// Enables the dismiss icon inside the tag.
    /// </summary>
    /// <returns>The current instance.</returns>
    public TablerTag Dismissable() {
        Dismiss = true;
        return this;
    }

    /// <summary>
    /// Sets the tag size.
    /// </summary>
    /// <param name="size">Desired size.</param>
    /// <returns>The current instance.</returns>
    public TablerTag TagSize(TablerTagSize size) {
        Size = size;
        return this;
    }

    /// <summary>
    /// Converts the tag to its HTML representation.
    /// </summary>
    /// <returns>HTML string.</returns>
    public override string ToString() {
        var tag = new HtmlTag("span").Class("tag");
        var sizeClass = Size.EnumToString();
        if (!string.IsNullOrEmpty(sizeClass)) {
            tag.Class(sizeClass);
        }
        if (Color != null) {
            tag.Class(Color.Value.ToTablerBackground());
        }
        tag.Value(Text);
        if (Dismiss) {
            var dismiss = new HtmlTag("a")
                .Class("tag-remove")
                .Attribute("href", "#")
                .Value(new TablerIconElement(TablerIconType.X));
            tag.Value(dismiss);
        }
        return tag.ToString();
    }
}
