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
        document.Head.Title = "Basic Demo Document Container 1";
        document.Head.Author = "Przemysław Kłys";
        document.Head.Revised = DateTime.Now;

        document.Head.AddMeta("description", "This is a basic demo document");
        document.Head.AddMeta("keywords", "html, c#, .net, library");

        document.Head.AddCharsetMeta("utf-8");
        // document.Head.AddHttpEquivMeta("Content-Type", "text/html; charset=utf-8");
        document.Head.AddViewportMeta("width=device-width, initial-scale=1.0");


        // Add the table to the document
        document.Body.Table(data, TableType.Tabler);

        var page = new HtmlTablerPage()
            .Add(new HtmlTablerRow()
                .Add(new HtmlTablerColumn().WithClass("col-6")
                    .Add(new HtmlTablerCard().SetContent("Card 1").WithStyle("background-color: red;"))
                    .Add(new HtmlTablerCard().SetContent("Card 2").WithStyle("background-color: blue;"))
                )
                .Add(new HtmlTablerColumn().WithClass("col-6")
                    .Add(new HtmlTablerCard().SetContent("Card 3").WithStyle("background-color: green;"))
                    .Add(new HtmlTablerCard().Table(data1, TableType.DataTables))
                )
            );


        document.Body.Add(page);

        var page1 = new HtmlTablerPage()
            .Add(new HtmlTablerCard().SetContent("Card 1").WithStyle("background-color: red;"))
            .Add(new HtmlTablerCard().SetContent("Card 2").WithStyle("background-color: blue;"))
            .Add(new HtmlTablerCard())
            .Add(new HtmlTablerCard().Table(data2, TableType.DataTables))
            .Add(new HtmlTablerCard().SetContent("Card 5"));

        document.Body.Add(page1);


        var page2 = new HtmlTablerPage().Add(page => {
            page.Add(new HtmlTablerCard().Add(card => {
                card.Content = "Card 1";
                card.Style = "background-color: red;";
            }));
            page.Add(new HtmlTablerCard().Add(card => {
                card.Content = "Card 2";
                card.Style = "background-color: blue;";
            }));
        });

        document.Body.Add(page2);


        document.Body.Page(page => {
            page.Add(new HtmlTablerCard().Add(card => {
                card.Content = "Card 10";
                card.Style = "background-color: red;";
            }));
            page.Add(new HtmlTablerCard().Add(card => {
                card.Content = "Card 20";
                card.Style = "background-color: blue;";
            }));
        });


        document.Body.Page(page => {
            page.Column(column => {
                column.Card(card => {
                    card.Add(new HtmlSpan().AddContent("This is table with DataTables").WithAlignment(FontAlignment.Center).WithColor(RGBColor.TractorRed));
                    card.Table(data1, TableType.DataTables);
                });
                column.Card(card => {
                    // one way to build span
                    card.Span("This is a table with ").Span("Tabler").WithColor(RGBColor.RedPurple);
                    card.Span(" Great?!");
                    card.LineBreak();
                    card.Span("This is a table with ").WithAlignment(FontAlignment.Center)
                        .WithColor(RGBColor.TractorRed)
                        .AppendContent("Tabler").WithBackgroundColor(RGBColor.RedPurple)
                        .AppendContent(" Great?!");
                    card.LineBreak();

                    card.Add(new HtmlSpan().AddContent("This is table with ").WithAlignment(FontAlignment.Center).WithColor(RGBColor.TractorRed)
                        .AppendContent("Tabler").WithColor(RGBColor.RedPurple));
                    card.Table(data2, TableType.Tabler);
                    card.Span("").WithBackgroundColor(RGBColor.BrickRed).Table(data2, TableType.DataTables);
                });
            });
        });

        document.Save("BasicDemoDocumentContainer01.html", openInBrowser);
    }
}
