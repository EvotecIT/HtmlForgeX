# HtmlForgeX Navigation Examples

## Overview
HtmlForgeX provides flexible navigation components that can be used in multiple ways, following the library's principle of offering both direct instantiation and fluent API patterns.

## Basic Navigation

### Method 1: Direct Instantiation
```csharp
// Create navbar directly
var navbar = new TablerNavbar()
    .WithLogo("logo.png", "/")
    .WithSticky()
    .AddItem("Home", "/")
    .AddItem("About", "/about")
    .AddItem("Contact", "/contact");

document.Body.Add(navbar);
```

### Method 2: Fluent API
```csharp
// Create navbar using fluent API
document.Body.Navbar(nav => nav
    .WithLogo("logo.png", "/")
    .WithSticky()
    .AddItem("Home", "/")
    .AddItem("About", "/about")
    .AddItem("Contact", "/contact"));
```

## Navigation with Dropdowns

```csharp
document.Body.Navbar(nav => nav
    .WithBrand("My App", "/")
    .AddItem(item => item
        .WithText("Products")
        .WithIcon(TablerIconType.Package)
        .AddDropdownItem("Software", "/software")
        .AddDropdownItem("Hardware", "/hardware")
        .AddDropdownItem("Services", "/services"))
    .AddRightItem(item => item
        .WithText("Account")
        .WithIcon(TablerIconType.User)
        .WithBadge("Pro", TablerColor.Success)));
```

## Full Layout with Navigation

### Single Page Application Style
```csharp
document.Body.Layout(layout => layout
    .WithLayout(TablerLayout.Horizontal)
    .WithNavbar(nav => nav
        .WithLogo("logo.png")
        .AddItem("Dashboard", "#dashboard")
        .AddItem("Reports", "#reports")
        .AddItem("Settings", "#settings"))
    .AddPage("dashboard", "Dashboard", page => {
        page.Row(row => {
            // Page content here
        });
    })
    .AddPage("reports", "Reports", page => {
        // Reports content
    })
    .WithFooter("© 2024 My Company"));
```

### Vertical Sidebar Navigation
```csharp
document.Body.Layout(layout => layout
    .WithLayout(TablerLayout.Vertical)
    .WithNavbar(nav => nav
        .WithBrand("Admin Panel")
        .AddItem(item => item
            .WithText("Dashboard")
            .WithIcon(TablerIconType.Home)
            .WithInternalPageId("dashboard"))
        .AddItem(item => item
            .WithText("Users")
            .WithIcon(TablerIconType.Users)
            .WithInternalPageId("users")
            .WithBadge("23", TablerColor.Danger))));
```

## Multi-Page Website Generation

```csharp
// Create a multi-page website
var multiPageDoc = new MultiPageDocument(LibraryMode.Online, ThemeMode.Light);

// Configure shared navigation
multiPageDoc.WithSharedNavigation(nav => nav
    .WithLogo("logo.png", "index.html")
    .AddItem("Home", "index.html")
    .AddItem("Products", "products.html")
    .AddItem("About", "about.html")
    .AddItem("Contact", "contact.html"));

// Add pages
multiPageDoc.AddPageWithLayout("home", "index.html", "Welcome", page => {
    // Home page content
});

multiPageDoc.AddPageWithLayout("products", "products.html", "Our Products", page => {
    // Products page content
});

// Generate all files
multiPageDoc.SaveAll("output-directory");
```

## Navigation Styles and Options

### Sticky Navigation
```csharp
nav.WithSticky(); // Stays at top when scrolling
```

### Dark Navigation
```csharp
nav.WithDark(); // Dark theme navigation
```

### Navigation with Different Expand Points
```csharp
nav.WithExpand(TablerNavbarExpand.Large); // Collapse on smaller screens
```

### Icons and Badges
```csharp
.AddItem(item => item
    .WithText("Notifications")
    .WithIcon(TablerIconType.Bell, TablerColor.Warning)
    .WithBadge("5", TablerColor.Danger));
```

## Best Practices

1. **Use Fluent API for Inline Configuration**: When building the document structure, use the fluent API methods like `Body.Layout()` and `Body.Navbar()`

2. **Direct Instantiation for Reusable Components**: Create navigation components directly when you need to reuse them across multiple pages

3. **Consistent Navigation**: Use `MultiPageDocument` for multi-page sites to ensure consistent navigation across all pages

4. **Mobile Consideration**: Always test navigation on different screen sizes; the collapse behavior is automatic

5. **Icon Usage**: Use icons sparingly but consistently to improve navigation clarity

## Complete Example

```csharp
using var document = new Document {
    Head = { Title = "My Application" },
    LibraryMode = LibraryMode.Online
};

document.Body.Layout(layout => layout
    .WithLayout(TablerLayout.Horizontal)
    .WithNavbar(nav => nav
        .WithLogo("assets/logo.png", "/")
        .WithSticky()
        .AddItem("Home", "#home")
        .AddItem(item => item
            .WithText("Features")
            .WithIcon(TablerIconType.Star)
            .AddDropdownItem("Core Features", "#core")
            .AddDropdownItem("Advanced", "#advanced"))
        .AddItem("Pricing", "#pricing")
        .AddRightItem(item => item
            .WithText("Sign In")
            .WithIcon(TablerIconType.Login)))
    .AddPage("home", "Home", page => {
        page.H1("Welcome to My Application");
        page.Row(row => {
            row.Column(TablerColumnNumber.Twelve, col => {
                col.Card(card => {
                    card.Header(h => h.Title("Getting Started"));
                    card.Add(new TablerText("Build amazing web applications without writing HTML/CSS/JS!"));
                });
            });
        });
    })
    .WithFooter("© 2024 My Company. All rights reserved."));

document.Save("index.html", true);
```