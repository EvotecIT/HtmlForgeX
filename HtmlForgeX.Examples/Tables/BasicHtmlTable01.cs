namespace HtmlForgeX.Examples.Tables;
internal class BasicHtmlTable01 {

    public static void Demo1(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Basic Demo Document with Tables 1");

        HtmlDocument document = new HtmlDocument();
        document.Head.Title = "Basic Demo Document with Tables";
        document.Head.Author = "Przemysław Kłys";
        document.Head.Revised = DateTime.Now;
        document.Head.Description = "This is a basic demo document with tables in bootstrap";
        document.Head.Keywords = "keywords, html, c#, .net, library";
        document.Head.Charset = "utf-8";


        HtmlTable table = new HtmlTable();
        table.AddHeaders("Header 1", "Header 2", "Header 3")
            .AddRows(
                new List<string> { "Row 1 Cell 1", "Row 1 Cell 2", "Row 1 Cell 3" },
                new List<string> { "Row 2 Cell 1", "Row 2 Cell 2", "Row 2 Cell 3" }
            );

        document.Body.Add(table);

        // get processes from the system
        var processes = System.Diagnostics.Process.GetProcesses().ToList().GetRange(1, 5);

        document.UseLibrary(Libraries.Bootstrap);

        document.Body.AddTable(processes, Libraries.Bootstrap);

        document.Save("BasicDemoDocumentWithTables1.html", openInBrowser);
    }

}
