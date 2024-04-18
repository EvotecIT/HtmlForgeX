using System.Text.Json.Serialization;

namespace HtmlForgeX;

public class FancyTreeNode {
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NodeTitle { get; set; }

    [JsonPropertyName("icon")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NodeIcon { get; set; }

    [JsonPropertyName("folder")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? NodeFolder { get; set; }

    [JsonPropertyName("children")]
    public List<FancyTreeNode> Nodes { get; set; } = new List<FancyTreeNode>();

    public FancyTreeNode() { }

    public FancyTreeNode(string title, string icon = "", bool folder = false) {
        NodeTitle = title;
        NodeIcon = icon;
        NodeFolder = folder;
    }

    public FancyTreeNode Title(string title) {
        NodeTitle = title;
        return this;
    }

    public FancyTreeNode Icon(string icon) {
        NodeIcon = icon;
        return this;
    }

    public FancyTreeNode AddNode(FancyTreeNode node) {
        Nodes.Add(node);
        return node;
    }

    public FancyTreeNode AddNode(string title, string icon = null, bool nodeFolder = false) {
        var node = new FancyTreeNode { NodeTitle = title, NodeIcon = icon, NodeFolder = nodeFolder };
        Nodes.Add(node);
        return node;
    }

    public FancyTreeNode AddNode(Action<FancyTreeNode> config) {
        var node = new FancyTreeNode();
        config(node);
        Nodes.Add(node);
        return node;
    }
}