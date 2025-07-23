using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestVisNetworkAttributes
{
    [TestMethod]
    public void VisNetwork_WithId_ShouldRenderIdAttribute()
    {
        using var doc = new Document();

        doc.Body.Add(element =>
        {
            element.DiagramNetwork(network =>
            {
                network.WithId("networkId");
                network.AddNode(new { id = 1, label = "A" });
            });
        });

        var html = doc.ToString();
        Assert.IsTrue(Regex.IsMatch(html, "<div class=\"diagram diagramObject\"[^>]*id=\"networkId\""), "ID attribute should be rendered on network container");
    }

    [TestMethod]
    public void VisNetwork_WithSize_ShouldRenderOptionsWidthAndHeight()
    {
        using var doc = new Document();

        doc.Body.Add(element =>
        {
            element.DiagramNetwork(network =>
            {
                network.WithId("sizeNetwork");
                network.WithSize("80%", "300px");
                network.AddNode(new { id = 1, label = "A" });
            });
        });

        var html = doc.ToString();
        var optionsMatch = Regex.Match(html, @"var options = ({[^}]+});");
        Assert.IsTrue(optionsMatch.Success, "Options object should be present");
        var optionsJson = optionsMatch.Groups[1].Value;
        Assert.IsTrue(optionsJson.Contains("\"width\":\"80%\""), "Width should be set in options");
        Assert.IsTrue(optionsJson.Contains("\"height\":\"300px\""), "Height should be set in options");
    }
}