using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlForgeX.Examples.Containers;
internal class BasicHtmlContainer03 {
    public static void Demo03(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Basic Demo Document Container 3");

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
                Title = "Basic Demo Document Container 3", Author = "Przemysław Kłys", Revised = DateTime.Now
            }
        };

        document.Body.ThemeMode = ThemeMode.Dark;
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
                row.Column(8, column => {
                    column.Card(card => {
                        card.DataGrid(dataGrid => {
                            dataGrid.AddItem("Registrar", "Third Party");
                            dataGrid.AddItem("Port number", "3306");
                            dataGrid.AddItem("Creator", "Przemyslaw Klys");
                            dataGrid.AddItem("Edge network", new BadgeStatus("Active", BadgeColor.Green));
                            dataGrid.AddItem("Created", "2021-09-01");
                            dataGrid.Title("Domain Information").Content("This is the domain information");
                            dataGrid.AddItem("Expiration date", DateTime.Now.AddDays(5).ToString());
                            dataGrid.AddItem("Age", "5 days");
                            dataGrid.Title("Expiring").Content(new BadgeSpan("Soon", BadgeColor.Azure, textColor: BadgeColor.White));

                        });
                    });
                });
                row.Column(4, column => {
                    column.Card(4, card => {
                        card.DataGrid(dataGrid => {
                            dataGrid.Title("Registrar").Content(new BadgeSpan("Testing", BadgeColor.Azure, BadgeStyle.Normal, true));
                            dataGrid.Title("Pill").Content(new BadgeSpan("1", BadgeColor.Azure, BadgeStyle.Pill, false, BadgeColor.White));
                            dataGrid.Title("Outline").Content(new BadgeSpan("Testing", BadgeColor.Azure, BadgeStyle.Outline, false, BadgeColor.Cyan));
                            dataGrid.Title("Text Color").Content(new BadgeSpan("Testing", BadgeColor.Azure, BadgeStyle.Normal, true, BadgeColor.Green));
                            dataGrid.Title("Normal").Content(new BadgeSpan("Testing", BadgeColor.Azure, BadgeStyle.Normal, true));

                        });
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

        document.Save("BasicDemoDocumentContainer03.html", openInBrowser);
    }
}
