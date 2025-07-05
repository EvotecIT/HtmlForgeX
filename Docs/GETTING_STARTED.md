# Getting Started with HtmlForgeX

Quick start guide for building HTML dashboards and interfaces with HtmlForgeX. This guide gets you up and running in minutes.

## Installation

```xml
<!-- Add to your .csproj file -->
<PackageReference Include="HtmlForgeX" Version="latest" />
```

```csharp
// Add using statement
using HtmlForgeX;
```

## Basic Concepts

### 1. Document Structure
Every HtmlForgeX application starts with a `Document`:

```csharp
var document = new Document();
document.Head.Title("My First Dashboard");
document.Body.Add(/* your content */);
document.SaveAs("output.html", openInBrowser: true);
```

### 2. Fluent API
HtmlForgeX uses method chaining for intuitive building:

```csharp
document.Body.Row()
    .AddColumn(Six).TablerCard("Left Side")
    .AddColumn(Six).TablerCard("Right Side");
```

### 3. Component Hierarchy
- **Document** → **Body** → **Containers** → **Components**
- Components can contain other components
- Use cards as primary content containers

## Your First Dashboard

### Step 1: Create Basic Structure
```csharp
using HtmlForgeX;

var dashboard = new Document();
dashboard.Head.Title("Sales Dashboard");

// Save and view
dashboard.SaveAs("dashboard.html", openInBrowser: true);
```

### Step 2: Add Summary Cards
```csharp
// Add KPI cards
dashboard.Body.Row()
    .AddColumn(Three).CardMini("Revenue", "$125,430", RGBColor.Green)
    .AddColumn(Three).CardMini("Orders", "1,247", RGBColor.Blue)
    .AddColumn(Three).CardMini("Customers", "892", RGBColor.Orange)
    .AddColumn(Three).CardMini("Growth", "+12.5%", RGBColor.Purple);
```

### Step 3: Add a Chart
```csharp
var chartCard = dashboard.Body.TablerCard("Sales Trend");

var chartData = new {
    Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" },
    Values = new[] { 100, 120, 110, 140, 135 }
};

chartCard.AddApexChart("line", chartData);
```

### Step 4: Add a Data Table
```csharp
var tableCard = dashboard.Body.TablerCard("Top Products");

var products = new[] {
    new { Product = "Widget A", Sales = 250, Revenue = "$12,500" },
    new { Product = "Widget B", Sales = 180, Revenue = "$9,000" },
    new { Product = "Widget C", Sales = 120, Revenue = "$6,000" }
};

tableCard.Add(new DataTable(products));
```

### Complete Example
```csharp
using HtmlForgeX;

class Program {
    static void Main() {
        var dashboard = new Document();
        dashboard.Head.Title("Sales Dashboard");
        
        // KPI Summary
        dashboard.Body.Row()
            .AddColumn(Three).CardMini("Revenue", "$125,430", RGBColor.Green)
            .AddColumn(Three).CardMini("Orders", "1,247", RGBColor.Blue)
            .AddColumn(Three).CardMini("Customers", "892", RGBColor.Orange)
            .AddColumn(Three).CardMini("Growth", "+12.5%", RGBColor.Purple);
        
        // Chart
        var chartCard = dashboard.Body.TablerCard("Sales Trend");
        var chartData = new {
            Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May" },
            Values = new[] { 100, 120, 110, 140, 135 }
        };
        chartCard.AddApexChart("line", chartData);
        
        // Data Table
        var tableCard = dashboard.Body.TablerCard("Top Products");
        var products = new[] {
            new { Product = "Widget A", Sales = 250, Revenue = "$12,500" },
            new { Product = "Widget B", Sales = 180, Revenue = "$9,000" },
            new { Product = "Widget C", Sales = 120, Revenue = "$6,000" }
        };
        tableCard.Add(new DataTable(products));
        
        dashboard.SaveAs("sales-dashboard.html", openInBrowser: true);
    }
}
```

## Common Patterns

### 1. Layout Patterns
```csharp
// Full width
dashboard.Body.Container(ContainerMode.Fluid);

// Centered with max width
dashboard.Body.Container(ContainerMode.Boxed);

// Two-column layout
dashboard.Body.Row()
    .AddColumn(Eight).TablerCard("Main Content")
    .AddColumn(Four).TablerCard("Sidebar");

// Four-column grid
dashboard.Body.Row()
    .AddColumn(Three).Content("25%")
    .AddColumn(Three).Content("25%")
    .AddColumn(Three).Content("25%")
    .AddColumn(Three).Content("25%");
```

### 2. Data Binding
```csharp
// From objects
var data = GetSalesData(); // Returns IEnumerable<object>
tableCard.Add(new DataTable(data));

// From anonymous objects
var data = new[] {
    new { Name = "John", Sales = 1000 },
    new { Name = "Jane", Sales = 1200 }
};
tableCard.Add(new DataTable(data));
```

### 3. Styling
```csharp
// Colors
card.WithBackgroundColor(RGBColor.Blue);
text.WithColor(RGBColor.Red);

// Custom CSS
document.Head.AddStyle(".custom { color: red; }");

// Theme
document.ThemeMode = ThemeMode.Dark;
```

## Quick Reference

### Essential Components
- `Document()` - Root container
- `TablerCard(title)` - Primary content container
- `CardMini(title, value, color)` - KPI cards
- `DataTable(data)` - Interactive tables
- `AddApexChart(type, data)` - Charts

### Layout Components
- `Row()` - Horizontal container
- `AddColumn(size)` - Column in row
- `Container(mode)` - Page container

### Data Display
- `AddDataGrid()` - Key-value pairs
- `AddProgressBar()` - Progress indicators
- `AddBadge()` - Status badges
- `Text()` - Simple text

### Column Sizes
- `Three` = 25% width
- `Four` = 33% width  
- `Six` = 50% width
- `Eight` = 66% width
- `Twelve` = 100% width

### Chart Types
- `"pie"` - Pie chart
- `"donut"` - Donut chart
- `"line"` - Line chart
- `"bar"` - Bar chart
- `"area"` - Area chart

### Colors
- `RGBColor.Red`, `RGBColor.Blue`, `RGBColor.Green`
- `RGBColor.Orange`, `RGBColor.Purple`, `RGBColor.Yellow`
- `RGBColor.FromHex("#FF5733")`

## Next Steps

1. **Read the [Dashboard Guide](DASHBOARD_GUIDE.md)** for complete dashboard patterns
2. **Check [Component Reference](COMPONENT_REFERENCE.md)** for all available components
3. **Explore Examples** in the HtmlForgeX.Examples project
4. **Learn Advanced Features** in specialized guides

## Common Questions

**Q: How do I add custom CSS?**
```csharp
document.Head.AddStyle("/* your CSS here */");
```

**Q: How do I make tables searchable?**
```csharp
var table = new DataTable(data).WithSearching(true);
```

**Q: How do I auto-refresh the page?**
```csharp
document.Head.Meta("refresh", "30"); // 30 seconds
```

**Q: How do I change themes?**
```csharp
document.ThemeMode = ThemeMode.Dark;
```

**Q: How do I add icons?**
```csharp
card.WithIcon("dashboard"); // Tabler icons
```

You're now ready to build professional dashboards with HtmlForgeX! Start with simple components and gradually add complexity as needed.