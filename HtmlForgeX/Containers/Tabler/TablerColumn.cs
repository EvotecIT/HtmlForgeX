using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Responsive column container for arranging <see cref="TablerCard"/> elements.
/// </summary>
public class TablerColumn : Element {
    /// <summary>
    /// Collection of cards contained in this column.
    /// </summary>
    public List<TablerCard> Cards { get; set; } = new List<TablerCard>();

    /// <summary>
    /// CSS class applied to the column div.
    /// </summary>
    public string? Class { get; set; }

    /// <summary>
    /// Number of columns for legacy compatibility.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Initializes or configures TablerColumn.
    /// </summary>
    public TablerColumn() {
        Class = "col";
    }

    /// <summary>
    /// Initializes or configures TablerColumn.
    /// </summary>
    public TablerColumn(TablerColumnNumber columnNumber) {
        Class = columnNumber.EnumToString();
    }

    /// <summary>
    /// Initializes or configures WithClass.
    /// </summary>
    public TablerColumn WithClass(string className) {
        Class = className;
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        //Console.WriteLine("Generating HtmlColumn...");
        var childrenHtml = string.Join("", Children.WhereNotNull().Select(child => child.ToString()));
        var result = $"<div class=\"{Class}\">{childrenHtml}</div>";
        //Console.WriteLine("Generated HtmlColumn: " + result);
        return result;
    }

    /// <summary>
    /// Initializes or configures Add.
    /// </summary>
    public TablerColumn Add(Action<TablerColumn> config) {
        config(this);
        return this;
    }

    /// <summary>
    /// Initializes or configures Card.
    /// </summary>
    public TablerCard Card(Action<TablerCard> config) {
        var card = new TablerCard();
        config(card);
        this.Add(card);
        return card;
    }

    /// <summary>
    /// Initializes or configures Card.
    /// </summary>
    public new TablerCard Card(int count, Action<TablerCard> config) {
        var card = new TablerCard(count);
        config(card);
        this.Add(card);
        return card;
    }

    /// <summary>
    /// Add a DataGrid directly to the column using the enhanced TablerDataGrid component
    /// </summary>
    public TablerDataGrid DataGrid(Action<TablerDataGrid> dataGridConfig) {
        var dataGrid = new TablerDataGrid();
        dataGridConfig(dataGrid);
        this.Add(dataGrid);
        return dataGrid;
    }
}