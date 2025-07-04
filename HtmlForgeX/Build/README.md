# SVG Icon Generator

⚠️ **IMPORTANT: Manual Process Only** ⚠️

This directory contains the PowerShell script to generate SVG icon enums and libraries from tabler-icons.

Icon generation downloads 5000+ SVG files and takes **15+ minutes** to complete. It has been **removed from the automatic build process** to prevent slow builds.

## When to Run

Only regenerate icons when:
- ✅ Setting up the project for the first time
- ✅ Updating to a newer version of tabler-icons
- ✅ Adding new icons that aren't currently available
- ❌ **NOT** on every build (too slow!)

## Quick Start

```powershell
# For production - generate ALL icons (takes 15+ minutes)
pwsh ./GenerateIcons.ps1 -IconSet both -Force

# For development/testing - limited icons (faster)
pwsh ./GenerateIcons.ps1 -IconSet both -MaxIcons 1000 -Force
```

## Generated Files

- **`IconType.cs`** - Enum with all icon types (⚠️ auto-generated, do not edit manually)
- **`SvgIconLibrary.cs`** - Library with embedded SVG content (⚠️ auto-generated, do not edit manually)

Both files are **committed to git** so other developers don't need to regenerate them.

## Script Parameters

| Parameter | Description | Default |
|-----------|-------------|---------|
| `IconSet` | Choose 'outline', 'filled', or 'both' | `both` |
| `MaxIcons` | Limit icons for testing (0 = no limit) | `0` |
| `Force` | Force regeneration even if files exist | `false` |

## Performance

- **Download Time**: 15+ minutes for all 5000+ icons
- **Output Size**: ~2MB of generated C# code
- **Runtime**: Instant (embedded in assembly)

## Why Manual?

The old automatic approach caused:
- ❌ 15+ minute build times on clean builds
- ❌ Unnecessary downloads on every CI run
- ❌ Developer frustration with slow builds

The new manual approach provides:
- ✅ Fast builds (0 seconds for icons)
- ✅ Generated files committed to git
- ✅ Only regenerate when actually needed
- ✅ Developer control over when to update icons

## Migration from TablerIcon

The new SVG system completely replaces the old CSS-based `TablerIcon` class:

```csharp
// OLD (CSS-based)
new TablerIconElement(TablerIcon.Home)

// NEW (SVG-based)
new TablerIconElement(IconType.Home)
```

Key improvements:
- ✅ Full styling control (colors, sizes, transforms)
- ✅ Crisp SVG rendering at any size
- ✅ No external CSS dependencies
- ✅ 5000+ icons vs limited CSS set
