namespace HtmlForgeX;

public class UnorderedList : Element {
    private HtmlTag ulTag;
    private HtmlTag liTag;

    public UnorderedList() {
        ulTag = new HtmlTag("ul").Class("list-unstyled space-y-1");
    }

/// <summary>
/// Method AddItem.
/// </summary>
    public UnorderedList AddItem(string item, TablerIconType TablerIconType) {
        liTag = new HtmlTag("li");
        liTag.Value(new TablerIconElement(TablerIconType)).Value(" " + item);
        ulTag.Value(liTag);
        return this;
    }

/// <summary>
/// Method ToString.
/// </summary>
    public override string ToString() {
        return ulTag.ToString();
    }
}