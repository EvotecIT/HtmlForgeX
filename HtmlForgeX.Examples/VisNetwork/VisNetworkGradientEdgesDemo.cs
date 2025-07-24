using System;

namespace HtmlForgeX.Examples.VisNetwork;

public class VisNetworkGradientEdgesDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("VisNetwork Gradient Edge Colors Demo");

        using var document = new Document {
            Head = {
                Title = "VisNetwork - Gradient Edge Colors Demo",
                Author = "HtmlForgeX"
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.H1("VisNetwork Gradient Edge Colors Demo");
            page.Text("This example demonstrates gradient edge colors with various configurations including color inheritance.");

            // Section 1: Basic Gradient Edges
            page.H2("1. Basic Gradient Edges");
            page.Text("Edges can have gradient colors that transition from one color to another.");

            page.DiagramNetwork(network => {
                network
                    .WithId("basicGradient")
                    .WithSize("100%", "400px")
                    .WithPhysics(false);

                // Create nodes with different colors
                network.AddNode(1, node => node
                    .WithLabel("Red Node")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.Red)
                    .WithPosition(0, 0)
                );

                network.AddNode(2, node => node
                    .WithLabel("Blue Node")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.Blue)
                    .WithPosition(200, 0)
                );

                network.AddNode(3, node => node
                    .WithLabel("Green Node")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.Green)
                    .WithPosition(100, 150)
                );

                // Add gradient edges
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(1, 2)
                    .WithLabel("Red to Blue Gradient")
                    .WithGradientColor(RGBColor.Red, RGBColor.Blue)
                    .WithWidth(3)
                );

                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(2, 3)
                    .WithLabel("Blue to Green Gradient")
                    .WithGradientColor(RGBColor.Blue, RGBColor.Green)
                    .WithWidth(3)
                );

                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(3, 1)
                    .WithLabel("Green to Red Gradient")
                    .WithGradientColor(RGBColor.Green, RGBColor.Red)
                    .WithWidth(3)
                );
            });

            // Section 2: Color Inheritance
            page.H2("2. Color Inheritance");
            page.Text("Edges can inherit colors from connected nodes using the VisNetworkColorInherit enum.");

            page.DiagramNetwork(network => {
                network
                    .WithId("colorInheritance")
                    .WithSize("100%", "400px")
                    .WithPhysics(false);

                // Create colorful nodes
                network.AddNode("A", node => node
                    .WithLabel("Orange Node")
                    .WithShape(VisNetworkNodeShape.Circle)
                    .WithColor(RGBColor.Orange)
                    .WithPosition(-150, 0)
                );

                network.AddNode("B", node => node
                    .WithLabel("Purple Node")
                    .WithShape(VisNetworkNodeShape.Circle)
                    .WithColor(RGBColor.Purple)
                    .WithPosition(0, -100)
                );

                network.AddNode("C", node => node
                    .WithLabel("Cyan Node")
                    .WithShape(VisNetworkNodeShape.Circle)
                    .WithColor(RGBColor.Cyan)
                    .WithPosition(150, 0)
                );

                network.AddNode("D", node => node
                    .WithLabel("Yellow Node")
                    .WithShape(VisNetworkNodeShape.Circle)
                    .WithColor(RGBColor.Yellow)
                    .WithPosition(0, 100)
                );

                // Edges with different inheritance settings
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection("A", "B")
                    .WithLabel("Inherit From")
                    .WithColor(colorOptions => colorOptions
                        .WithInherit(VisNetworkColorInherit.From)
                    )
                    .WithWidth(4)
                    .WithArrows(arrowOptions => arrowOptions.WithTo())
                );

                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection("B", "C")
                    .WithLabel("Inherit To")
                    .WithColor(colorOptions => colorOptions
                        .WithInherit(VisNetworkColorInherit.To)
                    )
                    .WithWidth(4)
                    .WithArrows(arrowOptions => arrowOptions.WithTo())
                );

                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection("C", "D")
                    .WithLabel("Inherit Both")
                    .WithColor(colorOptions => colorOptions
                        .WithInherit(VisNetworkColorInherit.Both)
                    )
                    .WithWidth(4)
                    .WithArrows(arrowOptions => arrowOptions.WithTo())
                );

                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection("D", "A")
                    .WithLabel("No Inheritance")
                    .WithColor(colorOptions => colorOptions
                        .WithColor(RGBColor.Gray)
                        .WithInherit(VisNetworkColorInherit.False)
                    )
                    .WithWidth(4)
                    .WithArrows(arrowOptions => arrowOptions.WithTo())
                );
            });

            // Section 3: Complex Gradient with Styling
            page.H2("3. Complex Edge Styling with Gradients");
            page.Text("Combining gradients with other edge styling options creates visually rich networks.");

            page.DiagramNetwork(network => {
                network
                    .WithId("complexGradients")
                    .WithSize("100%", "400px")
                    .WithPhysics(false);

                // Create a hub and spoke network
                network.AddNode("hub", node => node
                    .WithLabel("Central Hub")
                    .WithShape(VisNetworkNodeShape.Star)
                    .WithColor(RGBColor.Orange)
                    .WithSize(30)
                    .WithPosition(0, 0)
                );

                // Create surrounding nodes in a circle
                var colors = new[] {
                    RGBColor.Red, RGBColor.Orange, RGBColor.Yellow,
                    RGBColor.Green, RGBColor.Blue, RGBColor.Indigo,
                    RGBColor.Violet, RGBColor.Pink
                };

                for (int i = 0; i < 8; i++) {
                    var angle = (i * Math.PI * 2) / 8;
                    var x = Math.Cos(angle) * 150;
                    var y = Math.Sin(angle) * 150;

                    network.AddNode($"node{i}", node => node
                        .WithLabel($"Node {i + 1}")
                        .WithShape(VisNetworkNodeShape.Dot)
                        .WithColor(colors[i])
                        .WithPosition(x, y)
                    );

                    // Add gradient edge from hub to node
                    network.AddEdge(new VisNetworkEdgeOptions()
                        .WithConnection("hub", $"node{i}")
                        .WithGradientColor(RGBColor.Orange, colors[i])
                        .WithWidth(2)
                        .WithSmooth(smooth => smooth
                            .WithEnabled(true)
                            .WithType(VisNetworkSmoothType.Cubicbezier)
                            .WithRoundness(0.5)
                        )
                        .WithArrows(arrows => arrows
                            .WithTo(to => to
                                .WithEnabled(true)
                                .WithType(VisNetworkArrowType.Arrow)
                                .WithScaleFactor(0.8)
                            )
                        )
                    );
                }

                // Add some interconnections with different styles
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection("node0", "node4")
                    .WithLabel("Dashed Gradient")
                    .WithGradientColor(colors[0], colors[4])
                    .WithDashes(VisNetworkDashPattern.ShortDash)
                    .WithWidth(2)
                );

                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection("node2", "node6")
                    .WithLabel("Wide Gradient")
                    .WithGradientColor(colors[2], colors[6])
                    .WithWidth(5, 8, 10) // width, hoverWidth, selectionWidth
                );

                // Enable interaction
                network.WithOptions(options => options
                    .WithInteraction(interaction => interaction
                        .WithHover(true)
                        .WithHoverConnectedEdges(true)
                        .WithSelectConnectedEdges(true)
                    )
                );
            });

            // Section 4: Gradients with Opacity
            page.H2("4. Gradients with Opacity");
            page.Text("Edge gradients can have varying opacity levels for subtle visual effects.");

            page.DiagramNetwork(network => {
                network
                    .WithId("gradientOpacity")
                    .WithSize("100%", "400px")
                    .WithPhysics(false);

                // Create nodes
                for (int i = 1; i <= 4; i++) {
                    network.AddNode(i, node => node
                        .WithLabel($"Node {i}")
                        .WithShape(VisNetworkNodeShape.Box)
                        .WithColor(RGBColor.DarkBlue)
                        .WithPosition((i - 2.5) * 100, 0)
                    );
                }

                // Add edges with different opacities
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(1, 2)
                    .WithLabel("Opacity 1.0")
                    .WithGradientColor(RGBColor.Red, RGBColor.Blue)
                    .WithColor(colorOptions => colorOptions
                        .WithOpacity(1.0)
                    )
                    .WithWidth(5)
                );

                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(2, 3)
                    .WithLabel("Opacity 0.5")
                    .WithGradientColor(RGBColor.Green, RGBColor.Yellow)
                    .WithColor(colorOptions => colorOptions
                        .WithOpacity(0.5)
                    )
                    .WithWidth(5)
                );

                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(3, 4)
                    .WithLabel("Opacity 0.2")
                    .WithGradientColor(RGBColor.Purple, RGBColor.Orange)
                    .WithColor(colorOptions => colorOptions
                        .WithOpacity(0.2)
                    )
                    .WithWidth(5)
                );

                // Add a self-referencing edge with gradient
                network.AddEdge(new VisNetworkEdgeOptions()
                    .WithConnection(2, 2)
                    .WithLabel("Self Gradient")
                    .WithGradientColor(RGBColor.Magenta, RGBColor.Cyan)
                    .WithSelfReference(selfRef => selfRef
                        .WithSize(40)
                        .WithAngle(Math.PI / 4)
                    )
                    .WithWidth(3)
                );
            });

            page.H2("Summary");
            page.Text("The enhanced VisNetwork edge API provides:");
            page.Text("• Gradient edge colors with WithGradientColor() method");
            page.Text("• Color inheritance using VisNetworkColorInherit enum (From, To, Both, False)");
            page.Text("• Complex color configurations with opacity support");
            page.Text("• Full integration with other edge styling options");
            page.Text("• Type-safe API that prevents invalid configurations");
        });

        document.Save("VisNetworkGradientEdgesDemo.html", openInBrowser);
    }
}