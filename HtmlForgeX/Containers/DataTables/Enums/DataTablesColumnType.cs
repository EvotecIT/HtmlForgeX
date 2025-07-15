namespace HtmlForgeX;

/// <summary>
/// Column data types for DataTables
/// </summary>
public enum DataTablesColumnType
{
    /// <summary>String/text data</summary>
    String,

    /// <summary>Numeric data</summary>
    Numeric,

    /// <summary>Date data</summary>
    Date,

    /// <summary>HTML content</summary>
    Html,

    /// <summary>Currency values</summary>
    Currency,

    /// <summary>Percentage values</summary>
    Percentage,

    /// <summary>File size values</summary>
    FileSize,

    /// <summary>IP address values</summary>
    IpAddress,

    /// <summary>Natural sorting (alphanumeric)</summary>
    Natural
}