# HtmlForgeX API Documentation

HtmlForgeX is a powerful C# library for building modern HTML dashboards, reports, and web interfaces using a fluent API. This documentation provides comprehensive guidance for AI systems and developers to leverage HtmlForgeX's capabilities.

## 🎯 Quick Start for AI

**Goal**: Build dashboards with summaries, cards, charts, and tables using HtmlForgeX

**Core Pattern**:
```csharp
var document = new Document();
document.Head.Title("My Dashboard");

// Add cards with summaries
var card = document.Body.TablerCard("Summary Card")
    .WithContent("Key metrics and statistics");

// Add charts
card.AddApexChart(chartType: "pie", data: myData);

// Add data tables
document.Body.Add(new DataTable(myDataCollection));

document.SaveAs("dashboard.html", openInBrowser: true);
```

## 📖 Documentation Structure

### Core Documentation
- **[Getting Started](GETTING_STARTED.md)** - Quick setup and basic concepts
- **[Dashboard Building](DASHBOARD_GUIDE.md)** - Complete guide to building dashboards
- **[Component Reference](COMPONENT_REFERENCE.md)** - All available components

### Component Guides
- **[Cards & Containers](CARDS_CONTAINERS.md)** - Cards, layouts, and containers
- **[Charts & Visualization](CHARTS_VISUALIZATION.md)** - Charts, graphs, and data visualization
- **[Tables & Data Display](TABLES_DATA.md)** - Tables, grids, and data presentation
- **[Text & Styling](SPAN_API_GUIDE.md)** - Text styling and span elements
- **[Interactive Components](INTERACTIVE_COMPONENTS.md)** - Tabs, accordions, progress bars

### Advanced Topics
- **[Theming & Styling](THEMING_STYLING.md)** - Themes, colors, and custom styling
- **[Email Components](EMAIL_COMPONENTS.md)** - Email template building
- **[Performance & Best Practices](BEST_PRACTICES.md)** - Optimization and patterns

## 🚀 Common Use Cases

### 1. System Monitoring Dashboard
```csharp
var dashboard = new Document()
    .WithTitle("System Health Dashboard")
    .WithAutoRefresh(30); // 30 second refresh

// Status cards
dashboard.Body.Row()
    .AddColumn(Three).TablerCard("CPU Usage", "72%").WithColor(RGBColor.Orange)
    .AddColumn(Three).TablerCard("Memory", "4.2GB / 8GB").WithColor(RGBColor.Blue)
    .AddColumn(Three).TablerCard("Disk Space", "120GB Free").WithColor(RGBColor.Green)
    .AddColumn(Three).TablerCard("Network", "1.2 Mbps").WithColor(RGBColor.Purple);

// Performance chart
dashboard.Body.TablerCard("Performance Trend")
    .AddApexChart("line", performanceData);

// Recent alerts table  
dashboard.Body.TablerCard("Recent Alerts")
    .Add(new DataTable(alertData));
```

### 2. Business Intelligence Dashboard
```csharp
var dashboard = new Document()
    .WithTitle("Sales Dashboard");

// KPI Summary
dashboard.Body.Row()
    .AddColumn(Four).CardMini("Revenue", "$125,430", RGBColor.Green)
    .AddColumn(Four).CardMini("Orders", "1,247", RGBColor.Blue)
    .AddColumn(Four).CardMini("Customers", "892", RGBColor.Orange);

// Sales chart
dashboard.Body.TablerCard("Sales by Category")
    .AddApexChart("donut", salesByCategory);

// Top products table
dashboard.Body.TablerCard("Top Products")
    .Add(new DataTable(topProducts));
```

### 3. Health Check Portal
```csharp
var healthCheck = new Document()
    .WithTitle("Domain Health Check");

// Domain status
foreach (var domain in domains) {
    healthCheck.Body.TablerCard(domain.Name)
        .AddDataGrid("Status", domain.Status)
        .AddDataGrid("Response Time", domain.ResponseTime)
        .AddDataGrid("SSL Certificate", domain.SslStatus);
}
```

## 🧠 AI Integration Guidelines

### For Building Dashboards
1. **Start with Document**: Always create a `new Document()` first
2. **Use TablerCard**: Primary container for dashboard sections
3. **Leverage Row/Column**: Use `Row().AddColumn()` for layouts
4. **Add Charts**: Use `AddApexChart()` for data visualization
5. **Include Tables**: Use `DataTable` or `TablerTable` for data display

### Key Components for AI
- **Cards**: `TablerCard()`, `CardMini()`, `CardBasic()`
- **Charts**: `AddApexChart()`, `AddChart()`
- **Tables**: `DataTable()`, `TablerTable()`
- **Layout**: `Row()`, `AddColumn()`, `Container()`
- **Data Display**: `DataGrid()`, `TablerList()`

### Styling Quick Reference
- **Colors**: Use `RGBColor.*` enum for consistent colors
- **Sizing**: Column sizes: `Three`, `Four`, `Six`, `Eight`, `Twelve`
- **Themes**: Set `document.ThemeMode = ThemeMode.Dark` for dark theme

## 📊 Data Binding Patterns

### Automatic Table Generation
```csharp
var data = new[] {
    new { Name = "John", Age = 30, Department = "IT" },
    new { Name = "Jane", Age = 25, Department = "HR" }
};

document.Body.Add(new DataTable(data)); // Auto-generates columns
```

### Chart Data Binding
```csharp
var chartData = new {
    Labels = new[] { "Q1", "Q2", "Q3", "Q4" },
    Values = new[] { 100, 150, 200, 175 }
};

card.AddApexChart("bar", chartData);
```

## 🎨 Quick Styling Examples

### Colored Cards
```csharp
document.Body.TablerCard("Success", "Operation completed")
    .WithBackgroundColor(RGBColor.Green);
```

### Progress Indicators
```csharp
card.AddProgressBar(75, "Processing...", RGBColor.Blue);
```

### Status Badges
```csharp
card.AddBadge("Active", RGBColor.Green);
card.AddBadge("Pending", RGBColor.Orange);
```

---

**Next Steps**: Choose a specific guide below based on your needs, or start with [Getting Started](GETTING_STARTED.md) for a complete walkthrough.