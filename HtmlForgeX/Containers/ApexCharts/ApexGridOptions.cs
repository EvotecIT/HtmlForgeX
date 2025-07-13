using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class ApexGridOptions {
    [JsonPropertyName("padding")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ApexGridPadding? Padding { get; set; }

    public ApexGridOptions PaddingOptions(Action<ApexGridPadding> configure) {
        Padding ??= new ApexGridPadding();
        configure(Padding);
        return this;
    }
}
