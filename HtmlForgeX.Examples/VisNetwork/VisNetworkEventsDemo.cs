using System;

namespace HtmlForgeX.Examples.VisNetwork {
    public class VisNetworkEventsDemo {
        public static void Create(bool openInBrowser = true) {
            HelpersSpectre.PrintTitle("VisNetwork Events Demo");

            using var document = new Document {
                Head = { 
                    Title = "VisNetwork Events Demo - Interactive Network", 
                    Author = "HtmlForgeX"
                },
                LibraryMode = LibraryMode.Online,
                ThemeMode = ThemeMode.Light
            };

            document.Body.Page(page => {
                page.H1("VisNetwork Events System");
                page.Text("This demo showcases the comprehensive event handling system in VisNetwork.");

                page.H2("1. Basic Click Events");
                page.Text("Click on nodes and edges to see console output (open browser developer tools).");

                page.DiagramNetwork(network => {
                    network
                        .WithId("clickEventsDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(false));
                            options.WithInteraction(interaction => interaction
                                .WithHover(true)
                                .WithTooltipDelay(300)
                            );
                            options.WithEvents(events => {
                                events.WithClick(@"
                                    function(params) {
                                        console.log('Click event:', params);
                                        if (params.nodes.length > 0) {
                                            alert('Clicked node: ' + params.nodes[0]);
                                        } else if (params.edges.length > 0) {
                                            alert('Clicked edge: ' + params.edges[0]);
                                        }
                                    }"
                                );
                                
                                events.WithDoubleClick(@"
                                    function(params) {
                                        if (params.nodes.length > 0) {
                                            var nodeId = params.nodes[0];
                                            var node = nodes.get(nodeId);
                                            alert('Double-clicked node: ' + node.label);
                                        }
                                    }"
                                );
                                
                                events.WithContext(VisNetworkEvents.Templates.PreventContextMenu);
                            });
                        });

                    // Add nodes
                    network.AddNode(1, node => node
                        .WithLabel("Server 1")
                        .WithShape(VisNetworkNodeShape.Box)
                        .WithColor(RGBColor.Blue)
                        .WithPosition(-200, -100)
                    );
                    
                    network.AddNode(2, node => node
                        .WithLabel("Database")
                        .WithShape(VisNetworkNodeShape.Database)
                        .WithColor(RGBColor.Green)
                        .WithPosition(0, 0)
                    );
                    
                    network.AddNode(3, node => node
                        .WithLabel("Server 2")
                        .WithShape(VisNetworkNodeShape.Box)
                        .WithColor(RGBColor.Blue)
                        .WithPosition(200, -100)
                    );
                    
                    // Add edges
                    network.AddEdge(1, 2, edge => edge.WithLabel("Query"));
                    network.AddEdge(3, 2, edge => edge.WithLabel("Query"));
                });

                page.H2("2. Hover and Selection Events");
                page.Text("Hover over nodes to see console output and watch connected edges highlight.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("hoverEventsDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics
                                .WithEnabled(true)
                                .WithSolver(VisNetworkPhysicsSolver.ForceAtlas2based)
                            );
                            options.WithInteraction(interaction => interaction
                                .WithHover(true)
                                .WithHoverConnectedEdges(true)
                                .WithSelectConnectedEdges(true)
                            );
                            options.WithEvents(events => {
                                events.WithHoverNode(@"
                                    function(params) {
                                        var nodeId = params.node;
                                        var connectedNodes = network.getConnectedNodes(nodeId);
                                        var connectedEdges = network.getConnectedEdges(nodeId);
                                        console.log('Hovering node:', nodeId, 
                                            '- Connected nodes:', connectedNodes.length,
                                            '- Connected edges:', connectedEdges.length);
                                    }"
                                );
                                
                                events.WithBlurNode(@"
                                    function(params) {
                                        console.log('Blur node:', params.node);
                                    }"
                                );
                                
                                events.WithSelectNode(@"
                                    function(params) {
                                        console.log('Selected nodes:', params.nodes);
                                    }"
                                );
                            });
                        });

                    // Create a more complex network
                    for (int i = 1; i <= 6; i++) {
                        network.AddNode(i, node => node
                            .WithLabel($"Node {i}")
                            .WithShape(i % 2 == 0 ? VisNetworkNodeShape.Circle : VisNetworkNodeShape.Box)
                            .WithColor(i % 3 == 0 ? RGBColor.Red : (i % 3 == 1 ? RGBColor.Blue : RGBColor.Green))
                        );
                    }
                    
                    network.AddEdge(1, 2);
                    network.AddEdge(1, 3);
                    network.AddEdge(2, 4);
                    network.AddEdge(3, 4);
                    network.AddEdge(4, 5);
                    network.AddEdge(4, 6);
                });

                page.H2("3. Drag and Physics Events");
                page.Text("Drag nodes around and watch stabilization events in console.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("dragEventsDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics
                                .WithEnabled(true)
                                .WithStabilization(stab => stab.WithIterations(100))
                            );
                            options.WithEvents(events => {
                                events.WithDragStart(@"
                                    function(params) {
                                        if (params.nodes.length > 0) {
                                            console.log('Drag start - Node:', params.nodes[0]);
                                        }
                                    }"
                                );
                                
                                events.WithDragEnd(@"
                                    function(params) {
                                        if (params.nodes.length > 0) {
                                            console.log('Drag end - Node:', params.nodes[0]);
                                        }
                                    }"
                                );
                                
                                events.WithStartStabilizing(@"
                                    function() {
                                        console.log('Stabilization started');
                                    }"
                                );
                                
                                events.WithStabilized(@"
                                    function(params) {
                                        console.log('Stabilized after', params.iterations, 'iterations');
                                    }"
                                );
                            });
                        });

                    // Create a star network
                    network.AddNode("center", node => node
                        .WithLabel("Central Hub")
                        .WithShape(VisNetworkNodeShape.Star)
                        .WithColor(RGBColor.Yellow)
                        .WithSize(30)
                    );
                    
                    for (int i = 1; i <= 8; i++) {
                        network.AddNode($"satellite{i}", node => node
                            .WithLabel($"S{i}")
                            .WithShape(VisNetworkNodeShape.Dot)
                            .WithColor(RGBColor.SkyBlue)
                            .WithSize(15)
                        );
                        network.AddEdge("center", $"satellite{i}");
                    }
                });

                page.H2("4. Zoom and Animation Events");
                page.Text("Use mouse wheel to zoom and observe zoom events in console.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("zoomEventsDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(false));
                            options.WithInteraction(interaction => interaction
                                .WithZoomView(true)
                                .WithZoomSpeed(1)
                            );
                            options.WithEvents(events => {
                                events.WithZoom(@"
                                    function(params) {
                                        var scale = network.getScale();
                                        console.log('Zoom level:', (scale * 100).toFixed(0) + '%');
                                    }"
                                );
                                
                                events.WithAnimationFinished(@"
                                    function() {
                                        console.log('Animation finished');
                                    }"
                                );
                            });
                        });

                    // Create a grid network
                    for (int row = 0; row < 4; row++) {
                        for (int col = 0; col < 4; col++) {
                            var id = $"{row},{col}";
                            network.AddNode(id, node => node
                                .WithLabel(id)
                                .WithShape(VisNetworkNodeShape.Square)
                                .WithColor(RGBColor.DarkSlateGray)
                                .WithPosition(col * 100 - 150, row * 100 - 150)
                            );
                            
                            // Connect to neighbors
                            if (col > 0) network.AddEdge(id, $"{row},{col-1}");
                            if (row > 0) network.AddEdge(id, $"{row-1},{col}");
                        }
                    }
                });

                page.H2("Code Example");
                page.Text("Configure VisNetwork with events using options.WithEvents() - see source code for examples.");

                page.H2("Available Events");
                page.Text("The VisNetwork Events System supports the following events:");
                page.LineBreak();
                page.Text("• Click, DoubleClick, Context (right-click)");
                page.LineBreak();
                page.Text("• HoverNode, BlurNode, HoverEdge, BlurEdge");
                page.LineBreak();
                page.Text("• SelectNode, SelectEdge, DeselectNode, DeselectEdge");
                page.LineBreak();
                page.Text("• DragStart, Dragging, DragEnd");
                page.LineBreak();
                page.Text("• StartStabilizing, StabilizationProgress, Stabilized");
                page.LineBreak();
                page.Text("• Zoom, Resize, AnimationFinished");
                page.LineBreak();
                page.Text("• BeforeDrawing, AfterDrawing");
            });

            document.Save("VisNetworkEventsDemo.html", openInBrowser);
            Console.WriteLine($"VisNetwork Events Demo created at: VisNetworkEventsDemo.html");
        }
    }
}