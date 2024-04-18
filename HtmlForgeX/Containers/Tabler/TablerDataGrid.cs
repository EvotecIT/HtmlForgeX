using System.Text;

namespace HtmlForgeX;

public class DataGrid : HtmlElement {
    public List<DataGridItem> Items { get; set; } = new List<DataGridItem>();

    public DataGrid AddItem(DataGridItem item) {
        Items.Add(item);
        return this;
    }

    public DataGridItem AddItem(string title, string content) {
        var item = new DataGridItem().Title(title).Content(content);
        Items.Add(item);
        return item;
    }

    public DataGridItem AddItem(string title, HtmlElement content) {
        var item = new DataGridItem().Title(title).Content(content);
        Items.Add(item);
        return item;
    }

    public DataGridItem Title(string title) {
        var item = new DataGridItem().Title(title);
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
