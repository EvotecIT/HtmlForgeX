using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Fixed Header configuration for DataTables
/// </summary>
public class DataTablesFixedHeader {
    /// <summary>Enable/disable fixed header</summary>
    [JsonPropertyName("enable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enable { get; set; }

    /// <summary>Header offset from top</summary>
    [JsonPropertyName("headerOffset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? HeaderOffset { get; set; }

    /// <summary>Footer offset from bottom</summary>
    [JsonPropertyName("footerOffset")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? FooterOffset { get; set; }

    /// <summary>Enable/disable fixed footer</summary>
    [JsonPropertyName("footer")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Footer { get; set; }
}