using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class ApexHeatmapOptions {
    [JsonPropertyName("radius")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public double? Radius { get; set; }

    public ApexHeatmapOptions RadiusValue(double radius) {
        Radius = radius;
        return this;
    }
}
