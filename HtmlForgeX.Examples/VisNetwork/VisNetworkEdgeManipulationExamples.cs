namespace HtmlForgeX.Examples.VisNetwork;

internal class VisNetworkEdgeManipulationExamples {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("VisNetwork Edge & Manipulation Examples");

        using var document = new Document {
            Head = { Title = "VisNetwork Edge & Manipulation Examples", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.H2("VisNetwork Edge Styling & Manipulation");
            page.LineBreak();

            // Example 1: Edge Styling Showcase
            page.H3("Edge Styling Options");
            page.DiagramNetwork(network => {
                network
                    .WithId("edgeStyling")
                    .WithSize("100%", "500px")
                    .WithPhysics(false);

                // Create nodes in a circle
                var nodeCount = 8;
                var radius = 200;
                for (int i = 0; i < nodeCount; i++) {
                    var angle = (i * 2 * Math.PI) / nodeCount;
                    var x = radius * Math.Cos(angle);
                    var y = radius * Math.Sin(angle);

                    network.AddNode(i + 1, node => node
                        .WithLabel($"Node {i + 1}")
                        .WithPosition(x, y)
                        .WithShape(VisNetworkNodeShape.Circle)
                        .WithColor(RGBColor.SkyBlue)
                    );
                }

                // Different edge styles
                network.AddEdge(1, 2, edge => edge
                    .WithLabel("Thick Red")
                    .WithColor(RGBColor.Red)
                    .WithWidth(5)
                );

                network.AddEdge(2, 3, edge => edge
                    .WithLabel("Dashed")
                    .WithDashes(VisNetworkDashPattern.MediumDash)
                    .WithColor(RGBColor.Green)
                );

                network.AddEdge(3, 4, edge => edge
                    .WithLabel("Curved")
                    .WithSmooth(new VisNetworkSmoothOptions()
                        .WithEnabled(true)
                        .WithType(VisNetworkSmoothType.Curvedcw)
                        .WithRoundness(0.5)
                    )
                    .WithColor(RGBColor.Blue)
                );

                network.AddEdge(4, 5, edge => edge
                    .WithLabel("Shadow")
                    .WithShadow(new VisNetworkShadowOptions()
                        .WithEnabled(true)
                        .WithColor(RGBColor.Black)
                        .WithSize(10)
                        .WithOffset(3, 3)
                    )
                    .WithColor(RGBColor.Purple)
                );

                network.AddEdge(5, 6, edge => edge
                    .WithLabel("Arrows Both")
                    .WithArrows(new VisNetworkArrowOptions()
                        .WithTo(true)
                        .WithFrom(true)
                        .WithMiddle(true)
                    )
                    .WithColor(RGBColor.Orange)
                );

                network.AddEdge(6, 7, edge => edge
                    .WithLabel("Custom Arrow")
                    .WithArrows(new VisNetworkArrowOptions()
                        .WithTo(new VisNetworkArrowTypeOptions()
                            .WithType(VisNetworkArrowType.Arrow)
                            .WithScaleFactor(2)
                        )
                    )
                    .WithColor(RGBColor.Pink)
                );

                network.AddEdge(7, 8, edge => edge
                    .WithLabel("Hover Effect")
                    .WithColor(new VisNetworkAdvancedColorOptions()
                        .WithColor(RGBColor.Gray)
                        .WithHover(RGBColor.Yellow)
                        .WithHighlight(RGBColor.Red)
                    )
                    .WithWidth(2, selectionWidth: 5, hoverWidth: 4)
                );

                network.AddEdge(8, 1, edge => edge
                    .WithLabel("Self Reference")
                    .WithSelfReference(selfRef => selfRef
                        .WithSize(20)
                        .WithAngle(Math.PI / 4)
                        .WithRenderBehindTheNode(false)
                    )
                    .WithColor(RGBColor.Brown)
                );
            });

            page.LineBreak();

            // Example 2: Dynamic Edge Colors and Widths
            page.H3("Dynamic Edge Properties");
            page.DiagramNetwork(network => {
                network
                    .WithId("dynamicEdges")
                    .WithSize("100%", "400px")
                    .WithPhysics(physics => {
                        physics.WithEnabled(true)
                            .WithSolver(VisNetworkPhysicsSolver.BarnesHut);
                    });

                // Network traffic visualization
                network.AddNode("internet", node => node
                    .WithLabel("Internet")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon
                        .WithFace("FontAwesome")
                        .WithCode("\uf0c2")
                        .WithSize(50)
                        .WithColor(RGBColor.SkyBlue)
                    )
                );

                network.AddNode("firewall", node => node
                    .WithLabel("Firewall")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.DarkRed)
                );

                network.AddNode("loadbalancer", node => node
                    .WithLabel("Load Balancer")
                    .WithShape(VisNetworkNodeShape.Diamond)
                    .WithColor(RGBColor.Orange)
                );

                network.AddNode("server1", node => node
                    .WithLabel("Server 1")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.Green)
                );

                network.AddNode("server2", node => node
                    .WithLabel("Server 2")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.Green)
                );

                network.AddNode("database", node => node
                    .WithLabel("Database")
                    .WithShape(VisNetworkNodeShape.Database)
                    .WithColor(RGBColor.Blue)
                );

                // Traffic flow with different widths representing volume
                network.AddEdge("internet", "firewall", edge => edge
                    .WithLabel("High Traffic")
                    .WithWidth(8)
                    .WithColor(RGBColor.Red)
                    .WithArrows(new VisNetworkArrowOptions().WithTo(true))
                );

                network.AddEdge("firewall", "loadbalancer", edge => edge
                    .WithLabel("Filtered")
                    .WithWidth(6)
                    .WithColor(RGBColor.Orange)
                    .WithArrows(new VisNetworkArrowOptions().WithTo(true))
                );

                network.AddEdge("loadbalancer", "server1", edge => edge
                    .WithLabel("50%")
                    .WithWidth(3)
                    .WithColor(RGBColor.Green)
                    .WithArrows(new VisNetworkArrowOptions().WithTo(true))
                );

                network.AddEdge("loadbalancer", "server2", edge => edge
                    .WithLabel("50%")
                    .WithWidth(3)
                    .WithColor(RGBColor.Green)
                    .WithArrows(new VisNetworkArrowOptions().WithTo(true))
                );

                network.AddEdge("server1", "database", edge => edge
                    .WithLabel("Queries")
                    .WithWidth(2)
                    .WithColor(RGBColor.Blue)
                    .WithArrows(new VisNetworkArrowOptions().WithTo(true).WithFrom(true))
                );

                network.AddEdge("server2", "database", edge => edge
                    .WithLabel("Queries")
                    .WithWidth(2)
                    .WithColor(RGBColor.Blue)
                    .WithArrows(new VisNetworkArrowOptions().WithTo(true).WithFrom(true))
                );
            });

            page.LineBreak();

            // Example 3: Network Manipulation
            page.H3("Interactive Network Manipulation");
            page.DiagramNetwork(network => {
                network
                    .WithId("manipulation")
                    .WithSize("100%", "500px")
                    .WithManipulation(manipulation => {
                        manipulation
                            .WithEnabled(true)
                            .WithInitiallyActive(false)
                            .WithAddNode(true)
                            .WithAddEdge(true)
                            .WithEditNode(true)
                            .WithEditEdge(true)
                            .WithDeleteNode(true)
                            .WithDeleteEdge(true);
                        // Control node style configuration is not available in current API
                    })
                    .WithOptions(options => {
                        options
                            .WithLocale(VisNetworkLocale.En);
                        // Locales configuration is not available in current API
                    });

                // Initial network
                network.AddNode(1, node => node
                    .WithLabel("Start Here")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.LightGreen)
                );

                network.AddNode(2, node => node
                    .WithLabel("Click Edit")
                    .WithShape(VisNetworkNodeShape.Circle)
                    .WithColor(RGBColor.LightBlue)
                );

                network.AddNode(3, node => node
                    .WithLabel("To Modify")
                    .WithShape(VisNetworkNodeShape.Diamond)
                    .WithColor(RGBColor.LightCoral)
                );

                network.AddEdge(1, 2, edge => edge.WithLabel("Connection 1"));
                network.AddEdge(2, 3, edge => edge.WithLabel("Connection 2"));
            });

            page.LineBreak();

            // Example 4: Edge Smooth Types
            page.H3("Edge Smooth Types");
            page.DiagramNetwork(network => {
                network
                    .WithId("smoothTypes")
                    .WithSize("100%", "400px")
                    .WithPhysics(false);

                // Create node pairs to demonstrate smooth types
                var smoothTypes = new[] {
                    (VisNetworkSmoothType.Dynamic, "Dynamic"),
                    (VisNetworkSmoothType.Continuous, "Continuous"),
                    (VisNetworkSmoothType.Discrete, "Discrete"),
                    (VisNetworkSmoothType.Diagonally, "Diagonal"),
                    (VisNetworkSmoothType.Straightcross, "Straight Cross"),
                    (VisNetworkSmoothType.Horizontal, "Horizontal"),
                    (VisNetworkSmoothType.Vertical, "Vertical"),
                    (VisNetworkSmoothType.Curvedcw, "Curved CW"),
                    (VisNetworkSmoothType.Curvedccw, "Curved CCW"),
                    (VisNetworkSmoothType.Cubicbezier, "Cubic Bezier")
                };

                var y = -200;
                var nodeId = 1;
                foreach (var (smoothType, name) in smoothTypes) {
                    var fromId = nodeId++;
                    var toId = nodeId++;

                    network.AddNode(fromId, node => node
                        .WithLabel("A")
                        .WithPosition(-150, y)
                        .WithShape(VisNetworkNodeShape.Circle)
                        .WithSize(20)
                    );

                    network.AddNode(toId, node => node
                        .WithLabel("B")
                        .WithPosition(150, y)
                        .WithShape(VisNetworkNodeShape.Circle)
                        .WithSize(20)
                    );

                    network.AddEdge(fromId, toId, edge => edge
                        .WithLabel(name)
                        .WithSmooth(new VisNetworkSmoothOptions()
                            .WithEnabled(true)
                            .WithType(smoothType)
                            .WithRoundness(0.5)
                        )
                        .WithArrows(new VisNetworkArrowOptions().WithTo(true))
                    );

                    y += 80;
                }
            });

            page.LineBreak();

            // Example 5: Advanced Manipulation with Events
            page.H3("Advanced Network with Toolbar");
            page.DiagramNetwork(network => {
                network
                    .WithId("advancedManipulation")
                    .WithSize("100%", "500px")
                    .WithManipulation(manipulation => {
                        manipulation
                            .WithEnabled(true)
                            .WithInitiallyActive(false)
                            .WithAddNode(true)
                            .WithAddEdge(true)
                            .WithEditNode(true)
                            .WithEditEdge(true)
                            .WithDeleteNode(true)
                            .WithDeleteEdge(true);
                    })
                    .WithInteraction(interaction => {
                        interaction
                            .WithDragNodes(true)
                            .WithDragView(true)
                            .WithZoomView(true)
                            .WithMultiselect(true)
                            .WithSelectable(true)
                            .WithSelectConnectedEdges(true)
                            .WithHover(true)
                            .WithHoverConnectedEdges(true)
                            .WithNavigationButtons(true)
                            .WithKeyboard(new VisNetworkKeyboardOptions()
                                .WithEnabled(true)
                                .WithSpeed(10, 10, 0.02)
                                .WithBindToWindow(true)
                                .WithAutoFocus(true)
                            );
                    });

                // Create a sample network
                network.AddNode("center", node => node
                    .WithLabel("Central Hub")
                    .WithShape(VisNetworkNodeShape.Star)
                    .WithSize(40)
                    .WithColor(RGBColor.DarkGoldenrod)
                );

                var satellites = new[] { "North", "East", "South", "West" };
                foreach (var satellite in satellites) {
                    network.AddNode(satellite, node => node
                        .WithLabel(satellite)
                        .WithShape(VisNetworkNodeShape.Box)
                        .WithColor(RGBColor.LightBlue)
                    );

                    network.AddEdge("center", satellite, edge => edge
                        .WithWidth(2)
                        .WithColor(RGBColor.Gray)
                    );
                }
            });
        });

        document.Save("VisNetworkEdgeManipulationExamples.html", openInBrowser);
    }
}