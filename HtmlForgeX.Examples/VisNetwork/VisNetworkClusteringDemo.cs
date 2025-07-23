using System;

namespace HtmlForgeX.Examples.VisNetwork {
    public class VisNetworkClusteringDemo {
        public static void Create(bool openInBrowser = true) {
            HelpersSpectre.PrintTitle("VisNetwork Clustering Demo");

            using var document = new Document {
                Head = { 
                    Title = "VisNetwork Clustering Demo - Dynamic Node Grouping", 
                    Author = "HtmlForgeX"
                },
                LibraryMode = LibraryMode.Online,
                ThemeMode = ThemeMode.Light
            };

            document.Body.Page(page => {
                page.H1("VisNetwork Clustering System");
                page.Text("This demo showcases the powerful clustering capabilities of VisNetwork for managing large networks.");

                page.H2("1. Cluster by Connection");
                page.Text("Click on a node to cluster it with all its connected nodes.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("clusterByConnectionDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(true));
                            options.WithEvents(events => {
                                events.WithClick(@"
                                    function(params) {
                                        if (params.nodes.length > 0) {
                                            var nodeId = params.nodes[0];
                                            // Check if it's a cluster
                                            if (network.isCluster(nodeId)) {
                                                network.openCluster(nodeId);
                                            } else {
                                                network.clusterByConnection(nodeId, {
                                                    clusterNodeProperties: {
                                                        label: 'Cluster ' + nodeId,
                                                        shape: 'database',
                                                        color: '#ff9999',
                                                        font: { size: 20 }
                                                    }
                                                });
                                            }
                                        }
                                    }"
                                );
                            });
                        });

                    // Create a network with central hub
                    network.AddNode("hub", node => node
                        .WithLabel("Central Hub")
                        .WithShape(VisNetworkNodeShape.Star)
                        .WithColor(RGBColor.DarkBlue)
                        .WithSize(30)
                    );

                    for (int i = 1; i <= 8; i++) {
                        network.AddNode($"node{i}", node => node
                            .WithLabel($"Node {i}")
                            .WithShape(VisNetworkNodeShape.Circle)
                            .WithColor(RGBColor.LightBlue)
                        );
                        network.AddEdge("hub", $"node{i}");
                        
                        // Add sub-nodes
                        for (int j = 1; j <= 2; j++) {
                            var subId = $"sub{i}-{j}";
                            network.AddNode(subId, node => node
                                .WithLabel($"Sub {i}.{j}")
                                .WithShape(VisNetworkNodeShape.Dot)
                                .WithColor(RGBColor.LightGray)
                                .WithSize(10)
                            );
                            network.AddEdge($"node{i}", subId);
                        }
                    }
                });

                page.H2("2. Cluster by Hub Size");
                page.Text("Automatically cluster nodes with many connections (hubs).");

                page.DiagramNetwork(network => {
                    network
                        .WithId("clusterByHubsizeDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics
                                .WithEnabled(true)
                                .WithSolver(VisNetworkPhysicsSolver.ForceAtlas2based)
                            );
                        })
                        // Apply hub clustering after network is created
                        .ClusterByHubsize(3, cluster => cluster
                            .WithClusterNodeProperties(props => props
                                .WithShape(VisNetworkNodeShape.Square)
                                .WithColor(RGBColor.Purple)
                                .WithFont(font => font.WithSize(20).WithColor(RGBColor.White))
                            )
                            .WithProcessProperties(VisNetworkClusteringTemplates.ShowNodeCount)
                        );

                    // Create a complex network with multiple hubs
                    // Hub 1
                    network.AddNode("hub1", node => node
                        .WithLabel("Hub 1")
                        .WithShape(VisNetworkNodeShape.Diamond)
                        .WithColor(RGBColor.Red)
                    );
                    
                    // Hub 2
                    network.AddNode("hub2", node => node
                        .WithLabel("Hub 2")
                        .WithShape(VisNetworkNodeShape.Diamond)
                        .WithColor(RGBColor.Green)
                    );
                    
                    // Hub 3
                    network.AddNode("hub3", node => node
                        .WithLabel("Hub 3")
                        .WithShape(VisNetworkNodeShape.Diamond)
                        .WithColor(RGBColor.Blue)
                    );
                    
                    // Connect hubs
                    network.AddEdge("hub1", "hub2");
                    network.AddEdge("hub2", "hub3");
                    network.AddEdge("hub3", "hub1");
                    
                    // Add peripheral nodes to each hub
                    for (int h = 1; h <= 3; h++) {
                        for (int i = 1; i <= 5; i++) {
                            var nodeId = $"h{h}n{i}";
                            network.AddNode(nodeId, node => node
                                .WithLabel($"H{h}-N{i}")
                                .WithShape(VisNetworkNodeShape.Circle)
                                .WithColor(h == 1 ? RGBColor.Pink : (h == 2 ? RGBColor.LightGreen : RGBColor.LightBlue))
                                .WithSize(15)
                            );
                            network.AddEdge($"hub{h}", nodeId);
                        }
                    }
                });

                page.H2("3. Cluster Outliers");
                page.Text("Cluster all nodes with only one connection to clean up the network.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("clusterOutliersDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(true));
                        });

                    // Create a network with many outliers
                    network.AddNode("core1", node => node
                        .WithLabel("Core 1")
                        .WithShape(VisNetworkNodeShape.Box)
                        .WithColor(RGBColor.DarkGreen)
                        .WithPosition(-100, 0)
                    );
                    
                    network.AddNode("core2", node => node
                        .WithLabel("Core 2")
                        .WithShape(VisNetworkNodeShape.Box)
                        .WithColor(RGBColor.DarkGreen)
                        .WithPosition(100, 0)
                    );
                    
                    network.AddEdge("core1", "core2");
                    
                    // Add many outlier nodes
                    for (int i = 1; i <= 10; i++) {
                        var outlierId = $"outlier{i}";
                        network.AddNode(outlierId, node => node
                            .WithLabel($"Out {i}")
                            .WithShape(VisNetworkNodeShape.Dot)
                            .WithColor(RGBColor.Gray)
                            .WithSize(10)
                        );
                        network.AddEdge(i <= 5 ? "core1" : "core2", outlierId);
                    }
                    
                    // Apply outlier clustering
                    network.ClusterOutliers(cluster => cluster
                        .WithClusterNodeProperties(props => props
                            .WithShape(VisNetworkNodeShape.Circle)
                            .WithColor(RGBColor.Orange)
                            .WithLabel("Outliers")
                        )
                        .WithProcessProperties(@"
                            function(clusterOptions, childNodesOptions) {
                                clusterOptions.label = 'Outliers (' + childNodesOptions.length + ')';
                                clusterOptions.title = 'Click to expand ' + childNodesOptions.length + ' outlier nodes';
                                return clusterOptions;
                            }"
                        )
                    );
                });

                page.H2("4. Cluster by Group");
                page.Text("Cluster nodes based on their group property.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("clusterByGroupDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(false));
                            options.WithGroup("frontend", group => group
                                .WithColor(RGBColor.Blue)
                                .WithShape(VisNetworkNodeShape.Circle));
                            options.WithGroup("backend", group => group
                                .WithColor(RGBColor.Green)
                                .WithShape(VisNetworkNodeShape.Box));
                            options.WithGroup("database", group => group
                                .WithColor(RGBColor.Red)
                                .WithShape(VisNetworkNodeShape.Database));
                        });

                    // Create nodes with groups
                    // Frontend nodes
                    for (int i = 1; i <= 4; i++) {
                        network.AddNode($"fe{i}", node => node
                            .WithLabel($"Frontend {i}")
                            .WithGroup("frontend")
                            .WithPosition(-200 + i * 50, -100)
                        );
                    }
                    
                    // Backend nodes
                    for (int i = 1; i <= 3; i++) {
                        network.AddNode($"be{i}", node => node
                            .WithLabel($"Backend {i}")
                            .WithGroup("backend")
                            .WithPosition(-100 + i * 70, 0)
                        );
                    }
                    
                    // Database nodes
                    for (int i = 1; i <= 2; i++) {
                        network.AddNode($"db{i}", node => node
                            .WithLabel($"Database {i}")
                            .WithGroup("database")
                            .WithPosition(-50 + i * 100, 100)
                        );
                    }
                    
                    // Connect layers
                    network.AddEdge("fe1", "be1");
                    network.AddEdge("fe2", "be1");
                    network.AddEdge("fe3", "be2");
                    network.AddEdge("fe4", "be3");
                    network.AddEdge("be1", "db1");
                    network.AddEdge("be2", "db1");
                    network.AddEdge("be3", "db2");
                    
                    // Cluster by groups
                    network.ClusterByGroup("frontend", cluster => cluster
                        .WithClusterNodeProperties(props => props
                            .WithLabel("Frontend Layer")
                            .WithShape(VisNetworkNodeShape.Square)
                            .WithColor(RGBColor.DarkBlue)
                            .WithFont(font => font.WithColor(RGBColor.White))
                        )
                    );
                    
                    network.ClusterByGroup("backend", cluster => cluster
                        .WithClusterNodeProperties(props => props
                            .WithLabel("Backend Layer")
                            .WithShape(VisNetworkNodeShape.Square)
                            .WithColor(RGBColor.DarkGreen)
                            .WithFont(font => font.WithColor(RGBColor.White))
                        )
                    );
                });

                page.H2("5. Custom Clustering");
                page.Text("Use custom join conditions to create complex clustering rules.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("customClusteringDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(true));
                            options.WithInteraction(interaction => interaction
                                .WithMultiselect(true)
                                .WithSelectConnectedEdges(false)
                            );
                        });

                    // Create nodes with custom properties
                    var random = new Random(42);
                    for (int i = 1; i <= 20; i++) {
                        var priority = random.Next(1, 4); // 1-3 priority levels
                        var department = new[] { "Sales", "Engineering", "Marketing" }[random.Next(3)];
                        
                        network.AddNode(i, node => node
                            .WithLabel($"{department[0]}{i}")
                            .WithTitle($"{department} - Priority {priority}")
                            .WithColor(priority == 1 ? RGBColor.Red : (priority == 2 ? RGBColor.Yellow : RGBColor.Green))
                            .WithShape(VisNetworkNodeShape.Circle)
                            // Store custom data (would need custom property support in real implementation)
                        );
                    }
                    
                    // Add random connections
                    for (int i = 1; i <= 30; i++) {
                        var from = random.Next(1, 21);
                        var to = random.Next(1, 21);
                        if (from != to) {
                            network.AddEdge(from, to);
                        }
                    }
                    
                    // Cluster high priority nodes
                    network.Cluster(cluster => cluster
                        .WithJoinCondition(@"
                            function(nodeOptions, childNodeOptions) {
                                // Cluster red (high priority) nodes
                                return childNodeOptions && childNodeOptions.color === '#FF0000';
                            }"
                        )
                        .WithClusterNodeProperties(props => props
                            .WithLabel("High Priority")
                            .WithShape(VisNetworkNodeShape.Star)
                            .WithColor(RGBColor.DarkRed)
                            .WithSize(40)
                        )
                        .WithProcessProperties(VisNetworkClusteringTemplates.ShowNodeCount)
                    );
                });

                // Interactive note
                page.H2("Interactive Features");
                page.Text("• Click on any node in the first demo to cluster it with its connections");
                page.LineBreak();
                page.Text("• Click on a cluster to open it and reveal the contained nodes");
                page.LineBreak();
                page.Text("• Hub nodes are automatically clustered based on connection count");
                page.LineBreak();
                page.Text("• Outlier nodes with single connections are grouped together");

                page.H2("Benefits of Clustering");
                page.Text("• Performance: Handle networks with thousands of nodes");
                page.LineBreak();
                page.Text("• Organization: Group related nodes logically");
                page.LineBreak();
                page.Text("• Clarity: Reduce visual complexity");
                page.LineBreak();
                page.Text("• Interactivity: Click to expand/collapse clusters");
                page.LineBreak();
                page.Text("• Flexibility: Custom clustering rules and appearance");
            });

            document.Save("VisNetworkClusteringDemo.html", openInBrowser);
            HelpersSpectre.Success($"VisNetwork Clustering Demo created at: VisNetworkClusteringDemo.html");
        }
    }
}