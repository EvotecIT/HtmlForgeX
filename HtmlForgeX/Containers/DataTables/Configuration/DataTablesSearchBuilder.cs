using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Search Builder configuration for DataTables
/// </summary>
public class DataTablesSearchBuilder
{
    /// <summary>Enable/disable search builder</summary>
    [JsonPropertyName("enable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enable { get; set; }

    /// <summary>Default number of condition groups</summary>
    [JsonPropertyName("conditions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Conditions { get; set; }

    /// <summary>Enable/disable group logic (AND/OR)</summary>
    [JsonPropertyName("logic")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Logic { get; set; }

    /// <summary>Greyscale styling</summary>
    [JsonPropertyName("greyscale")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Greyscale { get; set; }

    /// <summary>Pre-defined search criteria</summary>
    [JsonPropertyName("preDefined")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public object? PreDefined { get; set; }
}