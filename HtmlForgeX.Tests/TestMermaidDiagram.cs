using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestMermaidDiagram {
    [TestMethod]
    public void MermaidDiagram_GeneratesHtml() {
        var doc = new Document();
        doc.Body.Add(element => {
            element.DiagramMermaid(diagram => {
                diagram.SetType(MermaidDiagramType.Flowchart);
                diagram.AddNode("A", "Start");
                diagram.AddNode("B", "End");
                diagram.AddLink("A", "B");
            });

            element.DiagramMermaid("sequenceDiagram\nAlice->>Bob: Hi");
        });

        var html = doc.ToString();
        Assert.IsTrue(html.Contains("mermaidAPI"));
        Assert.IsTrue(doc.Configuration.Libraries.ContainsKey(Libraries.Mermaid));
    }
}
