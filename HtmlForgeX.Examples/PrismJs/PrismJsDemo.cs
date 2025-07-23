using HtmlForgeX;

namespace HtmlForgeX.Examples.PrismJs;

/// <summary>
/// Comprehensive demonstration of PrismJS syntax highlighting capabilities
/// </summary>
public class PrismJsDemo
{
    public static void RunDemo()
    {
        using var document = new Document
        {
            Head = {
                Title = "PrismJS Syntax Highlighting Demo",
                Description = "Comprehensive demonstration of PrismJS code highlighting with fluent API"
            }
        };

        document.Body.Page(page =>
        {
            page.Layout = TablerLayout.Fluid;

            page.H1("🎨 PrismJS Syntax Highlighting");
            page.Text("Beautiful code highlighting with themes, line numbers, and copy functionality")
                .Style(TablerTextStyle.Muted);

            // Basic Usage Section
            page.Divider("Basic Usage");
            page.Text("Simple code blocks with different languages:");

            page.CSharpCode(@"
// C# Example
public class DataTablesTable : Table
{
    public string Id { get; set; }

    public DataTablesTable EnablePaging(int pageLength = 10)
    {
        Options.PageLength = pageLength;
        return this;
    }
}", config => config
                .SetTitle("C# - DataTables Configuration")
                .EnableLineNumbers()
                .EnableCopyButton());

            page.JavaScriptCode(@"
// JavaScript Example
$(document).ready(function() {
    $('#myTable').DataTable({
        paging: true,
        searching: true,
        ordering: true,
        pageLength: 25
    });
});", config => config
                .SetTitle("JavaScript - DataTables Initialization")
                .EnableLineNumbers());

            // Theme Showcase
            page.Divider("Theme Showcase");
            page.Text("Different themes for various preferences:");

            var sampleCode = @"
public void ConfigureDataTables()
{
    document.Configuration.DataTables.DefaultRenderMode = DataTablesRenderMode.Auto;
    document.Configuration.DataTables.AutoModeThreshold = 1000;
    document.Configuration.DataTables.EnableDeferredRendering = true;
}";

            page.CSharpCode(sampleCode, config => config
                .SetTitle("Default Theme")
                .EnableLineNumbers()
                .SetTheme(PrismJsTheme.Default));

            page.CSharpCode(sampleCode, config => config
                .SetTitle("Dark Theme")
                .EnableLineNumbers()
                .SetTheme(PrismJsTheme.Dark));

            page.CSharpCode(sampleCode, config => config
                .SetTitle("Okaidia Theme (Popular Dark)")
                .EnableLineNumbers()
                .SetTheme(PrismJsTheme.Okaidia));

            page.CSharpCode(sampleCode, config => config
                .SetTitle("GitHub Theme")
                .EnableLineNumbers()
                .SetTheme(PrismJsTheme.GitHub));

            // Advanced Features
            page.Divider("Advanced Features");
            page.Text("Line highlighting, custom heights, and more:");

            page.CSharpCode(@"
// Global column configuration example
document.Configuration.DataTables.DefaultColumnWidth = ""120px"";
document.Configuration.DataTables.DefaultColumnType = DataTablesColumnType.String;
document.Configuration.DataTables.DefaultColumnAlignment = DataTablesTextAlign.Left;
document.Configuration.DataTables.DefaultColumnFontWeight = DataTablesFontWeight.Normal;
document.Configuration.DataTables.DefaultColumnStyle = DataTablesColumnStyle.None;

// Table with global defaults
page.DataTable(products, table => {
    table.EnableHtmlRendering()
         .Style(BootStrapTableStyle.Striped)
         .EnablePaging(5);
    // No ConfigureColumns() - uses global defaults
});", config => config
                .SetTitle("Global Column Configuration")
                .EnableLineNumbers()
                .HighlightLine(2, 3, 4, 5, 6) // Highlight the configuration lines
                .SetMaxHeight("300px")
                .OkaidiaTheme());

            // Multiple Languages
            page.Divider("Multiple Programming Languages");

            page.HtmlCode(@"
<!-- HTML Example -->
<table id=""myTable"" class=""table table-striped"">
    <thead>
        <tr>
            <th>Product ID</th>
            <th>Name</th>
            <th>Price</th>
        </tr>
    </thead>
    <tbody>
        <!-- Data will be populated by DataTables -->
    </tbody>
</table>", config => config
                .SetTitle("HTML - Table Structure")
                .EnableLineNumbers());

            page.CssCode(@"
/* CSS Styling */
.dataTables_wrapper {
    margin-top: 1rem;
}

.table-striped tbody tr:nth-of-type(odd) {
    background-color: rgba(0, 0, 0, 0.05);
}

.dataTables_filter input {
    border-radius: 0.375rem;
    border: 1px solid #ced4da;
    padding: 0.375rem 0.75rem;
}", config => config
                .SetTitle("CSS - Custom Styling")
                .EnableLineNumbers());

            page.JsonCode(@"
{
  ""data"": [
    { ""id"": 1, ""name"": ""Laptop Pro"", ""price"": 1299.99 },
    { ""id"": 2, ""name"": ""Wireless Mouse"", ""price"": 29.99 },
    { ""id"": 3, ""name"": ""Office Chair"", ""price"": 199.99 }
  ],
  ""columns"": [
    { ""data"": ""id"", ""title"": ""Product ID"" },
    { ""data"": ""name"", ""title"": ""Product Name"" },
    { ""data"": ""price"", ""title"": ""Price"" }
  ]
}", config => config
                .SetTitle("JSON - Data Structure")
                .EnableLineNumbers());

            // Configuration Examples
            page.Divider("DataTables Configuration Examples");
            page.Text("Real-world configuration examples:");

            page.CSharpCode(@"
// HTML Rendering Mode - Better Compatibility
page.DataTable(products, table => {
    table.EnableHtmlRendering()
         .Style(BootStrapTableStyle.Striped)
         .Style(BootStrapTableStyle.Hover)
         .EnablePaging(5)
         .ConfigureColumns(columns => {
             columns.Column(col => col.Target(0).Title(""Product ID"").Width(""80px"").Type(DataTablesColumnType.Numeric).Centered());
             columns.Column(col => col.Target(1).Title(""Product Name"").Width(""200px""));
             columns.Column(col => col.Target(2).Title(""Category"").Width(""120px""));
             columns.Column(col => col.Target(3).Title(""Price"").Width(""100px"").Type(DataTablesColumnType.Currency).CurrencyStyle());
         })
         .EnableExport(DataTablesExportFormat.Excel, DataTablesExportFormat.CSV)
         .EnableResponsive();
});", config => config
                .SetTitle("HTML Rendering Configuration")
                .EnableLineNumbers()
                .SetMaxHeight("400px")
                .TomorrowNightTheme());

            page.CSharpCode(@"
// JavaScript Rendering Mode - Better Performance
page.DataTable(largeDataset, table => {
    table.EnableJavaScriptRendering()
         .Style(BootStrapTableStyle.Borders)
         .EnablePaging(50)
         .Scrolling(scrollY: ""400px"", scrollX: true)
         .EnableSearching()
         .EnableOrdering()
         .Configure(options => {
             options.Processing = true;
             options.DeferRender = true;
             options.StateSave = true;
         });
});", config => config
                .SetTitle("JavaScript Rendering Configuration")
                .EnableLineNumbers()
                .HighlightLine(3, 4, 5) // Highlight performance settings
                .VsTheme());

            page.CSharpCode(@"
// Auto Mode - Smart Selection
page.DataTable(data, table => {
    table.EnableAutoRendering() // Chooses HTML or JavaScript based on data size
         .Style(BootStrapTableStyle.Hover)
         .EnablePaging(25)
         .EnableExport(DataTablesExportFormat.CSV, DataTablesExportFormat.PDF)
         .EnableRowGrouping(2) // Group by category column
         .EnableSearchBuilder()
         .EnableFixedHeader()
         .DefaultOrder(0, ""asc"");
});", config => config
                .SetTitle("Auto Mode Configuration")
                .EnableLineNumbers()
                .HighlightLine(2) // Highlight the auto mode
                .GitHubTheme());

            // Best Practices
            page.Divider("Best Practices & Tips");

            page.CodeBlock(@"
// ✅ DO: Use global configuration for consistency
document.Configuration.DataTables.DefaultRenderMode = DataTablesRenderMode.Auto;
document.Configuration.DataTables.AutoModeThreshold = 1000;
document.Configuration.DataTables.DefaultColumnWidth = ""120px"";

// ✅ DO: Use fluent API for readability
table.EnablePaging(25)
     .EnableSearching()
     .EnableResponsive()
     .OkaidiaTheme();

// ❌ DON'T: Mix rendering modes unnecessarily
// table.EnableHtmlRendering().EnableJavaScriptRendering(); // Conflicting

// ✅ DO: Use appropriate rendering mode for data size
if (data.Count > 1000) {
    table.EnableJavaScriptRendering(); // Better performance
} else {
    table.EnableHtmlRendering(); // Better compatibility
}", PrismJsLanguage.CSharp, config => config
                .SetTitle("Best Practices")
                .EnableLineNumbers()
                .SetMaxHeight("350px")
                .EnableWordWrap()
                .DarkTheme());
        });

        document.Save("prismjs_demo.html", true);

        HelpersSpectre.Success("✅ PrismJS Demo completed successfully!");
        HelpersSpectre.Success("🎨 Features demonstrated:");
        HelpersSpectre.Success("   • Multiple programming languages (C#, JavaScript, HTML, CSS, JSON)");
        HelpersSpectre.Success("   • Various themes (Default, Dark, Okaidia, GitHub, VS, Tomorrow Night)");
        HelpersSpectre.Success("   • Line numbers and highlighting");
        HelpersSpectre.Success("   • Copy to clipboard functionality");
        HelpersSpectre.Success("   • Custom heights and scrolling");
        HelpersSpectre.Success("   • Word wrapping");
        HelpersSpectre.Success("   • Fluent API configuration");
        HelpersSpectre.Success("");
        HelpersSpectre.Success("🚀 Perfect for documentation and code examples!");
    }
}