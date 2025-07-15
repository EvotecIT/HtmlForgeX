using HtmlForgeX;

namespace TestDataTablesEnhanced
{
    class Program
    {
        static void Main(string[] args)
        {
            // Sample data
            var products = new[]
            {
                new { Id = 1, Name = "Laptop Pro", Category = "Electronics", Price = 1299.99, Stock = 15, Rating = 4.5 },
                new { Id = 2, Name = "Wireless Mouse", Category = "Electronics", Price = 29.99, Stock = 50, Rating = 4.2 },
                new { Id = 3, Name = "Office Chair", Category = "Furniture", Price = 199.99, Stock = 8, Rating = 4.0 }
            };

            var document = new Document
            {
                Head = {
                    Title = "Enhanced DataTables Test",
                    Description = "Testing the new fluent API with enums and rendering modes"
                }
            };

            // Configure global DataTables settings
            document.Configuration.DataTables.DefaultRenderMode = DataTablesRenderMode.Auto;
            document.Configuration.DataTables.AutoModeThreshold = 5; // Low threshold for demo
            document.Configuration.DataTables.EnableDeferredRendering = true;
            document.Configuration.DataTables.DebugMode = true;

            // Configure global column defaults
            document.Configuration.DataTables.DefaultColumnWidth = "120px";
            document.Configuration.DataTables.DefaultColumnType = DataTablesColumnType.String;
            document.Configuration.DataTables.DefaultColumnAlignment = DataTablesTextAlign.Left;
            document.Configuration.DataTables.DefaultColumnFontWeight = DataTablesFontWeight.Normal;
            document.Configuration.DataTables.DefaultColumnStyle = DataTablesColumnStyle.None;

            document.Body.Page(page =>
            {
                page.Layout = TablerLayout.Fluid;

                page.Add(new HeaderLevel(HeaderLevelTag.H1, "Enhanced DataTables API Test"));
                page.Text("Testing fluent API with enums and JavaScript/HTML rendering modes")
                    .Style(TablerTextStyle.Muted);

                // Test HTML rendering
                page.Divider("HTML Rendering Mode");
                page.DataTable(products, table =>
                {
                    table
                        .EnableHtmlRendering() // Force HTML mode
                        .Style(BootStrapTableStyle.Striped)
                        .Style(BootStrapTableStyle.Hover)
                        .EnablePaging(5)
                        .ConfigureColumns(columns =>
                        {
                            columns.Column(col => col.Target(0).Title("Product ID").Width("80px").Type(DataTablesColumnType.Numeric).Centered());
                            columns.Column(col => col.Target(1).Title("Product Name").Width("200px"));
                            columns.Column(col => col.Target(2).Title("Category").Width("120px"));
                            columns.Column(col => col.Target(3).Title("Price").Width("100px").Type(DataTablesColumnType.Currency).CurrencyStyle());
                            columns.Column(col => col.Target(4).Title("Stock").Width("80px").Type(DataTablesColumnType.Numeric).Centered());
                            columns.Column(col => col.Target(5).Title("Rating").Width("80px").Type(DataTablesColumnType.Numeric).Centered().Bold());
                        })
                        .EnableExport(DataTablesExportFormat.Excel, DataTablesExportFormat.CSV)
                        .EnableResponsive();
                });

                // Test JavaScript rendering
                page.Divider("JavaScript Rendering Mode");
                page.DataTable(products, table =>
                {
                    table
                        .EnableJavaScriptRendering() // Force JavaScript mode
                        .Style(BootStrapTableStyle.Borders)
                        .EnablePaging(5)
                        .ConfigureColumns(columns =>
                        {
                            columns.Column(col => col.Target(0).Title("Product ID").Width("80px").Type(DataTablesColumnType.Numeric).Centered());
                            columns.Column(col => col.Target(1).Title("Product Name").Width("200px"));
                            columns.Column(col => col.Target(2).Title("Category").Width("120px"));
                            columns.Column(col => col.Target(3).Title("Price").Width("100px").Type(DataTablesColumnType.Currency).CurrencyStyle());
                            columns.Column(col => col.Target(4).Title("Stock").Width("80px").Type(DataTablesColumnType.Numeric).Centered());
                            columns.Column(col => col.Target(5).Title("Rating").Width("80px").Type(DataTablesColumnType.Numeric).Centered().Bold());
                        })
                        .EnableExport(DataTablesExportFormat.CSV);
                });

                // Test Auto mode (will use JavaScript due to low threshold)
                page.Divider("Auto Rendering Mode");
                page.DataTable(products, table =>
                {
                    table
                        .EnableAutoRendering() // Auto mode
                        .Style(BootStrapTableStyle.Hover)
                        .EnablePaging(5)
                        .ConfigureColumns(columns =>
                        {
                            columns.Column(col => col.Target(0).Title("Product ID").Width("80px").Type(DataTablesColumnType.Numeric).Centered());
                            columns.Column(col => col.Target(1).Title("Product Name").Width("200px"));
                            columns.Column(col => col.Target(2).Title("Category").Width("120px"));
                            columns.Column(col => col.Target(3).Title("Price").Width("100px").Type(DataTablesColumnType.Currency).CurrencyStyle());
                            columns.Column(col => col.Target(4).Title("Stock").Width("80px").Type(DataTablesColumnType.Numeric).Centered());
                            columns.Column(col => col.Target(5).Title("Rating").Width("80px").Type(DataTablesColumnType.Numeric).Centered().Bold());
                        });
                });

                // Test Global Column Defaults (no column configuration - uses global defaults)
                page.Divider("Global Column Defaults Demo");
                page.Text("This table uses global column defaults (120px width, left alignment, normal font weight)")
                    .Style(TablerTextStyle.Muted);
                page.DataTable(products, table =>
                {
                    table
                        .EnableHtmlRendering()
                        .Style(BootStrapTableStyle.Striped)
                        .EnablePaging(5);
                    // No ConfigureColumns() call - will use global defaults
                });
            });

            document.Save("enhanced_datatables_test.html", true);

            Console.WriteLine("✅ Enhanced DataTables API test completed successfully!");
            Console.WriteLine("🎯 Key improvements:");
            Console.WriteLine("   • Fluent API with lambda configuration");
            Console.WriteLine("   • Type-safe enums instead of CSS class strings");
            Console.WriteLine("   • Convenient shorthand methods (Centered(), Bold(), CurrencyStyle())");
            Console.WriteLine("   • JavaScript/HTML rendering modes for optimal performance");
            Console.WriteLine("   • Global configuration with auto-mode selection");
            Console.WriteLine("   • Global column defaults (width, type, alignment, font weight, style)");
            Console.WriteLine("   • Better developer experience without HTML/CSS knowledge");
            Console.WriteLine("");
            Console.WriteLine("🚀 Rendering modes tested:");
            Console.WriteLine("   • HTML Rendering - Traditional compatibility mode");
            Console.WriteLine("   • JavaScript Rendering - High-performance mode");
            Console.WriteLine("   • Auto Mode - Smart selection based on data size");
            Console.WriteLine("");
            Console.WriteLine("🎨 Global column defaults applied:");
            Console.WriteLine("   • Default Width: 120px");
            Console.WriteLine("   • Default Type: String");
            Console.WriteLine("   • Default Alignment: Left");
            Console.WriteLine("   • Default Font Weight: Normal");
            Console.WriteLine("   • Default Style: None");
        }
    }
}