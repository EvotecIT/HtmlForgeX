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
/// Method ToString.
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
    Unordered,
    Ordered
}

/// <summary>
/// List styles for proper Tabler styling
/// </summary>
public enum TablerCardListStyle {
    Default,
    Unstyled,
    Inline,
    Flush,
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
/// Method Text.
/// </summary>
    public TablerCardListItem Text(string text) {
        ItemText = text;
        return this;
    }
    
/// <summary>
/// Method Icon.
/// </summary>
    public TablerCardListItem Icon(TablerIconType icon) {
        ItemIcon = icon;
        return this;
    }
    
/// <summary>
/// Method Color.
/// </summary>
    public TablerCardListItem Color(TablerColor color) {
        ItemColor = color;
        return this;
    }
    
/// <summary>
/// Method Active.
/// </summary>
    public TablerCardListItem Active() {
        IsActive = true;
        return this;
    }
    
/// <summary>
/// Method Disabled.
/// </summary>
    public TablerCardListItem Disabled() {
        IsDisabled = true;
        return this;
    }
    
/// <summary>
/// Method Url.
/// </summary>
    public TablerCardListItem Url(string url) {
        ItemUrl = url;
        return this;
    }
    
    internal void SetParentListStyle(TablerCardListStyle style) {
        ParentListStyle = style;
    }
    
/// <summary>
/// Method ToString.
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
            linkElement.Attribute("href", ItemUrl);
            
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
/// Method Item.
/// </summary>
    public TablerCardListBuilder Item(string text, Action<TablerCardListItem>? config = null) {
        var item = new TablerCardListItem().Text(text);
        config?.Invoke(item);
        items.Add(item);
        return this;
    }
    
/// <summary>
/// Method CheckItem.
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
/// Method GetItems.
/// </summary>
    public List<TablerCardListItem> GetItems() => items;
}

/// <summary>
/// Extension methods for list styling
/// </summary>
public static class TablerCardListExtensions {
/// <summary>
/// Method ToTablerListStyleClass.
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