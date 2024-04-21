namespace HtmlForgeX;

/// <summary>
/// Defines the type of row in a Tabler Page Layout.
/// </summary>
public class TablerRowType {
    private string Type { get; }

    private TablerRowType(string type) {
        Type = type;
    }

    public override string ToString() {
        return Type;
    }

    public static TablerRowType Default => new TablerRowType("row");
    public static TablerRowType Deck => new TablerRowType("row-deck");
    public static TablerRowType Cards => new TablerRowType("row-cards");
}