namespace HtmlForgeX;

public abstract class HtmlElement {
    public List<HtmlElement> Children { get; } = new List<HtmlElement>();

    public void Add(HtmlElement child) {
        Children.Add(child);
    }

    public abstract override string ToString();
}
