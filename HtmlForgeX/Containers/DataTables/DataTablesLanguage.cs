using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Localization strings for DataTables user interface elements.
/// </summary>
public class DataTablesLanguage
{
    /// <summary>Label for the search input.</summary>
    [JsonPropertyName("search")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Search { get; set; }

    /// <summary>Text for the page length menu.</summary>
    [JsonPropertyName("lengthMenu")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LengthMenu { get; set; }

    /// <summary>Information text.</summary>
    [JsonPropertyName("info")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Info { get; set; }

    /// <summary>Text shown when no records are present.</summary>
    [JsonPropertyName("infoEmpty")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? InfoEmpty { get; set; }

    /// <summary>Text for filtered results information.</summary>
    [JsonPropertyName("infoFiltered")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? InfoFiltered { get; set; }

    /// <summary>Loading message.</summary>
    [JsonPropertyName("loadingRecords")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? LoadingRecords { get; set; }

    /// <summary>Processing message.</summary>
    [JsonPropertyName("processing")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Processing { get; set; }

    /// <summary>Text shown when no matching records are found.</summary>
    [JsonPropertyName("zeroRecords")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? ZeroRecords { get; set; }

    /// <summary>Text used for pagination buttons.</summary>
    [JsonPropertyName("paginate")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public DataTablesPaginate? Paginate { get; set; }
}

