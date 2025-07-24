using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Fixed Columns configuration for DataTables
/// </summary>
public class DataTablesFixedColumns {
    /// <summary>Number of columns to fix on the left</summary>
    [JsonPropertyName("leftColumns")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? LeftColumns { get; set; }

    /// <summary>Number of columns to fix on the right</summary>
    [JsonPropertyName("rightColumns")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? RightColumns { get; set; }

    /// <summary>Height matching for fixed columns</summary>
    [JsonPropertyName("heightMatch")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? HeightMatch { get; set; }
}