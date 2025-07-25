# HtmlForgeX TODO - Tabler Feature Implementation Plan

## Overview
This document outlines the implementation plan for Tabler features missing in HtmlForgeX. The goal is to provide a fluent, C#-friendly API for HTML-challenged developers while maintaining consistency with existing HtmlForgeX patterns.

**Last Updated**: 2025-07-25

## 📊 COMPLETED TODAY (2025-07-24)

### ✅ JavaScript Violation Fix
- **CRITICAL FIX**: Eliminated raw JavaScript in `TablerLayoutContainer`
- Created `TablerPageSwitcher` component to encapsulate page switching logic
- Maintains "NO CSS, NO JS, NO HTML" principle perfectly
- Page switching functionality preserved with typed configuration API

### ✅ Compilation Success
- Fixed all compilation errors (0 errors remaining!)
- Projects now build successfully across all target frameworks

### ✅ Warning Reduction Progress
- **Analyzed 1053 warnings** (351 unique across 3 frameworks)
- **Fixed 31 critical warnings**:
  - ✅ All CS8604 nullable reference warnings (25 instances)
  - ✅ CS8602 nullable dereference warning (1 instance)  
  - ✅ CS0414 unused field warning (1 instance)
  - ✅ CS1570/CS1572/CS1573 XML comment warnings (5 instances)
- **Remaining**: 77 CS1591 missing XML documentation warnings (non-critical)

### ✅ API Fixes Applied
- Fixed TablerDropdown API changes (AddItem → Item)
- Fixed TablerAlert constructor requirements
- Fixed TablerTable API (Headers → AddHeaders, Row → AddRow)
- Fixed TablerSidebar Item method signatures
- Fixed TablerDashboardDemo Create method signatures

## 📋 REMAINING WORK FOR TOMORROW

### 🟡 Documentation Warnings (Low Priority)
- 77 CS1591 warnings for missing XML documentation
- Mainly in `EmailImage`, `TablerBadge`, `TablerCloseButton` classes
- Non-critical but should be addressed for API completeness

### 🔴 Critical Components Still Missing
1. **TablerButton** - No standalone button component exists
2. **TablerDropdown** - Has basic implementation but needs enhancement
3. **TablerBreadcrumb** - Not implemented
4. **TablerPagination** - Not implemented
5. **Professional Layout Components**:
   - TablerHeader (dedicated header with user profile)
   - TablerSidebar (dedicated sidebar, not just navbar)
   - TablerFooter (professional footer component)

### 🟢 Next Steps Priority
1. Add XML documentation to reduce warnings (optional)
2. Implement missing critical components (TablerButton first)
3. Create professional layout demos
4. Test multi-page navigation thoroughly

---

## 🚨 CRITICAL PRINCIPLE REMINDER 🚨
### NO CSS, NO JS, NO HTML - EVER!
- Users should NEVER write `new HtmlTag("div").Class("page-wrapper")`
- Users should NEVER see CSS classes like `"d-print-none"`, `"container-xl"`, `"col-md-4"`
- Users should NEVER write style strings like `.Style("height: 300px")`
- EVERYTHING must be typed components with fluent API
- If you're typing HTML tags, CSS classes, or style strings - YOU'RE DOING IT WRONG!

### ❌ VIOLATIONS TO FIX IMMEDIATELY
```csharp
// ❌ WRONG - These are violations found in demos:
var pageWrapper = new HtmlTag("div").Class("page-wrapper");
var headerContainer = new HtmlTag("div").Class("container-xl");
new HtmlTag("span").Class("badge bg-success").Value("Completed")
.Style("height: 300px")

// ✅ CORRECT - Everything is typed:
document.Body.Page(page => page
    .Wrapper(wrapper => wrapper
        .Container(container => container.Fluid())
        .Badge("Completed", TablerBadgeColor.Success)
        .Height(TablerHeight.Pixels(300))
    )
);
```

### Components That Need To Be Created To Fix The Demo
1. **TablerPage** - Typed page container (no `new HtmlTag("div").Class("page")`)
2. **TablerPageWrapper** - Page wrapper component (no `.Class("page-wrapper")`)
3. **TablerPageHeader** - Page header with proper structure
4. **TablerPageTitle** - Title component with pretitle support
5. **TablerPageBody** - Body container with proper spacing
6. **TablerContainer** - Container with size options (xl, lg, md, sm, fluid)
7. **TablerStatsRow** - Stats card row with automatic spacing
8. **TablerStatCard** - Mini stat cards with icon, value, change
9. **TablerOrderStatus** - Enum for order statuses (Completed, Pending, Processing, Cancelled)
10. **TablerBadge** (proper) - Badge with all color and style options as enums
11. **TablerChartCard** - Chart container with time range selectors
12. **TablerHeight/TablerWidth** - Typed dimension system (no `.Style("height: 300px")`)

---

# 🚨 PRIORITY: Professional Navigation & Layout System Implementation Plan

## Goal
Create a professional navigation and layout system matching the quality of Tabler's official demos, utilizing existing HtmlForgeX components and implementing only the critical missing pieces.

## Current Situation
- We have many components already (icons, cards, forms, etc.)
- Navigation exists but lacks the professional polish of Tabler demos
- Missing critical components: Button, Dropdown, proper Header/Sidebar/Footer structure
- Need to integrate everything into a cohesive, beautiful system

## Implementation Strategy

### Phase 1: Critical Missing Components (Week 1)
1. **TablerButton** - Foundation for all interactions
   ```csharp
   element.Button("Save", TablerButtonVariant.Primary)
          .Icon(TablerIconType.DeviceFloppy)
          .Size(TablerButtonSize.Default)
          .OnClick("saveData()");
   ```

2. **TablerDropdown** - Essential for navigation menus
   ```csharp
   element.Dropdown("User Menu", dropdown => {
       dropdown.Item("Profile", "/profile").Icon(TablerIconType.User)
               .Divider()
               .Item("Logout", "/logout").Icon(TablerIconType.Logout);
   });
   ```

3. **TablerBreadcrumb** - Navigation context
   ```csharp
   element.Breadcrumb(crumb => {
       crumb.Item("Home", "/")
            .Item("Products", "/products")
            .Active("Details");
   });
   ```

### Phase 2: Professional Layout Components (Week 1-2)
1. **TablerHeader** - Top navigation bar with user profile
   ```csharp
   document.Body.Header(header => {
       header.Brand("MyApp", "/").Logo("/logo.png")
             .DarkModeToggle()
             .NotificationBell(5)
             .UserProfile("John Doe", "Admin", profile => {
                 profile.Avatar("/avatar.jpg")
                        .MenuItem("Settings", "/settings")
                        .MenuItem("Logout", "/logout");
             });
   });
   ```

2. **TablerSidebar** - Professional sidebar navigation
   ```csharp
   layout.Sidebar(sidebar => {
       sidebar.Brand("MyApp").Logo("/logo.png")
              .NavItem("Dashboard", "/").Icon(TablerIconType.Home).Active()
              .NavItem("Analytics", "/analytics").Icon(TablerIconType.ChartBar).Badge("New", TablerColor.Success)
              .NavGroup("Products", group => {
                  group.Item("All Products", "/products")
                       .Item("Categories", "/categories")
                       .Item("Inventory", "/inventory");
              })
              .Divider()
              .NavItem("Settings", "/settings").Icon(TablerIconType.Settings);
   });
   ```

3. **TablerFooter** - Professional footer
   ```csharp
   layout.Footer(footer => {
       footer.Copyright("2024 MyCompany")
             .Links(links => {
                 links.Link("Documentation", "/docs")
                      .Link("Support", "/support")
                      .Link("License", "/license");
             })
             .Version("v1.0.0");
   });
   ```

### Phase 3: Enhanced Navigation Components (Week 2)
1. **TablerUserMenu** - Dedicated user dropdown
2. **TablerNotificationPanel** - Notification dropdown
3. **TablerSearchBox** - Global search component
4. **TablerLanguageSelector** - Language switcher

### Phase 4: Professional Demo Pages (Week 2-3)
Create demos that showcase:
1. **Dashboard Layout** - Analytics dashboard with charts, cards, tables
2. **Admin Panel** - Full CRUD interface with navigation
3. **Landing Page** - Marketing page with hero, features, pricing
4. **Application Layout** - Complex app with sidebar, tabs, forms

## Example: Complete Professional Layout
```csharp
var document = new Document()
    .WithTitle("Professional Dashboard")
    .WithTablerTheme(TablerTheme.Default);

document.Body.TablerLayout(TablerLayoutType.Combo, layout => {
    // Header with user profile
    layout.Header(header => {
        header.Brand("HtmlForgeX Pro", "/").Logo("/assets/logo.png")
              .SearchBox(search => search.Placeholder("Search..."))
              .RightSection(right => {
                  right.DarkModeToggle()
                       .NotificationBell(3, notifications => {
                           notifications.Item("New order received", "2 min ago")
                                       .Item("Server restart scheduled", "1 hour ago");
                       })
                       .UserProfile("Sarah Chen", "Developer", profile => {
                           profile.Avatar("/assets/sarah.jpg")
                                  .Status(UserStatus.Online)
                                  .MenuItem("My Profile", "/profile").Icon(TablerIconType.User)
                                  .MenuItem("Settings", "/settings").Icon(TablerIconType.Settings)
                                  .Divider()
                                  .MenuItem("Logout", "/logout").Icon(TablerIconType.Logout);
                       });
              });
    });
    
    // Sidebar navigation
    layout.Sidebar(sidebar => {
        sidebar.NavItem("Dashboard", "/").Icon(TablerIconType.Home).Active()
               .NavItem("Analytics", "/analytics").Icon(TablerIconType.ChartBar)
               .NavGroup("Content", group => {
                   group.Item("Articles", "/articles").Badge("12")
                        .Item("Media", "/media")
                        .Item("Comments", "/comments").Badge("3", TablerColor.Warning);
               })
               .NavGroup("E-Commerce", group => {
                   group.Item("Products", "/products")
                        .Item("Orders", "/orders").Badge("New", TablerColor.Success)
                        .Item("Customers", "/customers");
               })
               .Divider()
               .NavItem("Settings", "/settings").Icon(TablerIconType.Settings);
    });
    
    // Main content area
    layout.Content(content => {
        content.PageHeader(header => {
            header.Title("Dashboard")
                  .Breadcrumb(crumb => {
                      crumb.Item("Home", "/").Item("Dashboard");
                  })
                  .Actions(actions => {
                      actions.Button("New Report", TablerButtonVariant.Primary)
                             .Icon(TablerIconType.Plus);
                  });
        });
        
        // Dashboard content
        content.Row(row => {
            row.Column(4).Card(card => {
                card.Title("Revenue")
                    .Value("$45,234")
                    .Change("+12%", TablerColor.Success)
                    .Icon(TablerIconType.CurrencyDollar);
            });
            // ... more dashboard cards
        });
    });
    
    // Footer
    layout.Footer(footer => {
        footer.Copyright("2024 HtmlForgeX")
              .Links(links => {
                  links.Link("Documentation", "/docs")
                       .Link("Support", "/support");
              })
              .SocialLinks(social => {
                  social.GitHub("https://github.com/evotecit/htmlforgex")
                        .Twitter("https://twitter.com/evotecit");
              });
    });
});
```

## Success Metrics
- [ ] Navigation matches Tabler demo quality
- [ ] All interactive elements work smoothly
- [ ] Responsive design works on all devices
- [ ] Dark mode fully implemented
- [ ] Professional polish with proper spacing, hover states, animations
- [ ] Easy to use API that requires NO HTML/CSS knowledge

---

## Implementation Philosophy
- **Fluent Interface**: All components should support method chaining
- **Type Safety**: Use enums instead of strings where possible
- **Builder Pattern**: Support both direct instantiation and lambda configuration
- **Predictable API**: Follow existing HtmlForgeX naming conventions
- **No HTML Required**: Abstract all HTML/CSS complexity

## Component Status Overview

### ✅ Already Implemented

#### Navigation & Layout
- **TablerNavbar**: Horizontal and vertical navbar with brand/logo support
- **TablerNavigationItem**: Navigation items with dropdown support  
- **TablerLayout**: Multiple layout types (Fluid, Boxed, Horizontal, Vertical, etc.)
- **TablerLayoutContainer**: Complete layout structure
- **TablerPage**: Page container with header support
- **TablerSection**: Section containers
- **TablerRow** & **TablerColumn**: Grid system with responsive columns

#### Cards & Containers
- **TablerCard**: Basic card with header, body, footer
- **TablerCardEnhanced**: Enhanced card with more options
- **TablerCardMini**: Compact card variant
- **TablerCardList**: Card with list items
- **TablerCardNavigation**: Card with navigation
- **TablerCardStorage**: Storage/file cards
- **TablerCardAction**: Cards with action buttons

#### Forms
- **TablerForm**: Form container
- **TablerInput**: Text input fields
- **TablerInputMask**: Masked input fields  
- **TablerTextarea**: Textarea fields
- **TablerSelect**: Dropdown select with TomSelect integration
- **TablerCheckbox** & **TablerCheckboxGroup**: Checkboxes
- **TablerRadio** & **TablerRadioGroup**: Radio buttons
- **TablerSwitch**: Toggle switches
- **TablerWysiwygEditor**: WYSIWYG editor (Quill integration)

#### UI Components
- **TablerAlerts**: Alert messages
- **TablerBadgeSpan**, **TablerBadgeLink**, **TablerBadgeButton**: Badge variants
- **TablerBadgeStatus**: Status badges
- **TablerProgressBar**: Progress bars  
- **TablerToast**: Toast notifications
- **TablerModal**: Modal dialogs
- **TablerAccordion**: Collapsible accordions
- **TablerTabs**: Tab navigation
- **TablerDivider**: Horizontal dividers
- **TablerTag**: Tag elements
- **TablerText**: Styled text components
- **TablerAvatar**: User avatars
- **TablerStarRating**: Star rating component
- **TablerCountdown**: Countdown timer
- **TablerSteps**: Step indicators
- **TablerTimeline**: Timeline component
- **TablerLogs**: Log display component
- **TablerTracking**: Progress tracking

#### Data Display
- **TablerTable**: Basic table
- **TablerDataGrid**: Data grid with items
- **DataTablesTable**: Advanced DataTables.js integration
- **BootstrapTable**: Bootstrap table styles

#### Icon Systems
- **TablerIcon**: Modern SVG-based Tabler icons (4,963 icons)
- **TablerIconFont**: Font-based Tabler icons
- **FontAwesome5**: FontAwesome 5 icons
- **FontAwesome6**: FontAwesome 6 icons

#### Charts & Visualization
- **ApexCharts**: Comprehensive charting library
- **ChartJs**: Chart.js integration
- **VisNetwork**: Network/graph visualization
- **FancyTree**: Tree view component
- **FullCalendar**: Calendar component

#### Other Components
- **SmartWizard**: Multi-step wizard
- **SmartTab**: Smart tabs
- **EasyQRCode**: QR code generator
- **PrismJs**: Code syntax highlighting
- **QuillEditor**: Rich text editor
- **ScrollingText**: Scrolling text/marquee

#### Styling & Theming
- **TablerColor**: Comprehensive color system with hex values
- **TablerThemes**: Theme support (enums only)
- **TablerSpacing**, **TablerMargin**, **TablerPadding**: Spacing system
- **TablerFontWeight**, **TablerTextStyle**, **TablerTextAlignment**: Typography
- **TablerBorder**: Border utilities

### 🔄 Partially Implemented (Need Enhancement)
- **Navigation**: Basic implementation exists but missing professional Tabler structure
- **Layout**: Container exists but missing proper header/sidebar/footer integration
- **Cards**: Missing ribbon, stamps, hover effects
- **Alerts**: Missing list support, minor alerts
- **Tables**: Missing mobile-responsive view
- **Dark Mode**: Enums exist but no actual implementation
- **RTL Support**: Layout enum exists but no implementation

### ❌ Not Implemented - Critical for Navigation

#### CRITICAL MISSING COMPONENTS
1. **TablerButton** ⚠️ - No standalone button component (only badge buttons)
2. **TablerDropdown** ⚠️ - No dropdown menu component 
3. **TablerBreadcrumb** ⚠️ - No breadcrumb navigation
4. **TablerPagination** ⚠️ - No pagination component

#### Navigation Components
- **TablerHeader** - No dedicated header component (top bar with user profile)
- **TablerSidebar** - No dedicated sidebar component (only navbar in vertical mode)
- **TablerFooter** - No footer component
- **TablerMenu** - No menu component
- **TablerSubmenu** - No submenu support
- **TablerMegaMenu** - No mega menu
- **TablerOffcanvas** - No off-canvas navigation
- **TablerDrawer** - No drawer component
- **TablerUserMenu** - No user profile dropdown

#### Layout Components  
- **TablerContainer** - No container wrapper (using generic divs)
- **TablerGrid** - No dedicated grid component (only row/column)
- **TablerSpacer** - No spacer utilities
- **TablerStack** - No stack layout component

#### UI Components
- **TablerSpinner/TablerLoader** - No loading indicators
- **TablerSkeleton** - No skeleton loaders
- **TablerTooltip** - No tooltip component
- **TablerPopover** - No popover component
- **TablerCollapse** - No collapse component (outside accordion)
- **TablerCarousel** - No carousel/slider
- **TablerChip** - No chip component
- **TablerListGroup** - No list group component
- **TablerEmpty** - No empty state component
- **TablerPlaceholder** - No placeholder component

#### Form Components
- **TablerDatePicker** - No date picker
- **TablerTimePicker** - No time picker
- **TablerColorPicker** - No color picker
- **TablerSlider/TablerRange** - No slider input
- **TablerFileInput** - No file upload component
- **TablerToggleGroup** - No toggle button groups

#### Advanced Features
- **Dark Mode Implementation** - Enums exist but no actual implementation
- **RTL Support** - Layout enum exists but no implementation
- **Responsive Utilities** - No responsive helper classes
- **Animation Support** - No animation utilities
- **Icon Button** - No icon button component
- **Floating Action Button** - No FAB component

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