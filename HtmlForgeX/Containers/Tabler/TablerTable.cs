namespace HtmlForgeX;

public class TablerTable : Table {
    public string Id;
    public TablerTable(IEnumerable<object> objects, TableType library) : base(objects, library) {

    }

    public override string BuildTable() {
        string tableInside = base.BuildTable();
        string classNames = "table";
        var tableTag = new HtmlTag("table")
            .Id(Id)
            .Class(classNames)
            .Value(tableInside);
        return tableTag.ToString();
    }
}
