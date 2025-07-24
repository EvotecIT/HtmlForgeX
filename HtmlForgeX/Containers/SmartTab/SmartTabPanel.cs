using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Represents a tab panel in the SmartTab component.
/// </summary>
public class SmartTabPanel : ElementContainer {
    /// <summary>Gets or sets the panel identifier.</summary>
    public string Id { get; set; }

    /// <summary>Gets or sets the tab label.</summary>
    public string Label { get; set; }

    /// <summary>Gets or sets the tab icon.</summary>
    public new TablerIconType? Icon { get; set; }

    /// <summary>Gets or sets whether this tab is disabled.</summary>
    public bool Disabled { get; set; }

    /// <summary>Gets or sets whether this tab is hidden.</summary>
    public bool Hidden { get; set; }

    /// <summary>Gets or sets a custom CSS class for the tab.</summary>
    public string? TabClass { get; set; }

    /// <summary>Gets or sets a custom CSS class for the panel content.</summary>
    public string? PanelClass { get; set; }

    /// <summary>Gets or sets the URL for ajax content loading.</summary>
    public string? AjaxUrl { get; set; }

    /// <summary>Gets or sets whether to cache ajax content.</summary>
    public bool CacheAjax { get; set; } = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="SmartTabPanel"/> class.
    /// </summary>
    /// <param name="label">The tab label.</param>
    public SmartTabPanel(string label) {
        Label = label;
        Id = GlobalStorage.GenerateRandomId("tab-panel");
    }

    /// <summary>
    /// Sets the tab icon.
    /// </summary>
    /// <param name="icon">The icon type.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTabPanel WithIcon(TablerIconType icon) {
        Icon = icon;
        return this;
    }

    /// <summary>
    /// Marks the tab as disabled.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTabPanel AsDisabled() {
        Disabled = true;
        return this;
    }

    /// <summary>
    /// Marks the tab as hidden.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTabPanel AsHidden() {
        Hidden = true;
        return this;
    }

    /// <summary>
    /// Sets a custom CSS class for the tab.
    /// </summary>
    /// <param name="cssClass">The CSS class name.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTabPanel WithTabClass(string cssClass) {
        TabClass = cssClass;
        return this;
    }

    /// <summary>
    /// Sets a custom CSS class for the panel content.
    /// </summary>
    /// <param name="cssClass">The CSS class name.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTabPanel WithPanelClass(string cssClass) {
        PanelClass = cssClass;
        return this;
    }

    /// <summary>
    /// Configures ajax content loading for this tab.
    /// </summary>
    /// <param name="url">The URL to load content from.</param>
    /// <param name="cache">Whether to cache the loaded content.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTabPanel WithAjaxContent(string url, bool cache = true) {
        AjaxUrl = url;
        CacheAjax = cache;
        return this;
    }

    /// <summary>
    /// Builds the tab list item markup.
    /// </summary>
    internal string BuildTabItem(bool isActive = false) {
        var classes = new List<string> { "nav-link" };
        if (isActive) classes.Add("active");
        if (Disabled) classes.Add("disabled");
        if (!string.IsNullOrEmpty(TabClass)) classes.Add(TabClass!);

        var attributes = new List<string> {
            $"href=\"#{Id}\"",
            $"data-bs-toggle=\"tab\""
        };

        if (Disabled) attributes.Add("tabindex=\"-1\"");
        if (Hidden) attributes.Add("style=\"display: none;\"");

        var content = new List<string>();
        if (Icon.HasValue) {
            var iconClass = GetIconClass(Icon.Value);
            content.Add($"<i class=\"{iconClass} me-2\"></i>");
        }
        content.Add(Label);

        return $"<a class=\"{string.Join(" ", classes)}\" {string.Join(" ", attributes)}>{string.Join("", content)}</a>";
    }

    /// <summary>
    /// Converts TablerIconType to CSS class name.
    /// </summary>
    private string GetIconClass(TablerIconType iconType) {
        // Convert enum to kebab-case CSS class name
        var iconName = iconType.ToString()
            .Replace("_", "-")
            .ToLowerInvariant();
        return $"ti-{iconName}";
    }

    /// <summary>
    /// Builds the tab panel content markup.
    /// </summary>
    internal string BuildTabPanel(bool isActive = false) {
        var classes = new List<string> { "tab-pane" };
        if (isActive) classes.Add("active");
        if (!string.IsNullOrEmpty(PanelClass)) classes.Add(PanelClass!);

        var attributes = new List<string> {
            $"id=\"{Id}\"",
            $"role=\"tabpanel\""
        };

        if (Hidden) attributes.Add("style=\"display: none;\"");

        // Build content
        string content;
        if (!string.IsNullOrEmpty(AjaxUrl)) {
            content = $"<div class=\"text-center\"><div class=\"spinner-border\" role=\"status\"><span class=\"visually-hidden\">Loading...</span></div></div>";
        } else {
            content = string.Join("", Children.WhereNotNull().Select(child => child.ToString()));
        }

        return $"<div class=\"{string.Join(" ", classes)}\" {string.Join(" ", attributes)}>{content}</div>";
    }
}