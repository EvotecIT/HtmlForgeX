using System.Text.Json;
using System.Linq;

namespace HtmlForgeX;

/// <summary>
/// Container for building interactive diagrams using the Vis Network library.
/// </summary>
public class VisNetwork : Element {
    /// <summary>
    /// Gets or sets the unique identifier of the diagram container element.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets the collection of nodes to render.
    /// </summary>
    public List<object> Nodes { get; set; } = new List<object>();

    /// <summary>
    /// Gets the collection of edges connecting nodes.
    /// </summary>
    public List<object> Edges { get; set; } = new List<object>();

    /// <summary>
    /// Gets a dictionary of additional options passed directly to Vis Network.
    /// </summary>
    public Dictionary<string, object> Options { get; set; } = new Dictionary<string, object>();

    /// <summary>
    /// Gets or sets a value indicating whether the loading bar should be displayed.
    /// </summary>
    public bool EnableLoadingBar { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="VisNetwork"/> class.
    /// </summary>
    public VisNetwork() {
        // Libraries will be registered via RegisterLibraries method
        Id = GlobalStorage.GenerateRandomId("Diagram");
    }

    /// <summary>
    /// Registers the required libraries for VisNetwork.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.Configuration.Libraries.TryAdd(Libraries.VisNetwork, 0);
        Document?.Configuration.Libraries.TryAdd(Libraries.VisNetworkLoadingBar, 0);
    }

    /// <summary>
    /// Called when the element is added to a <see cref="Document"/>.
    /// Ensures that offline embedding rules are applied to all nodes.
    /// </summary>
    protected internal override void OnAddedToDocument() {
        foreach (var nodeObj in Nodes) {
            if (nodeObj is VisNetworkNode node) {
                node.ApplyDocumentConfiguration(Document!);
            }
        }
    }

    /// <summary>
    /// Adds a raw node object to the diagram.
    /// </summary>
    /// <param name="node">Object containing node definition.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddNode(object node) {
        Nodes.Add(node);
        return this;
    }

    /// <summary>
    /// Adds a strongly typed <see cref="VisNetworkNode"/> to the diagram.
    /// </summary>
    /// <param name="node">Node to add.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddNode(VisNetworkNode node) {
        if (Document != null) {
            node.ApplyDocumentConfiguration(Document);
        }
        Nodes.Add(node);
        return this;
    }

    /// <summary>
    /// Adds a raw edge object to the diagram.
    /// </summary>
    /// <param name="edge">Object containing edge definition.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddEdge(object edge) {
        Edges.Add(edge);
        return this;
    }

    /// <summary>
    /// Adds a <see cref="VisNetworkEdge"/> to the diagram.
    /// </summary>
    /// <param name="edge">Edge to add.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork AddEdge(VisNetworkEdge edge) {
        Edges.Add(edge);
        return this;
    }

    /// <summary>
    /// Sets an option that will be passed to the underlying Vis Network instance.
    /// </summary>
    /// <param name="key">Option name.</param>
    /// <param name="value">Option value.</param>
    /// <returns>The current <see cref="VisNetwork"/> instance.</returns>
    public VisNetwork SetOption(string key, object value) {
        Options[key] = value;
        return this;
    }

    /// <summary>
    /// Generates the HTML and JavaScript required to render the diagram.
    /// </summary>
    /// <returns>HTML string representing the network diagram.</returns>
    public override string ToString() {
        HtmlTag divTag;
        if (EnableLoadingBar) {
            divTag = new HtmlTag("div").Class("diagramWrapper")
                .Value(new HtmlTag("div").Class("diagram").Style("position", "relative")
                    .Value(new HtmlTag("div").Class("diagram diagramObject").Style("position", "absolute").Id(Id)))
                .Value(new HtmlTag("div").Id($"{Id}-diagramLoadingBar").Class("diagramLoadingBar")
                    .Value(new HtmlTag("div").Class("diagramOuterBorder")
                        .Value(new HtmlTag("div").Id($"{Id}-diagramText").Class("diagramText").Value("0%"))
                        .Value(new HtmlTag("div").Class("diagramBorder")
                            .Value(new HtmlTag("div").Id($"{Id}-diagramBar").Class("diagramBar")))));
        } else {
            divTag = new HtmlTag("div").Class("diagram").Style("position", "relative")
                        .Value(new HtmlTag("div").Class("diagram diagramObject").Style("position", "absolute").Id(Id));
        }

        foreach (var n in Nodes) {
            if (n is VisNetworkNode vn) {
                vn.ApplyDocumentConfiguration(Document!);
            }
        }
        var nodeObjects = Nodes.Select(n => n is VisNetworkNode vn ? vn.ToDictionary() : n).ToList();

        var edgeObjects = Edges.Select(e => e is VisNetworkEdge ve ? ve.ToDictionary() : e).ToList();

        var nodesJson = JsonSerializer.Serialize(nodeObjects);
        var edgesJson = JsonSerializer.Serialize(edgeObjects);
        var optionsJson = JsonSerializer.Serialize(Options);

        var scriptTag = new HtmlTag("script").Value($@"
            var nodes = new vis.DataSet({nodesJson});
            var edges = new vis.DataSet({edgesJson});
            var container = document.getElementById('{Id}');
            var data = {{
                nodes: nodes,
                edges: edges
            }};
            var options = {optionsJson};
            var network = loadDiagramWithFonts(container, data, options, '{Id}', {EnableLoadingBar.ToString().ToLower()}, false);
            diagramTracker['{Id}'] = network;
        ");

        return divTag + scriptTag.ToString();
    }
}
