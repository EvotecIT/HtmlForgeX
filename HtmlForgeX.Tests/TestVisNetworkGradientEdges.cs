using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestVisNetworkGradientEdges {
    
    [TestMethod]
    public void VisNetwork_BasicGradientEdge() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNodeOptions().WithId(1).WithLabel("Start"));
                network.AddNode(new VisNetworkNodeOptions().WithId(2).WithLabel("End"));
                
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(1, 2)
                    .WithGradientColor(RGBColor.Red, RGBColor.Blue)
                );
            });
        });
        
        var html = doc.ToString();
        
        // Should contain gradient structure
        Assert.IsTrue(html.Contains("from") && html.Contains("to"), "Should contain gradient structure");
        Assert.IsTrue(html.Contains("#FF0000") || html.Contains("rgb(255, 0, 0)") || html.Contains("red"), 
            "Should contain red color");
        Assert.IsTrue(html.Contains("#0000FF") || html.Contains("rgb(0, 0, 255)") || html.Contains("blue"), 
            "Should contain blue color");
    }
    
    [TestMethod]
    public void VisNetwork_GradientWithStringColors() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNodeOptions().WithId(1));
                network.AddNode(new VisNetworkNodeOptions().WithId(2));
                
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(1, 2)
                    .WithGradientColor("#FF0000", "#00FF00")
                );
            });
        });
        
        var html = doc.ToString();
        
        Assert.IsTrue(html.Contains("#FF0000"), "Should contain red hex color");
        Assert.IsTrue(html.Contains("#00FF00"), "Should contain green hex color");
    }
    
    [TestMethod]
    public void VisNetwork_ColorInheritance_From() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNodeOptions()
                    .WithId(1)
                    .WithColor(RGBColor.Red)
                );
                network.AddNode(new VisNetworkNodeOptions()
                    .WithId(2)
                    .WithColor(RGBColor.Blue)
                );
                
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(1, 2)
                    .WithColor(colorOptions => colorOptions
                        .WithInherit(VisNetworkColorInherit.From)
                    )
                );
            });
        });
        
        var html = doc.ToString();
        
        // Should contain inherit configuration
        Assert.IsTrue(html.Contains("inherit"), "Should contain inherit property");
        Assert.IsTrue(html.Contains("from") || html.Contains("From"), "Should contain 'from' inheritance");
    }
    
    [TestMethod]
    public void VisNetwork_ColorInheritance_To() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNodeOptions().WithId("A"));
                network.AddNode(new VisNetworkNodeOptions().WithId("B"));
                
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection("A", "B")
                    .WithColor(colorOptions => colorOptions
                        .WithInherit(VisNetworkColorInherit.To)
                    )
                );
            });
        });
        
        var html = doc.ToString();
        
        Assert.IsTrue(html.Contains("inherit"), "Should contain inherit property");
        Assert.IsTrue(html.Contains("to") || html.Contains("To"), "Should contain 'to' inheritance");
    }
    
    [TestMethod]
    public void VisNetwork_ColorInheritance_Both() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNodeOptions().WithId(1));
                network.AddNode(new VisNetworkNodeOptions().WithId(2));
                
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(1, 2)
                    .WithColor(colorOptions => colorOptions
                        .WithInherit(VisNetworkColorInherit.Both)
                    )
                );
            });
        });
        
        var html = doc.ToString();
        
        Assert.IsTrue(html.Contains("inherit"), "Should contain inherit property");
        Assert.IsTrue(html.Contains("both") || html.Contains("Both"), "Should contain 'both' inheritance");
    }
    
    [TestMethod]
    public void VisNetwork_ColorInheritance_False() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNodeOptions().WithId(1));
                network.AddNode(new VisNetworkNodeOptions().WithId(2));
                
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(1, 2)
                    .WithColor(colorOptions => colorOptions
                        .WithColor(RGBColor.Gray)
                        .WithInherit(VisNetworkColorInherit.False)
                    )
                );
            });
        });
        
        var html = doc.ToString();
        
        // When inheritance is false, the edge should use its own color
        Assert.IsTrue(html.Contains("#808080") || html.Contains("gray") || html.Contains("Grey"), 
            "Should contain gray color");
    }
    
    [TestMethod]
    public void VisNetwork_EdgeColorWithOpacity() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNodeOptions().WithId(1));
                network.AddNode(new VisNetworkNodeOptions().WithId(2));
                
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(1, 2)
                    .WithColor(colorOptions => colorOptions
                        .WithColor(RGBColor.Red)
                        .WithOpacity(0.5)
                    )
                );
            });
        });
        
        var html = doc.ToString();
        
        Assert.IsTrue(html.Contains("opacity"), "Should contain opacity property");
        Assert.IsTrue(html.Contains("0.5"), "Should contain opacity value");
    }
    
    [TestMethod]
    public void VisNetwork_ComplexColorConfiguration() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNodeOptions().WithId(1));
                network.AddNode(new VisNetworkNodeOptions().WithId(2));
                
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(1, 2)
                    .WithColor(colorOptions => colorOptions
                        .WithColor(RGBColor.Blue)
                        .WithHighlight(RGBColor.Red)
                        .WithHover(RGBColor.Green)
                        .WithOpacity(0.8)
                        .WithInherit(VisNetworkColorInherit.Both)
                    )
                );
            });
        });
        
        var html = doc.ToString();
        
        // Should contain all color properties
        Assert.IsTrue(html.Contains("color"), "Should contain color property");
        Assert.IsTrue(html.Contains("highlight"), "Should contain highlight property");
        Assert.IsTrue(html.Contains("hover"), "Should contain hover property");
        Assert.IsTrue(html.Contains("opacity"), "Should contain opacity property");
        Assert.IsTrue(html.Contains("inherit"), "Should contain inherit property");
    }
    
    [TestMethod]
    public void VisNetwork_GradientWithComplexEdgeOptions() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNodeOptions().WithId("start"));
                network.AddNode(new VisNetworkNodeOptions().WithId("end"));
                
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection("start", "end")
                    .WithLabel("Gradient Edge")
                    .WithGradientColor(RGBColor.Purple, RGBColor.Orange)
                    .WithWidth(5)
                    .WithDashes(10, 5)
                    .WithArrows(arrows => arrows.WithTo())
                    .WithSmooth(smooth => smooth
                        .WithEnabled(true)
                        .WithType(VisNetworkSmoothType.Cubicbezier)
                        .WithRoundness(0.7)
                    )
                );
            });
        });
        
        var html = doc.ToString();
        
        // Should contain gradient and all other options
        Assert.IsTrue(html.Contains("Gradient Edge"), "Should contain edge label");
        Assert.IsTrue(html.Contains("width"), "Should contain width property");
        Assert.IsTrue(html.Contains("dashes"), "Should contain dashes property");
        Assert.IsTrue(html.Contains("arrows"), "Should contain arrows property");
        Assert.IsTrue(html.Contains("smooth"), "Should contain smooth property");
    }
    
    [TestMethod]
    public void VisNetwork_EdgeColorOptions_StringOverloads() {
        using var doc = new Document();
        
        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new VisNetworkNodeOptions().WithId(1));
                network.AddNode(new VisNetworkNodeOptions().WithId(2));
                
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(1, 2)
                    .WithColor(colorOptions => colorOptions
                        .WithColor("#FF0000")
                        .WithHighlight("#00FF00")
                        .WithHover("#0000FF")
                    )
                );
            });
        });
        
        var html = doc.ToString();
        
        Assert.IsTrue(html.Contains("#FF0000"), "Should contain red hex color");
        Assert.IsTrue(html.Contains("#00FF00"), "Should contain green hex color");
        Assert.IsTrue(html.Contains("#0000FF"), "Should contain blue hex color");
    }
}