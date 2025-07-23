using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Responsive column container for arranging <see cref="TablerCard"/> elements.
/// </summary>
public class TablerColumn : Element {
    /// <summary>
    /// Gets the collection of cards contained within the column.
    /// </summary>
    public List<TablerCard> Cards { get; set; } = new List<TablerCard>();

    /// <summary>
    /// Gets or sets custom CSS classes applied to the column element.
    /// </summary>
    public string? Class { get; set; }

    /// <summary>
    /// Gets or sets the number of grid columns used for width.
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
    public new TablerCard Card(Action<TablerCard> config) {
        var card = new TablerCard();
        this.Add(card);
        config(card);
        return card;
    }

    /// <summary>
    /// Initializes or configures Card.
    /// </summary>
    public new TablerCard Card(int count, Action<TablerCard> config) {
        var card = new TablerCard(count);
        this.Add(card);
        config(card);
        return card;
    }

    /// <summary>
    /// Adds a <see cref="TablerCardEnhanced"/> to the column using fluent configuration.
    /// </summary>
    /// <param name="config">Action that configures the card.</param>
    /// <returns>The created <see cref="TablerCardEnhanced"/>.</returns>
    public TablerCardEnhanced CardEnhanced(Action<TablerCardEnhanced> config) {
        var card = new TablerCardEnhanced();
        this.Add(card);
        config(card);
        return card;
    }

    /// <summary>
    /// Add a DataGrid directly to the column using the enhanced TablerDataGrid component
    /// </summary>
    public new TablerDataGrid DataGrid(Action<TablerDataGrid> dataGridConfig) {
        var dataGrid = new TablerDataGrid();
        dataGridConfig(dataGrid);
        this.Add(dataGrid);
        return dataGrid;
    }
}