# Dashboard Building Guide

This guide shows how to build professional dashboards using HtmlForgeX. Perfect for AI systems that need to create monitoring dashboards, business intelligence interfaces, and data visualization portals.

## Dashboard Architecture

### 1. Basic Dashboard Structure
```csharp
var dashboard = new Document();
dashboard.Head.Title("My Dashboard");
dashboard.Head.Meta("refresh", "30"); // Auto-refresh every 30 seconds

// Header row with summary cards
var summaryRow = dashboard.Body.Row();

// Main content area
var mainRow = dashboard.Body.Row();

// Charts and detailed data
var detailRow = dashboard.Body.Row();

dashboard.SaveAs("dashboard.html", openInBrowser: true);
```

### 2. Layout Patterns

#### Full-Width Dashboard
```csharp
dashboard.Body.Container(ContainerMode.Fluid) // Full width
    .Row()
    .AddColumn(Twelve).TablerCard("Full Width Content");
```

#### Responsive Grid Layout
```csharp
dashboard.Body.Row()
    .AddColumn(Six).TablerCard("Chart Area")     // 50% width
    .AddColumn(Six).TablerCard("Data Table");    // 50% width

dashboard.Body.Row()
    .AddColumn(Three).CardMini("KPI 1")          // 25% width
    .AddColumn(Three).CardMini("KPI 2")          // 25% width
    .AddColumn(Three).CardMini("KPI 3")          // 25% width
    .AddColumn(Three).CardMini("KPI 4");         // 25% width
```

## Summary Cards

### 1. KPI Cards (Key Performance Indicators)
```csharp
// Revenue card
dashboard.Body.Row()
    .AddColumn(Three).CardMini(
        title: "Total Revenue",
        subtitle: "$1,234,567",
        color: RGBColor.Green
    ).WithIcon("dollar-sign");

// User count card
dashboard.Body.Row()
    .AddColumn(Three).CardMini(
        title: "Active Users", 
        subtitle: "8,491",
        color: RGBColor.Blue
    ).WithIcon("users");

// Growth rate card
dashboard.Body.Row()
    .AddColumn(Three).CardMini(
        title: "Growth Rate",
        subtitle: "+12.5%",
        color: RGBColor.Orange
    ).WithIcon("trending-up");
```

### 2. Status Summary Cards
```csharp
var statusCard = dashboard.Body.TablerCard("System Status");

statusCard.AddDataGrid()
    .AddKeyValue("Database", "Online", RGBColor.Green)
    .AddKeyValue("API Server", "Online", RGBColor.Green)
    .AddKeyValue("Cache", "Degraded", RGBColor.Orange)
    .AddKeyValue("Queue", "Offline", RGBColor.Red);
```

### 3. Metric Cards with Progress
```csharp
var metricsCard = dashboard.Body.TablerCard("Performance Metrics");

metricsCard.AddProgressBar(85, "CPU Usage (85%)", RGBColor.Orange);
metricsCard.AddProgressBar(60, "Memory Usage (60%)", RGBColor.Blue);
metricsCard.AddProgressBar(95, "Disk Usage (95%)", RGBColor.Red);
```

## Charts and Visualization

### 1. Pie Charts for Distribution
```csharp
var chartCard = dashboard.Body.TablerCard("Sales by Category");

var pieData = new {
    Labels = new[] { "Electronics", "Clothing", "Books", "Sports" },
    Values = new[] { 35, 25, 20, 20 }
};

chartCard.AddApexChart("pie", pieData);
```

### 2. Line Charts for Trends
```csharp
var trendCard = dashboard.Body.TablerCard("Revenue Trend");

var lineData = new {
    Labels = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun" },
    Series = new[] {
        new { Name = "2023", Data = new[] { 100, 120, 110, 130, 125, 140 } },
        new { Name = "2024", Data = new[] { 110, 125, 115, 135, 130, 145 } }
    }
};

trendCard.AddApexChart("line", lineData);
```

### 3. Bar Charts for Comparisons
```csharp
var comparisonCard = dashboard.Body.TablerCard("Monthly Comparison");

var barData = new {
    Labels = new[] { "Q1", "Q2", "Q3", "Q4" },
    Values = new[] { 450, 520, 480, 610 }
};

comparisonCard.AddApexChart("bar", barData);
```

### 4. Donut Charts with Legend
```csharp
var donutCard = dashboard.Body.TablerCard("Traffic Sources");

var donutData = new {
    Labels = new[] { "Direct", "Organic", "Social", "Email", "Paid" },
    Values = new[] { 40, 25, 15, 12, 8 }
};

donutCard.AddApexChart("donut", donutData);
```

## Data Tables

### 1. Basic Data Table
```csharp
var tableCard = dashboard.Body.TablerCard("Recent Orders");

var orders = new[] {
    new { ID = "ORD-001", Customer = "John Doe", Amount = 250.00, Status = "Shipped" },
    new { ID = "ORD-002", Customer = "Jane Smith", Amount = 125.50, Status = "Processing" },
    new { ID = "ORD-003", Customer = "Bob Johnson", Amount = 75.25, Status = "Delivered" }
};

tableCard.Add(new DataTable(orders));
```

### 2. Interactive DataTable with Search
```csharp
var interactiveCard = dashboard.Body.TablerCard("Product Inventory");

var inventory = GetInventoryData(); // Your data source

var dataTable = new DataTable(inventory)
    .WithSearching(true)
    .WithPaging(true)
    .WithOrdering(true)
    .WithPageLength(25);

interactiveCard.Add(dataTable);
```

### 3. Styled Table with Status Indicators
```csharp
var statusTable = dashboard.Body.TablerCard("Server Status");

var servers = new[] {
    new { 
        Name = "Web-01", 
        Status = "Online", 
        CPU = "45%", 
        Memory = "60%",
        Uptime = "99.9%" 
    },
    new { 
        Name = "DB-01", 
        Status = "Online", 
        CPU = "78%", 
        Memory = "85%",
        Uptime = "99.8%" 
    }
};

statusTable.Add(new TablerTable(servers)
    .WithStriped(true)
    .WithHover(true)
    .WithResponsive(true));
```

## Real-World Dashboard Examples

### 1. System Monitoring Dashboard
```csharp
var monitoringDashboard = new Document();
monitoringDashboard.Head.Title("System Monitoring")
    .Meta("refresh", "30"); // Auto-refresh

// Header KPIs
monitoringDashboard.Body.Row()
    .AddColumn(Three).CardMini("CPU", "72%", RGBColor.Orange)
    .AddColumn(Three).CardMini("Memory", "4.2GB", RGBColor.Blue)
    .AddColumn(Three).CardMini("Disk", "120GB", RGBColor.Green)
    .AddColumn(Three).CardMini("Network", "1.2Mbps", RGBColor.Purple);

// Performance chart
var performanceCard = monitoringDashboard.Body.TablerCard("Performance Over Time");
performanceCard.AddApexChart("line", GetPerformanceData());

// Recent events table
var eventsCard = monitoringDashboard.Body.TablerCard("Recent Events");
eventsCard.Add(new DataTable(GetRecentEvents()));

monitoringDashboard.SaveAs("monitoring.html");
```

### 2. Sales Dashboard
```csharp
var salesDashboard = new Document();
salesDashboard.Head.Title("Sales Dashboard");

// Revenue summary
salesDashboard.Body.Row()
    .AddColumn(Four).CardMini("Today's Revenue", "$12,450", RGBColor.Green)
    .AddColumn(Four).CardMini("This Month", "$345,280", RGBColor.Blue)
    .AddColumn(Four).CardMini("This Year", "$2,150,840", RGBColor.Orange);

// Charts row
salesDashboard.Body.Row()
    .AddColumn(Six).TablerCard("Sales by Category")
        .AddApexChart("donut", GetSalesByCategoryData())
    .AddColumn(Six).TablerCard("Monthly Trend")
        .AddApexChart("line", GetMonthlyTrendData());

// Top products table
salesDashboard.Body.TablerCard("Top Selling Products")
    .Add(new DataTable(GetTopProductsData()));

salesDashboard.SaveAs("sales-dashboard.html");
```

### 3. Health Check Dashboard
```csharp
var healthDashboard = new Document();
healthDashboard.Head.Title("Health Check Dashboard")
    .Meta("refresh", "60");

// Overall status
healthDashboard.Body.Row()
    .AddColumn(Twelve).TablerCard("System Health Overview")
        .AddBadge("All Systems Operational", RGBColor.Green);

// Service status cards
var servicesRow = healthDashboard.Body.Row();

foreach (var service in GetServices()) {
    var serviceCard = servicesRow.AddColumn(Four).TablerCard(service.Name);
    
    serviceCard.AddDataGrid()
        .AddKeyValue("Status", service.Status, GetStatusColor(service.Status))
        .AddKeyValue("Response Time", service.ResponseTime)
        .AddKeyValue("Last Check", service.LastCheck)
        .AddKeyValue("Uptime", service.Uptime);
}

// Historical uptime chart
healthDashboard.Body.TablerCard("Uptime History")
    .AddApexChart("area", GetUptimeHistoryData());

healthDashboard.SaveAs("health-check.html");
```

## Dashboard Styling

### 1. Dark Theme
```csharp
dashboard.ThemeMode = ThemeMode.Dark;
dashboard.Head.AddStyle("""
    .dark-card {
        background-color: #1a1a1a;
        border: 1px solid #333;
    }
""");
```

### 2. Custom Colors
```csharp
// Define custom color scheme
var primaryColor = RGBColor.FromHex("#007bff");
var successColor = RGBColor.FromHex("#28a745");
var warningColor = RGBColor.FromHex("#ffc107");
var dangerColor = RGBColor.FromHex("#dc3545");

// Apply to cards
dashboard.Body.TablerCard("Status")
    .WithBackgroundColor(successColor);
```

### 3. Auto-Refresh
```csharp
// Refresh every 30 seconds
dashboard.Head.Meta("refresh", "30");

// Or with JavaScript for more control
dashboard.Head.AddScript("""
    setInterval(() => {
        location.reload();
    }, 30000);
""");
```

## Best Practices for Dashboard Development

### 1. Performance
- Use pagination for large data tables
- Implement client-side filtering when possible
- Minimize the number of chart series
- Use appropriate chart types for data

### 2. User Experience
- Provide loading indicators for async data
- Use consistent color schemes
- Implement responsive design
- Include meaningful titles and labels

### 3. Data Presentation
- Sort tables by most relevant column
- Use appropriate number formatting
- Highlight important metrics
- Group related information

### 4. Maintenance
- Implement error handling
- Add data validation
- Use configuration files for settings
- Document dashboard purposes and data sources

This guide provides everything needed to build professional, functional dashboards using HtmlForgeX. The examples can be adapted for any domain or use case by changing the data sources and styling to match your requirements.