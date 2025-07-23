using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Containers;

/// <summary>
/// Demonstrates colorful info cards using predefined RGBColor constants
/// Shows the clean approach: RGBColor.White, RGBColor.Red instead of hex strings
/// </summary>
internal class InfocardsCleanDemo {
    public static void Demo01(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Clean Infocards Demo - Predefined RGBColor Constants");

        using var document = new Document {
            Head = {
                Title = "Clean Infocards Demo - RGBColor Constants",
                Author = "HtmlForgeX",
                Revised = DateTime.Now,
                AutoRefresh = 30
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;

            // Header section
            page.H1("🎨 Clean RGBColor Demo");
            page.Text("Beautiful cards using predefined RGBColor constants - No more cryptic hex numbers!")
                .Style(TablerTextStyle.Muted).Weight(TablerFontWeight.Medium);

            page.Divider("Clean Color Usage Examples");

            // First row - Using predefined color constants
            page.Row(row => {
                // Purple card with clean constants
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Background(RGBColor.Purple, RGBColor.White) // Clean and readable!
                            .Header(header => {
                                header.Title("Total Users").Subtitle("Active members");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.Users)
                                          .BackgroundColor(RGBColor.Amethyst, RGBColor.White) // Descriptive color names
                                          .Size(AvatarSize.MD);
                                });
                            })
                            .Body(body => {
                                body.H2("12,847");
                                body.Text("↗️ +12% from last month");
                            });
                    });
                });

                // Blue card with clean constants
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Background(RGBColor.RoyalBlue, RGBColor.White) // Much clearer than #3B82F6!
                            .Header(header => {
                                header.Title("Revenue").Subtitle("Monthly earnings");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.CurrencyDollar)
                                          .BackgroundColor(RGBColor.CornflowerBlue, RGBColor.White)
                                          .Size(AvatarSize.MD);
                                });
                            })
                            .Body(body => {
                                body.H2("$45,231");
                                body.Text("↗️ +8% from last month");
                            });
                    });
                });

                // Green card with clean constants
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Background(RGBColor.ForestGreen, RGBColor.White) // Self-documenting!
                            .Header(header => {
                                header.Title("Orders").Subtitle("Completed today");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.ShoppingCart)
                                          .BackgroundColor(RGBColor.MediumSeaGreen, RGBColor.White)
                                          .Size(AvatarSize.MD);
                                });
                            })
                            .Body(body => {
                                body.H2("1,247");
                                body.Text("↗️ +15% from yesterday");
                            });
                    });
                });

                // Orange card with clean constants
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Background(RGBColor.Orange, RGBColor.White) // No more guessing colors!
                            .Header(header => {
                                header.Title("Conversion").Subtitle("Success rate");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.TrendingUp)
                                          .BackgroundColor(RGBColor.LightGold, RGBColor.White)
                                          .Size(AvatarSize.MD);
                                });
                            })
                            .Body(body => {
                                body.H2("94.2%");
                                body.Text("↗️ +2.1% improvement");
                            });
                    });
                });
            });

            // Second row - More vibrant colors
            page.Row(row => {
                // Crimson card
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Background(RGBColor.Crimson, RGBColor.White)
                            .Ribbon("HOT", TablerColor.Red)
                            .Header(header => {
                                header.Title("Hot Products").Subtitle("Trending now");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.Flame)
                                          .BackgroundColor(RGBColor.Red, RGBColor.White)
                                          .Size(AvatarSize.LG);
                                });
                            })
                            .Body(body => {
                                body.Text("These products are flying off the shelves!");
                                body.H3("🔥 Trending");
                            });
                    });
                });

                // Teal card
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Background(RGBColor.Teal, RGBColor.White)
                            .StatusIndicator("top", TablerColor.Success)
                            .Header(header => {
                                header.Title("Project Status").Subtitle("All systems go");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.Check)
                                          .BackgroundColor(RGBColor.LightSeaGreen, RGBColor.White)
                                          .Size(AvatarSize.LG);
                                });
                            })
                            .Body(body => {
                                body.Text("Everything is running smoothly across all environments.");
                                body.H4("✅ Healthy");
                            })
                            .Progress(95, TablerColor.Success);
                    });
                });

                // Deep Pink card
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Background(RGBColor.DeepPink, RGBColor.White)
                            .Stamp(TablerIconType.Heart, TablerColor.Pink)
                            .Header(header => {
                                header.Title("Customer Love").Subtitle("Satisfaction score");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.Heart)
                                          .BackgroundColor(RGBColor.HotPink, RGBColor.White)
                                          .Size(AvatarSize.LG);
                                });
                            })
                            .Body(body => {
                                body.Text("Our customers absolutely love the new features!");
                                body.H3("💖 Amazing");
                            });
                    });
                });
            });

            // Third row - Professional colors
            page.Row(row => {
                // Navy blue professional card
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Background(RGBColor.NavyBlue, RGBColor.White)
                            .Header(header => {
                                header.Title("Enterprise Dashboard").Subtitle("Professional analytics");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.ChartBar)
                                          .BackgroundColor(RGBColor.SteelBlue, RGBColor.White)
                                          .Size(AvatarSize.XL);
                                });
                            })
                            .Body(body => {
                                body.Text("Professional-grade analytics with clean, readable color constants.");
                                body.Text("No more wondering what #1F2937 looks like!");
                                body.H4("RGBColor.Navy = Professional");
                            });
                    });
                });

                // Coral card
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Background(RGBColor.Coral, RGBColor.White)
                            .Header(header => {
                                header.Title("Creative Projects").Subtitle("Design inspiration");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.Palette)
                                          .BackgroundColor(RGBColor.LightCoral, RGBColor.White)
                                          .Size(AvatarSize.XL);
                                });
                            })
                            .Body(body => {
                                body.Text("Creative projects benefit from descriptive color names.");
                                body.Text("RGBColor.Coral is much clearer than #FF7F50!");
                                body.H4("🎨 Self-Documenting");
                            });
                    });
                });
            });

            // Comparison section
            page.Divider("Before vs After Comparison");

            page.Row(row => {
                // Before - cryptic hex
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Background(RGBColor.LightGray, RGBColor.Black)
                            .Header(header => {
                                header.Title("❌ Before: Cryptic Hex").Subtitle("Hard to understand");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.QuestionMark)
                                          .BackgroundColor(RGBColor.Gray, RGBColor.White)
                                          .Size(AvatarSize.LG);
                                });
                            })
                            .Body(body => {
                                body.Text("Old way with hex strings:");
                                body.H5("card.Background(\"#8B5CF6\", \"#FFFFFF\")");
                                body.Text("What color is #8B5CF6? 🤔");
                                body.Text("Hard to remember, hard to maintain!");
                            });
                    });
                });

                // After - clean constants
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Background(RGBColor.LightGreen, RGBColor.DarkGreen)
                            .Header(header => {
                                header.Title("✅ After: Clean Constants").Subtitle("Self-documenting");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.Check)
                                          .BackgroundColor(RGBColor.Green, RGBColor.White)
                                          .Size(AvatarSize.LG);
                                });
                            })
                            .Body(body => {
                                body.Text("New way with predefined constants:");
                                body.H5("card.Background(RGBColor.Purple, RGBColor.White)");
                                body.Text("Crystal clear! 🎯");
                                body.Text("Easy to read, easy to maintain!");
                            });
                    });
                });
            });

            // Summary section
            page.Divider("Available Color Constants");

            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Background(RGBColor.AliceBlue, RGBColor.DarkSlateGray)
                            .Header(header => {
                                header.Title("🌈 800+ Predefined Colors Available");
                                header.Avatar(avatar => {
                                    avatar.BackgroundColor(RGBColor.Violet, RGBColor.White)
                                          .Icon(TablerIconType.Palette)
                                          .Size(AvatarSize.XL);
                                });
                            })
                            .Body(body => {
                                body.Text("HtmlForgeX includes over 800 predefined color constants:");

                                body.AddList(list => {
                                    list.Style(TablerCardListStyle.Unstyled);
                                    list.WithItems(items => {
                                        items.CheckItem("🔴 Basic Colors: RGBColor.Red, RGBColor.Blue, RGBColor.Green", true);
                                        items.CheckItem("🎨 Named Colors: RGBColor.Crimson, RGBColor.Turquoise, RGBColor.Coral", true);
                                        items.CheckItem("💼 Professional: RGBColor.Navy, RGBColor.SteelBlue, RGBColor.SlateGray", true);
                                        items.CheckItem("🌈 Creative: RGBColor.Amethyst, RGBColor.Periwinkle, RGBColor.Lavender", true);
                                        items.CheckItem("✨ Self-documenting code - no more hex guessing!", true);
                                        items.CheckItem("🚀 IntelliSense support for all color names", true);
                                    });
                                });

                                body.Text("Benefits of using predefined constants:");
                                body.Text("• Code is self-documenting and easier to read");
                                body.Text("• No need to remember hex values");
                                body.Text("• IntelliSense helps you find the perfect color");
                                body.Text("• Consistent color usage across your application");
                            });
                    });
                });
            });
        });

        document.Save("InfocardsCleanDemo.html", openInBrowser);

        HelpersSpectre.Success("🎨 Clean Infocards Demo created successfully!");
        HelpersSpectre.Success("✨ Features demonstrated:");
        HelpersSpectre.Success("   🎯 Predefined RGBColor constants (RGBColor.Purple, RGBColor.White)");
        HelpersSpectre.Success("   📖 Self-documenting color usage");
        HelpersSpectre.Success("   🚀 No more cryptic hex numbers!");
        HelpersSpectre.Success("   🌈 Over 800 available color constants");
        HelpersSpectre.Success("");
        HelpersSpectre.Success("🔧 Clean API usage:");
        HelpersSpectre.Success("   • card.Background(RGBColor.Purple, RGBColor.White)");
        HelpersSpectre.Success("   • avatar.BackgroundColor(RGBColor.Crimson, RGBColor.White)");
        HelpersSpectre.Success("   • Much cleaner than hex strings!");
    }
}