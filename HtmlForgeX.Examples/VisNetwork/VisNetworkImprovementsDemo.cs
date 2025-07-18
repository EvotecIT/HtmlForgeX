using System;
using HtmlForgeX;

namespace HtmlForgeX.Examples.VisNetwork;

/// <summary>
/// Demonstrates the improved VisNetwork API with typed enums and fluent configuration
/// </summary>
internal class VisNetworkImprovementsDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("VisNetwork API Improvements Demo");

        using var document = new Document {
            Head = { 
                Title = "VisNetwork API Improvements - Typed Configuration", 
                Author = "HtmlForgeX"
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.H1("VisNetwork API Improvements");
            page.Text("This demo showcases the enhanced VisNetwork API with typed enums and improved fluent configuration.");
            
            // Section 1: Smooth Edge Types with Force Direction
            page.H2("1. Smooth Edge Types with Force Direction");
            page.Text("Edges now support typed enums for smooth configuration and force direction.");
            
            page.DiagramNetwork(network => {
                network
                    .WithId("smoothEdgesDemo")
                    .WithSize("100%", "400px")
                    .WithPhysics(false);

                // Add nodes in a square layout
                network.AddNode(1, node => node
                    .WithLabel("Dynamic")
                    .WithPosition(-200, -100)
                    .WithColor(RGBColor.Blue)
                );
                
                network.AddNode(2, node => node
                    .WithLabel("Continuous")
                    .WithPosition(200, -100)
                    .WithColor(RGBColor.Green)
                );
                
                network.AddNode(3, node => node
                    .WithLabel("Discrete")
                    .WithPosition(-200, 100)
                    .WithColor(RGBColor.Orange)
                );
                
                network.AddNode(4, node => node
                    .WithLabel("Diagonal")
                    .WithPosition(200, 100)
                    .WithColor(RGBColor.Purple)
                );

                // Add edges with different smooth types
                network.AddEdge(1, 2, edge => edge
                    .WithLabel("Dynamic")
                    .WithSmooth(smooth => smooth
                        .WithEnabled(true)
                        .WithType(VisNetworkSmoothType.Dynamic)
                    )
                    .WithColor(RGBColor.Gray)
                );

                network.AddEdge(2, 3, edge => edge
                    .WithLabel("Continuous")
                    .WithSmooth(smooth => smooth
                        .WithEnabled(true)
                        .WithType(VisNetworkSmoothType.Continuous)
                    )
                    .WithColor(RGBColor.Gray)
                );

                network.AddEdge(3, 4, edge => edge
                    .WithLabel("Discrete")
                    .WithSmooth(smooth => smooth
                        .WithEnabled(true)
                        .WithType(VisNetworkSmoothType.Discrete)
                    )
                    .WithColor(RGBColor.Gray)
                );

                network.AddEdge(4, 1, edge => edge
                    .WithLabel("Horizontal Force")
                    .WithSmooth(smooth => smooth
                        .WithEnabled(true)
                        .WithType(VisNetworkSmoothType.Curvedcw)
                        .WithForceDirection(VisNetworkForceDirection.Horizontal)
                    )
                    .WithColor(RGBColor.Gray)
                );
            });

            // Section 2: Hierarchical Layout with ShakeTowards
            page.H2("2. Hierarchical Layout with ShakeTowards");
            page.Text("Hierarchical layouts now support typed direction and shake towards configuration.");
            
            page.DiagramNetwork(network => {
                network
                    .WithId("hierarchicalDemo")
                    .WithSize("100%", "500px")
                    .WithLayout(layout => layout
                        .WithHierarchical(hierarchical => hierarchical
                            .WithEnabled(true)
                            .WithDirection(VisNetworkLayoutDirection.Ud)
                            .WithSortMethod(VisNetworkLayoutSort.Hubsize)
                            .WithShakeTowards(VisNetworkShakeTowards.Leaves)
                            .WithLevelSeparation(150)
                            .WithNodeSpacing(100)
                        )
                    );

                // Create a tree structure
                network.AddNode("root", node => node
                    .WithLabel("Root Node")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(RGBColor.DarkBlue)
                    .WithFont(font => font.WithColor(RGBColor.White))
                );

                // Level 1
                for (int i = 1; i <= 3; i++) {
                    network.AddNode($"l1-{i}", node => node
                        .WithLabel($"Branch {i}")
                        .WithShape(VisNetworkNodeShape.Ellipse)
                        .WithColor(RGBColor.Blue)
                    );
                    network.AddEdge("root", $"l1-{i}");
                }

                // Level 2
                for (int i = 1; i <= 3; i++) {
                    for (int j = 1; j <= 2; j++) {
                        network.AddNode($"l2-{i}-{j}", node => node
                            .WithLabel($"Leaf {i}.{j}")
                            .WithShape(VisNetworkNodeShape.Circle)
                            .WithColor(RGBColor.LightBlue)
                        );
                        network.AddEdge($"l1-{i}", $"l2-{i}-{j}");
                    }
                }
            });

            // Section 3: Physics Solvers
            page.H2("3. Physics Solvers with Typed Configuration");
            page.Text("Physics configuration now uses typed enums for solver selection.");
            
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Barnes Hut Solver"));
                        card.Body(body => {
                            body.DiagramNetwork(network => {
                                network
                                    .WithId("barnesHutDemo")
                                    .WithSize("100%", "300px")
                                    .WithPhysics(physics => physics
                                        .WithEnabled(true)
                                        .WithSolver(VisNetworkPhysicsSolver.BarnesHut)
                                        .WithBarnesHut(barnes => barnes
                                            .WithGravitationalConstant(-2000)
                                            .WithCentralGravity(0.3)
                                            .WithSpringLength(95)
                                        )
                                    );

                                // Add random nodes
                                for (int i = 1; i <= 10; i++) {
                                    network.AddNode(i, node => node
                                        .WithLabel($"N{i}")
                                        .WithColor(GetRandomColor())
                                    );
                                }

                                // Add random edges
                                network.AddEdge(1, 2);
                                network.AddEdge(2, 3);
                                network.AddEdge(3, 4);
                                network.AddEdge(4, 5);
                                network.AddEdge(5, 6);
                                network.AddEdge(6, 7);
                                network.AddEdge(7, 8);
                                network.AddEdge(8, 9);
                                network.AddEdge(9, 10);
                                network.AddEdge(10, 1);
                                network.AddEdge(1, 5);
                                network.AddEdge(2, 6);
                            });
                        });
                    });
                });
                
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Force Atlas 2 Solver"));
                        card.Body(body => {
                            body.DiagramNetwork(network => {
                                network
                                    .WithId("forceAtlas2Demo")
                                    .WithSize("100%", "300px")
                                    .WithPhysics(physics => physics
                                        .WithEnabled(true)
                                        .WithSolver(VisNetworkPhysicsSolver.ForceAtlas2based)
                                        .WithForceAtlas2Based(atlas => atlas
                                            .WithGravitationalConstant(-50)
                                            .WithCentralGravity(0.01)
                                            .WithSpringLength(100)
                                        )
                                    );

                                // Add random nodes
                                for (int i = 1; i <= 10; i++) {
                                    network.AddNode(i, node => node
                                        .WithLabel($"N{i}")
                                        .WithColor(GetRandomColor())
                                    );
                                }

                                // Add different edge pattern
                                for (int i = 1; i <= 10; i++) {
                                    network.AddEdge(i, (i % 10) + 1);
                                    if (i <= 5) {
                                        network.AddEdge(i, i + 5);
                                    }
                                }
                            });
                        });
                    });
                });
            });

            // Section 4: Arrow Types
            page.H2("4. Typed Arrow Configuration");
            page.Text("Arrow configuration now uses typed enums for arrow types.");
            
            page.DiagramNetwork(network => {
                network
                    .WithId("arrowTypesDemo")
                    .WithSize("100%", "400px")
                    .WithPhysics(false);

                // Create nodes in a line
                for (int i = 1; i <= 5; i++) {
                    network.AddNode(i, node => node
                        .WithLabel($"Node {i}")
                        .WithPosition((i - 3) * 150, 0)
                        .WithShape(VisNetworkNodeShape.Box)
                    );
                }

                // Different arrow types
                network.AddEdge(1, 2, edge => edge
                    .WithLabel("Arrow")
                    .WithArrows(arrows => arrows
                        .WithTo(to => to
                            .WithEnabled(true)
                            .WithType(VisNetworkArrowType.Arrow)
                        )
                    )
                );

                network.AddEdge(2, 3, edge => edge
                    .WithLabel("Bar")
                    .WithArrows(arrows => arrows
                        .WithTo(to => to
                            .WithEnabled(true)
                            .WithType(VisNetworkArrowType.Bar)
                        )
                    )
                );

                network.AddEdge(3, 4, edge => edge
                    .WithLabel("Circle")
                    .WithArrows(arrows => arrows
                        .WithTo(to => to
                            .WithEnabled(true)
                            .WithType(VisNetworkArrowType.Circle)
                        )
                    )
                );

                network.AddEdge(4, 5, edge => edge
                    .WithLabel("Vee")
                    .WithArrows(arrows => arrows
                        .WithTo(to => to
                            .WithEnabled(true)
                            .WithType(VisNetworkArrowType.Vee)
                        )
                    )
                );
            });

            // Code examples
            page.H2("Code Examples");
            
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Smooth Edge Configuration"));
                        card.Body(body => {
                            body.CSharpCode(@"// Configure smooth edges with typed enums
network.AddEdge(from, to, edge => edge
    .WithSmooth(smooth => smooth
        .WithEnabled(true)
        .WithType(VisNetworkSmoothType.Curvedcw)
        .WithForceDirection(VisNetworkForceDirection.Horizontal)
        .WithRoundness(0.5)
    )
);", config => config.EnableLineNumbers().EnableCopyButton());
                        });
                    });
                });
                
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Hierarchical Layout"));
                        card.Body(body => {
                            body.CSharpCode(@"// Configure hierarchical layout
network.WithLayout(layout => layout
    .WithHierarchical(hierarchical => hierarchical
        .WithEnabled(true)
        .WithDirection(VisNetworkLayoutDirection.Lr)
        .WithSortMethod(VisNetworkLayoutSort.Directed)
        .WithShakeTowards(VisNetworkShakeTowards.Roots)
    )
);", config => config.EnableLineNumbers().EnableCopyButton());
                        });
                    });
                });
            });

            // Benefits
            page.H2("Benefits of the Improvements");
            page.Text("• Type-safe configuration with IntelliSense support").LineBreak();
            page.Text("• No more magic strings - all options use enums").LineBreak();
            page.Text("• RGBColor support throughout the API").LineBreak();
            page.Text("• Consistent fluent API with lambda configuration").LineBreak();
            page.Text("• Better discoverability of available options").LineBreak();
            page.Text("• Compile-time validation of configuration values");
        });

        document.Save("VisNetworkImprovementsDemo.html", openInBrowser);
        Console.WriteLine("VisNetwork Improvements Demo created successfully!");
    }
    
    private static RGBColor GetRandomColor() {
        var random = new Random();
        var colors = new[] {
            RGBColor.Blue,
            RGBColor.Red,
            RGBColor.Green,
            RGBColor.Orange,
            RGBColor.Purple,
            RGBColor.DarkBlue,
            RGBColor.DarkGreen,
            RGBColor.DarkRed,
            RGBColor.DarkOrange,
            RGBColor.DarkPurple
        };
        return colors[random.Next(colors.Length)];
    }
}