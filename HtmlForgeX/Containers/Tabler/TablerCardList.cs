using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// Card list component with proper styling (no raw HTML)
/// </summary>
public class TablerCardList : Element {
    private TablerCardListType ListType { get; set; } = TablerCardListType.Unordered;
    private TablerCardListStyle ListStyle { get; set; } = TablerCardListStyle.Default;
    private List<TablerCardListItem> Items { get; set; } = new List<TablerCardListItem>();
    private string? ListTitle { get; set; }

    /// <summary>
    /// Set the list type (ordered or unordered)
    /// </summary>
    public TablerCardList Type(TablerCardListType type) {
        ListType = type;
        return this;
    }

    /// <summary>
    /// Set the list style
    /// </summary>
    public TablerCardList Style(TablerCardListStyle style) {
        ListStyle = style;
        return this;
    }

    /// <summary>
    /// Set an optional title for the list
    /// </summary>
    public TablerCardList Title(string title) {
        ListTitle = title;
        return this;
    }

    /// <summary>
    /// Add items to the list
    /// </summary>
    public TablerCardList WithItems(Action<TablerCardListBuilder> itemsConfig) {
        var builder = new TablerCardListBuilder();
        itemsConfig(builder);
        Items = builder.GetItems();
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var containerDiv = new HtmlTag("div");

        // Add title if specified
        if (!string.IsNullOrEmpty(ListTitle)) {
            var titleElement = new HtmlTag("h4").Value(ListTitle);
            containerDiv.Value(titleElement);
        }

        // Create the list element
        var listTag = ListType == TablerCardListType.Ordered ? "ol" : "ul";
        var listElement = new HtmlTag(listTag);

        var classes = new List<string>();
        var styleClass = ListStyle.ToTablerListStyleClass();
        if (!string.IsNullOrEmpty(styleClass)) {
            classes.Add(styleClass);
        }

        if (classes.Count > 0) {
            listElement.Class(string.Join(" ", classes));
        }

        // Add list items
        foreach (var item in Items) {
            // Pass the list style to items so they can add appropriate classes
            item.SetParentListStyle(ListStyle);
            listElement.Value(item.ToString());
        }

        containerDiv.Value(listElement);
        return containerDiv.ToString();
    }
}

/// <summary>
/// List types
/// </summary>
public enum TablerCardListType {
    /// <summary>Standard unordered list.</summary>
    Unordered,
    /// <summary>Ordered (numbered) list.</summary>
    Ordered
}

/// <summary>
/// List styles for proper Tabler styling
/// </summary>
public enum TablerCardListStyle {
    /// <summary>Default bootstrap list style.</summary>
    Default,
    /// <summary>Removes list styling.</summary>
    Unstyled,
    /// <summary>Displays items inline.</summary>
    Inline,
    /// <summary>Flush list group style.</summary>
    Flush,
    /// <summary>List group style.</summary>
    Group
}

/// <summary>
/// Individual list item
/// </summary>
public class TablerCardListItem : Element {
    private string? ItemText { get; set; }
    private TablerIconType? ItemIcon { get; set; }
    private TablerColor? ItemColor { get; set; }
    private bool IsActive { get; set; } = false;
    private bool IsDisabled { get; set; } = false;
    private string? ItemUrl { get; set; }
    private TablerCardListStyle? ParentListStyle { get; set; }

    /// <summary>
    /// Initializes or configures Text.
    /// </summary>
    public new TablerCardListItem Text(string text) {
        ItemText = text;
        return this;
    }

    /// <summary>
    /// Initializes or configures Icon.
    /// </summary>
    public TablerCardListItem Icon(TablerIconType icon) {
        ItemIcon = icon;
        return this;
    }

    /// <summary>
    /// Initializes or configures Color.
    /// </summary>
    public TablerCardListItem Color(TablerColor color) {
        ItemColor = color;
        return this;
    }

    /// <summary>
    /// Initializes or configures Active.
    /// </summary>
    public TablerCardListItem Active() {
        IsActive = true;
        return this;
    }

    /// <summary>
    /// Initializes or configures Disabled.
    /// </summary>
    public TablerCardListItem Disabled() {
        IsDisabled = true;
        return this;
    }

    /// <summary>
    /// Initializes or configures Url.
    /// </summary>
    public TablerCardListItem Url(string url) {
        ItemUrl = url;
        return this;
    }

    internal void SetParentListStyle(TablerCardListStyle style) {
        ParentListStyle = style;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var listItem = new HtmlTag("li");
        var classes = new List<string>();

        // Add list-group-item class if parent is a list-group
        if (ParentListStyle == TablerCardListStyle.Group) {
            classes.Add("list-group-item");
        }

        if (IsActive) classes.Add("active");
        if (IsDisabled) classes.Add("disabled");

        if (ItemColor.HasValue) {
            classes.Add(ItemColor.Value.ToTablerText());
        }

        if (classes.Count > 0) {
            listItem.Class(string.Join(" ", classes));
        }

        // Create content
        if (!string.IsNullOrEmpty(ItemUrl)) {
            var linkElement = new HtmlTag("a");
            linkElement.Attribute("href", ItemUrl!);

            if (ItemIcon.HasValue) {
                linkElement.Value(new TablerIconElement(ItemIcon.Value).ToString());
                linkElement.Value(" ");
            }

            linkElement.Value(ItemText ?? "");
            listItem.Value(linkElement);
        } else {
            if (ItemIcon.HasValue) {
                listItem.Value(new TablerIconElement(ItemIcon.Value).ToString());
                listItem.Value(" ");
            }

            listItem.Value(ItemText ?? "");
        }

        return listItem.ToString();
    }
}

/// <summary>
/// Builder for list items
/// </summary>
public class TablerCardListBuilder {
    private List<TablerCardListItem> items = new List<TablerCardListItem>();

    /// <summary>
    /// Initializes or configures Item.
    /// </summary>
    public TablerCardListBuilder Item(string text, Action<TablerCardListItem>? config = null) {
        var item = new TablerCardListItem().Text(text);
        config?.Invoke(item);
        items.Add(item);
        return this;
    }

    /// <summary>
    /// Initializes or configures CheckItem.
    /// </summary>
    public TablerCardListBuilder CheckItem(string text, bool isChecked = true) {
        var checkIcon = isChecked ? TablerIconType.Check : TablerIconType.X;
        var checkColor = isChecked ? TablerColor.Success : TablerColor.Danger;

        var item = new TablerCardListItem()
            .Text(text)
            .Icon(checkIcon)
            .Color(checkColor);

        items.Add(item);
        return this;
    }

    /// <summary>
    /// Returns the configured list items.
    /// </summary>
    public List<TablerCardListItem> GetItems() => items;
}

/// <summary>
/// Extension methods for list styling
/// </summary>
public static class TablerCardListExtensions {
    /// <summary>
    /// Initializes or configures ToTablerListStyleClass.
    /// </summary>
    public static string ToTablerListStyleClass(this TablerCardListStyle style) {
        return style switch {
            TablerCardListStyle.Unstyled => "list-unstyled",
            TablerCardListStyle.Inline => "list-inline",
            TablerCardListStyle.Flush => "list-group-flush",
            TablerCardListStyle.Group => "list-group",
            _ => ""
        };
    }
}