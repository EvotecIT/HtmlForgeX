namespace HtmlForgeX.Examples.Tables;

/// <summary>
/// Comprehensive demonstration of advanced DataTables features with fluent API
/// </summary>
internal class AdvancedDataTablesDemo
{
    public static void Create(bool openInBrowser = false)
    {
        HelpersSpectre.PrintTitle("🚀 Advanced DataTables Features Demo");

        using var document = new Document
        {
            Head = {
                Title = "Advanced DataTables Features Demo",
                Author = "HtmlForgeX Team",
                Revised = DateTime.Now,
                Description = "Comprehensive showcase of DataTables advanced features",
                Keywords = "datatable, advanced, features, export, search, responsive",
                Charset = "utf-8"
            }
        };

        // Sample data with various data types
        var employees = new List<dynamic>
        {
            new { Id = 1, Name = "John Smith", Department = "Engineering", Salary = 75000, HireDate = new DateTime(2020, 3, 15), Email = "john.smith@company.com", Active = true },
            new { Id = 2, Name = "Jane Doe", Department = "Marketing", Salary = 65000, HireDate = new DateTime(2019, 7, 22), Email = "jane.doe@company.com", Active = true },
            new { Id = 3, Name = "Bob Johnson", Department = "Engineering", Salary = 82000, HireDate = new DateTime(2018, 11, 8), Email = "bob.johnson@company.com", Active = false },
            new { Id = 4, Name = "Alice Brown", Department = "HR", Salary = 58000, HireDate = new DateTime(2021, 1, 12), Email = "alice.brown@company.com", Active = true },
            new { Id = 5, Name = "Charlie Wilson", Department = "Engineering", Salary = 95000, HireDate = new DateTime(2017, 5, 3), Email = "charlie.wilson@company.com", Active = true },
            new { Id = 6, Name = "Diana Davis", Department = "Marketing", Salary = 72000, HireDate = new DateTime(2020, 9, 18), Email = "diana.davis@company.com", Active = true },
            new { Id = 7, Name = "Frank Miller", Department = "Sales", Salary = 68000, HireDate = new DateTime(2019, 12, 5), Email = "frank.miller@company.com", Active = false },
            new { Id = 8, Name = "Grace Lee", Department = "Engineering", Salary = 88000, HireDate = new DateTime(2018, 4, 27), Email = "grace.lee@company.com", Active = true },
            new { Id = 9, Name = "Henry Taylor", Department = "HR", Salary = 62000, HireDate = new DateTime(2021, 8, 14), Email = "henry.taylor@company.com", Active = true },
            new { Id = 10, Name = "Ivy Chen", Department = "Sales", Salary = 71000, HireDate = new DateTime(2020, 2, 29), Email = "ivy.chen@company.com", Active = true }
        };

        document.Body.Page(page =>
        {
            page.Layout = TablerLayout.Fluid;

            // Header
            page.H1("🚀 Advanced DataTables Features");
            page.Text("Comprehensive demonstration of DataTables with all advanced features enabled")
                .Style(TablerTextStyle.Muted).Weight(TablerFontWeight.Medium);

            page.Divider("Feature-Rich Employee Table");

            // Advanced DataTables with all features - FIXED: Now properly attached to page
            page.DataTable(employees, table =>
            {
                table
                    // Styling
                    .Style(BootStrapTableStyle.Striped)
                    .Style(BootStrapTableStyle.Hover)
                    .Style(BootStrapTableStyle.Borders)

                    // Basic Features
                    .EnablePaging(pageLength: 5, lengthMenu: new[] { 5, 10, 25, 50, 100 })
                    .EnableSearching()
                    .EnableOrdering()
                    .PagingType(DataTablesPagingType.FullNumbers)

                    // Advanced Features
                    .EnableStateSaving()
                    .EnableResponsive()
                    .EnableFixedHeader(headerOffset: 50)
                    .EnableSelection("multiple")
                    .Scrolling(scrollY: "400px", scrollX: true, scrollCollapse: true)

                    // Export functionality
                    .ConfigureExport(export =>
                    {
                        export.Excel("📊 Excel", "employees_report", "Employee Report")
                              .CSV("📄 CSV", "employees_data")
                              .PDF("📋 PDF", "employees_list", "Company Employee List")
                              .Copy("📋 Copy")
                              .Print("🖨️ Print")
                              .ColumnVisibility("👁️ Columns")
                              .VisibleColumnsOnly();
                    })

                    // Column Configuration
                    .ConfigureColumns(columns =>
                    {
                        columns.Column(col => col.Target(0).Title("ID").Width("60px").Type(DataTablesColumnType.Numeric).ClassName("text-center"));
                        columns.Column(col => col.Target(1).Title("Employee Name").Width("150px").Type(DataTablesColumnType.String));
                        columns.Column(col => col.Target(2).Title("Department").Width("120px").Type(DataTablesColumnType.String));
                        columns.Column(col => col.Target(3).Title("Salary").Width("100px").Type(DataTablesColumnType.Currency).ClassName("text-end"));
                        columns.Column(col => col.Target(4).Title("Hire Date").Width("120px").Type(DataTablesColumnType.Date));
                        columns.Column(col => col.Target(5).Title("Email").Width("200px").Type(DataTablesColumnType.String));
                        columns.Column(col => col.Target(6).Title("Status").Width("80px").ClassName("text-center"));

                        // Make ID column non-orderable and non-searchable for demo
                        columns.DisableOrdering(0);
                        columns.DisableSearching(5); // Email column
                    })

                    // Default ordering by Name
                    .DefaultOrder(1, "asc")

                    // Row Grouping by Department
                    .EnableRowGrouping(2, rowGroup =>
                    {
                        rowGroup.ClassName = "group-header";
                    })

                    // Search Builder
                    .EnableSearchBuilder(searchBuilder =>
                    {
                        searchBuilder.Enable = true;
                        searchBuilder.Logic = "AND";
                        searchBuilder.Conditions = 3;
                    })

                    // Search Panes
                    .EnableSearchPanes(searchPanes =>
                    {
                        searchPanes.Enable = true;
                        searchPanes.Layout = "columns-3";
                        searchPanes.Threshold = 0.5;
                        searchPanes.ViewTotal = true;
                    })

                    // Localization
                    .Localize(lang =>
                    {
                        lang.Search = "🔍 Filter employees:";
                        lang.LengthMenu = "Show _MENU_ employees per page";
                        lang.Info = "Showing _START_ to _END_ of _TOTAL_ employees";
                        lang.InfoEmpty = "No employees found";
                        lang.InfoFiltered = "(filtered from _MAX_ total employees)";
                        lang.Processing = "Loading employee data...";
                        lang.ZeroRecords = "No matching employees found";
                        lang.Paginate = new DataTablesPaginate
                        {
                            First = "⏮️ First",
                            Last = "⏭️ Last",
                            Next = "▶️ Next",
                            Previous = "◀️ Previous"
                        };
                    })

                    // Custom DOM layout with all features
                    .DomLayout("Bfrtip") // B=buttons, f=filter, r=processing, t=table, i=info, p=pagination

                    // Additional configuration
                    .Configure(options =>
                    {
                        options.Processing = true;
                        options.DeferRender = true;
                        options.AutoWidth = false;
                    });
            });

            // Second table - Simple comparison
            page.Divider("Simple DataTable for Comparison");

            page.DataTable(employees.Take(5), table =>
            {
                table.Style(BootStrapTableStyle.Striped)
                     .EnablePaging(10)
                     .EnableSearching()
                     .EnableOrdering()
                     .EnableExport(DataTablesExportFormat.Excel, DataTablesExportFormat.CSV, DataTablesExportFormat.Copy);
            });

            // Third table - Column-specific features demo
            page.Divider("Column-Specific Features Demo");

            page.DataTable(employees.Take(8), table =>
            {
                table.Style(BootStrapTableStyle.Hover)
                     .EnablePaging(5)
                     .ConfigureColumns(columns =>
                     {
                         // Hide ID column
                         columns.HideColumns(0);

                         // Set specific widths
                         columns.SetWidth(1, "200px"); // Name
                         columns.SetWidth(2, "150px"); // Department
                         columns.SetWidth(3, "120px"); // Salary

                         // Set data types
                         columns.SetType(3, DataTablesColumnType.Currency);
                         columns.SetType(4, DataTablesColumnType.Date);

                         // Add CSS classes
                         columns.AddClass(3, "text-end fw-bold"); // Salary
                         columns.AddClass(6, "text-center"); // Status

                         // Disable ordering on email
                         columns.DisableOrdering(5);
                     })
                     .DefaultOrder(4, "desc") // Order by hire date descending
                     .EnableExport(DataTablesExportFormat.PDF, DataTablesExportFormat.Print);
            });

            // Fourth table - Advanced search features
            page.Divider("Advanced Search Features");

            page.DataTable(employees, table =>
            {
                table.Style(BootStrapTableStyle.Borders)
                     .EnablePaging(8)
                     .EnableSearchBuilder(builder =>
                     {
                         builder.Enable = true;
                         builder.Logic = "OR";
                         builder.Conditions = 2;
                         builder.Greyscale = false;
                     })
                     .EnableSearchPanes(panes =>
                     {
                         panes.Enable = true;
                         panes.Layout = "columns-2";
                         panes.CascadePanes = true;
                         panes.ViewTotal = true;
                         panes.Threshold = 0.3;
                     })
                     .DomLayout("QSfrtip"); // Q=SearchBuilder, S=SearchPanes, f=filter, r=processing, t=table, i=info, p=pagination
            });

            // Add code examples section at the end
            page.Divider("📚 How to Use - Code Examples");
            page.Text("Here are the code examples showing how to create these DataTables:")
                .Style(TablerTextStyle.Muted);

            page.CSharpCode(@"
// Feature-Rich DataTable Configuration
page.DataTable(employees, table => {
    table
        .Style(BootStrapTableStyle.Striped)
        .Style(BootStrapTableStyle.Hover)
        .EnablePaging(pageLength: 5, lengthMenu: new[] { 5, 10, 25, 50, 100 })
        .EnableSearching()
        .EnableOrdering()
        .EnableStateSaving()
        .EnableResponsive()
        .EnableFixedHeader(headerOffset: 50)
        .EnableSelection(""multiple"")
        .Scrolling(scrollY: ""400px"", scrollX: true, scrollCollapse: true)
        .ConfigureExport(export => {
            export.Excel(""📊 Excel"", ""employees_report"", ""Employee Report"")
                  .CSV(""📄 CSV"", ""employees_data"")
                  .PDF(""📋 PDF"", ""employees_list"", ""Company Employee List"");
        })
        .ConfigureColumns(columns => {
            columns.Column(col => col.Target(0).Title(""ID"").Width(""60px"").Type(DataTablesColumnType.Numeric));
            columns.Column(col => col.Target(1).Title(""Employee Name"").Width(""150px""));
            columns.Column(col => col.Target(3).Title(""Salary"").Type(DataTablesColumnType.Currency));
        });
});", config => config
                .SetTitle("Advanced DataTable Configuration")
                .EnableLineNumbers()
                .EnableCopyButton()
                .OkaidiaTheme());

            // Feature-Rich Configuration
            page.H2("🚀 Feature-Rich Configuration");
            page.Text("Here's how to create a DataTable with all advanced features enabled:");

            page.CSharpCode(@"
page.DataTable(employees, table => {
    table
        // Styling
        .Style(BootStrapTableStyle.Striped)
        .Style(BootStrapTableStyle.Hover)
        .Style(BootStrapTableStyle.Borders)

        // Basic Features
        .EnablePaging(pageLength: 5, lengthMenu: new[] { 5, 10, 25, 50, 100 })
        .EnableSearching()
        .EnableOrdering()
        .PagingType(DataTablesPagingType.FullNumbers)

        // Advanced Features
        .EnableStateSaving()
        .EnableResponsive()
        .EnableFixedHeader(headerOffset: 50)
        .EnableSelection(""multiple"")
        .Scrolling(scrollY: ""400px"", scrollX: true, scrollCollapse: true);
});", config => config
                .SetTitle("Advanced DataTable Configuration")
                .EnableLineNumbers()
                .EnableCopyButton()
                .SetMaxHeight("400px")
                .OkaidiaTheme());

            // Export Configuration
            page.H3("📊 Export Configuration");
            page.Text("Configure export functionality with custom options:");

            page.CSharpCode(@"
table.ConfigureExport(export => {
    export.Excel(""📊 Excel"", ""employees_report"", ""Employee Report"")
          .CSV(""📄 CSV"", ""employees_data"")
          .PDF(""📋 PDF"", ""employees_list"", ""Company Employee List"")
          .Copy(""📋 Copy"")
          .Print(""🖨️ Print"")
          .ColumnVisibility(""👁️ Columns"")
          .VisibleColumnsOnly();
});", config => config
                .SetTitle("Export Configuration")
                .EnableLineNumbers()
                .EnableCopyButton()
                .TomorrowNightTheme());

            // Column Configuration
            page.H3("📋 Column Configuration");
            page.Text("Fine-tune individual columns with detailed configuration:");

            page.CSharpCode(@"
table.ConfigureColumns(columns => {
    columns.Column(col => col.Target(0).Title(""ID"").Width(""60px"").Type(DataTablesColumnType.Numeric).ClassName(""text-center""));
    columns.Column(col => col.Target(1).Title(""Employee Name"").Width(""150px"").Type(DataTablesColumnType.String));
    columns.Column(col => col.Target(2).Title(""Department"").Width(""120px"").Type(DataTablesColumnType.String));
    columns.Column(col => col.Target(3).Title(""Salary"").Width(""100px"").Type(DataTablesColumnType.Currency).ClassName(""text-end""));
    columns.Column(col => col.Target(4).Title(""Hire Date"").Width(""120px"").Type(DataTablesColumnType.Date));
    columns.Column(col => col.Target(5).Title(""Email"").Width(""200px"").Type(DataTablesColumnType.String));
    columns.Column(col => col.Target(6).Title(""Status"").Width(""80px"").ClassName(""text-center""));

    // Make ID column non-orderable and non-searchable for demo
    columns.DisableOrdering(0);
    columns.DisableSearching(5); // Email column
});", config => config
                .SetTitle("Column Configuration")
                .EnableLineNumbers()
                .EnableCopyButton()
                .SetMaxHeight("350px")
                .VsTheme());

            // Advanced Features
            page.H3("🔍 Advanced Search Features");
            page.Text("Enable advanced search capabilities:");

            page.CSharpCode(@"
table
    // Row Grouping by Department
    .EnableRowGrouping(2, rowGroup => {
        rowGroup.ClassName = ""group-header"";
    })

    // Search Builder
    .EnableSearchBuilder(searchBuilder => {
        searchBuilder.Enable = true;
        searchBuilder.Logic = ""AND"";
        searchBuilder.Conditions = 3;
    })

    // Search Panes
    .EnableSearchPanes(searchPanes => {
        searchPanes.Enable = true;
        searchPanes.Layout = ""columns-3"";
        searchPanes.Threshold = 0.5;
        searchPanes.ViewTotal = true;
    });", config => config
                .SetTitle("Advanced Search Configuration")
                .EnableLineNumbers()
                .EnableCopyButton()
                .GitHubTheme());

            // Localization
            page.H3("🌐 Localization");
            page.Text("Customize text and labels for better user experience:");

            page.CSharpCode(@"
table.Localize(lang => {
    lang.Search = ""🔍 Filter employees:"";
    lang.LengthMenu = ""Show _MENU_ employees per page"";
    lang.Info = ""Showing _START_ to _END_ of _TOTAL_ employees"";
    lang.InfoEmpty = ""No employees found"";
    lang.InfoFiltered = ""(filtered from _MAX_ total employees)"";
    lang.Processing = ""Loading employee data..."";
    lang.ZeroRecords = ""No matching employees found"";
    lang.Paginate = new DataTablesPaginate {
        First = ""⏮️ First"",
        Last = ""⏭️ Last"",
        Next = ""▶️ Next"",
        Previous = ""◀️ Previous""
    };
});", config => config
                .SetTitle("Localization Configuration")
                .EnableLineNumbers()
                .EnableCopyButton()
                .DarkTheme());

            // Simple Configuration Examples
            page.H2("⚡ Simple Configuration Examples");

            page.H3("Basic DataTable");
            page.Text("Simple DataTable with essential features:");

            page.CSharpCode(@"
page.DataTable(employees, table => {
    table.Style(BootStrapTableStyle.Striped)
         .EnablePaging(10)
         .EnableSearching()
         .EnableOrdering()
         .EnableExport(DataTablesExportFormat.Excel, DataTablesExportFormat.CSV, DataTablesExportFormat.Copy);
});", config => config
                .SetTitle("Basic Configuration")
                .EnableLineNumbers()
                .EnableCopyButton()
                .GitHubTheme());

            page.H3("Column-Specific Features");
            page.Text("Focus on column-specific configurations:");

            page.CSharpCode(@"
page.DataTable(employees, table => {
    table.Style(BootStrapTableStyle.Hover)
         .EnablePaging(5)
         .ConfigureColumns(columns => {
             // Hide ID column
             columns.HideColumns(0);

             // Set specific widths
             columns.SetWidth(1, ""200px""); // Name
             columns.SetWidth(2, ""150px""); // Department
             columns.SetWidth(3, ""120px""); // Salary

             // Set data types
             columns.SetType(3, DataTablesColumnType.Currency);
             columns.SetType(4, DataTablesColumnType.Date);

             // Add CSS classes
             columns.AddClass(3, ""text-end fw-bold""); // Salary
             columns.AddClass(6, ""text-center""); // Status

             // Disable ordering on email
             columns.DisableOrdering(5);
         })
         .DefaultOrder(4, ""desc"") // Order by hire date descending
         .EnableExport(DataTablesExportFormat.PDF, DataTablesExportFormat.Print);
});", config => config
                .SetTitle("Column-Specific Configuration")
                .EnableLineNumbers()
                .EnableCopyButton()
                .SetMaxHeight("400px")
                .OkaidiaTheme());

            page.H3("Advanced Search Configuration");
            page.Text("Complex search and filtering setup:");

            page.CSharpCode(@"
page.DataTable(employees, table => {
    table.Style(BootStrapTableStyle.Borders)
         .EnablePaging(8)
         .EnableSearchBuilder(builder => {
             builder.Enable = true;
             builder.Logic = ""OR"";
             builder.Conditions = 2;
             builder.Greyscale = false;
         })
         .EnableSearchPanes(panes => {
             panes.Enable = true;
             panes.Layout = ""columns-2"";
             panes.CascadePanes = true;
             panes.ViewTotal = true;
             panes.Threshold = 0.3;
         })
         .DomLayout(""QSfrtip""); // Q=SearchBuilder, S=SearchPanes, f=filter, r=processing, t=table, i=info, p=pagination
});", config => config
                .SetTitle("Advanced Search Configuration")
                .EnableLineNumbers()
                .EnableCopyButton()
                .SetMaxHeight("350px")
                .TomorrowNightTheme());

            // Performance Tips
            page.H2("⚡ Performance Tips");
            page.Text("Optimize your DataTables for better performance:");

            page.CSharpCode(@"
// ✅ For large datasets, use JavaScript rendering
table.EnableJavaScriptRendering()
     .Configure(options => {
         options.Processing = true;     // Show loading indicator
         options.DeferRender = true;   // Render rows only when needed
         options.AutoWidth = false;    // Disable automatic width calculation
     });

// ✅ Use scrolling instead of pagination for very large datasets
table.Scrolling(scrollY: ""400px"", scrollX: true, scrollCollapse: true);

// ✅ Enable state saving for better user experience
table.EnableStateSaving();

// ✅ Use global configuration to avoid repetition
document.Configuration.DataTables.EnableDeferredRendering = true;
document.Configuration.DataTables.DefaultRenderMode = DataTablesRenderMode.Auto;", config => config
                .SetTitle("Performance Optimization")
                .EnableLineNumbers()
                .EnableCopyButton()
                .SetMaxHeight("300px")
                .VsTheme());
        });

        document.Save("AdvancedDataTablesDemo.html", openInBrowser);

        // Console output
        Console.WriteLine("🚀 Advanced DataTables Demo created successfully!");
        Console.WriteLine("✨ Features demonstrated:");
        Console.WriteLine("   📊 Export to Excel, CSV, PDF with custom options");
        Console.WriteLine("   🔍 Advanced search builder with multiple conditions");
        Console.WriteLine("   📱 Responsive design with fixed headers");
        Console.WriteLine("   👁️ Column visibility controls");
        Console.WriteLine("   🔄 Row grouping by department");
        Console.WriteLine("   📋 Search panes for filtering");
        Console.WriteLine("   🎨 Custom styling and localization");
        Console.WriteLine("   ⚡ State saving and performance optimizations");
        Console.WriteLine("");
        Console.WriteLine("🔧 Fluent API examples:");
        Console.WriteLine("   • .EnableExport(Excel, CSV, PDF)");
        Console.WriteLine("   • .ConfigureColumns(c => c.SetType(3, Currency))");
        Console.WriteLine("   • .EnableSearchBuilder(b => b.Logic = \"AND\")");
        Console.WriteLine("   • .EnableRowGrouping(2, rg => rg.ClassName = \"group\")");
        Console.WriteLine("   • .Localize(l => l.Search = \"🔍 Filter:\")");
    }
}