using System.ComponentModel;

namespace HtmlForgeX;

/// <summary>
/// CSS <c>display</c> property values.
/// </summary>
public enum Display {
    /// <summary>Specifies <c>display: none</c>.</summary>
    [Description("none")]
    None = 1,

    /// <summary>Specifies <c>display: inline</c>.</summary>
    [Description("inline")]
    Inline,

    /// <summary>Specifies <c>display: block</c>.</summary>
    [Description("block")]
    Block,

    /// <summary>Specifies <c>display: inline-block</c>.</summary>
    [Description("inline-block")]
    InlineBlock,

    /// <summary>Specifies <c>display: contents</c>.</summary>
    [Description("contents")]
    Contents,

    /// <summary>Specifies <c>display: flex</c>.</summary>
    [Description("flex")]
    Flex,

    /// <summary>Specifies <c>display: grid</c>.</summary>
    [Description("grid")]
    Grid,

    /// <summary>Specifies <c>display: inline-flex</c>.</summary>
    [Description("inline-flex")]
    InlineFlex,

    /// <summary>Specifies <c>display: inline-grid</c>.</summary>
    [Description("inline-grid")]
    InlineGrid,

    /// <summary>Specifies <c>display: inline-table</c>.</summary>
    [Description("inline-table")]
    InlineTable,

    /// <summary>Specifies <c>display: list-item</c>.</summary>
    [Description("list-item")]
    ListItem,

    /// <summary>Specifies <c>display: run-in</c>.</summary>
    [Description("run-in")]
    RunIn,

    /// <summary>Specifies <c>display: table</c>.</summary>
    [Description("table")]
    Table,

    /// <summary>Specifies <c>display: table-caption</c>.</summary>
    [Description("table-caption")]
    TableCaption,

    /// <summary>Specifies <c>display: table-column-group</c>.</summary>
    [Description("table-column-group")]
    TableColumnGroup,

    /// <summary>Specifies <c>display: table-header-group</c>.</summary>
    [Description("table-header-group")]
    TableHeaderGroup,

    /// <summary>Specifies <c>display: table-footer-group</c>.</summary>
    [Description("table-footer-group")]
    TableFooterGroup,

    /// <summary>Specifies <c>display: table-row-group</c>.</summary>
    [Description("table-row-group")]
    TableRowGroup,

    /// <summary>Specifies <c>display: table-cell</c>.</summary>
    [Description("table-cell")]
    TableCell,

    /// <summary>Specifies <c>display: table-column</c>.</summary>
    [Description("table-column")]
    TableColumn,

    /// <summary>Specifies <c>display: table-row</c>.</summary>
    [Description("table-row")]
    TableRow
}

/// <summary>
/// Extension methods for the <see cref="Display"/> enum.
/// </summary>
public static class DisplayExtensions {
    /// <summary>
    /// Converts the enum value to its lowercase CSS string representation.
    /// </summary>
    /// <param name="value">Display enumeration value.</param>
    /// <returns>The CSS text for the display value.</returns>
    public static string EnumToString(this Display value) {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attributes = (DescriptionAttribute[])fieldInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : value.ToString().ToLower();
    }
}
