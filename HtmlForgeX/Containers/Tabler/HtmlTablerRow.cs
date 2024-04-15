namespace HtmlForgeX;

public class HtmlTablerRow : HtmlElement {
    public List<HtmlTablerColumn> Columns { get; set; } = new List<HtmlTablerColumn>();

    public override string ToString() {
        Console.WriteLine("Generating HtmlRow...");
        var childrenHtml = string.Join("", Children.Select(child => child.ToString()));
        var result = $"<div class=\"row row-deck row-cards\">{childrenHtml}</div>";
        Console.WriteLine("Generated HtmlRow: " + result);
        return result;
    }
}
