# Parallel Page Generation in HtmlForgeX

## Overview
HtmlForgeX now supports parallel page generation for multi-page websites, providing significant performance improvements when generating multiple HTML files.

## Key Features

### 1. Sequential Generation (Traditional)
```csharp
var multiPageDoc = new MultiPageDocument(LibraryMode.Online, ThemeMode.Light);
multiPageDoc.SaveAll("output-directory", false);
```

### 2. Parallel Generation (Performance)
```csharp
var multiPageDoc = new MultiPageDocument(LibraryMode.Online, ThemeMode.Light);
await multiPageDoc.SaveAllAsync("output-directory", false);
```

## Implementation Details

### MultiPageDocument Class
- `SaveAll()` - Synchronous, sequential file generation
- `SaveAllAsync()` - Asynchronous, parallel file generation using Task.WhenAll()

### Performance Benefits
- Pages are generated in parallel, reducing total generation time
- Particularly effective for sites with many pages or complex content
- Example: 10 pages with 50ms processing each
  - Sequential: ~500ms total
  - Parallel: ~50-100ms total (depending on CPU cores)

## Example Usage

### Basic Multi-Page Site with Parallel Generation
```csharp
var multiPageDoc = new MultiPageDocument(LibraryMode.Online, ThemeMode.Light);

// Configure shared navigation
multiPageDoc.WithSharedNavigation(nav => nav
    .WithLogo("logo.png", "index.html")
    .AddItem("Home", "index.html")
    .AddItem("Products", "products.html")
    .AddItem("About", "about.html"));

// Add pages
multiPageDoc.AddPageWithLayout("home", "index.html", "Welcome", page => {
    page.H1("Welcome to Our Site");
    // ... page content
});

multiPageDoc.AddPageWithLayout("products", "products.html", "Products", page => {
    page.H1("Our Products");
    // ... page content
});

// Generate all pages in parallel
await multiPageDoc.SaveAllAsync("output-directory", false);
```

### Performance Comparison Example
```csharp
// Sequential
var sw1 = Stopwatch.StartNew();
multiPageDoc.SaveAll("sequential-output", false);
sw1.Stop();
Console.WriteLine($"Sequential: {sw1.ElapsedMilliseconds}ms");

// Parallel
var sw2 = Stopwatch.StartNew();
await multiPageDoc.SaveAllAsync("parallel-output", false);
sw2.Stop();
Console.WriteLine($"Parallel: {sw2.ElapsedMilliseconds}ms");
```

## Demo Files Created

1. **MultiPageParallelDemo.cs** - Simple examples showing sequential vs parallel generation
2. **MultiPagePerformanceDemo.cs** - Comprehensive benchmark with 100+ products, categories, and timing measurements

## Best Practices

1. Use `SaveAllAsync()` for sites with 3+ pages
2. The performance benefit increases with:
   - Number of pages
   - Complexity of each page
   - Available CPU cores
3. Both methods produce identical output files
4. Parallel generation maintains all navigation links and shared components correctly

## Technical Implementation

The parallel implementation uses:
- `Task.WhenAll()` for concurrent file writing
- Thread-safe document generation
- Proper async/await patterns throughout
- No shared state issues between pages

This feature makes HtmlForgeX suitable for generating large documentation sites, product catalogs, and multi-page reports with significant time savings.