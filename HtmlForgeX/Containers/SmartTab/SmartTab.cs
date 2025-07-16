using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// SmartTab component for creating responsive tabbed interfaces with extensive customization options.
/// </summary>
public class SmartTab : Element {
    /// <summary>Gets the unique identifier for this SmartTab instance.</summary>
    public string Id { get; }

    /// <summary>Gets the list of tab panels.</summary>
    public List<SmartTabPanel> Panels { get; } = new();

    /// <summary>Gets the configuration options.</summary>
    public SmartTabOptions Options { get; } = new();

    /// <summary>Gets or sets the orientation (horizontal or vertical).</summary>
    public bool IsVertical { get; set; }

    /// <summary>Gets or sets custom CSS classes for the container.</summary>
    public string? ContainerClass { get; set; }

    /// <summary>Gets or sets custom CSS classes for the nav container.</summary>
    public string? NavClass { get; set; }

    /// <summary>Gets or sets custom CSS classes for the content container.</summary>
    public string? ContentClass { get; set; }

    /// <summary>Event handlers for SmartTab events.</summary>
    private readonly Dictionary<string, string> _eventHandlers = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="SmartTab"/> class.
    /// </summary>
    public SmartTab() {
        Id = GlobalStorage.GenerateRandomId("smarttab");
        Options.Selected = 0;
        Options.Justified = true;
        Options.AutoAdjustHeight = true;
        Options.BackButtonSupport = true;
        Options.EnableUrlHash = true;
    }

    #region Tab Management

    /// <summary>
    /// Adds a new tab panel to the SmartTab.
    /// </summary>
    /// <param name="label">The tab label.</param>
    /// <param name="configure">Optional configuration action for the panel.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab AddTab(string label, Action<SmartTabPanel>? configure = null) {
        var panel = new SmartTabPanel(label);
        configure?.Invoke(panel);
        Panels.Add(panel);
        this.Add(panel); // ensure document propagation for library registration
        return this;
    }

    /// <summary>
    /// Adds a new tab panel with icon.
    /// </summary>
    /// <param name="label">The tab label.</param>
    /// <param name="icon">The tab icon.</param>
    /// <param name="configure">Optional configuration action for the panel.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab AddTab(string label, TablerIconType icon, Action<SmartTabPanel>? configure = null) {
        var panel = new SmartTabPanel(label).WithIcon(icon);
        configure?.Invoke(panel);
        Panels.Add(panel);
        this.Add(panel); // ensure document propagation for library registration
        return this;
    }

    /// <summary>
    /// Sets the initially selected tab.
    /// </summary>
    /// <param name="index">The zero-based index of the tab to select.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab WithSelectedTab(int index) {
        Options.Selected = index;
        return this;
    }

    #endregion

    #region Styling

    /// <summary>
    /// Sets the theme for the SmartTab.
    /// </summary>
    /// <param name="theme">The theme to apply.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab WithTheme(SmartTabTheme theme) {
        Options.Theme = theme switch {
            SmartTabTheme.Basic => "basic",
            SmartTabTheme.Classic => "classic",
            SmartTabTheme.Dark => "dark",
            SmartTabTheme.Bootstrap => "bootstrap",
            SmartTabTheme.Square => "square",
            SmartTabTheme.Round => "round",
            SmartTabTheme.Material => "material",
            _ => "basic"
        };
        return this;
    }

    /// <summary>
    /// Sets whether navigation menu should be justified.
    /// </summary>
    /// <param name="justified">Whether to justify navigation menu.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab Justified(bool justified = true) {
        Options.Justified = justified;
        return this;
    }

    /// <summary>
    /// Sets the tab orientation to vertical.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab AsVertical() {
        IsVertical = true;
        return this;
    }

    /// <summary>
    /// Sets custom CSS classes for the container.
    /// </summary>
    /// <param name="cssClass">The CSS class names.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab WithContainerClass(string cssClass) {
        ContainerClass = cssClass;
        return this;
    }

    /// <summary>
    /// Sets custom CSS classes for the nav container.
    /// </summary>
    /// <param name="cssClass">The CSS class names.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab WithNavClass(string cssClass) {
        NavClass = cssClass;
        return this;
    }

    /// <summary>
    /// Sets custom CSS classes for the content container.
    /// </summary>
    /// <param name="cssClass">The CSS class names.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab WithContentClass(string cssClass) {
        ContentClass = cssClass;
        return this;
    }

    #endregion

    #region Behavior

    /// <summary>
    /// Enables or disables automatic height adjustment.
    /// </summary>
    /// <param name="enabled">Whether to enable auto height adjustment.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab AutoAdjustHeight(bool enabled = true) {
        Options.AutoAdjustHeight = enabled;
        return this;
    }

    /// <summary>
    /// Enables or disables browser back button support.
    /// </summary>
    /// <param name="enabled">Whether to enable back button support.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab BackButtonSupport(bool enabled = true) {
        Options.BackButtonSupport = enabled;
        return this;
    }

    /// <summary>
    /// Enables or disables URL hash navigation.
    /// </summary>
    /// <param name="enabled">Whether to enable URL hash navigation.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab EnableUrlHash(bool enabled = true) {
        Options.EnableUrlHash = enabled;
        return this;
    }

    #endregion

    #region Animation

    /// <summary>
    /// Configures the transition animation.
    /// </summary>
    /// <param name="animation">The animation type.</param>
    /// <param name="speed">The animation speed in milliseconds.</param>
    /// <param name="easing">The easing function.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab WithTransition(SmartTabAnimation animation, int speed = 400, string? easing = null) {
        Options.Transition ??= new SmartTabTransition();
        Options.Transition.Animation = animation switch {
            SmartTabAnimation.None => "none",
            SmartTabAnimation.Fade => "fade",
            SmartTabAnimation.SlideHorizontal => "slideHorizontal",
            SmartTabAnimation.SlideVertical => "slideVertical",
            SmartTabAnimation.SlideSwing => "slideSwing",
            SmartTabAnimation.Css => "css",
            _ => "none"
        };
        Options.Transition.Speed = speed.ToString();
        Options.Transition.Easing = easing;
        return this;
    }

    /// <summary>
    /// Configures custom CSS animation classes.
    /// </summary>
    /// <param name="prefixCss">CSS class prefix.</param>
    /// <param name="fwdShowCss">Forward show CSS class.</param>
    /// <param name="fwdHideCss">Forward hide CSS class.</param>
    /// <param name="bckShowCss">Backward show CSS class.</param>
    /// <param name="bckHideCss">Backward hide CSS class.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab WithCustomAnimation(string prefixCss, string? fwdShowCss = null, string? fwdHideCss = null, 
        string? bckShowCss = null, string? bckHideCss = null) {
        Options.Transition ??= new SmartTabTransition();
        Options.Transition.Animation = "css";
        Options.Transition.PrefixCss = prefixCss;
        Options.Transition.FwdShowCss = fwdShowCss;
        Options.Transition.FwdHideCss = fwdHideCss;
        Options.Transition.BckShowCss = bckShowCss;
        Options.Transition.BckHideCss = bckHideCss;
        return this;
    }

    #endregion

    #region Auto Progress

    /// <summary>
    /// Enables auto-progress functionality.
    /// </summary>
    /// <param name="interval">The interval in milliseconds.</param>
    /// <param name="stopOnFocus">Whether to pause on focus.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab EnableAutoProgress(int interval = 3500, bool stopOnFocus = true) {
        Options.AutoProgress ??= new SmartTabAutoProgress();
        Options.AutoProgress.Enabled = true;
        Options.AutoProgress.Interval = interval;
        Options.AutoProgress.StopOnFocus = stopOnFocus;
        return this;
    }

    /// <summary>
    /// Disables auto-progress functionality.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab DisableAutoProgress() {
        Options.AutoProgress ??= new SmartTabAutoProgress();
        Options.AutoProgress.Enabled = false;
        return this;
    }

    #endregion

    #region Keyboard Navigation

    /// <summary>
    /// Configures keyboard navigation.
    /// </summary>
    /// <param name="enabled">Whether to enable keyboard navigation.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab WithKeyboardNavigation(bool enabled = true) {
        Options.Keyboard ??= new SmartTabKeyboard();
        Options.Keyboard.KeyNavigation = enabled;
        return this;
    }

    /// <summary>
    /// Configures custom keyboard shortcuts.
    /// </summary>
    /// <param name="configure">Configuration action for keyboard settings.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab ConfigureKeyboard(Action<SmartTabKeyboard> configure) {
        Options.Keyboard ??= new SmartTabKeyboard();
        configure(Options.Keyboard);
        return this;
    }

    #endregion

    #region Events

    /// <summary>
    /// Adds an event handler for the initialized event.
    /// </summary>
    /// <param name="handler">The JavaScript event handler code.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab OnInitialized(string handler) {
        _eventHandlers["initialized"] = handler;
        return this;
    }

    /// <summary>
    /// Adds an event handler for the loaded event.
    /// </summary>
    /// <param name="handler">The JavaScript event handler code.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab OnLoaded(string handler) {
        _eventHandlers["loaded"] = handler;
        return this;
    }

    /// <summary>
    /// Adds an event handler for the leaveTab event.
    /// </summary>
    /// <param name="handler">The JavaScript event handler code.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab OnLeaveTab(string handler) {
        _eventHandlers["leaveTab"] = handler;
        return this;
    }

    /// <summary>
    /// Adds an event handler for the showTab event.
    /// </summary>
    /// <param name="handler">The JavaScript event handler code.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartTab OnShowTab(string handler) {
        _eventHandlers["showTab"] = handler;
        return this;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Generates JavaScript code to navigate to the next tab.
    /// </summary>
    /// <returns>JavaScript method call string.</returns>
    public string GoToNext() => $"$('#{Id}').smartTab('next')";

    /// <summary>
    /// Generates JavaScript code to navigate to the previous tab.
    /// </summary>
    /// <returns>JavaScript method call string.</returns>
    public string GoToPrevious() => $"$('#{Id}').smartTab('prev')";

    /// <summary>
    /// Generates JavaScript code to navigate to a specific tab.
    /// </summary>
    /// <param name="index">The tab index.</param>
    /// <returns>JavaScript method call string.</returns>
    public string GoToTab(int index) => $"$('#{Id}').smartTab('goToTab', {index})";

    /// <summary>
    /// Generates JavaScript code to reset the tabs.
    /// </summary>
    /// <returns>JavaScript method call string.</returns>
    public string Reset() => $"$('#{Id}').smartTab('reset')";

    #endregion

    #region Rendering

    /// <summary>
    /// Registers the required libraries for SmartTab.
    /// </summary>
    protected internal override void RegisterLibraries() {
        base.RegisterLibraries();
        Document?.AddLibrary(Libraries.JQuery);
        Document?.AddLibrary(Libraries.SmartTab, 10);
    }

    /// <summary>
    /// Builds the SmartTab HTML markup.
    /// </summary>
    public override string ToString() {
        if (!Panels.Any()) {
            return "<!-- SmartTab: No panels defined -->";
        }

        RegisterLibraries();

        var containerClasses = new List<string>();
        if (IsVertical) containerClasses.Add("st-vertical");
        if (!string.IsNullOrEmpty(ContainerClass)) containerClasses.Add(ContainerClass);

        var navClasses = new List<string> { "nav" };
        if (IsVertical) navClasses.Add("flex-column nav-pills");
        else navClasses.Add("nav-tabs");
        if (!string.IsNullOrEmpty(NavClass)) navClasses.Add(NavClass);

        var contentClasses = new List<string> { "tab-content" };
        if (!string.IsNullOrEmpty(ContentClass)) contentClasses.Add(ContentClass);

        // Build tabs navigation
        var tabsHtml = new List<string>();
        for (int i = 0; i < Panels.Count; i++) {
            var isActive = i == (Options.Selected ?? 0);
            tabsHtml.Add($"<li class=\"nav-item\" role=\"presentation\">{Panels[i].BuildTabItem(isActive)}</li>");
        }

        // Build tab panels
        var panelsHtml = new List<string>();
        for (int i = 0; i < Panels.Count; i++) {
            var isActive = i == (Options.Selected ?? 0);
            panelsHtml.Add(Panels[i].BuildTabPanel(isActive));
        }

        // Build the complete structure
        var html = new List<string> {
            $"<div id=\"{Id}\" class=\"{string.Join(" ", containerClasses)}\">",
            $"  <ul class=\"{string.Join(" ", navClasses)}\" role=\"tablist\">",
            string.Join("\n    ", tabsHtml),
            "  </ul>",
            $"  <div class=\"{string.Join(" ", contentClasses)}\">",
            string.Join("\n    ", panelsHtml),
            "  </div>",
            "</div>"
        };

        // Build initialization script
        var script = BuildInitializationScript();
        html.Add(script);

        return string.Join("\n", html);
    }

    /// <summary>
    /// Builds the SmartTab initialization script.
    /// </summary>
    private string BuildInitializationScript() {
        // Prepare configuration
        var config = new Dictionary<string, object?>();
        
        // Add all non-null options
        var optionsJson = JsonSerializer.Serialize(Options, new JsonSerializerOptions {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        });

        var optionsDict = JsonSerializer.Deserialize<Dictionary<string, object?>>(optionsJson);
        if (optionsDict != null) {
            foreach (var kv in optionsDict.Where(kv => kv.Value != null)) {
                config[kv.Key] = kv.Value;
            }
        }

        // Build event handlers
        var eventScript = new List<string>();
        foreach (var evt in _eventHandlers) {
            eventScript.Add($"$('#{Id}').on('{evt.Key}', {evt.Value});");
        }

        // Handle Ajax content loading
        var ajaxScript = new List<string>();
        foreach (var panel in Panels.Where(p => !string.IsNullOrEmpty(p.AjaxUrl))) {
            var cacheAttr = panel.CacheAjax ? "true" : "false";
            ajaxScript.Add($@"
                $('#{Id}').on('showTab', function(e, anchorObject, tabIndex) {{
                    if (anchorObject.attr('href') === '#{panel.Id}' && !anchorObject.data('loaded')) {{
                        var $panel = $('#{panel.Id}');
                        $.ajax({{
                            url: '{panel.AjaxUrl}',
                            cache: {cacheAttr},
                            success: function(data) {{
                                $panel.html(data);
                                anchorObject.data('loaded', true);
                            }},
                            error: function() {{
                                $panel.html('<div class=""alert alert-danger"">Failed to load content</div>');
                            }}
                        }});
                    }}
                }});");
        }

        var configJson = JsonSerializer.Serialize(config, new JsonSerializerOptions {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        });

        var script = $@"<script>
$(document).ready(function() {{
    $('#{Id}').smartTab({configJson});
    {string.Join("\n    ", eventScript)}
    {string.Join("\n    ", ajaxScript)}
}});
</script>";

        return script;
    }

    #endregion
}