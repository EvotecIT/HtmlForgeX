namespace HtmlForgeX;

/// <summary>
/// Export formats available for DataTables
/// </summary>
public enum DataTablesExportFormat {
    /// <summary>Export to Excel format</summary>
    Excel,

    /// <summary>Export to CSV format</summary>
    CSV,

    /// <summary>Export to PDF format</summary>
    PDF,

    /// <summary>Copy to clipboard</summary>
    Copy,

    /// <summary>Print the table</summary>
    Print
}