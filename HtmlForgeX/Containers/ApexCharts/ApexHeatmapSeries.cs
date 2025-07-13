using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class ApexHeatmapSeries {
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("data")]
    public List<ApexHeatmapData> Data { get; set; } = new();
}
