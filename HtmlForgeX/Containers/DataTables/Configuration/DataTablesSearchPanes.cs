using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Search Panes configuration for DataTables
/// </summary>
public class DataTablesSearchPanes
{
    /// <summary>Enable/disable search panes</summary>
    [JsonPropertyName("enable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enable { get; set; }

    /// <summary>Layout configuration</summary>
    [JsonPropertyName("layout")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Layout { get; set; }

    /// <summary>Threshold for showing search panes</summary>
    [JsonPropertyName("threshold")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Threshold { get; set; }

    /// <summary>Enable cascading panes</summary>
    [JsonPropertyName("cascadePanes")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? CascadePanes { get; set; }

    /// <summary>Clear message text</summary>
    [JsonPropertyName("clearMessage")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ClearMessage { get; set; }

    /// <summary>Collapse message text</summary>
    [JsonPropertyName("collapse")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Collapse { get; set; }

    /// <summary>Enable view total</summary>
    [JsonPropertyName("viewTotal")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ViewTotal { get; set; }
}