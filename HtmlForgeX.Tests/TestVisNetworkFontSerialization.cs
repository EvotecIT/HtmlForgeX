using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestVisNetworkFontSerialization {
    
    [TestMethod]
    public void VisNetworkFontOptions_SerializesMultiCorrectly() {
        var font = new VisNetworkFontOptions {
            Multi = VisNetworkMulti.Html
        };
        
        var json = JsonSerializer.Serialize(font);
        Assert.IsTrue(json.Contains("\"multi\":\"html\""), $"Should serialize multi as 'html'. Got: {json}");
        
        font.Multi = VisNetworkMulti.Markdown;
        json = JsonSerializer.Serialize(font);
        Assert.IsTrue(json.Contains("\"multi\":\"markdown\""), $"Should serialize multi as 'markdown'. Got: {json}");
    }
    
    [TestMethod]
    public void VisNetworkNode_WithHtmlLabel_SetsMulti() {
        var node = new VisNetworkNodeOptions()
            .WithId(1)
            .WithHtmlLabel("<b>Test</b>");
            
        Assert.IsNotNull(node.Font, "Font should be created");
        Assert.AreEqual(VisNetworkMulti.Html, node.Font.Multi, "Multi should be set to Html");
        
        var json = JsonSerializer.Serialize(node);
        Assert.IsTrue(json.Contains("\"multi\":\"html\""), $"Should contain multi:html. Got: {json}");
    }
    
    [TestMethod]
    public void VisNetworkEdge_WithMarkdownLabel_SetsMulti() {
        var edge = new VisNetworkEdgeOptions()
            .WithConnection(1, 2)
            .WithMarkdownLabel("**Bold**");
            
        Assert.IsNotNull(edge.Font, "Font should be created");
        Assert.AreEqual(VisNetworkMulti.Markdown, edge.Font.Multi, "Multi should be set to Markdown");
        
        var json = JsonSerializer.Serialize(edge);
        Assert.IsTrue(json.Contains("\"multi\":\"markdown\""), $"Should contain multi:markdown. Got: {json}");
    }
}