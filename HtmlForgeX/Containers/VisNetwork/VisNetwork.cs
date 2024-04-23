using System.Text.Json;

namespace HtmlForgeX;

public class VisNetwork : Element {
    public string Id { get; set; }
    public List<object> Nodes { get; set; } = new List<object>();
    public List<object> Edges { get; set; } = new List<object>();
    public Dictionary<string, object> Options { get; set; } = new Dictionary<string, object>();

    public bool EnableLoadingBar { get; set; }

    public VisNetwork() {
        GlobalStorage.Libraries.Add(Libraries.VisNetwork);
        GlobalStorage.Libraries.Add(Libraries.VisNetworkLoadingBar);
        Id = GlobalStorage.GenerateRandomId("Diagram");
    }

    public VisNetwork AddNode(object node) {
        Nodes.Add(node);
        return this;
    }

    public VisNetwork AddEdge(object edge) {
        Edges.Add(edge);
        return this;
    }

    public VisNetwork SetOption(string key, object value) {
        Options[key] = value;
        return this;
    }

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

        var nodesJson = JsonSerializer.Serialize(Nodes);
        var edgesJson = JsonSerializer.Serialize(Edges);
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
