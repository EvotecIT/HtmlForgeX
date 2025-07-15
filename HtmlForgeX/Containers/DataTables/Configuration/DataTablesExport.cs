using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Export configuration for DataTables buttons
/// </summary>
public class DataTablesExport
{
    /// <summary>Export button text</summary>
    [JsonPropertyName("text")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Text { get; set; }

    /// <summary>Export format type</summary>
    [JsonPropertyName("extend")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Extend { get; set; }

    /// <summary>Filename for exported file</summary>
    [JsonPropertyName("filename")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Filename { get; set; }

    /// <summary>Title for exported document</summary>
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Title { get; set; }

    /// <summary>CSS class for the button</summary>
    [JsonPropertyName("className")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ClassName { get; set; }

    /// <summary>Export all rows or just visible ones</summary>
    [JsonPropertyName("exportOptions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DataTablesExportOptions? ExportOptions { get; set; }

    /// <summary>Custom action function name</summary>
    [JsonPropertyName("action")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Action { get; set; }
}

/// <summary>
/// Export options for controlling what data to export
/// </summary>
public class DataTablesExportOptions
{
    /// <summary>Which columns to export</summary>
    [JsonPropertyName("columns")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Columns { get; set; }

    /// <summary>Which rows to export</summary>
    [JsonPropertyName("rows")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Rows { get; set; }

    /// <summary>Modifier for export selection</summary>
    [JsonPropertyName("modifier")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? Modifier { get; set; }
}