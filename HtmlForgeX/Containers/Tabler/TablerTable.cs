namespace HtmlForgeX;

public class TablerTable : Table {
    public string Id;
    public List<BootStrapTableStyle> StyleList { get; set; } = new List<BootStrapTableStyle>();

    public TablerTable() : base() {
        Id = GlobalStorage.GenerateRandomId("table");
        StyleList.Add(BootStrapTableStyle.Responsive);
    }

    public TablerTable(IEnumerable<object> objects, TableType library) : base(objects, library) {
        Id = GlobalStorage.GenerateRandomId("table");
        StyleList.Add(BootStrapTableStyle.Responsive);
    }

    public TablerTable Style(BootStrapTableStyle style) {
        StyleList.Add(style);
        return this;
    }

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
