using System;

namespace HtmlForgeX.Examples.Containers;

/// <summary>
/// Demonstrates the new FontAwesome enum system for easy icon selection.
/// Shows before/after examples of using FontAwesome icons in VisNetwork.
/// </summary>
internal class FontAwesomeExampleDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("FontAwesome Enum System Demo");

        using var document = new Document {
            Head = { 
                Title = "FontAwesome Enum System Demo", 
                Author = "HtmlForgeX",
                Description = "Comparing old vs new FontAwesome icon usage"
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.H1("FontAwesome Enum System Demo");
            page.Text("Compare the old manual Unicode approach with the new type-safe enum system:");

            page.H2("Old Approach (Manual Unicode)");
            page.DiagramNetwork(network => {
                network
                    .WithId("oldApproach")
                    .WithSize("100%", "300px")
                    .WithPhysics(false);

                // Old way - hard to remember Unicode values
                network.AddNode(1, node => node
                    .WithLabel("Server")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon
                        .WithFace("FontAwesome")
                        .WithCode("\uf233")  // Hard to remember!
                        .WithSize(50)
                        .WithColor(RGBColor.DarkBlue)
                    )
                    .WithPosition(-150, 0)
                );

                network.AddNode(2, node => node
                    .WithLabel("Users")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon
                        .WithFace("FontAwesome")
                        .WithCode("\uf0c0")  // What icon is this?
                        .WithSize(50)
                        .WithColor(RGBColor.DarkGreen)
                    )
                    .WithPosition(0, 0)
                );

                network.AddNode(3, node => node
                    .WithLabel("Security")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon
                        .WithFace("FontAwesome")
                        .WithCode("\uf023")  // Need to look this up
                        .WithSize(50)
                        .WithColor(RGBColor.DarkRed)
                    )
                    .WithPosition(150, 0)
                );

                network.AddEdge(1, 2);
                network.AddEdge(2, 3);
            });

            page.H2("New Approach (Type-Safe Enum)");
            page.DiagramNetwork(network => {
                network
                    .WithId("newApproach")
                    .WithSize("100%", "300px")
                    .WithPhysics(false);

                // New way - IntelliSense friendly enum values
                network.AddNode(1, node => node
                    .WithLabel("Server")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon
                        .WithFontAwesome(FontAwesome.Server)  // Clear and discoverable!
                        .WithSize(50)
                        .WithColor(RGBColor.DarkBlue)
                    )
                    .WithPosition(-150, 0)
                );

                network.AddNode(2, node => node
                    .WithLabel("Users")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon
                        .WithFontAwesome(FontAwesome.Users)  // Obvious what this is
                        .WithSize(50)
                        .WithColor(RGBColor.DarkGreen)
                    )
                    .WithPosition(0, 0)
                );

                network.AddNode(3, node => node
                    .WithLabel("Security")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon
                        .WithFontAwesome(FontAwesome.Lock)  // IntelliSense suggests this
                        .WithSize(50)
                        .WithColor(RGBColor.DarkRed)
                    )
                    .WithPosition(150, 0)
                );

                network.AddEdge(1, 2);
                network.AddEdge(2, 3);
            });

            page.H2("Available FontAwesome Icons");
            page.Text("The enum includes commonly used categories:");

            page.H3("Infrastructure & Technology");
            page.DiagramNetwork(network => {
                network
                    .WithId("infrastructure")
                    .WithSize("100%", "200px")
                    .WithPhysics(false);

                var icons = new[] {
                    (FontAwesome.Server, "Server", -300),
                    (FontAwesome.Database, "Database", -150),
                    (FontAwesome.Cloud, "Cloud", 0),
                    (FontAwesome.Desktop, "Desktop", 150),
                    (FontAwesome.Laptop, "Laptop", 300)
                };

                for (int i = 0; i < icons.Length; i++) {
                    var (icon, label, x) = icons[i];
                    network.AddNode(i + 1, node => node
                        .WithLabel(label)
                        .WithShape(VisNetworkNodeShape.Icon)
                        .WithIcon(iconOptions => iconOptions
                            .WithFontAwesome(icon)
                            .WithSize(40)
                            .WithColor(RGBColor.DarkBlue)
                        )
                        .WithPosition(x, 0)
                    );
                }
            });

            page.H3("People & Communication");
            page.DiagramNetwork(network => {
                network
                    .WithId("people")
                    .WithSize("100%", "200px")
                    .WithPhysics(false);

                var icons = new[] {
                    (FontAwesome.User, "User", -300),
                    (FontAwesome.Users, "Users", -150),
                    (FontAwesome.UserTie, "UserTie", 0),
                    (FontAwesome.Email, "Email", 150),
                    (FontAwesome.Phone, "Phone", 300)
                };

                for (int i = 0; i < icons.Length; i++) {
                    var (icon, label, x) = icons[i];
                    network.AddNode(i + 1, node => node
                        .WithLabel(label)
                        .WithShape(VisNetworkNodeShape.Icon)
                        .WithIcon(iconOptions => iconOptions
                            .WithFontAwesome(icon)
                            .WithSize(40)
                            .WithColor(RGBColor.DarkGreen)
                        )
                        .WithPosition(x, 0)
                    );
                }
            });

            page.H3("Status & Actions");
            page.DiagramNetwork(network => {
                network
                    .WithId("status")
                    .WithSize("100%", "200px")
                    .WithPhysics(false);

                var icons = new[] {
                    (FontAwesome.CheckCircle, "Success", -300),
                    (FontAwesome.TimesCircle, "Error", -150),
                    (FontAwesome.Warning, "Warning", 0),
                    (FontAwesome.Info, "Info", 150),
                    (FontAwesome.Gear, "Settings", 300)
                };

                for (int i = 0; i < icons.Length; i++) {
                    var (icon, label, x) = icons[i];
                    network.AddNode(i + 1, node => node
                        .WithLabel(label)
                        .WithShape(VisNetworkNodeShape.Icon)
                        .WithIcon(iconOptions => iconOptions
                            .WithFontAwesome(icon)
                            .WithSize(40)
                            .WithColor(RGBColor.DarkOrange)
                        )
                        .WithPosition(x, 0)
                    );
                }
            });

            page.H2("Benefits of the Enum System");
            page.Text("✅ **IntelliSense Support**: Discover available icons as you type").LineBreak();
            page.Text("✅ **Type Safety**: Compile-time checking prevents typos").LineBreak();
            page.Text("✅ **Self-Documenting**: Enum names clearly indicate what icon they represent").LineBreak();
            page.Text("✅ **No Unicode Memorization**: No need to remember \\uf233 codes").LineBreak();
            page.Text("✅ **Backward Compatible**: Old WithCode() method still works").LineBreak();
        });

        document.Save("FontAwesomeEnumDemo.html", openInBrowser);
        HelpersSpectre.Success("FontAwesome Enum System Demo created successfully!");
    }
}