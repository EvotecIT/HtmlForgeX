namespace HtmlForgeX;

public class TablerPage : HtmlElement {
    // public List<HtmlTablerRow> Rows { get; set; } = new List<HtmlTablerRow>();


    public TablerRow Rows(Action<TablerRow> config) {
        var row = new TablerRow();
        config(row);
        this.Add(row);
        return row;
    }


    //public HtmlTablerColumn Column() {
    //    var column = new HtmlTablerColumn();
    //    this.Add(column);
    //    return column;
    //}

    public TablerPage() {
        GlobalStorage.Libraries.Add(Libraries.Bootstrap);
        GlobalStorage.Libraries.Add(Libraries.Tabler);
    }

    public override string ToString() {
        Console.WriteLine("Generating HtmlPage...");
        var childrenHtml = string.Join("", Children.Select(child => child.ToString()));
        var result = $"<div class=\"page-wrapper\"><div class=\"page-body\"><div class=\"container-xl\">{childrenHtml}</div></div></div>";
        Console.WriteLine("Generated HtmlPage: " + result);
        return result;
    }

    public TablerPage Add(Action<TablerPage> config) {
        config(this);
        return this;
    }

    public TablerColumn Column(Action<TablerColumn> config) {
        var column = new TablerColumn();
        config(column);
        this.Add(column);
        return column;
    }
}
