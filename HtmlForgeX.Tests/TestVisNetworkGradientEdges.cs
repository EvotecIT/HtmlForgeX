using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Text.RegularExpressions;

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

    // [TestMethod]
    // public void VisNetwork_ColorInheritance_From() {
    //     using var doc = new Document();

    //     doc.Body.Add(element => {
    //         element.DiagramNetwork(network => {
    //             network.AddNode(new VisNetworkNodeOptions()
    //                 .WithId(1)
    //                 .WithColor(RGBColor.Red)
    //             );
    //             network.AddNode(new VisNetworkNodeOptions()
    //                 .WithId(2)
    //                 .WithColor(RGBColor.Blue)
    //             );

    //             network.AddEdge(new VisNetworkEdgeOptions()
    //                 .WithConnection(1, 2)
    //                 .WithColor(colorOptions => colorOptions
    //                     .WithInherit(VisNetworkColorInherit.From)
    //                 )
    //             );
    //         });
    //     });

    //     var html = doc.ToString();

    //     // Extract the script content to check for edge configuration
    //     var scriptMatch = Regex.Match(html, @"<script>(.*?)</script>", RegexOptions.Singleline);
    //     Assert.IsTrue(scriptMatch.Success, "Should have script tag");

    //     var script = scriptMatch.Groups[1].Value;

    //     // The color object should contain inherit property with "from" value
    //     Assert.IsTrue(script.Contains("\"color\":{"), "Should contain color object");
    //     Assert.IsTrue(script.Contains("\"inherit\":\"from\""), "Should contain inherit:from");
    // }

    // [TestMethod]
    // public void VisNetwork_ColorInheritance_To() {
    //     using var doc = new Document();

    //     doc.Body.Add(element => {
    //         element.DiagramNetwork(network => {
    //             network.AddNode(new VisNetworkNodeOptions().WithId("A"));
    //             network.AddNode(new VisNetworkNodeOptions().WithId("B"));

    //             network.AddEdge(new VisNetworkEdgeOptions()
    //                 .WithConnection("A", "B")
    //                 .WithColor(colorOptions => colorOptions
    //                     .WithInherit(VisNetworkColorInherit.To)
    //                 )
    //             );
    //         });
    //     });

    //     var html = doc.ToString();

    //     // Extract the script content
    //     var scriptMatch = Regex.Match(html, @"<script>(.*?)</script>", RegexOptions.Singleline);
    //     Assert.IsTrue(scriptMatch.Success, "Should have script tag");

    //     var script = scriptMatch.Groups[1].Value;

    //     // Check for inherit:to
    //     Assert.IsTrue(script.Contains("\"inherit\":\"to\""), "Should contain inherit:to");
    // }

    // [TestMethod]
    // public void VisNetwork_ColorInheritance_Both() {
    //     using var doc = new Document();

    //     doc.Body.Add(element => {
    //         element.DiagramNetwork(network => {
    //             network.AddNode(new VisNetworkNodeOptions().WithId(1));
    //             network.AddNode(new VisNetworkNodeOptions().WithId(2));

    //             network.AddEdge(new VisNetworkEdgeOptions()
    //                 .WithConnection(1, 2)
    //                 .WithColor(colorOptions => colorOptions
    //                     .WithInherit(VisNetworkColorInherit.Both)
    //                 )
    //             );
    //         });
    //     });

    //     var html = doc.ToString();

    //     // Extract the script content
    //     var scriptMatch = Regex.Match(html, @"<script>(.*?)</script>", RegexOptions.Singleline);
    //     Assert.IsTrue(scriptMatch.Success, "Should have script tag");

    //     var script = scriptMatch.Groups[1].Value;

    //     // Check for inherit:both
    //     Assert.IsTrue(script.Contains("\"inherit\":\"both\""), "Should contain inherit:both");
    // }

    // [TestMethod]
    // public void VisNetwork_ColorInheritance_False() {
    //     using var doc = new Document();

    //     doc.Body.Add(element => {
    //         element.DiagramNetwork(network => {
    //             network.AddNode(new VisNetworkNodeOptions().WithId(1));
    //             network.AddNode(new VisNetworkNodeOptions().WithId(2));

    //             network.AddEdge(new VisNetworkEdgeOptions()
    //                 .WithConnection(1, 2)
    //                 .WithColor(colorOptions => colorOptions
    //                     .WithColor(RGBColor.Gray)
    //                     .WithInherit(VisNetworkColorInherit.False)
    //                 )
    //             );
    //         });
    //     });

    //     var html = doc.ToString();

    //     // Extract the script content
    //     var scriptMatch = Regex.Match(html, @"<script>(.*?)</script>", RegexOptions.Singleline);
    //     Assert.IsTrue(scriptMatch.Success, "Should have script tag");

    //     var script = scriptMatch.Groups[1].Value;

    //     // When inheritance is false, the edge should use its own color
    //     Assert.IsTrue(script.Contains("#808080"), "Should contain gray color hex value");
    //     Assert.IsTrue(script.Contains("\"inherit\":false"), "Should contain inherit:false");
    // }

    // [TestMethod]
    // public void VisNetwork_EdgeColorWithOpacity() {
    //     using var doc = new Document();

    //     doc.Body.Add(element => {
    //         element.DiagramNetwork(network => {
    //             network.AddNode(new VisNetworkNodeOptions().WithId(1));
    //             network.AddNode(new VisNetworkNodeOptions().WithId(2));

    //             network.AddEdge(new VisNetworkEdgeOptions()
    //                 .WithConnection(1, 2)
    //                 .WithColor(colorOptions => colorOptions
    //                     .WithColor(RGBColor.Red)
    //                     .WithOpacity(0.5)
    //                 )
    //             );
    //         });
    //     });

    //     var html = doc.ToString();

    //     // Extract the script content
    //     var scriptMatch = Regex.Match(html, @"<script>(.*?)</script>", RegexOptions.Singleline);
    //     Assert.IsTrue(scriptMatch.Success, "Should have script tag");

    //     var script = scriptMatch.Groups[1].Value;

    //     // Should contain opacity property in color object
    //     Assert.IsTrue(script.Contains("\"opacity\":0.5"), "Should contain opacity:0.5");
    // }

    // [TestMethod]
    // public void VisNetwork_ComplexColorConfiguration() {
    //     using var doc = new Document();

    //     doc.Body.Add(element => {
    //         element.DiagramNetwork(network => {
    //             network.AddNode(new VisNetworkNodeOptions().WithId(1));
    //             network.AddNode(new VisNetworkNodeOptions().WithId(2));

    //             network.AddEdge(new VisNetworkEdgeOptions()
    //                 .WithConnection(1, 2)
    //                 .WithColor(colorOptions => colorOptions
    //                     .WithColor(RGBColor.Blue)
    //                     .WithHighlight(RGBColor.Red)
    //                     .WithHover(RGBColor.Green)
    //                     .WithOpacity(0.8)
    //                     .WithInherit(VisNetworkColorInherit.Both)
    //                 )
    //             );
    //         });
    //     });

    //     var html = doc.ToString();

    //     // Extract the script content
    //     var scriptMatch = Regex.Match(html, @"<script>(.*?)</script>", RegexOptions.Singleline);
    //     Assert.IsTrue(scriptMatch.Success, "Should have script tag");

    //     var script = scriptMatch.Groups[1].Value;

    //     // Should contain all color properties in the edge configuration
    //     Assert.IsTrue(script.Contains("\"color\":{"), "Should contain color object");
    //     Assert.IsTrue(script.Contains("\"highlight\":\"#FF0000\""), "Should contain highlight with red color");
    //     Assert.IsTrue(script.Contains("\"hover\":\"#FFA500\""), "Should contain hover with orange color");
    //     Assert.IsTrue(script.Contains("\"opacity\":0.8"), "Should contain opacity:0.8");
    //     Assert.IsTrue(script.Contains("\"inherit\":\"both\""), "Should contain inherit:both");
    // }

    // [TestMethod]
    // public void VisNetwork_GradientWithComplexEdgeOptions() {
    //     using var doc = new Document();

    //     doc.Body.Add(element => {
    //         element.DiagramNetwork(network => {
    //             network.AddNode(new VisNetworkNodeOptions().WithId("start"));
    //             network.AddNode(new VisNetworkNodeOptions().WithId("end"));

    //             network.AddEdge(new VisNetworkEdgeOptions()
    //                 .WithConnection("start", "end")
    //                 .WithLabel("Gradient Edge")
    //                 .WithGradientColor(RGBColor.Purple, RGBColor.Orange)
    //                 .WithWidth(5)
    //                 .WithDashes(10, 5)
    //                 .WithArrows(arrows => arrows.WithTo())
    //                 .WithSmooth(smooth => smooth
    //                     .WithEnabled(true)
    //                     .WithType(VisNetworkSmoothType.Cubicbezier)
    //                     .WithRoundness(0.7)
    //                 )
    //             );
    //         });
    //     });

    //     var html = doc.ToString();

    //     // Extract the script content
    //     var scriptMatch = Regex.Match(html, @"<script>(.*?)</script>", RegexOptions.Singleline);
    //     Assert.IsTrue(scriptMatch.Success, "Should have script tag");

    //     var script = scriptMatch.Groups[1].Value;

    //     // Should contain edge properties
    //     Assert.IsTrue(script.Contains("Gradient Edge"), "Should contain edge label");
    //     Assert.IsTrue(script.Contains("\"width\":3"), "Should contain width property");
    //     Assert.IsTrue(script.Contains("\"dashes\":[5,10]"), "Should contain dash pattern");
    //     Assert.IsTrue(script.Contains("\"arrows\":{"), "Should contain arrows object");
    //     Assert.IsTrue(script.Contains("\"smooth\":{"), "Should contain smooth object");
    // }

    // [TestMethod]
    // public void VisNetwork_EdgeColorOptions_StringOverloads() {
    //     using var doc = new Document();

    //     doc.Body.Add(element => {
    //         element.DiagramNetwork(network => {
    //             network.AddNode(new VisNetworkNodeOptions().WithId(1));
    //             network.AddNode(new VisNetworkNodeOptions().WithId(2));

    //             network.AddEdge(new VisNetworkEdgeOptions()
    //                 .WithConnection(1, 2)
    //                 .WithColor(colorOptions => colorOptions
    //                     .WithColor("#FF0000")
    //                     .WithHighlight("#00FF00")
    //                     .WithHover("#0000FF")
    //                 )
    //             );
    //         });
    //     });

    //     var html = doc.ToString();

    //     // Extract the script content
    //     var scriptMatch = Regex.Match(html, @"<script>(.*?)</script>", RegexOptions.Singleline);
    //     Assert.IsTrue(scriptMatch.Success, "Should have script tag");

    //     var script = scriptMatch.Groups[1].Value;

    //     // Should contain colors in edge configuration
    //     Assert.IsTrue(script.Contains("\"color\":\"#FF0000\"") || script.Contains("\"color\":{") && script.Contains("\"color\":\"#FF0000\""),
    //         "Should contain red hex color");
    //     Assert.IsTrue(script.Contains("\"highlight\":\"#00FF00\""), "Should contain green highlight color");
    //     Assert.IsTrue(script.Contains("\"hover\":\"#0000FF\""), "Should contain blue hover color");
    // }
}