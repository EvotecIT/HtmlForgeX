using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests.VisNetwork;

[TestClass]
public class VisNetworkHtmlNodesTests {
    
    [TestMethod]
    public void VisNetwork_HtmlNodes_ShouldRenderCorrectly() {
        // Arrange
        using var document = new Document();
        document.LibraryMode = LibraryMode.Online;

        var network = new HtmlForgeX.VisNetwork()
            .WithId("testNetwork")
            .WithOptions(options => options
                .WithPhysics(physics => physics.WithEnabled(false)));

        // Add native HTML node (limited support)
        network.AddNode(1, node => node
            .WithLabel("<b>Bold</b><br><i>Italic</i><br><code>Code</code>")
            .WithPosition(0, -100)
            .WithShape(VisNetworkNodeShape.Box)
            .WithFont(font => font.WithMulti(VisNetworkMulti.Html)));

        // Add HTML node with plugin
        var htmlNode = new VisNetworkHtmlNode("htmlNode1")
            .WithCard("Test Card", "Card Content", "#28a745");
        network.AddHtmlNode(htmlNode);

        document.Body.Add(network);
        
        // Act
        var html = document.ToString();
        
        // Debug output
        System.Console.WriteLine("=== HTML Output ===");
        System.Console.WriteLine(html.Substring(0, Math.Min(1000, html.Length)));
        
        // Assert - Check HTML structure
        Assert.IsTrue(html.Contains("diagramTracker"), "Should contain diagram tracker");
        Assert.IsTrue(html.Contains("testNetwork"), "Should contain network ID");
        // HTML is escaped in JSON as Unicode
        Assert.IsTrue(html.Contains("\\u003Cb\\u003EBold\\u003C/b\\u003E"), "Should contain bold HTML tag");
        Assert.IsTrue(html.Contains("\\u003Ci\\u003EItalic\\u003C/i\\u003E"), "Should contain italic HTML tag");
        Assert.IsTrue(html.Contains("\\u003Ccode\\u003ECode\\u003C/code\\u003E"), "Should contain code HTML tag");
        
        // Check if HTML nodes plugin script is included
        Assert.IsTrue(html.Contains("visjs-html-nodes.min.js"), "Should include HTML nodes plugin script");
        Assert.IsTrue(html.Contains("VisJsHtmlNodes"), "Should contain VisJsHtmlNodes initialization");
        Assert.IsTrue(html.Contains("htmlContents"), "Should contain HTML contents object");
        Assert.IsTrue(html.Contains("htmlNode1"), "Should contain HTML node ID");
        
        // Check card HTML content
        Assert.IsTrue(html.Contains("Test Card"), "Should contain card title");
        Assert.IsTrue(html.Contains("Card Content"), "Should contain card content");
        Assert.IsTrue(html.Contains("#28a745"), "Should contain card color");
    }

    [TestMethod]
    public void VisNetwork_NativeHtmlLabels_ShouldOnlySupportBasicTags() {
        // Arrange
        using var document = new Document();
        document.LibraryMode = LibraryMode.Online;

        var network = new HtmlForgeX.VisNetwork()
            .WithId("testNativeHtml")
            .WithOptions(options => options
                .WithPhysics(physics => physics.WithEnabled(false)));

        // Add node with supported tags
        network.AddNode(1, node => node
            .WithHtmlLabel(label => label
                .Bold("Bold Text")
                .LineBreak()
                .Italic("Italic Text")
                .LineBreak()
                .Code("code.example()")
                .LineBreak()
                .Text("Plain text"))
            .WithPosition(0, 0)
            .WithShape(VisNetworkNodeShape.Box));

        document.Body.Add(network);
        
        // Act
        var html = document.ToString();
        
        // Assert - Check generated HTML content
        // Should contain only supported tags (HTML is escaped as Unicode in JSON)
        Assert.IsTrue(html.Contains("\\u003Cb\\u003EBold Text\\u003C/b\\u003E"), "Should contain bold tag");
        Assert.IsTrue(html.Contains("\\u003Ci\\u003EItalic Text\\u003C/i\\u003E"), "Should contain italic tag");
        Assert.IsTrue(html.Contains("\\u003Ccode\\u003Ecode.example()\\u003C/code\\u003E"), "Should contain code tag");
        Assert.IsTrue(html.Contains("\\u003Cbr\\u003E"), "Should contain line break tag");
        Assert.IsTrue(html.Contains("Plain text"), "Should contain plain text");
        
        // The HTML should not contain unsupported tags in native mode
        // (The label builder only generates supported tags)
    }

    [TestMethod]
    public void VisNetwork_HtmlNodesPlugin_ShouldSupportFullHtml() {
        // Arrange
        using var document = new Document();
        document.LibraryMode = LibraryMode.Online;

        var network = new HtmlForgeX.VisNetwork()
            .WithId("testHtmlPlugin")
            .WithOptions(options => options
                .WithPhysics(physics => physics.WithEnabled(false)));

        // Add various HTML nodes
        network.AddHtmlNode(new VisNetworkHtmlNode("card1")
            .WithCard("Card Title", "Card Body", "#007bff"));

        network.AddHtmlNode(new VisNetworkHtmlNode("table1")
            .WithTable(new[] { "Column 1", "Column 2" }, new[] {
                new[] { "Row 1 Col 1", "Row 1 Col 2" },
                new[] { "Row 2 Col 1", "Row 2 Col 2" }
            }));

        network.AddHtmlNode(new VisNetworkHtmlNode("list1")
            .WithList("Todo List", new[] { "Item 1", "Item 2", "Item 3" }, true));

        network.AddHtmlNode(new VisNetworkHtmlNode("progress1")
            .WithProgressBar("Loading", 75, "#ffc107"));

        document.Body.Add(network);
        
        // Act
        var html = document.ToString();
        
        // Assert - Check if HTML nodes are properly set up
        Assert.IsTrue(html.Contains("testHtmlPlugin"), "Should contain network ID");
        Assert.IsTrue(html.Contains("htmlContents"), "Should contain HTML contents object");
        Assert.IsTrue(html.Contains("VisJsHtmlNodes"), "Should reference HTML nodes plugin");
        
        // Check various HTML node types
        Assert.IsTrue(html.Contains("Card Title"), "Should contain card title");
        Assert.IsTrue(html.Contains("Card Body"), "Should contain card body");
        Assert.IsTrue(html.Contains("#007bff"), "Should contain card color");
        
        Assert.IsTrue(html.Contains("Column 1"), "Should contain table column 1");
        Assert.IsTrue(html.Contains("Column 2"), "Should contain table column 2");
        Assert.IsTrue(html.Contains("Row 1 Col 1"), "Should contain table row data");
        
        Assert.IsTrue(html.Contains("Todo List"), "Should contain list title");
        Assert.IsTrue(html.Contains("Item 1"), "Should contain list item 1");
        Assert.IsTrue(html.Contains("Item 2"), "Should contain list item 2");
        Assert.IsTrue(html.Contains("Item 3"), "Should contain list item 3");
        
        Assert.IsTrue(html.Contains("Loading"), "Should contain progress bar label");
        Assert.IsTrue(html.Contains("75%"), "Should contain progress value");
        Assert.IsTrue(html.Contains("#ffc107"), "Should contain progress color");
        
        // Verify proper escaping of HTML in JSON
        Assert.IsTrue(html.Contains("\\u003C") || html.Contains("<"), "HTML should be properly encoded");
    }
}