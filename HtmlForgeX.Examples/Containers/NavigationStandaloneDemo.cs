using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Containers;

internal class NavigationStandaloneDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Navigation Demo - Standalone Components");

        using var document = new Document {
            Head = {
                Title = "Standalone Navigation Demo - HtmlForgeX",
                Author = "HtmlForgeX Examples"
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        // Example 1: Direct navbar addition (non-fluent)
        var navbar1 = new TablerNavbar()
            .WithBrand("Direct Navigation", "#")
            .AddItem("Home", "#")
            .AddItem("About", "#about")
            .AddItem("Contact", "#contact");
        
        document.Body.Add(navbar1);

        document.Body.H2("Direct Navigation Example");
        document.Body.Text("This navbar was created directly and added with Add().");
        
        document.Body.Add(new HtmlTag("hr").Style("margin", "2rem 0"));

        // Example 2: Fluent navbar addition
        document.Body.Navbar(nav => nav
            .WithLogo("../../../../Assets/Images/WhiteBackground/Logo-evotec.png", "#")
            .AddItem(item => item
                .WithText("Dashboard")
                .WithIcon(TablerIconType.Home)
                .Active())
            .AddItem(item => item
                .WithText("Products")
                .WithIcon(TablerIconType.Package)
                .AddDropdownItem("Software", "#software")
                .AddDropdownItem("Hardware", "#hardware"))
            .AddRightItem(item => item
                .WithText("Settings")
                .WithIcon(TablerIconType.Settings)));

        document.Body.H2("Fluent Navigation Example");
        document.Body.Text("This navbar was created using the fluent Body.Navbar() method.");

        document.Body.Add(new HtmlTag("hr").Style("margin", "2rem 0"));

        // Example 3: Complex navigation with full layout
        document.Body.H2("Full Layout with Navigation");
        document.Body.Text("Below is a complete layout with navigation and content:");

        document.Body.Layout(layout => layout
            .WithLayout(TablerLayout.Horizontal)
            .WithNavbar(nav => nav
                .WithBrand("My Application", "#")
                .WithSticky()
                .AddItem("Home", "#home")
                .AddItem("Features", "#features")
                .AddItem("Pricing", "#pricing"))
            .AddPage("home", "Home", page => {
                page.Row(row => {
                    row.Column(TablerColumnNumber.Twelve, col => {
                        col.Card(card => {
                            card.Header(h => h.Title("Welcome"));
                            card.Add(new TablerText("This demonstrates both direct and fluent API usage for navigation."));
                        });
                    });
                });
            })
            .WithFooter("© 2024 HtmlForgeX Demo"));

        document.Save("NavigationStandaloneDemo.html", openInBrowser);
    }
}