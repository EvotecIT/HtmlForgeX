# HtmlForgeX Component Reference

Complete reference guide for all HtmlForgeX components. This guide is optimized for AI consumption to understand available components and their usage patterns.

## Document Structure

### Document
The root container for all HTML content.

```csharp
var document = new Document();
document.Head.Title("Page Title");
document.Head.Meta("description", "Page description");
document.Body.Add(content);
document.SaveAs("output.html", openInBrowser: true);
```

**Properties:**
- `Head` - Document head section
- `Body` - Document body section  
- `ThemeMode` - Light/Dark theme

### Head Section
Manages document metadata and resources.

```csharp
document.Head
    .Title("Dashboard")
    .Meta("viewport", "width=device-width, initial-scale=1")
    .AddStylesheet("custom.css")
    .AddScript("custom.js");
```

**Methods:**
- `Title(string)` - Set page title
- `Meta(name, content)` - Add meta tag
- `AddStylesheet(url)` - Add CSS file
- `AddScript(url)` - Add JavaScript file

## Layout Components

### Container
Provides page layout structure.

```csharp
// Fluid container (full width)
document.Body.Container(ContainerMode.Fluid);

// Boxed container (centered with max width)
document.Body.Container(ContainerMode.Boxed);
```

### Row and Columns
Bootstrap-based grid system.

```csharp
document.Body.Row()
    .AddColumn(Six).Content("Left half")
    .AddColumn(Six).Content("Right half");

document.Body.Row()
    .AddColumn(Three).Content("25%")
    .AddColumn(Three).Content("25%")
    .AddColumn(Three).Content("25%")
    .AddColumn(Three).Content("25%");
```

**Column Sizes:** `One`, `Two`, `Three`, `Four`, `Five`, `Six`, `Seven`, `Eight`, `Nine`, `Ten`, `Eleven`, `Twelve`

## Card Components

### TablerCard
Primary card component for content organization.

```csharp
var card = document.Body.TablerCard("Card Title");
card.WithContent("Card content goes here");

// With styling
card.WithBackgroundColor(RGBColor.Blue)
    .WithPadding("20px")
    .WithBorder("1px solid #ccc");
```

**Methods:**
- `WithContent(string)` - Set card content
- `WithBackgroundColor(color)` - Set background
- `WithPadding(string)` - Set padding
- `WithBorder(string)` - Set border

### CardMini
Compact cards for KPIs and metrics.

```csharp
document.Body.CardMini(
    title: "Total Sales",
    subtitle: "$125,430",
    color: RGBColor.Green
);

// With icon
document.Body.CardMini("Users", "1,247", RGBColor.Blue)
    .WithIcon("users");
```

**Parameters:**
- `title` - Main label
- `subtitle` - Value/metric
- `color` - Theme color

### CardBasic
Simple title/content cards.

```csharp
document.Body.CardBasic("Card Title", "Card content text");
```

## Data Display Components

### DataTable
Interactive tables with search, sort, and pagination.

```csharp
var data = new[] {
    new { Name = "John", Age = 30, Department = "IT" },
    new { Name = "Jane", Age = 25, Department = "HR" }
};

var table = new DataTable(data)
    .WithSearching(true)
    .WithPaging(true)
    .WithOrdering(true)
    .WithPageLength(25);

card.Add(table);
```

**Features:**
- `WithSearching(bool)` - Enable search
- `WithPaging(bool)` - Enable pagination
- `WithOrdering(bool)` - Enable column sorting
- `WithPageLength(int)` - Rows per page

### TablerTable
Styled HTML tables.

```csharp
var table = new TablerTable(data)
    .WithStriped(true)
    .WithHover(true)
    .WithResponsive(true);

card.Add(table);
```

**Styling:**
- `WithStriped(bool)` - Alternate row colors
- `WithHover(bool)` - Hover effects
- `WithResponsive(bool)` - Mobile responsive

### DataGrid
Key-value pair display with badges.

```csharp
card.AddDataGrid()
    .AddKeyValue("Status", "Online", RGBColor.Green)
    .AddKeyValue("Response Time", "45ms")
    .AddKeyValue("Uptime", "99.9%", RGBColor.Blue);
```

## Chart Components

### ApexCharts Integration
Various chart types for data visualization.

```csharp
// Pie Chart
var pieData = new {
    Labels = new[] { "A", "B", "C" },
    Values = new[] { 30, 50, 20 }
};
card.AddApexChart("pie", pieData);

// Line Chart
var lineData = new {
    Labels = new[] { "Jan", "Feb", "Mar" },
    Series = new[] {
        new { Name = "Sales", Data = new[] { 100, 120, 110 } }
    }
};
card.AddApexChart("line", lineData);

// Bar Chart
var barData = new {
    Labels = new[] { "Q1", "Q2", "Q3" },
    Values = new[] { 100, 150, 120 }
};
card.AddApexChart("bar", barData);

// Donut Chart
card.AddApexChart("donut", pieData);
```

**Chart Types:** `pie`, `donut`, `line`, `bar`, `area`, `column`

## Text and Content Components

### Span
Styled text elements with fluent API.

```csharp
// AddContent creates child spans
var span = new Span()
    .AddContent("Red text").WithColor(RGBColor.Red)
    .AddContent(" Blue text").WithColor(RGBColor.Blue);

// AppendContent modifies current span
var span2 = new Span()
    .AppendContent("Bold text").WithFontWeight(FontWeight.Bold)
    .AppendContent(" Normal text");

document.Body.Add(span);
```

**Styling Methods:**
- `WithColor(color)` - Text color
- `WithBackgroundColor(color)` - Background color
- `WithFontSize(string)` - Font size
- `WithFontWeight(weight)` - Font weight
- `WithAlignment(alignment)` - Text alignment

### Text Helper
Simple text addition to body.

```csharp
document.Body.Text("Simple text");
document.Body.Text("Colored text", RGBColor.Red);
document.Body.Text("Styled text", RGBColor.Blue, "18px");
```

## Interactive Components

### Tabs
Tabbed content with active/disabled states.

```csharp
var tabs = new TablerTabs();
tabs.AddTab("Tab 1", "Content 1", active: true);
tabs.AddTab("Tab 2", "Content 2");
tabs.AddTab("Tab 3", "Content 3", disabled: true);

card.Add(tabs);
```

### Accordion
Expandable/collapsible content sections.

```csharp
var accordion = new TablerAccordion();
accordion.AddSection("Section 1", "Content 1", expanded: true);
accordion.AddSection("Section 2", "Content 2");

card.Add(accordion);
```

### Progress Bars
Progress indicators with different styles.

```csharp
// Basic progress bar
card.AddProgressBar(75, "Processing...", RGBColor.Blue);

// Small progress bar
card.AddProgressSmall(50, RGBColor.Green);

// Indeterminate progress
card.AddProgressIndeterminate("Loading...");
```

## UI Elements

### Badges and Tags
Status indicators and labels.

```csharp
card.AddBadge("Active", RGBColor.Green);
card.AddBadge("Pending", RGBColor.Orange);
card.AddBadge("Error", RGBColor.Red);
```

### Icons
Tabler icon integration.

```csharp
// Icon in content
card.WithIcon("dashboard");

// Standalone icon
document.Body.Add(new TablerIcon("users")
    .WithSize(24)
    .WithColor(RGBColor.Blue));
```

### Avatars
User avatar display.

```csharp
// Image avatar
card.AddAvatar("user.jpg", "John Doe");

// Icon avatar
card.AddAvatar("user", "Jane Doe", RGBColor.Blue);

// Text avatar
card.AddAvatar("JD", "John Doe", RGBColor.Green);
```

### Alerts
Notification components.

```csharp
document.Body.AddAlert("Success message", AlertType.Success, dismissible: true);
document.Body.AddAlert("Warning message", AlertType.Warning);
document.Body.AddAlert("Error message", AlertType.Danger);
```

## List Components

### TablerList
Icon-based list display.

```csharp
var list = new TablerList();
list.AddItem("Item 1", "Description 1", "check");
list.AddItem("Item 2", "Description 2", "x");

card.Add(list);
```

## Specialized Components

### Steps
Process flow indicators.

```csharp
var steps = new TablerSteps();
steps.AddStep("Step 1", completed: true);
steps.AddStep("Step 2", active: true);
steps.AddStep("Step 3");

card.Add(steps);
```

### Tracking
Status tracking with colored blocks.

```csharp
var tracking = new TablerTracking();
tracking.AddStatus("Ordered", RGBColor.Blue, completed: true);
tracking.AddStatus("Shipped", RGBColor.Orange, completed: true);
tracking.AddStatus("Delivered", RGBColor.Green, active: true);

card.Add(tracking);
```

### ScrollingText
Structured scrolling content.

```csharp
var scrolling = new ScrollingText();
scrolling.AddSection("Section 1", "Content for section 1");
scrolling.AddSection("Section 2", "Content for section 2");

card.Add(scrolling);
```

## Email Components

### Email Document
Specialized email template structure.

```csharp
var email = new EmailDocument();
email.Header.WithLogo("logo.png")
    .WithTitle("Newsletter");

email.Body.AddSection("Welcome", "Thanks for subscribing!");
email.Body.AddButton("Visit Website", "https://example.com");

email.Footer.WithText("Unsubscribe | Contact");

email.SaveAs("newsletter.html");
```

## Styling and Theming

### Colors
Extensive color palette available.

```csharp
// Predefined colors
RGBColor.Red, RGBColor.Blue, RGBColor.Green
RGBColor.Orange, RGBColor.Purple, RGBColor.Yellow

// Custom colors
RGBColor.FromHex("#FF5733")
RGBColor.FromRGB(255, 87, 51)
```

### Theme Modes
```csharp
document.ThemeMode = ThemeMode.Light;
document.ThemeMode = ThemeMode.Dark;
```

### Custom CSS
```csharp
document.Head.AddStyle("""
    .custom-class {
        background-color: #f8f9fa;
        padding: 1rem;
    }
""");
```

## Method Chaining Patterns

### Fluent API Examples
```csharp
// Card with multiple components
var card = document.Body.TablerCard("Dashboard")
    .WithBackgroundColor(RGBColor.Light)
    .AddProgressBar(75, "Progress", RGBColor.Blue)
    .AddBadge("Status", RGBColor.Green)
    .Add(new DataTable(data));

// Row with multiple columns
document.Body.Row()
    .AddColumn(Four).TablerCard("Card 1")
    .AddColumn(Four).TablerCard("Card 2") 
    .AddColumn(Four).TablerCard("Card 3");
```

This reference provides comprehensive coverage of all HtmlForgeX components with practical examples for building dashboards and web interfaces.