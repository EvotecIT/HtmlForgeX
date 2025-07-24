using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Containers;

internal class MultiPageDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Multi-Page Site Demo");

        // Create a multi-page document
        var multiPageDoc = new MultiPageDocument(LibraryMode.Online, ThemeMode.Light);

        // Configure shared navigation
        multiPageDoc.WithSharedNavigation(nav => {
                nav.WithLogo("../../../../Assets/Images/WhiteBackground/Logo-evotec.png", "index.html")
                   .WithSticky()
                   .AddItem(item => item
                       .WithText("Home")
                       .WithIcon(TablerIconType.Home)
                       .WithInternalPageId("home"))
                   .AddItem(item => item
                       .WithText("Products")
                       .WithIcon(TablerIconType.Package)
                       .WithInternalPageId("products"))
                   .AddItem(item => item
                       .WithText("Services") 
                       .WithIcon(TablerIconType.Briefcase)
                       .AddDropdownItem("Consulting", "consulting.html")
                       .AddDropdownItem("Support", "support.html")
                       .AddDropdownItem("Training", "training.html"))
                   .AddItem(item => item
                       .WithText("About")
                       .WithIcon(TablerIconType.InfoCircle)
                       .WithInternalPageId("about"))
                   .AddItem(item => item
                       .WithText("Contact")
                       .WithIcon(TablerIconType.Mail)
                       .WithInternalPageId("contact"));
            })
            .WithLayout(TablerLayout.Horizontal)
            .WithSharedFooter("© 2024 HtmlForgeX. All rights reserved.");

        // Add Home page
        multiPageDoc.AddPageWithLayout("home", "index.html", "HtmlForgeX - Home", page => {
            page.Section(section => section
                .WithTitle("Welcome to HtmlForgeX", HeaderLevelTag.H1)
                .WithBackgroundColor(TablerColor.BlueLight)
                .WithPadding(TablerSpacing.ExtraLarge)
                .Add(new TablerText("Build beautiful, responsive web interfaces using C# with our powerful fluent API.").Weight(TablerFontWeight.Medium).Style(TablerTextStyle.Muted)));

            page.Row(row => {
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Avatar().Icon(TablerIconType.Code).BackgroundColor(TablerColor.Primary).Size(AvatarSize.LG);
                        card.Header(h => h.Title("Clean Code"));
                        card.Add(new TablerText("Write HTML, CSS, and JavaScript using strongly-typed C# code with IntelliSense support."));
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Avatar().Icon(TablerIconType.Devices).BackgroundColor(TablerColor.Success).Size(AvatarSize.LG);
                        card.Header(h => h.Title("Responsive Design"));
                        card.Add(new TablerText("Create responsive layouts that work perfectly on desktop, tablet, and mobile devices."));
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Avatar().Icon(TablerIconType.Rocket).BackgroundColor(TablerColor.Info).Size(AvatarSize.LG);
                        card.Header(h => h.Title("Fast Development"));
                        card.Add(new TablerText("Build complex UIs quickly with pre-built components and a fluent API design."));
                    });
                });
            });

            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Get Started"));
                        card.Steps().StepCounting()
                            .AddStep("Install NuGet Package", "Install-Package HtmlForgeX", TablerStepState.Completed)
                            .AddStep("Create Document", "var doc = new Document();", TablerStepState.Completed)
                            .AddStep("Add Components", "doc.Body.Add(...);", TablerStepState.Active)
                            .AddStep("Generate HTML", "doc.Save(\"output.html\");", TablerStepState.Pending);
                    });
                });
            });
        });

        // Add Products page
        multiPageDoc.AddPageWithLayout("products", "products.html", "HtmlForgeX - Products", page => {
            page.Section(section => section
                .WithTitle("Our Products")
                .Add(new TablerText("Explore our comprehensive suite of components and tools.")));

            page.Row(row => {
                var products = new[] {
                    ("Core Library", "Foundation components for HTML generation", TablerColor.Primary),
                    ("Tabler UI", "Modern UI components based on Tabler", TablerColor.Info),
                    ("Bootstrap", "Full Bootstrap 5 component support", TablerColor.Purple),
                    ("Email Builder", "Responsive email template builder", TablerColor.Warning),
                    ("Chart Library", "Data visualization components", TablerColor.Success),
                    ("Form Builder", "Advanced form creation tools", TablerColor.Danger)
                };

                foreach (var (name, description, color) in products) {
                    row.Column(TablerColumnNumber.Four, col => {
                        col.Card(card => {
                            card.Row(cardRow => {
                                cardRow.Column(TablerColumnNumber.Auto, iconCol => {
                                    iconCol.Avatar().Icon(TablerIconType.Package).BackgroundColor(color);
                                });
                                cardRow.Column(textCol => {
                                    textCol.Add(new TablerText(name).Weight(TablerFontWeight.Bold));
                                    textCol.Add(new TablerText(description).Style(TablerTextStyle.Muted));
                                });
                            });
                        });
                    });
                }
            });
        });

        // Add About page
        multiPageDoc.AddPageWithLayout("about", "about.html", "HtmlForgeX - About Us", page => {
            page.Row(row => {
                row.Column(TablerColumnNumber.Eight, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("About HtmlForgeX"));
                        card.Add(new TablerText("HtmlForgeX is a powerful .NET library designed to simplify HTML, CSS, and JavaScript generation through an intuitive fluent API. Our mission is to enable developers to create complex web interfaces without writing raw HTML/CSS/JS code."));
                        card.LineBreak();
                        card.Add(new TablerText("Key Benefits:").Weight(TablerFontWeight.Bold));
                        var ul = new HtmlTag("ul").Class("list-unstyled");
                        ul.Value(new HtmlTag("li", "Type-safe HTML generation"));
                        ul.Value(new HtmlTag("li", "IntelliSense support throughout"));
                        ul.Value(new HtmlTag("li", "No HTML/CSS/JS knowledge required"));
                        ul.Value(new HtmlTag("li", "Extensive component library"));
                        ul.Value(new HtmlTag("li", "Cross-platform support"));
                        card.Add(ul);
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Statistics"));
                        card.DataGrid(grid => {
                            grid.AddItem("Components", "150+");
                            grid.AddItem("Active Users", "10,000+");
                            grid.AddItem("Downloads", "50,000+");
                            grid.AddItem("Contributors", "25+");
                            grid.AddItem("Years Active", "3");
                        });
                    });
                });
            });

            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Our Journey"));
                        card.Tracking()
                            .Block("Project Started", TablerColor.Success)
                            .Block("v1.0 Released", TablerColor.Success)
                            .Block("10K Downloads", TablerColor.Success)
                            .Block("Tabler Integration", TablerColor.Success)
                            .Block("v2.0 Released", TablerColor.Success)
                            .Block("Email Builder", TablerColor.Success)
                            .Block("50K Downloads", TablerColor.Success)
                            .Block("Current", TablerColor.Primary);
                    });
                });
            });
        });

        // Add Contact page
        multiPageDoc.AddPageWithLayout("contact", "contact.html", "HtmlForgeX - Contact", page => {
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Get in Touch"));
                        card.Add(new TablerText("We'd love to hear from you! Whether you have questions, feedback, or need support, don't hesitate to reach out."));
                        card.LineBreak();
                        card.DataGrid(grid => {
                            grid.AddItem("Email", "support@htmlforgex.com");
                            grid.AddItem("GitHub", "github.com/htmlforgex");
                            grid.AddItem("Discord", "discord.gg/htmlforgex");
                            grid.AddItem("Twitter", "@htmlforgex");
                        });
                    });
                });
                row.Column(TablerColumnNumber.Six, col => {
                    col.Card(card => {
                        card.Header(h => h.Title("Office Hours"));
                        card.Alert("Support Available", "Our team is available Monday-Friday, 9 AM - 5 PM EST")
                            .Color(TablerColor.Info)
                            .Icon(TablerIconType.Clock);
                        card.LineBreak();
                        card.Add(new TablerText("For urgent issues, please use our GitHub issue tracker."));
                    });
                });
            });
        });

        // Save all pages to a directory
        multiPageDoc.SaveAll("MultiPageSite", openInBrowser);
        multiPageDoc.Dispose();

        HelpersSpectre.PrintTitle("Multi-page site generated in 'MultiPageSite' directory");
    }
}