namespace HtmlForgeX.Examples.Tables;

internal class BasicHtmlTableRowGroup
{
    public static void Create(bool openInBrowser = false)
    {
        HelpersSpectre.PrintTitle("DataTables RowGroup Demo");

        var document = new Document
        {
            Head =
            {
                Title = "DataTables RowGroup Demo",
                Author = "Przemyslaw Kłys",
                Revised = DateTime.Now,
                Description = "Showcase DataTables row grouping",
                Keywords = "datatable, rowgroup",
                Charset = "utf-8"
            }
        };

        var data = new List<dynamic>
        {
            new { Name = "John", Department = "IT", Age = 30 },
            new { Name = "Jane", Department = "HR", Age = 28 },
            new { Name = "Bob", Department = "IT", Age = 35 },
            new { Name = "Alice", Department = "HR", Age = 25 }
        };

        var table = (DataTablesTable)document.Body.Table(data, TableType.DataTables);
        table.RowGrouping(g =>
        {
            g.Enable = true;
            g.DataSrc = "Department";
        });

        document.Save("BasicDemoTablesRowGroup.html", openInBrowser);
    }
}
