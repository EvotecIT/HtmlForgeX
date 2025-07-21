using System;
using HtmlForgeX;

namespace HtmlForgeX.Examples.VisNetwork;

/// <summary>
/// Demonstrates advanced label features in VisNetwork including:
/// - HTML tooltips on hover (title property)
/// - Line breaks using \n
/// - Markdown support
/// - Extended font properties
/// </summary>
internal class VisNetworkAdvancedLabelsExample {
    public static void Run(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("VisNetwork Advanced Labels Example");

        using var document = new Document {
            Head = { 
                Title = "VisNetwork Advanced Labels - Hover Tooltips, Newlines & Markdown", 
                Author = "HtmlForgeX"
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.H1("VisNetwork Advanced Label Features");
            page.Text("This example demonstrates HTML tooltips on hover, proper line breaks using \\n, and markdown support.");
            
            // Section 1: HTML Tooltips on Hover
            page.H2("1. HTML Tooltips on Hover");
            page.Text("Hover over nodes to see HTML-formatted tooltips. Unlike node labels, titles support full HTML.");
            
            page.DiagramNetwork(network => {
                network
                    .WithId("htmlTooltipsDemo")
                    .WithSize("100%", "500px")
                    .WithPhysics(false);

                // Node with simple HTML tooltip
                network.AddNode(1, node => node
                    .WithLabel("Server 1\nProduction")
                    .WithTitle("<div style='padding: 10px; background: #f0f0f0; border: 1px solid #ccc;'>" +
                              "<h3 style='margin: 0 0 10px 0;'>Server Details</h3>" +
                              "<table style='border-collapse: collapse;'>" +
                              "<tr><td style='padding: 2px 10px 2px 0;'><b>CPU:</b></td><td>Intel Xeon 16-core</td></tr>" +
                              "<tr><td style='padding: 2px 10px 2px 0;'><b>RAM:</b></td><td>64GB DDR4</td></tr>" +
                              "<tr><td style='padding: 2px 10px 2px 0;'><b>Storage:</b></td><td>2TB NVMe SSD</td></tr>" +
                              "<tr><td style='padding: 2px 10px 2px 0;'><b>Status:</b></td><td style='color: green;'>✓ Active</td></tr>" +
                              "</table></div>")
                    .WithPosition(-300, 0)
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.DarkBlue)
                    .WithFont(font => font.WithColor(RGBColor.White))
                );
                
                // Node with complex HTML tooltip including lists
                network.AddNode(2, node => node
                    .WithLabel("Database\nPostgreSQL 14")
                    .WithTitle("<div style='width: 250px; padding: 10px; background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white; border-radius: 8px;'>" +
                              "<h3 style='margin: 0 0 10px 0; text-align: center;'>Database Metrics</h3>" +
                              "<div style='background: rgba(255,255,255,0.2); padding: 8px; border-radius: 4px; margin-bottom: 8px;'>" +
                              "<div style='display: flex; justify-content: space-between;'>" +
                              "<span>Connections:</span><span><b>127/200</b></span>" +
                              "</div>" +
                              "<div style='display: flex; justify-content: space-between;'>" +
                              "<span>Size:</span><span><b>45.2 GB</b></span>" +
                              "</div>" +
                              "<div style='display: flex; justify-content: space-between;'>" +
                              "<span>Queries/sec:</span><span><b>1,234</b></span>" +
                              "</div>" +
                              "</div>" +
                              "<div style='font-size: 12px;'>" +
                              "<div><b>Recent Operations:</b></div>" +
                              "<ul style='margin: 5px 0; padding-left: 20px;'>" +
                              "<li>Backup completed (2h ago)</li>" +
                              "<li>Index optimization (5h ago)</li>" +
                              "<li>Vacuum full (1d ago)</li>" +
                              "</ul>" +
                              "</div></div>")
                    .WithPosition(0, 0)
                    .WithShape(VisNetworkNodeShape.Database)
                    .WithColor(RGBColor.Green)
                );
                
                // Node with image in tooltip
                network.AddNode(3, node => node
                    .WithLabel("CDN\nCloudFlare")
                    .WithTitle("<div style='text-align: center; padding: 10px;'>" +
                              "<img src='data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iNDgiIGhlaWdodD0iNDgiIHZpZXdCb3g9IjAgMCA0OCA0OCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPGNpcmNsZSBjeD0iMjQiIGN5PSIyNCIgcj0iMjQiIGZpbGw9IiNGRjZCMDAiLz4KPHBhdGggZD0iTTI0IDEyQzE3LjM3MjYgMTIgMTIgMTcuMzcyNiAxMiAyNEMxMiAzMC42Mjc0IDE3LjM3MjYgMzYgMjQgMzZDMzAuNjI3NCAzNiAzNiAzMC42Mjc0IDM2IDI0QzM2IDE3LjM3MjYgMzAuNjI3NCAxMiAyNCAxMlpNMjQgMzJDMTkuNTgxNyAzMiAxNiAyOC40MTgzIDE2IDI0QzE2IDE5LjU4MTcgMTkuNTgxNyAxNiAyNCAxNkMyOC40MTgzIDE2IDMyIDE5LjU4MTcgMzIgMjRDMzIgMjguNDE4MyAyOC40MTgzIDMyIDI0IDMyWiIgZmlsbD0id2hpdGUiLz4KPC9zdmc+' width='48' height='48' style='margin-bottom: 10px;'/>" +
                              "<h3 style='margin: 0 0 10px 0;'>CloudFlare CDN</h3>" +
                              "<div style='text-align: left; background: #f5f5f5; padding: 10px; border-radius: 4px;'>" +
                              "<div><b>Edge Locations:</b> 285 cities</div>" +
                              "<div><b>Bandwidth:</b> 15.2 TB/month</div>" +
                              "<div><b>Cache Hit Rate:</b> 94.7%</div>" +
                              "<div><b>Avg Response:</b> 12ms</div>" +
                              "</div></div>")
                    .WithPosition(300, 0)
                    .WithShape(VisNetworkNodeShape.Circle)
                    .WithColor(RGBColor.Orange)
                );

                // Edges with tooltips
                network.AddEdge(1, 2, edge => edge
                    .WithLabel("Query")
                    .WithTitle("<b>Database Connection</b><br>Protocol: PostgreSQL Wire<br>Port: 5432<br>SSL: Enabled")
                    .WithArrows(arrows => arrows.WithTo(true))
                );
                
                network.AddEdge(1, 3, edge => edge
                    .WithLabel("HTTP/2")
                    .WithTitle("<div style='background: #333; color: white; padding: 8px; border-radius: 4px;'>" +
                              "<b>CDN Connection</b><br>" +
                              "Requests/min: 45,234<br>" +
                              "Bandwidth: 125 MB/s<br>" +
                              "Cache Status: HOT" +
                              "</div>")
                    .WithArrows(arrows => arrows.WithTo(true).WithFrom(true))
                );
            });

            // Section 2: Proper Line Breaks with \n
            page.H2("2. Line Breaks Using \\n (Recommended)");
            page.Text("Using \\n for line breaks is more reliable than <br> tags and works consistently across all VisJS versions.");
            
            page.DiagramNetwork(network => {
                network
                    .WithId("lineBreaksDemo")
                    .WithSize("100%", "400px")
                    .WithOptions(options => options
                        .WithPhysics(physics => physics.WithEnabled(false))
                        .WithNodes(nodes => nodes
                            .WithFont(font => font
                                .WithSize(14)
                                .WithMulti(VisNetworkMulti.Html) // Enable HTML mode for all nodes
                            )
                        )
                    );

                // Using label builder with \n line breaks
                network.AddNode(1, node => node
                    .WithHtmlLabel(label => label
                        .Bold("Using Label Builder")
                        .LineBreak()
                        .Text("Line 1: Normal text")
                        .LineBreak()
                        .Italic("Line 2: Italic text")
                        .LineBreak()
                        .Code("Line 3: Code text"))
                    .WithPosition(-200, 0)
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.LightBlue)
                    .WithWidthConstraint(minimum: 200)
                );
                
                // Direct string with \n
                network.AddNode(2, node => node
                    .WithLabel("Direct String\nLine 1\nLine 2\nLine 3")
                    .WithPosition(0, 0)
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.LightGreen)
                );
                
                // HTML with \n instead of <br>
                network.AddNode(3, node => node
                    .WithHtmlLabel("<b>HTML Format</b>\n<i>With newlines</i>\n<code>Instead of br tags</code>")
                    .WithPosition(200, 0)
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.Orange)
                    .WithWidthConstraint(minimum: 200)
                );
            });

            // Section 3: Markdown Support
            page.H2("3. Markdown Support");
            page.Text("VisJS supports markdown formatting with font.multi = 'markdown'. This provides a cleaner syntax than HTML.");
            
            page.DiagramNetwork(network => {
                network
                    .WithId("markdownDemo")
                    .WithSize("100%", "600px")
                    .WithPhysics(physics => physics
                        .WithEnabled(true)
                        .WithSolver(VisNetworkPhysicsSolver.Repulsion)
                    );

                // Markdown formatted nodes
                network.AddNode("md1", node => node
                    .WithMarkdownLabel("# Markdown Header\n## Subheader\n\nThis is **bold** and this is *italic*.\n\n- Item 1\n- Item 2\n- Item 3")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.Purple)
                    .WithFont(font => font.WithColor(RGBColor.White))
                    .WithWidthConstraint(minimum: 250)
                    .WithTitle("This node uses markdown formatting")
                );
                
                network.AddNode("md2", node => node
                    .WithMarkdownLabel("### Task List\n\n1. ~~Completed task~~\n2. **Important task**\n3. _Pending task_\n\n`Code: system.execute()`")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.DarkGreen)
                    .WithFont(font => font.WithColor(RGBColor.White))
                    .WithWidthConstraint(minimum: 200)
                    .WithTitle("<b>Hover for details!</b><br>Markdown makes formatting easy")
                );
                
                network.AddNode("md3", node => node
                    .WithMarkdownLabel("## Server Stats\n\n**CPU:** `85%`\n**RAM:** `12.5GB / 16GB`\n**Disk:** `450GB / 1TB`\n\n_Last updated: 5s ago_")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.Red)
                    .WithFont(font => font.WithColor(RGBColor.White))
                    .WithWidthConstraint(minimum: 220)
                );
                
                // Mixed mode - HTML node with markdown edge
                network.AddNode("mixed", node => node
                    .WithHtmlLabel("<b>HTML Node</b>\n<i>Can connect to</i>\n<code>Markdown nodes</code>")
                    .WithShape(VisNetworkNodeShape.Ellipse)
                    .WithColor(RGBColor.Blue)
                    .WithFont(font => font.WithColor(RGBColor.White))
                );

                // Markdown edges
                network.AddEdge("md1", "md2", edge => edge
                    .WithMarkdownLabel("**Data Flow**\n_Encrypted_")
                    .WithArrows(arrows => arrows.WithTo(true))
                    .WithTitle("Connection uses TLS 1.3")
                );
                
                network.AddEdge("md2", "md3", edge => edge
                    .WithMarkdownLabel("### API\n`REST/JSON`")
                    .WithArrows(arrows => arrows.WithTo(true))
                );
                
                network.AddEdge("mixed", "md1", edge => edge
                    .WithLabel("Standard\nConnection")
                    .WithArrows(arrows => arrows.WithTo(true))
                    .WithDashes(true)
                );
            });

            // Section 4: Combined Example
            page.H2("4. Combined Example - Network Monitoring Dashboard");
            page.Text("Combining all features: HTML tooltips, proper line breaks, and markdown formatting.");
            
            page.DiagramNetwork(network => {
                network
                    .WithId("combinedDemo")
                    .WithSize("100%", "700px")
                    .WithOptions(options => options
                        .WithPhysics(physics => physics
                            .WithEnabled(true)
                            .WithSolver(VisNetworkPhysicsSolver.ForceAtlas2based)
                            .WithForceAtlas2Based(fa2 => fa2
                                .WithGravitationalConstant(-200)
                                .WithSpringLength(300)
                            )
                        )
                    );

                // Central monitoring node
                network.AddNode("monitor", node => node
                    .WithMarkdownLabel("# Monitoring Center\n\n**Active Alerts:** 3\n**Systems:** 12\n**Uptime:** 99.95%")
                    .WithTitle("<div style='width: 300px; padding: 15px; background: #2c3e50; color: white; border-radius: 8px;'>" +
                              "<h2 style='margin: 0 0 15px 0; text-align: center;'>System Overview</h2>" +
                              "<div style='display: grid; grid-template-columns: 1fr 1fr; gap: 10px;'>" +
                              "<div style='background: rgba(255,255,255,0.1); padding: 10px; border-radius: 4px;'>" +
                              "<div style='font-size: 24px; font-weight: bold;'>3</div>" +
                              "<div style='font-size: 12px;'>Critical Alerts</div>" +
                              "</div>" +
                              "<div style='background: rgba(255,255,255,0.1); padding: 10px; border-radius: 4px;'>" +
                              "<div style='font-size: 24px; font-weight: bold;'>27</div>" +
                              "<div style='font-size: 12px;'>Warnings</div>" +
                              "</div>" +
                              "<div style='background: rgba(255,255,255,0.1); padding: 10px; border-radius: 4px;'>" +
                              "<div style='font-size: 24px; font-weight: bold;'>156</div>" +
                              "<div style='font-size: 12px;'>Services OK</div>" +
                              "</div>" +
                              "<div style='background: rgba(255,255,255,0.1); padding: 10px; border-radius: 4px;'>" +
                              "<div style='font-size: 24px; font-weight: bold;'>12</div>" +
                              "<div style='font-size: 12px;'>Locations</div>" +
                              "</div>" +
                              "</div></div>")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.DarkSlateGray)
                    .WithFont(font => font.WithColor(RGBColor.White).WithSize(14))
                    .WithWidthConstraint(minimum: 250)
                );

                // Service nodes with different formats
                network.AddNode("web", node => node
                    .WithHtmlLabel(label => label
                        .Bold("Web Services")
                        .LineBreak()
                        .Text("nginx/1.21")
                        .LineBreak()
                        .Italic("Load: 45%"))
                    .WithTitle("<b>Web Server Farm</b><br>4 instances running<br>Avg response time: 125ms")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.Green)
                );

                network.AddNode("api", node => node
                    .WithMarkdownLabel("## API Gateway\n\n`v2.1.0`\n\n**Requests/min:** 12,450")
                    .WithTitle("<div style='padding: 10px;'><b>API Performance</b><br>P95 Latency: 45ms<br>P99 Latency: 120ms<br>Error rate: 0.02%</div>")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.Blue)
                    .WithFont(font => font.WithColor(RGBColor.White))
                );

                network.AddNode("db_cluster", node => node
                    .WithLabel("Database Cluster\nMySQL 8.0\n3 nodes")
                    .WithTitle("<div style='background: #f0f0f0; padding: 10px; border-radius: 4px;'>" +
                              "<h3 style='margin: 0 0 10px 0;'>Cluster Health</h3>" +
                              "<table style='width: 100%;'>" +
                              "<tr><td>Primary:</td><td style='color: green;'>✓ Healthy</td></tr>" +
                              "<tr><td>Replica 1:</td><td style='color: green;'>✓ In Sync</td></tr>" +
                              "<tr><td>Replica 2:</td><td style='color: orange;'>⚠ Lagging (2s)</td></tr>" +
                              "</table></div>")
                    .WithShape(VisNetworkNodeShape.Database)
                    .WithColor(RGBColor.Orange)
                );

                network.AddNode("cache", node => node
                    .WithMarkdownLabel("### Redis Cache\n\n**Memory:** `8.2GB/16GB`\n**Keys:** `1.2M`\n**Hit Rate:** `94%`")
                    .WithTitle("Hover for cache statistics")
                    .WithShape(VisNetworkNodeShape.Square)
                    .WithColor(RGBColor.Red)
                    .WithFont(font => font.WithColor(RGBColor.White))
                );

                // Alert node
                network.AddNode("alert", node => node
                    .WithHtmlLabel("<b style='color: red;'>⚠ ALERT</b>\nHigh CPU\nServer-03")
                    .WithTitle("<div style='background: #ff4444; color: white; padding: 10px; border-radius: 4px;'>" +
                              "<b>Critical Alert Details</b><br>" +
                              "Server: production-server-03<br>" +
                              "CPU Usage: 95%<br>" +
                              "Duration: 15 minutes<br>" +
                              "Action: Auto-scaling initiated</div>")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.DarkRed)
                    .WithFont(font => font.WithColor(RGBColor.White))
                );

                // Connections
                network.AddEdge("monitor", "web", edge => edge
                    .WithMarkdownLabel("**HTTPS**\n`Monitor`")
                    .WithTitle("Monitoring interval: 30s")
                );
                
                network.AddEdge("monitor", "api", edge => edge
                    .WithLabel("Health\nCheck")
                    .WithTitle("Endpoint: /health<br>Method: GET<br>Timeout: 5s")
                );
                
                network.AddEdge("monitor", "db_cluster", edge => edge
                    .WithMarkdownLabel("**MySQL**\n_Port 3306_")
                );
                
                network.AddEdge("monitor", "cache", edge => edge
                    .WithLabel("Redis\nProtocol")
                );
                
                network.AddEdge("monitor", "alert", edge => edge
                    .WithHtmlLabel("<b style='color: red;'>Alert</b>")
                    .WithTitle("Alert triggered at 14:35:22 UTC")
                    .WithColor(RGBColor.Red)
                    .WithWidth(3)
                    .WithDashes(true)
                );
            });

            // Code examples
            page.H2("Code Examples");
            
            page.Row(row => {
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("HTML Tooltips"));
                        card.Body(body => {
                            body.CSharpCode(@"// Add HTML tooltip on hover
network.AddNode(1, node => node
    .WithLabel(""Server"")
    .WithTitle(""<div style='padding: 10px;'>"" +
              ""<h3>Server Info</h3>"" +
              ""<p>CPU: 85%</p>"" +
              ""</div>"")
);", config => config.EnableLineNumbers().EnableCopyButton());
                        });
                    });
                });
                
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Line Breaks with \\n"));
                        card.Body(body => {
                            body.CSharpCode(@"// Use \n for line breaks
network.AddNode(1, node => node
    .WithLabel(""Line 1\nLine 2\nLine 3"")
);

// Or with label builder
node.WithHtmlLabel(label => label
    .Text(""Line 1"")
    .LineBreak() // Uses \n
    .Text(""Line 2"")
);", config => config.EnableLineNumbers().EnableCopyButton());
                        });
                    });
                });
                
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Markdown Labels"));
                        card.Body(body => {
                            body.CSharpCode(@"// Enable markdown formatting
network.AddNode(1, node => node
    .WithMarkdownLabel(
        ""# Header\n"" +
        ""**Bold** and *italic*\n"" +
        ""- List item 1\n"" +
        ""- List item 2""
    )
);", config => config.EnableLineNumbers().EnableCopyButton());
                        });
                    });
                });
            });

            // Benefits summary
            page.H2("Summary of Features");
            
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, col => {
                    col.Alert("Key Improvements", 
                        "• <b>HTML Tooltips:</b> Full HTML support in hover tooltips via WithTitle()<br>" +
                        "• <b>Line Breaks:</b> Use \\n instead of &lt;br&gt; for consistent line breaks<br>" +
                        "• <b>Markdown:</b> Clean syntax for formatted text with WithMarkdownLabel()<br>" +
                        "• <b>Mixed Modes:</b> Combine HTML, plain text, and markdown in the same network",
                        TablerColor.Info);
                });
            });
        });

        document.Save("VisNetworkAdvancedLabelsExample.html", openInBrowser);
        Console.WriteLine("VisNetwork Advanced Labels Example created successfully!");
    }
}