using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class DataTablesOptions
{
    [JsonPropertyName("pageLength")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? PageLength { get; set; }

    [JsonPropertyName("lengthMenu")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int[]? LengthMenu { get; set; }

    [JsonPropertyName("stateSave")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? StateSave { get; set; }

    [JsonPropertyName("scrollY")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ScrollY { get; set; }

    [JsonPropertyName("scrollCollapse")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ScrollCollapse { get; set; }

    [JsonPropertyName("autoWidth")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? AutoWidth { get; set; }

    [JsonPropertyName("deferRender")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? DeferRender { get; set; }

    [JsonPropertyName("processing")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Processing { get; set; }

    [JsonPropertyName("serverSide")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? ServerSide { get; set; }

    [JsonPropertyName("language")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DataTablesLanguage? Language { get; set; }

    [JsonPropertyName("dom")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Dom { get; set; }
}

