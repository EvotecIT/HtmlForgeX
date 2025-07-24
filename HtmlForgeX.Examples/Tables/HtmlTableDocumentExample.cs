namespace HtmlForgeX.Examples.Tables;

internal class HtmlTableDocumentExample {

    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Basic Demo Document with Tables 1");

        // Create a new document with the title and author
        using Document document = new Document {
            Head = {
                Title = "Basic Demo Document with Tables 1",
                Author = "Przemysław Kłys",
                Revised = DateTime.Now,
                Description = "This is a basic demo document with tables in bootstrap",
                Keywords = "keywords, html, c#, .net, library",
                Charset = "utf-8"
            }
        };

        // Create a list of simple objects
        var data = new List<dynamic> {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
            new { Name = "Bob", Age = 35, Occupation = "Architect" }
        };

        // Add the table to the document
        document.Body.Table(data, TableType.Tabler);

        // Add the table to the document again using DataTables
        document.Body.Table(data, TableType.DataTables);

        // Get drive information
        var drives = System.IO.DriveInfo.GetDrives().Select(d => new {
            Name = d.Name,
            Type = d.DriveType,
            Format = d.IsReady ? d.DriveFormat : "N/A",
            TotalSize = d.IsReady ? d.TotalSize / (1024 * 1024 * 1024) + " GB" : "N/A",
            AvailableSpace = d.IsReady ? d.AvailableFreeSpace / (1024 * 1024 * 1024) + " GB" : "N/A"
        }).ToList();

        // Add the drive information to the document
        var table3 = document.Body.Table(drives, TableType.Tabler);

        // Add the drive information to the document again using DataTables
        var table4 = (DataTablesTable)document.Body.Table(drives, TableType.DataTables);
        table4.Style(BootStrapTableStyle.Hover).Style(BootStrapTableStyle.Striped);
        table4.EnablePaging()
              .DisableSearching()
              .EnableOrdering()
              .Scrolling(scrollX: true);
        table4.Configure(o =>
        {
            o.PageLength = 25;
            o.StateSave = true;
        });

        var table5 = (BootstrapTable)document.Body.Table(drives, TableType.BootstrapTable);
        table5.Style(BootStrapTableStyle.Striped).Style(BootStrapTableStyle.Hover);
        table5.Style(BootStrapTableStyle.Responsive);
        document.Save("HtmlTableDocumentExample.html", openInBrowser);
    }

}
