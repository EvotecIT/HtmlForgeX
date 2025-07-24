using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlForgeX;

/// <summary>
/// Represents a complete layout structure with navigation, content areas, and optional sidebars.
/// </summary>
public class TablerLayoutContainer : Element {
    private TablerNavbar? _navbar;
    private TablerNavbar? _sidebar;
    private readonly List<TablerLayoutPage> _pages = new();
    private TablerLayout _layoutType = TablerLayout.Default;
    private string? _footerContent;
    private bool _hasHeader = true;
    private bool _hasSidebar = false;

    /// <summary>
    /// Initializes a new instance of the TablerLayoutContainer class.
    /// </summary>
    public TablerLayoutContainer() {
    }

    /// <summary>
    /// Registers the required libraries for TablerLayoutContainer.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.Bootstrap);
        Document?.AddLibrary(Libraries.Tabler);
        // jQuery is included with Bootstrap
    }

    /// <summary>
    /// Sets the layout type.
    /// </summary>
    public TablerLayoutContainer WithLayout(TablerLayout layoutType) {
        _layoutType = layoutType;
        _hasSidebar = layoutType == TablerLayout.Vertical || 
                      layoutType == TablerLayout.VerticalRight || 
                      layoutType == TablerLayout.VerticalTransparent ||
                      layoutType == TablerLayout.FluidVertical ||
                      layoutType == TablerLayout.Combo;
        return this;
    }

    /// <summary>
    /// Configures the navigation bar.
    /// </summary>
    public TablerLayoutContainer WithNavbar(Action<TablerNavbar> config) {
        _navbar = new TablerNavbar();
        
        // Set appropriate style based on layout
        if (_hasSidebar && _layoutType != TablerLayout.Combo) {
            _navbar.WithStyle(TablerNavbarStyle.Vertical);
        }
        
        config(_navbar);
        Add(_navbar);
        return this;
    }

    /// <summary>
    /// Configures a secondary sidebar navigation (for combo layout).
    /// </summary>
    public TablerLayoutContainer WithSidebar(Action<TablerNavbar> config) {
        if (_layoutType == TablerLayout.Combo) {
            _sidebar = new TablerNavbar().WithStyle(TablerNavbarStyle.Vertical);
            config(_sidebar);
            Add(_sidebar);
        }
        return this;
    }

    /// <summary>
    /// Adds a page to the layout.
    /// </summary>
    public TablerLayoutContainer AddPage(string id, string title, Action<TablerLayoutPage> config) {
        var page = new TablerLayoutPage(id, title);
        config(page);
        _pages.Add(page);
        Add(page);
        return this;
    }

    /// <summary>
    /// Sets footer content.
    /// </summary>
    public TablerLayoutContainer WithFooter(string content) {
        _footerContent = content;
        return this;
    }

    /// <summary>
    /// Converts the layout to its HTML representation.
    /// </summary>
    public override string ToString() {
        var layoutClass = GetLayoutClass();
        var pageWrapper = new HtmlTag("div").Class($"page{layoutClass}");

        // Build layout structure based on type
        if (_hasSidebar && _layoutType != TablerLayout.Combo) {
            // Vertical layouts
            if (_navbar != null) {
                var aside = new HtmlTag("aside").Class("navbar navbar-vertical navbar-expand-lg");
                aside.Value(_navbar.ToString());
                pageWrapper.Value(aside);
            }

            var pageMain = new HtmlTag("div").Class("page-wrapper");
            pageMain.Value(BuildPageContent());
            pageWrapper.Value(pageMain);
        } else if (_layoutType == TablerLayout.Combo) {
            // Combo layout with header and sidebar
            if (_navbar != null) {
                pageWrapper.Value(_navbar.ToString());
            }

            var pageBody = new HtmlTag("div").Class("page-wrapper");
            
            if (_sidebar != null) {
                var aside = new HtmlTag("aside").Class("navbar navbar-vertical navbar-expand-lg");
                aside.Value(_sidebar.ToString());
                pageBody.Value(aside);
            }

            var pageMain = new HtmlTag("div").Class("page-main");
            pageMain.Value(BuildPageContent());
            pageBody.Value(pageMain);
            
            pageWrapper.Value(pageBody);
        } else {
            // Horizontal layouts
            if (_navbar != null) {
                pageWrapper.Value(_navbar.ToString());
            }
            
            var pageMain = new HtmlTag("div").Class("page-wrapper");
            pageMain.Value(BuildPageContent());
            pageWrapper.Value(pageMain);
        }

        // Add page switching script
        if (_pages.Count > 1) {
            pageWrapper.Value(BuildPageSwitchingScript());
        }

        return pageWrapper.ToString();
    }

    private HtmlTag BuildPageContent() {
        var container = new HtmlTag("div").Class("page-body");
        var innerContainer = new HtmlTag("div").Class(GetContainerClass());

        // Add all pages
        foreach (var page in _pages) {
            var pageDiv = new HtmlTag("div")
                .Class("layout-page")
                .Id(page.Id)
                .Style("display", page == _pages.FirstOrDefault() ? "block" : "none");
            
            pageDiv.Value(page.ToString());
            innerContainer.Value(pageDiv);
        }

        container.Value(innerContainer);

        // Add footer if specified
        if (!string.IsNullOrEmpty(_footerContent)) {
            var footer = new HtmlTag("footer").Class("footer footer-transparent d-print-none");
            var footerContainer = new HtmlTag("div").Class(GetContainerClass());
            footerContainer.Value(_footerContent);
            footer.Value(footerContainer);
            container.Value(footer);
        }

        return container;
    }

    private HtmlTag BuildPageSwitchingScript() {
        var script = @"
<script>
document.addEventListener('DOMContentLoaded', function() {
    // Handle navigation clicks for internal pages
    document.querySelectorAll('a[href^=""#""]').forEach(function(link) {
        link.addEventListener('click', function(e) {
            const targetId = this.getAttribute('href').substring(1);
            const targetPage = document.getElementById(targetId);
            
            if (targetPage && targetPage.classList.contains('layout-page')) {
                e.preventDefault();
                
                // Hide all pages
                document.querySelectorAll('.layout-page').forEach(function(page) {
                    page.style.display = 'none';
                });
                
                // Show target page
                targetPage.style.display = 'block';
                
                // Update active navigation
                document.querySelectorAll('.nav-link').forEach(function(navLink) {
                    navLink.classList.remove('active');
                });
                this.classList.add('active');
            }
        });
    });
});
</script>";
        return new HtmlTag("script").Value(script);
    }

    private string GetLayoutClass() {
        return _layoutType switch {
            TablerLayout.Default => "",
            TablerLayout.Fluid => " layout-fluid",
            TablerLayout.Boxed => " layout-boxed",
            TablerLayout.Horizontal => " layout-horizontal",
            TablerLayout.Vertical => " layout-vertical",
            TablerLayout.VerticalRight => " layout-vertical-right",
            TablerLayout.VerticalTransparent => " layout-vertical-transparent",
            TablerLayout.FluidVertical => " layout-fluid-vertical",
            TablerLayout.Combo => " layout-combo",
            TablerLayout.Condensed => " layout-condensed",
            TablerLayout.RTL => " layout-rtl",
            TablerLayout.NavbarDark => " layout-navbar-dark",
            TablerLayout.NavbarOverlap => " layout-navbar-overlap",
            TablerLayout.NavbarSticky => " layout-navbar-sticky",
            _ => ""
        };
    }

    private string GetContainerClass() {
        return _layoutType switch {
            TablerLayout.Fluid or TablerLayout.FluidVertical => "container-fluid",
            TablerLayout.Boxed => "container",
            _ => "container-xl"
        };
    }
}

/// <summary>
/// Represents a page within a layout container.
/// </summary>
public class TablerLayoutPage : Element {
    /// <summary>
    /// Gets the unique identifier for this page.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the title of this page.
    /// </summary>
    public string Title { get; }

    /// <summary>
    /// Initializes a new instance of the TablerLayoutPage class.
    /// </summary>
    public TablerLayoutPage(string id, string title) {
        Id = id;
        Title = title;
    }

    /// <summary>
    /// Registers the required libraries for TablerLayoutPage.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.Bootstrap);
        Document?.AddLibrary(Libraries.Tabler);
    }

    /// <summary>
    /// Adds content to the page.
    /// </summary>
    public TablerLayoutPage AddContent(Action<TablerLayoutPage> config) {
        config(this);
        return this;
    }

    /// <summary>
    /// Adds a row to the page.
    /// </summary>
    public TablerLayoutPage Row(Action<TablerRow> config) {
        var row = new TablerRow(TablerRowType.Cards, TablerRowType.Deck);
        row.WithBottomSpacing(TablerSpacing.Medium);
        this.Add(row);
        config(row);
        return this;
    }

    /// <summary>
    /// Adds a section to the page.
    /// </summary>
    public TablerLayoutPage Section(Action<TablerSection> config) {
        var section = new TablerSection();
        config(section);
        this.Add(section);
        return this;
    }

    /// <summary>
    /// Converts the page to its HTML representation.
    /// </summary>
    public override string ToString() {
        var container = new HtmlTag("div");
        
        // Add page header if title is provided
        if (!string.IsNullOrEmpty(Title)) {
            var pageHeader = new HtmlTag("div").Class("page-header d-print-none");
            var headerRow = new HtmlTag("div").Class("row g-2 align-items-center");
            var headerCol = new HtmlTag("div").Class("col");
            var h2 = new HtmlTag("h2").Class("page-title").Value(Title);
            headerCol.Value(h2);
            headerRow.Value(headerCol);
            pageHeader.Value(headerRow);
            container.Value(pageHeader);
        }

        // Add page content
        var pageContent = new HtmlTag("div").Class("page-content");
        foreach (var child in Children) {
            pageContent.Value(child);
        }
        container.Value(pageContent);

        return container.ToString();
    }
}