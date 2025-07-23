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
/// Button component for Tabler
/// </summary>
public class TablerButton : Element {
    /// <summary>Button label text.</summary>
    public new string Text { get; set; } = string.Empty;

    /// <summary>Target URL if the button behaves as a link.</summary>
    public string Href { get; set; } = "#";

    /// <summary>Visual variant of the button.</summary>
    public TablerButtonVariant Variant { get; set; } = TablerButtonVariant.Primary;

    /// <summary>Size of the button.</summary>
    public TablerButtonSize Size { get; set; } = TablerButtonSize.Default;

    /// <summary>Optional icon displayed before the text.</summary>
    public new TablerIconElement? Icon { get; set; }

    /// <summary>Indicates whether the button is disabled.</summary>
    public bool IsDisabled { get; set; }

    /// <summary>
    /// Initializes or configures TablerButton.
    /// </summary>
    public TablerButton() { }

    /// <summary>
    /// Initializes or configures TablerButton.
    /// </summary>
    public TablerButton(string text, string href = "#", TablerButtonVariant variant = TablerButtonVariant.Primary) {
        Text = text;
        Href = href;
        Variant = variant;
    }

    /// <summary>
    /// Initializes or configures WithIcon.
    /// </summary>
    public TablerButton WithIcon(TablerIconType iconType) {
        Icon = new TablerIconElement(iconType);
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var tag = !string.IsNullOrEmpty(Href) && Href != "#" ? new HtmlTag("a") : new HtmlTag("button");

        var classes = new List<string> { "btn" };

        var variantClass = Variant switch {
            TablerButtonVariant.Primary => "btn-primary",
            TablerButtonVariant.Secondary => "btn-secondary",
            TablerButtonVariant.Success => "btn-success",
            TablerButtonVariant.Warning => "btn-warning",
            TablerButtonVariant.Danger => "btn-danger",
            TablerButtonVariant.Info => "btn-info",
            TablerButtonVariant.Light => "btn-light",
            TablerButtonVariant.Dark => "btn-dark",
            TablerButtonVariant.Link => "btn-link",
            TablerButtonVariant.Outline => "btn-outline",
            _ => "btn-primary"
        };

        classes.Add(variantClass);

        if (Size != TablerButtonSize.Default) {
            var sizeClass = Size switch {
                TablerButtonSize.Small => "btn-sm",
                TablerButtonSize.Large => "btn-lg",
                TablerButtonSize.ExtraSmall => "btn-xs",
                _ => ""
            };
            if (!string.IsNullOrEmpty(sizeClass)) {
                classes.Add(sizeClass);
            }
        }

        tag.Class(string.Join(" ", classes));

        if (!string.IsNullOrEmpty(Href) && Href != "#") {
            tag.Attribute("href", Href);
        } else {
            tag.Attribute("type", "button");
        }

        if (IsDisabled) {
            if (!string.IsNullOrEmpty(Href) && Href != "#") {
                tag.Class("disabled");
                tag.Attribute("tabindex", "-1");
                tag.Attribute("aria-disabled", "true");
            } else {
                tag.Attribute("disabled", "");
            }
        }

        if (Icon != null) {
            tag.Value(Icon.ToString() + " ");
        }

        tag.Value(Text);

        return tag.ToString();
    }
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

/// <summary>
/// Dropdown component
/// </summary>
public class TablerDropdown : Element {
    /// <summary>Collection of dropdown menu items.</summary>
    public List<TablerDropdownItem> Items { get; set; } = new List<TablerDropdownItem>();

    /// <summary>Icon used for the dropdown trigger button.</summary>
    public TablerIconElement TriggerIcon { get; set; } = new TablerIconElement(TablerIconType.DotsVertical);

    /// <summary>
    /// Initializes a new instance of the <see cref="TablerDropdown"/> class.
    /// </summary>
    public TablerDropdown() {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TablerDropdown"/> class with predefined items.
    /// </summary>
    /// <param name="items">Initial dropdown items.</param>
    public TablerDropdown(List<TablerDropdownItem> items) {
        Items = items;
    }

    /// <summary>Adds a clickable item to the dropdown.</summary>
    public TablerDropdown AddItem(string text, string href = "#", bool isDanger = false) {
        Items.Add(new TablerDropdownItem { Text = text, Href = href, IsDanger = isDanger });
        return this;
    }

    /// <summary>Adds a divider to the dropdown.</summary>
    public TablerDropdown AddDivider() {
        Items.Add(new TablerDropdownItem { IsDivider = true });
        return this;
    }

    /// <summary>Sets the icon used for the dropdown trigger.</summary>
    public TablerDropdown Icon(TablerIconType icon) {
        TriggerIcon = new TablerIconElement(icon);
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var dropdownDiv = new HtmlTag("div").Class("dropdown");

        var trigger = new HtmlTag("a")
            .Class("btn-action dropdown-toggle")
            .Attribute("href", "#")
            .Attribute("data-bs-toggle", "dropdown")
            .Attribute("aria-haspopup", "true")
            .Attribute("aria-expanded", "false");

        trigger.Value(TriggerIcon);
        dropdownDiv.Value(trigger);

        var menu = new HtmlTag("div").Class("dropdown-menu dropdown-menu-end");

        foreach (var item in Items) {
            if (item.IsDivider) {
                menu.Value(new HtmlTag("div").Class("dropdown-divider"));
            } else {
                var link = new HtmlTag("a").Class("dropdown-item").Value(item.Text);
                if (!string.IsNullOrEmpty(item.Href)) {
                    link.Attribute("href", item.Href);
                }
                if (item.IsDanger) {
                    link.Class("text-danger");
                }
                menu.Value(link);
            }
        }

        dropdownDiv.Value(menu);

        return dropdownDiv.ToString();
    }
}

/// <summary>
/// Dropdown item
/// </summary>
public class TablerDropdownItem {
    /// <summary>Display text for the menu item.</summary>
    public string Text { get; set; } = string.Empty;

    /// <summary>Navigation target for the item.</summary>
    public string Href { get; set; } = "#";

    /// <summary>Indicates whether this item is rendered as a divider.</summary>
    public bool IsDivider { get; set; }

    /// <summary>Marks the item as a dangerous/destructive action.</summary>
    public bool IsDanger { get; set; }

    /// <summary>
    /// Creates a divider item for use within a dropdown menu.
    /// </summary>
    public static TablerDropdownItem Divider() => new TablerDropdownItem { IsDivider = true };

    /// <summary>
    /// Creates a clickable dropdown item.
    /// </summary>
    /// <param name="text">Item display text.</param>
    /// <param name="href">Optional URL for the link.</param>
    /// <param name="isDanger">If <c>true</c>, marks the item as destructive.</param>
    /// <returns>The configured dropdown item.</returns>
    public static TablerDropdownItem Item(string text, string href = "#", bool isDanger = false) =>
        new TablerDropdownItem { Text = text, Href = href, IsDanger = isDanger };
}

/// <summary>
/// Button variants for Tabler
/// </summary>
public enum TablerButtonVariant {
    /// <summary>Primary button style.</summary>
    Primary,
    /// <summary>Secondary button style.</summary>
    Secondary,
    /// <summary>Success button style.</summary>
    Success,
    /// <summary>Warning button style.</summary>
    Warning,
    /// <summary>Danger button style.</summary>
    Danger,
    /// <summary>Informational button style.</summary>
    Info,
    /// <summary>Light button style.</summary>
    Light,
    /// <summary>Dark button style.</summary>
    Dark,
    /// <summary>Link-styled button.</summary>
    Link,
    /// <summary>Outline button style.</summary>
    Outline
}

/// <summary>
/// Button sizes for Tabler  
/// </summary>
public enum TablerButtonSize {
    /// <summary>Default button size.</summary>
    Default,
    /// <summary>Extra small button.</summary>
    ExtraSmall,
    /// <summary>Small button.</summary>
    Small,
    /// <summary>Large button.</summary>
    Large
}