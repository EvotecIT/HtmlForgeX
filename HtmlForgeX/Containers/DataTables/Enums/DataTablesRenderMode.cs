namespace HtmlForgeX;

/// <summary>
/// Rendering modes for DataTables content
/// </summary>
public enum DataTablesRenderMode
{
    /// <summary>Traditional HTML rendering (default) - slower but more compatible</summary>
    Html,

    /// <summary>JavaScript rendering - faster performance, better for large datasets</summary>
    JavaScript,

    /// <summary>Automatic mode - uses JavaScript for large datasets, HTML for small ones</summary>
    Auto
}