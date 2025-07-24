using HtmlForgeX.Examples;

namespace HtmlForgeX.Examples.Containers;

/// <summary>
/// Basic SmartWizard demo showcasing the fluent API capabilities.
/// </summary>
internal class SmartWizardDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("SmartWizard Basic Demo - Fluent C# API");

        // Sample data for tables
        var data = new List<dynamic> {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
            new { Name = "Bob", Age = 35, Occupation = "Architect" }
        };

        using var document = new Document {
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Head.Title = "SmartWizard Basic Demo";
        document.Head.Author = "HtmlForgeX";
        document.Head.Revised = DateTime.Now;

        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;

            // SECTION: Basic SmartWizard Example
            page.H2("Basic SmartWizard Example");
            page.Text("Step-by-step wizard interface using SmartWizard fluent API").Weight(TablerFontWeight.Medium);

            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("User Registration Wizard");
                        });
                        card.Body(body => {
                            body.SmartWizard(wizard => {
                                wizard.WithTheme(SmartWizardTheme.Progress)
                                     .WithTransition(SmartTabAnimation.SlideHorizontal, 400)
                                     .WithSelectedStep(0)
                                     .WithButtonText("Next Step", "Go Back");

                                // Step 1: Personal Information
                                wizard.AddStep("Personal Info", TablerIconType.User, "Enter your basic information", step => {
                                    step.Text("Please provide your personal information to create your account.")
                                        .Weight(TablerFontWeight.Medium);
                                    step.LineBreak();

                                    step.Row(formRow => {
                                        formRow.Column(TablerColumnNumber.Six, formCol => {
                                            formCol.Text("First Name:").Weight(TablerFontWeight.Medium);
                                            formCol.TablerInput("firstName", input => input
                                                .Type(InputType.Text)
                                                .Placeholder("Enter first name"));
                                        });
                                        formRow.Column(TablerColumnNumber.Six, formCol => {
                                            formCol.Text("Last Name:").Weight(TablerFontWeight.Medium);
                                            formCol.TablerInput("lastName", input => input
                                                .Type(InputType.Text)
                                                .Placeholder("Enter last name"));
                                        });
                                    });

                                    step.LineBreak();
                                    step.Row(formRow => {
                                        formRow.Column(TablerColumnNumber.Six, formCol => {
                                            formCol.Text("Email:").Weight(TablerFontWeight.Medium);
                                            formCol.TablerInput("email", input => input
                                                .Type(InputType.Email)
                                                .Placeholder("Enter email address"));
                                        });
                                        formRow.Column(TablerColumnNumber.Six, formCol => {
                                            formCol.Text("Phone:").Weight(TablerFontWeight.Medium);
                                            formCol.TablerInput("phone", input => input
                                                .Type(InputType.Tel)
                                                .Placeholder("Enter phone number"));
                                        });
                                    });
                                });

                                // Step 2: Address Information
                                wizard.AddStep("Address", TablerIconType.Map, "Provide your address details", step => {
                                    step.Text("Please enter your address information for delivery and billing.")
                                        .Weight(TablerFontWeight.Medium);
                                    step.LineBreak();

                                    step.Row(formRow => {
                                        formRow.Column(TablerColumnNumber.Twelve, formCol => {
                                            formCol.Text("Street Address:").Weight(TablerFontWeight.Medium);
                                            formCol.TablerInput("street", input => input
                                                .Type(InputType.Text)
                                                .Placeholder("Enter street address"));
                                        });
                                    });

                                    step.LineBreak();
                                    step.Row(formRow => {
                                        formRow.Column(TablerColumnNumber.Four, formCol => {
                                            formCol.Text("City:").Weight(TablerFontWeight.Medium);
                                            formCol.TablerInput("city", input => input
                                                .Type(InputType.Text)
                                                .Placeholder("Enter city"));
                                        });
                                        formRow.Column(TablerColumnNumber.Four, formCol => {
                                            formCol.Text("State:").Weight(TablerFontWeight.Medium);
                                            formCol.TablerSelect("state", select => select
                                                .Option("Select state", "")
                                                .Option("California", "CA")
                                                .Option("New York", "NY")
                                                .Option("Texas", "TX"));
                                        });
                                        formRow.Column(TablerColumnNumber.Four, formCol => {
                                            formCol.Text("ZIP Code:").Weight(TablerFontWeight.Medium);
                                            formCol.TablerInput("zip", input => input
                                                .Type(InputType.Text)
                                                .Placeholder("Enter ZIP code"));
                                        });
                                    });
                                });

                                // Step 3: Account Setup
                                wizard.AddStep("Account", TablerIconType.Key, "Set up your account credentials", step => {
                                    step.Text("Create your account credentials to secure your profile.")
                                        .Weight(TablerFontWeight.Medium);
                                    step.LineBreak();

                                    step.Row(formRow => {
                                        formRow.Column(TablerColumnNumber.Six, formCol => {
                                            formCol.Text("Username:").Weight(TablerFontWeight.Medium);
                                            formCol.TablerInput("username", input => input
                                                .Type(InputType.Text)
                                                .Placeholder("Choose username"));
                                        });
                                        formRow.Column(TablerColumnNumber.Six, formCol => {
                                            formCol.Text("Password:").Weight(TablerFontWeight.Medium);
                                            formCol.TablerInput("password", input => input
                                                .Type(InputType.Password)
                                                .Placeholder("Create password"));
                                        });
                                    });

                                    step.LineBreak();
                                    step.Row(formRow => {
                                        formRow.Column(TablerColumnNumber.Six, formCol => {
                                            formCol.Text("Confirm Password:").Weight(TablerFontWeight.Medium);
                                            formCol.TablerInput("confirmPassword", input => input
                                                .Type(InputType.Password)
                                                .Placeholder("Confirm password"));
                                        });
                                        formRow.Column(TablerColumnNumber.Six, formCol => {
                                            formCol.LineBreak();
                                            formCol.LineBreak();
                                            formCol.TablerInput("newsletter", input => input
                                                .Type(InputType.Checkbox));
                                            formCol.Text(" Subscribe to newsletter").Style(TablerTextStyle.Muted);
                                        });
                                    });
                                });

                                // Step 4: Review & Confirm
                                wizard.AddStep("Review", TablerIconType.Check, "Review your information", step => {
                                    step.Text("Please review all your information before submitting.")
                                        .Weight(TablerFontWeight.Medium);
                                    step.LineBreak();

                                    step.DataGrid(dataGrid => {
                                        dataGrid.WithLayout(TablerDataGridLayout.Default)
                                               .WithSpacing(TablerDataGridSpacing.Medium);

                                        dataGrid.AddItem("Full Name", "John Doe");
                                        dataGrid.AddItem("Email", "john.doe@example.com");
                                        dataGrid.AddItem("Phone", "+1 (555) 123-4567");
                                        dataGrid.AddItem("Address", "123 Main St, Anytown, CA 12345");
                                        dataGrid.AddItem("Username", "johndoe");
                                        dataGrid.AddBadgeItem("Newsletter", "Subscribed", TablerColor.Success);
                                        dataGrid.AddStatusItem("Status", "Ready to submit", TablerColor.Info);
                                    });

                                    step.LineBreak();
                                    step.Add(new TablerAlert("Review Complete", "All information has been validated and is ready for submission.", TablerColor.Info, TablerAlertType.Regular)
                                        .Icon(TablerIconType.InfoCircle));
                                });

                                // Step 5: Success
                                wizard.AddStep("Complete", TablerIconType.CircleCheck, "Registration complete", step => {
                                    step.WithState(SmartWizardStepState.Done);

                                    step.Text("Congratulations! Your account has been created successfully.")
                                        .Weight(TablerFontWeight.Medium)
                                        .Color(TablerColor.Success);
                                    step.LineBreak();

                                    step.Row(successRow => {
                                        successRow.Column(TablerColumnNumber.Twelve, successCol => {
                                            successCol.Card(card => {
                                                card.Background(TablerColor.Success, isLight: true);
                                                card.Header(header => {
                                                    header.Title("Welcome to HtmlForgeX!");
                                                    header.Avatar(avatar => {
                                                        avatar.Icon(TablerIconType.User)
                                                              .BackgroundColor(TablerColor.Success)
                                                              .TextColor(TablerColor.White);
                                                    });
                                                });
                                                card.Body(body => {
                                                    body.Text("Your account is now active and ready to use.");
                                                    body.LineBreak();
                                                    body.Text("You can now:")
                                                        .Weight(TablerFontWeight.Medium);
                                                    body.TablerList()
                                                        .AddItem("Access your dashboard", TablerIconType.Dashboard)
                                                        .AddItem("Update your profile", TablerIconType.Settings)
                                                        .AddItem("Explore features", TablerIconType.Search)
                                                        .AddItem("Contact support", TablerIconType.Help);
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

            // SECTION: Advanced SmartWizard with Different Themes
            page.H2("Advanced SmartWizard Themes");
            page.Text("SmartWizard with different themes and orientations").Weight(TablerFontWeight.Medium);

            page.Row(row => {
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Arrows Theme");
                        });
                        card.Body(body => {
                            body.SmartWizard(wizard => {
                                wizard.WithTheme(SmartWizardTheme.Arrows)
                                     .WithTransition(SmartTabAnimation.Fade, 300)
                                     .WithSelectedStep(0)
                                     .WithToolbar(SmartWizardToolbarPosition.Top);

                                wizard.AddStep("Start", TablerIconType.PlayerPlay, step => {
                                    step.Text("Begin your journey with the arrows theme.")
                                        .Weight(TablerFontWeight.Medium);
                                    step.LineBreak();
                                    step.Text("This theme features arrow-style navigation indicators.")
                                        .Style(TablerTextStyle.Muted);
                                });

                                wizard.AddStep("Progress", TablerIconType.TrendingUp, step => {
                                    step.Text("Making progress through the wizard.")
                                        .Weight(TablerFontWeight.Medium);
                                    step.LineBreak();
                                    step.Add(new TablerProgressBar()
                                        .Item(TablerColor.Primary, 65, "Progress"));
                                });

                                wizard.AddStep("Finish", TablerIconType.Flag, step => {
                                    step.Text("Congratulations on completing the wizard!")
                                        .Weight(TablerFontWeight.Medium)
                                        .Color(TablerColor.Success);
                                    step.LineBreak();
                                    step.Add(new TablerTag("Completed", TablerColor.Success));
                                });
                            });
                        });
                    });
                });

                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Dots Theme");
                        });
                        card.Body(body => {
                            body.SmartWizard(wizard => {
                                wizard.WithTheme(SmartWizardTheme.Dots)
                                     .WithTransition(SmartTabAnimation.SlideVertical, 350)
                                     .WithSelectedStep(0)
                                     .WithToolbar(SmartWizardToolbarPosition.Bottom);

                                wizard.AddStep("Configure", TablerIconType.Settings, step => {
                                    step.Text("Configure your preferences with the dots theme.")
                                        .Weight(TablerFontWeight.Medium);
                                    step.LineBreak();
                                    step.DataGrid(dataGrid => {
                                        dataGrid.WithLayout(TablerDataGridLayout.Compact);
                                        dataGrid.AddCheckboxItem("Option 1", true);
                                        dataGrid.AddCheckboxItem("Option 2", false);
                                        dataGrid.AddCheckboxItem("Option 3", true);
                                    });
                                });

                                wizard.AddStep("Preview", TablerIconType.Eye, step => {
                                    step.Text("Preview your configuration changes.")
                                        .Weight(TablerFontWeight.Medium);
                                    step.LineBreak();
                                    step.Text("The dots theme provides a minimalist step indicator.")
                                        .Style(TablerTextStyle.Muted);
                                });

                                wizard.AddStep("Deploy", TablerIconType.CloudUp, step => {
                                    step.Text("Deploy your configuration to production.")
                                        .Weight(TablerFontWeight.Medium);
                                    step.LineBreak();
                                    step.Add(new TablerBadgeStatus("Ready", TablerColor.Success));
                                });
                            });
                        });
                    });
                });
            });

            // SECTION: Vertical SmartWizard
            page.H2("Vertical SmartWizard");
            page.Text("SmartWizard with vertical orientation").Weight(TablerFontWeight.Medium);

            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Header(header => {
                            header.Title("Project Setup Wizard");
                        });
                        card.Body(body => {
                            body.SmartWizard(wizard => {
                                wizard.WithTheme(SmartWizardTheme.Square)
                                     .AsVertical()
                                     .WithTransition(SmartTabAnimation.Fade, 400)
                                     .WithSelectedStep(0)
                                     .WithToolbar(SmartWizardToolbarPosition.Bottom);

                                wizard.AddStep("Project Details", TablerIconType.FolderPlus, "Basic project information", step => {
                                    step.Text("Set up your new project with basic information.")
                                        .Weight(TablerFontWeight.Medium);
                                    step.LineBreak();

                                    step.Row(projectRow => {
                                        projectRow.Column(TablerColumnNumber.Eight, projectCol => {
                                            projectCol.Text("Project Name:").Weight(TablerFontWeight.Medium);
                                            projectCol.TablerInput("projectName", input => input
                                                .Type(InputType.Text)
                                                .Placeholder("Enter project name"));
                                            projectCol.LineBreak();
                                            projectCol.Text("Description:").Weight(TablerFontWeight.Medium);
                                            projectCol.TablerTextarea("description", textarea => textarea
                                                .Placeholder("Enter project description"));
                                        });
                                        projectRow.Column(TablerColumnNumber.Four, projectCol => {
                                            projectCol.Text("Template:").Weight(TablerFontWeight.Medium);
                                            projectCol.TablerSelect("template", select => select
                                                .Option("Select template", "")
                                                .Option("Web Application", "web")
                                                .Option("API Service", "api")
                                                .Option("Desktop App", "desktop"));
                                        });
                                    });
                                });

                                wizard.AddStep("Team Members", TablerIconType.Users, "Add team members", step => {
                                    step.Text("Invite team members to collaborate on your project.")
                                        .Weight(TablerFontWeight.Medium);
                                    step.LineBreak();

                                    step.Row(teamRow => {
                                        teamRow.Column(TablerColumnNumber.Eight, teamCol => {
                                            teamCol.Text("Team Members:").Weight(TablerFontWeight.Medium);
                                            teamCol.LineBreak();

                                            // Sample team members
                                            teamCol.Row(memberRow => {
                                                memberRow.Column(TablerColumnNumber.Two, memberCol => {
                                                    memberCol.Add(new TablerAvatar()
                                                        .Icon(TablerIconType.User)
                                                        .BackgroundColor(TablerColor.Primary)
                                                        .TextColor(TablerColor.White));
                                                });
                                                memberRow.Column(TablerColumnNumber.Ten, memberCol => {
                                                    memberCol.Text("Alice Johnson").Weight(TablerFontWeight.Medium);
                                                    memberCol.LineBreak();
                                                    memberCol.Text("Project Manager").Style(TablerTextStyle.Muted);
                                                });
                                            });

                                            teamCol.LineBreak();
                                            teamCol.Row(memberRow => {
                                                memberRow.Column(TablerColumnNumber.Two, memberCol => {
                                                    memberCol.Add(new TablerAvatar()
                                                        .Icon(TablerIconType.User)
                                                        .BackgroundColor(TablerColor.Info)
                                                        .TextColor(TablerColor.White));
                                                });
                                                memberRow.Column(TablerColumnNumber.Ten, memberCol => {
                                                    memberCol.Text("Bob Wilson").Weight(TablerFontWeight.Medium);
                                                    memberCol.LineBreak();
                                                    memberCol.Text("Developer").Style(TablerTextStyle.Muted);
                                                });
                                            });
                                        });
                                        teamRow.Column(TablerColumnNumber.Four, teamCol => {
                                            teamCol.Text("Invite Members:").Weight(TablerFontWeight.Medium);
                                            teamCol.TablerInput("inviteEmail", input => input
                                                .Type(InputType.Email)
                                                .Placeholder("Enter email address"));
                                            teamCol.LineBreak();
                                            teamCol.TablerSelect("role", select => select
                                                .Option("Select role", "")
                                                .Option("Administrator", "admin")
                                                .Option("Developer", "dev")
                                                .Option("Viewer", "viewer"));
                                        });
                                    });
                                });

                                wizard.AddStep("Configuration", TablerIconType.Settings, "Project settings", step => {
                                    step.Text("Configure project settings and preferences.")
                                        .Weight(TablerFontWeight.Medium);
                                    step.LineBreak();

                                    step.DataGrid(dataGrid => {
                                        dataGrid.WithLayout(TablerDataGridLayout.Default);
                                        dataGrid.AddCheckboxItem("Enable CI/CD", true, "Continuous integration and deployment");
                                        dataGrid.AddCheckboxItem("Code reviews", true, "Require code reviews for pull requests");
                                        dataGrid.AddCheckboxItem("Issue tracking", false, "Enable built-in issue tracking");
                                        dataGrid.AddCheckboxItem("Wiki", false, "Enable project wiki");
                                        dataGrid.AddFormControlItem("License", "select", "Choose license", "MIT");
                                        dataGrid.AddFormControlItem("Visibility", "select", "Project visibility", "private");
                                    });
                                });

                                wizard.AddStep("Launch", TablerIconType.Rocket, "Launch your project", step => {
                                    step.Text("Your project is ready to launch!")
                                        .Weight(TablerFontWeight.Medium)
                                        .Color(TablerColor.Success);
                                    step.LineBreak();

                                    step.Add(new TablerAlert("Project Created Successfully", "Your project has been set up and is ready for development.", TablerColor.Success, TablerAlertType.Regular)
                                        .Icon(TablerIconType.CircleCheck));

                                    step.LineBreak();
                                    step.Text("Next steps:")
                                        .Weight(TablerFontWeight.Medium);
                                    step.TablerList()
                                        .AddItem("Clone the repository", TablerIconType.GitBranch)
                                        .AddItem("Set up development environment", TablerIconType.Tool)
                                        .AddItem("Start coding", TablerIconType.Code)
                                        .AddItem("Invite collaborators", TablerIconType.UserPlus);
                                });
                            });
                        });
                    });
                });
            });
        });

        document.Save("SmartWizardDemo.html", openInBrowser);

        HelpersSpectre.Success("🎉 SmartWizard Basic Demo created!");
        HelpersSpectre.Success("📋 Features demonstrated:");
        HelpersSpectre.Success("   ✅ Step-by-step wizard with fluent API");
        HelpersSpectre.Success("   ✅ Multiple themes (Progress, Arrows, Dots, Square)");
        HelpersSpectre.Success("   ✅ Various animations (SlideHorizontal, Fade, SlideVertical)");
        HelpersSpectre.Success("   ✅ Vertical wizard orientation");
        HelpersSpectre.Success("   ✅ Toolbar positioning (Top, Bottom)");
        HelpersSpectre.Success("   ✅ Step states and validation");
        HelpersSpectre.Success("   ✅ Integration with existing components (DataGrid, Cards, Forms)");
        HelpersSpectre.Success("   ✅ Icon support with Tabler icons");
        HelpersSpectre.Success("   ✅ Responsive design");
        HelpersSpectre.Success("   ✅ Zero HTML knowledge required - Pure C# fluent API!");
    }
}