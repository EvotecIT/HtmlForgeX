using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class ApexLegendOptions {
    [JsonPropertyName("show")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Show { get; set; }

    public ApexLegendOptions ShowLegend(bool value) {
        Show = value;
        return this;
    }
}
