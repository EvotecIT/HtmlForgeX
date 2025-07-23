using System.Net;
using HtmlForgeX;

namespace HtmlForgeX.Examples.VisNetwork;

/// <summary>
/// Demonstrates the limited native HTML support in VisJS and shows best practices
/// for creating rich multi-line labels using only supported tags.
/// </summary>
internal class VisNetworkHtmlSupportExample {
    public static void Demo(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("VisNetwork HTML Support Example");

        using var document = new Document {
            Head = { Title = "VisNetwork HTML Support - Best Practices" },
            LibraryMode = LibraryMode.Online
        };

        document.Body.Page(page => {
            page.H2("VisNetwork Native HTML Support");
            var warning = new TablerAlert("⚠️ Limited HTML Support in VisJS",
                "VisJS has very limited native HTML support. Only these tags work:", TablerColor.Warning)
                .WithDescription();

            warning.Add(new UnorderedList()
                .AddItem(new HtmlTag("code").Value(WebUtility.HtmlEncode("<b>")).ToString() + " - Bold text", TablerIconType.InfoCircle)
                .AddItem(new HtmlTag("code").Value(WebUtility.HtmlEncode("<i>")).ToString() + " - Italic text", TablerIconType.InfoCircle)
                .AddItem(new HtmlTag("code").Value(WebUtility.HtmlEncode("<code>")).ToString() + " - Monospace text", TablerIconType.InfoCircle)
                .AddItem(new HtmlTag("code").Value(WebUtility.HtmlEncode("<br>")).ToString() + " - Line breaks", TablerIconType.InfoCircle));

            warning.Add(new HtmlTag("p")
                .Value("Other HTML tags like ")
                .ValueRaw("<code>&lt;span&gt;</code>, <code>&lt;div&gt;</code>, <code>&lt;u&gt;</code>, <code>&lt;small&gt;</code>")
                .Value(", etc. are ")
                .Value(new HtmlTag("strong", "NOT supported"))
                .Value(" and will render as plain text."));

            page.Add(warning);

            page.LineBreak();

            // Example 1: What Works
            page.H3("✅ Supported HTML Tags");
            page.DiagramNetwork(network => {
                network
                    .WithId("supportedHtml")
                    .WithSize("100%", "400px")
                    .WithPhysics(false)
                    .WithOptions(options => {
                        options.WithNodes(nodes => {
                            nodes.WithShape(VisNetworkNodeShape.Box);
                            nodes.WithFont(font => font
                                .WithMulti(VisNetworkMulti.Html)
                                .WithSize(14)
                            );
                        });
                    });

                // Bold text
                network.AddNode(1, node => node
                    .WithHtmlLabel(label => label.Bold("Bold Text Works!"))
                    .WithPosition(-400, -100)
                );

                // Italic text
                network.AddNode(2, node => node
                    .WithHtmlLabel(label => label.Italic("Italic Text Works!"))
                    .WithPosition(-200, -100)
                );

                // Code text
                network.AddNode(3, node => node
                    .WithHtmlLabel(label => label.Code("Code Text Works!"))
                    .WithPosition(0, -100)
                );

                // Combined formatting
                network.AddNode(4, node => node
                    .WithHtmlLabel(label => label
                        .Bold("Bold")
                        .Text(" and ")
                        .Italic("Italic")
                        .Text(" Combined"))
                    .WithPosition(200, -100)
                );

                // Multi-line with breaks
                network.AddNode(5, node => node
                    .WithHtmlLabel(label => label
                        .Bold("Multi-line")
                        .LineBreak()
                        .Italic("Text with")
                        .LineBreak()
                        .Code("Line Breaks"))
                    .WithPosition(400, -100)
                );

                // Using the label builder with supported tags
                network.AddNode(6, node => node
                    .WithHtmlLabel(label => label
                        .Bold("Server Status")
                        .LineBreak()
                        .LabelValue("CPU", "45%")
                        .LineBreak()
                        .LabelValue("Memory", "2.1GB")
                        .LineBreak()
                        .Code("server-01.local")
                    )
                    .WithPosition(-300, 100)
                    .WithColor(RGBColor.LightBlue)
                );

                // Bullet points using supported HTML
                network.AddNode(7, node => node
                    .WithHtmlLabel(label => label
                        .Bold("Features")
                        .LineBreak()
                        .BulletPoint("High Performance")
                        .BulletPoint("Scalable")
                        .BulletPoint("Reliable")
                    )
                    .WithPosition(0, 100)
                    .WithColor(RGBColor.LightGreen)
                );

                // Complex multi-format label
                network.AddNode(8, node => node
                    .WithHtmlLabel(label => label
                        .Bold("User Profile")
                        .LineBreak()
                        .LineBreak()
                        .LabelValue("Name", "John Doe")
                        .LineBreak()
                        .LabelValue("Role", "Administrator")
                        .LineBreak()
                        .LineBreak()
                        .Italic("Last login: ")
                        .Code("2024-01-21 15:30")
                    )
                    .WithPosition(300, 100)
                    .WithWidthConstraint(minimum: 250)
                    .WithColor(RGBColor.LightYellow)
                );
            });

            page.LineBreak();

            // Example 2: What Doesn't Work
            page.H3("❌ Unsupported HTML Tags (Will Render as Plain Text)");
            page.DiagramNetwork(network => {
                network
                    .WithId("unsupportedHtml")
                    .WithSize("100%", "300px")
                    .WithPhysics(false)
                    .WithOptions(options => {
                        options.WithNodes(nodes => {
                            nodes.WithShape(VisNetworkNodeShape.Box);
                            nodes.WithFont(font => font.WithMulti(VisNetworkMulti.Html));
                        });
                    });

                // These will NOT work as expected
                network.AddNode(1, node => node
                    .WithLabel("<u>Underline doesn't work</u>")
                    .WithPosition(-400, 0)
                );

                network.AddNode(2, node => node
                    .WithLabel("<span style='color: red'>Colors don't work</span>")
                    .WithPosition(-200, 0)
                );

                network.AddNode(3, node => node
                    .WithLabel("<small>Small text doesn't work</small>")
                    .WithPosition(0, 0)
                );

                network.AddNode(4, node => node
                    .WithLabel("<h3>Headings don't work</h3>")
                    .WithPosition(200, 0)
                );

                network.AddNode(5, node => node
                    .WithLabel("<div style='text-align: center'>Div styling doesn't work</div>")
                    .WithPosition(400, 0)
                );
            });

            page.LineBreak();

            // Example 3: Best Practices
            page.H3("💡 Best Practices for Rich Labels");
            page.DiagramNetwork(network => {
                network
                    .WithId("bestPractices")
                    .WithSize("100%", "500px")
                    .WithPhysics(physics => physics
                        .WithEnabled(true)
                        .WithSolver(VisNetworkPhysicsSolver.ForceAtlas2based)
                    );

                // Example: Server monitoring dashboard
                network.AddNode("web-server", node => node
                    .WithHtmlLabel(label => label
                        .Bold("Web Server")
                        .LineBreak()
                        .Code("nginx/1.24.0")
                        .LineBreak()
                        .LineBreak()
                        .LabelValue("Status", "Active")
                        .LineBreak()
                        .LabelValue("Uptime", "99.9%")
                    )
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.LightGreen)
                );

                network.AddNode("database", node => node
                    .WithHtmlLabel(label => label
                        .Bold("Database")
                        .LineBreak()
                        .Code("PostgreSQL 15")
                        .LineBreak()
                        .LineBreak()
                        .BulletPoint("Primary: Active")
                        .BulletPoint("Replica: Synced")
                        .BulletPoint("Backup: Daily")
                    )
                    .WithShape(VisNetworkNodeShape.Database)
                    .WithColor(RGBColor.LightBlue)
                );

                network.AddNode("cache", node => node
                    .WithHtmlLabel(label => label
                        .Bold("Cache Layer")
                        .LineBreak()
                        .Italic("Redis Cluster")
                        .LineBreak()
                        .LineBreak()
                        .Text("Memory: ")
                        .Bold("4.2GB / 8GB")
                        .LineBreak()
                        .Text("Hit Rate: ")
                        .Bold("94.3%")
                    )
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.LightCoral)
                );

                network.AddNode("load-balancer", node => node
                    .WithHtmlLabel(label => label
                        .Bold("Load Balancer")
                        .LineBreak()
                        .LineBreak()
                        .Text("Active Connections: ")
                        .Code("1,234")
                        .LineBreak()
                        .Text("Throughput: ")
                        .Code("125 MB/s")
                    )
                    .WithShape(VisNetworkNodeShape.Circle)
                    .WithColor(RGBColor.LightYellow)
                );

                // Add connections
                network.AddEdge("load-balancer", "web-server", edge => edge.WithArrows(arrows => arrows.WithTo()));
                network.AddEdge("web-server", "database", edge => edge.WithArrows(arrows => arrows.WithTo()));
                network.AddEdge("web-server", "cache", edge => edge.WithArrows(arrows => arrows.WithTo().WithFrom()));
            });

            // Add note about alternatives using fluent components (no raw HTML)
            var alert = new TablerAlert("💡 Need Full HTML Support?",
                "If you need full HTML/CSS support in nodes, consider:", TablerColor.Info)
                .WithDescription();

            alert.Add(new UnorderedList()
                .AddItem("visjs-html-nodes plugin - Adds full HTML support but may impact performance", TablerIconType.InfoCircle)
                .AddItem("Custom node shapes - Use SVG or Canvas for complex visualizations", TablerIconType.InfoCircle)
                .AddItem("Node tooltips - Tooltips support full HTML and can show rich content on hover", TablerIconType.InfoCircle));

            page.Add(alert);
        });

        document.Save("VisNetworkHtmlSupport.html", openInBrowser);

        HelpersSpectre.Success("✅ VisNetwork HTML Support example created");
        HelpersSpectre.Success("📋 Demonstrates:");
        HelpersSpectre.Success("   • Native supported HTML tags (b, i, code, br)");
        HelpersSpectre.Success("   • Unsupported tags that won't work");
        HelpersSpectre.Success("   • Best practices for creating rich labels");
        HelpersSpectre.Success("   • Real-world examples with proper formatting");
    }
}