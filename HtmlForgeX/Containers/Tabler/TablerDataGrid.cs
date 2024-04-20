using System.Text;

namespace HtmlForgeX;

public class TablerDataGrid : Element {
    public List<TablerDataGridItem> Items { get; set; } = new List<TablerDataGridItem>();

    public TablerDataGrid AddItem(TablerDataGridItem item) {
        Items.Add(item);
        return this;
    }

    public TablerDataGridItem AddItem(string title, string content) {
        var item = new TablerDataGridItem().Title(title).Content(content);
        Items.Add(item);
        return item;
    }

    public TablerDataGridItem AddItem(string title, Element content) {
        var item = new TablerDataGridItem().Title(title).Content(content);
        Items.Add(item);
        return item;
    }

    public TablerDataGridItem Title(string title) {
        var item = new TablerDataGridItem().Title(title);
        Items.Add(item);
        return item;
    }

    public override string ToString() {
        StringBuilder html = new StringBuilder("<div class=\"datagrid\">");

        foreach (var item in Items) {
            html.Append(item.ToString());
        }

        html.Append("</div>");

        return html.ToString();
    }
}
