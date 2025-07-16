using HtmlForgeX.Examples;

namespace HtmlForgeX.Examples.Containers;

/// <summary>
/// Proper Tabler Cards Demo - Zero HTML, proper C# API usage
/// This demonstrates the correct way to use card components without any raw HTML
/// </summary>
internal class TablerCardsProperDemo {
    public static void Demo01(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Proper Tabler Cards Demo - Zero HTML, Pure C# API");

        using var document = new Document {
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Head.Title = "Proper Tabler Cards Demo - No Raw HTML";
        document.Head.Author = "HtmlForgeX";
        document.Head.Revised = DateTime.Now;

        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;

            // ===============================================
            // SECTION 1: Basic Cards with Proper Headers
            // ===============================================

            page.Add(new HeaderLevel(HeaderLevelTag.H2, "Basic Cards - Proper C# API"));
            page.Text("All cards built using fluent C# methods - zero raw HTML").Style(TablerTextStyle.Muted);

            page.Row(row => {
                // Card 1: Simple header and body
                row.Column(TablerColumnNumber.MediumSixLargeThree, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Card Title");
                        });
                        card.Body(body => {
                            body.Text("Lorem ipsum dolor sit amet, consectetur adipisicing elit. Aperiam deleniti fugit incidunt, iste, itaque minima neque pariatur perferendis sed suscipit, velit?");
                        });
                    });
                });

                // Card 2: Light header with subtitle
                row.Column(TablerColumnNumber.MediumSixLargeThree, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Card Title").Subtitle("With Subtitle").Style(TablerCardHeaderStyle.Light);
                        });
                        card.Body(body => {
                            body.Text("This card has a light header style and subtitle.");
                        });
                    });
                });

                // Card 3: Header with avatar
                row.Column(TablerColumnNumber.MediumSixLargeThree, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Paweł Kuna").Subtitle("UI Designer");
                            header.Avatar(avatar => {
                                avatar.Image("https://picsum.photos/100/100?random=100");
                            });
                        });
                        card.Body(body => {
                            body.Text("Profile card with avatar and contact information.");
                        });
                    });
                });

                // Card 4: Header with actions
                row.Column(TablerColumnNumber.MediumSixLargeThree, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Card with Actions");
                            header.WithActions(actions => {
                                actions.Button("Add New", btn => btn.Style(TablerButtonVariant.Primary));
                                actions.IconButton(TablerIconType.Phone, btn => btn.AsActionButton());
                                actions.IconButton(TablerIconType.Mail, btn => btn.AsActionButton());
                            });
                        });
                        card.Body(body => {
                            body.Text("This card has action buttons in the header.");
                        });
                    });
                });
            });

            // ===============================================
            // SECTION 2: Cards with Enhanced Features
            // ===============================================

            page.Add(new HeaderLevel(HeaderLevelTag.H2, "Enhanced Cards - Ribbons, Stamps, Progress"));

            page.Row(row => {
                // Card with stamp
                row.Column(TablerColumnNumber.MediumSixLargeThree, column => {
                    column.Card(card => {
                        card.Stamp(TablerIconType.Bell, TablerColor.Yellow);
                        card.Header(header => {
                            header.Title("Card with Stamp");
                        });
                        card.Body(body => {
                            body.Text("This card has a stamp icon in the corner using proper C# methods.");
                        });
                    });
                });

                // Card with text ribbon
                row.Column(TablerColumnNumber.MediumSixLargeThree, column => {
                    column.Card(card => {
                        card.Ribbon("NEW", TablerColor.Red);
                        card.Body(body => {
                            body.Title("Card with Text Ribbon");
                            body.Text("This card has a 'NEW' text ribbon added via C# method.");
                        });
                    });
                });

                // Card with progress bar
                row.Column(TablerColumnNumber.MediumSixLargeThree, column => {
                    column.Card(card => {
                        card.Body(body => {
                            body.Title("Card with Progress");
                            body.Text("This card shows progress at 75% using proper C# method.");
                        });
                        card.Progress(75, TablerColor.Primary);
                    });
                });

                // Card with status indicator
                row.Column(TablerColumnNumber.MediumSixLargeThree, column => {
                    column.Card(card => {
                        card.StatusIndicator("top", TablerColor.Success);
                        card.Body(body => {
                            body.Title("Status Indicator");
                            body.Text("Green status indicator at the top using C# methods.");
                        });
                    });
                });
            });

            // ===============================================
            // SECTION 3: Cards with Lists and Text Formatting
            // ===============================================

            page.Add(new HeaderLevel(HeaderLevelTag.H2, "Cards with Lists and Text Formatting"));

            page.Row(row => {
                // Card with proper list
                row.Column(TablerColumnNumber.MediumSixLargeThree, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Feature List");
                        });
                        card.Body(body => {
                            body.Text("Check out these features:");
                            body.AddList(list => {
                                list.Type(TablerCardListType.Unordered).Style(TablerCardListStyle.Unstyled);
                                list.WithItems(items => {
                                    items.CheckItem("Basic cards with headers", true);
                                    items.CheckItem("Light headers and subtitles", true);
                                    items.CheckItem("Status indicators", true);
                                    items.CheckItem("Ribbons and stamps", true);
                                    items.CheckItem("Progress bars", false);
                                });
                            });
                        });
                    });
                });

                // Card with formatted text
                row.Column(TablerColumnNumber.MediumSixLargeThree, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Text Formatting");
                        });
                        card.Body(body => {
                            body.AddText(text => {
                                text.WithContent("This is emphasized text").Emphasized();
                            });
                            body.AddText(text => {
                                text.WithContent("This is strong text").Strong();
                            });
                            body.AddText(text => {
                                text.WithContent("This is muted text").Style(TablerTextStyle.Muted);
                            });
                            body.AddText(text => {
                                text.WithContent("This is medium weight text").Weight(TablerFontWeight.Medium);
                            });
                        });
                    });
                });

                // Card with navigation tabs
                row.Column(TablerColumnNumber.LargeSix, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.WithNavigation(nav => {
                                nav.Type(TablerCardNavigationType.Tabs);
                                nav.WithItems(items => {
                                    items.Item("Home", item => item.Active());
                                    items.Item("Profile");
                                    items.Item("Settings");
                                    items.Item("Disabled", item => item.Disabled());
                                });
                            });
                        });
                        card.Body(body => {
                            body.Text("This card has navigation tabs in the header created with proper C# methods.");
                        });
                    });
                });
            });

            // ===============================================
            // SECTION 4: Cards with Images
            // ===============================================

            page.Add(new HeaderLevel(HeaderLevelTag.H2, "Cards with Images - Proper Positioning"));

            page.Row(row => {
                // Card with top image
                row.Column(TablerColumnNumber.MediumSixLargeThree, column => {
                    column.Card(card => {
                        card.Image(img => {
                            img.Url("https://picsum.photos/400/200?random=1")
                               .Alt("Top image")
                               .WithPosition(TablerCardImagePosition.Top)
                               .WithSize(TablerCardImageSize.Default);
                        });
                        card.Body(body => {
                            body.Title("Top Image Card");
                            body.Text("Image positioned at the top using C# methods.");
                        });
                    });
                });

                // Card with background
                row.Column(TablerColumnNumber.MediumSixLargeThree, column => {
                    column.Card(card => {
                        card.Background(TablerColor.Azure, isLight: true);
                        card.Body(body => {
                            body.Title("Background Color");
                            body.Text("This card has a light azure background set via C# method.");
                        });
                    });
                });

                // Card with footer
                row.Column(TablerColumnNumber.MediumSixLargeThree, column => {
                    column.Card(card => {
                        card.Body(body => {
                            body.Title("Card with Footer");
                            body.Text("This card has a footer with additional information.");
                        });
                        card.Footer(footer => {
                            footer.SetContent("Footer information created with C# methods");
                        });
                    });
                });

                // Complex multi-feature card
                row.Column(TablerColumnNumber.MediumSixLargeThree, column => {
                    column.Card(card => {
                        card.StatusIndicator("top", TablerColor.Success);
                        card.Ribbon("FEATURED", TablerColor.Purple);
                        card.Stamp(TablerIconType.Star, TablerColor.Yellow);
                        card.Header(header => {
                            header.Title("Premium Features").Subtitle("All-in-one example");
                            header.Avatar(avatar => {
                                avatar.BackgroundColor(TablerColor.Blue).TextColor(TablerColor.White);
                            });
                            header.WithActions(actions => {
                                actions.IconButton(TablerIconType.DotsVertical, btn => btn.AsActionButton());
                            });
                        });
                        card.Body(body => {
                            body.Text("This card demonstrates multiple features combined using only C# methods:");
                            body.AddList(list => {
                                list.WithItems(items => {
                                    items.Item("Status indicator (top, green)");
                                    items.Item("Featured ribbon (purple)");
                                    items.Item("Star stamp (yellow)");
                                    items.Item("Avatar with background");
                                    items.Item("Action menu button");
                                    items.Item("Progress bar below");
                                });
                            });
                        });
                        card.Progress(85, TablerColor.Success);
                    });
                });
            });

            // ===============================================
            // SECTION 5: Summary
            // ===============================================

            page.Add(new HeaderLevel(HeaderLevelTag.H2, "✅ Zero HTML Implementation Complete"));

            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Background(TablerColor.Green, isLight: true);
                        card.Ribbon("COMPLETE", TablerColor.Green);
                        card.Header(header => {
                            header.Title("🎉 Pure C# Card Implementation");
                        });
                        card.Body(body => {
                            body.AddText(text => {
                                text.WithContent("This demo shows the proper way to create Tabler cards using only C# fluent APIs:")
                                    .Weight(TablerFontWeight.Medium)
                                    .Color(TablerColor.Success);
                            });

                            body.AddList(list => {
                                list.Style(TablerCardListStyle.Unstyled);
                                list.WithItems(items => {
                                    items.CheckItem("✅ Zero raw HTML strings", true);
                                    items.CheckItem("✅ Proper fluent C# API", true);
                                    items.CheckItem("✅ Type-safe enums for all options", true);
                                    items.CheckItem("✅ Proper header/body/footer structure", true);
                                    items.CheckItem("✅ Image positioning with enums", true);
                                    items.CheckItem("✅ Navigation tabs and pills", true);
                                    items.CheckItem("✅ Lists with proper styling", true);
                                    items.CheckItem("✅ Text formatting and styling", true);
                                    items.CheckItem("✅ All decorations (ribbons, stamps, progress)", true);
                                    items.CheckItem("✅ Action buttons with proper types", true);
                                });
                            });

                            body.AddText(text => {
                                text.WithContent("No more cheating with raw HTML! This is the HtmlForgeX way! 🎯")
                                    .Style(TablerTextStyle.Muted);
                            });
                        });
                    });
                });
            });
        });

        document.Save("TablerCardsProperDemo.html", openInBrowser);

        Console.WriteLine("🎉 Proper Tabler Cards demo created!");
        Console.WriteLine("✅ Zero raw HTML - Pure C# fluent API");
        Console.WriteLine("🔧 Features demonstrated:");
        Console.WriteLine("   ✅ Proper TablerCardHeader with fluent methods");
        Console.WriteLine("   ✅ Proper TablerCardBody with text and lists");
        Console.WriteLine("   ✅ TablerCardImage with positioning enums");
        Console.WriteLine("   ✅ TablerCardNavigation for tabs and pills");
        Console.WriteLine("   ✅ TablerCardList with proper styling");
        Console.WriteLine("   ✅ TablerCardAction buttons with types");
        Console.WriteLine("   ✅ All decorations using C# methods");
        Console.WriteLine("   ✅ Type-safe enums for everything");
        Console.WriteLine();
        Console.WriteLine("🚀 This is how card components should be built!");
    }
}