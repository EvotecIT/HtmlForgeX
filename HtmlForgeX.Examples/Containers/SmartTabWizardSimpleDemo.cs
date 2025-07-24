using HtmlForgeX.Examples;

namespace HtmlForgeX.Examples.Containers;

/// <summary>
/// Simple demo demonstrating SmartTab and SmartWizard functionality with proper fluent API usage.
/// </summary>
internal class SmartTabWizardSimpleDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("SmartTab & SmartWizard Simple Demo");

        using var document = new Document {
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Head.Title = "SmartTab & SmartWizard Simple Demo";
        document.Head.Author = "HtmlForgeX";
        document.Head.Revised = DateTime.Now;

        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;

            // Title
            page.H1("SmartTab & SmartWizard Simple Demo");
            page.Text("Demonstration of SmartTab and SmartWizard components with proper fluent API usage")
                .Weight(TablerFontWeight.Medium)
                .Style(TablerTextStyle.Muted);

            page.LineBreak();

            // SmartTab Demo
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("SmartTab Demo");
                            header.Subtitle("Basic tab functionality");
                        });
                        card.Body(body => {
                            body.SmartTab(smartTab => {
                                smartTab.WithTheme(SmartTabTheme.Bootstrap)
                                       .WithTransition(SmartTabAnimation.Fade, 300)
                                       .WithSelectedTab(0)
                                       .Justified(true)
                                       .AutoAdjustHeight(true);

                                smartTab.AddTab("Home", TablerIconType.Home, panel => {
                                    panel.Text("Welcome to the Home tab!");
                                    panel.LineBreak();
                                    panel.Text("This demonstrates basic SmartTab functionality.");
                                });

                                smartTab.AddTab("Settings", TablerIconType.Settings, panel => {
                                    panel.Text("Configuration settings");
                                    panel.LineBreak();
                                    panel.Form(form => {
                                        form.Input("email", input => {
                                            input.Type(InputType.Email)
                                                 .Label("Email Address")
                                                 .Placeholder("Enter your email")
                                                 .Required();
                                        });
                                        form.Textarea("description", textarea => {
                                            textarea.Label("Description")
                                                   .Placeholder("Enter description")
                                                   .Rows(3);
                                        });
                                    });
                                });

                                smartTab.AddTab("Profile", TablerIconType.User, panel => {
                                    panel.Text("User profile information");
                                    panel.LineBreak();
                                    panel.Add(new TablerAvatar()
                                         .Icon(TablerIconType.User)
                                         .Size(AvatarSize.MD)
                                         .BackgroundColor(TablerColor.Primary)
                                         .TextColor(TablerColor.White));
                                });
                            });
                        });
                    });
                });

                // SmartWizard Demo
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("SmartWizard Demo");
                            header.Subtitle("Step-by-step wizard");
                        });
                        card.Body(body => {
                            body.SmartWizard(smartWizard => {
                                smartWizard.WithTheme(SmartWizardTheme.Arrows)
                                          .WithTransition(SmartTabAnimation.SlideHorizontal, 400)
                                          .WithSelectedStep(0)
                                          .Justified(true)
                                          .AutoAdjustHeight(true)
                                          .BackButtonSupport(true)
                                          .WithToolbar(SmartWizardToolbarPosition.Bottom)
                                          .WithToolbarButtons(true, true);

                                smartWizard.AddStep("Account", TablerIconType.User, step => {
                                    step.Text("Create your account");
                                    step.LineBreak();
                                    step.Form(form => {
                                        form.Input("username", input => {
                                            input.Type(InputType.Text)
                                                 .Label("Username")
                                                 .Placeholder("Enter username")
                                                 .Required();
                                        });
                                        form.Input("password", input => {
                                            input.Type(InputType.Password)
                                                 .Label("Password")
                                                 .Placeholder("Enter password")
                                                 .Required();
                                        });
                                    });
                                });

                                smartWizard.AddStep("Profile", TablerIconType.UserCheck, step => {
                                    step.Text("Complete your profile");
                                    step.LineBreak();
                                    step.Form(form => {
                                        form.Input("fullname", input => {
                                            input.Type(InputType.Text)
                                                 .Label("Full Name")
                                                 .Placeholder("Enter your full name");
                                        });
                                        form.Input("email", input => {
                                            input.Type(InputType.Email)
                                                 .Label("Email")
                                                 .Placeholder("Enter your email");
                                        });
                                        form.Textarea("bio", textarea => {
                                            textarea.Label("Biography")
                                                   .Placeholder("Tell us about yourself")
                                                   .Rows(3);
                                        });
                                    });
                                });

                                smartWizard.AddStep("Review", TablerIconType.Eye, step => {
                                    step.Text("Review your information");
                                    step.LineBreak();
                                    step.Alert("Success", "Your account has been created successfully!", TablerColor.Success)
                                        .Icon(TablerIconType.Check);
                                });

                                smartWizard.AddStep("Complete", TablerIconType.CircleCheck, step => {
                                    step.Text("Setup complete!");
                                    step.LineBreak();
                                    step.Text("You can now start using the application.")
                                        .Style(TablerTextStyle.Success);
                                });
                            });
                        });
                    });
                });
            });

            // Feature List
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Features Implemented");
                        });
                        card.Body(body => {
                            body.Row(featuresRow => {
                                featuresRow.Column(TablerColumnNumber.Six, col => {
                                    col.Text("SmartTab Features:").Weight(TablerFontWeight.Bold);
                                    col.TablerList()
                                       .AddItem("7 Themes (Bootstrap, Classic, Dark, etc.)", TablerIconType.Check)
                                       .AddItem("6 Animation Types", TablerIconType.Check)
                                       .AddItem("Auto-progress functionality", TablerIconType.Check)
                                       .AddItem("Keyboard navigation", TablerIconType.Check)
                                       .AddItem("AJAX content loading", TablerIconType.Check)
                                       .AddItem("URL hash navigation", TablerIconType.Check)
                                       .AddItem("Custom CSS animations", TablerIconType.Check);
                                });
                                featuresRow.Column(TablerColumnNumber.Six, col => {
                                    col.Text("SmartWizard Features:").Weight(TablerFontWeight.Bold);
                                    col.TablerList()
                                       .AddItem("8 Themes (Basic, Arrows, Square, etc.)", TablerIconType.Check)
                                       .AddItem("Step validation support", TablerIconType.Check)
                                       .AddItem("Toolbar positioning", TablerIconType.Check)
                                       .AddItem("State management", TablerIconType.Check)
                                       .AddItem("Form wizard capabilities", TablerIconType.Check)
                                       .AddItem("Progress tracking", TablerIconType.Check)
                                       .AddItem("Event handling", TablerIconType.Check);
                                });
                            });
                        });
                    });
                });
            });
        });

        document.Save("SmartTabWizardSimpleDemo.html", openInBrowser);
        HelpersSpectre.Success(document.ToString());
    }
}