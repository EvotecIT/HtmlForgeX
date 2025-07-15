namespace HtmlForgeX.Examples.Tables;

/// <summary>
/// Demonstration of DataTables extension methods for quick setup
/// </summary>
internal class DataTablesExtensionsDemo
{
    public static void Create(bool openInBrowser = false)
    {
        HelpersSpectre.PrintTitle("🚀 DataTables Extensions Demo");

        var document = new Document
        {
            Head = {
                Title = "DataTables Extensions Demo",
                Author = "HtmlForgeX Team",
                Revised = DateTime.Now,
                Description = "Quick setup methods for common DataTables configurations",
                Keywords = "datatable, extensions, quick-setup",
                Charset = "utf-8"
            }
        };

        // Sample data
        var salesData = GenerateSalesData();

        document.Body.Page(page =>
        {
            page.Layout = TablerLayout.Fluid;

            // Header
            page.Add(new HeaderLevel(HeaderLevelTag.H1, "🚀 DataTables Extension Methods"));
            page.Text("Quick setup methods for common DataTables configurations")
                .Style(TablerTextStyle.Muted).Weight(TablerFontWeight.Medium);

            // Quick Setup Example
            page.Divider("1. Quick Setup - Perfect for Simple Tables");
            page.Text("One-liner setup with sensible defaults:");

            page.Table(salesData.Take(10), TableType.DataTables, table =>
            {
                var dataTable = (DataTablesTable)table;
                dataTable.QuickSetup(pageLength: 5, enableExports: true, enableSearch: true, responsive: true);
            });

            // Enterprise Setup Example
            page.Divider("2. Enterprise Setup - Full-Featured Business Tables");
            page.Text("Complete enterprise configuration with all advanced features:");

            page.Table(salesData, TableType.DataTables, table =>
            {
                var dataTable = (DataTablesTable)table;
                dataTable.EnterpriseSetup(pageLength: 15, enableRowGrouping: true, groupByColumn: 2); // Group by Region
            });

            // Mobile Optimized Example
            page.Divider("3. Mobile Optimized - Perfect for Mobile Devices");
            page.Text("Optimized for mobile viewing with simplified controls:");

            page.Table(salesData.Take(8), TableType.DataTables, table =>
            {
                var dataTable = (DataTablesTable)table;
                dataTable.MobileOptimized(pageLength: 4);
            });

            // Dashboard Setup Example
            page.Divider("4. Dashboard Setup - Great for Summary Views");
            page.Text("Clean dashboard layout with controlled height:");

            page.Table(salesData.Take(12), TableType.DataTables, table =>
            {
                var dataTable = (DataTablesTable)table;
                dataTable.DashboardSetup(enableExports: true, scrollHeight: "250px");
            });

            // Report Setup Example
            page.Divider("5. Report Setup - Comprehensive Reporting");
            page.Text("Full reporting capabilities with extensive export options:");

            page.Table(salesData, TableType.DataTables, table =>
            {
                var dataTable = (DataTablesTable)table;
                dataTable.ReportSetup(reportTitle: "Sales Performance Report", filename: "sales_report_2024");
            });

            // Analytics Setup Example
            page.Divider("6. Analytics Setup - Advanced Data Analysis");
            page.Text("Analytics-focused with search panes and advanced filtering:");

            page.Table(salesData, TableType.DataTables, table =>
            {
                var dataTable = (DataTablesTable)table;
                dataTable.AnalyticsSetup(groupByColumn: 2, searchPanesLayout: "columns-2"); // Group by Region
            });

            // Performance Setup Example
            page.Divider("7. Performance Setup - Optimized for Large Datasets");
            page.Text("High-performance configuration for handling large amounts of data:");

            page.Table(salesData, TableType.DataTables, table =>
            {
                var dataTable = (DataTablesTable)table;
                dataTable.PerformanceSetup(scrollHeight: "350px", serverSide: false);
            });

            // Code Examples
            page.Divider("💻 Extension Method Examples");

            page.Row(row =>
            {
                row.Column(TablerColumnNumber.Six, column =>
                {
                    column.Card(card =>
                    {
                        card.Header(header =>
                        {
                            header.Title("Quick Setup").Subtitle("One-liner configuration");
                        });
                        card.Body(body =>
                        {
                            body.Text("// Simple one-liner setup")
                                .Style(TablerTextStyle.Monospace).Style(TablerTextStyle.Muted);
                            body.Text("var table = (DataTablesTable)document.Body")
                                .Style(TablerTextStyle.Monospace);
                            body.Text("    .Table(data, TableType.DataTables);")
                                .Style(TablerTextStyle.Monospace);
                            body.Text("table.QuickSetup();")
                                .Style(TablerTextStyle.Monospace).Weight(TablerFontWeight.Bold);
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, column =>
                {
                    column.Card(card =>
                    {
                        card.Header(header =>
                        {
                            header.Title("Enterprise Setup").Subtitle("Full-featured configuration");
                        });
                        card.Body(body =>
                        {
                            body.Text("// Enterprise-grade setup")
                                .Style(TablerTextStyle.Monospace).Style(TablerTextStyle.Muted);
                            body.Text("table.EnterpriseSetup(")
                                .Style(TablerTextStyle.Monospace).Weight(TablerFontWeight.Bold);
                            body.Text("    pageLength: 25,")
                                .Style(TablerTextStyle.Monospace);
                            body.Text("    enableRowGrouping: true,")
                                .Style(TablerTextStyle.Monospace);
                            body.Text("    groupByColumn: 2);")
                                .Style(TablerTextStyle.Monospace);
                        });
                    });
                });
            });

            page.Row(row =>
            {
                row.Column(TablerColumnNumber.Six, column =>
                {
                    column.Card(card =>
                    {
                        card.Header(header =>
                        {
                            header.Title("Mobile Optimized").Subtitle("Perfect for mobile devices");
                        });
                        card.Body(body =>
                        {
                            body.Text("// Mobile-friendly setup")
                                .Style(TablerTextStyle.Monospace).Style(TablerTextStyle.Muted);
                            body.Text("table.MobileOptimized(pageLength: 5);")
                                .Style(TablerTextStyle.Monospace).Weight(TablerFontWeight.Bold);
                            body.LineBreak();
                            body.Text("✓ Simple pagination")
                                .Style(TablerTextStyle.Success);
                            body.Text("✓ Horizontal scrolling")
                                .Style(TablerTextStyle.Success);
                            body.Text("✓ Responsive design")
                                .Style(TablerTextStyle.Success);
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, column =>
                {
                    column.Card(card =>
                    {
                        card.Header(header =>
                        {
                            header.Title("Report Setup").Subtitle("Comprehensive reporting");
                        });
                        card.Body(body =>
                        {
                            body.Text("// Full reporting capabilities")
                                .Style(TablerTextStyle.Monospace).Style(TablerTextStyle.Muted);
                            body.Text("table.ReportSetup(")
                                .Style(TablerTextStyle.Monospace).Weight(TablerFontWeight.Bold);
                            body.Text("    reportTitle: \"Sales Report\",")
                                .Style(TablerTextStyle.Monospace);
                            body.Text("    filename: \"sales_2024\");")
                                .Style(TablerTextStyle.Monospace);
                            body.LineBreak();
                            body.Text("✓ Excel, CSV, PDF exports")
                                .Style(TablerTextStyle.Success);
                        });
                    });
                });
            });

            // Benefits Summary
            page.Divider("✨ Extension Method Benefits");

            page.Row(row =>
            {
                row.Column(TablerColumnNumber.Twelve, column =>
                {
                    column.Card(card =>
                    {
                        card.Header(header =>
                        {
                            header.Title("🎯 Why Use Extension Methods?").Subtitle("Simplified DataTables configuration");
                            header.Avatar(avatar =>
                            {
                                avatar.Icon(TablerIconType.Rocket)
                                      .BackgroundColor(RGBColor.Blue, RGBColor.White)
                                      .Size(AvatarSize.LG);
                            });
                        });
                        card.Body(body =>
                        {
                            body.AddList(list =>
                            {
                                list.Style(TablerCardListStyle.Unstyled);
                                list.WithItems(items =>
                                {
                                    items.CheckItem("⚡ Quick Setup: One-liner configuration for common scenarios", true);
                                    items.CheckItem("🏢 Enterprise Ready: Full-featured setup with all advanced options", true);
                                    items.CheckItem("📱 Mobile Optimized: Perfect configuration for mobile devices", true);
                                    items.CheckItem("📊 Dashboard Friendly: Clean layouts for summary views", true);
                                    items.CheckItem("📋 Report Ready: Comprehensive export and formatting options", true);
                                    items.CheckItem("📈 Analytics Focused: Advanced search and grouping capabilities", true);
                                    items.CheckItem("🚀 Performance Tuned: Optimized for large datasets", true);
                                    items.CheckItem("🔧 Customizable: All methods accept parameters for fine-tuning", true);
                                });
                            });

                            body.Text("🎉 Choose the right extension method for your use case and get a perfectly configured DataTable in seconds!")
                                .Weight(TablerFontWeight.Bold).Style(TablerTextStyle.Primary);
                        });
                    });
                });
            });
        });

        document.Save("DataTablesExtensionsDemo.html", openInBrowser);

        Console.WriteLine("🚀 DataTables Extensions Demo created successfully!");
        Console.WriteLine("⚡ Extension methods demonstrated:");
        Console.WriteLine("   • QuickSetup() - Simple one-liner configuration");
        Console.WriteLine("   • EnterpriseSetup() - Full-featured business tables");
        Console.WriteLine("   • MobileOptimized() - Perfect for mobile devices");
        Console.WriteLine("   • DashboardSetup() - Clean dashboard layouts");
        Console.WriteLine("   • ReportSetup() - Comprehensive reporting");
        Console.WriteLine("   • AnalyticsSetup() - Advanced data analysis");
        Console.WriteLine("   • PerformanceSetup() - Optimized for large datasets");
        Console.WriteLine("");
        Console.WriteLine("🎯 Benefits:");
        Console.WriteLine("   ✓ Reduced configuration code");
        Console.WriteLine("   ✓ Consistent setups across projects");
        Console.WriteLine("   ✓ Best practices built-in");
        Console.WriteLine("   ✓ Easy to customize and extend");
    }

    private static List<dynamic> GenerateSalesData()
    {
        var random = new Random();
        var regions = new[] { "North America", "Europe", "Asia Pacific", "Latin America", "Middle East" };
        var products = new[] { "Software License", "Support Contract", "Training", "Consulting", "Hardware" };
        var salespeople = new[] { "Alice Johnson", "Bob Smith", "Carol Davis", "David Wilson", "Eva Brown", "Frank Miller" };

        return Enumerable.Range(1, 30).Select(i => new
        {
            Id = i,
            SalesPerson = salespeople[random.Next(salespeople.Length)],
            Region = regions[random.Next(regions.Length)],
            Product = products[random.Next(products.Length)],
            Amount = random.Next(5000, 50000),
            Date = DateTime.Now.AddDays(-random.Next(1, 365)),
            Quarter = $"Q{random.Next(1, 5)} 2024",
            Status = random.Next(100) > 20 ? "Closed Won" : "Closed Lost",
            Commission = Math.Round(random.NextDouble() * 5000 + 500, 2)
        }).Cast<dynamic>().ToList();
    }
}