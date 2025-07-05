using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestVisNetworkComponent {

    [TestMethod]
    public void VisNetwork_BasicCreation() {
        var doc = new Document();
        
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
        var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Start", color = "red" });
                network.AddNode(new { id = 2, label = "End", color = "blue" });
                network.AddEdge(new { from = 1, to = 2, arrows = "to" });
                
                network.SetOption("nodes", new { shape = "box", font = new { size = 14 } });
                network.SetOption("edges", new { smooth = true });
                network.SetOption("physics", new { enabled = false });
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
        var doc = new Document();
        
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
        var doc = new Document();
        
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
        var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Root", level = 0 });
                network.AddNode(new { id = 2, label = "Child 1", level = 1 });
                network.AddNode(new { id = 3, label = "Child 2", level = 1 });
                network.AddNode(new { id = 4, label = "Grandchild", level = 2 });
                
                network.AddEdge(new { from = 1, to = 2 });
                network.AddEdge(new { from = 1, to = 3 });
                network.AddEdge(new { from = 2, to = 4 });
                
                network.SetOption("layout", new { 
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
        var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Server", group = "servers", color = "blue" });
                network.AddNode(new { id = 2, label = "Database", group = "databases", color = "green" });
                network.AddNode(new { id = 3, label = "Client", group = "clients", color = "orange" });
                
                network.AddEdge(new { from = 1, to = 2, label = "queries" });
                network.AddEdge(new { from = 3, to = 1, label = "requests" });
                
                network.SetOption("groups", new {
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
        var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Interactive Node" });
                
                network.SetOption("interaction", new {
                    dragNodes = true,
                    dragView = true,
                    zoomView = true,
                    selectConnectedEdges = true
                });
                
                network.SetOption("manipulation", new {
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
        var doc = new Document();
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
        var doc = new Document();
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
        var doc = new Document();
        
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
        var doc = new Document();
        
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
                
                network.SetOption("edges", new {
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
        var doc = new Document();
        
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
        var doc = new Document();
        
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
}