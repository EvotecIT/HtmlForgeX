namespace HtmlForgeX;

public abstract class HtmlElement {
    public List<HtmlElement> Children { get; } = new List<HtmlElement>();

    public HtmlElement Add(HtmlElement child) {
        Children.Add(child);
        return this;
    }

    public abstract override string ToString();
}
