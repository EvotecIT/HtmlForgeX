using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlForgeX;

/// <summary>
/// Represents a navigation item within a TablerNavbar.
/// </summary>
public class TablerNavigationItem : Element {
    internal string? _text;
    internal string _href = "#";
    internal TablerIconType? _icon;
    internal TablerColor? _iconColor;
    internal bool _active;
    internal bool _disabled;
    internal readonly List<TablerNavigationItem> _dropdownItems = new();
    internal string? _badgeText;
    internal TablerColor? _badgeColor;
    internal string? _internalPageId;

    /// <summary>
    /// Initializes a new instance of the TablerNavigationItem class.
    /// </summary>
    public TablerNavigationItem() {
    }

    /// <summary>
    /// Registers the required libraries for TablerNavigationItem.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.AddLibrary(Libraries.Bootstrap);
        Document?.AddLibrary(Libraries.Tabler);
    }

    /// <summary>
    /// Sets the text for the navigation item.
    /// </summary>
    public TablerNavigationItem WithText(string text) {
        _text = text;
        return this;
    }

    /// <summary>
    /// Sets the href for the navigation item.
    /// </summary>
    public TablerNavigationItem WithHref(string href) {
        _href = href;
        return this;
    }

    /// <summary>
    /// Sets an internal page ID for single-page navigation.
    /// </summary>
    public TablerNavigationItem WithInternalPageId(string pageId) {
        _internalPageId = pageId;
        _href = $"#{pageId}";
        return this;
    }

    /// <summary>
    /// Sets the icon for the navigation item.
    /// </summary>
    public TablerNavigationItem WithIcon(TablerIconType icon, TablerColor? color = null) {
        _icon = icon;
        _iconColor = color;
        return this;
    }

    /// <summary>
    /// Marks the item as active.
    /// </summary>
    public TablerNavigationItem Active(bool active = true) {
        _active = active;
        return this;
    }

    /// <summary>
    /// Marks the item as disabled.
    /// </summary>
    public TablerNavigationItem Disabled(bool disabled = true) {
        _disabled = disabled;
        return this;
    }

    /// <summary>
    /// Adds a badge to the navigation item.
    /// </summary>
    public TablerNavigationItem WithBadge(string text, TablerColor? color = null) {
        _badgeText = text;
        _badgeColor = color;
        return this;
    }

    /// <summary>
    /// Adds a dropdown item to this navigation item.
    /// </summary>
    public TablerNavigationItem AddDropdownItem(string text, string href = "#") {
        var item = new TablerNavigationItem().WithText(text).WithHref(href);
        _dropdownItems.Add(item);
        Add(item);
        return this;
    }

    /// <summary>
    /// Adds a dropdown item with configuration.
    /// </summary>
    public TablerNavigationItem AddDropdownItem(Action<TablerNavigationItem> config) {
        var item = new TablerNavigationItem();
        config(item);
        _dropdownItems.Add(item);
        Add(item);
        return this;
    }

    /// <summary>
    /// Converts the navigation item to its HTML representation.
    /// </summary>
    public override string ToString() {
        var li = new HtmlTag("li").Class("nav-item");
        
        if (_dropdownItems.Any()) {
            li.Class("dropdown");
            var link = BuildDropdownToggle();
            li.Value(link);
            
            var dropdownMenu = BuildDropdownMenu();
            li.Value(dropdownMenu);
        } else {
            var link = BuildNavLink();
            li.Value(link);
        }

        return li.ToString();
    }

    private HtmlTag BuildNavLink() {
        var classes = new List<string> { "nav-link" };
        if (_active) classes.Add("active");
        if (_disabled) classes.Add("disabled");

        var link = new HtmlTag("a")
            .Class(string.Join(" ", classes))
            .Attribute("href", _href);

        if (_disabled) {
            link.Attribute("tabindex", "-1")
                .Attribute("aria-disabled", "true");
        }

        // Add icon if specified
        if (_icon.HasValue) {
            var iconClass = $"icon icon-tabler icon-tabler-{_icon.Value.ToString().ToKebabCase()}";
            if (_iconColor.HasValue) {
                iconClass += $" text-{_iconColor.Value.ToString().ToKebabCase()}";
            }
            var icon = new HtmlTag("svg").Class(iconClass);
            link.Value(icon);
        }

        // Add text
        if (!string.IsNullOrEmpty(_text)) {
            var textSpan = new HtmlTag("span").Class("nav-link-title").Value(_text);
            link.Value(textSpan);
        }

        // Add badge if specified
        if (!string.IsNullOrEmpty(_badgeText)) {
            var badgeClasses = new List<string> { "badge", "badge-sm", "ms-2" };
            if (_badgeColor.HasValue) {
                badgeClasses.Add($"bg-{_badgeColor.Value.ToString().ToKebabCase()}");
            } else {
                badgeClasses.Add("bg-green");
            }
            var badge = new HtmlTag("span").Class(string.Join(" ", badgeClasses)).Value(_badgeText);
            link.Value(badge);
        }

        return link;
    }

    private HtmlTag BuildDropdownToggle() {
        var classes = new List<string> { "nav-link", "dropdown-toggle" };
        if (_active) classes.Add("active");
        if (_disabled) classes.Add("disabled");

        var link = new HtmlTag("a")
            .Class(string.Join(" ", classes))
            .Attribute("href", "#navbar-base")
            .Attribute("data-bs-toggle", "dropdown")
            .Attribute("data-bs-auto-close", "false")
            .Attribute("role", "button")
            .Attribute("aria-expanded", "false");

        if (_disabled) {
            link.Attribute("tabindex", "-1")
                .Attribute("aria-disabled", "true");
        }

        // Add icon if specified
        if (_icon.HasValue) {
            var iconClass = $"icon icon-tabler icon-tabler-{_icon.Value.ToString().ToKebabCase()}";
            if (_iconColor.HasValue) {
                iconClass += $" text-{_iconColor.Value.ToString().ToKebabCase()}";
            }
            var icon = new HtmlTag("svg").Class(iconClass);
            link.Value(icon);
        }

        // Add text
        if (!string.IsNullOrEmpty(_text)) {
            var textSpan = new HtmlTag("span").Class("nav-link-title").Value(_text);
            link.Value(textSpan);
        }

        return link;
    }

    private HtmlTag BuildDropdownMenu() {
        var menu = new HtmlTag("div").Class("dropdown-menu");
        
        foreach (var item in _dropdownItems) {
            // For dropdown items, we render them differently
            var dropdownItem = new HtmlTag("a")
                .Class("dropdown-item")
                .Attribute("href", item._href);

            if (item._active) dropdownItem.Class("active");
            if (item._disabled) {
                dropdownItem.Class("disabled")
                    .Attribute("tabindex", "-1")
                    .Attribute("aria-disabled", "true");
            }

            // Add icon if specified
            if (item._icon.HasValue) {
                var iconClass = $"icon icon-tabler icon-tabler-{item._icon.Value.ToString().ToKebabCase()}";
                if (item._iconColor.HasValue) {
                    iconClass += $" text-{item._iconColor.Value.ToString().ToKebabCase()}";
                }
                var icon = new HtmlTag("svg").Class(iconClass);
                dropdownItem.Value(icon);
            }

            dropdownItem.Value(item._text);

            // Add badge if specified
            if (!string.IsNullOrEmpty(item._badgeText)) {
                var badgeClasses = new List<string> { "badge", "badge-sm", "ms-auto" };
                if (item._badgeColor.HasValue) {
                    badgeClasses.Add($"bg-{item._badgeColor.Value.ToString().ToKebabCase()}");
                } else {
                    badgeClasses.Add("bg-green");
                }
                var badge = new HtmlTag("span").Class(string.Join(" ", badgeClasses)).Value(item._badgeText);
                dropdownItem.Value(badge);
            }

            menu.Value(dropdownItem);
        }

        return menu;
    }
}

// Extension method for kebab case conversion
internal static class StringExtensions {
    internal static string ToKebabCase(this string input) {
        if (string.IsNullOrEmpty(input)) return input;

        var result = new System.Text.StringBuilder();
        for (int i = 0; i < input.Length; i++) {
            var c = input[i];
            if (char.IsUpper(c) && i > 0) {
                result.Append('-');
                result.Append(char.ToLower(c));
            } else {
                result.Append(char.ToLower(c));
            }
        }
        return result.ToString();
    }
}