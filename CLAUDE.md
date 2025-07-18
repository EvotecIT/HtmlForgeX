# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

HtmlForgeX is a .NET library that simplifies HTML/CSS/JavaScript generation through a fluent API. It enables creating complex HTML documents, pages, and reports without requiring HTML/CSS/JS knowledge. The project includes a PowerShell module and supports multiple .NET frameworks (Standard 2.0, Framework 4.7.2, .NET 8.0).

## Build Commands

### Standard Development Build
```bash
# Build entire solution
dotnet build HtmlForgeX.sln --configuration Release

# Run all tests
dotnet test HtmlForgeX.sln --configuration Release --no-build --verbosity normal

# Run tests with coverage
dotnet test HtmlForgeX.sln --configuration Release --no-build --verbosity normal --logger trx --collect:"XPlat Code Coverage"

# Run examples
dotnet run --project HtmlForgeX.Examples/HtmlForgeX.Examples.csproj

# Run benchmarks
dotnet run --project HtmlForgeX.Benchmarks/HtmlForgeX.Benchmarks.csproj --configuration Release
```

### PowerShell Build Scripts
```powershell
# Build and create NuGet packages
.\Build\BuildPackage.ps1

# Publish to NuGet
.\Build\PublishPackage.ps1

# Build PowerShell module
.\Module\Build\Build-Module.ps1
```

### Testing Individual Components
```bash
# Run specific test file
dotnet test HtmlForgeX.Tests/HtmlForgeX.Tests.csproj --filter "FullyQualifiedName~TestClassName"

# Run with detailed output
dotnet test HtmlForgeX.Tests/HtmlForgeX.Tests.csproj --logger "console;verbosity=detailed"
```

## Code Architecture

### Core Design Patterns

1. **Fluent API Pattern**: All configuration methods return `this` for method chaining
   ```csharp
   element.WithColor(RGBColor.Red).WithPadding("10px").WithBorder();
   ```

2. **Element Hierarchy**: All HTML components inherit from abstract `Element` class
   - `Element` manages parent-child relationships
   - Automatic library registration through `RegisterLibraries()`
   - Document reference propagation

3. **Component Organization**:
   - `Core/`: Base classes (Document, Element, Body, Head, Table)
   - `Containers/`: UI components organized by library (ApexCharts/, Bootstrap/, Tabler/, etc.)
   - `Libraries/`: Library management and resource handling
   - `Resources/`: Embedded CSS/JS files and their C# wrappers
   - `Email/`: Email-specific components with inline styling

### Library Management System

The project uses a sophisticated library management system:
- **Online Mode**: Links to CDN resources
- **Offline Mode**: Embeds resources inline in HTML
- **OfflineWithFiles Mode**: Creates local resource files

Libraries are automatically registered when components are used. Each component knows its dependencies and registers them through `RegisterLibraries()`.

### Important Conventions

1. **Method Naming**: Fluent methods start with `With` or `Add`
2. **Enum Usage**: Extensive use of enums for type-safe configuration
3. **Builder Pattern**: Complex components use builders (e.g., `EmailBoxBuilder`)
4. **Thread Safety**: Use `ConcurrentDictionary` for shared state
5. **Resource Embedding**: JS/CSS files in `Resources/` are embedded resources

### Testing Approach

- **Framework**: MSTest
- **Browser Testing**: Playwright for UI component testing
- **Coverage**: Coverlet for code coverage
- Tests are in `HtmlForgeX.Tests/` with comprehensive coverage

### PowerShell Integration

Special handling for PowerShell compatibility:
- PSObject support in table generation
- PowerShell module in `Module/` directory
- Separate build process for module distribution

## Key Implementation Details

1. **Table Generation**: Supports multiple table types (Bootstrap, DataTables, Tabler) with automatic data extraction via reflection

2. **Email Components**: Special components in `Email/` namespace with inline styling for email client compatibility

3. **SVG Icon System**: Modern SVG-based icon system replacing old CSS icons
   - Icons downloaded on-demand during build
   - Full styling control (size, color, transforms)

4. **Resource Caching**: Resources are deduplicated using HashSets to prevent multiple inclusions

5. **Error Handling**: Thread-safe error collection for build-time issues

## Development Guidelines

1. **Always maintain fluent API pattern** - methods should return `this`
2. **Register libraries in component constructors** - use `RegisterLibraries()`
3. **Follow existing naming conventions** - check similar components
4. **Add tests for new components** - maintain high test coverage
5. **Use embedded resources for offline support** - add to Resources/ directory
6. **Document complex configurations** - add XML comments for public APIs

## Common Tasks

### Adding a New Component
1. Create class inheriting from `Element`
2. Override `RegisterLibraries()` to register dependencies
3. Implement fluent configuration methods
4. Add tests in `HtmlForgeX.Tests/`
5. Add example in `HtmlForgeX.Examples/`

### Adding a New Library
1. Add enum value to `Libraries` enum
2. Create resource wrapper in `Resources/Classes/`
3. Add CSS/JS files to `Resources/Scripts/` or `Resources/Styles/`
4. Update `Library.cs` with CDN links

### Debugging Resource Issues
1. Check if library is registered: breakpoint in `RegisterLibraries()`
2. Verify resource embedding: check `.csproj` for `EmbeddedResource`
3. Test in different library modes: Online, Offline, OfflineWithFiles