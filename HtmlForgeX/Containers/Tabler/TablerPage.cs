namespace HtmlForgeX;

public class TablerPage : Element {
    public TablerPage() {
        // Libraries will be registered via RegisterLibraries method
    }

    /// <summary>
    /// Registers the required libraries for TablerPage.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.Configuration.Libraries.TryAdd(Libraries.Bootstrap, 0);
        Document?.Configuration.Libraries.TryAdd(Libraries.Tabler, 0);
    }

    public new TablerRow Row(Action<TablerRow> config) {
        var row = new TablerRow(TablerRowType.Cards, TablerRowType.Deck);
        config(row);
        this.Add(row);
        return row;
    }

    public override string ToString() {
        //Console.WriteLine("Generating HtmlPage...");
        var layoutClass = Layout != TablerLayout.Default ? $" layout-{Layout.ToString().ToLower()}" : "";
        var pageWrapper = new HtmlTag("div").Class($"page-wrapper{layoutClass}");

        var pageBody = new HtmlTag("div").Class("page-body");
        pageWrapper.Value(pageBody);

        var container = new HtmlTag("div").Class("container-xl");
        foreach (var child in Children) {
            container.Value(child);
        }
        pageBody.Value(container);

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
