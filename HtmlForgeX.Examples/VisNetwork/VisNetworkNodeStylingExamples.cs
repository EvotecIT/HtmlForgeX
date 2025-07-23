namespace HtmlForgeX.Examples.VisNetwork;

internal class VisNetworkNodeStylingExamples {
    public static void Demo(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("VisNetwork Node Styling Examples");

        using var document = new Document {
            Head = { Title = "VisNetwork Node Styling Examples", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.H2("VisNetwork Node Styling Examples");
            page.LineBreak();

            // Example 1: Font Awesome Icons
            page.H3("Font Awesome Icons");
            page.DiagramNetwork(network => {
                network
                    .WithId("fontAwesomeIcons")
                    .WithSize("100%", "400px")
                    .WithPhysics(false);

                // Add Font Awesome icon nodes
                network.AddNode(1, node => node
                    .WithLabel("Server")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon
                        .WithFontAwesome(FontAwesomeSolid.Server)
                        .WithSize(50)
                        .WithColor(RGBColor.DarkBlue)
                    )
                    .WithPosition(-200, 0)
                );

                network.AddNode(2, node => node
                    .WithLabel("Database")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon
                        .WithFontAwesome5(FontAwesome5Solid.Database)
                        .WithSize(50)
                        .WithColor(RGBColor.DarkGreen)
                    )
                    .WithPosition(0, 0)
                );

                network.AddNode(3, node => node
                    .WithLabel("Users")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon
                        .WithFontAwesome5(FontAwesome5Solid.Users)
                        .WithSize(50)
                        .WithColor(RGBColor.DarkOrange)
                    )
                    .WithPosition(200, 0)
                );

                network.AddNode(4, node => node
                    .WithLabel("Cloud")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon
                        .WithFontAwesome5(FontAwesome5Solid.Cloud)
                        .WithSize(50)
                        .WithColor(RGBColor.SkyBlue)
                    )
                    .WithPosition(0, -150)
                );

                network.AddNode(5, node => node
                    .WithLabel("Security")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon
                        .WithFontAwesome5(FontAwesome5Solid.Lock)
                        .WithSize(50)
                        .WithColor(RGBColor.DarkRed)
                    )
                    .WithPosition(0, 150)
                );

                // Connect the nodes
                network.AddEdge(1, 2);
                network.AddEdge(2, 3);
                network.AddEdge(1, 4);
                network.AddEdge(2, 4);
                network.AddEdge(5, 1);
                network.AddEdge(5, 2);
                network.AddEdge(5, 3);
            });

            page.LineBreak();

            // Example 2: Multiline and Multifont Labels
            page.H3("Multiline and Multifont Labels");
            page.DiagramNetwork(network => {
                network
                    .WithId("multilineLabels")
                    .WithSize("100%", "400px")
                    .WithPhysics(false)
                    .WithOptions(options => {
                        options.WithNodes(nodes => {
                            nodes
                                .WithShape(VisNetworkNodeShape.Box)
                                .WithFont(font => font
                                    .WithMulti(VisNetworkMulti.Html)
                                    .WithSize(14)
                                );
                        });
                    });

                // Multiline text with HTML
                network.AddNode(1, node => node
                    .WithHtmlLabel(label => label
                        .Bold("Bold Title")
                        .LineBreak()
                        .Italic("Italic subtitle")
                        .LineBreak()
                        .Code("code.example()")
                    )
                    .WithPosition(-300, 0)
                    .WithColor(RGBColor.LightBlue)
                );

                // Multiple fonts in one label
                network.AddNode(2, node => node
                    .WithHtmlLabel(label => label
                        .Bold("Server Status")
                        .LineBreak()
                        .Text("Status: Online")
                        .LineBreak()
                        .Code("CPU: 45%")
                    )
                    .WithPosition(0, 0)
                    .WithColor(RGBColor.LightGray)
                );

                // Markdown-style formatting
                network.AddNode(3, node => node
                    .WithHtmlLabel(label => label
                        .Bold("Performance")
                        .LineBreak()
                        .Bold("Critical")
                        .LineBreak()
                        .Italic("Action Required")
                    )
                    .WithPosition(300, 0)
                    .WithColor(RGBColor.LightCoral)
                );

                // Complex formatting
                network.AddNode(4, node => node
                    .WithHtmlLabel(label => label
                        .Bold("User Profile")
                        .LineBreak()
                        .Italic("John Doe")
                        .LineBreak()
                        .Code("john@example.com")
                        .LineBreak()
                        .Italic("Role: Admin")
                    )
                    .WithPosition(0, -200)
                    .WithWidthConstraint(minimum: 200)
                    .WithColor(RGBColor.LightGreen)
                );

                network.AddEdge(1, 2);
                network.AddEdge(2, 3);
                network.AddEdge(2, 4);
            });

            page.LineBreak();

            // Example 3: Images with Borders, Padding, and Opacity
            page.H3("Image Styling - Borders, Padding, Opacity");
            page.DiagramNetwork(network => {
                network
                    .WithId("imagesStyling")
                    .WithSize("100%", "400px")
                    .WithPhysics(false);

                // Image with border
                network.AddNode(1, node => node
                    .WithLabel("Border Style")
                    .WithShape(VisNetworkNodeShape.Image)
                    .WithImage("Assets/Icons/UxWing/server-icon.png")
                    .WithShapeProperties(props => props
                        .WithUseBorderWithImage(true)
                    )
                    .WithBorderWidth(5)
                    .WithColor(RGBColor.DarkBlue)
                    .WithPosition(-300, 0)
                );

                // Circular image with border
                network.AddNode(2, node => node
                    .WithLabel("Circular Border")
                    .WithShape(VisNetworkNodeShape.CircularImage)
                    .WithImage("Assets/Icons/UxWing/user-settings-icon.png")
                    .WithBorderWidth(3)
                    .WithColor(RGBColor.DarkGoldenrod)
                    .WithSize(60)
                    .WithPosition(-100, 0)
                );

                // Image with opacity
                network.AddNode(3, node => node
                    .WithLabel("50% Opacity")
                    .WithShape(VisNetworkNodeShape.Image)
                    .WithImage("Assets/Icons/UxWing/cloud-icon.png")
                    .WithOpacity(0.5)
                    .WithPosition(100, 0)
                );

                // Image with shadow
                network.AddNode(4, node => node
                    .WithLabel("With Shadow")
                    .WithShape(VisNetworkNodeShape.CircularImage)
                    .WithImage("Assets/Icons/UxWing/computer-cpu-icon.png")
                    .WithShadow(new VisNetworkShadowOptions()
                        .WithEnabled(true)
                        .WithColor(RGBColor.Black)
                        .WithSize(10)
                        .WithOffset(5, 5)
                    )
                    .WithPosition(300, 0)
                );

                // Different border styles
                network.AddNode(5, node => node
                    .WithLabel("Dashed Border")
                    .WithShape(VisNetworkNodeShape.Image)
                    .WithImage("Assets/Icons/UxWing/wrench-icon.png")
                    .WithShapeProperties(props => props
                        .WithUseBorderWithImage(true)
                        .WithBorderDashes(VisNetworkDashPattern.ShortDash)
                    )
                    .WithBorderWidth(3)
                    .WithColor(RGBColor.DarkGreen)
                    .WithPosition(0, 150)
                );
            });

            page.LineBreak();

            // Example 4: Advanced Node Styling
            page.H3("Advanced Node Styling");
            page.DiagramNetwork(network => {
                network
                    .WithId("advancedStyling")
                    .WithSize("100%", "500px")
                    .WithPhysics(physics => {
                        physics.WithEnabled(true)
                            .WithSolver(VisNetworkPhysicsSolver.ForceAtlas2based);
                    });

                // Node with custom colors for different states
                network.AddNode(1, node => node
                    .WithLabel("Hover & Select")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithColor(new VisNetworkColorOptions()
                        .WithBackground(RGBColor.LightBlue)
                        .WithBorder(RGBColor.DarkBlue)
                        .WithHighlight(RGBColor.Yellow, RGBColor.Orange)
                        .WithHover(RGBColor.LightYellow, RGBColor.DarkGoldenrod)
                    )
                    .WithChosen(new VisNetworkChosenOptions()
                        .WithNode(nodeChosen => nodeChosen
                            .WithColor(RGBColor.Red)
                            .WithBorderColor(RGBColor.DarkRed)
                            .WithBorderWidth(4)
                            .WithSize(40)
                        )
                    )
                );

                // Node with scaling based on value
                network.AddNode(2, node => node
                    .WithLabel("Scaled by Value")
                    .WithShape(VisNetworkNodeShape.Circle)
                    .WithValue(100)
                    .WithScaling(scaling => scaling
                        .WithMin(20)
                        .WithMax(60)
                        .WithLabel(min: 10, max: 30, maxVisible: 20)
                    )
                    .WithColor(RGBColor.Purple)
                );

                // Node with constraints
                network.AddNode(3, node => node
                    .WithLabel("This is a very long label that will be constrained to a maximum width")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithWidthConstraint(maximum: 150)
                    .WithHeightConstraint(minimum: 50, maximum: 100)
                    .WithColor(RGBColor.Green)
                );

                // Node with margin
                network.AddNode(4, node => node
                    .WithLabel("Margins")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithMargin(20, 10, 20, 10)
                    .WithColor(RGBColor.Orange)
                );

                // Custom shape properties
                network.AddNode(5, node => node
                    .WithLabel("Rounded Box")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithShapeProperties(props => props
                        .WithBorderRadius(15)
                    )
                    .WithColor(RGBColor.Pink)
                );

                // Hidden node
                network.AddNode(6, node => node
                    .WithLabel("Hidden Node")
                    .WithHidden(true)
                );

                // Fixed position node
                network.AddNode(7, node => node
                    .WithLabel("Fixed Position")
                    .WithPosition(0, -200)
                    .WithFixed(true, true)
                    .WithShape(VisNetworkNodeShape.Diamond)
                    .WithColor(RGBColor.Red)
                );

                // Connect nodes
                network.AddEdge(1, 2);
                network.AddEdge(2, 3);
                network.AddEdge(3, 4);
                network.AddEdge(4, 5);
                network.AddEdge(5, 6);
                network.AddEdge(1, 7);
                network.AddEdge(3, 7);
            });

            page.LineBreak();

            // Example 5: Node Legends
            page.H3("Network with Legend");
            page.DiagramNetwork(network => {
                network
                    .WithId("networkLegend")
                    .WithSize("100%", "500px")
                    .WithPhysics(false)
                    .WithOptions(options => {
                        options.WithInteraction(interaction => {
                            interaction.WithDragNodes(false);
                        });
                    });

                // Main network nodes
                var y = -100;
                network.AddNode("server1", node => node
                    .WithLabel("Production Server")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithGroup("production")
                    .WithPosition(0, y)
                );

                network.AddNode("server2", node => node
                    .WithLabel("Staging Server")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithGroup("staging")
                    .WithPosition(-200, y + 100)
                );

                network.AddNode("server3", node => node
                    .WithLabel("Development Server")
                    .WithShape(VisNetworkNodeShape.Box)
                    .WithGroup("development")
                    .WithPosition(200, y + 100)
                );

                network.AddNode("db1", node => node
                    .WithLabel("Database")
                    .WithShape(VisNetworkNodeShape.Database)
                    .WithGroup("database")
                    .WithPosition(0, y + 200)
                );

                // Configure groups
                network.WithGroup("production", group => group
                    .WithColor(RGBColor.DarkRed)
                    .WithFont(font => font.WithColor(RGBColor.White))
                );

                network.WithGroup("staging", group => group
                    .WithColor(RGBColor.DarkOrange)
                    .WithFont(font => font.WithColor(RGBColor.White))
                );

                network.WithGroup("development", group => group
                    .WithColor(RGBColor.DarkGreen)
                    .WithFont(font => font.WithColor(RGBColor.White))
                );

                network.WithGroup("database", group => group
                    .WithColor(RGBColor.DarkBlue)
                    .WithFont(font => font.WithColor(RGBColor.White))
                );

                // Add connections
                network.AddEdge("server1", "db1");
                network.AddEdge("server2", "db1");
                network.AddEdge("server3", "db1");

                // Create legend nodes
                var legendX = -400;
                var legendY = -200;
                var legendSpacing = 50;

                network.AddNode("legend_title", node => node
                    .WithLabel("LEGEND")
                    .WithShape(VisNetworkNodeShape.Text)
                    .WithFont(font => font.WithSize(16).WithFace("bold"))
                    .WithPosition(legendX, legendY)
                    .WithFixed(true, true)
                );

                var legendItems = new[] {
                    ("legend_prod", "Production", "production"),
                    ("legend_stage", "Staging", "staging"),
                    ("legend_dev", "Development", "development"),
                    ("legend_db", "Database", "database")
                };

                var i = 1;
                foreach (var (id, label, group) in legendItems) {
                    network.AddNode(id, node => node
                        .WithLabel(label)
                        .WithShape(VisNetworkNodeShape.Box)
                        .WithGroup(group)
                        .WithSize(20)
                        .WithPosition(legendX, legendY + (i * legendSpacing))
                        .WithFixed(true, true)
                    );
                    i++;
                }
            });
        });

        document.Save("VisNetworkNodeStylingExamples.html", openInBrowser);
    }
}