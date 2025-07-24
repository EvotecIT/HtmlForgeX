using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Spectre.Console;

namespace HtmlForgeX.Examples.Containers;
internal class ComponentHtmlContainer02 {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Document Container Example 2");

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

        using Document document = new Document {
            Head = {
                Title = "Document Container Example 2", Author = "Przemysław Kłys", Revised = DateTime.Now
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Span("This is inside card").AddContent(" with some color").WithColor(RGBColor.Amber);
                        card.LineBreak();
                        card.Span("This is continuing after").AppendContent(" linebreak ").WithColor(RGBColor.RedDevil).AppendContent(" cool?");
                        card.LineBreak();
                        var table1 = (DataTablesTable)card.Table(data, TableType.DataTables);
                        table1.EnableOrdering(false)
                        .EnableSearching(false);
                    });
                });
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Content("Card 1").Style("background-color: red; margin-bottom: 1rem;");
                    });
                    column.Card(card => {
                        card.Content("Card 2").Style("background-color: blue; margin-bottom: 1rem;");
                    });
                });
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(4, card => {
                        card.Content("Card 3").Style("background-color: green; margin-bottom: 1rem;");
                    });
                    column.Card(4, card => {
                        card.LineBreak();
                        card.Table(data1, TableType.DataTables);
                    });
                    column.Card(4, card => {
                        card.LineBreak();
                        card.Table(data2, TableType.Tabler);
                    });
                });
            });
        });


        document.Body.Page(page => {
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Span("This is inside card").AddContent(" with some color").WithColor(RGBColor.Amber);
                        card.LineBreak();
                        card.Span("This is continuing after").AppendContent(" linebreak ").WithColor(RGBColor.RedDevil).AppendContent(" cool?");
                        card.LineBreak();
                        var table1 = (DataTablesTable)card.Table(data, TableType.DataTables);
                        table1.EnableOrdering(false)
                        .EnableSearching(false);
                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Content("Card 1").Style("background-color: red; margin-bottom: 1rem;");
                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(4, card => {
                        card.Content("Card 3").Style("background-color: green; margin-bottom: 1rem;");
                    });
                });
                // this will add a new row and push it all wide
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Span("This is inside card").AddContent(" with some color").WithColor(RGBColor.Amber);
                        card.LineBreak();
                        card.Span("This is continuing after").AppendContent(" linebreak ").WithColor(RGBColor.RedDevil).AppendContent(" cool?");
                        card.LineBreak();
                        var table1 = (DataTablesTable)card.Table(data, TableType.DataTables);
                        table1.EnableOrdering(false)
                        .EnableSearching(false);
                    });
                });
            });
        });

        document.Save("ComponentHtmlContainer02.html", openInBrowser);
    }
}
