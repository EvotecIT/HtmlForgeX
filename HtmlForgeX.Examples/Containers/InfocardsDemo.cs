using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Containers;

/// <summary>
/// Demonstrates colorful info cards with custom RGBColor backgrounds and avatars
/// Inspired by modern dashboard card designs with vibrant colors
/// </summary>
internal class InfocardsDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Infocards Demo - Custom RGBColor Backgrounds & Avatars");

        using var document = new Document {
            Head = {
                Title = "Infocards Demo - Custom Colors",
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
            page.H1("🎨 Infocards Demo");
            page.Text("Beautiful cards with custom RGBColor backgrounds and colorful avatars - Zero HTML, Pure C# API!")
                .Style(TablerTextStyle.Muted).Weight(TablerFontWeight.Medium);

            page.Divider("Colorful Info Cards");

            // First row - Vibrant gradient-like colors
            page.Row(row => {
                // Purple gradient card
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Background("#8B5CF6", "#FFFFFF") // Purple background with white text
                            .Header(header => {
                                header.Title("Total Users").Subtitle("Active members");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.Users)
                                          .BackgroundColor("#A855F7", "#FFFFFF") // Lighter purple avatar
                                          .Size(AvatarSize.MD);
                                });
                            })
                            .Body(body => {
                                body.H2("12,847");
                                body.Text("↗️ +12% from last month");
                            });
                    });
                });

                // Blue gradient card
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Background("#3B82F6", "#FFFFFF") // Blue background
                            .Header(header => {
                                header.Title("Revenue").Subtitle("Monthly earnings");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.CurrencyDollar)
                                          .BackgroundColor("#60A5FA", "#FFFFFF") // Lighter blue avatar
                                          .Size(AvatarSize.MD);
                                });
                            })
                            .Body(body => {
                                body.H2("$45,231");
                                body.Text("↗️ +8% from last month");
                            });
                    });
                });

                // Green gradient card
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Background("#10B981", "#FFFFFF") // Green background
                            .Header(header => {
                                header.Title("Orders").Subtitle("Completed today");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.ShoppingCart)
                                          .BackgroundColor("#34D399", "#FFFFFF") // Lighter green avatar
                                          .Size(AvatarSize.MD);
                                });
                            })
                            .Body(body => {
                                body.H2("1,247");
                                body.Text("↗️ +15% from yesterday");
                            });
                    });
                });

                // Orange gradient card
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Background("#F59E0B", "#FFFFFF") // Orange background
                            .Header(header => {
                                header.Title("Conversion").Subtitle("Success rate");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.TrendingUp)
                                          .BackgroundColor("#FBBF24", "#FFFFFF") // Lighter orange avatar
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

            // Second row - Dark theme cards
            page.Row(row => {
                // Dark purple card
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Background("#1F2937", "#FFFFFF") // Dark gray background
                            .Ribbon("NEW", TablerColor.Purple)
                            .Header(header => {
                                header.Title("Team Performance").Subtitle("Weekly overview");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.Award)
                                          .BackgroundColor("#7C3AED", "#FFFFFF") // Purple avatar
                                          .Size(AvatarSize.LG);
                                });
                            })
                            .Body(body => {
                                body.Text("Our team achieved exceptional results this week with improved collaboration and efficiency.");
                                body.H3("Achievement Unlocked!");
                            });
                    });
                });

                // Teal card with progress
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Background("#0D9488", "#FFFFFF") // Teal background
                            .StatusIndicator("top", TablerColor.Success)
                            .Header(header => {
                                header.Title("Project Alpha").Subtitle("Development progress");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.Rocket)
                                          .BackgroundColor("#14B8A6", "#FFFFFF") // Lighter teal avatar
                                          .Size(AvatarSize.LG);
                                });
                            })
                            .Body(body => {
                                body.Text("Frontend development is progressing smoothly. Backend API integration scheduled for next sprint.");
                                body.H4("Progress: 78%");
                            })
                            .Progress(78, TablerColor.Success);
                    });
                });

                // Pink card with stamp
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Background("#EC4899", "#FFFFFF") // Pink background
                            .Stamp(TablerIconType.Heart, TablerColor.Red)
                            .Header(header => {
                                header.Title("Customer Love").Subtitle("Satisfaction metrics");
                                header.Avatar(avatar => {
                                    avatar.Icon(TablerIconType.Heart)
                                          .BackgroundColor("#F472B6", "#FFFFFF") // Lighter pink avatar
                                          .Size(AvatarSize.LG);
                                });
                            })
                            .Body(body => {
                                body.Text("Customer satisfaction has reached an all-time high with our latest product updates.");
                                body.H3("98.5% Happy");
                            });
                    });
                });
            });

            // Third row - Team member cards with custom avatar colors
            page.Divider("Team Members - Custom Avatar Colors");

            page.Row(row => {
                // Team member 1
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Background("#F8FAFC", "#1F2937") // Light background with dark text
                            .Header(header => {
                                header.Title("Sarah Wilson").Subtitle("Product Manager");
                                header.Avatar(avatar => {
                                    avatar.BackgroundColor("#E11D48", "#FFFFFF") // Rose red avatar
                                          .Icon(TablerIconType.User)
                                          .Size(AvatarSize.LG);
                                });
                            })
                            .Body(body => {
                                body.Text("Leading product strategy and roadmap development for our core platform.");
                                body.Text("📧 sarah@company.com");
                            });
                    });
                });

                // Team member 2
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Background("#F8FAFC", "#1F2937")
                            .Header(header => {
                                header.Title("Alex Chen").Subtitle("Lead Developer");
                                header.Avatar(avatar => {
                                    avatar.BackgroundColor("#7C2D12", "#FFFFFF") // Brown avatar
                                          .Icon(TablerIconType.Code)
                                          .Size(AvatarSize.LG);
                                });
                            })
                            .Body(body => {
                                body.Text("Full-stack developer specializing in React, Node.js, and cloud architecture.");
                                body.Text("📧 alex@company.com");
                            });
                    });
                });

                // Team member 3
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Background("#F8FAFC", "#1F2937")
                            .Header(header => {
                                header.Title("Maria Garcia").Subtitle("UX Designer");
                                header.Avatar(avatar => {
                                    avatar.BackgroundColor("#BE185D", "#FFFFFF") // Pink avatar
                                          .Icon(TablerIconType.Palette)
                                          .Size(AvatarSize.LG);
                                });
                            })
                            .Body(body => {
                                body.Text("Creating intuitive user experiences and beautiful interface designs.");
                                body.Text("📧 maria@company.com");
                            });
                    });
                });

                // Team member 4
                row.Column(TablerColumnNumber.Three, column => {
                    column.Card(card => {
                        card.Background("#F8FAFC", "#1F2937")
                            .Header(header => {
                                header.Title("David Kim").Subtitle("DevOps Engineer");
                                header.Avatar(avatar => {
                                    avatar.BackgroundColor("#059669", "#FFFFFF") // Green avatar
                                          .Icon(TablerIconType.Cloud)
                                          .Size(AvatarSize.LG);
                                });
                            })
                            .Body(body => {
                                body.Text("Managing infrastructure, CI/CD pipelines, and ensuring system reliability.");
                                body.Text("📧 david@company.com");
                            });
                    });
                });
            });

            // Fourth row - Feature showcase with RGBColor objects
            page.Divider("Advanced Features - RGBColor Objects");

            page.Row(row => {
                // Using RGBColor objects directly
                row.Column(TablerColumnNumber.Four, column => {
                    var deepPurple = new RGBColor("#6366F1");
                    var lightPurple = new RGBColor("#A5B4FC");
                    var white = new RGBColor("#FFFFFF");

                    column.Card(card => {
                        card.Background(deepPurple, white)
                            .Ribbon("PREMIUM", TablerColor.Yellow)
                            .Header(header => {
                                header.Title("Premium Analytics").Subtitle("Advanced insights");
                                header.Avatar(avatar => {
                                    avatar.BackgroundColor(lightPurple, white)
                                          .Icon(TablerIconType.ChartPie)
                                          .Size(AvatarSize.LG);
                                });
                            })
                            .Body(body => {
                                body.Text("Unlock powerful analytics with custom RGBColor precision.");
                                body.H4("Color: " + deepPurple.ToString());
                            });
                    });
                });

                // Gradient-like effect with multiple colors
                row.Column(TablerColumnNumber.Four, column => {
                    var emerald = new RGBColor("#10B981");
                    var lightEmerald = new RGBColor("#6EE7B7");

                    column.Card(card => {
                        card.Background(emerald, new RGBColor("#FFFFFF"))
                            .StatusIndicator("top", TablerColor.Success)
                            .Header(header => {
                                header.Title("Eco Dashboard").Subtitle("Sustainability metrics");
                                header.Avatar(avatar => {
                                    avatar.BackgroundColor(lightEmerald, new RGBColor("#065F46"))
                                          .Icon(TablerIconType.Leaf)
                                          .Size(AvatarSize.LG);
                                });
                            })
                            .Body(body => {
                                body.Text("Track environmental impact with precise color coding.");
                                body.H4("RGB: " + emerald.ToString());
                            })
                            .Progress(85, TablerColor.Success);
                    });
                });

                // Custom brand colors
                row.Column(TablerColumnNumber.Four, column => {
                    var brandPrimary = new RGBColor("#FF6B35"); // Custom brand orange
                    var brandSecondary = new RGBColor("#F7931E"); // Lighter orange

                    column.Card(card => {
                        card.Background(brandPrimary, new RGBColor("#FFFFFF"))
                            .Stamp(TablerIconType.Star, TablerColor.Yellow)
                            .Header(header => {
                                header.Title("Brand Colors").Subtitle("Custom palette");
                                header.Avatar(avatar => {
                                    avatar.BackgroundColor(brandSecondary, new RGBColor("#FFFFFF"))
                                          .Icon(TablerIconType.Brush)
                                          .Size(AvatarSize.LG);
                                });
                            })
                            .Body(body => {
                                body.Text("Perfect brand color matching with RGBColor precision.");
                                body.H4("Brand: " + brandPrimary.ToString());
                            });
                    });
                });
            });

            // Summary section
            page.Divider("Summary");

            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Background("#F1F5F9", "#334155") // Light gray background
                            .Header(header => {
                                header.Title("🎨 RGBColor Features Summary");
                                header.Avatar(avatar => {
                                    avatar.BackgroundColor("#8B5CF6", "#FFFFFF")
                                          .Icon(TablerIconType.Palette)
                                          .Size(AvatarSize.XL);
                                });
                            })
                            .Body(body => {
                                body.Text("This demo showcases the new RGBColor functionality in HtmlForgeX:");

                                body.AddList(list => {
                                    list.Style(TablerCardListStyle.Unstyled);
                                    list.WithItems(items => {
                                        items.CheckItem("✅ Custom card backgrounds using hex colors (#FF6B35)", true);
                                        items.CheckItem("✅ Custom avatar colors with RGBColor objects", true);
                                        items.CheckItem("✅ Precise color control for brand consistency", true);
                                        items.CheckItem("✅ Support for both hex strings and RGBColor objects", true);
                                        items.CheckItem("✅ Automatic text color optimization", true);
                                        items.CheckItem("✅ Zero HTML/CSS - Pure fluent C# API", true);
                                    });
                                });

                                body.Text("All cards maintain full Tabler functionality (ribbons, stamps, progress bars, etc.) while adding custom color precision!");
                            });
                    });
                });
            });
        });

        document.Save("InfocardsDemo.html", openInBrowser);

        HelpersSpectre.Success("🎨 Infocards Demo created successfully!");
        HelpersSpectre.Success("✨ Features demonstrated:");
        HelpersSpectre.Success("   🎯 Custom RGBColor backgrounds for cards");
        HelpersSpectre.Success("   🎨 Custom avatar colors with hex strings");
        HelpersSpectre.Success("   🌈 RGBColor object support");
        HelpersSpectre.Success("   📱 Responsive colorful card layouts");
        HelpersSpectre.Success("   🚀 Zero HTML - Pure C# fluent API");
        HelpersSpectre.Success("");
        HelpersSpectre.Success("🔧 New API methods added:");
        HelpersSpectre.Success("   • card.Background(\"#FF6B35\", \"#FFFFFF\")");
        HelpersSpectre.Success("   • card.Background(rgbColor, textColor)");
        HelpersSpectre.Success("   • avatar.BackgroundColor(\"#8B5CF6\", \"#FFFFFF\")");
        HelpersSpectre.Success("   • avatar.BackgroundColor(rgbColor, textColor)");
    }
}