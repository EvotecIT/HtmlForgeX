using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestVisNetworkDebug {
    
    [TestMethod]
    public void Debug_VisNetwork_HtmlLabel_Output() {
        using var doc = new Document();

        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNodeOptions()
                    .WithId(1)
                    .WithHtmlLabel("<b>Test</b>")
                );
            });
        });

        var html = doc.ToString();
        
        // Find the nodes array in the output
        var nodesStart = html.IndexOf("var nodes = new vis.DataSet(");
        if (nodesStart > 0) {
            var nodesEnd = html.IndexOf(");", nodesStart);
            if (nodesEnd > 0) {
                var nodesJson = html.Substring(nodesStart + 29, nodesEnd - nodesStart - 29);
                Console.WriteLine("Nodes JSON:");
                Console.WriteLine(nodesJson);
                
                // Also write to test output
                TestContext.WriteLine("Nodes JSON:");
                TestContext.WriteLine(nodesJson);
            }
        }
        
        // This test always passes - it's just for debugging
        Assert.IsTrue(true);
    }
    
    public TestContext TestContext { get; set; }
}