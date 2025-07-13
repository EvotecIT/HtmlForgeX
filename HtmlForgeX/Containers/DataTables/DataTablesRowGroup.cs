using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class DataTablesRowGroup
{
    [JsonPropertyName("dataSrc")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? DataSrc { get; set; }

    [JsonPropertyName("startRender")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? StartRender { get; set; }

    [JsonPropertyName("endRender")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? EndRender { get; set; }

    [JsonPropertyName("enable")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enable { get; set; }
}
