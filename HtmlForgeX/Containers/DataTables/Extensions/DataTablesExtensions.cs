namespace HtmlForgeX;

/// <summary>
/// Extension methods for enhanced DataTables functionality
/// </summary>
public static class DataTablesExtensions
{
    /// <summary>
    /// Quick setup for common DataTables configurations
    /// </summary>
    public static DataTablesTable QuickSetup(this DataTablesTable table,
        int pageLength = 10,
        bool enableExports = true,
        bool enableSearch = true,
        bool responsive = true)
    {
        table.EnablePaging(pageLength)
             .EnableSearching(enableSearch)
             .EnableOrdering()
             .Style(BootStrapTableStyle.Striped)
             .Style(BootStrapTableStyle.Hover);

        if (enableExports)
        {
            table.EnableExport(DataTablesExportFormat.Excel, DataTablesExportFormat.CSV, DataTablesExportFormat.Copy);
        }

        if (responsive)
        {
            table.EnableResponsive();
        }

        return table;
    }

    /// <summary>
    /// Enterprise setup with all advanced features
    /// </summary>
    public static DataTablesTable EnterpriseSetup(this DataTablesTable table,
        int pageLength = 25,
        bool enableRowGrouping = false,
        int groupByColumn = 0)
    {
        table.EnablePaging(pageLength, new[] { 10, 25, 50, 100 })
             .EnableSearching()
             .EnableOrdering()
             .EnableStateSaving()
             .EnableResponsive()
             .EnableFixedHeader()
             .PagingType(DataTablesPagingType.FullNumbers)
             .Style(BootStrapTableStyle.Striped)
             .Style(BootStrapTableStyle.Hover)
             .Style(BootStrapTableStyle.Borders);

        // Advanced features
        table.EnableSearchBuilder(builder =>
             {
                 builder.Enable = true;
                 builder.Logic = "AND";
                 builder.Conditions = 3;
             })
             .EnableSearchPanes(panes =>
             {
                 panes.Enable = true;
                 panes.Layout = "columns-3";
                 panes.ViewTotal = true;
             });

        // Export functionality
        table.ConfigureExport(export =>
        {
            export.Excel("📊 Excel", "enterprise_report", "Enterprise Data Report")
                  .CSV("📄 CSV", "enterprise_data")
                  .PDF("📋 PDF", "enterprise_document", "Enterprise Report")
                  .Copy("📋 Copy")
                  .Print("🖨️ Print")
                  .ColumnVisibility("👁️ Columns");
        });

        // Row grouping if requested
        if (enableRowGrouping)
        {
            table.EnableRowGrouping(groupByColumn);
        }

        // Performance optimizations
        table.Configure(options =>
        {
            options.Processing = true;
            options.DeferRender = true;
        });

        return table;
    }

    /// <summary>
    /// Mobile-optimized setup
    /// </summary>
    public static DataTablesTable MobileOptimized(this DataTablesTable table, int pageLength = 5)
    {
        return table.EnablePaging(pageLength, new[] { 5, 10, 15 })
                   .EnableSearching()
                   .EnableResponsive()
                   .PagingType(DataTablesPagingType.Simple)
                   .Style(BootStrapTableStyle.Striped)
                   .Scrolling(scrollX: true, scrollCollapse: true)
                   .Configure(options =>
                   {
                       options.AutoWidth = false;
                       options.DeferRender = true;
                   });
    }

    /// <summary>
    /// Dashboard setup for summary tables
    /// </summary>
    public static DataTablesTable DashboardSetup(this DataTablesTable table,
        bool enableExports = false,
        string scrollHeight = "300px")
    {
        table.EnablePaging(15)
             .EnableSearching()
             .EnableOrdering()
             .Style(BootStrapTableStyle.Hover)
             .Scrolling(scrollY: scrollHeight, scrollCollapse: true)
             .Configure(options =>
             {
                 options.Processing = false; // Faster for dashboards
                 options.AutoWidth = true;
             });

        if (enableExports)
        {
            table.EnableExport(DataTablesExportFormat.Excel, DataTablesExportFormat.CSV);
        }

        return table;
    }

    /// <summary>
    /// Report setup with comprehensive export options
    /// </summary>
    public static DataTablesTable ReportSetup(this DataTablesTable table,
        string reportTitle = "Data Report",
        string filename = "report")
    {
        return table.EnablePaging(50, new[] { 25, 50, 100, -1 }) // -1 = All
                   .EnableSearching()
                   .EnableOrdering()
                   .EnableStateSaving()
                   .Style(BootStrapTableStyle.Striped)
                   .Style(BootStrapTableStyle.Borders)
                   .ConfigureExport(export =>
                   {
                       export.Excel($"📊 {reportTitle} (Excel)", $"{filename}_excel", reportTitle)
                             .CSV($"📄 {reportTitle} (CSV)", $"{filename}_csv")
                             .PDF($"📋 {reportTitle} (PDF)", $"{filename}_pdf", reportTitle)
                             .Copy("📋 Copy Data")
                             .Print($"🖨️ Print {reportTitle}")
                             .ColumnVisibility("👁️ Show/Hide Columns");
                   })
                   .Configure(options =>
                   {
                       options.Processing = true;
                       options.AutoWidth = false;
                   });
    }

    /// <summary>
    /// Analytics setup with search panes and grouping
    /// </summary>
    public static DataTablesTable AnalyticsSetup(this DataTablesTable table,
        int groupByColumn = -1,
        string searchPanesLayout = "columns-3")
    {
        table.EnablePaging(20)
             .EnableSearching()
             .EnableOrdering()
             .EnableStateSaving()
             .Style(BootStrapTableStyle.Striped)
             .Style(BootStrapTableStyle.Hover)
             .EnableSearchPanes(panes =>
             {
                 panes.Enable = true;
                 panes.Layout = searchPanesLayout;
                 panes.ViewTotal = true;
                 panes.CascadePanes = true;
             })
             .EnableSearchBuilder(builder =>
             {
                 builder.Enable = true;
                 builder.Logic = "AND";
                 builder.Conditions = 2;
             })
             .DomLayout("QSfrtip");

        if (groupByColumn >= 0)
        {
            table.EnableRowGrouping(groupByColumn);
        }

        return table;
    }

    /// <summary>
    /// Performance setup for large datasets
    /// </summary>
    public static DataTablesTable PerformanceSetup(this DataTablesTable table,
        string scrollHeight = "500px",
        bool serverSide = false)
    {
        return table.EnablePaging(100, new[] { 50, 100, 200 })
                   .EnableSearching()
                   .EnableOrdering()
                   .Scrolling(scrollY: scrollHeight, scrollCollapse: true, scrollX: true)
                   .Configure(options =>
                   {
                       options.Processing = true;
                       options.DeferRender = true;
                       options.AutoWidth = false;
                       options.ServerSide = serverSide;
                   });
    }
}