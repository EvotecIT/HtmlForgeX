using System;
using HtmlForgeX;

namespace HtmlForgeX.Examples.VisNetwork;

/// <summary>
/// Demonstrates native HTML and Markdown multi-line label support in VisNetwork.
/// Note: Native VisJS only supports <b>, <i>, <code>, and <br> tags.
/// For full HTML support, use VisNetworkHtmlNodesExample instead.
/// </summary>
internal class VisNetworkMultiLineLabelDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("VisNetwork Multi-Line Label Demo");

        using var document = new Document {
            Head = { 
                Title = "VisNetwork Multi-Line Labels - HTML & Markdown Support", 
                Author = "HtmlForgeX"
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.H1("VisNetwork Multi-Line Label Support");
            page.Text("This demo showcases HTML and Markdown formatted labels for nodes and edges.");
            
            // Section 1: HTML Labels (Native VisJS Support)
            page.H2("1. HTML-Formatted Labels (Native Support)");
            page.Text("Native VisJS supports only basic HTML tags: <b> (bold), <i> (italic), <code> (code), and <br> (line break). For full HTML support, use the HTML nodes plugin.");
            
            page.DiagramNetwork(network => {
                network
                    .WithId("htmlLabelsDemo")
                    .WithSize("100%", "500px")
                    .WithPhysics(false);

                // HTML formatted nodes
                network.AddNode(1, node => node
                    .WithHtmlLabel(label => label
                        .Bold("Bold Title")
                        .LineBreak()
                        .Italic("Italic subtitle")
                        .LineBreak()
                        .Text("Normal text"))
                    .WithPosition(-300, -100)
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.LightBlue)
                );
                
                network.AddNode(2, node => node
                    .WithHtmlLabel(label => label
                        .Bold("HTML Node")
                        .LineBreak()
                        .Code("Feature 1")
                        .LineBreak()
                        .Code("Feature 2"))
                    .WithPosition(0, -100)
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.LightGreen)
                    .WithWidthConstraint(minimum: 150)
                );
                
                network.AddNode(3, node => node
                    .WithHtmlLabel(label => label
                        .Bold("Centered")
                        .LineBreak()
                        .Italic("Multi-line")
                        .LineBreak()
                        .Code("Code text"))
                    .WithPosition(300, -100)
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.Orange)
                );

                // HTML formatted edges
                network.AddEdge(1, 2, edge => edge
                    .WithHtmlLabel("<b>Connection 1</b><br><i>High Priority</i>")
                    .WithColor(RGBColor.Gray)
                );
                
                network.AddEdge(2, 3, edge => edge
                    .WithHtmlLabel("<b>Data Flow</b><br><i>Active</i>")
                    .WithColor(RGBColor.Gray)
                );
            });

            // Section 2: Markdown Labels
            page.H2("2. Markdown-Formatted Labels");
            page.Text("Markdown provides a simpler syntax for formatted text with support for headers, lists, and emphasis.");
            
            page.DiagramNetwork(network => {
                network
                    .WithId("markdownLabelsDemo")
                    .WithSize("100%", "500px")
                    .WithPhysics(false);

                // Markdown formatted nodes
                network.AddNode(1, node => node
                    .WithMarkdownLabel("# Server\n## Production\n- CPU: 85%\n- Memory: 4GB\n- **Status: Active**")
                    .WithPosition(-300, 0)
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.DarkBlue)
                    .WithFont(font => font.WithColor(RGBColor.White))
                    .WithWidthConstraint(minimum: 200)
                );
                
                network.AddNode(2, node => node
                    .WithMarkdownLabel("### Database\n*PostgreSQL 14*\n\n**Connections:** 127\n**Size:** 45GB")
                    .WithPosition(0, 0)
                    .WithShape(VisNetworkNodeShape.Database)
                    .WithColor(RGBColor.Green)
                );
                
                network.AddNode(3, node => node
                    .WithMarkdownLabel("## API Gateway\n\n1. Request validation\n2. Rate limiting\n3. Authentication\n\n_Version 2.1.0_")
                    .WithPosition(300, 0)
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.Purple)
                    .WithFont(font => font.WithColor(RGBColor.White))
                    .WithWidthConstraint(minimum: 180)
                );

                // Markdown formatted edges
                network.AddEdge(1, 2, edge => edge
                    .WithMarkdownLabel("**Query**\n_avg: 12ms_")
                    .WithArrows(arrows => arrows.WithTo(true))
                );
                
                network.AddEdge(3, 1, edge => edge
                    .WithMarkdownLabel("### HTTPS\n- Port: 443\n- **TLS 1.3**")
                    .WithArrows(arrows => arrows.WithTo(true))
                );
            });

            // Section 3: Mixed Example - Network Diagram
            page.H2("3. Real-World Example - Network Infrastructure");
            page.Text("Combining HTML and Markdown labels to create an informative network diagram.");
            
            page.DiagramNetwork(network => {
                network
                    .WithId("infrastructureDemo")
                    .WithSize("100%", "600px")
                    .WithPhysics(physics => physics
                        .WithEnabled(true)
                        .WithSolver(VisNetworkPhysicsSolver.ForceAtlas2based)
                    );

                // Core infrastructure nodes
                network.AddNode("lb", node => node
                    .WithHtmlLabel(label => label
                        .Bold("Load Balancer")
                        .LineBreak()
                        .Italic("Active")
                        .LineBreak()
                        .Code("nginx/1.21"))
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.Blue)
                    .WithFont(font => font.WithColor(RGBColor.White))
                );
                
                network.AddNode("web1", node => node
                    .WithMarkdownLabel("## Web Server 1\n**Apache 2.4**\n\nCPU: `45%`\nRAM: `2.1GB`")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.DarkGreen)
                    .WithFont(font => font.WithColor(RGBColor.White))
                );
                
                network.AddNode("web2", node => node
                    .WithMarkdownLabel("## Web Server 2\n**Apache 2.4**\n\nCPU: `52%`\nRAM: `2.3GB`")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.DarkGreen)
                    .WithFont(font => font.WithColor(RGBColor.White))
                );
                
                network.AddNode("cache", node => node
                    .WithHtmlLabel(label => label
                        .Bold("Redis Cache")
                        .LineBreak()
                        .Italic("Memory: 512MB")
                        .LineBreak()
                        .Italic("Keys: 15,234")
                        .LineBreak()
                        .Italic("Hit Rate: 94%"))
                    .WithShape(VisNetworkNodeShape.Database)
                    .WithColor(RGBColor.Red)
                    .WithFont(font => font.WithColor(RGBColor.White))
                );
                
                network.AddNode("db", node => node
                    .WithMarkdownLabel("# MySQL\n### Primary Database\n\n- Version: 8.0\n- Storage: 120GB\n- **Replication: Active**")
                    .WithShape(VisNetworkNodeShape.Database)
                    .WithColor(RGBColor.Orange)
                    .WithWidthConstraint(minimum: 200)
                );

                // Connections with informative labels
                network.AddEdge("lb", "web1", edge => edge
                    .WithHtmlLabel("<b>HTTP/2</b><br>50% traffic")
                    .WithArrows(arrows => arrows.WithTo(true))
                    .WithWidth(3)
                );
                
                network.AddEdge("lb", "web2", edge => edge
                    .WithHtmlLabel("<b>HTTP/2</b><br>50% traffic")
                    .WithArrows(arrows => arrows.WithTo(true))
                    .WithWidth(3)
                );
                
                network.AddEdge("web1", "cache", edge => edge
                    .WithMarkdownLabel("**Read**\n_~2ms_")
                    .WithArrows(arrows => arrows.WithTo(true).WithFrom(true))
                    .WithDashes(true)
                );
                
                network.AddEdge("web2", "cache", edge => edge
                    .WithMarkdownLabel("**Read**\n_~2ms_")
                    .WithArrows(arrows => arrows.WithTo(true).WithFrom(true))
                    .WithDashes(true)
                );
                
                network.AddEdge("web1", "db", edge => edge
                    .WithMarkdownLabel("### Queries\n- Read: 85%\n- Write: 15%")
                    .WithArrows(arrows => arrows.WithTo(true).WithFrom(true))
                );
                
                network.AddEdge("web2", "db", edge => edge
                    .WithMarkdownLabel("### Queries\n- Read: 82%\n- Write: 18%")
                    .WithArrows(arrows => arrows.WithTo(true).WithFrom(true))
                );
            });

            // Code examples
            page.H2("Code Examples");
            
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("HTML Labels"));
                        card.Body(body => {
                            body.CSharpCode(@"// HTML formatted node label
network.AddNode(1, node => node
    .WithHtmlLabel(""<b>Bold Title</b><br><i>Subtitle</i>"")
    .WithShape(VisNetworkNodeShape.Box)
);

// HTML formatted edge label
network.AddEdge(1, 2, edge => edge
    .WithHtmlLabel(""<b>Important</b><br><i>Connection</i>"")
);", config => config.EnableLineNumbers().EnableCopyButton());
                        });
                    });
                });
                
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Markdown Labels"));
                        card.Body(body => {
                            body.CSharpCode(@"// Markdown formatted node label
network.AddNode(1, node => node
    .WithMarkdownLabel(""# Header\n- Item 1\n- Item 2\n**Bold text**"")
    .WithShape(VisNetworkNodeShape.Box)
);

// Markdown formatted edge label
network.AddEdge(1, 2, edge => edge
    .WithMarkdownLabel(""**Connection**\n_Latency: 5ms_"")
);", config => config.EnableLineNumbers().EnableCopyButton());
                        });
                    });
                });
            });

            // Benefits
            page.H2("Benefits");
            page.Text("• Rich text formatting without manual HTML/CSS").LineBreak();
            page.Text("• Support for lists, headers, and emphasis").LineBreak();
            page.Text("• Automatic multi-line mode configuration").LineBreak();
            page.Text("• Clean API with dedicated methods").LineBreak();
            page.Text("• Mix HTML and Markdown in the same network");
        });

        document.Save("VisNetworkMultiLineLabelDemo.html", openInBrowser);
        Console.WriteLine("VisNetwork Multi-Line Label Demo created successfully!");
    }
}