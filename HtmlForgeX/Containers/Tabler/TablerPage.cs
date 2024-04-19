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
        //Console.WriteLine("Generating HtmlPage...");
        var layoutClass = Layout != TablerLayout.Default ? $" layout-{Layout.ToString().ToLower()}" : "";
        var pageWrapper = new HtmlTag("div").Class($"page-wrapper{layoutClass}");

        var pageBody = new HtmlTag("div").Class("page-body");
        pageWrapper.Append(pageBody);

        var container = new HtmlTag("div").Class("container-xl");
        foreach (var child in Children) {
            container.Append(child.ToString());
        }
        pageBody.Append(container);

        //Console.WriteLine("Generated HtmlPage: " + pageWrapper);
        return pageWrapper.ToString();
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

    public TablerLayout Layout { get; set; }
}
