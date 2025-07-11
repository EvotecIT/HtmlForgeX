using System;
using System.Text;

namespace HtmlForgeX;

public class MermaidDiagram : Element {
    public string Id { get; set; }
    private readonly StringBuilder _builder = new();
    private MermaidDiagramType _type = MermaidDiagramType.Flowchart;
    private MermaidFlowDirection _direction = MermaidFlowDirection.TopDown;

    public MermaidDiagram() {
        Id = GlobalStorage.GenerateRandomId("mermaid");
    }

    protected internal override void RegisterLibraries() {
        Document?.Configuration.Libraries.TryAdd(Libraries.Mermaid, 0);
    }

    public MermaidDiagram AddLine(string line) {
        AddLines(line);
        return this;
    }

    public MermaidDiagram AddLines(string code) {
        foreach (var part in code.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)) {
            _builder.AppendLine(part);
        }
        return this;
    }

    public MermaidDiagram Code(string code) {
        _builder.Clear();
        AddLines(code);
        return this;
    }

    public MermaidDiagram SetType(MermaidDiagramType type, MermaidFlowDirection direction = MermaidFlowDirection.TopDown) {
        _type = type;
        _direction = direction;
        return this;
    }

    public MermaidDiagram AddNode(string id, string label) {
        _builder.AppendLine($"{id}[{label}]");
        return this;
    }

    public MermaidDiagram AddLink(string from, string to, string? text = null) {
        var link = text == null ? $"{from} --> {to}" : $"{from} -- {text} --> {to}";
        _builder.AppendLine(link);
        return this;
    }

    public override string ToString() {
        var divTag = new HtmlTag("div").Id(Id);
        var sb = new StringBuilder();
        static string Dir(MermaidFlowDirection d) => d switch {
            MermaidFlowDirection.LeftRight => "LR",
            MermaidFlowDirection.BottomTop => "BT",
            MermaidFlowDirection.RightLeft => "RL",
            _ => "TD"
        };

        sb.AppendLine(_type switch {
            MermaidDiagramType.SequenceDiagram => "sequenceDiagram",
            MermaidDiagramType.Gantt => "gantt",
            MermaidDiagramType.ClassDiagram => "classDiagram",
            MermaidDiagramType.GitGraph => "gitGraph",
            MermaidDiagramType.ErDiagram => "erDiagram",
            _ => $"flowchart {Dir(_direction)}"
        });
        sb.Append(_builder);
        var code = sb.ToString().Replace("\\", "\\\\").Replace("\"", "\"\"");
        code = code.Replace("\n", "\\n");
        var scriptTag = new HtmlTag("script").Value($@"
            mermaid.mermaidAPI.render('{Id}_svg', ""{code}"", function(svgCode) {{
                document.getElementById('{Id}').innerHTML = svgCode;
            }});
        ");
        return divTag + scriptTag.ToString();
    }
}
