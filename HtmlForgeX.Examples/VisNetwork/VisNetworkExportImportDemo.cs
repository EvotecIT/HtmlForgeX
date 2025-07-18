using System;

namespace HtmlForgeX.Examples.VisNetwork {
    public class VisNetworkExportImportDemo {
        public static void Create(bool openInBrowser = true) {
            HelpersSpectre.PrintTitle("VisNetwork Export/Import Demo");

            using var document = new Document {
                Head = { 
                    Title = "VisNetwork Export/Import Demo - Save and Restore Networks", 
                    Author = "HtmlForgeX"
                },
                LibraryMode = LibraryMode.Online,
                ThemeMode = ThemeMode.Light
            };

            document.Body.Page(page => {
                page.H1("VisNetwork Export/Import Functionality");
                page.Text("This demo showcases the ability to export and import network data, positions, and viewport state.");

                page.H2("1. Basic Export/Import");
                page.Text("Drag nodes to new positions, then use the automatic export/import to restore the original state.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("basicExportImportDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(false));
                            options.WithInteraction(interaction => interaction
                                .WithDragNodes(true)
                                .WithNavigationButtons(true)
                            );
                        });

                    // Create a simple network
                    network.AddNode("server", node => node
                        .WithLabel("Server")
                        .WithShape(VisNetworkNodeShape.Database)
                        .WithColor(RGBColor.DarkBlue)
                        .WithPosition(0, -100)
                    );

                    network.AddNode("client1", node => node
                        .WithLabel("Client 1")
                        .WithShape(VisNetworkNodeShape.Box)
                        .WithColor(RGBColor.Green)
                        .WithPosition(-150, 50)
                    );

                    network.AddNode("client2", node => node
                        .WithLabel("Client 2")
                        .WithShape(VisNetworkNodeShape.Box)
                        .WithColor(RGBColor.Green)
                        .WithPosition(150, 50)
                    );

                    network.AddNode("firewall", node => node
                        .WithLabel("Firewall")
                        .WithShape(VisNetworkNodeShape.Hexagon)
                        .WithColor(RGBColor.Red)
                        .WithPosition(0, 50)
                    );

                    network.AddEdge("server", "firewall", edge => edge
                        .WithLabel("Secure")
                        .WithArrows(arrows => arrows.WithTo(true).WithFrom(true))
                    );
                    network.AddEdge("firewall", "client1");
                    network.AddEdge("firewall", "client2");

                    // Export initial state and import it after 5 seconds
                    network
                        .ExecuteMethod(@"
                            // Store initial state
                            window.basicDemoInitialState = {
                                nodes: nodes.get(),
                                edges: edges.get(),
                                positions: network.getPositions(),
                                viewport: {
                                    position: network.getViewPosition(),
                                    scale: network.getScale()
                                }
                            };
                            console.log('Initial state saved');
                        ")
                        .ExecuteMethod(@"
                            // Show message
                            var messageDiv = document.createElement('div');
                            messageDiv.innerHTML = '<strong>Drag the nodes around! Network will reset in 5 seconds...</strong>';
                            messageDiv.style.cssText = 'position: absolute; top: 10px; left: 10px; background: yellow; padding: 10px; border-radius: 5px; z-index: 1000;';
                            container.appendChild(messageDiv);
                            
                            setTimeout(function() {
                                container.removeChild(messageDiv);
                            }, 5000);
                        ")
                        .Import("window.basicDemoInitialState", true, 5000)
                        .ExecuteMethod(@"
                            // Restore viewport
                            network.moveTo({
                                position: window.basicDemoInitialState.viewport.position,
                                scale: window.basicDemoInitialState.viewport.scale,
                                animation: true
                            });
                        ", 5100);
                });

                page.H2("2. Export to File");
                page.Text("This demo automatically exports the network data as JSON and image files.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("exportToFileDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics
                                .WithEnabled(true)
                                .WithBarnesHut(barnes => barnes
                                    .WithGravitationalConstant(-2000)
                                    .WithSpringLength(100)
                                )
                            );
                        });

                    // Create a more complex network
                    var departments = new[] { "Sales", "Engineering", "Marketing", "HR" };
                    var colors = new[] { RGBColor.Blue, RGBColor.Green, RGBColor.Orange, RGBColor.Purple };

                    // Create department nodes
                    for (int i = 0; i < departments.Length; i++) {
                        network.AddNode(departments[i], node => node
                            .WithLabel(departments[i])
                            .WithShape(VisNetworkNodeShape.Box)
                            .WithColor(colors[i])
                            .WithSize(30)
                        );
                    }

                    // Create employee nodes
                    var random = new Random(42);
                    for (int d = 0; d < departments.Length; d++) {
                        for (int e = 1; e <= 3; e++) {
                            var empId = $"{departments[d]}_Emp{e}";
                            network.AddNode(empId, node => node
                                .WithLabel($"Employee {e}")
                                .WithShape(VisNetworkNodeShape.Circle)
                                .WithColor(colors[d])
                                .WithSize(20)
                            );
                            network.AddEdge(departments[d], empId);
                        }
                    }

                    // Connect departments
                    network.AddEdge("Sales", "Marketing");
                    network.AddEdge("Engineering", "Sales");
                    network.AddEdge("HR", "Engineering");
                    network.AddEdge("HR", "Marketing");

                    // Export after stabilization
                    network
                        .Stabilize(100, 2000)
                        .DownloadAsJson("organization-network", options => {
                            options.IncludePositions = true;
                            options.IncludeViewport = true;
                        }, 3000)
                        .ExportAsImage("png", "organization-diagram", 3500)
                        .ExecuteMethod(@"
                            console.log('Network exported as JSON and PNG files!');
                            
                            // Show notification
                            var notification = document.createElement('div');
                            notification.innerHTML = '<strong>✓ Network exported!</strong><br>Check your downloads for:<br>• organization-network.json<br>• organization-diagram.png';
                            notification.style.cssText = 'position: absolute; top: 10px; right: 10px; background: #4CAF50; color: white; padding: 15px; border-radius: 5px; z-index: 1000;';
                            container.appendChild(notification);
                            
                            setTimeout(function() {
                                container.removeChild(notification);
                            }, 5000);
                        ", 3600);
                });

                page.H2("3. Position Management");
                page.Text("Export and import node positions independently of the data.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("positionManagementDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(false));
                            options.WithInteraction(interaction => interaction
                                .WithDragNodes(true)
                            );
                        });

                    // Create a grid of nodes
                    for (int row = 0; row < 4; row++) {
                        for (int col = 0; col < 4; col++) {
                            var nodeId = $"grid_{row}_{col}";
                            network.AddNode(nodeId, node => node
                                .WithLabel($"{row},{col}")
                                .WithShape(VisNetworkNodeShape.Circle)
                                .WithColor(RGBColor.SkyBlue)
                                .WithPosition(col * 100 - 150, row * 100 - 150)
                            );

                            // Connect to neighbors
                            if (col > 0) {
                                network.AddEdge(nodeId, $"grid_{row}_{col - 1}");
                            }
                            if (row > 0) {
                                network.AddEdge(nodeId, $"grid_{row - 1}_{col}");
                            }
                        }
                    }

                    // Position management sequence
                    network
                        // Save initial grid positions
                        .ExportPositions("window.gridPositions = ", 500)
                        // Scramble positions
                        .ExecuteMethod(@"
                            var nodeIds = nodes.getIds();
                            nodeIds.forEach(function(id) {
                                var x = (Math.random() - 0.5) * 600;
                                var y = (Math.random() - 0.5) * 400;
                                network.moveNode(id, x, y);
                            });
                            network.fit();
                            console.log('Positions scrambled!');
                        ", 2000)
                        // Restore grid positions
                        .ImportPositions("window.gridPositions", true, 4000)
                        .ExecuteMethod(@"
                            console.log('Original grid positions restored!');
                        ", 4100);
                });

                page.H2("4. Complete State Management");
                page.Text("Save and restore the complete network state including data, positions, and viewport.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("stateManagementDemo")
                        .WithSize("100%", "500px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(true));
                            options.WithInteraction(interaction => interaction
                                .WithMultiselect(true)
                                .WithNavigationButtons(true)
                            );
                            options.WithManipulation(manip => manip
                                .WithEnabled(true)
                                .WithAddNode(true)
                                .WithAddEdge(true)
                                .WithDeleteNode(true)
                                .WithDeleteEdge(true)
                            );
                        });

                    // Create initial network
                    network.AddNode("central", node => node
                        .WithLabel("Central Hub")
                        .WithShape(VisNetworkNodeShape.Star)
                        .WithColor(RGBColor.Yellow)
                        .WithSize(40)
                    );

                    for (int i = 1; i <= 5; i++) {
                        network.AddNode($"node{i}", node => node
                            .WithLabel($"Node {i}")
                            .WithShape(VisNetworkNodeShape.Circle)
                            .WithColor(RGBColor.LightGray)
                        );
                        network.AddEdge("central", $"node{i}");
                    }

                    // State management with UI feedback
                    network
                        .ExecuteMethod(@"
                            // Add state management UI
                            var uiDiv = document.createElement('div');
                            uiDiv.style.cssText = 'position: absolute; top: 10px; left: 10px; background: rgba(255,255,255,0.9); padding: 10px; border: 1px solid #ccc; border-radius: 5px; z-index: 1000;';
                            uiDiv.innerHTML = `
                                <h4 style='margin: 0 0 10px 0;'>State Management</h4>
                                <p style='margin: 5px 0;'>You can:</p>
                                <ul style='margin: 5px 0; padding-left: 20px;'>
                                    <li>Add/delete nodes and edges</li>
                                    <li>Move nodes around</li>
                                    <li>Zoom and pan the view</li>
                                </ul>
                                <p style='margin: 10px 0 5px 0;'><strong>All changes will be saved and restored!</strong></p>
                                <div id='stateStatus' style='margin-top: 10px; padding: 5px; background: #f0f0f0; border-radius: 3px;'></div>
                            `;
                            container.appendChild(uiDiv);
                            
                            window.updateStateStatus = function(message) {
                                document.getElementById('stateStatus').innerHTML = message;
                            };
                            
                            updateStateStatus('Ready - make some changes!');
                        ")
                        // Save complete state after 3 seconds
                        .Export(options => {
                            options.IncludePositions = true;
                            options.IncludeViewport = true;
                            options.IncludeOptions = false;
                        }, "window.savedNetworkState = ", 3000)
                        .ExecuteMethod("updateStateStatus('State saved! Continuing to edit...');", 3100)
                        // Clear and restore after 8 seconds
                        .ExecuteMethod(@"
                            updateStateStatus('Clearing network in 2 seconds...');
                        ", 6000)
                        .ExecuteMethod(@"
                            nodes.clear();
                            edges.clear();
                            updateStateStatus('Network cleared! Restoring in 2 seconds...');
                        ", 8000)
                        .Import("window.savedNetworkState", false, 10000)
                        .ExecuteMethod(@"
                            updateStateStatus('Network restored to saved state!');
                            
                            // Highlight the restoration
                            network.fit({ animation: true });
                        ", 10100);
                });

                // Instructions
                page.H2("Demo Features");
                page.Text("This demo showcases various export/import capabilities:");
                page.LineBreak();
                page.Text("• Basic Export/Import: Automatically saves and restores network state");
                page.LineBreak();
                page.Text("• File Export: Downloads network as JSON and PNG files");
                page.LineBreak();
                page.Text("• Position Management: Saves and restores node positions independently");
                page.LineBreak();
                page.Text("• Complete State: Full network state management with user modifications");
                page.LineBreak();
                page.LineBreak();
                page.Text("All operations are performed automatically - watch the networks transform!");
            });

            document.Save("VisNetworkExportImportDemo.html", openInBrowser);
            Console.WriteLine($"VisNetwork Export/Import Demo created at: VisNetworkExportImportDemo.html");
        }
    }
}