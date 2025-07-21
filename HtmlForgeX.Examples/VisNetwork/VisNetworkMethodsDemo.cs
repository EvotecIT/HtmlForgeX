using System;

namespace HtmlForgeX.Examples.VisNetwork {
    public class VisNetworkMethodsDemo {
        public static void Create(bool openInBrowser = true) {
            HelpersSpectre.PrintTitle("VisNetwork Methods API Demo");

            using var document = new Document {
                Head = { 
                    Title = "VisNetwork Methods API Demo - Viewport Control", 
                    Author = "HtmlForgeX"
                },
                LibraryMode = LibraryMode.Online,
                ThemeMode = ThemeMode.Light
            };

            document.Body.Page(page => {
                page.H1("VisNetwork Methods API");
                page.Text("This demo showcases the Methods API for programmatic control of the network viewport and behavior.");

                page.H2("1. Fit & Focus Methods");
                page.Text("Control the viewport to fit nodes or focus on specific elements.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("fitFocusDemo")
                        .WithSize("100%", "500px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(false));
                            options.WithInteraction(interaction => interaction
                                .WithNavigationButtons(true)
                                .WithKeyboard(true)
                            );
                        });

                    // Create a distributed network
                    // Cluster 1 - Top Left
                    network.AddNode("cluster1", node => node
                        .WithLabel("Cluster 1")
                        .WithShape(VisNetworkNodeShape.Star)
                        .WithColor(RGBColor.Red)
                        .WithPosition(-300, -200)
                        .WithSize(30)
                    );
                    
                    for (int i = 1; i <= 3; i++) {
                        network.AddNode($"c1n{i}", node => node
                            .WithLabel($"C1-{i}")
                            .WithShape(VisNetworkNodeShape.Circle)
                            .WithColor(RGBColor.Pink)
                            .WithPosition(-300 + i * 40, -150)
                        );
                        network.AddEdge("cluster1", $"c1n{i}");
                    }

                    // Cluster 2 - Top Right
                    network.AddNode("cluster2", node => node
                        .WithLabel("Cluster 2")
                        .WithShape(VisNetworkNodeShape.Star)
                        .WithColor(RGBColor.Blue)
                        .WithPosition(300, -200)
                        .WithSize(30)
                    );
                    
                    for (int i = 1; i <= 3; i++) {
                        network.AddNode($"c2n{i}", node => node
                            .WithLabel($"C2-{i}")
                            .WithShape(VisNetworkNodeShape.Circle)
                            .WithColor(RGBColor.LightBlue)
                            .WithPosition(300 + i * 40, -150)
                        );
                        network.AddEdge("cluster2", $"c2n{i}");
                    }

                    // Cluster 3 - Bottom
                    network.AddNode("cluster3", node => node
                        .WithLabel("Cluster 3")
                        .WithShape(VisNetworkNodeShape.Star)
                        .WithColor(RGBColor.Green)
                        .WithPosition(0, 200)
                        .WithSize(30)
                    );
                    
                    for (int i = 1; i <= 3; i++) {
                        network.AddNode($"c3n{i}", node => node
                            .WithLabel($"C3-{i}")
                            .WithShape(VisNetworkNodeShape.Circle)
                            .WithColor(RGBColor.LightGreen)
                            .WithPosition(-60 + i * 60, 250)
                        );
                        network.AddEdge("cluster3", $"c3n{i}");
                    }

                    // Connect clusters
                    network.AddEdge("cluster1", "cluster2");
                    network.AddEdge("cluster2", "cluster3");
                    network.AddEdge("cluster3", "cluster1");

                    // Add method calls with delays
                    network
                        // Start by fitting all nodes after a short delay for initialization
                        .Fit(fit => fit
                            .WithAnimation(anim => anim
                                .WithDuration(1000)
                                .WithEasingFunction(VisNetworkEasingFunction.EaseInOutQuad)
                            )
                            .WithMinZoomLevel(0.5)
                            .WithMaxZoomLevel(2.0)
                        , delay: 500)  // Add initial delay for network initialization
                        // After 2.5 seconds, focus on cluster1
                        .Focus("cluster1", focus => focus
                            .WithScale(1.5)
                            .WithAnimation(anim => anim
                                .WithDuration(1500)
                                .WithEasingFunction(VisNetworkEasingFunction.EaseInOutCubic)
                            ), 
                            2500
                        )
                        // After 4.5 seconds, focus on cluster2
                        .Focus("cluster2", focus => focus
                            .WithScale(1.5)
                            .WithOffset(50, -50)
                            .WithAnimation(true), 
                            4500
                        )
                        // After 6.5 seconds, fit only cluster3 nodes
                        .Fit(fit => fit
                            .WithNodes("cluster3", "c3n1", "c3n2", "c3n3")
                            .WithAnimation(anim => anim
                                .WithDuration(2000)
                            ), 
                            6500
                        );
                });

                page.H2("2. Movement & Navigation");
                page.Text("Programmatically move the viewport to specific positions.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("moveToDemo")
                        .WithSize("100%", "500px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(false));
                        });

                    // Create a grid of nodes
                    for (int row = 0; row < 5; row++) {
                        for (int col = 0; col < 5; col++) {
                            var id = $"grid{row}{col}";
                            network.AddNode(id, node => node
                                .WithLabel($"{row},{col}")
                                .WithShape(VisNetworkNodeShape.Box)
                                .WithColor(row == 2 && col == 2 ? RGBColor.Red : RGBColor.LightGray)
                                .WithPosition(col * 150 - 300, row * 150 - 300)
                            );
                            
                            // Connect to neighbors
                            if (col > 0) network.AddEdge(id, $"grid{row}{col-1}");
                            if (row > 0) network.AddEdge(id, $"grid{row-1}{col}");
                        }
                    }

                    // Animated tour through the grid
                    network
                        // Start at top-left after initialization
                        .MoveTo(move => move
                            .WithPosition(-300, -300)
                            .WithScale(1.0)
                            .WithAnimation(anim => anim.WithDuration(1000)),
                            delay: 500
                        )
                        // Move to center with zoom
                        .MoveTo(move => move
                            .WithPosition(0, 0)
                            .WithScale(1.5)
                            .WithAnimation(anim => anim.WithDuration(2000)),
                            2000
                        )
                        // Move to bottom-right
                        .MoveTo(move => move
                            .WithPosition(300, 300)
                            .WithScale(1.0)
                            .WithAnimation(anim => anim.WithDuration(1500)),
                            4500
                        )
                        // Zoom out to see all
                        .Fit(fit => fit.WithAnimation(true), 6500);
                });

                page.H2("3. Selection Control");
                page.Text("Programmatically select nodes and edges.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("selectionDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics
                                .WithEnabled(true)
                                .WithSolver(VisNetworkPhysicsSolver.ForceAtlas2based)
                            );
                            options.WithInteraction(interaction => interaction
                                .WithMultiselect(true)
                                .WithSelectConnectedEdges(true)
                            );
                        });

                    // Create a network with groups
                    var groups = new[] { "Frontend", "Backend", "Database" };
                    var colors = new[] { RGBColor.Blue, RGBColor.Green, RGBColor.Red };
                    
                    for (int g = 0; g < groups.Length; g++) {
                        for (int i = 1; i <= 4; i++) {
                            var nodeId = $"{groups[g]}{i}";
                            network.AddNode(nodeId, node => node
                                .WithLabel($"{groups[g][0]}{i}")
                                .WithGroup(groups[g])
                                .WithColor(colors[g])
                                .WithShape(g == 2 ? VisNetworkNodeShape.Database : VisNetworkNodeShape.Circle)
                            );
                        }
                    }

                    // Connect groups with explicit edge IDs
                    network.AddEdge("Frontend1", "Backend1", edge => edge.WithId("edge1"));
                    network.AddEdge("Frontend2", "Backend1", edge => edge.WithId("edge2"));
                    network.AddEdge("Frontend3", "Backend2", edge => edge.WithId("edge3"));
                    network.AddEdge("Frontend4", "Backend3", edge => edge.WithId("edge4"));
                    network.AddEdge("Backend1", "Database1", edge => edge.WithId("edge5"));
                    network.AddEdge("Backend2", "Database2", edge => edge.WithId("edge6"));
                    network.AddEdge("Backend3", "Database3", edge => edge.WithId("edge7"));
                    network.AddEdge("Backend4", "Database4", edge => edge.WithId("edge8"));

                    // Selection sequence with initial delay for network initialization
                    network
                        // Select all frontend nodes after 1.5 seconds
                        .SelectNodes(new[] { "Frontend1", "Frontend2", "Frontend3", "Frontend4" }, delay: 1500)
                        // Select backend nodes after 3.5 seconds
                        .SelectNodes(new[] { "Backend1", "Backend2", "Backend3", "Backend4" }, delay: 3500)
                        // Select specific edges after 5.5 seconds
                        .UnselectAll(delay: 5500)
                        .SelectEdges(new[] { "edge1", "edge5" }, delay: 6000);
                });

                page.H2("4. Physics Control");
                page.Text("Start, stop, and stabilize the physics simulation.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("physicsControlDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics
                                .WithEnabled(true)
                                .WithBarnesHut(barnes => barnes
                                    .WithGravitationalConstant(-2000)
                                    .WithSpringLength(200)
                                )
                            );
                        });

                    // Create a chaotic network
                    var random = new Random(42);
                    for (int i = 1; i <= 15; i++) {
                        network.AddNode(i, node => node
                            .WithLabel($"Node {i}")
                            .WithShape(VisNetworkNodeShape.Circle)
                            .WithColor(random.Next(3) == 0 ? RGBColor.Red : (random.Next(2) == 0 ? RGBColor.Blue : RGBColor.Green))
                            .WithSize(20 + random.Next(20))
                        );
                    }

                    // Random connections
                    for (int i = 0; i < 20; i++) {
                        var from = random.Next(1, 16);
                        var to = random.Next(1, 16);
                        if (from != to) {
                            network.AddEdge(from, to);
                        }
                    }

                    // Physics control sequence
                    network
                        // Stop physics after 2 seconds
                        .StopSimulation(2000)
                        // Start again after 3 seconds
                        .StartSimulation(3000)
                        // Stabilize with custom iterations after 5 seconds
                        .Stabilize(100, 5000)
                        // Redraw after stabilization
                        .Redraw(6000);
                });

                page.H2("5. Custom Method Execution");
                page.Text("Execute any VisNetwork method with custom JavaScript.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("customMethodDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(false));
                        });

                    // Simple network
                    network.AddNode("center", node => node
                        .WithLabel("Center")
                        .WithShape(VisNetworkNodeShape.Star)
                        .WithColor(RGBColor.Yellow)
                        .WithPosition(0, 0)
                        .WithSize(40)
                    );

                    for (int i = 1; i <= 6; i++) {
                        var angle = i * Math.PI / 3;
                        var x = Math.Cos(angle) * 150;
                        var y = Math.Sin(angle) * 150;
                        
                        network.AddNode($"node{i}", node => node
                            .WithLabel($"Node {i}")
                            .WithShape(VisNetworkNodeShape.Circle)
                            .WithColor(RGBColor.SkyBlue)
                            .WithPosition(x, y)
                        );
                        network.AddEdge("center", $"node{i}");
                    }

                    // Custom JavaScript methods
                    network
                        // Get and log viewport position
                        .ExecuteMethod(@"
                            var pos = network.getViewPosition();
                            console.log('Current viewport position:', pos);
                        ", delay: 1000)
                        // Get and log network scale
                        .ExecuteMethod(@"
                            var scale = network.getScale();
                            console.log('Current scale:', scale);
                        ", delay: 2000)
                        // Get bounding box of specific nodes
                        .ExecuteMethod(@"
                            var bbox = network.getBoundingBox(['node1', 'node2', 'node3']);
                            console.log('Bounding box:', bbox);
                        ", delay: 3000)
                        // Export all node positions
                        .ExecuteMethod(@"
                            var positions = network.getPositions();
                            console.log('All node positions:', positions);
                        ", delay: 4000);
                });

                // Interactive instructions
                page.H2("Demo Features");
                page.Text("This demo automatically executes various methods to control the network:");
                page.LineBreak();
                page.Text("• Fit & Focus: Watch as the viewport automatically fits nodes and focuses on clusters");
                page.LineBreak();
                page.Text("• Movement: See animated viewport movements across a grid");
                page.LineBreak();
                page.Text("• Selection: Observe programmatic node and edge selection");
                page.LineBreak();
                page.Text("• Physics: Experience physics simulation control");
                page.LineBreak();
                page.Text("• Custom Methods: Check the browser console for logged information");
                page.LineBreak();
                page.LineBreak();
                page.Text("Open the browser developer console to see additional output from custom methods.");
            });

            document.Save("VisNetworkMethodsDemo.html", openInBrowser);
            Console.WriteLine($"VisNetwork Methods API Demo created at: VisNetworkMethodsDemo.html");
        }
    }
}