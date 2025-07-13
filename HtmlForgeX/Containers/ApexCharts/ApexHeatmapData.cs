using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class ApexHeatmapData {
    [JsonPropertyName("x")]
    public string X { get; set; } = string.Empty;

    [JsonPropertyName("y")]
    public double Y { get; set; }
}
