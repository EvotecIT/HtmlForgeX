using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class ApexThemeOptions {
    [JsonPropertyName("mode")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApexThemeMode? Mode { get; set; }

    public ApexThemeOptions ModeValue(ApexThemeMode mode) {
        Mode = mode;
        return this;
    }
}
