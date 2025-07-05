# HtmlForgeX Span API Guide

This guide explains how to use the Span API in HtmlForgeX for creating styled text content. The API has been fixed to work intuitively with proper fluent chaining.

## Overview

The Span API provides several methods for creating styled text:

1. **AddContent()** - Creates child spans (nested structure)
2. **AppendContent()** - Creates sibling spans (flat structure) 
3. **AddColoredText()** - Simplified method for colored text
4. **AddStyledText()** - Comprehensive styling method
5. **Body.Text()** - Simple text addition method

## AddContent() Method

Creates child spans within a parent span. All chained calls return wrappers that point to the same root span.

**Usage:**
```csharp
var span = new Span()
    .AddContent("First part").WithColor(RGBColor.Red)
    .AddContent(" second part").WithColor(RGBColor.Blue)
    .AddContent(" third part").WithColor(RGBColor.Green);

document.Body.Add(span);
```

**Generated HTML:**
```html
<span>
    <span style="color: #FF0000">First part</span>
    <span style="color: #0000FF"> second part</span>
    <span style="color: #008000"> third part</span>
</span>
```

**Key Points:**
- Returns wrapper objects that all reference the same root span
- Each AddContent() call creates a new child span
- Styling applies to the individual child spans
- Adding any wrapper to document shows complete content

## AppendContent() Method

Modifies the span's content directly and returns the same span instance for continued chaining.

**Usage:**
```csharp
var span = new Span()
    .AppendContent("First").WithColor(RGBColor.Red)
    .AppendContent(" Second").WithColor(RGBColor.Blue)
    .AppendContent(" Third").WithColor(RGBColor.Green);

document.Body.Add(span);
```

**Generated HTML:**
```html
<span style="color: #008000">First Second Third</span>
```

**Key Points:**
- Returns the same span instance (not wrappers)
- Content is concatenated into the span's Content property
- Only the final styling in the chain is applied
- Best used for building content without individual styling

## AddColoredText() Method

Simplified method for adding colored text segments as child spans.

**Usage:**
```csharp
var span = new Span()
    .AddColoredText("Red text", RGBColor.Red)
    .AddColoredText(" Blue text", RGBColor.Blue)
    .AddColoredText(" Green text", RGBColor.Green);

document.Body.Add(span);
```

**Generated HTML:**
```html
<span>
    <span style="color: #FF0000">Red text</span>
    <span style="color: #0000FF"> Blue text</span>
    <span style="color: #008000"> Green text</span>
</span>
```

## AddStyledText() Method

Comprehensive method for adding fully styled text segments.

**Usage:**
```csharp
var span = new Span()
    .AddStyledText("Bold Red", RGBColor.Red, "16px", FontWeight.Bold)
    .AddStyledText(" Normal Blue", RGBColor.Blue)
    .AddStyledText(" Large Green", RGBColor.Green, "24px");

document.Body.Add(span);
```

**Generated HTML:**
```html
<span>
    <span style="color: #FF0000; font-size: 16px; font-weight: bold">Bold Red</span>
    <span style="color: #0000FF"> Normal Blue</span>
    <span style="color: #008000; font-size: 24px"> Large Green</span>
</span>
```

## Body.Text() Method

Simple method for adding standalone text spans directly to the document body.

**Usage:**
```csharp
document.Body.Text("Red Text", RGBColor.Red);
document.Body.Text(" Blue Text", RGBColor.Blue, "20px");
document.Body.Text(" Normal Text");
```

**Generated HTML:**
```html
<span style="color: #FF0000">Red Text</span>
<span style="color: #0000FF; font-size: 20px"> Blue Text</span>
<span> Normal Text</span>
```

## Mixed Usage

You can combine AddContent() and AppendContent() in the same chain:

**Usage:**
```csharp
var span = new Span()
    .AddContent("Child span").WithColor(RGBColor.Red)
    .AppendContent(" appended to root").WithColor(RGBColor.Blue);

document.Body.Add(span);
```

This creates a child span with "Child span" and appends " appended to root" to the root span.

## Available Styling Methods

All styling methods work on Span objects:

- `WithColor(RGBColor color)`
- `WithBackgroundColor(RGBColor backgroundColor)`
- `WithFontSize(string fontSize)`
- `WithLineHeight(string lineHeight)`
- `WithFontWeight(FontWeight fontWeight)`
- `WithFontStyle(FontStyle fontStyle)`
- `WithFontVariant(FontVariant fontVariant)`
- `WithFontFamily(string fontFamily)`
- `WithAlignment(FontAlignment alignment)`
- `WithTextDecoration(TextDecoration textDecoration)`
- `WithTextTransform(TextTransform textTransform)`
- `WithDirection(Direction direction)`
- `WithDisplay(Display display)`
- `WithOpacity(double? opacity)`

## Best Practices

1. **Use AddContent()** when you need individual styling for each text segment
2. **Use AppendContent()** when building content without per-segment styling
3. **Use AddColoredText()** for simple colored text segments
4. **Use AddStyledText()** for complex styling requirements
5. **Use Body.Text()** for simple standalone text additions
6. **Chain methods fluently** - all methods return appropriate objects for continued chaining

## Common Patterns

### Multi-colored inline text:
```csharp
var coloredSpan = new Span()
    .AddColoredText("Error: ", RGBColor.Red)
    .AddColoredText("Connection failed", RGBColor.Orange)
    .AddColoredText(" (Code: 404)", RGBColor.Gray);
```

### Styled headers with emphasis:
```csharp
var header = new Span()
    .AddStyledText("Warning", RGBColor.Orange, "18px", FontWeight.Bold)
    .AddStyledText(": System maintenance in progress", RGBColor.Black, "14px");
```

### Simple text sequence:
```csharp
document.Body.Text("Welcome ", RGBColor.Green);
document.Body.Text("to HtmlForgeX!", RGBColor.Blue, "16px");
```

The Span API now provides intuitive, predictable behavior that works as developers expect!