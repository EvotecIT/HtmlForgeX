namespace HtmlForgeX;

/// <summary>
/// Defines the type of row in a Tabler Page Layout.
/// </summary>
public enum TablerRowType {
    Default,
    Deck,
    Cards
}

/// <summary>
/// Extension helpers for <see cref="TablerRowType"/> values.
/// </summary>
public static class TablerRowTypeExtensions {
    /// <summary>
    /// Converts the row type value to its Tabler CSS class.
    /// </summary>
    /// <param name="rowType">Row layout option.</param>
    /// <returns>CSS class string.</returns>
    public static string EnumToString(this TablerRowType rowType) {
        return rowType switch {
            TablerRowType.Default => "row",
            TablerRowType.Deck => "row-deck",
            TablerRowType.Cards => "row-cards",
            _ => throw new ArgumentOutOfRangeException(nameof(rowType), rowType, null)
        };
    }
}