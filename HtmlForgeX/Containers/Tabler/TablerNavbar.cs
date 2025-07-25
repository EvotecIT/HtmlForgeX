using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlForgeX;

/// <summary>
/// Represents a Tabler navigation bar component for creating responsive navigation menus.
/// </summary>
public class TablerNavbar : Element {
    internal string? _brand;
    internal string _brandUrl = "#";
    internal string? _logoUrl;
    internal TablerNavbarStyle _style = TablerNavbarStyle.Default;
    internal TablerNavbarExpand _expand = TablerNavbarExpand.Medium;
    internal bool _sticky;
    internal bool _dark;
    internal readonly List<TablerNavigationItem> _items = new();
    internal readonly List<TablerNavigationItem> _rightItems = new();

    /// <summary>
    /// Initializes a new instance of the TablerNavbar class.
    /// </summary>
    public TablerNavbar() {
    }

    /// <summary>
    /// Registers the required libraries for TablerNavbar.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.Bootstrap);
        Document?.AddLibrary(Libraries.Tabler);
    }

    /// <summary>
    /// Sets the brand text for the navbar.
    /// </summary>
    public TablerNavbar WithBrand(string brandText, string brandUrl = "#") {
        _brand = brandText;
        _brandUrl = brandUrl;
        return this;
    }

    /// <summary>
    /// Sets the logo for the navbar.
    /// </summary>
    public TablerNavbar WithLogo(string logoUrl, string brandUrl = "#") {
        _logoUrl = logoUrl;
        _brandUrl = brandUrl;
        return this;
    }

    /// <summary>
    /// Sets the navbar style.
    /// </summary>
    public TablerNavbar WithStyle(TablerNavbarStyle style) {
        _style = style;
        return this;
    }

    /// <summary>
    /// Sets the navbar expand breakpoint.
    /// </summary>
    public TablerNavbar WithExpand(TablerNavbarExpand expand) {
        _expand = expand;
        return this;
    }

    /// <summary>
    /// Makes the navbar sticky.
    /// </summary>
    public TablerNavbar WithSticky(bool sticky = true) {
        _sticky = sticky;
        return this;
    }

    /// <summary>
    /// Makes the navbar dark.
    /// </summary>
    public TablerNavbar WithDark(bool dark = true) {
        _dark = dark;
        return this;
    }

    /// <summary>
    /// Adds a navigation item to the navbar.
    /// </summary>
    public TablerNavbar AddItem(string text, string href = "#") {
        var item = new TablerNavigationItem().WithText(text).WithHref(href);
        _items.Add(item);
        Add(item);
        return this;
    }

    /// <summary>
    /// Adds a navigation item with configuration to the navbar.
    /// </summary>
    public TablerNavbar AddItem(Action<TablerNavigationItem> config) {
        var item = new TablerNavigationItem();
        config(item);
        _items.Add(item);
        Add(item);
        return this;
    }

    /// <summary>
    /// Adds a navigation item to the right side of the navbar.
    /// </summary>
    public TablerNavbar AddRightItem(Action<TablerNavigationItem> config) {
        var item = new TablerNavigationItem();
        config(item);
        _rightItems.Add(item);
        Add(item);
        return this;
    }

    /// <summary>
    /// Converts the navbar to its HTML representation.
    /// </summary>
    public override string ToString() {
        var headerClasses = GetHeaderClasses();
        var header = new HtmlTag("header").Class(headerClasses);

        var container = new HtmlTag("div").Class("container-xl");
        header.Value(container);

        var navbarContent = BuildNavbarContent();
        container.Value(navbarContent);

        return header.ToString();
    }

    private string GetHeaderClasses() {
        var classes = new List<string> { "navbar" };

        // Add expand class
        classes.Add(_expand switch {
            TablerNavbarExpand.Small => "navbar-expand-sm",
            TablerNavbarExpand.Medium => "navbar-expand-md",
            TablerNavbarExpand.Large => "navbar-expand-lg",
            TablerNavbarExpand.ExtraLarge => "navbar-expand-xl",
            TablerNavbarExpand.Never => "",
            _ => "navbar-expand-md"
        });

        // Add style class
        if (_style == TablerNavbarStyle.Vertical) {
            classes.Add("navbar-vertical");
        }

        // Add modifiers
        if (_sticky) classes.Add("navbar-sticky");
        if (_dark) classes.Add("navbar-dark");

        return string.Join(" ", classes.Where(c => !string.IsNullOrEmpty(c)));
    }

    private HtmlTag BuildNavbarContent() {
        if (_style == TablerNavbarStyle.Vertical) {
            return BuildVerticalNavbar();
        }
        return BuildHorizontalNavbar();
    }

    private HtmlTag BuildHorizontalNavbar() {
        var container = new HtmlTag("div");

        // Add toggler button for mobile
        var toggler = new HtmlTag("button")
            .Class("navbar-toggler")
            .Attribute("type", "button")
            .Attribute("data-bs-toggle", "collapse")
            .Attribute("data-bs-target", "#navbar-menu")
            .Attribute("aria-controls", "navbar-menu")
            .Attribute("aria-expanded", "false")
            .Attribute("aria-label", "Toggle navigation");
        toggler.Value(new HtmlTag("span").Class("navbar-toggler-icon"));
        container.Value(toggler);

        // Add brand/logo
        if (!string.IsNullOrEmpty(_brand) || !string.IsNullOrEmpty(_logoUrl)) {
            var brand = new HtmlTag("a").Class("navbar-brand").Attribute("href", _brandUrl);
            if (!string.IsNullOrEmpty(_logoUrl)) {
                var logo = new HtmlTag("img", null, TagMode.SelfClosing)
                    .Attribute("src", _logoUrl!)
                    .Attribute("alt", _brand ?? "Logo")
                    .Attribute("height", "32");
                brand.Value(logo);
            } else if (!string.IsNullOrEmpty(_brand)) {
                brand.Value(_brand);
            }
            container.Value(brand);
        }

        // Add navigation items
        var collapse = new HtmlTag("div").Class("collapse navbar-collapse").Id("navbar-menu");
        var navContainer = new HtmlTag("div").Class("d-flex flex-column flex-md-row flex-fill align-items-stretch align-items-md-center");
        var nav = new HtmlTag("ul").Class("navbar-nav");

        foreach (var item in _items) {
            nav.Value(item);
        }

        navContainer.Value(nav);

        // Add right items if any
        if (_rightItems.Any()) {
            var rightNav = new HtmlTag("ul").Class("navbar-nav ms-auto");
            foreach (var item in _rightItems) {
                rightNav.Value(item);
            }
            navContainer.Value(rightNav);
        }

        collapse.Value(navContainer);
        container.Value(collapse);

        return container;
    }

    private HtmlTag BuildVerticalNavbar() {
        var container = new HtmlTag("div").Class("navbar-inner");

        // Add brand/logo
        if (!string.IsNullOrEmpty(_brand) || !string.IsNullOrEmpty(_logoUrl)) {
            var brandContainer = new HtmlTag("h1").Class("navbar-brand navbar-brand-autodark");
            var brand = new HtmlTag("a").Attribute("href", _brandUrl);
            if (!string.IsNullOrEmpty(_logoUrl)) {
                var logo = new HtmlTag("img", null, TagMode.SelfClosing)
                    .Attribute("src", _logoUrl!)
                    .Attribute("alt", _brand ?? "Logo")
                    .Attribute("height", "32");
                brand.Value(logo);
            } else if (!string.IsNullOrEmpty(_brand)) {
                brand.Value(_brand);
            }
            brandContainer.Value(brand);
            container.Value(brandContainer);
        }

        // Add toggler for mobile
        var toggler = new HtmlTag("div").Class("navbar-toggler collapsed")
            .Attribute("data-bs-toggle", "collapse")
            .Attribute("data-bs-target", "#sidebar-menu")
            .Attribute("aria-controls", "sidebar-menu")
            .Attribute("aria-expanded", "false")
            .Attribute("aria-label", "Toggle navigation");
        toggler.Value(new HtmlTag("span").Class("navbar-toggler-icon"));
        container.Value(toggler);

        // Add navigation menu
        var collapse = new HtmlTag("div").Class("collapse navbar-collapse").Id("sidebar-menu");
        var nav = new HtmlTag("ul").Class("navbar-nav pt-lg-3");

        foreach (var item in _items) {
            nav.Value(item);
        }

        collapse.Value(nav);
        container.Value(collapse);

        return container;
    }
}

/// <summary>
/// Defines the style of the navbar.
/// </summary>
public enum TablerNavbarStyle {
    /// <summary>
    /// Default horizontal navbar.
    /// </summary>
    Default,
    /// <summary>
    /// Vertical sidebar navbar.
    /// </summary>
    Vertical
}

/// <summary>
/// Defines when the navbar should expand from mobile to desktop view.
/// </summary>
public enum TablerNavbarExpand {
    /// <summary>
    /// Always expanded.
    /// </summary>
    Always,
    /// <summary>
    /// Expand on small screens and up.
    /// </summary>
    Small,
    /// <summary>
    /// Expand on medium screens and up.
    /// </summary>
    Medium,
    /// <summary>
    /// Expand on large screens and up.
    /// </summary>
    Large,
    /// <summary>
    /// Expand on extra large screens and up.
    /// </summary>
    ExtraLarge,
    /// <summary>
    /// Never expand, always show mobile menu.
    /// </summary>
    Never
}