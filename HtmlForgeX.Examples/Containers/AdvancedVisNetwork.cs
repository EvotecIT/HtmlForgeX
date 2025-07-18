namespace HtmlForgeX.Examples.Containers;

internal class AdvancedVisNetwork {
    public static void Demo(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Advanced VisNetwork Demo - New Fluent API");

        using var document = new Document {
            Head = { Title = "Advanced VisNetwork Demo", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Offline,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            // Example 1: Hierarchical Organization Chart
            page.DiagramNetwork(network => {
                network
                    .WithId("orgChart")
                    .WithSize("100%", "600px")
                    .WithHierarchicalLayout(VisNetworkLayoutDirection.Ud)
                    .WithPhysics(false)
                    .WithOptions(options => {
                        options.WithInteraction(interaction => {
                            interaction
                                .WithDragNodes(false)
                                .WithNavigationButtons(true)
                                .WithZoomView(true)
                                .WithTooltipDelay(300);
                        });
                        
                        options.WithNodes(nodes => {
                            nodes
                                .WithShape(VisNetworkNodeShape.Box)
                                .WithBorderWidth(2)
                                .WithFont(font => font.WithSize(14).WithFace("Arial"));
                        });
                        
                        options.WithEdges(edges => {
                            edges.WithArrows(arrows => arrows.WithTo(true));
                        });
                    });

                // Add organization nodes
                network.AddNode(1, node => node
                    .WithLabel("CEO")
                    .WithLevel(0)
                    .WithColor(RGBColor.FromRGB(231, 76, 60))
                    .WithFont(font => font.WithColor(RGBColor.White).WithSize(16))
                );

                network.AddNode(2, node => node
                    .WithLabel("CTO")
                    .WithLevel(1)
                    .WithColor(RGBColor.FromRGB(52, 152, 219))
                    .WithFont(font => font.WithColor(RGBColor.White))
                );

                network.AddNode(3, node => node
                    .WithLabel("CFO")
                    .WithLevel(1)
                    .WithColor(RGBColor.FromRGB(46, 204, 113))
                    .WithFont(font => font.WithColor(RGBColor.White))
                );

                network.AddNode(4, node => node
                    .WithLabel("Development Team")
                    .WithLevel(2)
                    .WithGroup("tech")
                );

                network.AddNode(5, node => node
                    .WithLabel("QA Team")
                    .WithLevel(2)
                    .WithGroup("tech")
                );

                network.AddNode(6, node => node
                    .WithLabel("Finance Team")
                    .WithLevel(2)
                    .WithGroup("finance")
                );

                // Add organization connections
                network.AddEdge(1, 2);
                network.AddEdge(1, 3);
                network.AddEdge(2, 4);
                network.AddEdge(2, 5);
                network.AddEdge(3, 6);

                // Configure groups
                network.WithGroup("tech", group => group
                    .WithColor(RGBColor.FromRGB(155, 89, 182))
                    .WithFont(font => font.WithColor(RGBColor.White))
                );

                network.WithGroup("finance", group => group
                    .WithColor(RGBColor.FromRGB(243, 156, 18))
                    .WithFont(font => font.WithColor(RGBColor.White))
                );
            });

            page.LineBreak();

            // Example 2: Network with Physics
            page.DiagramNetwork(network => {
                network
                    .WithId("physicsNetwork")
                    .WithSize("100%", "600px")
                    .WithLoadingBar(true)
                    .WithPhysics(physics => {
                        physics
                            .WithEnabled(true)
                            .WithSolver(VisNetworkPhysicsSolver.BarnesHut);
                    })
                    .WithInteraction(interaction => {
                        interaction
                            .WithDragNodes(true)
                            .WithHover(true)
                            .WithHoverConnectedEdges(true)
                            .WithMultiselect(true)
                            .WithNavigationButtons(true);
                    });

                // Create a network with multiple nodes
                var nodePositions = new[] {
                    new { id = 1, label = "Server", x = 0, y = 0 },
                    new { id = 2, label = "Database", x = -200, y = -100 },
                    new { id = 3, label = "Client A", x = 200, y = -100 },
                    new { id = 4, label = "Client B", x = 200, y = 100 },
                    new { id = 5, label = "API Gateway", x = 0, y = -200 },
                    new { id = 6, label = "Cache", x = -200, y = 100 }
                };

                foreach (var pos in nodePositions) {
                    network.AddNode(pos.id, node => node
                        .WithLabel(pos.label)
                        .WithPosition(pos.x, pos.y)
                        .WithShape(VisNetworkNodeShape.Box)
                        .WithColor(RGBColor.Blue)
                        .WithFont(font => font.WithColor(RGBColor.White))
                    );
                }

                // Add connections
                network.AddEdge(1, 2, edge => edge.WithLabel("Query").WithArrows(arrows => arrows.WithTo(true)));
                network.AddEdge(1, 3, edge => edge.WithLabel("Response").WithArrows(arrows => arrows.WithTo(true)));
                network.AddEdge(1, 4, edge => edge.WithLabel("Response").WithArrows(arrows => arrows.WithTo(true)));
                network.AddEdge(5, 1, edge => edge.WithLabel("Route").WithArrows(arrows => arrows.WithTo(true)));
                network.AddEdge(1, 6, edge => edge.WithLabel("Cache").WithArrows(arrows => arrows.WithTo(true).WithFrom(true)));
            });

            page.LineBreak();

            // Example 3: Network with Different Node Shapes
            page.DiagramNetwork(network => {
                network
                    .WithId("shapesNetwork")
                    .WithSize("100%", "500px")
                    .WithPhysics(false);

                var shapes = new[] {
                    VisNetworkNodeShape.Box,
                    VisNetworkNodeShape.Circle,
                    VisNetworkNodeShape.Ellipse,
                    VisNetworkNodeShape.Database,
                    VisNetworkNodeShape.Diamond,
                    VisNetworkNodeShape.Dot,
                    VisNetworkNodeShape.Square,
                    VisNetworkNodeShape.Star,
                    VisNetworkNodeShape.Triangle,
                    VisNetworkNodeShape.TriangleDown,
                    VisNetworkNodeShape.Hexagon
                };

                var x = -500;
                var y = 0;
                int nodeId = 1;

                foreach (var shape in shapes) {
                    network.AddNode(nodeId, node => node
                        .WithLabel(shape.ToString())
                        .WithShape(shape)
                        .WithPosition(x, y)
                        .WithSize(30)
                    );

                    x += 100;
                    if (nodeId % 6 == 0) {
                        x = -500;
                        y += 100;
                    }
                    nodeId++;
                }
            });

            page.LineBreak();

            // Example 4: Network with Custom Styling
            page.DiagramNetwork(network => {
                network
                    .WithId("styledNetwork")
                    .WithSize("100%", "500px")
                    .WithOptions(options => {
                        // Global node styling
                        options.WithNodes(nodes => {
                            nodes
                                .WithBorderWidth(2, 4)  // normal, selected
                                .WithShape(VisNetworkNodeShape.Box);
                        });

                        // Global edge styling
                        options.WithEdges(edges => {
                            edges
                                .WithWidth(2)
                                .WithColor(RGBColor.FromRGB(132, 132, 132))
                                .WithArrows(arrows => arrows.WithTo(true));
                        });
                    });

                // Add styled nodes
                network.AddNode("n1", node => node
                    .WithLabel("Important Node")
                    .WithColor(RGBColor.Red)
                    .WithSize(50)
                    .WithFont(font => font.WithColor(RGBColor.White).WithSize(16))
                );

                network.AddNode("n2", node => node
                    .WithLabel("Regular Node")
                    .WithColor(RGBColor.Blue)
                );

                network.AddNode("n3", node => node
                    .WithLabel("Warning Node")
                    .WithColor(RGBColor.Orange)
                    .WithShape(VisNetworkNodeShape.Triangle)
                );

                network.AddNode("n4", node => node
                    .WithLabel("Success Node")
                    .WithColor(RGBColor.Green)
                    .WithShape(VisNetworkNodeShape.Circle)
                );

                // Add styled edges
                network.AddEdge("n1", "n2", edge => edge
                    .WithLabel("Critical Path")
                    .WithColor(RGBColor.Red)
                    .WithWidth(4)
                );

                network.AddEdge("n2", "n3", edge => edge
                    .WithLabel("Warning")
                    .WithColor(RGBColor.Orange)
                    .WithDashes(true)
                );

                network.AddEdge("n3", "n4", edge => edge
                    .WithLabel("Success")
                    .WithColor(RGBColor.Green)
                    .WithWidth(3)
                );

                network.AddEdge("n4", "n1", edge => edge
                    .WithLabel("Feedback")
                    .WithColor(RGBColor.Gray)
                    .WithDashes(new[] { 5, 10 })
                );
            });

            page.LineBreak();

            // Example 5: Network with Image Nodes
            page.DiagramNetwork(network => {
                network
                    .WithId("imageNetwork")
                    .WithSize("100%", "400px");

                // Central server with circular image
                network.AddNode("server", node => node
                    .WithLabel("Main Server")
                    .WithShape(VisNetworkNodeShape.CircularImage)
                    .WithImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                    .WithSize(60)
                );

                // Client nodes with regular images
                for (int i = 1; i <= 3; i++) {
                    network.AddNode($"client{i}", node => node
                        .WithLabel($"Client {i}")
                        .WithShape(VisNetworkNodeShape.Image)
                        .WithImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .WithSize(40)
                    );

                    network.AddEdge("server", $"client{i}", edge => edge
                        .WithArrows(arrows => arrows.WithTo(true).WithFrom(true))
                        .WithLabel($"Connection {i}")
                    );
                }
            });

            page.LineBreak();

            // Example 6: Editable Network
            page.DiagramNetwork(network => {
                network
                    .WithId("editableNetwork")
                    .WithSize("100%", "500px")
                    .WithManipulation(manipulation => {
                        manipulation
                            .WithEnabled(true)
                            .WithAddNode(true)
                            .WithAddEdge(true)
                            .WithEditNode(true)
                            .WithEditEdge(true)
                            .WithDeleteNode(true)
                            .WithDeleteEdge(true);
                    })
                    .WithOptions(options => {
                        options.WithLocale(VisNetworkLocale.En);
                    });

                // Add initial nodes
                network.AddNode(1, node => node.WithLabel("Node 1").WithShape(VisNetworkNodeShape.Box));
                network.AddNode(2, node => node.WithLabel("Node 2").WithShape(VisNetworkNodeShape.Circle));
                network.AddNode(3, node => node.WithLabel("Node 3").WithShape(VisNetworkNodeShape.Database));
                
                // Add initial edges
                network.AddEdge(1, 2, edge => edge.WithLabel("Connection A"));
                network.AddEdge(2, 3, edge => edge.WithLabel("Connection B"));
                network.AddEdge(3, 1, edge => edge.WithLabel("Connection C").WithDashes(true));
            });
        });

        document.Save("AdvancedVisNetworkDemo.html", openInBrowser);
    }
}