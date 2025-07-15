namespace HtmlForgeX;

/// <summary>
/// Specialized table control using Tabler and Bootstrap styles.
/// </summary>
public class TablerTable : Table {
    /// <summary>
    /// Unique identifier of the table element.
    /// </summary>
    public string Id;

    /// <summary>
    /// Collection of Bootstrap style flags applied to the table.
    /// </summary>
    public List<BootStrapTableStyle> StyleList { get; set; } = new List<BootStrapTableStyle>();

    /// <summary>
    /// Initializes or configures TablerTable.
    /// </summary>
    public TablerTable() : base() {
        Id = GlobalStorage.GenerateRandomId("table");
        StyleList.Add(BootStrapTableStyle.Responsive);
    }

    /// <summary>
    /// Initializes or configures TablerTable.
    /// </summary>
    public TablerTable(IEnumerable<object> objects, TableType library) : base(objects, library) {
        Id = GlobalStorage.GenerateRandomId("table");
        StyleList.Add(BootStrapTableStyle.Responsive);
    }

    /// <summary>
    /// Initializes or configures Style.
    /// </summary>
    public TablerTable Style(BootStrapTableStyle style) {
        StyleList.Add(style);
        return this;
    }

    /// <summary>
    /// Initializes or configures BuildTable.
    /// </summary>
    public override string BuildTable() {
        string tableInside = base.BuildTable();
        string classNames = StyleList.BuildTableStyles();
        var tableTag = new HtmlTag("table")
            .Id(Id)
            .Class(classNames)
            .Value(tableInside);
        return tableTag.ToString();
    }
}