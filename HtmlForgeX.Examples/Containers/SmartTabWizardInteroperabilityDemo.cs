using HtmlForgeX.Examples;

namespace HtmlForgeX.Examples.Containers;

/// <summary>
/// Advanced demo showing SmartTab and SmartWizard interoperability with existing HtmlForgeX components.
/// </summary>
internal class SmartTabWizardInteroperabilityDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("SmartTab & SmartWizard Interoperability Demo");

        // Sample data for various components
        var userData = new List<dynamic> {
            new { Name = "John Doe", Email = "john@example.com", Role = "Administrator", Status = "Active", LastLogin = "2024-01-15" },
            new { Name = "Jane Smith", Email = "jane@example.com", Role = "Manager", Status = "Active", LastLogin = "2024-01-14" },
            new { Name = "Bob Johnson", Email = "bob@example.com", Role = "Developer", Status = "Inactive", LastLogin = "2024-01-10" },
            new { Name = "Alice Brown", Email = "alice@example.com", Role = "Designer", Status = "Active", LastLogin = "2024-01-13" }
        };

        var projectData = new List<dynamic> {
            new { Project = "HtmlForgeX", Status = "Active", Progress = 85, Team = "Frontend", Budget = "$50,000" },
            new { Project = "DataViz Pro", Status = "Planning", Progress = 25, Team = "Analytics", Budget = "$75,000" },
            new { Project = "Mobile App", Status = "In Progress", Progress = 60, Team = "Mobile", Budget = "$40,000" },
            new { Project = "API Gateway", Status = "Completed", Progress = 100, Team = "Backend", Budget = "$30,000" }
        };

        var systemHealthData = new List<dynamic> {
            new { Component = "Web Server", Status = "Healthy", Uptime = "99.9%", LastCheck = "2 minutes ago" },
            new { Component = "Database", Status = "Warning", Uptime = "98.5%", LastCheck = "1 minute ago" },
            new { Component = "Cache", Status = "Healthy", Uptime = "99.8%", LastCheck = "30 seconds ago" },
            new { Component = "Load Balancer", Status = "Healthy", Uptime = "99.9%", LastCheck = "1 minute ago" }
        };

        using var document = new Document {
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Head.Title = "SmartTab & SmartWizard Interoperability Demo";
        document.Head.Author = "HtmlForgeX";
        document.Head.Revised = DateTime.Now;

        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;

            // SECTION: Admin Dashboard with SmartTab containing DataTables, Cards, and SmartWizard
            page.H1("Admin Dashboard");
            page.Text("Complete admin interface showcasing SmartTab and SmartWizard interoperability").Weight(TablerFontWeight.Medium);

            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("System Administration");
                            header.Subtitle("Manage users, projects, and system health");
                        });
                        card.Body(body => {
                            body.SmartTab(smartTab => {
                                smartTab.WithTheme(SmartTabTheme.Bootstrap)
                                       .WithTransition(SmartTabAnimation.Fade, 300)
                                       .WithSelectedTab(0)
                                       .Justified(true);

                                // Tab 1: Users Management with DataTables
                                smartTab.AddTab("Users", TablerIconType.Users, panel => {
                                    panel.Text("Manage system users and their permissions").Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();

                                    // Statistics cards
                                    panel.Row(statsRow => {
                                        statsRow.Column(TablerColumnNumber.Three, statsCol => {
                                            statsCol.CardMini()
                                                   .Avatar(TablerIconType.Users)
                                                   .BackgroundColor(TablerColor.Primary)
                                                   .TextColor(TablerColor.White)
                                                   .Title("124")
                                                   .Subtitle("Total Users");
                                        });
                                        statsRow.Column(TablerColumnNumber.Three, statsCol => {
                                            statsCol.CardMini()
                                                   .Avatar(TablerIconType.UserCheck)
                                                   .BackgroundColor(TablerColor.Success)
                                                   .TextColor(TablerColor.White)
                                                   .Title("98")
                                                   .Subtitle("Active Users");
                                        });
                                        statsRow.Column(TablerColumnNumber.Three, statsCol => {
                                            statsCol.CardMini()
                                                   .Avatar(TablerIconType.UserPlus)
                                                   .BackgroundColor(TablerColor.Info)
                                                   .TextColor(TablerColor.White)
                                                   .Title("12")
                                                   .Subtitle("New This Month");
                                        });
                                        statsRow.Column(TablerColumnNumber.Three, statsCol => {
                                            statsCol.CardMini()
                                                   .Avatar(TablerIconType.UserX)
                                                   .BackgroundColor(TablerColor.Warning)
                                                   .TextColor(TablerColor.White)
                                                   .Title("3")
                                                   .Subtitle("Inactive Users");
                                        });
                                    });

                                    panel.LineBreak();

                                    // Users DataTable
                                    var usersTable = (DataTablesTable)panel.Table(userData, TableType.DataTables);
                                    usersTable.EnableOrdering(true)
                                             .EnableSearching(true)
                                             .EnableExport(DataTablesExportFormat.Excel, DataTablesExportFormat.CSV)
                                             .EnableResponsive(true)
                                             .Style(BootStrapTableStyle.Striped)
                                             .DefaultOrder(0, "asc")
                                             .ConfigureColumns(columns => {
                                                 columns.Column(col => col.Target(0).Title("Name").Width("25%"));
                                                 columns.Column(col => col.Target(1).Title("Email").Width("30%"));
                                                 columns.Column(col => col.Target(2).Title("Role").Width("15%"));
                                                 columns.Column(col => col.Target(3).Title("Status").Width("15%"));
                                                 columns.Column(col => col.Target(4).Title("Last Login").Width("15%"));
                                             });
                                });

                                // Tab 2: Projects with Enhanced Cards and SmartWizard
                                smartTab.AddTab("Projects", TablerIconType.Briefcase, panel => {
                                    panel.Text("Manage projects and create new ones").Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();

                                    // Project creation wizard
                                    panel.Row(projectRow => {
                                        projectRow.Column(TablerColumnNumber.Eight, projectCol => {
                                            projectCol.Card(card => {
                                                card.Header(header => {
                                                    header.Title("Active Projects");
                                                });
                                                card.Body(body => {
                                                    var projectsTable = (DataTablesTable)body.Table(projectData, TableType.DataTables);
                                                    projectsTable.EnableOrdering(true)
                                                                .EnableSearching(true)
                                                                .Style(BootStrapTableStyle.Hover)
                                                                .EnablePaging(5);
                                                });
                                            });
                                        });

                                        projectRow.Column(TablerColumnNumber.Four, projectCol => {
                                            projectCol.Card(card => {
                                                card.Header(header => {
                                                    header.Title("Create New Project");
                                                });
                                                card.Body(body => {
                                                    body.SmartWizard(wizard => {
                                                        wizard.WithTheme(SmartWizardTheme.Dots)
                                                             .WithTransition(SmartTabAnimation.SlideVertical, 200)
                                                             .WithSelectedStep(0)
                                                             .WithToolbar(SmartWizardToolbarPosition.Bottom)
                                                             .WithButtonText("Next", "Back");

                                                        wizard.AddStep("Basic", TablerIconType.FileText, step => {
                                                            step.Text("Project Name:").Weight(TablerFontWeight.Medium);
                                                            step.TablerInput("projectName", input => input
                                                                .Type(InputType.Text)
                                                                .Placeholder("Enter project name"));
                                                            step.LineBreak();
                                                            step.Text("Description:").Weight(TablerFontWeight.Medium);
                                                            step.TablerTextarea("description", textarea => textarea
                                                                .Placeholder("Enter description"));
                                                        });

                                                        wizard.AddStep("Team", TablerIconType.Users, step => {
                                                            step.Text("Team Lead:").Weight(TablerFontWeight.Medium);
                                                            step.TablerSelect("teamLead", select => select
                                                                .Option("", "Select team lead")
                                                                .Option("john", "John Doe")
                                                                .Option("jane", "Jane Smith"));
                                                            step.LineBreak();
                                                            step.Text("Budget:").Weight(TablerFontWeight.Medium);
                                                            step.TablerInput("budget", input => input
                                                                .Type(InputType.Number)
                                                                .Placeholder("Enter budget"));
                                                        });

                                                        wizard.AddStep("Launch", TablerIconType.Rocket, step => {
                                                            step.Text("Ready to create project!")
                                                                .Weight(TablerFontWeight.Medium)
                                                                .Color(TablerColor.Success);
                                                            step.LineBreak();
                                                            step.Add(new TablerBadgeStatus("Ready", TablerColor.Success));
                                                        });
                                                    });
                                                });
                                            });
                                        });
                                    });
                                });

                                // Tab 3: System Health with DataGrid and Mixed Components
                                smartTab.AddTab("System Health", TablerIconType.Heart, panel => {
                                    panel.Text("Monitor system health and performance").Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();

                                    // Health overview cards
                                    panel.Row(healthRow => {
                                        healthRow.Column(TablerColumnNumber.Three, healthCol => {
                                            healthCol.Card(card => {
                                                card.StatusIndicator("top", TablerColor.Success);
                                                card.Header(header => {
                                                    header.Title("System Status");
                                                    header.Avatar(avatar => {
                                                        avatar.Icon(TablerIconType.Server2)
                                                              .BackgroundColor(TablerColor.Success)
                                                              .TextColor(TablerColor.White);
                                                    });
                                                });
                                                card.Body(body => {
                                                    body.Text("All systems operational")
                                                        .Color(TablerColor.Success)
                                                        .Weight(TablerFontWeight.Medium);
                                                    body.LineBreak();
                                                    body.Text("Uptime: 99.9%").Style(TablerTextStyle.Muted);
                                                });
                                            });
                                        });

                                        healthRow.Column(TablerColumnNumber.Three, healthCol => {
                                            healthCol.Card(card => {
                                                card.StatusIndicator("top", TablerColor.Warning);
                                                card.Header(header => {
                                                    header.Title("Database");
                                                    header.Avatar(avatar => {
                                                        avatar.Icon(TablerIconType.Database)
                                                              .BackgroundColor(TablerColor.Warning)
                                                              .TextColor(TablerColor.White);
                                                    });
                                                });
                                                card.Body(body => {
                                                    body.Text("High load detected")
                                                        .Color(TablerColor.Warning)
                                                        .Weight(TablerFontWeight.Medium);
                                                    body.LineBreak();
                                                    body.Text("Response time: 250ms").Style(TablerTextStyle.Muted);
                                                });
                                            });
                                        });

                                        healthRow.Column(TablerColumnNumber.Six, healthCol => {
                                            healthCol.Card(card => {
                                                card.Header(header => {
                                                    header.Title("Quick Actions");
                                                });
                                                card.Body(body => {
                                                    body.SmartTab(quickTab => {
                                                        quickTab.WithTheme(SmartTabTheme.Classic)
                                                               .WithTransition(SmartTabAnimation.None, 0)
                                                               .WithSelectedTab(0);

                                                        quickTab.AddTab("Monitoring", TablerIconType.Activity, quickPanel => {
                                                            quickPanel.TablerList()
                                                                .AddItem("View system logs", TablerIconType.FileText)
                                                                .AddItem("Performance metrics", TablerIconType.ChartBar)
                                                                .AddItem("Error tracking", TablerIconType.AlertTriangle);
                                                        });

                                                        quickTab.AddTab("Actions", TablerIconType.Settings, quickPanel => {
                                                            quickPanel.TablerList()
                                                                .AddItem("Restart services", TablerIconType.Refresh)
                                                                .AddItem("Clear cache", TablerIconType.Trash)
                                                                .AddItem("Backup database", TablerIconType.Database);
                                                        });
                                                    });
                                                });
                                            });
                                        });
                                    });

                                    panel.LineBreak();

                                    // Detailed health table
                                    panel.Card(card => {
                                        card.Header(header => {
                                            header.Title("Component Health Details");
                                        });
                                        card.Body(body => {
                                            var healthTable = (DataTablesTable)body.Table(systemHealthData, TableType.DataTables);
                                            healthTable.EnableOrdering(true)
                                                      .EnableSearching(false)
                                                      .Style(BootStrapTableStyle.Striped)
                                                      .DisablePaging()
                                                      .EnableResponsive(true);
                                        });
                                    });
                                });

                                // Tab 4: Settings with SmartWizard Configuration
                                smartTab.AddTab("Settings", TablerIconType.Settings, panel => {
                                    panel.Text("System configuration and preferences").Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();

                                    panel.Row(settingsRow => {
                                        settingsRow.Column(TablerColumnNumber.Eight, settingsCol => {
                                            settingsCol.Card(card => {
                                                card.Header(header => {
                                                    header.Title("Configuration Wizard");
                                                });
                                                card.Body(body => {
                                                    body.SmartWizard(wizard => {
                                                        wizard.WithTheme(SmartWizardTheme.Progress)
                                                             .WithTransition(SmartTabAnimation.SlideHorizontal, 300)
                                                             .WithSelectedStep(0)
                                                             .WithToolbar(SmartWizardToolbarPosition.Both);

                                                        wizard.AddStep("General", TablerIconType.Settings, step => {
                                                            step.Text("General system settings").Weight(TablerFontWeight.Medium);
                                                            step.LineBreak();
                                                            step.DataGrid(dataGrid => {
                                                                dataGrid.WithLayout(TablerDataGridLayout.Default);
                                                                dataGrid.AddCheckboxItem("Maintenance mode", false);
                                                                dataGrid.AddCheckboxItem("Debug logging", true);
                                                                dataGrid.AddFormControlItem("Log level", "select", "Level", "info");
                                                                dataGrid.AddFormControlItem("Session timeout", "number", "Minutes", "30");
                                                            });
                                                        });

                                                        wizard.AddStep("Security", TablerIconType.Shield, step => {
                                                            step.Text("Security configuration").Weight(TablerFontWeight.Medium);
                                                            step.LineBreak();
                                                            step.DataGrid(dataGrid => {
                                                                dataGrid.WithLayout(TablerDataGridLayout.Default);
                                                                dataGrid.AddCheckboxItem("Two-factor authentication", true);
                                                                dataGrid.AddCheckboxItem("SSL enforcement", true);
                                                                dataGrid.AddFormControlItem("Password policy", "select", "Policy", "strong");
                                                                dataGrid.AddFormControlItem("Login attempts", "number", "Max attempts", "5");
                                                            });
                                                        });

                                                        wizard.AddStep("Backup", TablerIconType.Database, step => {
                                                            step.Text("Backup configuration").Weight(TablerFontWeight.Medium);
                                                            step.LineBreak();
                                                            step.DataGrid(dataGrid => {
                                                                dataGrid.WithLayout(TablerDataGridLayout.Default);
                                                                dataGrid.AddCheckboxItem("Automatic backups", true);
                                                                dataGrid.AddFormControlItem("Backup frequency", "select", "Frequency", "daily");
                                                                dataGrid.AddFormControlItem("Retention period", "number", "Days", "30");
                                                                dataGrid.AddFormControlItem("Backup location", "text", "Path", "/backup");
                                                            });
                                                        });

                                                        wizard.AddStep("Apply", TablerIconType.Check, step => {
                                                            step.Text("Configuration complete!")
                                                                .Weight(TablerFontWeight.Medium)
                                                                .Color(TablerColor.Success);
                                                            step.LineBreak();
                                                            step.Add(new TablerAlert("Settings Updated", "All configuration changes have been applied successfully.", TablerColor.Success, TablerAlertType.Regular)
                                                                .Icon(TablerIconType.CircleCheck));
                                                        });
                                                    });
                                                });
                                            });
                                        });

                                        settingsRow.Column(TablerColumnNumber.Four, settingsCol => {
                                            settingsCol.Card(card => {
                                                card.Header(header => {
                                                    header.Title("Current Settings");
                                                });
                                                card.Body(body => {
                                                    body.DataGrid(dataGrid => {
                                                        dataGrid.WithLayout(TablerDataGridLayout.Compact);
                                                        dataGrid.AddBadgeItem("Environment", "Production", TablerColor.Success);
                                                        dataGrid.AddStatusItem("Version", "2.1.0", TablerColor.Info);
                                                        dataGrid.AddItem("Last Updated", "2024-01-15");
                                                        dataGrid.AddCheckboxItem("Maintenance", false);
                                                        dataGrid.AddStatusItem("Backup Status", "Healthy", TablerColor.Success);
                                                        dataGrid.AddItem("Next Backup", "Tonight 2:00 AM");
                                                    });
                                                });
                                            });
                                        });
                                    });
                                });
                            });
                        });
                    });
                });
            });

            // SECTION: Domain Health Check Integration (Enhanced version of existing component)
            page.H2("Enhanced Domain Health Check");
            page.Text("Domain health monitoring integrated with SmartTab interface").Weight(TablerFontWeight.Medium);

            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Domain Security & Health Monitor");
                        });
                        card.Body(body => {
                            body.SmartTab(domainTab => {
                                domainTab.WithTheme(SmartTabTheme.Bootstrap)
                                        .WithTransition(SmartTabAnimation.Fade, 200)
                                        .WithSelectedTab(0);

                                // Tab 1: Security Rating (Enhanced version of DomainHealthCheck)
                                domainTab.AddTab("Security Rating", TablerIconType.Shield, panel => {
                                    panel.Row(securityRow => {
                                        securityRow.Column(TablerColumnNumber.Twelve, securityCol => {
                                            securityCol.Card(card => {
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

                                                            dataGrid.AddBadgeItem("SPF", "soft fail", TablerColor.Green);
                                                            dataGrid.AddStatusItem("DKIM", "yes, 2 selectors known", TablerColor.Success);
                                                            dataGrid.AddBadgeItem("DMARC", "reject", TablerColor.GreenLight);
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

                                                            dataGrid.AddBadgeItem("TLS (STARTTLS)", "supported by all MX", TablerColor.Green, TablerBadgeStyle.Normal);
                                                            dataGrid.AddItem("MTA-STS", "enforce");
                                                            dataGrid.AddIconItem("TLSA (DANE)", TablerIconType.X, "no", TablerColor.Red);
                                                            dataGrid.AddStatusItem("TLS REPORTING", "yes", TablerColor.Success);
                                                        });
                                                    });

                                                    // Enhanced DOMAIN Section
                                                    cardRow.Column(TablerColumnNumber.Three, textColumn => {
                                                        textColumn.HeaderLevel(HeaderLevelTag.H4, "DOMAIN").Class("card-title");
                                                        textColumn.DataGrid(dataGrid => {
                                                            dataGrid.WithLayout(TablerDataGridLayout.Default)
                                                                   .WithSpacing(TablerDataGridSpacing.Medium)
                                                                   .AsMobileResponsive();

                                                            dataGrid.AddItem("NAME", "evotec.xyz");
                                                            dataGrid.AddIconItem("DNSSEC", TablerIconType.Check, "yes", TablerColor.Green);
                                                            dataGrid.AddBadgeItem("MONITORING", "yes", TablerColor.GreenLight);
                                                            dataGrid.AddStatusItem("STATUS", "Active", TablerColor.Success);
                                                        });
                                                    });
                                                });
                                            });
                                        });
                                    });
                                });

                                // Tab 2: Performance Metrics
                                domainTab.AddTab("Performance", TablerIconType.Activity, panel => {
                                    panel.Text("Domain performance and response time metrics").Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();

                                    panel.Row(perfRow => {
                                        perfRow.Column(TablerColumnNumber.Six, perfCol => {
                                            perfCol.Card(card => {
                                                card.Header(header => {
                                                    header.Title("Response Times");
                                                });
                                                card.Body(body => {
                                                    body.DataGrid(dataGrid => {
                                                        dataGrid.WithLayout(TablerDataGridLayout.Default);
                                                        dataGrid.AddItem("DNS Lookup", "3.4ms");
                                                        dataGrid.AddItem("TCP Connect", "0.52ms");
                                                        dataGrid.AddItem("SSL Handshake", "12.5ms");
                                                        dataGrid.AddItem("First Byte", "145ms");
                                                        dataGrid.AddItem("Total Time", "280ms");
                                                        dataGrid.AddStatusItem("Performance", "Excellent", TablerColor.Success);
                                                    });
                                                });
                                            });
                                        });

                                        perfRow.Column(TablerColumnNumber.Six, perfCol => {
                                            perfCol.Card(card => {
                                                card.Header(header => {
                                                    header.Title("SSL Certificate");
                                                });
                                                card.Body(body => {
                                                    body.DataGrid(dataGrid => {
                                                        dataGrid.WithLayout(TablerDataGridLayout.Default);
                                                        dataGrid.AddItem("Issuer", "Let's Encrypt");
                                                        dataGrid.AddItem("Valid From", "2024-01-01");
                                                        dataGrid.AddItem("Valid To", "2024-04-01");
                                                        dataGrid.AddItem("Days Left", "75");
                                                        dataGrid.AddStatusItem("Certificate", "Valid", TablerColor.Success);
                                                        dataGrid.AddIconItem("Auto-Renewal", TablerIconType.Check, "Enabled", TablerColor.Green);
                                                    });
                                                });
                                            });
                                        });
                                    });
                                });

                                // Tab 3: Monitoring History
                                domainTab.AddTab("History", TablerIconType.History, panel => {
                                    panel.Text("Historical monitoring data and trends").Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();

                                    var historyData = new List<dynamic> {
                                        new { Date = "2024-01-15", Status = "Healthy", ResponseTime = "250ms", Uptime = "100%" },
                                        new { Date = "2024-01-14", Status = "Healthy", ResponseTime = "245ms", Uptime = "100%" },
                                        new { Date = "2024-01-13", Status = "Warning", ResponseTime = "450ms", Uptime = "99.5%" },
                                        new { Date = "2024-01-12", Status = "Healthy", ResponseTime = "235ms", Uptime = "100%" },
                                        new { Date = "2024-01-11", Status = "Healthy", ResponseTime = "240ms", Uptime = "100%" }
                                    };

                                    var historyTable = (DataTablesTable)panel.Table(historyData, TableType.DataTables);
                                    historyTable.EnableOrdering(true)
                                               .EnableSearching(true)
                                               .Style(BootStrapTableStyle.Striped)
                                               .EnablePaging(10)
                                               .DefaultOrder(0, "desc");
                                });

                                // Tab 4: Alerts & Notifications
                                domainTab.AddTab("Alerts", TablerIconType.Bell, panel => {
                                    panel.Text("Configure monitoring alerts and notifications").Weight(TablerFontWeight.Medium);
                                    panel.LineBreak();

                                    panel.SmartWizard(alertWizard => {
                                        alertWizard.WithTheme(SmartWizardTheme.Round)
                                                  .WithTransition(SmartTabAnimation.Fade, 200)
                                                  .WithSelectedStep(0)
                                                  .WithToolbar(SmartWizardToolbarPosition.Bottom);

                                        alertWizard.AddStep("Rules", TablerIconType.Settings, step => {
                                            step.Text("Configure alert rules").Weight(TablerFontWeight.Medium);
                                            step.LineBreak();
                                            step.DataGrid(dataGrid => {
                                                dataGrid.WithLayout(TablerDataGridLayout.Default);
                                                dataGrid.AddCheckboxItem("Response time > 500ms", true);
                                                dataGrid.AddCheckboxItem("SSL certificate expiry", true);
                                                dataGrid.AddCheckboxItem("DNS resolution failure", true);
                                                dataGrid.AddCheckboxItem("HTTP status errors", false);
                                            });
                                        });

                                        alertWizard.AddStep("Contacts", TablerIconType.AddressBook, step => {
                                            step.Text("Notification contacts").Weight(TablerFontWeight.Medium);
                                            step.LineBreak();
                                            step.DataGrid(dataGrid => {
                                                dataGrid.WithLayout(TablerDataGridLayout.Default);
                                                dataGrid.AddFormControlItem("Email", "email", "Email address", "admin@example.com");
                                                dataGrid.AddFormControlItem("SMS", "tel", "Phone number", "+1-555-0123");
                                                dataGrid.AddCheckboxItem("Slack notifications", true);
                                                dataGrid.AddCheckboxItem("Push notifications", false);
                                            });
                                        });

                                        alertWizard.AddStep("Test", TablerIconType.Send, step => {
                                            step.Text("Test alert configuration").Weight(TablerFontWeight.Medium);
                                            step.LineBreak();
                                            step.Add(new TablerAlert("Test Alert", "Click 'Send Test Alert' to verify your configuration.", TablerColor.Info, TablerAlertType.Regular)
                                                .Icon(TablerIconType.InfoCircle));
                                        });
                                    });
                                });
                            });
                        });
                    });
                });
            });
        });

        document.Save("SmartTabWizardInteroperabilityDemo.html", openInBrowser);

        HelpersSpectre.Success("🎉 SmartTab & SmartWizard Interoperability Demo created!");
        HelpersSpectre.Success("📋 Advanced features demonstrated:");
        HelpersSpectre.Success("   ✅ SmartTab containing DataTables with advanced features");
        HelpersSpectre.Success("   ✅ SmartWizard within SmartTab panels");
        HelpersSpectre.Success("   ✅ Nested SmartTab components");
        HelpersSpectre.Success("   ✅ Integration with existing Tabler components (Cards, DataGrid, etc.)");
        HelpersSpectre.Success("   ✅ Enhanced Domain Health Check with tabbed interface");
        HelpersSpectre.Success("   ✅ Complex admin dashboard with multiple component types");
        HelpersSpectre.Success("   ✅ Real-world use cases and scenarios");
        HelpersSpectre.Success("   ✅ Full interoperability between all HtmlForgeX components");
        HelpersSpectre.Success("   ✅ Responsive design with mobile support");
        HelpersSpectre.Success("   ✅ Zero HTML knowledge required - Pure C# fluent API!");
    }
}