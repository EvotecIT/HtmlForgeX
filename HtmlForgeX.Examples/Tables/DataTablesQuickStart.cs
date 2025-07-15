using HtmlForgeX;

namespace HtmlForgeX.Examples.Tables;

/// <summary>
/// Quick start guide for the enhanced DataTables features
/// </summary>
internal class DataTablesQuickStart
{
    public static void Create(bool openInBrowser = false)
    {
        HelpersSpectre.PrintTitle("⚡ DataTables Quick Start Guide");

        var document = new Document
        {
            Head = {
                Title = "DataTables Quick Start Guide",
                Author = "HtmlForgeX Team",
                Revised = DateTime.Now,
                Description = "Quick start examples for DataTables enhanced features",
                Keywords = "datatable, quickstart, examples",
                Charset = "utf-8"
            }
        };

        // Sample data
        var products = new List<dynamic>
        {
            new { Id = 1, Name = "Laptop Pro", Category = "Electronics", Price = 1299.99, Stock = 15, Rating = 4.5 },
            new { Id = 2, Name = "Wireless Mouse", Category = "Electronics", Price = 29.99, Stock = 50, Rating = 4.2 },
            new { Id = 3, Name = "Office Chair", Category = "Furniture", Price = 199.99, Stock = 8, Rating = 4.0 },
            new { Id = 4, Name = "Standing Desk", Category = "Furniture", Price = 399.99, Stock = 12, Rating = 4.7 },
            new { Id = 5, Name = "Smartphone", Category = "Electronics", Price = 699.99, Stock = 25, Rating = 4.3 },
            new { Id = 6, Name = "Tablet", Category = "Electronics", Price = 329.99, Stock = 18, Rating = 4.1 },
            new { Id = 7, Name = "Bookshelf", Category = "Furniture", Price = 149.99, Stock = 6, Rating = 3.9 },
            new { Id = 8, Name = "Desk Lamp", Category = "Furniture", Price = 79.99, Stock = 22, Rating = 4.4 }
        };

        document.Body.Page(page =>
        {
            page.Layout = TablerLayout.Fluid;

            // Header
            page.Add(new HeaderLevel(HeaderLevelTag.H1, "⚡ DataTables Quick Start"));
            page.Text("Learn the enhanced DataTables features with simple examples")
                .Style(TablerTextStyle.Muted).Weight(TablerFontWeight.Medium);

            // Example 1: Basic Enhanced Table
            page.Divider("1. Basic Enhanced Table");
            page.Text("Simple table with export functionality and responsive design:");

            var basicTable = (DataTablesTable)page.Table(products, TableType.DataTables);
            basicTable
                .Style(BootStrapTableStyle.Striped)
                .Style(BootStrapTableStyle.Hover)
                .EnablePaging(5)
                .EnableExport(DataTablesExportFormat.Excel, DataTablesExportFormat.CSV, DataTablesExportFormat.Copy)
                .EnableResponsive();

            // Example 2: Column Configuration
            page.Divider("2. Column Configuration");
            page.Text("Table with custom column types, widths, and formatting:");

            page.DataTable(products, table =>
            {
                table
                    .Style(BootStrapTableStyle.Borders)
                    .EnablePaging(4)
                    .ConfigureColumns(columns =>
                    {
                        columns.Column(col => col.Target(0).Title("Product ID").Width("80px").Type(DataTablesColumnType.Numeric).Centered());
                        columns.Column(col => col.Target(1).Title("Product Name").Width("200px"));
                        columns.Column(col => col.Target(2).Title("Category").Width("120px"));
                        columns.Column(col => col.Target(3).Title("Price").Width("100px").Type(DataTablesColumnType.Currency).CurrencyStyle());
                        columns.Column(col => col.Target(4).Title("Stock").Width("80px").Type(DataTablesColumnType.Numeric).Centered());
                        columns.Column(col => col.Target(5).Title("Rating").Width("80px").Type(DataTablesColumnType.Numeric).Centered());
                    })
                    .DefaultOrder(3, "desc") // Order by price descending
                    .EnableExport(DataTablesExportFormat.PDF);
            });

            // Example 3: Search and Filter Features
            page.Divider("3. Advanced Search Features");
            page.Text("Table with search builder and search panes:");

            page.DataTable(products, table =>
            {
                table
                    .Style(BootStrapTableStyle.Hover)
                    .EnablePaging(6)
                    .EnableSearchBuilder(builder =>
                    {
                        builder.Enable = true;
                        builder.Logic = "AND";
                        builder.Conditions = 2;
                    })
                    .DomLayout("Qfrtip"); // Simplified - just SearchBuilder (Q), no SearchPanes for now
            });

            // Example 4: Export Configuration
            page.Divider("4. Custom Export Configuration");
            page.Text("Table with detailed export options:");

            page.DataTable(products, table =>
            {
                table
                    .Style(BootStrapTableStyle.Striped)
                    .EnablePaging(5)
                    .ConfigureExport(export =>
                    {
                        export.Excel("📊 Export Excel", "products_report", "Product Inventory Report")
                              .CSV("📄 Export CSV", "products_data")
                              .PDF("� Expoort PDF", "products_list", "Product Catalog")
                              .Copy("📋 Copy Data")
                              .Print("🖨️ Print Table")
                              .ColumnVisibility("👁️ Show/Hide Columns")
                              .ExcludeColumns(0); // Exclude ID column from exports
                    });
            });

            // Example 5: Localization
            page.Divider("5. Localization Example");
            page.Text("Table with custom text and localization:");

            page.DataTable(products.Take(6), table =>
            {
                table
                    .Style(BootStrapTableStyle.Borders)
                    .EnablePaging(3)
                    .Localize(lang =>
                    {
                        lang.Search = "🔍 Search products:";
                        lang.LengthMenu = "Display _MENU_ products";
                        lang.Info = "Showing _START_ to _END_ of _TOTAL_ products";
                        lang.InfoEmpty = "No products available";
                        lang.ZeroRecords = "No matching products found";
                        lang.Processing = "Loading products...";
                        lang.Paginate = new DataTablesPaginate
                        {
                            First = "⏮️ First",
                            Last = "⏭️ Last",
                            Next = "▶️ Next",
                            Previous = "◀️ Previous"
                        };
                    })
                    .EnableExport(DataTablesExportFormat.Excel, DataTablesExportFormat.Copy);
            });

            // Example 6: Performance Features
            page.Divider("6. Performance Optimizations");
            page.Text("Table with state saving, fixed header, and scrolling:");

            page.DataTable(products, table =>
            {
                table
                    .Style(BootStrapTableStyle.Hover)
                    .EnablePaging(4)
                    .EnableStateSaving() // Remember user preferences
                    .EnableFixedHeader() // Keep header visible while scrolling
                    .Scrolling(scrollY: "300px", scrollCollapse: true) // Vertical scrolling
                    .Configure(options =>
                    {
                        options.Processing = true; // Show loading indicator
                        options.DeferRender = true; // Improve performance with large datasets
                    });
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
                            header.Title("Basic Usage").Subtitle("Simple enhanced table");
                        });
                        card.Body(body =>
                        {
                            body.CSharpCode(@"
document.Body.DataTable(data, table =>
{
    table.Style(BootStrapTableStyle.Striped)
         .EnablePaging(10)
         .EnableExport(Excel, CSV);
});", config => config
                                .EnableLineNumbers()
                                .EnableCopyButton()
                                .GitHubTheme());
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, column =>
                {
                    column.Card(card =>
                    {
                        card.Header(header =>
                        {
                            header.Title("Column Configuration").Subtitle("Advanced column setup");
                        });
                        card.Body(body =>
                        {
                            body.CSharpCode(@"
.ConfigureColumns(columns =>
{
    columns.Column(col => col.Target(0)
           .Width(""80px"").Centered());
    columns.Column(col => col.Target(3)
           .Type(Currency).CurrencyStyle());
})", config => config
                                .EnableLineNumbers()
                                .EnableCopyButton()
                                .GitHubTheme());
                        });
                    });
                });
            });

            page.Row(row =>
            {
                row.Column(TablerColumnNumber.Twelve, column =>
                {
                    column.Card(card =>
                    {
                        card.Header(header =>
                        {
                            header.Title("🎯 Key Features").Subtitle("What's new in the enhanced DataTables");
                        });
                        card.Body(body =>
                        {
                            body.AddList(list =>
                            {
                                list.Style(TablerCardListStyle.Unstyled);
                                list.WithItems(items =>
                                {
                                    items.CheckItem("📊 Export to Excel, CSV, PDF with custom options", true);
                                    items.CheckItem("🔍 Advanced search builder with multiple conditions", true);
                                    items.CheckItem("📱 Responsive design with fixed headers and columns", true);
                                    items.CheckItem("👁️ Column visibility controls and reordering", true);
                                    items.CheckItem("🔄 Row grouping and advanced sorting", true);
                                    items.CheckItem("📋 Search panes for easy filtering", true);
                                    items.CheckItem("🎨 Fluent API with lambda configuration", true);
                                    items.CheckItem("🌍 Complete localization support", true);
                                    items.CheckItem("⚡ Performance optimizations and state saving", true);
                                    items.CheckItem("🎯 Type-safe column configuration with enums", true);
                                });
                            });
                        });
                    });
                });
            });
        });

        document.Save("DataTablesQuickStart.html", openInBrowser);

        Console.WriteLine("⚡ DataTables Quick Start Guide created successfully!");
        Console.WriteLine("📚 Examples included:");
        Console.WriteLine("   1. Basic enhanced table with exports");
        Console.WriteLine("   2. Column configuration and formatting");
        Console.WriteLine("   3. Advanced search features");
        Console.WriteLine("   4. Custom export configuration");
        Console.WriteLine("   5. Localization examples");
        Console.WriteLine("   6. Performance optimizations");
        Console.WriteLine("");
        Console.WriteLine("🚀 Ready to use enhanced DataTables with fluent API!");
    }
}