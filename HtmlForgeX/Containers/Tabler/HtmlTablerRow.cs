namespace HtmlForgeX;

public class HtmlTablerRow : HtmlElement {
    //public List<HtmlTablerColumn> Columns { get; set; } = new List<HtmlTablerColumn>();

    public override string ToString() {
        Console.WriteLine("Generating HtmlRow...");
        var childrenHtml = string.Join("", Children.Select(child => child.ToString()));
        var result = $"<div class=\"row row-deck row-cards\">{childrenHtml}</div>";
        Console.WriteLine("Generated HtmlRow: " + result);
        return result;
    }

    public HtmlTablerColumn Column(Action<HtmlTablerColumn> config) {
        var column = new HtmlTablerColumn();
        config(column);
        this.Add(column);
        return column;
    }

    public HtmlTablerColumn Column(int number, Action<HtmlTablerColumn> config) {
        var column = new HtmlTablerColumn(number);
        config(column);
        this.Add(column);
        return column;
    }

}
