using HtmlForgeX;

namespace HtmlForgeX.Examples.PrismJs;

/// <summary>
/// Documentation-focused demo showing how to use PrismJS for DataTables code examples
/// </summary>
public class DataTablesDocumentationDemo
{
    public static void RunDemo()
    {
        using var document = new Document
        {
            Head = {
                Title = "DataTables API Documentation",
                Description = "Complete guide to using the enhanced DataTables API with code examples"
            }
        };

        document.Body.Page(page =>
        {
            page.Layout = TablerLayout.Fluid;

            page.Add(new HeaderLevel(HeaderLevelTag.H1, "📊 DataTables Enhanced API Guide"));
            page.Text("Complete documentation with interactive code examples")
                .Style(TablerTextStyle.Muted);

            // Quick Start
            page.Add(new HeaderLevel(HeaderLevelTag.H2, "🚀 Quick Start"));
            page.Text("Get started with DataTables in just a few lines:");

            page.CSharpCode(@"
// Basic DataTable setup
var products = new[] {
    new { Id = 1, Name = ""Laptop"", Price = 999.99 },
    new { Id = 2, Name = ""Mouse"", Price = 29.99 }
};

page.DataTable(products, table => {
    table.EnablePaging(10)
         .EnableSearching()
         .Style(BootStrapTableStyle.Striped);
});", config => config
                .SetTitle("Basic Usage")
                .EnableLineNumbers()
                .EnableCopyButton()
                .GitHubTheme());

            // Rendering Modes
            page.Add(new HeaderLevel(HeaderLevelTag.H2, "⚡ Rendering Modes"));
            page.Text("Choose the optimal rendering mode for your data size:");

            page.Add(new HeaderLevel(HeaderLevelTag.H3, "HTML Rendering (Traditional)"));
            page.Text("Best for smaller datasets and maximum compatibility:");

            page.CSharpCode(@"
page.DataTable(smallDataset, table => {
    table.EnableHtmlRendering()  // Traditional server-side rendering
         .Style(BootStrapTableStyle.Striped)
         .EnablePaging(25)
         .EnableExport(DataTablesExportFormat.Excel);
});", config => config
                .EnableLineNumbers()
                .HighlightLine(2)
                .OkaidiaTheme());

            page.Add(new HeaderLevel(HeaderLevelTag.H3, "JavaScript Rendering (High Performance)"));
            page.Text("Best for large datasets (1000+ rows):");

            page.CSharpCode(@"
page.DataTable(largeDataset, table => {
    table.EnableJavaScriptRendering()  // Client-side rendering
         .EnablePaging(50)
         .Scrolling(scrollY: ""400px"")
         .Configure(options => {
             options.DeferRender = true;    // Faster initial load
             options.Processing = true;     // Show loading indicator
         });
});", config => config
                .EnableLineNumbers()
                .HighlightLine(2, 6, 7)
                .TomorrowNightTheme());

            page.Add(new HeaderLevel(HeaderLevelTag.H3, "Auto Mode (Smart Selection)"));
            page.Text("Automatically chooses the best rendering mode:");

            page.CSharpCode(@"
// Configure global threshold
document.Configuration.DataTables.AutoModeThreshold = 1000;

page.DataTable(data, table => {
    table.EnableAutoRendering()  // Smart mode selection
         .EnablePaging()
         .EnableResponsive();
});", config => config
                .EnableLineNumbers()
                .HighlightLine(2, 5)
                .VsTheme());

            // Global Configuration
            page.Add(new HeaderLevel(HeaderLevelTag.H2, "🌐 Global Configuration"));
            page.Text("Set document-wide defaults for consistency:");

            page.CSharpCode(@"
// Configure global DataTables settings
document.Configuration.DataTables.DefaultRenderMode = DataTablesRenderMode.Auto;
document.Configuration.DataTables.AutoModeThreshold = 1000;
document.Configuration.DataTables.EnableDeferredRendering = true;
document.Configuration.DataTables.DefaultPageLength = 25;

// Configure global column defaults
document.Configuration.DataTables.DefaultColumnWidth = ""120px"";
document.Configuration.DataTables.DefaultColumnType = DataTablesColumnType.String;
document.Configuration.DataTables.DefaultColumnAlignment = DataTablesTextAlign.Left;
document.Configuration.DataTables.DefaultColumnFontWeight = DataTablesFontWeight.Normal;
document.Configuration.DataTables.DefaultColumnStyle = DataTablesColumnStyle.None;", config => config
                .SetTitle("Global Configuration")
                .EnableLineNumbers()
                .SetMaxHeight("300px")
                .DarkTheme());

            // Column Configuration
            page.Add(new HeaderLevel(HeaderLevelTag.H2, "📋 Column Configuration"));
            page.Text("Fine-tune individual columns with the fluent API:");

            page.CSharpCode(@"
page.DataTable(products, table => {
    table.ConfigureColumns(columns => {
        columns.Column(col => col
            .Target(0)
            .Title(""Product ID"")
            .Width(""80px"")
            .Type(DataTablesColumnType.Numeric)
            .Centered());

        columns.Column(col => col
            .Target(1)
            .Title(""Product Name"")
            .Width(""200px"")
            .Type(DataTablesColumnType.String));

        columns.Column(col => col
            .Target(2)
            .Title(""Price"")
            .Width(""100px"")
            .Type(DataTablesColumnType.Currency)
            .CurrencyStyle()
            .RightAligned());
    });
});", config => config
                .SetTitle("Column Configuration")
                .EnableLineNumbers()
                .SetMaxHeight("400px")
                .HighlightLine(4, 5, 6, 7, 8)
                .GitHubTheme());

            // Advanced Features
            page.Add(new HeaderLevel(HeaderLevelTag.H2, "🔧 Advanced Features"));

            page.Add(new HeaderLevel(HeaderLevelTag.H3, "Export Functionality"));
            page.CSharpCode(@"
table.EnableExport(
    DataTablesExportFormat.Excel,
    DataTablesExportFormat.CSV,
    DataTablesExportFormat.PDF
);", config => config
                .EnableLineNumbers()
                .OkaidiaTheme());

            page.Add(new HeaderLevel(HeaderLevelTag.H3, "Search and Filtering"));
            page.CSharpCode(@"
table.EnableSearching()
     .EnableSearchBuilder()
     .EnableSearchPanes();", config => config
                .EnableLineNumbers()
                .VsTheme());

            page.Add(new HeaderLevel(HeaderLevelTag.H3, "Responsive Design"));
            page.CSharpCode(@"
table.EnableResponsive()
     .EnableFixedHeader()
     .EnableFixedColumns(leftColumns: 1, rightColumns: 1);", config => config
                .EnableLineNumbers()
                .TomorrowNightTheme());

            // Performance Tips
            page.Add(new HeaderLevel(HeaderLevelTag.H2, "⚡ Performance Tips"));

            page.CodeBlock(@"
// ✅ For large datasets (1000+ rows)
table.EnableJavaScriptRendering()
     .Configure(options => {
         options.DeferRender = true;        // Render rows only when needed
         options.Processing = true;         // Show loading indicator
         options.ServerSide = false;        // Client-side processing
     });

// ✅ Use scrolling instead of pagination for very large datasets
table.Scrolling(scrollY: ""400px"", scrollX: true, scrollCollapse: true);

// ✅ Enable state saving for better user experience
table.EnableStateSaving();

// ✅ Use global configuration to avoid repetition
document.Configuration.DataTables.EnableDeferredRendering = true;", PrismJsLanguage.CSharp, config => config
                .SetTitle("Performance Optimization")
                .EnableLineNumbers()
                .SetMaxHeight("350px")
                .DarkTheme());

            // Complete Example
            page.Add(new HeaderLevel(HeaderLevelTag.H2, "🎯 Complete Example"));
            page.Text("Putting it all together:");

            page.CSharpCode(@"
using var document = new Document {
    Head = { Title = ""Product Catalog"" }
};

// Global configuration
document.Configuration.DataTables.DefaultRenderMode = DataTablesRenderMode.Auto;
document.Configuration.DataTables.AutoModeThreshold = 1000;
document.Configuration.DataTables.DefaultColumnWidth = ""120px"";

document.Body.Page(page => {
    page.Layout = TablerLayout.Fluid;

    page.Add(new HeaderLevel(HeaderLevelTag.H1, ""Product Catalog""));

    page.DataTable(products, table => {
        table
            .EnableAutoRendering()
            .Style(BootStrapTableStyle.Striped)
            .Style(BootStrapTableStyle.Hover)
            .EnablePaging(25)
            .EnableSearching()
            .EnableResponsive()
            .ConfigureColumns(columns => {
                columns.Column(col => col.Target(0).Title(""ID"").Width(""60px"").Centered());
                columns.Column(col => col.Target(1).Title(""Product"").Width(""200px""));
                columns.Column(col => col.Target(2).Title(""Category"").Width(""120px""));
                columns.Column(col => col.Target(3).Title(""Price"").Type(DataTablesColumnType.Currency));
                columns.Column(col => col.Target(4).Title(""Stock"").Centered());
            })
            .EnableExport(DataTablesExportFormat.Excel, DataTablesExportFormat.CSV)
            .DefaultOrder(1, ""asc"");
    });
});

document.Save(""product-catalog.html"", true);", config => config
                .SetTitle("Complete Implementation")
                .EnableLineNumbers()
                .SetMaxHeight("500px")
                .EnableWordWrap()
                .OkaidiaTheme());
        });

        document.Save("datatables_documentation.html", true);

        Console.WriteLine("✅ DataTables Documentation Demo completed!");
        Console.WriteLine("📚 Documentation includes:");
        Console.WriteLine("   • Quick start guide");
        Console.WriteLine("   • Rendering mode explanations");
        Console.WriteLine("   • Global configuration examples");
        Console.WriteLine("   • Column configuration details");
        Console.WriteLine("   • Advanced features showcase");
        Console.WriteLine("   • Performance optimization tips");
        Console.WriteLine("   • Complete working example");
        Console.WriteLine("");
        Console.WriteLine("🎨 All code examples are syntax-highlighted and copyable!");
    }
}