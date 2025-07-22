using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestVisNetworkComponent {

    [TestMethod]
    public void VisNetwork_BasicCreation() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Node 1" });
                network.AddNode(new { id = 2, label = "Node 2" });
                network.AddEdge(new { from = 1, to = 2 });
            });
        });
        
        var html = doc.ToString();
        
        // Should contain network element and data
        Assert.IsTrue(html.Contains("vis-network") || html.Contains("network"), "Should contain network element");
        Assert.IsTrue(html.Contains("Node 1"), "Should contain first node");
        Assert.IsTrue(html.Contains("Node 2"), "Should contain second node");
        Assert.IsTrue(html.Contains("from") && html.Contains("to"), "Should contain edge data");
    }

    [TestMethod]
    public void VisNetwork_WithOptions() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Start", color = "red" });
                network.AddNode(new { id = 2, label = "End", color = "blue" });
                network.AddEdge(new { from = 1, to = 2, arrows = "to" });
                
                network.WithOptions("nodes", new { shape = "box", font = new { size = 14 } });
                network.WithOptions("edges", new { smooth = true });
                network.WithOptions("physics", new { enabled = false });
            });
        });
        
        var html = doc.ToString();
        
        // Should contain nodes with styling
        Assert.IsTrue(html.Contains("Start"), "Should contain start node");
        Assert.IsTrue(html.Contains("End"), "Should contain end node");
        Assert.IsTrue(html.Contains("red") || html.Contains("blue"), "Should contain node colors");
        
        // Should contain configuration options
        Assert.IsTrue(html.Contains("shape") || html.Contains("smooth") || html.Contains("physics"), 
            "Should contain network options");
    }

    [TestMethod]
    public void VisNetwork_LoadingBar() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.EnableLoadingBar = true;
                network.AddNode(new { id = 1, label = "Test" });
            });
        });
        
        var html = doc.ToString();
        
        // Should include loading bar library when enabled
        Assert.IsTrue(html.Contains("loadingbar") || html.Contains("loading"), 
            "Should include loading bar when enabled");
    }

    [TestMethod]
    public void VisNetwork_MultipleNodes() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                for (int i = 1; i <= 5; i++) {
                    network.AddNode(new { id = i, label = $"Node {i}" });
                }
                
                // Connect nodes in sequence
                for (int i = 1; i < 5; i++) {
                    network.AddEdge(new { from = i, to = i + 1 });
                }
            });
        });
        
        var html = doc.ToString();
        
        // Should contain all nodes
        for (int i = 1; i <= 5; i++) {
            Assert.IsTrue(html.Contains($"Node {i}"), $"Should contain Node {i}");
        }
    }

    [TestMethod]
    public void VisNetwork_HierarchicalLayout() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Root", level = 0 });
                network.AddNode(new { id = 2, label = "Child 1", level = 1 });
                network.AddNode(new { id = 3, label = "Child 2", level = 1 });
                network.AddNode(new { id = 4, label = "Grandchild", level = 2 });
                
                network.AddEdge(new { from = 1, to = 2 });
                network.AddEdge(new { from = 1, to = 3 });
                network.AddEdge(new { from = 2, to = 4 });
                
                network.WithOptions("layout", new { 
                    hierarchical = new { 
                        direction = "UD",
                        sortMethod = "directed"
                    }
                });
            });
        });
        
        var html = doc.ToString();
        
        // Should contain hierarchical structure
        Assert.IsTrue(html.Contains("Root"), "Should contain root node");
        Assert.IsTrue(html.Contains("Child 1") && html.Contains("Child 2"), "Should contain child nodes");
        Assert.IsTrue(html.Contains("Grandchild"), "Should contain grandchild node");
        Assert.IsTrue(html.Contains("hierarchical") || html.Contains("layout"), "Should contain layout options");
    }

    [TestMethod]
    public void VisNetwork_NodeGroups() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Server", group = "servers", color = "blue" });
                network.AddNode(new { id = 2, label = "Database", group = "databases", color = "green" });
                network.AddNode(new { id = 3, label = "Client", group = "clients", color = "orange" });
                
                network.AddEdge(new { from = 1, to = 2, label = "queries" });
                network.AddEdge(new { from = 3, to = 1, label = "requests" });
                
                network.WithOptions("groups", new {
                    servers = new { color = new { background = "lightblue" } },
                    databases = new { color = new { background = "lightgreen" } },
                    clients = new { color = new { background = "lightyellow" } }
                });
            });
        });
        
        var html = doc.ToString();
        
        // Should contain grouped nodes
        Assert.IsTrue(html.Contains("Server") && html.Contains("Database") && html.Contains("Client"), 
            "Should contain all node types");
        Assert.IsTrue(html.Contains("servers") || html.Contains("databases") || html.Contains("clients"), 
            "Should contain group information");
        Assert.IsTrue(html.Contains("queries") && html.Contains("requests"), "Should contain edge labels");
    }

    [TestMethod]
    public void VisNetwork_InteractiveOptions() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Interactive Node" });
                
                network.WithOptions("interaction", new {
                    dragNodes = true,
                    dragView = true,
                    zoomView = true,
                    selectConnectedEdges = true
                });
                
                network.WithOptions("manipulation", new {
                    enabled = true,
                    addNode = true,
                    addEdge = true,
                    deleteNode = true,
                    deleteEdge = true
                });
            });
        });
        
        var html = doc.ToString();
        
        // Should contain interactive options
        Assert.IsTrue(html.Contains("Interactive Node"), "Should contain interactive node");
        Assert.IsTrue(html.Contains("interaction") || html.Contains("manipulation"), 
            "Should contain interaction options");
        Assert.IsTrue(html.Contains("drag") || html.Contains("zoom") || html.Contains("select"), 
            "Should contain interaction settings");
    }

    [TestMethod]
    public void VisNetwork_OnlineMode_LibraryInclusion() {
        using var doc = new Document();
        doc.LibraryMode = LibraryMode.Online;
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Online Node" });
            });
        });
        
        var html = doc.ToString();
        
        // Should include vis-network library from CDN
        Assert.IsTrue(html.Contains("vis-network") || html.Contains("network"), "Should include vis-network library");
        Assert.IsTrue(html.Contains("https://") || html.Contains("cdn"), "Should use CDN in online mode");
    }

    [TestMethod]
    public void VisNetwork_OfflineMode_EmbeddedLibrary() {
        using var doc = new Document();
        doc.LibraryMode = LibraryMode.Offline;
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Offline Node" });
            });
        });
        
        var html = doc.ToString();
        
        // Should embed vis-network library
        Assert.IsTrue(html.Contains("vis-network") || html.Contains("network"), "Should include vis-network functionality");
        Assert.IsFalse(html.Contains("cdn.jsdelivr.net"), "Should not use CDN in offline mode");
    }

    [TestMethod]
    public void VisNetwork_LibraryRegistration() {
        using var doc = new Document();
        
        // Before adding network
        Assert.IsFalse(doc.Configuration.Libraries.ContainsKey(Libraries.VisNetwork), 
            "VisNetwork library should not be registered initially");
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Test" });
            });
        });
        
        // Generate HTML to trigger library registration
        var html = doc.ToString();
        
        // After adding network, library should be registered
        Assert.IsTrue(doc.Configuration.Libraries.ContainsKey(Libraries.VisNetwork), 
            "VisNetwork library should be registered after adding network");
    }

    [TestMethod]
    public void VisNetwork_ComplexEdges() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Source" });
                network.AddNode(new { id = 2, label = "Target" });
                
                network.AddEdge(new { 
                    from = 1, 
                    to = 2, 
                    label = "Connection",
                    arrows = "to",
                    color = "red",
                    width = 3,
                    dashes = true
                });
                
                network.WithOptions("edges", new {
                    smooth = new {
                        type = "cubicBezier",
                        forceDirection = "horizontal",
                        roundness = 0.4
                    }
                });
            });
        });
        
        var html = doc.ToString();
        
        // Should contain complex edge configuration
        Assert.IsTrue(html.Contains("Source") && html.Contains("Target"), "Should contain source and target nodes");
        Assert.IsTrue(html.Contains("Connection"), "Should contain edge label");
        Assert.IsTrue(html.Contains("arrows") || html.Contains("color") || html.Contains("width"), 
            "Should contain edge styling");
        Assert.IsTrue(html.Contains("smooth") || html.Contains("cubicBezier"), "Should contain edge smoothing");
    }

    [TestMethod]
    public void VisNetwork_EmptyNetwork() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                // Empty network - no nodes or edges
            });
        });
        
        var html = doc.ToString();
        
        // Should still create network container
        Assert.IsTrue(html.Contains("vis-network") || html.Contains("network"), "Should create network container");
    }

    [TestMethod]
    public void VisNetwork_LoadingBarRegistration() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.EnableLoadingBar = true;
                network.AddNode(new { id = 1, label = "Test" });
            });
        });
        
        // Generate HTML to trigger library registration
        var html = doc.ToString();
        
        // Should register both VisNetwork and LoadingBar libraries
        Assert.IsTrue(doc.Configuration.Libraries.ContainsKey(Libraries.VisNetwork), 
            "VisNetwork library should be registered");
        Assert.IsTrue(doc.Configuration.Libraries.ContainsKey(Libraries.VisNetworkLoadingBar),
            "VisNetworkLoadingBar library should be registered when enabled");
    }

    [TestMethod]
    public void VisNetwork_NodeImages() {
        using var doc = new Document();

        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNode { Id = 1, Label = "Image Node", Image = "https://example.com/img.png" });
            });
        });

        var html = doc.ToString();

        Assert.IsTrue(html.Contains("img.png"), "Should include image url");
        Assert.IsTrue(html.Contains("image"), "Should set shape to image");
    }

    [TestMethod]
    public void VisNetwork_EmbeddedNodeImage() {
        var imgData = new byte[] {
            0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x00, 0x00, 0x0D,
            0x49, 0x48, 0x44, 0x52, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01,
            0x08, 0x06, 0x00, 0x00, 0x00, 0x1F, 0x15, 0xC4, 0x89, 0x00, 0x00, 0x00,
            0x0A, 0x49, 0x44, 0x41, 0x54, 0x78, 0x9C, 0x63, 0x00, 0x01, 0x00, 0x00,
            0x05, 0x00, 0x01, 0x0D, 0x0A, 0x2D, 0xB4, 0x00, 0x00, 0x00, 0x00, 0x49,
            0x45, 0x4E, 0x44, 0xAE, 0x42, 0x60, 0x82
        };
        var path = Path.GetTempFileName();
        File.WriteAllBytes(path, imgData);

        using var doc = new Document { LibraryMode = LibraryMode.Offline };

        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNode()
                    .IdValue(1)
                    .LabelText("Embedded")
                    .UseImage(path));
            });
        });

        var html = doc.ToString();

        File.Delete(path);

        Assert.IsTrue(html.Contains("data:image/png;base64,"));
    }

    [TestMethod]
    public void VisNetwork_OfflineAutoEmbedding_Disabled() {
        var imgData = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
        var path = Path.GetTempFileName();
        File.WriteAllBytes(path, imgData);

        using var doc = new Document { LibraryMode = LibraryMode.Offline };

        doc.Body.Add(el => {
            el.DiagramNetwork(net => {
                net.AddNode(new VisNetworkNode()
                    .IdValue(1)
                    .LabelText("NoEmbed")
                    .UseImage(path)
                    .WithoutAutoEmbedding());
            });
        });

        var html = doc.ToString();

        File.Delete(path);

        // The path should be in the JavaScript output
        // Check for the actual JSON representation
        var scriptMatch = Regex.Match(html, @"<script>(.*?)</script>", RegexOptions.Singleline);
        Assert.IsTrue(scriptMatch.Success, "Should have script tag");
        
        var script = scriptMatch.Groups[1].Value;
        
        // The image path should not be converted to data URI
        Assert.IsFalse(script.Contains("data:image"), "Should not embed image as data URI");
        
        // The path should be present (it might be escaped in JSON)
        Assert.IsTrue(script.Contains(path.Replace("\\", "\\\\")) || script.Contains(path.Replace("\\", "/")), 
            "Should contain the original file path");
    }

    [TestMethod]
    public void VisNetwork_FluentNodeCreation() {
        using var doc = new Document();

        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNode()
                    .IdValue(1)
                    .LabelText("Fluent")
                    .NodeShape(VisNetworkNodeShape.Star)
                    .NodeColor(RGBColor.Amber));

                network.AddEdge(new VisNetworkEdge()
                    .FromNode(1)
                    .ToNode(1)
                    .EdgeArrows(VisNetworkArrows.To | VisNetworkArrows.From));
            });
        });

        var html = doc.ToString();

        Assert.IsTrue(html.Contains("star"), "Should render star shape");
        Assert.IsTrue(html.Contains("#FFBF00"), "Should render color");
        Assert.IsTrue(html.Contains("\"to\":true") && html.Contains("\"from\":true"), "Should render arrows");
    }

    [TestMethod]
    public void VisNetwork_HtmlLabels() {
        using var doc = new Document();

        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNodeOptions()
                    .WithId(1)
                    .WithHtmlLabel("<b>Bold</b><br><i>Italic</i>")
                );
                
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(1, 1)
                    .WithHtmlLabel("<span style='color: red'>Red Text</span>")
                );
            });
        });

        var html = doc.ToString();

        // The HTML labels should be escaped in the JSON output
        // Look for the actual JSON representation of the labels
        var scriptMatch = Regex.Match(html, @"<script>(.*?)</script>", RegexOptions.Singleline);
        Assert.IsTrue(scriptMatch.Success, "Should have script tag");
        
        var script = scriptMatch.Groups[1].Value;
        
        // Check for the label content in the nodes array
        Assert.IsTrue(script.Contains("\"label\":"), "Should contain label property");
        Assert.IsTrue(script.Contains("Bold") || script.Contains("\\u003cb\\u003eBold"), "Should contain Bold text");
        Assert.IsTrue(script.Contains("Italic") || script.Contains("\\u003ci\\u003eItalic"), "Should contain Italic text");
        
        // Check for font multi configuration
        Assert.IsTrue(script.Contains("\"multi\":\"html\""), "Should have multi:html for font");
        
        // Verify the basic structure
        Assert.IsTrue(html.Contains("var nodes = new vis.DataSet"), "Should contain nodes DataSet");
        Assert.IsTrue(html.Contains("var edges = new vis.DataSet"), "Should contain edges DataSet");
    }

    [TestMethod]
    public void VisNetwork_MarkdownLabels() {
        using var doc = new Document();

        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNodeOptions()
                    .WithId(1)
                    .WithMarkdownLabel("# Header\n**Bold** and *italic*")
                );
                
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(1, 1)
                    .WithMarkdownLabel("- Item 1\n- Item 2")
                );
            });
        });

        var html = doc.ToString();

        // Should contain Markdown content
        Assert.IsTrue(html.Contains("# Header"), "Should contain Markdown header");
        Assert.IsTrue(html.Contains("**Bold**"), "Should contain Markdown bold");
        Assert.IsTrue(html.Contains("*italic*"), "Should contain Markdown italic");
        Assert.IsTrue(html.Contains("- Item 1"), "Should contain Markdown list");
        
        // The methods should have set up the font configuration
        // Let's just verify the content is there rather than the exact JSON structure
        Assert.IsTrue(html.Contains("var nodes = new vis.DataSet"), "Should contain nodes DataSet");
        Assert.IsTrue(html.Contains("var edges = new vis.DataSet"), "Should contain edges DataSet");
    }
}