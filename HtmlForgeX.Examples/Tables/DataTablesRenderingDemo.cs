using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlForgeX.Examples.Tables;

/// <summary>
/// Demonstrates DataTables rendering modes and global configuration
/// </summary>
internal class DataTablesRenderingDemo
{
    public static void Create(bool openInBrowser = false)
    {
        HelpersSpectre.PrintTitle("🚀 DataTables Rendering Modes Demo");

        // Create sample datasets of different sizes
        var smallDataset = GenerateProducts(50);
        var mediumDataset = GenerateProducts(500);
        var largeDataset = GenerateProducts(2000);

        var document = new Document
        {
            Head = {
                Title = "DataTables Rendering Modes Demo",
                Author = "HtmlForgeX Team",
                Description = "Demonstrating HTML vs JavaScript rendering modes for optimal performance",
                Keywords = "datatable, rendering, performance, javascript, html"
            }
        };

        // Configure global DataTables settings
        document.Configuration.DataTables.DefaultRenderMode = DataTablesRenderMode.Auto;
        document.Configuration.DataTables.AutoModeThreshold = 1000;
        document.Configuration.DataTables.EnableDeferredRendering = true;
        document.Configuration.DataTables.EnableProcessingIndicator = true;
        document.Configuration.DataTables.DefaultPageLength = 25;
        document.Configuration.DataTables.DebugMode = true;

        document.Body.Page(page =>
        {
            page.Layout = TablerLayout.Fluid;

            // Header
            page.Add(new HeaderLevel(HeaderLevelTag.H1, "🚀 DataTables Rendering Modes"));
            page.Text("Compare HTML vs JavaScript rendering for optimal performance with different dataset sizes")
                .Style(TablerTextStyle.Muted).Weight(TablerFontWeight.Medium);

            // Performance comparison section
            page.Divider("📊 Performance Comparison");

            page.Row(row =>
            {
                row.Column(TablerColumnNumber.Four, col =>
                {
                    col.Card(card =>
                    {
                        card.Header(h => h.Title("HTML Rendering").Subtitle("Traditional Mode"));
                        card.Body(body =>
                        {
                            body.Text("✅ Better compatibility").LineBreak();
                            body.Text("✅ Simpler debugging").LineBreak();
                            body.Text("❌ Slower with large datasets").LineBreak();
                            body.Text("❌ Higher memory usage").LineBreak();
                        });
                    });
                });

                row.Column(TablerColumnNumber.Four, col =>
                {
                    col.Card(card =>
                    {
                        card.Header(h => h.Title("JavaScript Rendering").Subtitle("Performance Mode"));
                        card.Body(body =>
                        {
                            body.Text("✅ Faster rendering").LineBreak();
                            body.Text("✅ Lower memory usage").LineBreak();
                            body.Text("✅ Better for large datasets").LineBreak();
                            body.Text("❌ Requires more setup").LineBreak();
                        });
                    });
                });

                row.Column(TablerColumnNumber.Four, col =>
                {
                    col.Card(card =>
                    {
                        card.Header(h => h.Title("Auto Mode").Subtitle("Smart Selection"));
                        card.Body(body =>
                        {
                            body.Text("✅ Best of both worlds").LineBreak();
                            body.Text("✅ Automatic optimization").LineBreak();
                            body.Text("✅ Configurable threshold").LineBreak();
                            body.Text("✅ No manual decisions").LineBreak();
                        });
                    });
                });
            });

            // Example 1: Small Dataset - HTML Rendering
            page.Divider($"1. Small Dataset ({smallDataset.Count} rows) - HTML Rendering");
            page.Text("Small datasets work well with traditional HTML rendering for better compatibility:");

            page.DataTable(smallDataset, table =>
            {
                table
                    .EnableHtmlRendering() // Force HTML mode
                    .Style(BootStrapTableStyle.Striped)
                    .EnablePaging(10)
                    .ConfigureColumns(columns =>
                    {
                        columns.Column(col => col.Target(0).Title("ID").Width("60px").Centered());
                        columns.Column(col => col.Target(1).Title("Product").Width("200px"));
                        columns.Column(col => col.Target(2).Title("Category").Width("120px"));
                        columns.Column(col => col.Target(3).Title("Price").Width("100px").CurrencyStyle());
                        columns.Column(col => col.Target(4).Title("Stock").Width("80px").Centered());
                        columns.Column(col => col.Target(5).Title("Rating").Width("80px").Centered().Bold());
                    })
                    .EnableExport(DataTablesExportFormat.Excel, DataTablesExportFormat.CSV);
            });

            // Example 2: Medium Dataset - JavaScript Rendering
            page.Divider($"2. Medium Dataset ({mediumDataset.Count} rows) - JavaScript Rendering");
            page.Text("Medium datasets benefit from JavaScript rendering for better performance:");

            page.DataTable(mediumDataset, table =>
            {
                table
                    .EnableJavaScriptRendering() // Force JavaScript mode
                    .Style(BootStrapTableStyle.Hover)
                    .EnablePaging(25)
                    .ConfigureColumns(columns =>
                    {
                        columns.Column(col => col.Target(0).Title("ID").Width("60px").Centered());
                        columns.Column(col => col.Target(1).Title("Product").Width("200px"));
                        columns.Column(col => col.Target(2).Title("Category").Width("120px"));
                        columns.Column(col => col.Target(3).Title("Price").Width("100px").CurrencyStyle());
                        columns.Column(col => col.Target(4).Title("Stock").Width("80px").Centered());
                        columns.Column(col => col.Target(5).Title("Rating").Width("80px").Centered().Bold());
                    })
                    .EnableExport(DataTablesExportFormat.Excel)
                    .EnableResponsive();
            });

            // Example 3: Large Dataset - Auto Mode
            page.Divider($"3. Large Dataset ({largeDataset.Count} rows) - Auto Mode");
            page.Text("Large datasets automatically use JavaScript rendering when Auto mode is enabled:");

            page.DataTable(largeDataset, table =>
            {
                table
                    .EnableAutoRendering() // Auto mode - will choose JavaScript for large dataset
                    .Style(BootStrapTableStyle.Borders)
                    .EnablePaging(50)
                    .ConfigureColumns(columns =>
                    {
                        columns.Column(col => col.Target(0).Title("ID").Width("60px").Centered());
                        columns.Column(col => col.Target(1).Title("Product").Width("200px"));
                        columns.Column(col => col.Target(2).Title("Category").Width("120px"));
                        columns.Column(col => col.Target(3).Title("Price").Width("100px").CurrencyStyle());
                        columns.Column(col => col.Target(4).Title("Stock").Width("80px").Centered());
                        columns.Column(col => col.Target(5).Title("Rating").Width("80px").Centered().Bold());
                    })
                    .EnableExport(DataTablesExportFormat.Excel, DataTablesExportFormat.CSV)
                    .EnableFixedHeader()
                    .Scrolling(scrollY: "400px", scrollCollapse: true);
            });

            // Global Configuration Example
            page.Divider("4. Global Configuration Demo");
            page.Text("This table uses global document settings (Auto mode with 1000 row threshold):");

            // This table will inherit global settings
            page.DataTable(mediumDataset.Take(800), table =>
            {
                table
                    // No explicit render mode - uses global Auto mode
                    .Style(BootStrapTableStyle.Striped)
                    .Style(BootStrapTableStyle.Hover)
                    .EnablePaging() // Uses global default page length (25)
                    .ConfigureColumns(columns =>
                    {
                        columns.Column(col => col.Target(0).Title("ID").Width("60px").Centered());
                        columns.Column(col => col.Target(1).Title("Product").Width("200px"));
                        columns.Column(col => col.Target(2).Title("Category").Width("120px"));
                        columns.Column(col => col.Target(3).Title("Price").Width("100px").CurrencyStyle());
                        columns.Column(col => col.Target(4).Title("Stock").Width("80px").Centered());
                        columns.Column(col => col.Target(5).Title("Rating").Width("80px").Centered().Bold());
                    })
                    .EnableResponsive();
            });

            // Code examples section
            page.Divider("💻 Code Examples");

            page.Row(row =>
            {
                row.Column(TablerColumnNumber.Six, column =>
                {
                    column.Card(card =>
                    {
                        card.Header(header =>
                        {
                            header.Title("Global Configuration").Subtitle("Document-level settings");
                        });
                        card.Body(body =>
                        {
                            body.Text("// Configure global DataTables settings")
                                .Style(TablerTextStyle.Monospace);
                            body.Text("document.Configuration.DataTables.DefaultRenderMode = Auto;")
                                .Style(TablerTextStyle.Monospace);
                            body.Text("document.Configuration.DataTables.AutoModeThreshold = 1000;")
                                .Style(TablerTextStyle.Monospace);
                            body.Text("document.Configuration.DataTables.EnableDeferredRendering = true;")
                                .Style(TablerTextStyle.Monospace);
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, column =>
                {
                    column.Card(card =>
                    {
                        card.Header(header =>
                        {
                            header.Title("Table-level Override").Subtitle("Per-table rendering mode");
                        });
                        card.Body(body =>
                        {
                            body.Text("page.DataTable(data, table =>")
                                .Style(TablerTextStyle.Monospace);
                            body.Text("{")
                                .Style(TablerTextStyle.Monospace);
                            body.Text("    table.EnableJavaScriptRendering() // Override global")
                                .Style(TablerTextStyle.Monospace);
                            body.Text("         .EnablePaging(50)")
                                .Style(TablerTextStyle.Monospace);
                            body.Text("         .EnableResponsive();")
                                .Style(TablerTextStyle.Monospace);
                            body.Text("});")
                                .Style(TablerTextStyle.Monospace);
                        });
                    });
                });
            });

            // Performance tips
            page.Row(row =>
            {
                row.Column(TablerColumnNumber.Twelve, column =>
                {
                    column.Card(card =>
                    {
                        card.Header(header =>
                        {
                            header.Title("🎯 Performance Tips").Subtitle("Best practices for optimal DataTables performance");
                        });
                        card.Body(body =>
                        {
                            body.AddList(list =>
                            {
                                list.Style(TablerCardListStyle.Unstyled);
                                list.WithItems(items =>
                                {
                                    items.CheckItem("🚀 Use JavaScript rendering for datasets > 1000 rows", true);
                                    items.CheckItem("⚡ Enable deferred rendering for large datasets", true);
                                    items.CheckItem("🎯 Use Auto mode for mixed dataset sizes", true);
                                    items.CheckItem("📊 Configure appropriate page lengths", true);
                                    items.CheckItem("🔧 Enable processing indicators for user feedback", true);
                                    items.CheckItem("💾 Use server-side processing for very large datasets", true);
                                    items.CheckItem("🎨 Minimize column configurations for better performance", true);
                                    items.CheckItem("📱 Enable responsive design for mobile compatibility", true);
                                });
                            });
                        });
                    });
                });
            });
        });

        document.Save("DataTablesRenderingDemo.html", openInBrowser);

        Console.WriteLine("🚀 DataTables Rendering Modes Demo created successfully!");
        Console.WriteLine("📊 Performance comparison included:");
        Console.WriteLine($"   • Small dataset: {smallDataset.Count} rows (HTML rendering)");
        Console.WriteLine($"   • Medium dataset: {mediumDataset.Count} rows (JavaScript rendering)");
        Console.WriteLine($"   • Large dataset: {largeDataset.Count} rows (Auto mode)");
        Console.WriteLine("⚙️ Global configuration features:");
        Console.WriteLine("   • Auto mode with configurable threshold");
        Console.WriteLine("   • Deferred rendering for performance");
        Console.WriteLine("   • Debug mode for development");
        Console.WriteLine("   • Global default settings");
    }

    private static List<dynamic> GenerateProducts(int count)
    {
        var random = new Random(42); // Fixed seed for consistent results
        var categories = new[] { "Electronics", "Furniture", "Clothing", "Books", "Sports", "Home & Garden" };
        var products = new[] { "Laptop", "Mouse", "Chair", "Desk", "Phone", "Tablet", "Monitor", "Keyboard" };

        return Enumerable.Range(1, count)
            .Select(i => new
            {
                Id = i,
                Name = $"{products[random.Next(products.Length)]} {random.Next(100, 999)}",
                Category = categories[random.Next(categories.Length)],
                Price = Math.Round(random.NextDouble() * 2000 + 10, 2),
                Stock = random.Next(0, 100),
                Rating = Math.Round(random.NextDouble() * 2 + 3, 1) // 3.0 to 5.0
            })
            .Cast<dynamic>()
            .ToList();
    }
}