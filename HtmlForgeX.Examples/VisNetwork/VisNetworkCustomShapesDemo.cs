using System;

namespace HtmlForgeX.Examples.VisNetwork {
    public class VisNetworkCustomShapesDemo {
        public static void Create(bool openInBrowser = true) {
            HelpersSpectre.PrintTitle("VisNetwork Custom Shapes Demo");

            using var document = new Document {
                Head = {
                    Title = "VisNetwork Custom Shapes Demo - Advanced Node Rendering",
                    Author = "HtmlForgeX"
                },
                LibraryMode = LibraryMode.Online,
                ThemeMode = ThemeMode.Light
            };

            document.Body.Page(page => {
                page.H1("VisNetwork Custom Shapes");
                page.Text("This demo showcases custom node shapes rendered using Canvas 2D context.");

                page.H2("1. Predefined Custom Shapes");
                page.Text("A collection of predefined custom shapes for common use cases.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("predefinedShapesDemo")
                        .WithSize("100%", "500px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(false));
                            options.WithNodes(nodes => nodes
                                .WithSize(40)
                                .WithFont(font => font.WithSize(14))
                            );
                        });

                    // Rounded Rectangle
                    network.AddNode("roundedRect", node => node
                        .WithLabel("Rounded\nRectangle")
                        .WithCustomShape(VisNetworkCustomShapes.RoundedRectangle(15))
                        .WithColor(RGBColor.SteelBlue)
                        .WithPosition(-300, -150)
                    );

                    // Heart Shape
                    network.AddNode("heart", node => node
                        .WithLabel("Heart")
                        .WithCustomShape(VisNetworkCustomShapes.Heart)
                        .WithColor(RGBColor.Crimson)
                        .WithPosition(-100, -150)
                    );

                    // Cloud Shape
                    network.AddNode("cloud", node => node
                        .WithLabel("Cloud")
                        .WithCustomShape(VisNetworkCustomShapes.Cloud)
                        .WithColor(RGBColor.LightBlue)
                        .WithPosition(100, -150)
                    );

                    // Gear Shape
                    network.AddNode("gear", node => node
                        .WithLabel("Gear")
                        .WithCustomShape(VisNetworkCustomShapes.Gear(8))
                        .WithColor(RGBColor.Silver)
                        .WithPosition(300, -150)
                    );

                    // Lightning Shape
                    network.AddNode("lightning", node => node
                        .WithLabel("Lightning")
                        .WithCustomShape(VisNetworkCustomShapes.Lightning)
                        .WithColor(RGBColor.Yellow)
                        .WithPosition(-300, 0)
                    );

                    // House Shape
                    network.AddNode("house", node => node
                        .WithLabel("House")
                        .WithCustomShape(VisNetworkCustomShapes.House)
                        .WithColor(RGBColor.SaddleBrown)
                        .WithPosition(-100, 0)
                    );

                    // Person Shape
                    network.AddNode("person", node => node
                        .WithLabel("Person")
                        .WithCustomShape(VisNetworkCustomShapes.Person)
                        .WithColor(RGBColor.DarkBlue)
                        .WithPosition(100, 0)
                    );

                    // Arrow Shapes
                    network.AddNode("arrowRight", node => node
                        .WithLabel("Right")
                        .WithCustomShape(VisNetworkCustomShapes.Arrow("right"))
                        .WithColor(RGBColor.ForestGreen)
                        .WithPosition(300, 0)
                    );

                    network.AddNode("arrowUp", node => node
                        .WithLabel("Up")
                        .WithCustomShape(VisNetworkCustomShapes.Arrow("up"))
                        .WithColor(RGBColor.ForestGreen)
                        .WithPosition(-200, 150)
                    );

                    network.AddNode("arrowDown", node => node
                        .WithLabel("Down")
                        .WithCustomShape(VisNetworkCustomShapes.Arrow("down"))
                        .WithColor(RGBColor.ForestGreen)
                        .WithPosition(0, 150)
                    );

                    network.AddNode("arrowLeft", node => node
                        .WithLabel("Left")
                        .WithCustomShape(VisNetworkCustomShapes.Arrow("left"))
                        .WithColor(RGBColor.ForestGreen)
                        .WithPosition(200, 150)
                    );

                    // Connect some nodes to show they work normally
                    network.AddEdge("roundedRect", "heart");
                    network.AddEdge("heart", "cloud");
                    network.AddEdge("cloud", "gear");
                    network.AddEdge("lightning", "house");
                    network.AddEdge("house", "person");
                    network.AddEdge("person", "arrowRight");
                    network.AddEdge("arrowUp", "arrowDown");
                    network.AddEdge("arrowDown", "arrowLeft");
                });

                page.H2("2. Emoji Shapes");
                page.Text("Using emojis as custom node shapes with backgrounds.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("emojiShapesDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics
                                .WithEnabled(true)
                                .WithBarnesHut(barnes => barnes.WithGravitationalConstant(-2000))
                            );
                        });

                    // Create emoji nodes
                    var emojis = new[] {
                        ("😀", "Happy", RGBColor.Yellow),
                        ("😢", "Sad", RGBColor.LightBlue),
                        ("😡", "Angry", RGBColor.Red),
                        ("😎", "Cool", RGBColor.Orange),
                        ("🚀", "Rocket", RGBColor.Purple),
                        ("💡", "Idea", RGBColor.Yellow),
                        ("❤️", "Love", RGBColor.Pink),
                        ("⭐", "Star", RGBColor.Yellow)
                    };

                    for (int i = 0; i < emojis.Length; i++) {
                        var (emoji, label, color) = emojis[i];
                        network.AddNode($"emoji{i}", node => node
                            .WithLabel(label)
                            .WithCustomShape(VisNetworkCustomShapes.Emoji(emoji, 24))
                            .WithColor(color)
                            .WithSize(35)
                        );
                    }

                    // Create a network of connections
                    network.AddEdge("emoji0", "emoji1");
                    network.AddEdge("emoji0", "emoji3");
                    network.AddEdge("emoji1", "emoji2");
                    network.AddEdge("emoji3", "emoji4");
                    network.AddEdge("emoji4", "emoji5");
                    network.AddEdge("emoji5", "emoji6");
                    network.AddEdge("emoji6", "emoji7");
                    network.AddEdge("emoji7", "emoji0");
                });

                page.H2("3. Dynamic Custom Shape");
                page.Text("Create your own custom shape using JavaScript Canvas 2D API.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("customShapeDemo")
                        .WithSize("100%", "400px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(false));
                        });

                    // Create a custom diamond shape
                    var diamondShape = VisNetworkCustomShapes.Custom("diamond", @"
                        function({ ctx, id, x, y, state: { selected, hover }, style, label }) {
                            return {
                                drawNode() {
                                    var r = style.size || 25;
                                    ctx.beginPath();
                                    ctx.moveTo(x, y - r);
                                    ctx.lineTo(x + r, y);
                                    ctx.lineTo(x, y + r);
                                    ctx.lineTo(x - r, y);
                                    ctx.closePath();
                                    ctx.fillStyle = style.color;
                                    ctx.fill();
                                    if (selected || hover) {
                                        ctx.strokeStyle = selected ? '#000' : '#333';
                                        ctx.lineWidth = selected ? 2 : 1;
                                        ctx.stroke();
                                    }
                                },
                                nodeDimensions: { width: (style.size || 25) * 2, height: (style.size || 25) * 2 }
                            };
                        }");

                    // Create a custom star burst shape
                    var starBurstShape = VisNetworkCustomShapes.Custom("starBurst", @"
                        function({ ctx, id, x, y, state: { selected, hover }, style, label }) {
                            return {
                                drawNode() {
                                    var r = style.size || 25;
                                    var spikes = 8;
                                    var innerRadius = r * 0.5;
                                    var outerRadius = r;
                                    
                                    ctx.beginPath();
                                    for (var i = 0; i < spikes * 2; i++) {
                                        var angle = (i * Math.PI) / spikes - Math.PI / 2;
                                        var radius = i % 2 === 0 ? outerRadius : innerRadius;
                                        var x1 = x + Math.cos(angle) * radius;
                                        var y1 = y + Math.sin(angle) * radius;
                                        
                                        if (i === 0) {
                                            ctx.moveTo(x1, y1);
                                        } else {
                                            ctx.lineTo(x1, y1);
                                        }
                                    }
                                    ctx.closePath();
                                    
                                    ctx.fillStyle = style.color;
                                    ctx.fill();
                                    if (selected || hover) {
                                        ctx.strokeStyle = selected ? '#000' : '#333';
                                        ctx.lineWidth = selected ? 2 : 1;
                                        ctx.stroke();
                                    }
                                },
                                nodeDimensions: { width: (style.size || 25) * 2, height: (style.size || 25) * 2 }
                            };
                        }");

                    // Create nodes with custom shapes
                    network.AddNode("diamond1", node => node
                        .WithLabel("Diamond 1")
                        .WithCustomShape(diamondShape)
                        .WithColor(RGBColor.Purple)
                        .WithPosition(-150, 0)
                        .WithSize(50)
                    );

                    network.AddNode("starBurst", node => node
                        .WithLabel("Star Burst")
                        .WithCustomShape(starBurstShape)
                        .WithColor(RGBColor.Orange)
                        .WithPosition(0, 0)
                        .WithSize(60)
                    );

                    network.AddNode("diamond2", node => node
                        .WithLabel("Diamond 2")
                        .WithCustomShape(diamondShape)
                        .WithColor(RGBColor.Teal)
                        .WithPosition(150, 0)
                        .WithSize(50)
                    );

                    // Connect them
                    network.AddEdge("diamond1", "starBurst");
                    network.AddEdge("starBurst", "diamond2");
                });

                page.H2("4. Shape Combinations");
                page.Text("Combining custom shapes with other VisNetwork features.");

                page.DiagramNetwork(network => {
                    network
                        .WithId("combinationDemo")
                        .WithSize("100%", "500px")
                        .WithOptions(options => {
                            options.WithPhysics(physics => physics.WithEnabled(false));
                            options.WithGroup("tech", group => {
                                var techColor = new VisNetworkColorOptions()
                                    .WithBackground(RGBColor.LightBlue)
                                    .WithBorder(RGBColor.DarkBlue);
                                group.WithColor(techColor);
                            });
                            options.WithGroup("business", group => {
                                var businessColor = new VisNetworkColorOptions()
                                    .WithBackground(RGBColor.LightGreen)
                                    .WithBorder(RGBColor.DarkGreen);
                                group.WithColor(businessColor);
                            });
                        });

                    // Tech nodes with custom shapes
                    network.AddNode("server", node => node
                        .WithLabel("Server")
                        .WithCustomShape(VisNetworkCustomShapes.RoundedRectangle(10))
                        .WithGroup("tech")
                        .WithPosition(-200, -100)
                        .WithSize(60)
                    );

                    network.AddNode("database", node => node
                        .WithLabel("Database")
                        .WithShape(VisNetworkNodeShape.Database)  // Standard shape
                        .WithGroup("tech")
                        .WithPosition(0, -100)
                    );

                    network.AddNode("cloudService", node => node
                        .WithLabel("Cloud\nService")
                        .WithCustomShape(VisNetworkCustomShapes.Cloud)
                        .WithGroup("tech")
                        .WithPosition(200, -100)
                    );

                    // Business nodes with custom shapes
                    network.AddNode("employee", node => node
                        .WithLabel("Employee")
                        .WithCustomShape(VisNetworkCustomShapes.Person)
                        .WithGroup("business")
                        .WithPosition(-200, 100)
                    );

                    network.AddNode("office", node => node
                        .WithLabel("Office")
                        .WithCustomShape(VisNetworkCustomShapes.House)
                        .WithGroup("business")
                        .WithPosition(0, 100)
                    );

                    network.AddNode("process", node => node
                        .WithLabel("Process")
                        .WithCustomShape(VisNetworkCustomShapes.Gear(6))
                        .WithGroup("business")
                        .WithPosition(200, 100)
                    );

                    // Mixed connections
                    network.AddEdge("server", "database", edge => edge
                        .WithArrows(arrows => arrows.WithTo(true))
                        .WithLabel("Query")
                    );
                    network.AddEdge("database", "cloudService", edge => edge
                        .WithArrows(arrows => arrows.WithTo(true).WithFrom(true))
                        .WithLabel("Sync")
                    );
                    network.AddEdge("employee", "office");
                    network.AddEdge("office", "process");
                    network.AddEdge("employee", "server", edge => edge
                        .WithDashes(true)
                        .WithLabel("Access")
                    );
                });

                // Instructions
                page.H2("About Custom Shapes");
                page.Text("Custom shapes in VisNetwork allow you to create any shape using the Canvas 2D API. Key features:");
                page.Text("• Full access to Canvas 2D context for drawing");
                page.LineBreak();
                page.Text("• Automatic handling of fill and stroke based on node styling");
                page.LineBreak();
                page.Text("• Size property controls the overall scale");
                page.LineBreak();
                page.Text("• Works with all other node features (labels, colors, physics, etc.)");
                page.LineBreak();
                page.Text("• Can be combined with groups and standard shapes");

                page.Text("The ctxRenderer function receives: ctx (canvas context), x, y (center position), state, doStroke, doFill flags.");
            });

            document.Save("VisNetworkCustomShapesDemo.html", openInBrowser);
            HelpersSpectre.Success($"VisNetwork Custom Shapes Demo created at: VisNetworkCustomShapesDemo.html");
        }
    }
}