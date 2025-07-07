# HtmlForgeX Development Guide

## Table of Contents

1. [Introduction](#introduction)
2. [Architecture Overview](#architecture-overview)
3. [Component Creation Standards](#component-creation-standards)
4. [Testing Requirements](#testing-requirements)
5. [Integration Procedures](#integration-procedures)
6. [Resource Management](#resource-management)
7. [Email System Architecture](#email-system-architecture)
8. [Quality Assurance](#quality-assurance)
9. [Deployment Guidelines](#deployment-guidelines)

---

## Introduction

This guide provides comprehensive standards and procedures for developing components in HtmlForgeX, a C# library that generates modern HTML dashboards and emails using Tabler framework. The library follows a fluent API pattern to make web development accessible to developers without HTML/CSS/JavaScript expertise.

### Core Principles

1. **Zero HTML/CSS/JS Knowledge Required**: Users should accomplish tasks through intuitive C# methods
2. **Fluent API Design**: Method chaining for readable, discoverable code
3. **Framework Agnostic**: Components work across different .NET frameworks
4. **Resource Management**: Automatic CDN and local resource handling
5. **Email Compatibility**: Separate email-optimized components for maximum client support

---

## Architecture Overview

### Core Class Hierarchy

```csharp
Element (abstract base class)
├── Document (root container with configuration)
│   ├── Head (metadata, scripts, styles)
│   └── Body (content container)
├── HtmlTag (generic HTML tag generator)
├── Containers (layout components)
│   ├── TablerCard, TablerRow, TablerColumn
│   ├── ApexCharts, DataTables, VisNetwork
│   └── Email components
└── Tags (specific HTML elements)
    ├── Span, Anchor, TagBundle
    └── All Tabler components
```

### Document Configuration Pattern

Every component must work with the Document's configuration system:

```csharp
public class DocumentConfiguration {
    public ConcurrentBag<string> Errors { get; set; } = new();
    public ConcurrentBag<Libraries> LibrariesRequired { get; set; } = new();
    public bool Online { get; set; } = true;
    public string PathToSave { get; set; } = "";
    // ... other configuration properties
}
```

---

## Component Creation Standards

### 1. Basic Component Structure

Every component must follow this pattern:

```csharp
public class TablerExampleComponent : Element {
    
    // Private properties to store component state
    private string ComponentText { get; set; }
    private TablerColor? Color { get; set; }
    private bool IsDisabled { get; set; }
    
    // Constructor with required parameters
    public TablerExampleComponent(string text) {
        ComponentText = text ?? throw new ArgumentNullException(nameof(text));
    }
    
    // Fluent API methods that return 'this' for chaining
    public TablerExampleComponent SetColor(TablerColor color) {
        Color = color;
        return this;
    }
    
    public TablerExampleComponent Disable() {
        IsDisabled = true;
        return this;
    }
    
    // Library registration for required dependencies
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.Tabler);
        Document?.AddLibrary(Libraries.JQuery); // Only if needed
    }
    
    // HTML generation using HtmlTag
    public override string ToString() {
        var tag = new HtmlTag("div").Class("example-component");
        
        if (Color.HasValue) {
            tag.Class(Color.Value.ToTablerBackground());
        }
        
        if (IsDisabled) {
            tag.Class("disabled");
            tag.Attribute("disabled", "disabled");
        }
        
        tag.Value(ComponentText);
        return tag.ToString();
    }
}
```

### 2. Naming Conventions

- **Classes**: `TablerComponentName` (e.g., `TablerCard`, `TablerAlert`)
- **Properties**: PascalCase (e.g., `CardTitle`, `AlertMessage`)
- **Methods**: PascalCase with descriptive verbs (e.g., `SetTitle()`, `AddContent()`)
- **Enums**: PascalCase with descriptive values (e.g., `TablerColor.Primary`)

### 3. Required Interface Implementation

All components must:

1. **Inherit from Element**: Provides common functionality
2. **Implement RegisterLibraries()**: Register required CSS/JS libraries
3. **Override ToString()**: Generate HTML using HtmlTag
4. **Provide Fluent API**: All configuration methods return `this`
5. **Validate Input**: Throw appropriate exceptions for invalid parameters

### 4. Error Handling Standards

```csharp
// Constructor validation
public TablerCard(string title) {
    if (string.IsNullOrWhiteSpace(title)) {
        throw new ArgumentException("Title cannot be null or empty.", nameof(title));
    }
    Title = title;
}

// Method validation
public TablerCard AddContent(string content) {
    if (content == null) {
        Document?.AddError("Content cannot be null in TablerCard.AddContent()");
        return this;
    }
    Content = content;
    return this;
}
```

### 5. CSS Class Management

Use extension methods for consistent CSS class generation:

```csharp
// For colors
public static string ToTablerBackground(this TablerColor color) {
    return $"bg-{color.ToString().ToLower()}";
}

// For sizes
public static string ToTablerSize(this TablerSize size) {
    return size switch {
        TablerSize.Small => "sm",
        TablerSize.Large => "lg",
        _ => ""
    };
}
```

---

## HtmlForgeX Component Usage Patterns

### Core Design Philosophy
HtmlForgeX follows specific patterns that **must** be adhered to in all examples and implementations:

1. **Direct Component Methods**: Components provide direct methods, not wrapper patterns
2. **Fluent API Chaining**: Methods return the component itself for continued chaining
3. **Lambda-Based Builders**: Complex components use lambda functions for configuration
4. **No HTML/CSS/JS**: Users work with C# components, never raw markup
5. **Hierarchical Building**: Components build through method calls, not manual DOM construction

### ✅ Correct Patterns

#### Span Text Building
```csharp
// CORRECT: Direct span methods with chaining
card.Span("This is inside card").AddContent(" with some color").WithColor(RGBColor.Amber);
card.Span("This is continuing after").AppendContent(" linebreak ").WithColor(RGBColor.RedDevil)
    .AppendContent(" cool?");

// CORRECT: Using Span constructor with chaining
card.Add(new Span().AddContent("This is table with ").WithAlignment(FontAlignment.Center)
    .WithColor(RGBColor.TractorRed).AppendContent("Tabler").WithColor(RGBColor.RedPurple));
```

#### DataGrid Building
```csharp
// CORRECT: Direct dataGrid methods
card.DataGrid(dataGrid => {
    dataGrid.AddItem("Registrar", "Third Party");
    dataGrid.AddItem("Port number", "3306");
    dataGrid.AddItem("Creator", "Przemysław Kłys");
    dataGrid.Title("Domain Information").Content("This is the domain information");
    dataGrid.Title("Expiring").Content(new TablerBadgeSpan("Soon", TablerColor.Azure));
});
```

#### FancyTree Building
```csharp
// CORRECT: Lambda-based tree building
card.FancyTree(fancyTree => {
    fancyTree.AutoScroll(true).MinimumExpandLevel(2);
    fancyTree.Title("Enable TSDebugMode")
        .Icon("https://cdn-icons-png.flaticon.com/512/5610/5610944.png");
    fancyTree.Title("OS Supported")
        .AddNode(new FancyTreeNode("Pre-Check", "icon.png", true))
        .AddNode(node => {
            node.Title("Checking if DB is up and running");
            node.AddNode(nextNode => {
                nextNode.Title("DB is up and running");
                nextNode.AddNode("Testing DB Connection");
            });
        });
});
```

#### Tabs Building
```csharp
// CORRECT: Direct tab methods with lambda content
column.Tabs(tabs => {
    tabs.AddTab("Tab 1", new Strong("Content 1")).Active();
    tabs.AddTab("Tab With Tracking", tab => {
        tab.Text("This is tracking");
        tab.Tracking()
            .Block("Operational", TablerColor.Success)
            .Block("No data", TablerColor.Failed)
            .Block("Downtime", TablerColor.Danger);
    }).Active();
});
```

### ❌ Incorrect Patterns

#### Never Use BasicElement Wrappers
```csharp
// WRONG: Using BasicElement wrappers
content.Add(new BasicElement().Add(heading));
content.Add(new BasicElement().Add(bodyText));

// CORRECT: Direct component methods
content.Span("Heading text").WithFontSize("32px").WithFontWeight(FontWeight.Bold);
content.Span("Body text").WithFontSize("16px").WithColor(new RGBColor("#667382"));
```

#### Never Use Manual HTML/CSS
```csharp
// WRONG: Raw HTML in components
content.SetHtml("<h1 class=\"text-center\">Title</h1>");
content.SetHtml("<div style=\"background-color: #f6f6f6;\">Content</div>");

// CORRECT: Use library components
content.HeaderLevel(HeaderLevelTag.H1, "Title").WithAlignment(FontAlignment.Center);
content.Span("Content").WithBackgroundColor(new RGBColor("#f6f6f6"));
```

### Email Component Patterns

HtmlForgeX provides **TWO email patterns** for different use cases:

#### 1. Direct Email Pattern (Simple Top-to-Bottom)

For simple emails like writing in Outlook - direct content flow:

```csharp
// DIRECT pattern - simple top-to-bottom like Outlook
var email = new Email();
email.Head.AddTitle("Simple Email").AddEmailCoreStyles();

email.Body
    .EmailText("This is simple text")
    .WithFontSize("16px")
    .WithFontFamily("Calibri");

email.Body.EmailTextBox(textBox => {
    textBox.WithFontFamily("Calibri")
           .WithFontSize("15px")
           .AddText(
               "Multi-line text content",
               "Each line flows naturally",
               "Like writing in email client"
           );
});

email.Body.EmailTable(table => {
    table.AddHeader(new[] { "Name", "Value" });
    table.AddRow(new[] { "Item 1", "Value 1" });
});

email.Body.EmailList(list => {
    list.AddItem("First item").WithColor(new RGBColor("#ff0000"));
    list.AddItem("Second item").WithColor(new RGBColor("#008000"));
});
```

#### 2. Layout Email Pattern (Structured Rows/Columns)

For complex layouts with structured rows and columns:

```csharp
// LAYOUT pattern - structured with containers
var email = new Email();
email.Head.AddTitle("Structured Email").AddEmailCoreStyles();

email.Body.EmailBox(emailBox => {
    emailBox.SetPadding("8px"); // Configurable padding
    
    // Row with full-width image
    emailBox.EmailRow(row => {
        row.EmailColumn(col => {
            col.SetWidth("600px");
            col.EmailImage("https://example.com/banner.jpg", "600");
        });
    });
    
    // Row with two columns
    emailBox.EmailRow(row => {
        row.EmailColumn(col => {
            col.SetWidth("50%");
            col.EmailText("Left column");
            col.EmailTable(table => {
                table.AddRow(new[] { "Data", "Value" });
            });
        });
        row.EmailColumn(col => {
            col.SetWidth("50%");
            col.EmailText("Right column");
            col.EmailImage("image.jpg", "300");
        });
    });
});
```

#### Available Email Extension Methods

All email components inherit the natural builder pattern from Element:

**Text Components:**
- `EmailText(string content)` - Simple text with styling
- `EmailText(Action<EmailText> config)` - Text with lambda configuration  
- `EmailTextBox(Action<EmailTextBox> config)` - Multi-line text container

**Media Components:**
- `EmailImage(string source)` - Image with source
- `EmailImage(string source, string width)` - Image with dimensions
- `EmailImage(Action<EmailImage> config)` - Image with lambda configuration

**Structure Components:**
- `EmailTable(Action<EmailTable> config)` - Tables with rows/columns
- `EmailList(Action<EmailList> config)` - Lists with items
- `EmailRow(Action<EmailRow> config)` - Layout rows  
- `EmailColumn(Action<EmailColumn> config)` - Layout columns
- `EmailBox(Action<EmailBox> config)` - Content containers

**Utility:**
- `EmailLineBreak()` - Line breaks

#### Key Design Principles

1. **Two Patterns**: Use Direct for simple emails, Layout for complex structures
2. **Configurable Padding**: EmailBox padding is configurable (default reduced to 16px)
3. **Natural Flow**: Same builder pattern as dashboards
4. **Email-Safe**: All components generate email-client compatible HTML

```csharp
// Dashboard pattern
document.Body.Page(page => {
    page.Row(row => {
        row.Column(column => {
            column.Card(card => {
                card.Span("text").Table(data).DataGrid(grid => {});
            });
        });
    });
});

// Email patterns (same natural structure!)
// Direct: email.Body.EmailText().EmailTable().EmailList()
// Layout: email.Body.EmailBox(box => { box.EmailRow().EmailColumn() })
```

---

## Testing Requirements

### 1. Unit Test Structure

Every component requires comprehensive unit tests:

```csharp
[TestClass]
public class TablerExampleComponentTests {
    
    [TestMethod]
    public void Constructor_ValidInput_CreatesComponent() {
        // Arrange & Act
        var component = new TablerExampleComponent("Test");
        
        // Assert
        Assert.IsNotNull(component);
        StringAssert.Contains(component.ToString(), "Test");
    }
    
    [TestMethod]
    public void SetColor_ValidColor_AddsColorClass() {
        // Arrange
        var component = new TablerExampleComponent("Test");
        
        // Act
        component.SetColor(TablerColor.Primary);
        
        // Assert
        StringAssert.Contains(component.ToString(), "bg-primary");
    }
    
    [TestMethod]
    public void Constructor_NullInput_ThrowsException() {
        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() => 
            new TablerExampleComponent(null));
    }
    
    [TestMethod]
    public void FluentAPI_MethodChaining_ReturnsThis() {
        // Arrange
        var component = new TablerExampleComponent("Test");
        
        // Act
        var result = component.SetColor(TablerColor.Primary).Disable();
        
        // Assert
        Assert.AreSame(component, result);
    }
}
```

### 2. HTML Validation Tests

```csharp
[TestMethod]
public void ToString_GeneratesValidHtml() {
    // Arrange
    var component = new TablerExampleComponent("Test")
        .SetColor(TablerColor.Primary);
    
    // Act
    var html = component.ToString();
    
    // Assert
    Assert.IsTrue(html.Contains("<div"));
    Assert.IsTrue(html.Contains("class=\"example-component bg-primary\""));
    Assert.IsTrue(html.Contains("Test"));
    Assert.IsTrue(html.Contains("</div>"));
}
```

### 3. Integration Tests

```csharp
[TestMethod]
public void Integration_WithDocument_RegistersLibraries() {
    // Arrange
    var document = new Document();
    var component = new TablerExampleComponent("Test");
    
    // Act
    document.Body.AddChild(component);
    
    // Assert
    Assert.IsTrue(document.Configuration.LibrariesRequired.Contains(Libraries.Tabler));
}
```

---

## Integration Procedures

### 1. Library Registration System

Components must register their dependencies:

```csharp
protected internal override void RegisterLibraries() {
    Document?.AddLibrary(Libraries.Tabler);        // Always required
    Document?.AddLibrary(Libraries.JQuery);        // If using jQuery features
    Document?.AddLibrary(Libraries.Bootstrap);     // If using Bootstrap components
    Document?.AddLibrary(Libraries.ApexCharts);    // For charting components
}
```

### 2. Resource Management

All external resources must have:

1. **CDN Links**: For online deployment
2. **Local Resources**: Embedded in assembly for offline use
3. **Version Control**: Specific versions to prevent breaking changes

```csharp
public class TablerLibrary : Library {
    public override string Name => "Tabler";
    public override string Version => "1.3.0";
    public override string CdnLink => "https://cdn.jsdelivr.net/npm/@tabler/core@1.3.0/dist/css/tabler.min.css";
    public override string LocalPath => "HtmlForgeX.Resources.Styles.tabler.min.css";
}
```

### 3. Enum Library System

Create supporting enums for component configuration:

```csharp
public enum TablerColor {
    Primary,
    Secondary,
    Success,
    Info,
    Warning,
    Danger,
    Light,
    Dark,
    Muted
}

public enum TablerSize {
    ExtraSmall,
    Small,
    Medium,
    Large,
    ExtraLarge
}
```

---

## Resource Management

### 1. CDN and Local Resource Handling

```csharp
// Online mode - uses CDN
Document.Configuration.Online = true;

// Offline mode - uses embedded resources
Document.Configuration.Online = false;
```

### 2. Embedding Resources

All CSS/JS files must be embedded as resources:

1. Add files to `Resources/` folder
2. Set Build Action to "Embedded Resource"
3. Reference in Library class with full namespace path

### 3. Custom Resource Injection

```csharp
// Custom CSS
document.Head.AddCustomCss(".my-custom-class { color: red; }");

// Custom JavaScript
document.Head.AddCustomScript("console.log('Custom script loaded');");
```

---

## Email System Architecture

### 1. Email Component Base Class

```csharp
public abstract class EmailElement : Element {
    protected virtual bool UseTableLayout => true;
    protected virtual string EmailSafeCss => "";
    
    protected HtmlTag CreateEmailSafeTag(string tagName) {
        var tag = new HtmlTag(tagName);
        if (UseTableLayout && (tagName == "div" || tagName == "section")) {
            // Convert to table-based layout for email compatibility
            tag = new HtmlTag("table").Attribute("cellspacing", "0").Attribute("cellpadding", "0");
        }
        return tag;
    }
}
```

### 2. Email Template Structure

```csharp
public class EmailDocument : Document {
    protected override void InitializeDefaults() {
        base.InitializeDefaults();
        
        // Email-specific DOCTYPE
        DoctypeType = EmailDoctypeType.XhtmlStrict;
        
        // Email-safe CSS
        Head.AddMetaTag("viewport", "width=device-width, initial-scale=1");
        Head.AddStyleSheet(Libraries.TablerEmail);
    }
}
```

### 3. Email Component Requirements

1. **Table-based Layout**: Use tables for structure, not divs
2. **Inline CSS**: Critical styles must be inline
3. **Email Client Testing**: Test across major email clients
4. **Responsive Design**: Mobile-first approach with media queries
5. **Dark Mode Support**: Automatic image variants

---

## Quality Assurance

### 1. Code Quality Checklist

- [ ] Follows naming conventions
- [ ] Implements fluent API pattern
- [ ] Includes comprehensive error handling
- [ ] Registers required libraries
- [ ] Provides XML documentation
- [ ] Includes unit tests with >90% coverage
- [ ] Validates HTML output
- [ ] Supports both online and offline modes

### 2. Accessibility Requirements

- [ ] ARIA labels for interactive elements
- [ ] Keyboard navigation support
- [ ] Screen reader compatibility
- [ ] Color contrast compliance
- [ ] Focus management
- [ ] Semantic HTML structure

### 3. Performance Standards

- [ ] Minimal memory allocation
- [ ] Efficient string building
- [ ] Lazy loading of resources
- [ ] Optimized CSS/JS bundling
- [ ] Compressed embedded resources

---

## Deployment Guidelines

### 1. Example Creation

Every component must include:

1. **Basic Example**: Simple usage demonstration
2. **Advanced Example**: Complex scenarios with multiple features
3. **Integration Example**: Working with other components
4. **Email Example**: If applicable, email-specific usage

```csharp
// In Examples project
public static void TablerExampleComponentDemo() {
    var document = new Document();
    
    // Basic usage
    document.Body.AddChild(
        new TablerExampleComponent("Hello World")
            .SetColor(TablerColor.Primary)
    );
    
    // Save and optionally open
    document.Save("example-component.html");
    
    if (OpenInBrowser) {
        document.OpenInBrowser();
    }
}
```

### 2. Documentation Requirements

1. **API Documentation**: XML comments on all public members
2. **Usage Examples**: Code samples in documentation
3. **Migration Guide**: If updating existing components
4. **Best Practices**: Recommended usage patterns

### 3. Release Checklist

- [ ] All tests passing
- [ ] Documentation updated
- [ ] Examples created and tested
- [ ] Performance benchmarks met
- [ ] Accessibility validated
- [ ] Cross-browser testing completed
- [ ] NuGet package version updated

---

## Implementation Workflow

### 1. Component Development Process

1. **Planning**: Define component requirements and API
2. **Implementation**: Create component following standards
3. **Testing**: Implement comprehensive test suite
4. **Documentation**: Add XML comments and usage examples
5. **Integration**: Add to Examples project with demo
6. **Validation**: Test in real-world scenarios
7. **Review**: Code review and quality assurance
8. **Deployment**: Merge and update documentation

### 2. Quality Gates

Each component must pass:

1. **Unit Tests**: >90% code coverage
2. **Integration Tests**: Works with Document system
3. **HTML Validation**: Generates valid HTML
4. **Accessibility Audit**: Meets WCAG 2.1 AA standards
5. **Performance Test**: Meets memory and speed requirements
6. **Cross-Platform Test**: Works on Windows, macOS, Linux

### 3. Maintenance Standards

- **Breaking Changes**: Require major version increment
- **New Features**: Require minor version increment
- **Bug Fixes**: Require patch version increment
- **Documentation**: Updated with every change
- **Backward Compatibility**: Maintained for at least 2 major versions

---

This guide ensures consistent, high-quality development of HtmlForgeX components that meet the needs of developers seeking to create modern web interfaces without requiring deep HTML/CSS/JavaScript knowledge.