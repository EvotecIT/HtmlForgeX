namespace HtmlForgeX.Examples.Containers;

internal class VisNetworkPhysicsExamples {
    public static void Demo(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("VisNetwork Physics Examples");

        using var document = new Document {
            Head = { Title = "VisNetwork Physics Examples", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.H2("VisNetwork Physics Simulation Examples");
            page.LineBreak();

            // Example 1: Barnes Hut Physics
            page.H3("Barnes Hut Physics");
            page.DiagramNetwork(network => {
                network
                    .WithId("barnesHutPhysics")
                    .WithSize("100%", "400px")
                    .WithPhysics(physics => {
                        physics
                            .WithEnabled(true)
                            .WithSolver(VisNetworkPhysicsSolver.BarnesHut)
                            .WithBarnesHut(barnesHut => {
                                barnesHut
                                    .WithGravitationalConstant(-2000)
                                    .WithCentralGravity(0.3)
                                    .WithSpringLength(95)
                                    .WithSpringConstant(0.04)
                                    .WithDamping(0.09)
                                    .WithAvoidOverlap(0.5);
                            })
                            .WithStabilization(new VisNetworkStabilizationOptions()
                                .WithEnabled(true)
                                .WithIterations(1000)
                                .WithUpdateInterval(100)
                                .WithOnlyDynamicEdges(false)
                                .WithFit(true));
                    });

                // Create a network of nodes
                for (int i = 1; i <= 10; i++) {
                    network.AddNode(i, node => node
                        .WithLabel($"Node {i}")
                        .WithShape(VisNetworkNodeShape.Dot)
                        .WithSize(20)
                        .WithColor(new RGBColor($"#{100 + i * 15:X2}{50:X2}{200 - i * 15:X2}"))
                    );
                }

                // Create random connections
                network.AddEdge(1, 2);
                network.AddEdge(1, 3);
                network.AddEdge(2, 4);
                network.AddEdge(2, 5);
                network.AddEdge(3, 6);
                network.AddEdge(4, 7);
                network.AddEdge(5, 8);
                network.AddEdge(6, 9);
                network.AddEdge(7, 10);
                network.AddEdge(8, 10);
                network.AddEdge(9, 10);
            });

            page.LineBreak();

            // Example 2: Force Atlas 2 Based Physics
            page.H3("Force Atlas 2 Based Physics");
            page.DiagramNetwork(network => {
                network
                    .WithId("forceAtlas2Physics")
                    .WithSize("100%", "400px")
                    .WithPhysics(physics => {
                        physics
                            .WithEnabled(true)
                            .WithSolver(VisNetworkPhysicsSolver.ForceAtlas2based)
                            .WithForceAtlas2Based(forceAtlas2 => {
                                forceAtlas2
                                    .WithGravitationalConstant(-50)
                                    .WithCentralGravity(0.01)
                                    .WithSpringConstant(0.08)
                                    .WithSpringLength(100)
                                    .WithDamping(0.4)
                                    .WithAvoidOverlap(0);
                            });
                    });

                // Create a star topology
                network.AddNode("center", node => node
                    .WithLabel("Central Hub")
                    .WithShape(VisNetworkNodeShape.Star)
                    .WithSize(40)
                    .WithColor(RGBColor.DarkGoldenrod)
                );

                for (int i = 1; i <= 8; i++) {
                    network.AddNode($"satellite{i}", node => node
                        .WithLabel($"Satellite {i}")
                        .WithShape(VisNetworkNodeShape.Circle)
                        .WithSize(25)
                        .WithColor(RGBColor.SkyBlue)
                    );
                    network.AddEdge("center", $"satellite{i}");
                }
            });

            page.LineBreak();

            // Example 3: Repulsion Physics
            page.H3("Repulsion Physics");
            page.DiagramNetwork(network => {
                network
                    .WithId("repulsionPhysics")
                    .WithSize("100%", "400px")
                    .WithPhysics(physics => {
                        physics
                            .WithEnabled(true)
                            .WithSolver(VisNetworkPhysicsSolver.Repulsion)
                            .WithRepulsion(repulsion => {
                                repulsion
                                    .WithNodeDistance(120)
                                    .WithCentralGravity(0.2)
                                    .WithSpringLength(200)
                                    .WithSpringConstant(0.05)
                                    .WithDamping(0.09);
                            })
                            .WithMaxVelocity(50)
                            .WithMinVelocity(0.1)
                            .WithTimestep(0.5);
                    });

                // Create a mesh network
                var nodeCount = 6;
                for (int i = 1; i <= nodeCount; i++) {
                    network.AddNode(i, node => node
                        .WithLabel($"Mesh Node {i}")
                        .WithShape(VisNetworkNodeShape.Box)
                        .WithColor(RGBColor.Purple)
                        .WithFont(font => font.WithColor(RGBColor.White))
                    );
                }

                // Connect each node to every other node
                for (int i = 1; i <= nodeCount; i++) {
                    for (int j = i + 1; j <= nodeCount; j++) {
                        network.AddEdge(i, j, edge => edge
                            .WithColor(RGBColor.LightGray)
                            .WithWidth(1)
                        );
                    }
                }
            });

            page.LineBreak();

            // Example 4: Hierarchical Repulsion
            page.H3("Hierarchical Repulsion");
            page.DiagramNetwork(network => {
                network
                    .WithId("hierarchicalRepulsion")
                    .WithSize("100%", "500px")
                    .WithPhysics(physics => {
                        physics
                            .WithEnabled(true)
                            .WithSolver(VisNetworkPhysicsSolver.HierarchicalRepulsion)
                            .WithHierarchicalRepulsion(hierarchical => {
                                hierarchical
                                    .WithNodeDistance(120)
                                    .WithCentralGravity(0.0)
                                    .WithSpringLength(100)
                                    .WithSpringConstant(0.01)
                                    .WithDamping(0.09)
                                    .WithAvoidOverlap(0.5);
                            });
                    })
                    .WithLayout(layout => {
                        layout.WithHierarchical(new VisNetworkHierarchicalOptions()
                            .WithEnabled(true)
                            .WithLevelSeparation(150)
                            .WithNodeSpacing(100)
                            .WithTreeSpacing(200)
                            .WithBlockShifting(true)
                            .WithEdgeMinimization(true)
                            .WithParentCentralization(true)
                            .WithDirection(VisNetworkLayoutDirection.Ud)
                            .WithSortMethod(VisNetworkLayoutSort.Hubsize));
                    });

                // Create hierarchical structure
                network.AddNode(1, node => node.WithLabel("Root").WithLevel(0).WithColor(RGBColor.DarkRed));
                network.AddNode(2, node => node.WithLabel("Branch A").WithLevel(1).WithColor(RGBColor.DarkBlue));
                network.AddNode(3, node => node.WithLabel("Branch B").WithLevel(1).WithColor(RGBColor.DarkBlue));
                network.AddNode(4, node => node.WithLabel("Leaf A1").WithLevel(2).WithColor(RGBColor.DarkGreen));
                network.AddNode(5, node => node.WithLabel("Leaf A2").WithLevel(2).WithColor(RGBColor.DarkGreen));
                network.AddNode(6, node => node.WithLabel("Leaf B1").WithLevel(2).WithColor(RGBColor.DarkGreen));
                network.AddNode(7, node => node.WithLabel("Leaf B2").WithLevel(2).WithColor(RGBColor.DarkGreen));

                network.AddEdge(1, 2);
                network.AddEdge(1, 3);
                network.AddEdge(2, 4);
                network.AddEdge(2, 5);
                network.AddEdge(3, 6);
                network.AddEdge(3, 7);
            });

            page.LineBreak();

            // Example 5: Wind Physics Effect
            page.H3("Wind Physics Effect");
            page.DiagramNetwork(network => {
                network
                    .WithId("windPhysics")
                    .WithSize("100%", "400px")
                    .WithPhysics(physics => {
                        physics
                            .WithEnabled(true)
                            .WithWind(0.05, 0)
                            .WithSolver(VisNetworkPhysicsSolver.ForceAtlas2based)
                            .WithForceAtlas2Based(forceAtlas2 => {
                                forceAtlas2
                                    .WithGravitationalConstant(-30)
                                    .WithCentralGravity(0.005)
                                    .WithSpringLength(100)
                                    .WithSpringConstant(0.18)
                                    .WithDamping(0.3);
                            });
                    });

                // Create particles affected by wind
                for (int i = 1; i <= 15; i++) {
                    network.AddNode(i, node => node
                        .WithLabel($"P{i}")
                        .WithShape(VisNetworkNodeShape.Dot)
                        .WithSize(10 + (i % 3) * 5)
                        .WithColor(new RGBColor($"#{255:X2}{165 - i * 10:X2}{0:X2}"))
                        .WithMass(0.5 + (i % 3) * 0.5)
                    );
                }

                // Create light connections
                for (int i = 1; i < 15; i++) {
                    if (i % 3 != 0) {
                        network.AddEdge(i, i + 1, edge => edge
                            .WithColor(new RGBColor($"#{255:X2}{200:X2}{200:X2}"))
                            .WithWidth(0.5)
                        );
                    }
                }
            });

            page.LineBreak();

            // Example 6: Adaptive Physics
            page.H3("Adaptive Physics");
            page.DiagramNetwork(network => {
                network
                    .WithId("adaptivePhysics")
                    .WithSize("100%", "400px")
                    .WithPhysics(physics => {
                        physics
                            .WithEnabled(true)
                            .WithAdaptiveTimestep(true)
                            .WithSolver(VisNetworkPhysicsSolver.BarnesHut)
                            .WithBarnesHut(barnesHut => {
                                barnesHut
                                    .WithGravitationalConstant(-3000)
                                    .WithCentralGravity(0.1)
                                    .WithSpringLength(150)
                                    .WithSpringConstant(0.05)
                                    .WithDamping(0.2);
                            })
                            .WithStabilization(new VisNetworkStabilizationOptions()
                                .WithEnabled(true)
                                .WithIterations(2000)
                                .WithUpdateInterval(50));
                    })
                    .WithInteraction(interaction => {
                        interaction
                            .WithDragNodes(true)
                            .WithDragView(true)
                            .WithHideEdgesOnDrag(true)
                            .WithHideEdgesOnZoom(true)
                            .WithHover(true)
                            .WithNavigationButtons(true)
                            .WithSelectable(true)
                            .WithSelectConnectedEdges(true)
                            .WithZoomView(true);
                    });

                // Create dynamic network
                var colors = new[] { RGBColor.Red, RGBColor.Blue, RGBColor.Green, RGBColor.Orange, RGBColor.Purple };
                for (int i = 1; i <= 20; i++) {
                    network.AddNode(i, node => node
                        .WithLabel($"Dynamic {i}")
                        .WithShape(i % 2 == 0 ? VisNetworkNodeShape.Box : VisNetworkNodeShape.Circle)
                        .WithColor(colors[i % colors.Length])
                        .WithFont(font => font.WithColor(RGBColor.White))
                    );
                }

                // Create interesting connections
                for (int i = 1; i <= 20; i++) {
                    if (i < 20) network.AddEdge(i, i + 1);
                    if (i % 4 == 0 && i > 4) network.AddEdge(i, i - 4);
                    if (i % 3 == 0 && i < 18) network.AddEdge(i, i + 3);
                }
            });
        });

        document.Save("VisNetworkPhysicsExamples.html", openInBrowser);
    }
}