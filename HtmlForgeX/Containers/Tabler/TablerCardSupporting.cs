namespace HtmlForgeX;

/// <summary>
/// Navigation item for card headers
/// </summary>
public class TablerNavItem {
    /// <summary>Navigation item caption.</summary>
    public string Text { get; set; } = string.Empty;
    /// <summary>Destination for the navigation link.</summary>
    public string Href { get; set; } = "#";
    /// <summary>Whether the item is active.</summary>
    public bool IsActive { get; set; }
    /// <summary>Disables the navigation item.</summary>
    public bool IsDisabled { get; set; }
    /// <summary>Optional icon associated with the item.</summary>
    public TablerIconElement Icon { get; set; }
}

/// <summary>
/// Button component for Tabler
/// </summary>
public class TablerButton : Element {
    /// <summary>Button label text.</summary>
    public new string Text { get; set; } = string.Empty;
    /// <summary>Hyperlink reference for the button.</summary>
    public string Href { get; set; } = "#";
    /// <summary>Visual variant of the button.</summary>
    public TablerButtonVariant Variant { get; set; } = TablerButtonVariant.Primary;
    /// <summary>Button size.</summary>
    public TablerButtonSize Size { get; set; } = TablerButtonSize.Default;
    /// <summary>Optional icon displayed within the button.</summary>
    public TablerIconElement Icon { get; set; }
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
    /// <summary>Icon displayed inside the button.</summary>
    public TablerIconElement Icon { get; set; }
    /// <summary>Destination URL for the button.</summary>
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
    /// <summary>List of dropdown menu items.</summary>
    public List<TablerDropdownItem> Items { get; set; } = new List<TablerDropdownItem>();
    /// <summary>Icon used as the dropdown trigger.</summary>
    public TablerIconElement TriggerIcon { get; set; }

    /// <summary>
    /// Initializes or configures TablerDropdown.
    /// </summary>
    public TablerDropdown(List<TablerDropdownItem> items) {
        Items = items;
        TriggerIcon = new TablerIconElement(TablerIconType.DotsVertical);
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
    /// <summary>Displayed text for the item.</summary>
    public string Text { get; set; } = string.Empty;
    /// <summary>Destination link for the item.</summary>
    public string Href { get; set; } = "#";
    /// <summary>Indicates whether this item is a divider.</summary>
    public bool IsDivider { get; set; }
    /// <summary>Marks the item as dangerous.</summary>
    public bool IsDanger { get; set; }

    /// <summary>
    /// Creates a menu item acting as a divider.
    /// </summary>
    public static TablerDropdownItem Divider() => new TablerDropdownItem { IsDivider = true };
    /// <summary>
    /// Initializes or configures Item.
    /// </summary>
    /// <summary>
    /// Creates a standard dropdown item.
    /// </summary>
    /// <param name="text">Display text.</param>
    /// <param name="href">Navigation link.</param>
    /// <param name="isDanger">Marks the item as dangerous.</param>
    /// <returns>Configured <see cref="TablerDropdownItem"/> instance.</returns>
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
    /// <summary>Light themed button.</summary>
    Light,
    /// <summary>Dark themed button.</summary>
    Dark,
    /// <summary>Link styled button.</summary>
    Link,
    /// <summary>Outline variant.</summary>
    Outline
}

/// <summary>
/// Button sizes for Tabler  
/// </summary>
public enum TablerButtonSize {
    /// <summary>Default size.</summary>
    Default,
    /// <summary>Extra small button.</summary>
    ExtraSmall,
    /// <summary>Small button.</summary>
    Small,
    /// <summary>Large button.</summary>
    Large
}