namespace HtmlForgeX;

public class ElementContainer : Element {
    public override string ToString() {
        return string.Join("", Children.Select(child => child.ToString()));
    }
}