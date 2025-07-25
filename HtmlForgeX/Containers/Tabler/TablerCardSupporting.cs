namespace HtmlForgeX;

/// <summary>
/// Navigation item for card headers
/// </summary>
public class TablerNavItem {
    /// <summary>Display text for the navigation link.</summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>Destination URL for the navigation item.</summary>
    public string Href { get; set; } = "#";

    /// <summary>Indicates whether the item is currently active.</summary>
    public bool IsActive { get; set; }

    /// <summary>Indicates whether the item is disabled.</summary>
    public bool IsDisabled { get; set; }

    /// <summary>Optional icon displayed before the text.</summary>
    public TablerIconElement? Icon { get; set; }
}

/// <summary>
/// Icon button component
/// </summary>
public class TablerIconButton : Element {
    /// <summary>Icon displayed within the button.</summary>
    public new TablerIconElement Icon { get; set; }

    /// <summary>Target URL when the button acts as a link.</summary>
    public string Href { get; set; } = "#";

    /// <summary>Tooltip shown on hover.</summary>
    public string Tooltip { get; set; } = string.Empty;

    /// <summary>
    /// Initializes or configures TablerIconButton.
    /// </summary>
    public TablerIconButton(TablerIconType iconType, string href = "#") {
        Icon = new TablerIconElement(iconType);
        Href = href;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var tag = !string.IsNullOrEmpty(Href) && Href != "#" ? new HtmlTag("a") : new HtmlTag("button");
        tag.Class("btn-action");

        if (!string.IsNullOrEmpty(Href) && Href != "#") {
            tag.Attribute("href", Href);
        }

        if (!string.IsNullOrEmpty(Tooltip)) {
            tag.Attribute("title", Tooltip);
        }

        tag.Value(Icon);

        return tag.ToString();
    }
}

// Note: TablerButton is now defined in Containers/Tabler/TablerButton.cs
// Note: TablerDropdown is now defined in Containers/Tabler/TablerDropdown.cs  
// Use the newer, better versions instead of maintaining duplicates