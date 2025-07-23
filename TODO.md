# HtmlForgeX TODO - Tabler Feature Implementation Plan

## Overview
This document outlines the implementation plan for Tabler features missing in HtmlForgeX. The goal is to provide a fluent, C#-friendly API for HTML-challenged developers while maintaining consistency with existing HtmlForgeX patterns.

## Implementation Philosophy
- **Fluent Interface**: All components should support method chaining
- **Type Safety**: Use enums instead of strings where possible
- **Builder Pattern**: Support both direct instantiation and lambda configuration
- **Predictable API**: Follow existing HtmlForgeX naming conventions
- **No HTML Required**: Abstract all HTML/CSS complexity

## Component Status Overview

### ✅ Already Implemented
- **Alerts**: `TablerAlerts` with all variations
- **Cards**: `TablerCard` with comprehensive features
- **Tables**: `TablerTable`, `DataTablesTable`, `BootstrapTable`
- **Badges**: `TablerBadgeSpan`, `TablerBadgeButton`, `TablerBadgeLink`
- **Progress Bars**: `TablerProgressBar`
- **Tabs**: `TablerTabs`, `TablerTabsPanel`
- **Icons**: `TablerIcon` with migration helper
- **Lists**: `TablerList`
- **Dividers**: `TablerDivider`
- **Avatars**: `TablerAvatar`
- **Accordion**: `TablerAccordion`
- **Steps**: `TablerSteps`
- **Tags**: `TablerTag`
- **Timeline**: `TablerTimeline`
- **Toasts**: `TablerToast`
- **Modals**: `TablerModal`
- **Forms**: `TablerForm`, `TablerInput`, `TablerSelect`, `TablerInputMask`

### 🔄 Partially Implemented (Need Enhancement)
- **Cards**: Missing ribbon, stamps, hover effects
- **Alerts**: Missing list support, minor alerts
- **Tables**: Missing mobile-responsive view

### ❌ Not Implemented (Priority Order)

## Phase 1: Core Interactive Components (High Priority)

### ✅ Modals (`TablerModal`)
**Source Reference**: `/preview/pages/modals.html`
```csharp
// Proposed API
element.Modal(modal => {
    modal.Title("Confirm Action")
        .Size(TablerModalSize.Large) // Small, Default, Large, FullWidth
        .Scrollable()
        .Content(content => {
            content.Text("Are you sure?");
        })
        .Footer(footer => {
            footer.Button("Cancel", TablerColor.Secondary).Dismiss()
                  .Button("Confirm", TablerColor.Primary).Submit();
        });
});

// Enum needed
public enum TablerModalSize { Small, Default, Large, FullWidth }
```

### 3. Tooltips & Popovers (`TablerTooltip`, `TablerPopover`)
**Source Reference**: `/preview/pages/tooltip.html`
```csharp
// Proposed API
element.Tooltip("Save changes")
    .Position(TablerTooltipPosition.Top)
    .Trigger(TablerTooltipTrigger.Hover);

element.Popover("More Info", pop => {
    pop.Content("Extra details here")
       .Placement(TablerPopoverPlacement.Right);
});
```

### 4. Forms Enhancement (`TablerForm`, `TablerInput`)
**Source Reference**: `/preview/pages/form-elements.html`
```csharp
// Proposed API
element.Form(form => {
    form.Input("email", input => {
        input.Type(InputType.Email)
             .Label("Email Address")
             .Placeholder("your@email.com")
             .Required()
             .Icon(TablerIconType.Mail)
             .Validation(ValidationState.Invalid, "Please enter valid email");
    });
    
    form.Select("country", select => {
        select.Label("Country")
              .Options(countries)
              .Multiple()
              .Searchable();
    });
    
    form.InputMask("phone", mask => {
        mask.Pattern("+1 (999) 999-9999")
            .Label("Phone Number");
    });
});

// Enums needed
public enum InputType { Text, Email, Password, Number, Date, Time, File, Tel, Url }
public enum ValidationState { Valid, Invalid, Warning }
```


### 5. Button Component (`TablerButton`)
**Source Reference**: `/preview/pages/buttons.html`
```csharp
// Proposed API
element.Button("Submit", TablerColor.Primary)
       .Size(TablerButtonSize.Large)
       .Icon(TablerIcon.Send)
       .OnClick("handleSubmit");
```
## Phase 2: Navigation & Layout Components

### 6. Pagination (`TablerPagination`)
**Source Reference**: `/preview/pages/pagination.html`
```csharp
// Proposed API
element.Pagination(pagination => {
    pagination.CurrentPage(3)
              .TotalPages(10)
              .ShowPrevNext()
              .PrevText("Previous")
              .NextText("Next")
              .OnPageChange("handlePageChange"); // JS callback
});

// Descriptive pagination
pagination.Descriptive()
         .PrevDescription("Getting Started")
         .NextDescription("Installation Guide");
```

### 7. Breadcrumbs (`TablerBreadcrumb`)
**Source Reference**: `/preview/pages/navigation.html`
```csharp
// Proposed API
element.Breadcrumb(breadcrumb => {
    breadcrumb.Item("Home", "/")
              .Item("Products", "/products")
              .Item("Electronics", "/products/electronics")
              .Current("Laptops"); // No link for current
});
```

### 8. Navigation (`TablerNavigation`)
**Source Reference**: `/preview/pages/navigation.html`
```csharp
// Proposed API
element.Navigation(nav => {
    nav.Item("Dashboard").Icon(TablerIconType.Home).Active()
       .Item("Users").Icon(TablerIconType.Users).Badge("5", TablerColor.Red)
       .Dropdown("Settings", dropdown => {
           dropdown.Item("Profile")
                   .Item("Security")
                   .Separator()
                   .Item("Logout");
       });
});
```

## Phase 3: Data Display Components

### 9. DataGrid Enhancement (`TablerDataGrid`)
**Source Reference**: `/preview/pages/datagrid.html`
- Add sorting capabilities
- Add filtering support
- Add pagination integration
- Add column customization

### 10. Empty States (`TablerEmpty`)
**Source Reference**: `/preview/pages/empty.html`
```csharp
// Proposed API
element.Empty(empty => {
    empty.Icon(TablerIconType.Search)
         .Title("No results found")
         .Description("Try adjusting your search criteria")
         .Action("Clear filters", TablerColor.Primary);
});
```

## Phase 4: Visual Enhancement Components

### 11. Carousel (`TablerCarousel`)
**Source Reference**: `/preview/pages/carousel.html`
```csharp
// Proposed API
element.Carousel(carousel => {
    carousel.AutoPlay(5000)
            .ShowIndicators()
            .ShowControls()
            .Slide(slide => {
                slide.Image("/image1.jpg")
                     .Caption("First slide");
            });
});
```

### 12. Lightbox (`TablerLightbox`)
**Source Reference**: `/preview/pages/lightbox.html`
```csharp
// Proposed API
element.Lightbox(lightbox => {
    lightbox.Gallery("vacation-photos")
            .Image("/photo1.jpg", "Beach sunset")
            .Image("/photo2.jpg", "Mountain view");
});
```

### 13. Offcanvas (`TablerOffcanvas`)
**Source Reference**: `/preview/pages/offcanvas.html`
```csharp
// Proposed API
element.Offcanvas(offcanvas => {
    offcanvas.Position(OffcanvasPosition.Right)
             .Title("Filters")
             .Backdrop()
             .Content(content => {
                 // Add filter controls
             });
});

// Enum needed
public enum OffcanvasPosition { Left, Right, Top, Bottom }
```

## Phase 5: Specialized Components

### 14. Star Rating (`TablerStarRating`)
**Source Reference**: `/preview/pages/stars-rating.html`
```csharp
// Proposed API
element.StarRating(rating => {
    rating.Value(4.5)
          .MaxStars(5)
          .ReadOnly(false)
          .ShowValue()
          .OnChange("handleRatingChange");
});
```

### 15. Color Picker (`TablerColorPicker`)
**Source Reference**: `/preview/pages/colorpicker.html`
```csharp
// Proposed API
element.ColorPicker(picker => {
    picker.Value("#3b82f6")
          .Format(ColorFormat.Hex) // Hex, RGB, HSL
          .ShowAlpha()
          .Swatches(presetColors);
});
```


## Phase 6: Enhancement of Existing Components

### 17. Card Enhancements
**Source Reference**: `/preview/pages/cards.html`
- Add ribbon support: `card.Ribbon("NEW", TablerColor.Red, RibbonPosition.TopRight)`
- Add stamp support: `card.Stamp("DRAFT", TablerColor.Yellow)`
- Add hover effects: `card.HoverEffect(CardHoverEffect.Lift)`
- Add status indicators: `card.StatusIndicator(TablerColor.Success, StatusPosition.Top)`

### 18. Alert Enhancements
**Source Reference**: `/preview/pages/alerts.html`

### 19. Table Mobile Responsive
**Source Reference**: `/preview/pages/tables.html`
- Add mobile-responsive mode that stacks columns
- Add data-label attributes for mobile view

## Implementation Guidelines

### 1. File Organization
```
HtmlForgeX/Containers/Tabler/
├── Forms/
│   ├── TablerForm.cs
│   ├── TablerInput.cs
│   ├── TablerSelect.cs
│   └── TablerInputMask.cs
├── Navigation/
│   ├── TablerPagination.cs
│   ├── TablerBreadcrumb.cs
│   └── TablerNavigation.cs
├── Modals/
│   ├── TablerModal.cs
│   └── TablerModalSize.cs
└── [other components...]
```

### 2. Common Patterns to Follow

**Fluent Interface Pattern**:
```csharp
public TablerModal Title(string title)
{
    _title = title;
    return this;
}
```

**Lambda Configuration Pattern**:
```csharp
public TablerModal Content(Action<Element> configure)
{
    var contentElement = new Element("div").AddClass("modal-body");
    configure(contentElement);
    _content = contentElement;
    return this;
}
```

**Enum Usage**:
- Create enums in `Enums` subfolder
- Use descriptive names
- Include extension methods for CSS class mapping

### 3. Testing Strategy
- Create example file for each new component
- Test all component variations
- Ensure proper HTML output
- Verify CSS class application
- Test with both light and dark themes

### 4. Documentation Requirements
- XML documentation for all public methods
- Example usage in method documentation
- Create example files in HtmlForgeX.Examples

## Priority Implementation Order

1. **Week 1-2**: Phase 1 (Modals, Tooltips/Popovers, Buttons, Forms)
2. **Week 3**: Phase 2 (Navigation components)
3. **Week 4**: Phase 3 (Data display components)
4. **Week 5**: Phase 4 (Visual components)
5. **Week 6**: Phase 5 (Specialized components)
6. **Week 7**: Phase 6 (Enhancements to existing)

## Source References

All implementations should reference the corresponding Tabler preview files:
- Base path: `/Ignore/BuildMe/tabler--tabler-core-1.3.0/preview/pages/`
- Use the HTML structure as guidance
- Maintain CSS class compatibility
- Ensure JavaScript integration points

## Success Criteria

- Components follow HtmlForgeX fluent API patterns
- No HTML knowledge required to use components
- Strong typing with enums and proper IntelliSense
- Consistent with existing component behavior
- Examples demonstrate all features
- Compatible with existing theme system

---

# Extended Layout System Plan

## Overview
This section outlines enhancements to the HtmlForgeX layout system to provide more flexible spacing, multi-column cards, and modern grid capabilities while maintaining the fluent API design.

## Current State Analysis
- **Grid System**: Bootstrap-based with `col-1` through `col-12`
- **Spacing**: TablerMargin and TablerPadding enums (0-5)
- **Row Types**: Default, Deck, Cards
- **Limitations**: No gap/gutter support, fixed column sizes, no multi-row spanning

## Phase 1: Gap and Gutter Support

### 1. Grid Gap Utilities (`TablerGap`)
**Implementation**: New enum for Bootstrap's gap utilities
```csharp
public enum TablerGap
{
    Gap0,    // gap-0
    Gap1,    // gap-1
    Gap2,    // gap-2
    Gap3,    // gap-3 (default)
    Gap4,    // gap-4
    Gap5,    // gap-5
    // Directional gaps
    RowGap0, RowGap1, RowGap2, RowGap3, RowGap4, RowGap5,
    ColumnGap0, ColumnGap1, ColumnGap2, ColumnGap3, ColumnGap4, ColumnGap5
}

// Extension method
public static string ToClass(this TablerGap gap) => gap switch
{
    TablerGap.Gap0 => "gap-0",
    TablerGap.RowGap3 => "row-gap-3",
    TablerGap.ColumnGap3 => "column-gap-3",
    // ... etc
};

// API Usage
row.WithGap(TablerGap.Gap4)
   .WithGutters(TablerGutter.X3Y2); // gx-3 gy-2
```

### 2. Gutter Control (`TablerGutter`)
```csharp
public enum TablerGutter
{
    None,     // g-0
    Small,    // g-2
    Default,  // g-3
    Large,    // g-4
    ExtraLarge, // g-5
    // Specific X/Y gutters
    X0Y0, X1Y1, X2Y2, X3Y3, X4Y4, X5Y5,
    X2Y3, X3Y2, X4Y2, // Common combinations
}

// Fluent API
page.Row(row => {
    row.WithGutters(TablerGutter.Large)
       .Card(card => { /* ... */ })
       .Card(card => { /* ... */ });
});
```

## Phase 2: Advanced Column System

### 3. Multi-Column Cards (`TablerColumnSpan`)
```csharp
public class TablerColumnAdvanced : TablerColumn
{
    // New properties
    private int? _span;
    private int? _offset;
    private Dictionary<string, int> _responsiveSpans;
    
    // Fluent methods
    public TablerColumnAdvanced Span(int columns)
    {
        _span = columns;
        UpdateClasses();
        return this;
    }
    
    public TablerColumnAdvanced Offset(int columns)
    {
        _offset = columns;
        return this;
    }
    
    public TablerColumnAdvanced ResponsiveSpan(string breakpoint, int columns)
    {
        _responsiveSpans[breakpoint] = columns;
        return this;
    }
}

// Usage examples
row.Column(col => {
    col.Span(6)           // col-6
       .Offset(3)         // offset-3
       .ResponsiveSpan("md", 4)  // col-md-4
       .ResponsiveSpan("lg", 3)  // col-lg-3
       .Card(card => {
           card.Title("Wide Card")
               .Content("This card spans multiple columns");
       });
});

// Shorthand for common patterns
row.WideCard(8, card => { /* Takes 8 columns */ });
row.CenteredCard(6, card => { /* 6 columns with auto margins */ });
```

### 4. CSS Grid Support (`TablerGrid`)
```csharp
public class TablerGrid : Element
{
    public TablerGrid Columns(int count)
    {
        Style($"display: grid; grid-template-columns: repeat({count}, 1fr);");
        return this;
    }
    
    public TablerGrid AutoFit(int minWidth = 250)
    {
        Style($"display: grid; grid-template-columns: repeat(auto-fit, minmax({minWidth}px, 1fr));");
        return this;
    }
    
    public TablerGrid Gap(int pixels)
    {
        Style($"gap: {pixels}px;");
        return this;
    }
}

// Usage
element.Grid(grid => {
    grid.AutoFit(300)
        .Gap(20)
        .Card(card => { /* Auto-sizing cards */ });
});
```

## Phase 3: Layout Presets and Helpers

### 5. Common Layout Patterns
```csharp
public static class TablerLayouts
{
    // Dashboard layout: sidebar + main content
    public static TablerRow DashboardLayout(Action<TablerColumn> sidebar, Action<TablerColumn> content)
    {
        return new TablerRow()
            .Column(col => col.Span(3).ResponsiveSpan("md", 2), sidebar)
            .Column(col => col.Span(9).ResponsiveSpan("md", 10), content);
    }
    
    // Card grid with consistent spacing
    public static TablerRow CardGrid(int cardsPerRow, params Action<TablerCard>[] cards)
    {
        var row = new TablerRow().WithGutters(TablerGutter.Default);
        int colSize = 12 / cardsPerRow;
        
        foreach (var cardConfig in cards)
        {
            row.Column(col => col.Span(colSize).ResponsiveSpan("sm", 6).ResponsiveSpan("md", colSize))
               .Card(cardConfig);
        }
        return row;
    }
    
    // Masonry layout
    public static Element MasonryLayout(params Action<TablerCard>[] cards)
    {
        var container = new Element("div")
            .AddClass("masonry-container")
            .Style("column-count: 3; column-gap: 1rem;");
            
        foreach (var cardConfig in cards)
        {
            var card = new TablerCard().Style("break-inside: avoid; margin-bottom: 1rem;");
            cardConfig(card);
            container.Add(card);
        }
        return container;
    }
}

// Usage
page.Add(TablerLayouts.CardGrid(3,
    card => card.Title("Card 1"),
    card => card.Title("Card 2"),
    card => card.Title("Card 3")
));
```

### 6. Spacing Utilities Enhancement
```csharp
public static class SpacingExtensions
{
    // Chainable spacing for any element
    public static T WithSpacing<T>(this T element, int? margin = null, int? padding = null) where T : Element
    {
        if (margin.HasValue) element.AddClass($"m-{margin}");
        if (padding.HasValue) element.AddClass($"p-{padding}");
        return element;
    }
    
    public static T WithResponsiveSpacing<T>(this T element, string breakpoint, int margin, int padding) where T : Element
    {
        element.AddClass($"m-{breakpoint}-{margin} p-{breakpoint}-{padding}");
        return element;
    }
    
    // Quick spacing presets
    public static T Compact<T>(this T element) where T : Element => element.WithSpacing(1, 2);
    public static T Comfortable<T>(this T element) where T : Element => element.WithSpacing(3, 3);
    public static T Spacious<T>(this T element) where T : Element => element.WithSpacing(4, 4);
}
```

---

# DataTables Enhancement Plan

## Overview
Extend DataTables support to expose more of the powerful DataTables.net API while maintaining the simple, fluent interface for C# developers.

## Current DataTables Support
- Basic options: Paging, Searching, Ordering, ScrollX
- Table styling through BootstrapTableStyle
- Automatic ID generation and initialization

## Phase 1: Core DataTables Features

### 1. Advanced Configuration (`DataTablesOptions`)
```csharp
public class DataTablesOptions
{
    // Display options
    public int? PageLength { get; set; } = 10;
    public int[] LengthMenu { get; set; } = new[] { 10, 25, 50, 100 };
    public bool StateSave { get; set; } = false;
    public string ScrollY { get; set; } // e.g., "400px"
    public bool ScrollCollapse { get; set; }
    
    // Feature flags
    public bool AutoWidth { get; set; } = true;
    public bool DeferRender { get; set; } = false;
    public bool Processing { get; set; } = true;
    public bool ServerSide { get; set; } = false;
    
    // Language customization
    public DataTablesLanguage Language { get; set; }
    
    // Dom positioning
    public string Dom { get; set; } = "lfrtip";
}

public class DataTablesLanguage
{
    public string Search { get; set; } = "Search:";
    public string LengthMenu { get; set; } = "Show _MENU_ entries";
    public string Info { get; set; } = "Showing _START_ to _END_ of _TOTAL_ entries";
    public string InfoEmpty { get; set; } = "Showing 0 to 0 of 0 entries";
    public string InfoFiltered { get; set; } = "(filtered from _MAX_ total entries)";
    public string LoadingRecords { get; set; } = "Loading...";
    public string Processing { get; set; } = "Processing...";
    public string ZeroRecords { get; set; } = "No matching records found";
    public DataTablesPaginate Paginate { get; set; }
}

// Usage
table.Configure(options => {
    options.PageLength = 25;
    options.LengthMenu = new[] { 10, 25, 50, -1 }; // -1 for "All"
    options.ScrollY = "400px";
    options.Language.Search = "Filter:";
    options.Dom = "Bfrtip"; // With buttons
});
```

### 2. Column Definition Support
```csharp
public class DataTablesColumn
{
    public string Data { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public bool Searchable { get; set; } = true;
    public bool Orderable { get; set; } = true;
    public bool Visible { get; set; } = true;
    public string Width { get; set; }
    public string DefaultContent { get; set; }
    public string ClassName { get; set; }
    public string Render { get; set; } // JS function as string
    public DataTablesColumnType Type { get; set; }
}

public enum DataTablesColumnType
{
    String,
    Numeric,
    Date,
    DateTime,
    Html,
    Currency
}

// Fluent API
table.Column("Name", col => {
    col.Title("Full Name")
       .Width("200px")
       .Searchable(true);
})
.Column("Age", col => {
    col.Type(DataTablesColumnType.Numeric)
       .ClassName("text-center");
})
.Column("Salary", col => {
    col.Type(DataTablesColumnType.Currency)
       .Render("$.fn.dataTable.render.number(',', '.', 2, '$')");
})
.Column("Actions", col => {
    col.Orderable(false)
       .Searchable(false)
       .DefaultContent("<button class='btn btn-sm btn-primary'>Edit</button>");
});
```

### 3. Export and Button Extensions
```csharp
public class DataTablesButtons
{
    public bool Copy { get; set; }
    public bool Excel { get; set; }
    public bool Csv { get; set; }
    public bool Pdf { get; set; }
    public bool Print { get; set; }
    public bool ColVis { get; set; } // Column visibility
    public List<CustomButton> Custom { get; set; }
}

public class CustomButton
{
    public string Text { get; set; }
    public string ClassName { get; set; }
    public string Action { get; set; } // JS function
}

// Usage
table.EnableButtons(buttons => {
    buttons.Excel = true;
    buttons.Pdf = true;
    buttons.ColVis = true;
    buttons.Custom.Add(new CustomButton {
        Text = "Refresh",
        ClassName = "btn-success",
        Action = "function() { table.ajax.reload(); }"
    });
});
```

## Phase 2: Advanced Features

### 4. Server-Side Processing Support
```csharp
public class DataTablesAjax
{
    public string Url { get; set; }
    public string Type { get; set; } = "POST";
    public string DataSrc { get; set; } = "data";
    public Dictionary<string, string> Headers { get; set; }
}

// API
table.ServerSide(ajax => {
    ajax.Url = "/api/data/users";
    ajax.Type = "POST";
    ajax.Headers["Authorization"] = "Bearer token";
});

// Generate proper Ajax configuration
table.OnDraw("function(settings, json) { console.log('Data loaded'); }");
```

### 5. Row Callbacks and Events
```csharp
public class DataTablesCallbacks
{
    public string CreatedRow { get; set; }
    public string DrawCallback { get; set; }
    public string InitComplete { get; set; }
    public string RowCallback { get; set; }
    public string FooterCallback { get; set; }
}

// Usage
table.Callbacks(cb => {
    cb.CreatedRow = @"function(row, data, dataIndex) {
        if (data.age > 50) {
            $(row).addClass('highlight');
        }
    }";
    
    cb.InitComplete = @"function(settings, json) {
        this.api().columns().every(function() {
            var column = this;
            var select = $('<select><option value=""""></option></select>')
                .appendTo($(column.footer()).empty())
                .on('change', function() {
                    column.search($(this).val()).draw();
                });
        });
    }";
});
```

### 6. Responsive Extension
```csharp
public class DataTablesResponsive
{
    public bool Enable { get; set; }
    public ResponsiveBreakpoint[] Breakpoints { get; set; }
    public bool Details { get; set; } = true;
    public string DetailsType { get; set; } = "inline"; // or "column"
}

// Usage
table.Responsive(responsive => {
    responsive.Enable = true;
    responsive.DetailsType = "column";
    responsive.Breakpoints = new[] {
        new ResponsiveBreakpoint { Name = "desktop", Width = 1024 },
        new ResponsiveBreakpoint { Name = "tablet", Width = 768 },
        new ResponsiveBreakpoint { Name = "mobile", Width = 480 }
    };
});
```

### 7. Search Builder and Advanced Filtering
```csharp
public class DataTablesSearchBuilder
{
    public bool Enable { get; set; }
    public SearchBuilderConfig Config { get; set; }
}

// Enable SearchBuilder
table.SearchBuilder(builder => {
    builder.Enable = true;
    builder.Config.DefaultCondition = "contains";
    builder.Config.DepthLimit = 3;
});

// Column-specific search
table.ColumnSearch("Age", search => {
    search.Type = SearchType.Range;
    search.Min = 18;
    search.Max = 65;
});
```

## Phase 3: Integration Features

### 8. State Management
```csharp
public class DataTablesState
{
    public bool Save { get; set; }
    public int Duration { get; set; } = 7200; // 2 hours
    public string SaveCallback { get; set; }
    public string LoadCallback { get; set; }
}

// Usage
table.StateManagement(state => {
    state.Save = true;
    state.Duration = 86400; // 24 hours
    state.SaveCallback = "function(settings, data) { localStorage.setItem('DataTables_' + settings.sInstance, JSON.stringify(data)); }";
});
```

### 9. Row Grouping
```csharp
public class DataTablesRowGroup
{
    public string DataSrc { get; set; }
    public string StartRender { get; set; }
    public string EndRender { get; set; }
    public bool Enable { get; set; }
}

// Usage
table.RowGrouping(group => {
    group.Enable = true;
    group.DataSrc = "department";
    group.StartRender = @"function(rows, group) {
        return group + ' (' + rows.count() + ' employees)';
    }";
});
```

### 10. Fixed Columns and Headers
```csharp
public class DataTablesFixed
{
    public int? LeftColumns { get; set; }
    public int? RightColumns { get; set; }
    public bool FixedHeader { get; set; }
    public bool FixedFooter { get; set; }
}

// Usage
table.Fixed(fixed => {
    fixed.LeftColumns = 2;
    fixed.FixedHeader = true;
    fixed.FixedFooter = true;
});
```

## Implementation Examples

### Complete DataTables Example
```csharp
document.Body.DataTable(data, table => {
    // Basic configuration
    table.Configure(options => {
        options.PageLength = 25;
        options.Processing = true;
        options.Dom = "Bfrtip";
    });
    
    // Column definitions
    table.Column("Name", col => col.Title("Employee Name").Width("200px"))
         .Column("Age", col => col.Type(DataTablesColumnType.Numeric))
         .Column("Salary", col => {
             col.Type(DataTablesColumnType.Currency)
                .Render("$.fn.dataTable.render.number(',', '.', 2, '$')");
         });
    
    // Enable features
    table.EnableButtons(btn => {
        btn.Excel = true;
        btn.Print = true;
        btn.ColVis = true;
    })
    .Responsive(true)
    .RowGrouping(group => {
        group.DataSrc = "department";
    })
    .StateManagement(state => {
        state.Save = true;
    });
    
    // Styling
    table.WithStyle(BootstrapTableStyle.Striped | BootstrapTableStyle.Hover)
         .Compact();
});
```

## Testing Strategy
1. Create comprehensive examples for each feature
2. Test with various data types and sizes
3. Ensure proper JavaScript generation
4. Validate responsive behavior
5. Test export functionality
6. Verify state persistence

## Migration Guide
For users upgrading from basic DataTables:
1. Existing `Table(data, TableType.DataTables)` continues to work
2. New features are opt-in through configuration
3. Gradual adoption path - add features as needed
4. Backward compatibility maintained