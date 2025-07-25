# Naming Convention Updates for Multi-Page Examples

## Files Renamed
1. `MultiPageParallelDemo.cs` → `MultiPageParallelGeneration.cs`
2. `MultiPagePerformanceDemo.cs` → `MultiPagePerformanceBenchmark.cs`

## Classes Renamed
1. `MultiPageParallelDemo` → `MultiPageParallelGeneration`
2. `MultiPagePerformanceDemo` → `MultiPagePerformanceBenchmark`

## HTML Output Naming Convention
Following the pattern of other examples (e.g., `ChartsApexBasicDemo.html`):

### MultiPageParallelGeneration outputs:
- `MultiPageParallelGeneration_Sequential/` (directory with pages)
- `MultiPageParallelGeneration_Parallel/` (directory with pages)
- `MultiPageParallelGeneration_BenchmarkSequential/` (directory with pages)
- `MultiPageParallelGeneration_BenchmarkParallel/` (directory with pages)

### MultiPagePerformanceBenchmark outputs:
- `MultiPagePerformanceBenchmark_Sequential/` (directory with pages)
- `MultiPagePerformanceBenchmark_Parallel/` (directory with pages)

## Method Signatures
Both examples now use synchronous `Create()` methods:
```csharp
public static void Create(bool openInBrowser = false)
```

Internally they use `.Wait()` for async operations to maintain consistency with other examples.

## Alphabetical Ordering in Program.cs
The examples are now properly ordered alphabetically:
```csharp
MultiPageDemo.Create(openInBrowser);                    // 🌐 MULTI-PAGE SITE DEMO
MultiPageParallelGeneration.Create(openInBrowser);      // ⚡ MULTI-PAGE PARALLEL GENERATION
MultiPagePerformanceBenchmark.Create(openInBrowser);    // 📊 MULTI-PAGE PERFORMANCE BENCHMARK
NavigationDemo.Create(openInBrowser);                   // 🧭 NAVIGATION DEMO - Single Page
NavigationStandaloneDemo.Create(openInBrowser);         // 🧭 NAVIGATION DEMO - Standalone Examples
NavigationVerticalDemo.Create(openInBrowser);           // 🧭 NAVIGATION DEMO - Vertical Layout
```

## Consistency with HtmlForgeX Patterns
✅ Class names follow the pattern: `[Feature][Type]` (e.g., `MultiPageParallelGeneration`)
✅ HTML output follows the pattern: `[ClassName]_[Variant]` 
✅ Methods use synchronous signatures with internal async handling
✅ Proper alphabetical ordering maintained
✅ Clear, descriptive names that explain the purpose