namespace HtmlForgeX.Examples.Containers;

internal class VisNetworkLayoutExamples {
    public static void Demo(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("VisNetwork Layout Examples");

        using var document = new Document {
            Head = { Title = "VisNetwork Layout Examples", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.H2("VisNetwork Layout Examples");
            page.LineBreak();

            // Example 1: Hierarchical Layout with Different Directions
            page.H3("Hierarchical Layout - Different Directions");
            
            var directions = new[] { 
                (VisNetworkLayoutDirection.Ud, "Up-Down"),
                (VisNetworkLayoutDirection.Du, "Down-Up"),
                (VisNetworkLayoutDirection.Lr, "Left-Right"),
                (VisNetworkLayoutDirection.Rl, "Right-Left")
            };

            foreach (var (direction, name) in directions) {
                page.H4($"{name} Direction");
                page.DiagramNetwork(network => {
                    network
                        .WithId($"hierarchical{direction}")
                        .WithSize("48%", "300px")
                        .WithHierarchicalLayout(direction)
                        .WithPhysics(false)
                        .WithOptions(options => {
                            options.WithLayout(layout => {
                                layout.WithHierarchical(new VisNetworkHierarchicalOptions()
                                    .WithEnabled(true)
                                    .WithLevelSeparation(100)
                                    .WithNodeSpacing(100)
                                    .WithTreeSpacing(200)
                                    .WithBlockShifting(true)
                                    .WithEdgeMinimization(true)
                                    .WithParentCentralization(true)
                                    .WithDirection(direction)
                                    .WithSortMethod(VisNetworkLayoutSort.Directed));
                            });
                        });

                    // Create tree structure
                    network.AddNode(1, node => node.WithLabel("Root").WithLevel(0).WithColor(RGBColor.DarkRed));
                    network.AddNode(2, node => node.WithLabel("Child 1").WithLevel(1).WithColor(RGBColor.DarkBlue));
                    network.AddNode(3, node => node.WithLabel("Child 2").WithLevel(1).WithColor(RGBColor.DarkBlue));
                    network.AddNode(4, node => node.WithLabel("Grandchild 1").WithLevel(2).WithColor(RGBColor.DarkGreen));
                    network.AddNode(5, node => node.WithLabel("Grandchild 2").WithLevel(2).WithColor(RGBColor.DarkGreen));

                    network.AddEdge(1, 2);
                    network.AddEdge(1, 3);
                    network.AddEdge(2, 4);
                    network.AddEdge(3, 5);
                });
            }

            page.LineBreak();

            // Example 2: Hierarchical Layout with Overlap Avoidance
            page.H3("Hierarchical Layout with Overlap Avoidance");
            page.DiagramNetwork(network => {
                network
                    .WithId("hierarchicalOverlap")
                    .WithSize("100%", "600px")
                    .WithPhysics(physics => {
                        physics
                            .WithEnabled(false)
                            .WithStabilization(new VisNetworkStabilizationOptions()
                                .WithEnabled(false));
                    })
                    .WithLayout(layout => {
                        layout.WithHierarchical(new VisNetworkHierarchicalOptions()
                            .WithEnabled(true)
                            .WithLevelSeparation(150)
                            .WithNodeSpacing(300)
                            .WithTreeSpacing(400)
                            .WithBlockShifting(true)
                            .WithEdgeMinimization(true)
                            .WithParentCentralization(true)
                            .WithDirection(VisNetworkLayoutDirection.Ud)
                            .WithSortMethod(VisNetworkLayoutSort.Hubsize));
                    })
                    .WithOptions(options => {
                        options.WithNodes(nodes => {
                            nodes
                                .WithShape(VisNetworkNodeShape.Box)
                                .WithWidthConstraint(minimum: 150, maximum: 150)
                                .WithFont(font => font.WithSize(14).WithFace("Arial"));
                        });
                    });

                // Create complex organization chart
                network.AddNode(1, node => node.WithLabel("CEO\nJohn Smith").WithLevel(0).WithColor(new RGBColor($"#{231:X2}{76:X2}{60:X2}")));
                
                // VPs
                network.AddNode(2, node => node.WithLabel("VP Engineering\nJane Doe").WithLevel(1).WithColor(new RGBColor($"#{52:X2}{152:X2}{219:X2}")));
                network.AddNode(3, node => node.WithLabel("VP Sales\nBob Johnson").WithLevel(1).WithColor(new RGBColor($"#{52:X2}{152:X2}{219:X2}")));
                network.AddNode(4, node => node.WithLabel("VP Marketing\nAlice Brown").WithLevel(1).WithColor(new RGBColor($"#{52:X2}{152:X2}{219:X2}")));
                
                // Engineering teams
                network.AddNode(5, node => node.WithLabel("Frontend Team\nLead: Mike").WithLevel(2).WithColor(new RGBColor($"#{46:X2}{204:X2}{113:X2}")));
                network.AddNode(6, node => node.WithLabel("Backend Team\nLead: Sarah").WithLevel(2).WithColor(new RGBColor($"#{46:X2}{204:X2}{113:X2}")));
                network.AddNode(7, node => node.WithLabel("DevOps Team\nLead: Tom").WithLevel(2).WithColor(new RGBColor($"#{46:X2}{204:X2}{113:X2}")));
                
                // Sales teams
                network.AddNode(8, node => node.WithLabel("Enterprise Sales\nLead: David").WithLevel(2).WithColor(new RGBColor($"#{155:X2}{89:X2}{182:X2}")));
                network.AddNode(9, node => node.WithLabel("SMB Sales\nLead: Emma").WithLevel(2).WithColor(new RGBColor($"#{155:X2}{89:X2}{182:X2}")));
                
                // Marketing teams
                network.AddNode(10, node => node.WithLabel("Content Team\nLead: Chris").WithLevel(2).WithColor(new RGBColor($"#{243:X2}{156:X2}{18:X2}")));
                network.AddNode(11, node => node.WithLabel("Digital Marketing\nLead: Lisa").WithLevel(2).WithColor(new RGBColor($"#{243:X2}{156:X2}{18:X2}")));

                // Add connections
                network.AddEdge(1, 2);
                network.AddEdge(1, 3);
                network.AddEdge(1, 4);
                network.AddEdge(2, 5);
                network.AddEdge(2, 6);
                network.AddEdge(2, 7);
                network.AddEdge(3, 8);
                network.AddEdge(3, 9);
                network.AddEdge(4, 10);
                network.AddEdge(4, 11);
            });

            page.LineBreak();

            // Example 3: Random Layout with Seed
            page.H3("Random Layout with Different Seeds");
            for (int seed = 1; seed <= 2; seed++) {
                page.H4($"Random Seed: {seed}");
                page.DiagramNetwork(network => {
                    network
                        .WithId($"randomLayout{seed}")
                        .WithSize("48%", "400px")
                        .WithLayout(layout => {
                            layout
                                .WithRandomSeed(seed)
                                .WithImprovedLayout(true);
                        })
                        .WithPhysics(physics => {
                            physics.WithEnabled(true)
                                .WithStabilization(new VisNetworkStabilizationOptions()
                                    .WithIterations(100));
                        });

                    // Create network
                    for (int i = 1; i <= 10; i++) {
                        network.AddNode(i, node => node
                            .WithLabel($"R{i}")
                            .WithShape(VisNetworkNodeShape.Circle)
                            .WithColor(new RGBColor($"#{100:X2}{150 + i * 10:X2}{200:X2}"))
                        );
                    }

                    // Create connections
                    for (int i = 1; i < 10; i++) {
                        network.AddEdge(i, i + 1);
                        if (i % 3 == 0) network.AddEdge(i, (i + 3) % 10 + 1);
                    }
                });
            }

            page.LineBreak();

            // Example 4: Cluster Layout
            page.H3("Cluster Layout");
            page.DiagramNetwork(network => {
                network
                    .WithId("clusterLayout")
                    .WithSize("100%", "500px")
                    .WithOptions(options => {
                        options
                            .WithPhysics(physics => {
                                physics
                                    .WithEnabled(true)
                                    .WithSolver(VisNetworkPhysicsSolver.ForceAtlas2based)
                                    .WithForceAtlas2Based(forceAtlas2 => {
                                        forceAtlas2
                                            .WithGravitationalConstant(-50)
                                            .WithCentralGravity(0.01)
                                            .WithSpringLength(150)
                                            .WithSpringConstant(0.2);
                                    });
                            });
                    });

                // Define groups/clusters
                var groups = new[] { "Database", "Backend", "Frontend", "Mobile" };
                var groupColors = new Dictionary<string, RGBColor> {
                    ["Database"] = RGBColor.DarkRed,
                    ["Backend"] = RGBColor.DarkBlue,
                    ["Frontend"] = RGBColor.DarkGreen,
                    ["Mobile"] = RGBColor.DarkOrange
                };

                // Configure groups
                foreach (var group in groups) {
                    network.WithGroup(group, g => g
                        .WithColor(groupColors[group])
                        .WithFont(font => font.WithColor(RGBColor.White))
                        .WithShape(VisNetworkNodeShape.Box)
                    );
                }

                // Create nodes for each cluster
                int nodeId = 1;
                foreach (var group in groups) {
                    for (int i = 0; i < 4; i++) {
                        network.AddNode(nodeId++, node => node
                            .WithLabel($"{group} {i + 1}")
                            .WithGroup(group)
                        );
                    }
                }

                // Connect nodes within clusters
                for (int i = 0; i < groups.Length; i++) {
                    int baseId = i * 4 + 1;
                    network.AddEdge(baseId, baseId + 1);
                    network.AddEdge(baseId + 1, baseId + 2);
                    network.AddEdge(baseId + 2, baseId + 3);
                    network.AddEdge(baseId + 3, baseId);
                }

                // Connect clusters
                network.AddEdge(2, 6, edge => edge.WithLabel("API").WithColor(RGBColor.Gray));
                network.AddEdge(6, 10, edge => edge.WithLabel("REST").WithColor(RGBColor.Gray));
                network.AddEdge(10, 14, edge => edge.WithLabel("Mobile API").WithColor(RGBColor.Gray));
                network.AddEdge(2, 14, edge => edge.WithLabel("Direct").WithColor(RGBColor.Gray).WithDashes(true));
            });

            page.LineBreak();

            // Example 5: Improved Layout
            page.H3("Improved Layout Algorithm");
            page.DiagramNetwork(network => {
                network
                    .WithId("improvedLayout")
                    .WithSize("100%", "500px")
                    .WithLayout(layout => {
                        layout
                            .WithImprovedLayout(true)
                            .WithClusterThreshold(150);
                    })
                    .WithPhysics(physics => {
                        physics
                            .WithEnabled(true)
                            .WithSolver(VisNetworkPhysicsSolver.BarnesHut)
                            .WithBarnesHut(barnesHut => {
                                barnesHut
                                    .WithGravitationalConstant(-2000)
                                    .WithCentralGravity(0.3)
                                    .WithSpringLength(100);
                            });
                    });

                // Create a complex network
                var nodeTypes = new[] { "Server", "Database", "Cache", "Client", "API" };
                var nodeShapes = new Dictionary<string, VisNetworkNodeShape> {
                    ["Server"] = VisNetworkNodeShape.Box,
                    ["Database"] = VisNetworkNodeShape.Database,
                    ["Cache"] = VisNetworkNodeShape.Square,
                    ["Client"] = VisNetworkNodeShape.Circle,
                    ["API"] = VisNetworkNodeShape.Hexagon
                };

                // Create nodes
                int id = 1;
                var nodesByType = new Dictionary<string, List<int>>();
                foreach (var type in nodeTypes) {
                    nodesByType[type] = new List<int>();
                    for (int i = 0; i < 3; i++) {
                        network.AddNode(id, node => node
                            .WithLabel($"{type} {i + 1}")
                            .WithShape(nodeShapes[type])
                            .WithColor(RGBColor.Blue)
                            .WithFont(font => font.WithColor(RGBColor.White))
                        );
                        nodesByType[type].Add(id);
                        id++;
                    }
                }

                // Create logical connections
                foreach (var server in nodesByType["Server"]) {
                    foreach (var db in nodesByType["Database"]) {
                        network.AddEdge(server, db);
                    }
                    foreach (var cache in nodesByType["Cache"]) {
                        network.AddEdge(server, cache);
                    }
                }

                foreach (var api in nodesByType["API"]) {
                    foreach (var server in nodesByType["Server"]) {
                        network.AddEdge(api, server);
                    }
                }

                foreach (var client in nodesByType["Client"]) {
                    foreach (var api in nodesByType["API"]) {
                        network.AddEdge(client, api);
                    }
                }
            });
        });

        document.Save("VisNetworkLayoutExamples.html", openInBrowser);
    }
}