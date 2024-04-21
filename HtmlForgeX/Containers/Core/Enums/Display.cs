using System.ComponentModel;

namespace HtmlForgeX;

public enum Display {
    [Description("none")]
    None = 1,

    [Description("inline")]
    Inline,

    [Description("block")]
    Block,

    [Description("inline-block")]
    InlineBlock,

    [Description("contents")]
    Contents,

    [Description("flex")]
    Flex,

    [Description("grid")]
    Grid,

    [Description("inline-flex")]
    InlineFlex,

    [Description("inline-grid")]
    InlineGrid,

    [Description("inline-table")]
    InlineTable,

    [Description("list-item")]
    ListItem,

    [Description("run-in")]
    RunIn,

    [Description("table")]
    Table,

    [Description("table-caption")]
    TableCaption,

    [Description("table-column-group")]
    TableColumnGroup,

    [Description("table-header-group")]
    TableHeaderGroup,

    [Description("table-footer-group")]
    TableFooterGroup,

    [Description("table-row-group")]
    TableRowGroup,

    [Description("table-cell")]
    TableCell,

    [Description("table-column")]
    TableColumn,

    [Description("table-row")]
    TableRow
}

public static class DisplayExtensions {
    public static string EnumToString(this Display value) {
        var fieldInfo = value.GetType().GetField(value.ToString());
        var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

        return attributes.Length > 0 ? attributes[0].Description : value.ToString().ToLower();
    }
}
