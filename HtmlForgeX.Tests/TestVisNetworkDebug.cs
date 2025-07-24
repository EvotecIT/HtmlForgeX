using System;
using System.Text.RegularExpressions;

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
                TestContext!.WriteLine("Nodes JSON:");
                TestContext!.WriteLine(nodesJson);
            }
        }

        // Let's also output the full HTML to understand the structure
        Console.WriteLine("\n=== FULL HTML OUTPUT ===");
        Console.WriteLine(html);
        TestContext!.WriteLine("\n=== FULL HTML OUTPUT ===");
        TestContext!.WriteLine(html);

        // This test always passes - it's just for debugging
        Assert.IsTrue(true);
    }

    public TestContext? TestContext { get; set; }

    [TestMethod]
    public void Debug_VisNetwork_ColorInherit_Output() {
        using var doc = new Document();

        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNodeOptions().WithId("A"));
                network.AddNode(new VisNetworkNodeOptions().WithId("B"));

                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection("A", "B")
                    .WithColor(colorOptions => colorOptions
                        .WithInherit(VisNetworkColorInherit.From)
                    )
                );
            });
        });

        var html = doc.ToString();

        // Find the script content
        var scriptMatch = Regex.Match(html, @"<script>(.*?)</script>", RegexOptions.Singleline);
        if (scriptMatch.Success) {
            var script = scriptMatch.Groups[1].Value;

            // Look for edges
            var edgesStart = script.IndexOf("var edges = new vis.DataSet(");
            if (edgesStart > 0) {
                var edgesEnd = script.IndexOf(");", edgesStart);
                if (edgesEnd > 0) {
                    var edgesJson = script.Substring(edgesStart + 29, edgesEnd - edgesStart - 29);
                    Console.WriteLine("Edges JSON:");
                    Console.WriteLine(edgesJson);
                    TestContext!.WriteLine("Edges JSON:");
                    TestContext!.WriteLine(edgesJson);
                }
            }
        }

        // This test always passes - it's just for debugging
        Assert.IsTrue(true);
    }
}