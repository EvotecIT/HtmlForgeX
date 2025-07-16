namespace HtmlForgeX.Examples.Containers;

internal class EnhancedAccordionStepsShowcase {
    public static void Demo01(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Enhanced Accordion & Steps Showcase - Complete Feature Demo");

        using var document = new Document {
            Head = {
                Title = "Enhanced Accordion & Steps - Complete Feature Showcase",
                Author = "HtmlForgeX",
                Revised = DateTime.Now
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;

            // Title section
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Text("Enhanced Accordion & Steps Showcase").HeaderLevel(HeaderLevelTag.H1, "Enhanced Accordion & Steps Showcase");
                    column.Text("Comprehensive demonstration of all new features added to TablerAccordion and TablerSteps components").Style(TablerTextStyle.Muted);
                    column.LineBreak();
                });
            });

            // Accordion Types Demonstration
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Text("🎛️ Accordion Types & Configurations").HeaderLevel(HeaderLevelTag.H2, "Accordion Types & Configurations");
                });
            });

            page.Row(row => {
                // Default Accordion with Icons
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Text("Default Accordion with Icons").HeaderLevel(HeaderLevelTag.H3, "Default Accordion with Icons");

                        card.Accordion(accordion => {
                            accordion.AddItem("🚀 Getting Started", item => {
                                item.Icon(TablerIconType.Rocket)
                                    .Expanded(true)
                                    .Content(new Span().AddContent("Learn the fundamentals of HtmlForgeX development with this comprehensive guide"));
                            });

                            accordion.AddItem("📚 Documentation", item => {
                                item.Icon(TablerIconType.Book)
                                    .Content(new Span().AddContent("Explore detailed API documentation and best practices"));
                            });

                            accordion.AddItem("⚙️ Advanced Features", item => {
                                item.Icon(TablerIconType.Settings)
                                    .Content(new Span().AddContent("Master advanced component configurations and customizations"));
                            });

                            accordion.AddItem("🔒 Security (Disabled)", item => {
                                item.Icon(TablerIconType.Lock)
                                    .Disabled(true)
                                    .Content(new Span().AddContent("Security features coming in next release"));
                            });
                        });
                    });
                });

                // Flush Accordion with Color Theme
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Text("Flush Accordion with Color Theme").HeaderLevel(HeaderLevelTag.H3, "Flush Accordion with Color Theme");

                        card.Accordion(accordion => {
                            accordion.Type(TablerAccordionType.Flush)
                                    .Color(TablerColor.Primary);

                            accordion.AddItem("💡 Innovation", item => {
                                item.Icon(TablerIconType.Bulb)
                                    .Expanded(true)
                                    .Content(new Span().AddContent("Revolutionary zero-HTML approach to web development"));
                            });

                            accordion.AddItem("🔧 Technical Excellence", item => {
                                item.Icon(TablerIconType.Tool)
                                    .Content(new Span().AddContent("Built on Bootstrap 5, Tabler CSS, and modern C# patterns"));
                            });

                            accordion.AddItem("📈 Performance", item => {
                                item.Icon(TablerIconType.TrendingUp)
                                    .Content(new Span().AddContent("Optimized rendering with minimal overhead"));
                            });
                        });
                    });
                });
            });

            page.Row(row => {
                // Always Open Tabs Accordion
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Text("Always Open Tabs Accordion").HeaderLevel(HeaderLevelTag.H3, "Always Open Tabs Accordion");

                        card.Accordion(accordion => {
                            accordion.Type(TablerAccordionType.Tabs)
                                    .Color(TablerColor.Success)
                                    .AlwaysOpen(true);

                            accordion.AddItem("📋 Phase 1: Planning", item => {
                                item.Icon(TablerIconType.ClipboardList)
                                    .Expanded(true)
                                    .Content(new Span().AddContent("Requirements gathering and architecture planning"));
                            });

                            accordion.AddItem("👨‍💻 Phase 2: Development", item => {
                                item.Icon(TablerIconType.Code)
                                    .Expanded(true)
                                    .Content(new Span().AddContent("Implementation using HtmlForgeX fluent API"));
                            });

                            accordion.AddItem("🧪 Phase 3: Testing", item => {
                                item.Icon(TablerIconType.TestPipe)
                                    .Content(new Span().AddContent("Quality assurance and cross-browser testing"));
                            });
                        });
                    });
                });

                // Plus Style Accordion
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Text("Plus Style Accordion").HeaderLevel(HeaderLevelTag.H3, "Plus Style Accordion");

                        card.Accordion(accordion => {
                            accordion.Type(TablerAccordionType.Plus)
                                    .Color(TablerColor.Orange);

                            accordion.AddItem("✅ Completed Tasks", item => {
                                item.Icon(TablerIconType.Check)
                                    .Expanded(true)
                                    .Content().Span("Enhanced accordion and steps implementation finished").LineBreak().Text("🎉 All features working perfectly!");
                            });

                            accordion.AddItem("🔄 In Progress", item => {
                                item.Icon(TablerIconType.Loader)
                                    .Content(new Span().AddContent("Documentation and example creation"));
                            });

                            accordion.AddItem("📅 Planned", item => {
                                item.Icon(TablerIconType.Calendar)
                                    .Content(new Span().AddContent("Advanced animations and custom themes"));
                            });
                        });
                    });
                });
            });

            page.Row(row => {
                // Inverted Accordion
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Text("Inverted Style Accordion (Icons on Left)").HeaderLevel(HeaderLevelTag.H3, "Inverted Style Accordion");

                        card.Accordion(accordion => {
                            accordion.Type(TablerAccordionType.Inverted)
                                    .Color(TablerColor.Info);

                            accordion.AddItem("🖥️ System Status", item => {
                                item.Icon(TablerIconType.Server)
                                    .Expanded(true)
                                    .Content(new Span().AddContent("All systems operational - monitoring dashboard shows green across all services"));
                            });

                            accordion.AddItem("💾 Database Health", item => {
                                item.Icon(TablerIconType.Database)
                                    .Content(new Span().AddContent("Primary and replica databases running optimally with low latency"));
                            });

                            accordion.AddItem("🔐 Security Monitoring", item => {
                                item.Icon(TablerIconType.Shield)
                                    .Content().Span("No security threats detected - all authentication systems functioning normally");
                            });
                        });
                    });
                });
            });

            // Steps Components Demonstration
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Text("🔄 Enhanced Steps Components").HeaderLevel(HeaderLevelTag.H2, "Enhanced Steps Components");
                });
            });

            page.Row(row => {
                // Horizontal Steps with States
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Text("E-commerce Order Process - Horizontal Steps").HeaderLevel(HeaderLevelTag.H3, "E-commerce Order Process");

                        card.Steps()
                            .Color(TablerColor.Success)
                            .AddStep("Shopping Cart", TablerStepState.Completed)
                            .AddStep("Customer Info", TablerStepState.Completed)
                            .AddStep("Payment", TablerStepState.Active)
                            .AddStep("Review Order", TablerStepState.Pending)
                            .AddStep("Confirmation", TablerStepState.Pending);

                        card.LineBreak();
                        card.Text("Progress: Step 3 of 5 (60% Complete)").Style(TablerTextStyle.Muted);
                    });
                });
            });

            page.Row(row => {
                // Vertical Steps with Descriptions
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Text("Project Development Timeline").HeaderLevel(HeaderLevelTag.H4, "Project Timeline");

                        card.Steps()
                            .Orientation(StepsOrientation.Vertical)
                            .Color(TablerColor.Blue)
                            .AddStep("Requirements", "Gather and analyze project requirements", TablerStepState.Completed)
                            .AddStep("Design", "Create UI/UX designs and wireframes", TablerStepState.Completed)
                            .AddStep("Development", "Implement features using HtmlForgeX", TablerStepState.Active)
                            .AddStep("Testing", "Quality assurance and bug fixing", TablerStepState.Pending)
                            .AddStep("Deployment", "Production release and monitoring", TablerStepState.Pending);
                    });
                });

                // Numbered Steps
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Text("Setup Guide (Numbered)").HeaderLevel(HeaderLevelTag.H4, "Setup Guide");

                        card.Steps()
                            .Orientation(StepsOrientation.Vertical)
                            .StepCounting()
                            .Color(TablerColor.Purple)
                            .AddClickableStep("Install", "Install HtmlForgeX NuGet package", "/install", TablerStepState.Completed)
                            .AddClickableStep("Configure", "Set up your first document", "/configure", TablerStepState.Completed)
                            .AddClickableStep("Build", "Create your UI components", "/build", TablerStepState.Active)
                            .AddClickableStep("Deploy", "Publish to production", "/deploy", TablerStepState.Pending);

                        card.LineBreak();
                        card.Text("💡 Tip: Click on completed steps to view documentation").Style(TablerTextStyle.Muted);
                    });
                });

                // Different Colored Processes
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Text("Multi-Process Monitoring").HeaderLevel(HeaderLevelTag.H4, "Status Monitoring");

                        card.Text("Database Migration").HeaderLevel(HeaderLevelTag.H6, "Database Migration");
                        card.Steps()
                            .Orientation(StepsOrientation.Vertical)
                            .Color(TablerColor.Green)
                            .AddStep("Backup", TablerStepState.Completed)
                            .AddStep("Migrate", TablerStepState.Active)
                            .AddStep("Verify", TablerStepState.Pending);

                        card.LineBreak();
                        card.Text("Security Audit").HeaderLevel(HeaderLevelTag.H6, "Security Audit");
                        card.Steps()
                            .Orientation(StepsOrientation.Vertical)
                            .Color(TablerColor.Red)
                            .AddStep("Scan", TablerStepState.Completed)
                            .AddStep("Analyze", TablerStepState.Completed)
                            .AddStep("Report", TablerStepState.Active);
                    });
                });
            });

            // Interactive Demo Section
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Text("🎮 Interactive Feature Matrix").HeaderLevel(HeaderLevelTag.H2, "Interactive Feature Matrix");
                });
            });

            page.Row(row => {
                // Complex Accordion with Mixed Content
                row.Column(TablerColumnNumber.Eight, column => {
                    column.Card(card => {
                        card.Text("HtmlForgeX Component Library").HeaderLevel(HeaderLevelTag.H3, "Component Library");

                        card.Accordion(accordion => {
                            accordion.Type(TablerAccordionType.Default)
                                    .Color(TablerColor.Teal);

                            accordion.AddItem("📊 Dashboard Components", item => {
                                item.Icon(TablerIconType.Dashboard)
                                    .Expanded(true)
                                    .Content(content => {
                                        content.Text("Available dashboard components:");
                                        content.LineBreak();
                                        content.Steps()
                                            .Color(TablerColor.Success)
                                            .AddStep("Cards", TablerStepState.Completed)
                                            .AddStep("Charts", TablerStepState.Completed)
                                            .AddStep("Tables", TablerStepState.Active)
                                            .AddStep("Forms", TablerStepState.Pending);
                                    });
                            });

                            accordion.AddItem("🎨 Layout System", item => {
                                item.Icon(TablerIconType.Layout)
                                    .Content(new Span().AddContent("Responsive Bootstrap 5 grid with Tabler CSS enhancements for modern web applications"));
                            });

                            accordion.AddItem("🔧 Developer Tools", item => {
                                item.Icon(TablerIconType.Tools)
                                    .Content(content => {
                                        content.Text("Enhanced development experience:");
                                        content.LineBreak();
                                        content.Steps()
                                            .Orientation(StepsOrientation.Vertical)
                                            .StepCounting()
                                            .Color(TablerColor.Orange)
                                            .AddStep("IntelliSense", "Full code completion support", TablerStepState.Completed)
                                            .AddStep("Type Safety", "Compile-time error checking", TablerStepState.Completed)
                                            .AddStep("Hot Reload", "Instant preview updates", TablerStepState.Active);
                                    });
                            });
                        });
                    });
                });

                // Feature Comparison Card
                row.Column(TablerColumnNumber.Four, column => {
                    column.Card(card => {
                        card.Text("Feature Comparison").HeaderLevel(HeaderLevelTag.H4, "HtmlForgeX vs Traditional");

                        card.Accordion(accordion => {
                            accordion.Type(TablerAccordionType.Flush)
                                    .Color(TablerColor.Cyan)
                                    .AlwaysOpen(true);

                            accordion.AddItem("⚡ Development Speed", item => {
                                item.Icon(TablerIconType.Bolt)
                                    .Expanded(true)
                                    .Content(new Span().AddContent("5x faster development with zero context switching"));
                            });

                            accordion.AddItem("🛡️ Type Safety", item => {
                                item.Icon(TablerIconType.Shield)
                                    .Expanded(true)
                                    .Content(new Span().AddContent("Compile-time checking vs runtime errors"));
                            });

                            accordion.AddItem("🎯 Learning Curve", item => {
                                item.Icon(TablerIconType.Target)
                                    .Expanded(true)
                                    .Content(new Span().AddContent("No HTML/CSS/JS knowledge required"));
                            });
                        });
                    });
                });
            });

            // NEW: Fluent Content Syntax Demonstration
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Text("🎯 NEW: Improved Content Syntax Demo").HeaderLevel(HeaderLevelTag.H2, "Improved Content Syntax");

                        card.Accordion(accordion => {
                            accordion.Type(TablerAccordionType.Default)
                                    .Color(TablerColor.Green);

                            // OLD SYNTAX (still works) - Direct element
                            accordion.AddItem("📝 Old Syntax (Direct Element)", item => {
                                item.Icon(TablerIconType.Code)
                                    .Content(new Span().AddContent("This uses the old syntax: new Span().AddContent(\"text\")"));
                            });

                            // NEW FLUENT SYNTAX
                            accordion.AddItem("✨ NEW: Fluent Chaining Syntax", item => {
                                item.Icon(TablerIconType.Wand)
                                    .Content().Span("This uses NEW fluent syntax: .Content().Span().LineBreak().Text()").LineBreak().Text("Much cleaner and more intuitive!");
                            });

                            // LAMBDA SYNTAX (enhanced)
                            accordion.AddItem("🔧 Lambda Configuration Syntax", item => {
                                item.Icon(TablerIconType.Settings)
                                    .Content(content => {
                                        content.Span("This uses lambda syntax for complex content:");
                                        content.LineBreak();
                                        content.Text("• Multiple elements").LineBreak();
                                        content.Text("• Complex structures").LineBreak();
                                        content.Text("• Perfect for advanced scenarios");
                                    });
                            });
                        });

                        card.LineBreak();
                        card.Add(new Span().AddContent("🎉 All three syntax options work perfectly! Choose the one that fits your coding style.").WithColor(RGBColor.Green));
                    });
                });
            });

            // Summary and Features Overview
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Text("🎉 Complete Feature Summary").HeaderLevel(HeaderLevelTag.H2, "Feature Summary");

                        card.Row(cardRow => {
                            cardRow.Column(TablerColumnNumber.Six, col => {
                                col.Text("🎛️ Enhanced Accordion Features:").HeaderLevel(HeaderLevelTag.H4, "Accordion Features");
                                col.Text("✓ Five accordion types (Default, Flush, Tabs, Inverted, Plus)");

                                col.Text("✓ Color theming with all Tabler colors");

                                col.Text("✓ Always-open mode for multiple expanded items");

                                col.Text("✓ Icon support with TablerIconElement");

                                col.Text("✓ Expanded and disabled states");

                                col.Text("✓ Enhanced accessibility with ARIA attributes");
                            });

                            cardRow.Column(TablerColumnNumber.Six, col => {
                                col.Text("🔄 Enhanced Steps Features:").HeaderLevel(HeaderLevelTag.H4, "Steps Features");
                                col.Text("✓ Step states (Pending, Active, Completed)");

                                col.Text("✓ Clickable steps with URL navigation");

                                col.Text("✓ Horizontal and vertical orientations");

                                col.Text("✓ Numbered steps with step counting");

                                col.Text("✓ Tooltip support for enhanced UX");

                                col.Text("✓ Color theming and semantic styling");
                            });
                        });

                        card.LineBreak();
                        card.Add(new Span().AddContent("All features implemented using pure C# fluent API - zero HTML knowledge required! 🚀").WithColor(RGBColor.Green));
                    });
                });
            });
        });

        document.Save("EnhancedAccordionStepsShowcase.html", openInBrowser);
        Console.WriteLine("✅ Enhanced Accordion & Steps showcase created successfully!");
        Console.WriteLine("📋 Complete feature demonstration includes:");
        Console.WriteLine("   🎛️ All 5 accordion types with comprehensive configurations");
        Console.WriteLine("   🎨 Color theming and visual state management");
        Console.WriteLine("   🔄 Advanced steps with state tracking and navigation");
        Console.WriteLine("   🖱️ Interactive elements and clickable components");
        Console.WriteLine("   ♿ Enhanced accessibility features");
        Console.WriteLine("   📱 Responsive design patterns");
        Console.WriteLine("   🎯 Real-world usage scenarios");
        Console.WriteLine("💡 Perfect showcase of HtmlForgeX's enhanced capabilities!");
    }
}