namespace HtmlForgeX;

/// <summary>
/// Configuration options for <see cref="FancyTree"/>.
/// </summary>
public class FancyTreeOptions {
    /// <summary>
    /// Gets the list of additional extensions to enable.
    /// </summary>
    [JsonPropertyName("extensions")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public List<string> Extensions { get; set; } = new List<string>();

    /// <summary>
    /// Gets or sets the selection mode for the tree.
    /// </summary>
    [JsonPropertyName("selectMode")]
    public int SelectMode { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the tree should auto scroll.
    /// </summary>
    [JsonPropertyName("autoScroll")]
    public bool AutoScroll { get; set; }

    /// <summary>
    /// Gets or sets the initial tree expand level.
    /// </summary>
    [JsonPropertyName("minExpandLevel")]
    public int MinExpandLevel { get; set; }

    /// <summary>
    /// Gets or sets the node data used to build the tree.
    /// </summary>
    [JsonPropertyName("source")]
    public List<FancyTreeNode> Source { get; set; } = new List<FancyTreeNode>();
}