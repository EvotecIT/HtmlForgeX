namespace HtmlForgeX;

/// <summary>
/// Simple unordered list rendered with Tabler styles.
/// </summary>
public class UnorderedList : Element {
    private HtmlTag ulTag;
    private HtmlTag? liTag;

    /// <summary>
    /// Initializes or configures UnorderedList.
    /// </summary>
    public UnorderedList() {
        ulTag = new HtmlTag("ul").Class("list-unstyled space-y-1");
    }

    /// <summary>
    /// Initializes or configures AddItem.
    /// </summary>
    public UnorderedList AddItem(string item, TablerIconType TablerIconType) {
        liTag = new HtmlTag("li");
        liTag.Value(new TablerIconElement(TablerIconType)).Value(" " + item);
        ulTag.Value(liTag);
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        return ulTag.ToString();
    }
}