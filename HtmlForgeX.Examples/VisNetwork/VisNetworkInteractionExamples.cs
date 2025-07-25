namespace HtmlForgeX.Examples.VisNetwork;

internal class VisNetworkInteractionExamples {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("VisNetwork Interaction Examples");

        using var document = new Document {
            Head = { Title = "VisNetwork Interaction Examples", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.H2("VisNetwork Interaction & Configuration");
            page.LineBreak();

            // Example 1: Interaction Options
            page.H3("Interaction Options");
            page.DiagramNetwork(network => {
                network
                    .WithId("interactionOptions")
                    .WithSize("100%", "400px")
                    .WithInteraction(interaction => {
                        interaction
                            .WithDragNodes(true)
                            .WithDragView(true)
                            .WithHideEdgesOnDrag(true)
                            .WithHideEdgesOnZoom(true)
                            .WithHideNodesOnDrag(false)
                            .WithHover(true)
                            .WithHoverConnectedEdges(true)
                            .WithKeyboard(new VisNetworkKeyboardOptions()
                                .WithEnabled(true)
                                .WithSpeed(5, 5, 0.02)
                                .WithBindToWindow(false)
                            )
                            .WithMultiselect(true)
                            .WithNavigationButtons(true)
                            .WithSelectable(true)
                            .WithSelectConnectedEdges(true)
                            .WithTooltipDelay(300)
                            .WithZoomView(true)
                            .WithZoomSpeed(1);
                    })
                    .WithOptions(options => {
                        options.WithNodes(nodes => {
                            nodes.WithChosen(new VisNetworkChosenOptions()
                                .WithNode(true)  // Simply enable chosen functionality
                                .WithLabel(true)
                            );
                        });
                    });

                // Create interactive network
                for (int i = 1; i <= 6; i++) {
                    network.AddNode(i, node => node
                        .WithLabel($"Node {i}")
                        .WithTitle($"This is node {i}\nClick to select\nCtrl+Click for multi-select")
                        .WithShape(VisNetworkNodeShape.Box)
                        .WithColor(RGBColor.LightBlue)
                    );
                }

                network.AddEdge(1, 2, edge => edge.WithTitle("Edge 1-2"));
                network.AddEdge(2, 3, edge => edge.WithTitle("Edge 2-3"));
                network.AddEdge(3, 4, edge => edge.WithTitle("Edge 3-4"));
                network.AddEdge(4, 5, edge => edge.WithTitle("Edge 4-5"));
                network.AddEdge(5, 6, edge => edge.WithTitle("Edge 5-6"));
                network.AddEdge(6, 1, edge => edge.WithTitle("Edge 6-1"));
                network.AddEdge(1, 4, edge => edge.WithTitle("Edge 1-4"));
                network.AddEdge(2, 5, edge => edge.WithTitle("Edge 2-5"));
            });

            page.LineBreak();

            // Example 2: Configure Options
            page.H3("Configure Options");
            page.DiagramNetwork(network => {
                network
                    .WithId("configureOptions")
                    .WithSize("100%", "400px")
                    .WithOptions(options => {
                        options
                            .WithAutoResize(true)
                            .WithSize("100%", "100%")
                            .WithClickToUse(false)
                            .WithConfigure(new VisNetworkConfigureOptions()
                                .WithEnabled(true)
                                .WithFilter("nodes,edges")
                                .WithShowButton(true)
                            );
                    });

                // Simple network to configure
                network.AddNode(1, node => node.WithLabel("Configure Me"));
                network.AddNode(2, node => node.WithLabel("And Me"));
                network.AddEdge(1, 2);
            });

            page.LineBreak();

            // Example 3: Clustering
            page.H3("Network Clustering");
            page.DiagramNetwork(network => {
                network
                    .WithId("clustering")
                    .WithSize("100%", "500px")
                    .WithOptions(options => {
                        options.WithLayout(layout => {
                            layout.WithImprovedLayout(true);
                        });
                    });

                // Create clusters of nodes
                var clusters = new[] { "Frontend", "Backend", "Database", "External" };
                var clusterColors = new Dictionary<string, RGBColor> {
                    ["Frontend"] = RGBColor.Green,
                    ["Backend"] = RGBColor.Blue,
                    ["Database"] = RGBColor.Purple,
                    ["External"] = RGBColor.Orange
                };

                var nodeId = 1;
                var nodesByCluster = new Dictionary<string, List<int>>();

                foreach (var cluster in clusters) {
                    nodesByCluster[cluster] = new List<int>();

                    // Configure cluster group
                    network.WithGroup(cluster, group => group
                        .WithColor(clusterColors[cluster])
                        .WithFont(font => font.WithColor(RGBColor.White))
                    );

                    // Add nodes to cluster
                    for (int i = 0; i < 4; i++) {
                        network.AddNode(nodeId, node => node
                            .WithLabel($"{cluster} {i + 1}")
                            .WithGroup(cluster)
                            .WithShape(VisNetworkNodeShape.Box)
                        );
                        nodesByCluster[cluster].Add(nodeId);
                        nodeId++;
                    }

                    // Connect nodes within cluster
                    var clusterNodes = nodesByCluster[cluster];
                    for (int i = 0; i < clusterNodes.Count - 1; i++) {
                        network.AddEdge(clusterNodes[i], clusterNodes[i + 1]);
                    }
                }

                // Connect clusters
                network.AddEdge(nodesByCluster["Frontend"][0], nodesByCluster["Backend"][0],
                    edge => edge.WithLabel("API").WithWidth(3));
                network.AddEdge(nodesByCluster["Backend"][1], nodesByCluster["Database"][0],
                    edge => edge.WithLabel("Query").WithWidth(3));
                network.AddEdge(nodesByCluster["Frontend"][2], nodesByCluster["External"][0],
                    edge => edge.WithLabel("Service").WithWidth(3));
            });

            page.LineBreak();

            // Example 4: Locale Configuration
            page.H3("Locale Configuration");
            page.DiagramNetwork(network => {
                network
                    .WithId("localeConfig")
                    .WithSize("100%", "400px")
                    .WithManipulation(manipulation => {
                        manipulation.WithEnabled(true);
                    })
                    .WithOptions(options => {
                        options
                            .WithLocale(VisNetworkLocale.En);
                        // Locales configuration is not available in the current API
                        // The locale is set with WithLocale(VisNetworkLocale.En) above
                    });

                // Sample network
                network.AddNode(1, node => node.WithLabel("Edit Me"));
                network.AddNode(2, node => node.WithLabel("Delete Me"));
                network.AddEdge(1, 2);
            });

            page.LineBreak();

            // Example 5: Performance Configuration
            page.H3("Performance Optimized Network");
            page.DiagramNetwork(network => {
                network
                    .WithId("performanceNetwork")
                    .WithSize("100%", "600px")
                    .WithOptions(options => {
                        options
                            .WithPhysics(physics => {
                                physics
                                    .WithEnabled(true)
                                    .WithAdaptiveTimestep(true)
                                    .WithBarnesHut(barnesHut => {
                                        barnesHut
                                            .WithGravitationalConstant(-2000)
                                            .WithCentralGravity(0.1)
                                            .WithSpringLength(200)
                                            .WithSpringConstant(0.05)
                                            .WithDamping(0.1)
                                            .WithAvoidOverlap(0.5);
                                    })
                                    .WithStabilization(new VisNetworkStabilizationOptions()
                                        .WithEnabled(true)
                                        .WithIterations(1000)
                                        .WithUpdateInterval(25)
                                        .WithOnlyDynamicEdges(false)
                                        .WithFit(true))
                                    .WithMaxVelocity(146)
                                    .WithMinVelocity(0.75)
                                    .WithTimestep(0.5);
                            })
                            .WithInteraction(interaction => {
                                interaction
                                    .WithHideEdgesOnDrag(true)
                                    .WithHideEdgesOnZoom(true)
                                    .WithHideNodesOnDrag(false);
                            })
                            .WithEdges(edges => {
                                edges.WithSmooth(new VisNetworkSmoothOptions()
                                    .WithEnabled(false)  // Disable for performance
                                );
                            });
                    })
                    .WithLoadingBar(true);  // Show loading progress

                // Create large network
                var nodeCount = 50;
                var nodes = new List<int>();

                // Add nodes
                for (int i = 1; i <= nodeCount; i++) {
                    network.AddNode(i, node => node
                        .WithLabel($"N{i}")
                        .WithShape(VisNetworkNodeShape.Dot)
                        .WithSize(10 + (i % 5) * 5)
                        .WithColor(new RGBColor($"#{100 + (i * 3) % 155:X2}{100 + (i * 5) % 155:X2}{100 + (i * 7) % 155:X2}"))
                    );
                    nodes.Add(i);
                }

                // Create random connections
                var random = new Random(42);
                for (int i = 0; i < nodeCount * 2; i++) {
                    var from = nodes[random.Next(nodes.Count)];
                    var to = nodes[random.Next(nodes.Count)];
                    if (from != to) {
                        network.AddEdge(from, to, edge => edge
                            .WithId($"e{i}")
                            .WithColor(RGBColor.LightGray)
                            .WithWidth(0.5)
                        );
                    }
                }
            });

            page.LineBreak();

            // Example 6: View Options
            page.H3("View Options & Animations");
            page.DiagramNetwork(network => {
                network
                    .WithId("viewOptions")
                    .WithSize("100%", "400px")
                    .WithOptions(options => {
                        options
                            .WithNodes(nodes => {
                                nodes
                                    .WithShape(VisNetworkNodeShape.Box)
                                    .WithScaling(scaling => scaling
                                        .WithMin(10)
                                        .WithMax(30)
                                        .WithLabel(enabled: true)
                                    );
                            })
                            .WithEdges(edges => {
                                edges
                                    .WithScaling(scaling => scaling
                                        .WithMin(1)
                                        .WithMax(5)
                                    );
                            })
                            .WithInteraction(interaction => {
                                interaction
                                    .WithZoomView(true)
                                    .WithZoomSpeed(1.2);
                            });
                    });

                // Create nodes with different values for scaling
                network.AddNode(1, node => node
                    .WithLabel("Small")
                    .WithValue(10)
                    .WithColor(RGBColor.LightBlue)
                );

                network.AddNode(2, node => node
                    .WithLabel("Medium")
                    .WithValue(50)
                    .WithColor(RGBColor.Blue)
                );

                network.AddNode(3, node => node
                    .WithLabel("Large")
                    .WithValue(100)
                    .WithColor(RGBColor.DarkBlue)
                );

                network.AddNode(4, node => node
                    .WithLabel("Extra Large")
                    .WithValue(150)
                    .WithColor(RGBColor.NavyBlue)
                );

                // Edges with different values
                network.AddEdge(1, 2, edge => edge.WithValue(20).WithLabel("Thin"));
                network.AddEdge(2, 3, edge => edge.WithValue(50).WithLabel("Medium"));
                network.AddEdge(3, 4, edge => edge.WithValue(100).WithLabel("Thick"));
                network.AddEdge(4, 1, edge => edge.WithValue(150).WithLabel("Very Thick"));
            });
        });

        document.Save("VisNetworkInteractionExamples.html", openInBrowser);
    }
}