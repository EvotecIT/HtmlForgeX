using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Containers;
internal class DomainHealthCheck {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Enhanced Domain Health Check with Advanced DataGrid Features");

        // Create sample data for enhanced demonstration
        var data = new List<dynamic> {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
            new { Name = "Bob", Age = 35, Occupation = "Architect" }
        };

        // Placeholder for logs data - not used in current implementation
        /*
        var logs =
            """
            Effective URL            https://evotec.xyz
            Redirect count           0
            Name lookup time         3.4e-05
            Connect time             0.000521
            Pre-transfer time        0.0
            Start-transfer time      0.0
            App connect time         0.0
            Redirect time            0.0
            Total time               28.000601
            Response code            0
            Return keyword           operation_timedout
            """;
        */

        using var document = new Document {
            Head = {
                Title = "Enhanced Domain Health Check",
                Author = "Przemysław Kłys",
                Revised = DateTime.Now
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.Layout = TablerLayout.Boxed;

            // Main Security Rating Card with Enhanced DataGrid
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Row(cardTitle => {
                            cardTitle.HeaderLevel(HeaderLevelTag.H4, "Security Rating").Class("card-title");
                        });

                        card.Row(cardRow => {
                            // Security Icon Column
                            cardRow.Column(TablerColumnNumber.Three, textColumn => {
                                textColumn.Add(new TablerIconElement(TablerIconType.BasketCheck)
                                    .FontSize(115)
                                    .Color(RGBColor.LightGreen));
                            });

                            // Enhanced OUTBOUND EMAIL Section
                            cardRow.Column(TablerColumnNumber.Three, textColumn => {
                                textColumn.HeaderLevel(HeaderLevelTag.H4, "OUTBOUND EMAIL").Class("card-title");
                                textColumn.DataGrid(dataGrid => {
                                    dataGrid.WithLayout(TablerDataGridLayout.Compact)
                                           .WithSpacing(TablerDataGridSpacing.Small)
                                           .WithNarrowTitles();

                                    // SPF with badge
                                    dataGrid.AddBadgeItem("SPF", "soft fail", TablerColor.Green);

                                    // DKIM with status
                                    dataGrid.AddStatusItem("DKIM", "yes, 2 selectors known", TablerColor.Success);

                                    // DMARC with badge
                                    dataGrid.AddBadgeItem("DMARC", "reject", TablerColor.GreenLight);

                                    // BIMI with status
                                    dataGrid.AddStatusItem("BIMI", "yes, 1 selector is known", TablerColor.Success);
                                });
                            });

                            // Enhanced INBOUND EMAIL Section
                            cardRow.Column(TablerColumnNumber.Three, textColumn => {
                                textColumn.HeaderLevel(HeaderLevelTag.H4, "INBOUND EMAIL").Class("card-title");
                                textColumn.DataGrid(dataGrid => {
                                    dataGrid.WithLayout(TablerDataGridLayout.Compact)
                                           .WithSpacing(TablerDataGridSpacing.Small)
                                           .WithNarrowTitles();

                                    // TLS with badge
                                    dataGrid.AddBadgeItem("TLS (STARTTLS)", "supported by all MX", TablerColor.Green, TablerBadgeStyle.Normal);

                                    // MTA-STS with simple text
                                    dataGrid.AddItem("MTA-STS", "enforce");

                                    // TLSA with icon and color
                                    dataGrid.AddIconItem("TLSA (DANE)", TablerIconType.X, "no", TablerColor.Red);

                                    // TLS reporting with status
                                    dataGrid.AddStatusItem("TLS REPORTING", "yes", TablerColor.Success);
                                });
                            });

                            // Enhanced DOMAIN Section with Advanced Features
                            cardRow.Column(TablerColumnNumber.Three, textColumn => {
                                textColumn.HeaderLevel(HeaderLevelTag.H4, "DOMAIN").Class("card-title");
                                textColumn.DataGrid(dataGrid => {
                                    dataGrid.WithLayout(TablerDataGridLayout.Default)
                                           .WithSpacing(TablerDataGridSpacing.Medium)
                                           .AsMobileResponsive();

                                    // Domain name with simple text
                                    dataGrid.AddItem("NAME", "evotec.xyz");

                                    // DNSSEC with icon
                                    dataGrid.AddIconItem("DNSSEC", TablerIconType.Check, "yes", TablerColor.Green);

                                    // Monitoring with badge
                                    dataGrid.AddBadgeItem("MONITORING", "yes", TablerColor.GreenLight);

                                    // Status with dismissible tag (using HTML content for advanced feature)
                                    dataGrid.Title("STATUS").HtmlContent(@"<span class=""badge bg-lime text-lime-fg"">Active</span>");
                                });
                            });
                        });
                    });
                });
            });

            // Advanced DataGrid Features Demonstration
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Advanced DataGrid Features");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                dataGrid.AsSpacious()
                                       .WithWideTitles()
                                       .AsFullyResponsive()
                                       .WithMargin(TablerMargin.AllNormal);

                                // Avatar with user info
                                dataGrid.AddAvatarItem("Creator", "Paweł Kuna", avatar => {
                                    avatar.Image("https://picsum.photos/100/100?random=100");
                                });

                                // Checkbox example
                                dataGrid.AddCheckboxItem("Enable Alerts", true, "Send notifications");

                                // Form control example
                                dataGrid.AddFormControlItem("Port Number", "number", "Enter port", "3306");

                                // Avatar list example
                                dataGrid.AddAvatarListItem("Team Members",
                                    avatar => avatar.Image("https://picsum.photos/100/100?random=101"),
                                    avatar => avatar.Image("https://picsum.photos/100/100?random=102"),
                                    avatar => avatar.Image("https://picsum.photos/100/100?random=103")
                                );

                                // Complex configuration example
                                dataGrid.AddItem(item => {
                                    item.Title("Custom Configured Item")
                                        .IconContent(TablerIconType.Settings, "Advanced Settings", TablerColor.Blue)
                                        .WithSpacing(TablerDataGridSpacing.Large)
                                        .WithContentAlignment(TablerDataGridContentAlignment.Center)
                                        .WithTitleWidth(TablerDataGridTitleWidth.Wide);
                                });
                            });
                        });
                    });
                });

                // Compact DataGrid Example
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Compact System Status");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                dataGrid.AsCompact()
                                       .WithCustomSpacing("4px")
                                       .WithDefaultTitleWidth(TablerDataGridTitleWidth.Narrow);

                                // System metrics with various content types
                                dataGrid.AddStatusItem("CPU Usage", "45%", TablerColor.Warning);
                                dataGrid.AddStatusItem("Memory", "78%", TablerColor.Danger);
                                dataGrid.AddStatusItem("Disk Space", "34%", TablerColor.Success);
                                dataGrid.AddIconItem("Network", TablerIconType.Wifi, "Connected", TablerColor.Green);
                                dataGrid.AddBadgeItem("Uptime", "15 days", TablerColor.Blue);

                                // Interactive elements
                                dataGrid.AddCheckboxItem("Auto Backup", false, "Enable automatic backups");
                                dataGrid.AddFormControlItem("Refresh Rate", "number", "Seconds", "30");
                            });
                        });
                    });
                });
            });

            // Responsive and Layout Demonstrations
            page.Row(row => {
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Horizontal Layout");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                dataGrid.WithLayout(TablerDataGridLayout.Horizontal)
                                       .WithPadding(TablerPadding.AllNormal);

                                dataGrid.AddBadgeItem("Version", "v2.1.3", TablerColor.Primary);
                                dataGrid.AddStatusItem("Build", "Stable", TablerColor.Success);
                                dataGrid.AddIconItem("License", TablerIconType.Certificate, "MIT", TablerColor.Blue);
                            });
                        });
                    });
                });

                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Custom Styled");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                dataGrid.WithCustomStyle("border: 2px solid #e9ecef; border-radius: 8px; padding: 16px;")
                                       .WithSpacing(TablerDataGridSpacing.ExtraLarge);

                                dataGrid.AddItem("Environment", "Production")
                                       .WithCustomStyle("font-weight: bold; color: #d63384;");
                                dataGrid.AddItem("Region", "US-East-1")
                                       .WithContentAlignment(TablerDataGridContentAlignment.Right);
                                dataGrid.AddBadgeItem("Health", "Excellent", TablerColor.Success);
                            });
                        });
                    });
                });

                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Mixed Content Types");
                        });
                        card.Body(body => {
                            body.DataGrid(dataGrid => {
                                dataGrid.WithMargin(TablerMargin.VerticalNormal);

                                // Mix different content types
                                dataGrid.AddAvatarItem("Administrator", "Admin User", avatar => {
                                    avatar.BackgroundColor(TablerColor.Blue).TextColor(TablerColor.White);
                                });

                                dataGrid.AddIconItem("Last Updated", TablerIconType.Clock, "2 hours ago", TablerColor.Gray500);

                                dataGrid.AddItem(item => {
                                    item.Title("Configuration")
                                        .CheckboxContent(true, "Production Mode")
                                        .WithTitleWidth(TablerDataGridTitleWidth.Medium);
                                });

                                dataGrid.AddFormControlItem("API Key", "password", "Enter your API key");
                            });
                        });
                    });
                });
            });
        });

        document.Save("DomainHealthCheck.html", openInBrowser);

        HelpersSpectre.Success("🎉 Enhanced Domain Health Check created with advanced DataGrid features!");
        HelpersSpectre.Success("📋 Features demonstrated:");
        HelpersSpectre.Success("   ✅ Badge content with various colors and styles");
        HelpersSpectre.Success("   ✅ Status indicators with semantic colors");
        HelpersSpectre.Success("   ✅ Avatar integration with user information");
        HelpersSpectre.Success("   ✅ Icon content with text and colors");
        HelpersSpectre.Success("   ✅ Checkbox and form control elements");
        HelpersSpectre.Success("   ✅ Configurable spacing and layout options");
        HelpersSpectre.Success("   ✅ Responsive behavior for mobile devices");
        HelpersSpectre.Success("   ✅ Title width customization");
        HelpersSpectre.Success("   ✅ Margin and padding utilities");
        HelpersSpectre.Success("   ✅ Custom styling and alignment options");
        HelpersSpectre.Success("   ✅ Compact and spacious layout presets");
        HelpersSpectre.Success("   ✅ Mixed content types in single DataGrid");
        HelpersSpectre.Success("   ✅ Zero HTML knowledge required - Pure C# fluent API!");
    }
}