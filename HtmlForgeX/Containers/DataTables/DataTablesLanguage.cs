using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class DataTablesLanguage
{
    [JsonPropertyName("search")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Search { get; set; }

    [JsonPropertyName("lengthMenu")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LengthMenu { get; set; }

    [JsonPropertyName("info")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Info { get; set; }

    [JsonPropertyName("infoEmpty")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? InfoEmpty { get; set; }

    [JsonPropertyName("infoFiltered")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? InfoFiltered { get; set; }

    [JsonPropertyName("loadingRecords")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LoadingRecords { get; set; }

    [JsonPropertyName("processing")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Processing { get; set; }

    [JsonPropertyName("zeroRecords")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ZeroRecords { get; set; }

    [JsonPropertyName("paginate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DataTablesPaginate? Paginate { get; set; }
}

