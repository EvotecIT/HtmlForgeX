using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class ApexTooltipOptions {
    [JsonPropertyName("enabled")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? Enabled { get; set; }

    public ApexTooltipOptions Enable(bool enabled) {
        Enabled = enabled;
        return this;
    }
}
