using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlForgeX.Examples.Containers;

internal class BasicHtmlContainer01 {
    public static void Demo01(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Basic Demo Document Container 1");

        // Create a list of simple objects
        var data = new List<dynamic> {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
            new { Name = "Bob", Age = 35, Occupation = "Architect" }
        };

        var data1 = new List<dynamic> {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
            new { Name = "Bob", Age = 35, Occupation = "Architect" },
            new { Name = "John", Age = 30, Occupation = "Engineer" },
        };

        var data2 = new List<dynamic> {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
        };

        HtmlDocument document = new HtmlDocument();
        document.Head.Title = "Basic Demo Document 1";
        document.Head.Author = "Przemysław Kłys";
        document.Head.Revised = DateTime.Now;

        document.Head.AddMeta("description", "This is a basic demo document");
        document.Head.AddMeta("keywords", "html, c#, .net, library");

        document.Head.AddCharsetMeta("utf-8");
        // document.Head.AddHttpEquivMeta("Content-Type", "text/html; charset=utf-8");
        document.Head.AddViewportMeta("width=device-width, initial-scale=1.0");


        // Add the table to the document
        document.Body.AddTable(data, TableType.Tabler);

        var page = new HtmlPage()
            .Add(new HtmlRow()
                .Add(new HtmlColumn().WithClass("col-6")
                    .Add(new HtmlCard().AddContent("Card 1").WithStyle("background-color: red;"))
                    .Add(new HtmlCard().AddContent("Card 2").WithStyle("background-color: blue;"))
                )
                .Add(new HtmlColumn().WithClass("col-6")
                    .Add(new HtmlCard().AddContent("Card 3").WithStyle("background-color: green;"))
                    .Add(new HtmlCard().AddTable(data1, TableType.DataTables))
                )
            );


        document.Body.Add(page.ToString());

        var page1 = new HtmlPage()
            .Add(new HtmlCard().AddContent("Card 1").WithStyle("background-color: red;"))
            .Add(new HtmlCard().AddContent("Card 2").WithStyle("background-color: blue;"))
            .Add(new HtmlCard())
            .Add(new HtmlCard().AddTable(data2, TableType.DataTables))
            .Add(new HtmlCard().AddContent("Card 5"));

        document.Body.Add(page1.ToString());





        document.Save("BasicDemoDocumentContainer01.html", openInBrowser);
    }
}
