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
                    Description = "Testing the new fluent API with enums"
                }
            };

            document.Body.Page(page =>
            {
                page.Layout = TablerLayout.Fluid;

                page.Add(new HeaderLevel(HeaderLevelTag.H1, "Enhanced DataTables API Test"));

                // Test the new fluent API with enums
                page.DataTable(products, table =>
                {
                    table
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
            });

            document.Save("enhanced_datatables_test.html", true);

            Console.WriteLine("✅ Enhanced DataTables API test completed successfully!");
            Console.WriteLine("🎯 Key improvements:");
            Console.WriteLine("   • Fluent API with lambda configuration");
            Console.WriteLine("   • Type-safe enums instead of CSS class strings");
            Console.WriteLine("   • Convenient shorthand methods (Centered(), Bold(), CurrencyStyle())");
            Console.WriteLine("   • Better developer experience without HTML/CSS knowledge");
        }
    }
}