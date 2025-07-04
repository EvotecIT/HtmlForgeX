namespace HtmlForgeX;

/// <summary>
/// Defines a row in a Tabler Page Layout.
/// When using the TablerRow, you can specify the row type.
/// By default, the row type is set to Default, however when dealing with Page Layouts you usually should have both Deck and Cards.
/// But for other purposes of layout such as within Card you should use the Default row type
/// </summary>
/// <seealso cref="HtmlForgeX.Element" />
public class TablerRow : Element {
    private HashSet<TablerRowType> RowTypes { get; set; } = new HashSet<TablerRowType>();

    public TablerRow(params TablerRowType[] rowTypes) {
        RowTypes.Add(TablerRowType.Default);
        foreach (var rowType in rowTypes) {
            RowTypes.Add(rowType);
        }
    }

    public override string ToString() {
        HtmlTag rowTag = new HtmlTag("div");
        foreach (var rowType in RowTypes) {
            rowTag.Class(rowType.EnumToString());
        }
        foreach (var child in Children) {
            rowTag.Value(child);
        }
        return rowTag.ToString();
    }

    public TablerColumn Column(Action<TablerColumn> config) {
        var column = new TablerColumn();
        config(column);
        this.Add(column);
        return column;
    }

    public TablerColumn Column(TablerColumnNumber number, Action<TablerColumn> config) {
        var column = new TablerColumn(number);
        config(column);
        this.Add(column);
        return column;
    }
}