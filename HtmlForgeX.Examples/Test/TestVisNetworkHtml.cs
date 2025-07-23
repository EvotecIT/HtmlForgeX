using HtmlForgeX;

namespace HtmlForgeX.Examples.Test;

public static class TestVisNetworkHtml {
    public static void Run() {
        using var document = new Document {
            Head = { Title = "VisNetwork HTML Test" },
            LibraryMode = LibraryMode.Online
        };

        document.Body.Page(page => {
            page.H2("VisNetwork HTML Support Test");
            
            // Test 1: Basic HTML tags
            page.H3("Test 1: Basic HTML Tags");
            page.DiagramNetwork(network => {
                network.WithId("test1")
                    .WithSize("100%", "300px")
                    .WithPhysics(false)
                    .WithOptions(options => {
                        options.WithNodes(nodes => {
                            nodes.WithShape(VisNetworkNodeShape.Box);
                            nodes.WithFont(font => font.WithMulti(VisNetworkMulti.Html));
                        });
                    });

                // Test various HTML tags
                network.AddNode(1, node => node
                    .WithHtmlLabel(label => label.Bold("Bold Text"))
                    .WithPosition(-400, 0)
                );

                network.AddNode(2, node => node
                    .WithHtmlLabel(label => label.Italic("Italic Text"))
                    .WithPosition(-200, 0)
                );

                network.AddNode(3, node => node
                    .WithHtmlLabel(label => label
                        .Bold("Bold")
                        .Text(" and ")
                        .Italic("Italic"))
                    .WithPosition(0, 0)
                );

                network.AddNode(4, node => node
                    .WithLabel("Underlined Text (not supported)")
                    .WithPosition(200, 0)
                );

                network.AddNode(5, node => node
                    .WithHtmlLabel(label => label.Code("Code Text"))
                    .WithPosition(400, 0)
                );
            });

            // Test 2: Font Multi property variations
            page.H3("Test 2: Font Multi Settings");
            page.DiagramNetwork(network => {
                network.WithId("test2")
                    .WithSize("100%", "300px")
                    .WithPhysics(false);

                // HTML multi set globally
                network.AddNode(1, node => node
                    .WithHtmlLabel(label => label
                        .Bold("Global HTML")
                        .LineBreak()
                        .Italic("Multi Setting"))
                    .WithPosition(-300, 0)
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithFont(font => font.WithMulti(VisNetworkMulti.Html))
                );

                // HTML multi set locally 
                network.AddNode(2, node => node
                    .WithHtmlLabel(label => label
                        .Bold("Local HTML")
                        .LineBreak()
                        .Italic("Font Setting"))
                    .WithPosition(0, 0)
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithFont(font => font
                        .WithMulti(VisNetworkMulti.Html)
                        .WithSize(14)
                    )
                );

                // Markdown multi
                network.AddNode(3, node => node
                    .WithLabel("**Bold** and *Italic*")
                    .WithPosition(300, 0)
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithFont(font => font.WithMulti(VisNetworkMulti.Markdown))
                );
            });

            // Test 3: Complex HTML with colors and spans
            page.H3("Test 3: Complex HTML");
            page.DiagramNetwork(network => {
                network.WithId("test3")
                    .WithSize("100%", "300px")
                    .WithPhysics(false);

                network.AddNode(1, node => node
                    .WithHtmlLabel(label => label
                        .Bold("Title")
                        .LineBreak()
                        .Text("Red Text")
                        .LineBreak()
                        .Text("Small text")
                    )
                    .WithPosition(-200, 0)
                    .WithShape(VisNetworkNodeShape.Box)
                );

                network.AddNode(2, node => node
                    .WithLabel("<span style='color: red'>Red</span> <span style='color: blue'>Blue</span>")
                    .WithPosition(0, 0)
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithFont(font => font.WithMulti(VisNetworkMulti.Html))
                );

                network.AddNode(3, node => node
                    .WithLabel("<div style='text-align: center'>Centered<br>Text</div>")
                    .WithPosition(200, 0)
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithFont(font => font.WithMulti(VisNetworkMulti.Html))
                );
            });

            // Test 4: Different node shapes with HTML
            page.H3("Test 4: HTML in Different Shapes");
            page.DiagramNetwork(network => {
                network.WithId("test4")
                    .WithSize("100%", "300px")
                    .WithPhysics(false)
                    .WithOptions(options => {
                        options.WithNodes(nodes => {
                            nodes.WithFont(font => font.WithMulti(VisNetworkMulti.Html));
                        });
                    });

                var shapes = new[] {
                    (VisNetworkNodeShape.Box, -300),
                    (VisNetworkNodeShape.Circle, -150),
                    (VisNetworkNodeShape.Ellipse, 0),
                    (VisNetworkNodeShape.Text, 150),
                    (VisNetworkNodeShape.Square, 300)
                };

                var i = 1;
                foreach (var (shape, x) in shapes) {
                    network.AddNode(i++, node => node
                        .WithLabel($"<b>{shape}</b><br><i>HTML</i>")
                        .WithPosition(x, 0)
                        .WithShape(shape)
                    );
                }
            });

            // Add JavaScript to inspect the actual rendering
            page.Add(new HtmlTag("script", @"
                document.addEventListener('DOMContentLoaded', function() {
                    // Log network configurations
                    console.log('=== VisNetwork HTML Test Results ===');
                    
                    // Check if networks are created
                    console.log('Test 1 Network:', diagramTracker['test1'] ? 'Created' : 'Failed');
                    console.log('Test 2 Network:', diagramTracker['test2'] ? 'Created' : 'Failed');
                    console.log('Test 3 Network:', diagramTracker['test3'] ? 'Created' : 'Failed');
                    console.log('Test 4 Network:', diagramTracker['test4'] ? 'Created' : 'Failed');
                    
                    // Get node options for test1
                    if (diagramTracker['test1']) {
                        var nodes = diagramTracker['test1'].body.data.nodes;
                        console.log('Test 1 - Node 1 label:', nodes.get(1).label);
                        console.log('Test 1 - Node 1 font:', nodes.get(1).font);
                    }
                    
                    // Get options for test2
                    if (diagramTracker['test2']) {
                        var nodes = diagramTracker['test2'].body.data.nodes;
                        console.log('Test 2 - Node 1 font:', nodes.get(1).font);
                        console.log('Test 2 - Node 2 font:', nodes.get(2).font);
                        console.log('Test 2 - Node 3 font:', nodes.get(3).font);
                    }
                });
            "));
        });

        document.Save("test-visnetwork-html.html", openInBrowser: true);
        HelpersSpectre.Success("✅ VisNetwork HTML test created at: test-visnetwork-html.html");
        HelpersSpectre.Success("🔍 Open the browser console to see diagnostic information");
    }
}