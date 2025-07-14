using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class ApexGridPadding {
    [JsonPropertyName("top")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Top { get; set; }

    [JsonPropertyName("right")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Right { get; set; }

    [JsonPropertyName("bottom")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Bottom { get; set; }

    [JsonPropertyName("left")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public int? Left { get; set; }

    public ApexGridPadding TopPadding(int value) {
        Top = value;
        return this;
    }

    public ApexGridPadding RightPadding(int value) {
        Right = value;
        return this;
    }

    public ApexGridPadding BottomPadding(int value) {
        Bottom = value;
        return this;
    }

    public ApexGridPadding LeftPadding(int value) {
        Left = value;
        return this;
    }

    public ApexGridPadding All(int value) {
        Top = value;
        Right = value;
        Bottom = value;
        Left = value;
        return this;
    }
}
