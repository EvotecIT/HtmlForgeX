using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Text for pagination navigation in DataTables.
/// </summary>
public class DataTablesPaginate
{
    /// <summary>Text for the first page button.</summary>
    [JsonPropertyName("first")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? First { get; set; }

    /// <summary>Text for the last page button.</summary>
    [JsonPropertyName("last")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Last { get; set; }

    /// <summary>Text for the next page button.</summary>
    [JsonPropertyName("next")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Next { get; set; }

    /// <summary>Text for the previous page button.</summary>
    [JsonPropertyName("previous")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Previous { get; set; }
}

