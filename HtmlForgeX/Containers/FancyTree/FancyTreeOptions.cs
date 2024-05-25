namespace HtmlForgeX;

public class FancyTreeOptions {
    [JsonPropertyName("extensions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string> Extensions { get; set; } = new List<string>();

    [JsonPropertyName("selectMode")]
    public int SelectMode { get; set; }

    [JsonPropertyName("autoScroll")]
    public bool AutoScroll { get; set; }

    [JsonPropertyName("minExpandLevel")]
    public int MinExpandLevel { get; set; }

    [JsonPropertyName("source")]
    public List<FancyTreeNode> Source { get; set; }
}