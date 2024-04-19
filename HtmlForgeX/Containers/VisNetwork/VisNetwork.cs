using System.Text.Json;

namespace HtmlForgeX;

public class VisNetwork : HtmlElement {
    public string Id { get; set; }
    public List<object> Nodes { get; set; } = new List<object>();
    public List<object> Edges { get; set; } = new List<object>();
    public Dictionary<string, object> Options { get; set; } = new Dictionary<string, object>();

    public VisNetwork() {
        GlobalStorage.Libraries.Add(Libraries.VisNetwork);
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
        var divTag = new HtmlTag("div").Class("diagramWrapper")
            .Append(new HtmlTag("div").Class("diagram").Class("position:relative")
                .Append(new HtmlTag("div").Class("diagram diagramObject").Class("position:absolute").Id(Id)))
            .Append(new HtmlTag("div").Id($"{Id}-diagramLoadingBar").Class("diagramLoadingBar")
                .Append(new HtmlTag("div").Class("diagramOuterBorder")
                    .Append(new HtmlTag("div").Id($"{Id}-diagramText").Class("diagramText").SetValue("0%"))
                    .Append(new HtmlTag("div").Class("diagramBorder")
                        .Append(new HtmlTag("div").Id($"{Id}-diagramBar").Class("diagramBar")))));

        var nodesJson = JsonSerializer.Serialize(Nodes);
        var edgesJson = JsonSerializer.Serialize(Edges);
        var optionsJson = JsonSerializer.Serialize(Options);

        var scriptTag = new HtmlTag("script").SetValue($@"
            var nodes = new vis.DataSet({nodesJson});
            var edges = new vis.DataSet({edgesJson});
            var container = document.getElementById('{Id}');
            var data = {{
                nodes: nodes,
                edges: edges
            }};
            var options = {optionsJson};
            var network = loadDiagramWithFonts(container, data, options, '{Id}', true, false);
            diagramTracker['{Id}'] = network;
        ");

        return divTag + scriptTag.ToString();
    }
}
