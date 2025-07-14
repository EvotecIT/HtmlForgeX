namespace HtmlForgeX;

/// <summary>
/// Navigation item for card headers
/// </summary>
public class TablerNavItem {
    public string Text { get; set; } = string.Empty;
    public string Href { get; set; } = "#";
    public bool IsActive { get; set; }
    public bool IsDisabled { get; set; }
    public TablerIconElement Icon { get; set; }
}

/// <summary>
/// Button component for Tabler
/// </summary>
public class TablerButton : Element {
    public new string Text { get; set; } = string.Empty;
    public string Href { get; set; } = "#";
    public TablerButtonVariant Variant { get; set; } = TablerButtonVariant.Primary;
    public TablerButtonSize Size { get; set; } = TablerButtonSize.Default;
    public TablerIconElement Icon { get; set; }
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
    public TablerIconElement Icon { get; set; }
    public string Href { get; set; } = "#";
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
    public List<TablerDropdownItem> Items { get; set; } = new List<TablerDropdownItem>();
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
    public string Text { get; set; } = string.Empty;
    public string Href { get; set; } = "#";
    public bool IsDivider { get; set; }
    public bool IsDanger { get; set; }

    public static TablerDropdownItem Divider() => new TablerDropdownItem { IsDivider = true };
    /// <summary>
    /// Initializes or configures Item.
    /// </summary>
    public static TablerDropdownItem Item(string text, string href = "#", bool isDanger = false) =>
        new TablerDropdownItem { Text = text, Href = href, IsDanger = isDanger };
}

/// <summary>
/// Button variants for Tabler
/// </summary>
public enum TablerButtonVariant {
    Primary,
    Secondary,
    Success,
    Warning,
    Danger,
    Info,
    Light,
    Dark,
    Link,
    Outline
}

/// <summary>
/// Button sizes for Tabler  
/// </summary>
public enum TablerButtonSize {
    Default,
    ExtraSmall,
    Small,
    Large
}