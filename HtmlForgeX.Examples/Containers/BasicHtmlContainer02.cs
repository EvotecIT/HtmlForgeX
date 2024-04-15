using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Spectre.Console;

namespace HtmlForgeX.Examples.Containers;
internal class BasicHtmlContainer02 {
    public static void Demo02(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Basic Demo Document Container 2");

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

        HtmlDocument document = new HtmlDocument {
            Head = {
                Title = "Basic Demo Document Container 2", Author = "Przemysław Kłys", Revised = DateTime.Now
            }
        };

        document.Body.Page(page => {
            page.Rows(row => {
                row.Column(12, column => {
                    column.Card(card => {
                        card.Span("This is inside card").AddContent(" with some color").WithColor(RGBColor.Amber);
                        card.LineBreak();
                        card.Span("This is continuing after").AppendContent(" linebreak ").WithColor(RGBColor.RedDevil).AppendContent(" cool?");
                        var table1 = (HtmlTableDataTables)card.Table(data, TableType.DataTables);
                        table1.EnableOrdering = false;
                        table1.EnableSearching = false;
                    });
                });
                row.Column(12, column => {
                    column.Card(card => {
                        card.SetContent("Card 1").WithStyle("background-color: red;");
                    });
                    column.Card(card => {
                        card.SetContent("Card 2").WithStyle("background-color: blue;");
                    });
                });
                row.Column(12, column => {
                    column.Card(4, card => {
                        card.SetContent("Card 3").WithStyle("background-color: green;");
                    });
                    column.Card(4, card => {
                        card.Table(data1, TableType.DataTables);
                    });
                    column.Card(4, card => {
                        card.Table(data2, TableType.Tabler);
                    });
                });
            });
        });


        document.Body.Page(page => {
            page.Rows(row => {
                row.Column(4, column => {
                    column.Card(card => {
                        card.Span("This is inside card").AddContent(" with some color").WithColor(RGBColor.Amber);
                        card.LineBreak();
                        card.Span("This is continuing after").AppendContent(" linebreak ").WithColor(RGBColor.RedDevil).AppendContent(" cool?");
                        var table1 = (HtmlTableDataTables)card.Table(data, TableType.DataTables);
                        table1.EnableOrdering = false;
                        table1.EnableSearching = false;
                    });
                });
                row.Column(4, column => {
                    column.Card(card => {
                        card.SetContent("Card 1").WithStyle("background-color: red;");
                    });
                });
                row.Column(4, column => {
                    column.Card(4, card => {
                        card.SetContent("Card 3").WithStyle("background-color: green;");
                    });
                });
                // this will add a new row and push it all wide
                row.Column(12, column => {
                    column.Card(card => {
                        card.Span("This is inside card").AddContent(" with some color").WithColor(RGBColor.Amber);
                        card.LineBreak();
                        card.Span("This is continuing after").AppendContent(" linebreak ").WithColor(RGBColor.RedDevil).AppendContent(" cool?");
                        var table1 = (HtmlTableDataTables)card.Table(data, TableType.DataTables);
                        table1.EnableOrdering = false;
                        table1.EnableSearching = false;
                    });
                });
            });
        });

        document.Save("BasicDemoDocumentContainer02.html", openInBrowser);
    }
}
