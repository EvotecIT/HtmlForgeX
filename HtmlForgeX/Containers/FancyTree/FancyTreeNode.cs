using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Represents a single node within a <see cref="FancyTree"/> control.
/// </summary>
public class FancyTreeNode {
    /// <summary>
    /// Display text for the node.
    /// </summary>
    [JsonPropertyName("title")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NodeTitle { get; set; }

    /// <summary>
    /// Name of the icon used for the node.
    /// </summary>
    [JsonPropertyName("icon")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? NodeIcon { get; set; }

    /// <summary>
    /// Gets or sets whether the node represents a folder.
    /// </summary>
    [JsonPropertyName("folder")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public bool? NodeFolder { get; set; }

    /// <summary>
    /// Child nodes contained under this node.
    /// </summary>
    [JsonPropertyName("children")]
    public List<FancyTreeNode> Nodes { get; set; } = new List<FancyTreeNode>();

    /// <summary>
    /// Initializes a new instance of the <see cref="FancyTreeNode"/> class.
    /// </summary>
    public FancyTreeNode() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="FancyTreeNode"/> class with values.
    /// </summary>
    /// <param name="title">Node title.</param>
    /// <param name="icon">Node icon.</param>
    /// <param name="folder">Indicates if the node is a folder.</param>
    public FancyTreeNode(string title, string icon = "", bool folder = false) {
        NodeTitle = title;
        NodeIcon = icon;
        NodeFolder = folder;
    }

    /// <summary>
    /// Sets the display title for the node.
    /// </summary>
    /// <param name="title">Title text.</param>
    /// <returns>The current <see cref="FancyTreeNode"/>.</returns>
    public FancyTreeNode Title(string title) {
        NodeTitle = title;
        return this;
    }

    /// <summary>
    /// Sets the icon for the node.
    /// </summary>
    /// <param name="icon">Icon name.</param>
    /// <returns>The current <see cref="FancyTreeNode"/>.</returns>
    public FancyTreeNode Icon(string icon) {
        NodeIcon = icon;
        return this;
    }

    /// <summary>
    /// Adds a child node.
    /// </summary>
    /// <param name="node">Node to add.</param>
    /// <returns>The added node.</returns>
    public FancyTreeNode AddNode(FancyTreeNode node) {
        Nodes.Add(node);
        return node;
    }

    /// <summary>
    /// Creates and adds a child node.
    /// </summary>
    /// <param name="title">Child title.</param>
    /// <param name="icon">Child icon.</param>
    /// <param name="nodeFolder">Whether the child is a folder.</param>
    /// <returns>The created node.</returns>
    public FancyTreeNode AddNode(string title, string icon = null, bool nodeFolder = false) {
        var node = new FancyTreeNode { NodeTitle = title, NodeIcon = icon, NodeFolder = nodeFolder };
        Nodes.Add(node);
        return node;
    }

    /// <summary>
    /// Creates and configures a child node using a callback.
    /// </summary>
    /// <param name="config">Configuration delegate.</param>
    /// <returns>The created node.</returns>
    public FancyTreeNode AddNode(Action<FancyTreeNode> config) {
        var node = new FancyTreeNode();
        config(node);
        Nodes.Add(node);
        return node;
    }
}