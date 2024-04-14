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

        var page = new HtmlTablerPage()
            .Add(new HtmlTablerRow()
                .Add(new HtmlTablerColumn().WithClass("col-6")
                    .Add(new HtmlTablerCard().AddContent("Card 1").WithStyle("background-color: red;"))
                    .Add(new HtmlTablerCard().AddContent("Card 2").WithStyle("background-color: blue;"))
                )
                .Add(new HtmlTablerColumn().WithClass("col-6")
                    .Add(new HtmlTablerCard().AddContent("Card 3").WithStyle("background-color: green;"))
                    .Add(new HtmlTablerCard().AddTable(data1, TableType.DataTables))
                )
            );


        document.Body.Add(page);

        var page1 = new HtmlTablerPage()
            .Add(new HtmlTablerCard().AddContent("Card 1").WithStyle("background-color: red;"))
            .Add(new HtmlTablerCard().AddContent("Card 2").WithStyle("background-color: blue;"))
            .Add(new HtmlTablerCard())
            .Add(new HtmlTablerCard().AddTable(data2, TableType.DataTables))
            .Add(new HtmlTablerCard().AddContent("Card 5"));

        document.Body.Add(page1);


        var page2 = new HtmlTablerPage().Add(page => {
            page.Add(new HtmlTablerCard().AddContent(card => {
                card.Content = "Card 1";
                card.Style = "background-color: red;";
            }));
            page.Add(new HtmlTablerCard().AddContent(card => {
                card.Content = "Card 2";
                card.Style = "background-color: blue;";
            }));
        });

        document.Body.Add(page2);


        document.Body.Page(page => {
            page.Add(new HtmlTablerCard().AddContent(card => {
                card.Content = "Card 10";
                card.Style = "background-color: red;";
            }));
            page.Add(new HtmlTablerCard().AddContent(card => {
                card.Content = "Card 20";
                card.Style = "background-color: blue;";
            }));
        });


        document.Body.Page(page => {
            page.Column(column => {
                column.Card(card => {
                    card.Add(new HtmlSpan().AddContent("This is table with DataTables").WithAlignment(FontAlignment.Center).WithColor(RGBColor.TractorRed)
                    );
                    card.AddTable(data1, TableType.DataTables);
                });
                column.Card(card => {
                    card.Add(new HtmlSpan().AddContent("This is table with ").WithAlignment(FontAlignment.Center).WithColor(RGBColor.TractorRed)
                                        .AddContent("Tabler").WithColor(RGBColor.RedPurple));
                    card.AddTable(data2, TableType.Tabler);
                });
            });
        });

        document.Save("BasicDemoDocumentContainer01.html", openInBrowser);
    }
}
