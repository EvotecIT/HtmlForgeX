using System;
using System.Collections.Generic;

namespace HtmlForgeX.Examples.Containers;

/// <summary>
/// Comprehensive demonstration of the enhanced TablerDataGrid component showcasing
/// all features from the Tabler datagrid.html example using pure C# fluent API.
/// </summary>
internal class EnhancedDataGridDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Enhanced DataGrid - Complete Feature Demonstration");

        using var document = new Document {
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Head.Title = "Enhanced DataGrid - Complete Feature Demo";
        document.Head.Author = "HtmlForgeX";
        document.Head.Revised = DateTime.Now;

        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;

            // Header
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.H1("Enhanced DataGrid Component");
                    column.Text("Complete recreation of Tabler's datagrid.html features using pure C# fluent API - zero HTML knowledge required!")
                        .Style(TablerTextStyle.Muted);
                });
            });

            // ===============================================
            // SECTION 1: Basic DataGrid Features
            // ===============================================

            page.H2("Section 1: Basic DataGrid Features");

            page.Row(row => {
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Simple Key-Value Pairs");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                dataGrid.AddItem("Registrar", "Third Party");
                                dataGrid.AddItem("Nameservers", "Third Party");
                                dataGrid.AddItem("Port number", "3306");
                                dataGrid.AddItem("Expiration date", "–");
                                dataGrid.AddItem("Age", "15 days");
                            });
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Badge Content Types");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                dataGrid.AddBadgeItem("Status", "Active", TablerColor.Success);
                                dataGrid.AddBadgeItem("Priority", "High", TablerColor.Danger);
                                dataGrid.AddBadgeItem("Type", "Premium", TablerColor.Primary);
                                dataGrid.AddBadgeItem("Category", "Important", TablerColor.Warning);
                                dataGrid.AddBadgeItem("Version", "v2.1.0", TablerColor.Info);
                            });
                        });
                    });
                });
            });

            // ===============================================
            // SECTION 2: Advanced Content Types
            // ===============================================

            page.H2("Section 2: Advanced Content Types");

            page.Row(row => {
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Avatar & User Content");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                // Single avatar with user info
                                dataGrid.AddAvatarItem("Creator", "Paweł Kuna", avatar => {
                                    avatar.Image("https://picsum.photos/100/100?random=100");
                                });

                                // Avatar with initials
                                dataGrid.AddAvatarItem("Administrator", "Admin User", avatar => {
                                    avatar.BackgroundColor(TablerColor.Blue).TextColor(TablerColor.White);
                                });

                                // Avatar list (team members)
                                dataGrid.AddAvatarListItem("Team Members",
                                    avatar => avatar.Image("https://picsum.photos/100/100?random=101"),
                                    avatar => avatar.Image("https://picsum.photos/100/100?random=102"),
                                    avatar => avatar.Image("https://picsum.photos/100/100?random=103"),
                                    avatar => avatar.Image("https://picsum.photos/100/100?random=104"),
                                    avatar => avatar.Image("https://picsum.photos/100/100?random=105")
                                );
                            });
                        });
                    });
                });

                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Icon & Status Content");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                // Icons with text and colors
                                dataGrid.AddIconItem("Security", TablerIconType.Shield, "Enabled", TablerColor.Green);
                                dataGrid.AddIconItem("Backup", TablerIconType.Database, "Daily", TablerColor.Blue);
                                dataGrid.AddIconItem("Monitoring", TablerIconType.Activity, "Active", TablerColor.Success);

                                // Status indicators
                                dataGrid.AddStatusItem("Edge network", "Active", TablerColor.Success);
                                dataGrid.AddStatusItem("CDN Status", "Operational", TablerColor.Success);
                                dataGrid.AddStatusItem("SSL Certificate", "Valid", TablerColor.Success);
                            });
                        });
                    });
                });

                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Interactive Elements");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                // Checkboxes
                                dataGrid.AddCheckboxItem("Auto Renewal", true, "Enable automatic renewal");
                                dataGrid.AddCheckboxItem("Email Notifications", false, "Send alerts via email");
                                dataGrid.AddCheckboxItem("SMS Alerts", true, "Send SMS notifications");

                                // Form controls
                                dataGrid.AddFormControlItem("Timeout", "number", "Seconds", "30");
                                dataGrid.AddFormControlItem("API Endpoint", "url", "Enter API URL");
                            });
                        });
                    });
                });
            });

            // ===============================================
            // SECTION 3: Layout & Spacing Configuration
            // ===============================================

            page.H2("Section 3: Layout & Spacing Configuration");

            page.Row(row => {
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Compact Layout");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                dataGrid.AsCompact();

                                dataGrid.AddBadgeItem("CPU", "45%", TablerColor.Warning);
                                dataGrid.AddBadgeItem("Memory", "67%", TablerColor.Info);
                                dataGrid.AddBadgeItem("Disk", "23%", TablerColor.Success);
                                dataGrid.AddBadgeItem("Network", "12 Mbps", TablerColor.Primary);
                                dataGrid.AddStatusItem("Health", "Good", TablerColor.Success);
                            });
                        });
                    });
                });

                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Spacious Layout");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                dataGrid.AsSpacious()
                                       .WithWideTitles();

                                dataGrid.AddAvatarItem("Project Manager", "Sarah Wilson", avatar => {
                                    avatar.Image("https://picsum.photos/100/100?random=200");
                                });
                                dataGrid.AddIconItem("Last Activity", TablerIconType.Clock, "2 hours ago", TablerColor.Gray500);
                                dataGrid.AddStatusItem("Project Status", "On Track", TablerColor.Success);
                            });
                        });
                    });
                });

                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Custom Spacing");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                dataGrid.WithCustomSpacing("20px")
                                       .WithCustomDefaultTitleWidth("180px")
                                       .WithMargin(TablerMargin.AllNormal);

                                dataGrid.AddIconItem("Environment", TablerIconType.Server, "Production", TablerColor.Red);
                                dataGrid.AddBadgeItem("Build Version", "v3.2.1", TablerColor.Primary);
                                dataGrid.AddStatusItem("Deployment", "Successful", TablerColor.Success);
                            });
                        });
                    });
                });
            });

            // ===============================================
            // SECTION 4: Responsive Behavior
            // ===============================================

            page.H2("Section 4: Responsive Behavior");

            page.Row(row => {
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Mobile Responsive");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                dataGrid.AsMobileResponsive()
                                       .WithNarrowTitles();

                                dataGrid.AddAvatarItem("Mobile User", "John Mobile", avatar => {
                                    avatar.Image("https://picsum.photos/100/100?random=300");
                                });
                                dataGrid.AddBadgeItem("Device Type", "Smartphone", TablerColor.Info);
                                dataGrid.AddIconItem("Connection", TablerIconType.Wifi, "4G LTE", TablerColor.Green);
                                dataGrid.AddStatusItem("App Version", "v2.0.1", TablerColor.Success);
                                dataGrid.AddCheckboxItem("Push Notifications", true, "Enable mobile alerts");
                            });
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Fully Responsive");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                dataGrid.AsFullyResponsive()
                                       .WithSpacing(TablerDataGridSpacing.Large);

                                dataGrid.AddAvatarListItem("Development Team",
                                    avatar => avatar.Image("https://picsum.photos/100/100?random=401"),
                                    avatar => avatar.Image("https://picsum.photos/100/100?random=402"),
                                    avatar => avatar.Image("https://picsum.photos/100/100?random=403")
                                );
                                dataGrid.AddFormControlItem("Screen Resolution", "text", "e.g., 1920x1080", "Auto-detect");
                                dataGrid.AddIconItem("Browser Support", TablerIconType.Browser, "Modern browsers", TablerColor.Blue);
                            });
                        });
                    });
                });
            });

            // ===============================================
            // SECTION 5: Advanced Customization
            // ===============================================

            page.H2("Section 5: Advanced Customization");

            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Highly Customized DataGrid");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                dataGrid.WithLayout(TablerDataGridLayout.Horizontal)
                                       .WithCustomStyle("border: 2px solid #0066cc; border-radius: 12px; padding: 20px; background: linear-gradient(135deg, #f8f9fa 0%, #e9ecef 100%);")
                                       .WithPadding(TablerPadding.AllNormal)
                                       .WithMargin(TablerMargin.AllNormal);

                                // Highly customized individual items
                                dataGrid.AddItem(item => {
                                    item.Title("Custom Item 1")
                                        .AvatarContent("Custom User", avatar => {
                                            avatar.Image("https://picsum.photos/100/100?random=500")
                                                  .Size(AvatarSize.MD);
                                        })
                                        .WithSpacing(TablerDataGridSpacing.ExtraLarge)
                                        .WithContentAlignment(TablerDataGridContentAlignment.Center)
                                        .WithTitleWidth(TablerDataGridTitleWidth.ExtraWide)
                                        .WithCustomStyle("font-weight: bold; color: #0066cc;");
                                });

                                dataGrid.AddItem(item => {
                                    item.Title("Custom Item 2")
                                        .IconContent(TablerIconType.Star, "Premium Feature", TablerColor.Yellow)
                                        .WithContentAlignment(TablerDataGridContentAlignment.Right)
                                        .WithCustomTitleWidth("200px");
                                });

                                dataGrid.AddItem(item => {
                                    item.Title("Interactive Element")
                                        .CheckboxContent(true, "Enable advanced features")
                                        .WithSpacing(TablerDataGridSpacing.Small)
                                        .WithMargin(TablerMargin.TopNormal);
                                });
                            });
                        });
                    });
                });
            });

            // ===============================================
            // SECTION 6: Real-World Example
            // ===============================================

            page.H2("Section 6: Real-World Server Dashboard");

            page.Row(row => {
                row.Column(TablerColumnNumber.Eight, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Server Information");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                dataGrid.WithSpacing(TablerDataGridSpacing.Medium)
                                       .AsMobileResponsive();

                                // Server basics
                                dataGrid.AddItem("Hostname", "web-server-01.company.com");
                                dataGrid.AddBadgeItem("Environment", "Production", TablerColor.Danger);
                                dataGrid.AddStatusItem("Status", "Running", TablerColor.Success);
                                dataGrid.AddIconItem("Operating System", TablerIconType.BrandUbuntu, "Ubuntu 22.04 LTS", TablerColor.Orange);

                                // Performance metrics
                                dataGrid.AddBadgeItem("CPU Usage", "34%", TablerColor.Info);
                                dataGrid.AddBadgeItem("Memory Usage", "67%", TablerColor.Warning);
                                dataGrid.AddBadgeItem("Disk Usage", "45%", TablerColor.Success);
                                dataGrid.AddIconItem("Network", TablerIconType.Network, "1 Gbps", TablerColor.Green);

                                // Management info
                                dataGrid.AddAvatarItem("System Administrator", "DevOps Team", avatar => {
                                    avatar.BackgroundColor(TablerColor.Purple).TextColor(TablerColor.White);
                                });
                                dataGrid.AddIconItem("Last Reboot", TablerIconType.RotateClockwise, "3 days ago", TablerColor.Gray500);
                                dataGrid.AddIconItem("Uptime", TablerIconType.Clock, "99.9% (30 days)", TablerColor.Green);

                                // Configuration
                                dataGrid.AddCheckboxItem("Auto Updates", true, "Enable automatic security updates");
                                dataGrid.AddCheckboxItem("Monitoring", true, "Enable 24/7 monitoring");
                                dataGrid.AddFormControlItem("Backup Frequency", "select", "Daily", "daily");
                            });
                        });
                    });
                });

                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Quick Actions");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                dataGrid.AsCompact()
                                       .WithNarrowTitles();

                                dataGrid.AddIconItem("Restart", TablerIconType.RotateClockwise, "Available", TablerColor.Orange);
                                dataGrid.AddIconItem("Backup", TablerIconType.Database, "Schedule", TablerColor.Blue);
                                dataGrid.AddIconItem("Logs", TablerIconType.FileText, "View", TablerColor.Gray500);
                                dataGrid.AddIconItem("Terminal", TablerIconType.Terminal2, "SSH Access", TablerColor.Green);
                                dataGrid.AddIconItem("Settings", TablerIconType.Settings, "Configure", TablerColor.Purple);
                            });
                        });
                    });
                });
            });

            // Summary
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Background(TablerColor.Azure, isLight: true);
                        card.Header(header => {
                            header.Title("🎉 Complete Enhanced DataGrid Implementation");
                        });
                        card.Body(body => {
                            body.AddText(text => {
                                text.WithContent("This demonstration showcases ALL enhanced DataGrid features using ONLY C# fluent APIs:")
                                    .Weight(TablerFontWeight.Medium)
                                    .Color(TablerColor.Primary);
                            });

                            body.AddList(list => {
                                list.Title("✅ Content Types:");
                                list.Style(TablerCardListStyle.Unstyled);
                                list.WithItems(items => {
                                    items.Item("• Simple text content");
                                    items.Item("• Badge content with colors and styles");
                                    items.Item("• Status indicators with semantic colors");
                                    items.Item("• Avatar content (single and lists)");
                                    items.Item("• Icon content with text and colors");
                                    items.Item("• Interactive checkboxes with labels");
                                    items.Item("• Form controls (inputs) with validation");
                                    items.Item("• Custom HTML content for advanced scenarios");
                                });
                            });

                            body.AddList(list => {
                                list.Title("🎛️ Configuration Options:");
                                list.Style(TablerCardListStyle.Unstyled);
                                list.WithItems(items => {
                                    items.Item("• Layout styles (Default, Compact, Spacious, Horizontal)");
                                    items.Item("• Spacing configuration (None to ExtraLarge + Custom)");
                                    items.Item("• Responsive behavior (Mobile, Tablet, Always, Custom)");
                                    items.Item("• Title width control (Auto to ExtraWide + Custom)");
                                    items.Item("• Content alignment (Left, Center, Right, Justified)");
                                    items.Item("• Tabler margin and padding utilities");
                                    items.Item("• Custom CSS styles and classes");
                                    items.Item("• Convenience methods (AsCompact, AsSpacious, etc.)");
                                });
                            });

                            body.AddText(text => {
                                text.WithContent("🚀 Zero HTML/CSS/JS Knowledge Required!")
                                    .Strong()
                                    .Color(TablerColor.Success);
                            });

                            body.AddText(text => {
                                text.WithContent("This enhanced DataGrid component provides the complete feature set of Tabler's datagrid.html using only intuitive C# methods. Perfect for developers who want powerful web UIs without web development expertise!")
                                    .Style(TablerTextStyle.Muted);
                            });
                        });
                    });
                });
            });
        });

        document.Save("EnhancedDataGridDemo.html", openInBrowser);

        Console.WriteLine("🎉 Enhanced DataGrid demo created successfully!");
        Console.WriteLine("📋 Complete feature set demonstrated:");
        Console.WriteLine("   ✅ All content types (text, badges, avatars, icons, forms)");
        Console.WriteLine("   ✅ Layout configurations (compact, spacious, horizontal)");
        Console.WriteLine("   ✅ Spacing control (predefined + custom)");
        Console.WriteLine("   ✅ Responsive behavior for all screen sizes");
        Console.WriteLine("   ✅ Advanced customization options");
        Console.WriteLine("   ✅ Real-world server dashboard example");
        Console.WriteLine("   ✅ Zero HTML exposure - Pure C# fluent API!");
        Console.WriteLine("");
        Console.WriteLine("🎯 Perfect for HTML-challenged developers who want powerful web UIs!");
    }
}