using System;

namespace HtmlForgeX.Examples.Icons;

/// <summary>
/// Comprehensive demonstration of the FontAwesome icon system implementation
/// Shows usage in both VisNetwork and general HTML contexts
/// </summary>
internal class FontAwesomeComprehensiveDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("FontAwesome Comprehensive Demo");

        using var document = new Document {
            Head = {
                Title = "FontAwesome Icons - Complete Implementation",
                Author = "HtmlForgeX",
                Description = "Demonstrates FontAwesome Solid, Regular, and Brands icons"
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.H1("FontAwesome Icons - Complete Implementation");

            // Section 1: Using icons in general HTML
            page.H2("FontAwesome Icons in HTML");

            page.Row(row => {
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => {
                            header.Title("Solid Icons");
                            header.Icon(FontAwesomeSolid.Star);
                        });
                        card.Body(body => {
                            body.Icon(FontAwesomeSolid.User).WithSize(FontAwesomeSize.X2).WithColor(RGBColor.DarkBlue);
                            body.Text(" User Management").LineBreak();

                            body.Icon(FontAwesomeSolid.Lock).WithSize(FontAwesomeSize.X2).WithColor(RGBColor.DarkRed);
                            body.Text(" Security Settings").LineBreak();

                            body.Icon(FontAwesomeSolid.Database).WithSize(FontAwesomeSize.X2).WithColor(RGBColor.DarkGreen);
                            body.Text(" Database Operations").LineBreak();

                            body.Icon(FontAwesomeSolid.Gear, icon => icon
                                .WithSize(FontAwesomeSize.X2)
                                .WithSpin()
                                .WithColor(RGBColor.Orange)
                            );
                            body.Text(" Processing...").LineBreak();
                        });
                    });
                });

                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => {
                            header.Title("Regular Icons");
                            header.Icon(FontAwesomeRegular.Heart);
                        });
                        card.Body(body => {
                            body.Icon(FontAwesomeRegular.FileLines).WithSize(FontAwesomeSize.X2);
                            body.Text(" Document").LineBreak();

                            body.Icon(FontAwesomeRegular.Calendar).WithSize(FontAwesomeSize.X2);
                            body.Text(" Schedule").LineBreak();

                            body.Icon(FontAwesomeRegular.Bell).WithSize(FontAwesomeSize.X2);
                            body.Text(" Notifications").LineBreak();

                            body.Icon(FontAwesomeRegular.Envelope).WithSize(FontAwesomeSize.X2);
                            body.Text(" Messages").LineBreak();
                        });
                    });
                });

                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(header => {
                            header.Title("Brand Icons");
                            header.Icon(FontAwesomeBrands.GitHub);
                        });
                        card.Body(body => {
                            body.Icon(FontAwesomeBrands.Facebook).WithSize(FontAwesomeSize.X2).WithColor("#1877f2");
                            body.Text(" Facebook").LineBreak();

                            body.Icon(FontAwesomeBrands.Twitter).WithSize(FontAwesomeSize.X2).WithColor("#1da1f2");
                            body.Text(" Twitter").LineBreak();

                            body.Icon(FontAwesomeBrands.YouTube).WithSize(FontAwesomeSize.X2).WithColor("#ff0000");
                            body.Text(" YouTube").LineBreak();

                            body.Icon(FontAwesomeBrands.LinkedinIn).WithSize(FontAwesomeSize.X2).WithColor("#0077b5");
                            body.Text(" LinkedIn").LineBreak();
                        });
                    });
                });
            });

            // Section 2: Icon modifiers and effects
            page.H2("Icon Modifiers & Effects");

            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Icon Transformations"));
                        card.Body(body => {
                            // Sizes
                            body.H4("Sizes:");
                            body.Icon(FontAwesomeSolid.House).WithSize(FontAwesomeSize.ExtraSmall);
                            body.Text(" xs  ");
                            body.Icon(FontAwesomeSolid.House).WithSize(FontAwesomeSize.Small);
                            body.Text(" sm  ");
                            body.Icon(FontAwesomeSolid.House);
                            body.Text(" normal  ");
                            body.Icon(FontAwesomeSolid.House).WithSize(FontAwesomeSize.Large);
                            body.Text(" lg  ");
                            body.Icon(FontAwesomeSolid.House).WithSize(FontAwesomeSize.X2);
                            body.Text(" 2x  ");
                            body.Icon(FontAwesomeSolid.House).WithSize(FontAwesomeSize.X3);
                            body.Text(" 3x ").LineBreak().LineBreak();

                            // Rotations
                            body.H4("Rotations:");
                            body.Icon(FontAwesomeSolid.Shield);
                            body.Text(" Normal  ");
                            body.Icon(FontAwesomeSolid.Shield).WithRotate(90);
                            body.Text(" 90°  ");
                            body.Icon(FontAwesomeSolid.Shield).WithRotate(180);
                            body.Text(" 180°  ");
                            body.Icon(FontAwesomeSolid.Shield).WithRotate(270);
                            body.Text(" 270° ").LineBreak().LineBreak();

                            // Flips
                            body.H4("Flips:");
                            body.Icon(FontAwesomeSolid.Shield);
                            body.Text(" Normal  ");
                            body.Icon(FontAwesomeSolid.Shield).WithFlip(FontAwesomeFlip.Horizontal);
                            body.Text(" Horizontal  ");
                            body.Icon(FontAwesomeSolid.Shield).WithFlip(FontAwesomeFlip.Vertical);
                            body.Text(" Vertical  ");
                            body.Icon(FontAwesomeSolid.Shield).WithFlip(FontAwesomeFlip.Both);
                            body.Text(" Both ").LineBreak().LineBreak();

                            // Animations
                            body.H4("Animations:");
                            body.Icon(FontAwesomeSolid.ArrowRotateRight).WithSpin();
                            body.Text(" Spin  ");
                            body.Icon(FontAwesomeRegular.Heart).WithPulse();
                            body.Text(" Pulse ").LineBreak();
                        });
                    });
                });
            });

            // Section 3: VisNetwork with FontAwesome icons
            page.H2("FontAwesome Icons in VisNetwork");

            page.DiagramNetwork(network => {
                network
                    .WithId("fontAwesomeNetwork")
                    .WithSize("100%", "500px")
                    .WithPhysics(false);

                // Solid Icons
                network.AddNode(1, node => node
                    .WithLabel("Server Infrastructure")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon.WithFontAwesome(FontAwesomeSolid.Server))
                    .WithPosition(-300, -100)
                );

                network.AddNode(2, node => node
                    .WithLabel("User Management")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon.WithFontAwesome(FontAwesomeSolid.Users))
                    .WithPosition(0, -100)
                );

                network.AddNode(3, node => node
                    .WithLabel("Security")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon.WithFontAwesome(FontAwesomeSolid.Shield))
                    .WithPosition(300, -100)
                );

                // Regular Icons
                network.AddNode(4, node => node
                    .WithLabel("Documents")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon.WithFontAwesome(FontAwesomeRegular.FileLines))
                    .WithPosition(-300, 0)
                );

                network.AddNode(5, node => node
                    .WithLabel("Calendar")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon.WithFontAwesome(FontAwesomeRegular.Calendar))
                    .WithPosition(0, 0)
                );

                network.AddNode(6, node => node
                    .WithLabel("Email")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon.WithFontAwesome(FontAwesomeRegular.Envelope))
                    .WithPosition(300, 0)
                );

                // Brand Icons
                network.AddNode(7, node => node
                    .WithLabel("GitHub Repo")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon.WithFontAwesome(FontAwesomeBrands.GitHub))
                    .WithPosition(-300, 100)
                );

                network.AddNode(8, node => node
                    .WithLabel("Docker Container")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon.WithFontAwesome(FontAwesomeBrands.Docker))
                    .WithPosition(0, 100)
                );

                network.AddNode(9, node => node
                    .WithLabel("AWS Cloud")
                    .WithShape(VisNetworkNodeShape.Icon)
                    .WithIcon(icon => icon.WithFontAwesome(FontAwesomeBrands.Aws))
                    .WithPosition(300, 100)
                );

                // Connect nodes
                network.AddEdge(1, 2);
                network.AddEdge(2, 3);
                network.AddEdge(1, 4);
                network.AddEdge(2, 5);
                network.AddEdge(3, 6);
                network.AddEdge(7, 1);
                network.AddEdge(8, 2);
                network.AddEdge(9, 3);
            });

            // Section 4: Code Examples
            page.H2("Usage Examples");

            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("HTML Icon Usage"));
                        card.Body(body => {
                            body.CSharpCode(@"// Add solid icon
page.Icon(FontAwesomeSolid.User);

// Add regular icon with size
page.Icon(FontAwesomeRegular.Heart)
    .WithSize(FontAwesomeSize.X2);

// Add brand icon with color
page.Icon(FontAwesomeBrands.GitHub)
    .WithColor(""#333"");

// Icon with multiple modifiers
page.Icon(FontAwesomeSolid.ArrowRotateRight, icon => icon
    .WithSize(FontAwesomeSize.X3)
    .WithSpin()
    .WithColor(RGBColor.Blue)
);", config => config
                                .EnableLineNumbers()
                                .EnableCopyButton());
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("VisNetwork Icon Usage"));
                        card.Body(body => {
                            body.CSharpCode(@"// Solid icon in VisNetwork
network.AddNode(1, node => node
    .WithShape(VisNetworkNodeShape.Icon)
    .WithIcon(icon => icon
        .WithFontAwesome(FontAwesomeSolid.Server)
    )
);

// Regular icon
.WithIcon(icon => icon
    .WithFontAwesome(FontAwesomeRegular.Calendar)
)

// Brand icon
.WithIcon(icon => icon
    .WithFontAwesome(FontAwesomeBrands.Docker)
)", config => config
                                .EnableLineNumbers()
                                .EnableCopyButton());
                        });
                    });
                });
            });

            // Benefits section
            page.H2("Benefits of the Complete Implementation");

            page.Text("• Three separate enums for Solid, Regular, and Brands").LineBreak();
            page.Text("• Type-safe icon selection with IntelliSense").LineBreak();
            page.Text("• Works in both HTML elements and VisNetwork").LineBreak();
            page.Text("• Support for all FontAwesome features (size, rotation, animation)").LineBreak();
            page.Text("• Automatic style and weight handling").LineBreak();
            page.Text("• Compatible with FontAwesome 6").LineBreak();
        });

        document.Save("FontAwesomeComprehensiveDemo.html", openInBrowser);
        HelpersSpectre.Success("FontAwesome Comprehensive Demo created successfully!");
    }
}