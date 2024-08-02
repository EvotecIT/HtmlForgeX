namespace HtmlForgeX;

public class UnorderedList : Element {
    private HtmlTag ulTag;
    private HtmlTag liTag;

    public UnorderedList() {
        ulTag = new HtmlTag("ul").Class("list-unstyled space-y-1");
    }

    public UnorderedList AddItem(string item, TablerIcon icon) {
        liTag = new HtmlTag("li");
        liTag.Value(new TablerIconElement(icon)).Value(" " + item);
        ulTag.Value(liTag);
        return this;
    }

    public override string ToString() {
        return ulTag.ToString();
    }
}