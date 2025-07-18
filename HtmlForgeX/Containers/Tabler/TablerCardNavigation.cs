using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// Card navigation component for tabs and pills (no raw HTML)
/// </summary>
public class TablerCardNavigation : Element {
    private TablerCardNavigationType NavType { get; set; } = TablerCardNavigationType.Tabs;
    private List<TablerCardNavItem> NavItems { get; set; } = new List<TablerCardNavItem>();

    /// <summary>
    /// Set navigation type (tabs or pills)
    /// </summary>
    public TablerCardNavigation Type(TablerCardNavigationType type) {
        NavType = type;
        return this;
    }

    /// <summary>
    /// Add navigation items
    /// </summary>
    public TablerCardNavigation WithItems(Action<TablerCardNavBuilder> itemsConfig) {
        var builder = new TablerCardNavBuilder();
        itemsConfig(builder);
        NavItems = builder.GetItems();
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var navList = new HtmlTag("ul");
        var classes = new List<string> { "nav" };

        switch (NavType) {
            case TablerCardNavigationType.Tabs:
                classes.Add("nav-tabs");
                classes.Add("card-header-tabs");
                break;
            case TablerCardNavigationType.Pills:
                classes.Add("nav-pills");
                classes.Add("card-header-pills");
                break;
        }

        navList.Class(string.Join(" ", classes));

        foreach (var item in NavItems) {
            navList.Value(item.ToString());
        }

        return navList.ToString();
    }
}

/// <summary>
/// Navigation types for card headers
/// </summary>
public enum TablerCardNavigationType {
    /// <summary>Use tabbed navigation.</summary>
    Tabs,
    /// <summary>Use pill style navigation.</summary>
    Pills
}

/// <summary>
/// Individual navigation item
/// </summary>
public class TablerCardNavItem : Element {
    private string ItemText { get; set; } = "";
    private string ItemUrl { get; set; } = "#";
    private bool IsActive { get; set; } = false;
    private bool IsDisabled { get; set; } = false;

    /// <summary>
    /// Initializes or configures Text.
    /// </summary>
    public new TablerCardNavItem Text(string text) {
        ItemText = text;
        return this;
    }

    /// <summary>
    /// Initializes or configures Url.
    /// </summary>
    public TablerCardNavItem Url(string url) {
        ItemUrl = url;
        return this;
    }

    /// <summary>
    /// Initializes or configures Active.
    /// </summary>
    public TablerCardNavItem Active() {
        IsActive = true;
        return this;
    }

    /// <summary>
    /// Initializes or configures Disabled.
    /// </summary>
    public TablerCardNavItem Disabled() {
        IsDisabled = true;
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var listItem = new HtmlTag("li").Class("nav-item");
        var linkItem = new HtmlTag("a");

        var linkClasses = new List<string> { "nav-link" };
        if (IsActive) linkClasses.Add("active");
        if (IsDisabled) linkClasses.Add("disabled");

        linkItem.Class(string.Join(" ", linkClasses));
        linkItem.Attribute("href", ItemUrl);
        linkItem.Value(ItemText);

        listItem.Value(linkItem);
        return listItem.ToString();
    }
}

/// <summary>
/// Builder for navigation items
/// </summary>
public class TablerCardNavBuilder {
    private List<TablerCardNavItem> items = new List<TablerCardNavItem>();

    /// <summary>
    /// Initializes or configures Item.
    /// </summary>
    public TablerCardNavBuilder Item(string text, Action<TablerCardNavItem>? config = null) {
        var item = new TablerCardNavItem().Text(text);
        config?.Invoke(item);
        items.Add(item);
        return this;
    }

    /// <summary>
    /// Gets the collection of navigation items configured by the builder.
    /// </summary>
    public List<TablerCardNavItem> GetItems() => items;
}