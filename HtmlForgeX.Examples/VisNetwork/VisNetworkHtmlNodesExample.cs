using HtmlForgeX;
using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.VisNetworkExamples;

/// <summary>
/// Demonstrates the use of VisNetwork with full HTML node support using the visjs-html-nodes plugin.
/// This example shows various HTML capabilities including cards, tables, lists, progress bars, and more.
/// </summary>
public static class VisNetworkHtmlNodesExample {
    public static void Run(bool openInBrowser = false) {
        using var document = new Document();

        document.Head.Title = "VisNetwork HTML Nodes Example";

        document.Body
            .Add(new H1("Full HTML Support in Network Nodes"))
            .Add(new HtmlTag("p", "This example demonstrates the visjs-html-nodes plugin which enables full HTML content inside network nodes."))
            .Add(new HtmlTag("p", "Unlike native VisJS which only supports &lt;b&gt;, &lt;i&gt;, &lt;code&gt;, and &lt;br&gt; tags, the HTML nodes plugin supports:"))
            .Add(new HtmlTag("ul")
                .Add(new HtmlTag("li", "Complete HTML elements (div, span, p, h1-h6, etc.)"))
                .Add(new HtmlTag("li", "CSS styling (inline styles and classes)"))
                .Add(new HtmlTag("li", "Tables and lists"))
                .Add(new HtmlTag("li", "Images and media"))
                .Add(new HtmlTag("li", "Complex layouts with nested elements"))
                .Add(new HtmlTag("li", "Interactive content (with event handling)")))
            .Add(new HtmlTag("br", TagMode.SelfClosing));

        // Create network with HTML nodes
        var network = new HtmlForgeX.VisNetwork()
            .WithOptions(options => options
                .WithSize("100%", "800px")  // Make it larger and configurable
                .WithNodes(node => node
                    .WithBorderWidth(0)
                    .WithShadow(true))
                .WithEdges(edge => edge
                    .WithSmooth(smooth => smooth
                        .WithType(VisNetworkSmoothType.Continuous)))
                .WithPhysics(physics => physics
                    .WithEnabled(true)
                    .WithSolver(VisNetworkPhysicsSolver.ForceAtlas2based)
                    .WithForceAtlas2Based(fa2 => fa2
                        .WithGravitationalConstant(-300)  // Stronger repulsion for more spacing
                        .WithSpringLength(400)           // Longer springs for more distance
                        .WithCentralGravity(0.005)       // Very weak central gravity
                        .WithSpringConstant(0.05)        // Softer springs
                        .WithDamping(0.5))               // More damping for stability
                    .WithMinVelocity(0.75))              // Stop simulation sooner
            .WithLayout(layout => layout
                .WithImprovedLayout(true)));

        // Add HTML nodes with various content types

        // 1. Card-style node
        var cardNode = new VisNetworkHtmlNode("card1")
            .WithCard("Project Status", "Development Phase\n85% Complete", "#28a745");
        network.AddHtmlNode(cardNode);

        // 2. Table node
        var tableNode = new VisNetworkHtmlNode("table1")
            .WithTable(
                headers: new[] { "Metric", "Value" },
                rows: new[] {
                    new[] { "Users", "1,234" },
                    new[] { "Revenue", "$45,678" },
                    new[] { "Growth", "+23%" }
                });
        network.AddHtmlNode(tableNode);

        // 3. List node
        var listNode = new VisNetworkHtmlNode("list1")
            .WithList("TODO List",
                new[] {
                    "Complete documentation",
                    "Run unit tests",
                    "Deploy to production",
                    "Monitor performance"
                },
                ordered: true);
        network.AddHtmlNode(listNode);

        // 4. Progress bar node
        var progressNode = new VisNetworkHtmlNode("progress1")
            .WithProgressBar("CPU Usage", 75, "#ff9800");
        network.AddHtmlNode(progressNode);

        // 5. Badge node
        var badgeNode = new VisNetworkHtmlNode("badge1")
            .WithBadge("CRITICAL", "#dc3545");
        network.AddHtmlNode(badgeNode);

        // 6. Status indicator node
        var statusNode = new VisNetworkHtmlNode("status1")
            .WithStatus("Online", "#28a745", "All systems operational");
        network.AddHtmlNode(statusNode);

        // 7. Custom HTML with builder
        var customNode = new VisNetworkHtmlNode("custom1")
            .WithHtmlBuilder(builder => builder
                .Div("Server Dashboard", "text-align: center; font-weight: bold; margin-bottom: 10px;")
                .Div("", "display: flex; justify-content: space-around;")
                .Span("Memory: ", "font-weight: bold;")
                .Span("4.2 GB", "color: #28a745;")
                .LineBreak()
                .Span("Disk: ", "font-weight: bold;")
                .Span("120 GB", "color: #ffc107;")
                .LineBreak()
                .Span("Network: ", "font-weight: bold;")
                .Span("1.5 Gbps", "color: #17a2b8;"));
        network.AddHtmlNode(customNode);

        // 8. Complex layout node with raw HTML
        var complexNode = new VisNetworkHtmlNode("complex1")
            .WithHtmlContent(@"
                <div style='width: 200px; padding: 10px; background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; border-radius: 8px;'>
                    <h3 style='margin: 0 0 10px 0; text-align: center;'>Analytics</h3>
                    <div style='display: grid; grid-template-columns: 1fr 1fr; gap: 10px;'>
                        <div style='text-align: center; background: rgba(255,255,255,0.2); padding: 5px; border-radius: 4px;'>
                            <div style='font-size: 24px; font-weight: bold;'>42K</div>
                            <div style='font-size: 12px;'>Visitors</div>
                        </div>
                        <div style='text-align: center; background: rgba(255,255,255,0.2); padding: 5px; border-radius: 4px;'>
                            <div style='font-size: 24px; font-weight: bold;'>98%</div>
                            <div style='font-size: 12px;'>Uptime</div>
                        </div>
                    </div>
                    <div style='margin-top: 10px; font-size: 12px; text-align: center;'>
                        Last updated: 5 min ago
                    </div>
                </div>");
        network.AddHtmlNode(complexNode);

        // Add edges to connect nodes
        network
            .AddEdge("card1", "table1", edge => edge.WithLabel("Metrics"))
            .AddEdge("table1", "list1", edge => edge.WithLabel("Tasks"))
            .AddEdge("list1", "progress1", edge => edge.WithLabel("Status"))
            .AddEdge("progress1", "badge1", edge => edge.WithLabel("Alert"))
            .AddEdge("badge1", "status1", edge => edge.WithLabel("System"))
            .AddEdge("status1", "custom1", edge => edge.WithLabel("Details"))
            .AddEdge("custom1", "complex1", edge => edge.WithLabel("Analytics"))
            .AddEdge("complex1", "card1", edge => edge.WithLabel("Report").WithDashes(true));

        document.Body.Add(network);

        // Add comparison section
        document.Body
            .Add(new HtmlTag("br", TagMode.SelfClosing))
            .Add(new H2("Native vs Plugin Comparison"))
            .Add(new HtmlTag("div")
                .Add(new H3("Native VisJS HTML Support (Limited)"))
                .Add(new HtmlForgeX.VisNetwork()
                    .WithOptions(o => o.WithSize("100%", "300px"))
                    .AddNode(node => node
                        .WithId("native1")
                        .WithLabel(new VisNetworkLabelBuilder()
                            .Bold("Native HTML")
                            .LineBreak()
                            .Italic("Only basic tags work")
                            .LineBreak()
                            .Code("code.example()")
                            .Build())
                        .WithFont(font => font.WithMulti(VisNetworkMulti.Html))
                        .WithShape(VisNetworkNodeShape.Box))))
            .Add(new H3("Plugin HTML Support (Full)"))
            .Add(new HtmlTag("p", "The examples above demonstrate the full HTML capabilities provided by the visjs-html-nodes plugin."));

        // Add notes
        document.Body
            .Add(new HtmlTag("br", TagMode.SelfClosing))
            .Add(new H2("Implementation Notes"))
            .Add(new HtmlTag("ul")
                .Add(new HtmlTag("li", "The visjs-html-nodes plugin is automatically loaded when using VisNetworkHtmlNode"))
                .Add(new HtmlTag("li", "HTML nodes can contain any valid HTML and CSS"))
                .Add(new HtmlTag("li", "Nodes are rendered as HTML overlays on top of the canvas"))
                .Add(new HtmlTag("li", "Performance may be impacted with many complex HTML nodes"))
                .Add(new HtmlTag("li", "HTML nodes support event handlers and interactive content")));

        // Save document
        document.Save("VisNetworkHtmlNodesExample.html", openInBrowser);
        HelpersSpectre.Success("Created VisNetworkHtmlNodesExample.html");
    }
}