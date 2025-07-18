using System;
using System.Collections.Generic;

namespace HtmlForgeX.Examples.Tables;

/// <summary>
/// Example showcasing how complex condition groups and custom operators can be
/// declared using the fluent SearchBuilder builder.
/// </summary>
internal class DataTablesInteractiveFilteringDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("🔍 DataTables Interactive Filtering");

        var sales = new List<dynamic> {
            new { Product = "Laptop", Category = "Electronics", Amount = 1500, Region = "Europe" },
            new { Product = "Phone", Category = "Electronics", Amount = 800, Region = "North America" },
            new { Product = "Desk", Category = "Furniture", Amount = 300, Region = "Europe" },
            new { Product = "Chair", Category = "Furniture", Amount = 120, Region = "Asia" },
            new { Product = "Camera", Category = "Electronics", Amount = 600, Region = "Europe" }
        };

        var document = new Document {
            Head = {
                Title = "DataTables Interactive Filtering",
                Author = "HtmlForgeX Team",
                Description = "Demo with SearchBuilder condition groups and custom operators",
                Keywords = "datatable, searchbuilder, interactive filtering"
            }
        };

        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;
            page.H1("Interactive Filtering");
            page.Text("SearchBuilder with predefined groups and a custom operator:");
            page.DataTable(sales, table => {
                table.ConfigureSearchBuilder(sb => sb
                    .Group(g => g
                        .Logic(DataTablesSearchLogic.Or)
                        .Criterion("Region", DataTablesSearchCondition.Equals, "Europe")
                        .Criterion("Amount", DataTablesSearchCondition.GreaterThan, 1000))
                    .CustomOperator(DataTablesBuiltInOperator.StartsWith)
                    .CustomOperator(DataTablesBuiltInOperator.Between)
                );
            });
        });

        document.Save("DataTablesInteractiveFilteringDemo.html", openInBrowser);
    }
}
