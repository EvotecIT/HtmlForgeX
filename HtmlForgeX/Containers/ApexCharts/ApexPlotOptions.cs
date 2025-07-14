using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class ApexPlotOptions {
    [JsonPropertyName("heatmap")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApexHeatmapOptions? Heatmap { get; set; }

    public ApexPlotOptions HeatmapOptions(Action<ApexHeatmapOptions> configure) {
        Heatmap ??= new ApexHeatmapOptions();
        configure(Heatmap);
        return this;
    }
}
