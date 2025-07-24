using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Row grouping configuration for DataTables
/// </summary>
public class DataTablesRowGroup {
    /// <summary>Column index to group by</summary>
    [JsonPropertyName("dataSrc")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? DataSrc { get; set; }

    /// <summary>Start render function for group header</summary>
    [JsonPropertyName("startRender")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StartRender { get; set; }

    /// <summary>End render function for group footer</summary>
    [JsonPropertyName("endRender")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? EndRender { get; set; }

    /// <summary>CSS class for group rows</summary>
    [JsonPropertyName("className")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ClassName { get; set; }

    /// <summary>Enable/disable group collapsing</summary>
    [JsonPropertyName("emptyDataGroup")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? EmptyDataGroup { get; set; }
}