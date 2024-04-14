using System.Text;

namespace HtmlForgeX;

public class HtmlElementContainer : HtmlElement {
    /// <summary>
    /// Adds the table to the container.
    /// </summary>
    /// <param name="objects">The objects.</param>
    /// <param name="tableType">Type of the table.</param>
    /// <returns></returns>
    /// <exception cref="System.Exception">Library not supported</exception>
    public HtmlTable AddTable(IEnumerable<object> objects, TableType tableType) {
        HtmlTable table;
        if (tableType == TableType.BootstrapTable) {
            GlobalStorage.Libraries.Add(Libraries.Bootstrap);
            table = new HtmlTableBootstrap(objects, tableType);
        } else if (tableType == TableType.DataTables) {
            GlobalStorage.Libraries.Add(Libraries.Bootstrap);
            GlobalStorage.Libraries.Add(Libraries.JQuery);
            GlobalStorage.Libraries.Add(Libraries.DataTables);
            table = new HtmlTableDataTables(objects, tableType);
        } else if (tableType == TableType.Tabler) {
            GlobalStorage.Libraries.Add(Libraries.Bootstrap);
            GlobalStorage.Libraries.Add(Libraries.Tabler);
            table = new HtmlTableTabler(objects, tableType);
        } else {
            throw new Exception("Library not supported");
        }

        this.Add(table);

        return table;
    }

    /// <summary>
    /// Converts to string representation of the container.
    /// </summary>
    /// <returns>
    /// A <see cref="System.String" /> that represents this instance.
    /// </returns>
    public override string ToString() {
        StringBuilder html = new StringBuilder();
        foreach (var child in Children) {
            html.AppendLine(child.ToString());
        }
        return html.ToString();
    }

    public HtmlElementContainer Add(Action<HtmlElementContainer> config) {
        config(this);
        return this;
    }
}
