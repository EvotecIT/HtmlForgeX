namespace HtmlForgeX;

/// <summary>
/// Global configuration settings for DataTables across the document
/// </summary>
public class DataTablesGlobalConfig {
    /// <summary>Default rendering mode for all DataTables in the document</summary>
    public DataTablesRenderMode DefaultRenderMode { get; set; } = DataTablesRenderMode.Html;

    /// <summary>Threshold for automatic mode - switch to JavaScript rendering when row count exceeds this</summary>
    public int AutoModeThreshold { get; set; } = 1000;

    /// <summary>Enable deferred rendering globally for better performance</summary>
    public bool EnableDeferredRendering { get; set; } = false;

    /// <summary>Enable processing indicator globally</summary>
    public bool EnableProcessingIndicator { get; set; } = true;

    /// <summary>Default page length for all tables</summary>
    public int DefaultPageLength { get; set; } = 25;

    /// <summary>Enable server-side processing globally</summary>
    public bool EnableServerSideProcessing { get; set; } = false;

    /// <summary>Enable debug mode for DataTables</summary>
    public bool DebugMode { get; set; } = false;

    /// <summary>Default column width for all columns</summary>
    public string? DefaultColumnWidth { get; set; }

    /// <summary>Default column type for all columns</summary>
    public DataTablesColumnType? DefaultColumnType { get; set; }

    /// <summary>Default column text alignment for all columns</summary>
    public DataTablesTextAlign? DefaultColumnAlignment { get; set; }

    /// <summary>Default column font weight for all columns</summary>
    public DataTablesFontWeight? DefaultColumnFontWeight { get; set; }

    /// <summary>Default column style for all columns</summary>
    public DataTablesColumnStyle? DefaultColumnStyle { get; set; }
}