namespace HtmlForgeX;

/// <summary>
/// Basic container element rendering its children.
/// </summary>
public class ElementContainer : Element {
    public override string ToString() {
        return string.Join("", Children.Select(child => child.ToString()));
    }
}