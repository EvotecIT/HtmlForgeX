using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestVisNetworkLambda
{
    [TestMethod]
    public void VisNetwork_LambdaOverloads_ShouldRender()
    {
        using var doc = new Document();

        doc.Body.Add(element =>
        {
            element.DiagramNetwork(network =>
            {
                network.AddNode(node => node.WithId(1).WithLabel("Node1"));
                network.AddNode(2, node => node.WithLabel("Node2"));
                network.AddEdge(edge => edge.WithConnection(1, 2).WithLabel("Edge1"));
                network.AddEdge(1, 2, edge => edge.WithLabel("Edge2"));
            });
        });

        var html = doc.ToString();

        Assert.IsTrue(html.Contains("Node1"), "Should contain first node");
        Assert.IsTrue(html.Contains("Node2"), "Should contain second node");
        Assert.IsTrue(html.Contains("Edge1"), "Should contain first edge label");
        Assert.IsTrue(html.Contains("Edge2"), "Should contain second edge label");
    }
}

