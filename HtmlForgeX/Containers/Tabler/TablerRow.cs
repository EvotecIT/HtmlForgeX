namespace HtmlForgeX;

public class TablerRow : HtmlElement {
    //public List<HtmlTablerColumn> Columns { get; set; } = new List<HtmlTablerColumn>();

    public override string ToString() {
        //Console.WriteLine("Generating HtmlRow...");
        var childrenHtml = string.Join("", Children.Select(child => child.ToString()));
        var result = $"<div class=\"row row-deck row-cards\">{childrenHtml}</div>";
        //Console.WriteLine("Generated HtmlRow: " + result);
        return result;
    }

    public TablerColumn Column(Action<TablerColumn> config) {
        var column = new TablerColumn();
        config(column);
        this.Add(column);
        return column;
    }

    public TablerColumn Column(int number, Action<TablerColumn> config) {
        var column = new TablerColumn(number);
        config(column);
        this.Add(column);
        return column;
    }

}
