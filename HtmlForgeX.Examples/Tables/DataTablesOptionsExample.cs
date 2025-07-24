namespace HtmlForgeX.Examples.Tables;

internal class DataTablesOptionsExample {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("DataTables Options Demo");

        using Document document = new Document {
            Head = {
                Title = "DataTables Options Demo",
                Author = "Przemysław Kłys",
                Revised = DateTime.Now,
                Description = "Showcase DataTables options",
                Keywords = "datatable, options",
                Charset = "utf-8"
            }
        };

        // Create a list of simple objects
        var data = new List<dynamic> {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
            new { Name = "Bob", Age = 35, Occupation = "Architect" }
        };

        var table = (DataTablesTable)document.Body.Table(data, TableType.DataTables);
        table.Style(BootStrapTableStyle.Striped)
             .Style(BootStrapTableStyle.Hover)
             .Configure(o =>
             {
                 o.PageLength = 10;
                 o.LengthMenu = new[] { 5, 10, 25, 50 };
                 o.StateSave = true;
                 o.Language = new DataTablesLanguage {
                     Search = "Filter:",
                     LengthMenu = "Show _MENU_ entries",
                     Paginate = new DataTablesPaginate {
                         First = "First",
                         Last = "Last",
                         Next = "Next",
                         Previous = "Prev"
                     }
                 };
             });

        document.Save("DataTablesOptionsExample.html", openInBrowser);
    }
}
