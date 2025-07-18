using System;

namespace HtmlForgeX.Examples.VisNetwork {
    public class VisNetworkAdvancedFeaturesDemo {
        public static void Create(bool openInBrowser = true) {
            HelpersSpectre.PrintTitle("VisNetwork Advanced Features Demo");

            using var document = new Document {
                Head = { 
                    Title = "VisNetwork Advanced Features - Image Handling & Wind Physics", 
                    Author = "HtmlForgeX"
                },
                LibraryMode = LibraryMode.Online,
                ThemeMode = ThemeMode.Light
            };

            document.Body.Page(page => {
                page.H1("VisNetwork Advanced Features");
                page.Text("Demonstrating image padding, broken image handling, and wind physics simulation.");

                page.H2("1. Image Padding & Broken Image Handling");
                page.Text("Shows how to configure image padding and fallback images for broken links.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("imageFeaturesDemo")
                        .WithSize("100%", "500px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(false));
                            // Set global broken image for all nodes
                            options.WithNodes(nodes => {
                                var globalImage = new VisNetworkImageOptions()
                                    .WithBrokenImage("https://via.placeholder.com/150x150/ff0000/ffffff?text=ERROR");
                                nodes.WithImageObject(globalImage);
                            });
                        });

                    // Working image with uniform padding
                    network.AddNode("user1", node => node
                        .WithLabel("User 1\n(10px padding)")
                        .WithShape(VisNetworkNodeShape.Image)
                        .WithImageObject(new VisNetworkImageOptions()
                            .WithUnselected("https://via.placeholder.com/150x150/4682B4/ffffff?text=User+1")
                            .WithSelected("https://via.placeholder.com/150x150/1E90FF/ffffff?text=Selected")
                            .WithImagePadding(10)
                        )
                        .WithPosition(-300, -100)
                        .WithSize(80)
                    );

                    // Working image with custom padding per side
                    network.AddNode("user2", node => node
                        .WithLabel("User 2\n(Custom padding)")
                        .WithShape(VisNetworkNodeShape.Image)
                        .WithImageObject(new VisNetworkImageOptions()
                            .WithUnselected("https://via.placeholder.com/150x150/228B22/ffffff?text=User+2")
                            .WithImagePadding(5, 20, 5, 20) // top, right, bottom, left
                        )
                        .WithPosition(0, -100)
                        .WithSize(80)
                    );

                    // Broken image that will use fallback
                    network.AddNode("user3", node => node
                        .WithLabel("User 3\n(Broken image)")
                        .WithShape(VisNetworkNodeShape.Image)
                        .WithImageObject(new VisNetworkImageOptions()
                            .WithUnselected("https://broken-url-that-does-not-exist.com/image.jpg")
                            .WithBrokenImage("https://via.placeholder.com/150x150/FFA500/000000?text=BROKEN")
                            .WithImagePadding(15)
                        )
                        .WithPosition(300, -100)
                        .WithSize(80)
                    );

                    // Image with both states and padding
                    network.AddNode("user4", node => node
                        .WithLabel("User 4\n(Click to select)")
                        .WithShape(VisNetworkNodeShape.Image)
                        .WithImageObject(new VisNetworkImageOptions()
                            .WithUnselected("https://via.placeholder.com/150x150/800080/ffffff?text=Normal")
                            .WithSelected("https://via.placeholder.com/150x150/FF1493/ffffff?text=Active")
                            .WithImagePadding(20)
                        )
                        .WithPosition(-150, 100)
                        .WithSize(100)
                    );

                    // CircularImage with padding
                    network.AddNode("user5", node => node
                        .WithLabel("User 5\n(Circular + padding)")
                        .WithShape(VisNetworkNodeShape.CircularImage)
                        .WithImageObject(new VisNetworkImageOptions()
                            .WithUnselected("https://via.placeholder.com/150x150/008080/ffffff?text=Circle")
                            .WithImagePadding(25)
                        )
                        .WithPosition(150, 100)
                        .WithSize(100)
                    );

                    // Connect nodes
                    network.AddEdge("user1", "user2");
                    network.AddEdge("user2", "user3");
                    network.AddEdge("user1", "user4");
                    network.AddEdge("user3", "user5");
                    network.AddEdge("user4", "user5");
                });

                page.H2("2. Wind Physics Simulation");
                page.Text("Demonstrates how wind forces affect node movement in the physics simulation.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("windPhysicsDemo")
                        .WithSize("100%", "500px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics
                                .WithEnabled(true)
                                .WithBarnesHut(barnes => barnes
                                    .WithGravitationalConstant(-2000)
                                    .WithSpringLength(100)
                                )
                                // Add wind force blowing to the right and slightly up
                                .WithWind(0.15, -0.05)
                            );
                            options.WithNodes(nodes => nodes
                                .WithShape(VisNetworkNodeShape.Circle)
                                .WithSize(25)
                            );
                        });

                    // Create a network of lightweight nodes that will be affected by wind
                    var colors = new[] { 
                        RGBColor.SkyBlue, RGBColor.LightGreen, RGBColor.LightCoral,
                        RGBColor.LightYellow, RGBColor.Plum, RGBColor.LightSalmon
                    };

                    // Create floating nodes
                    for (int i = 0; i < 20; i++) {
                        network.AddNode($"wind{i}", node => node
                            .WithLabel($"N{i}")
                            .WithColor(colors[i % colors.Length])
                            .WithMass(0.5 + (i % 3) * 0.3) // Varying mass for different wind effects
                        );
                    }

                    // Create some connections to see how wind affects connected components
                    network.AddEdge("wind0", "wind1");
                    network.AddEdge("wind1", "wind2");
                    network.AddEdge("wind2", "wind3");
                    network.AddEdge("wind3", "wind4");
                    
                    network.AddEdge("wind5", "wind6");
                    network.AddEdge("wind6", "wind7");
                    network.AddEdge("wind7", "wind8");
                    
                    network.AddEdge("wind10", "wind11");
                    network.AddEdge("wind11", "wind12");
                    
                    network.AddEdge("wind15", "wind16");
                    network.AddEdge("wind16", "wind17");
                    network.AddEdge("wind17", "wind18");
                    network.AddEdge("wind18", "wind19");

                    // Add a control panel to adjust wind
                    network.ExecuteMethod(@"
                        // Create wind control UI
                        var windControl = document.createElement('div');
                        windControl.style.cssText = 'position: absolute; top: 10px; left: 10px; background: rgba(255,255,255,0.9); padding: 15px; border: 1px solid #ccc; border-radius: 5px; z-index: 1000;';
                        windControl.innerHTML = `
                            <h4 style='margin: 0 0 10px 0;'>Wind Control</h4>
                            <div style='margin-bottom: 10px;'>
                                <label style='display: inline-block; width: 80px;'>X Force:</label>
                                <input type='range' id='windX' min='-0.5' max='0.5' step='0.05' value='0.15' style='width: 150px;'>
                                <span id='windXValue'>0.15</span>
                            </div>
                            <div style='margin-bottom: 10px;'>
                                <label style='display: inline-block; width: 80px;'>Y Force:</label>
                                <input type='range' id='windY' min='-0.5' max='0.5' step='0.05' value='-0.05' style='width: 150px;'>
                                <span id='windYValue'>-0.05</span>
                            </div>
                            <button id='stopWind' style='margin-right: 10px;'>Stop Wind</button>
                            <button id='resetWind'>Reset Wind</button>
                        `;
                        container.appendChild(windControl);
                        
                        // Add event handlers
                        document.getElementById('windX').addEventListener('input', function(e) {
                            var value = parseFloat(e.target.value);
                            document.getElementById('windXValue').textContent = value;
                            network.setOptions({
                                physics: {
                                    wind: { x: value, y: parseFloat(document.getElementById('windY').value) }
                                }
                            });
                        });
                        
                        document.getElementById('windY').addEventListener('input', function(e) {
                            var value = parseFloat(e.target.value);
                            document.getElementById('windYValue').textContent = value;
                            network.setOptions({
                                physics: {
                                    wind: { x: parseFloat(document.getElementById('windX').value), y: value }
                                }
                            });
                        });
                        
                        document.getElementById('stopWind').addEventListener('click', function() {
                            document.getElementById('windX').value = 0;
                            document.getElementById('windY').value = 0;
                            document.getElementById('windXValue').textContent = '0';
                            document.getElementById('windYValue').textContent = '0';
                            network.setOptions({
                                physics: { wind: { x: 0, y: 0 } }
                            });
                        });
                        
                        document.getElementById('resetWind').addEventListener('click', function() {
                            document.getElementById('windX').value = 0.15;
                            document.getElementById('windY').value = -0.05;
                            document.getElementById('windXValue').textContent = '0.15';
                            document.getElementById('windYValue').textContent = '-0.05';
                            network.setOptions({
                                physics: { wind: { x: 0.15, y: -0.05 } }
                            });
                        });
                    ");
                });

                page.H2("3. Combined Features Demo");
                page.Text("Combining image handling with wind physics for a realistic simulation.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("combinedDemo")
                        .WithSize("100%", "600px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics
                                .WithEnabled(true)
                                .WithForceAtlas2Based(atlas => atlas
                                    .WithGravitationalConstant(-50)
                                    .WithSpringLength(150)
                                )
                                .WithWind(0.1, 0) // Gentle breeze to the right
                            );
                            options.WithNodes(nodes => {
                                var defaultImage = new VisNetworkImageOptions()
                                    .WithBrokenImage("https://via.placeholder.com/100x100/cccccc/666666?text=N/A")
                                    .WithImagePadding(5);
                                nodes.WithImageObject(defaultImage);
                            });
                        });

                    // Create a weather monitoring network
                    network.AddNode("station1", node => node
                        .WithLabel("Weather Station 1")
                        .WithShape(VisNetworkNodeShape.Image)
                        .WithImage("https://via.placeholder.com/100x100/4169E1/ffffff?text=WS1")
                        .WithMass(3) // Heavy, less affected by wind
                    );

                    network.AddNode("station2", node => node
                        .WithLabel("Weather Station 2")
                        .WithShape(VisNetworkNodeShape.Image)
                        .WithImage("https://via.placeholder.com/100x100/32CD32/ffffff?text=WS2")
                        .WithMass(3)
                    );

                    // Add lightweight sensor nodes
                    var sensorTypes = new[] { "Temp", "Wind", "Rain", "UV" };
                    var sensorColors = new[] { "#FF6347", "#87CEEB", "#4682B4", "#FFD700" };
                    
                    for (int s = 1; s <= 2; s++) {
                        for (int i = 0; i < sensorTypes.Length; i++) {
                            var sensorId = $"sensor{s}_{i}";
                            network.AddNode(sensorId, node => node
                                .WithLabel($"{sensorTypes[i]} {s}")
                                .WithShape(VisNetworkNodeShape.CircularImage)
                                .WithImage($"https://via.placeholder.com/80x80/{sensorColors[i].Replace("#", "")}/ffffff?text={sensorTypes[i][0]}")
                                .WithSize(40)
                                .WithMass(0.5) // Lightweight, more affected by wind
                            );
                            network.AddEdge($"station{s}", sensorId);
                        }
                    }

                    // Connect the stations
                    network.AddEdge("station1", "station2", edge => edge
                        .WithLabel("Data Link")
                        .WithDashes(true)
                    );
                });

                // Instructions
                page.H2("Feature Descriptions");
                
                page.H3("Image Padding & Broken Image Handling");
                page.Text("• WithImagePadding(pixels) - Adds uniform padding around images");
                page.LineBreak();
                page.Text("• WithImagePadding(top, right, bottom, left) - Custom padding per side");
                page.LineBreak();
                page.Text("• WithBrokenImage(url) - Fallback image when main image fails to load");
                page.LineBreak();
                page.Text("• Works with both 'image' and 'circularImage' node shapes");
                
                page.H3("Wind Physics");
                page.Text("• WithWind(x, y) - Applies constant force in specified direction");
                page.LineBreak();
                page.Text("• X positive = right, negative = left");
                page.LineBreak();
                page.Text("• Y positive = down, negative = up");
                page.LineBreak();
                page.Text("• Effect varies based on node mass - lighter nodes move more");
                page.LineBreak();
                page.Text("• Interactive controls allow real-time wind adjustment");
            });

            document.Save("VisNetworkAdvancedFeaturesDemo.html", openInBrowser);
            Console.WriteLine($"VisNetwork Advanced Features Demo created at: VisNetworkAdvancedFeaturesDemo.html");
        }
    }
}