using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Configuration options for SmartTab component.
/// </summary>
public class SmartTabOptions {
    /// <summary>Gets or sets the initial selected tab index.</summary>
    [JsonPropertyName("selected")]
    public int? Selected { get; set; }

    /// <summary>Gets or sets the theme.</summary>
    [JsonPropertyName("theme")]
    public string? Theme { get; set; }

    /// <summary>Gets or sets whether navigation menu should be justified.</summary>
    [JsonPropertyName("justified")]
    public bool? Justified { get; set; }

    /// <summary>Gets or sets whether to automatically adjust content height.</summary>
    [JsonPropertyName("autoAdjustHeight")]
    public bool? AutoAdjustHeight { get; set; }

    /// <summary>Gets or sets whether to enable browser back button support.</summary>
    [JsonPropertyName("backButtonSupport")]
    public bool? BackButtonSupport { get; set; }

    /// <summary>Gets or sets whether to enable tab selection via URL hash.</summary>
    [JsonPropertyName("enableUrlHash")]
    public bool? EnableUrlHash { get; set; }

    /// <summary>Gets or sets the transition configuration.</summary>
    [JsonPropertyName("transition")]
    public SmartTabTransition? Transition { get; set; }

    /// <summary>Gets or sets the auto-progress configuration.</summary>
    [JsonPropertyName("autoProgress")]
    public SmartTabAutoProgress? AutoProgress { get; set; }

    /// <summary>Gets or sets the keyboard navigation configuration.</summary>
    [JsonPropertyName("keyboard")]
    public SmartTabKeyboard? Keyboard { get; set; }
}

/// <summary>
/// Transition configuration for SmartTab animations.
/// </summary>
public class SmartTabTransition {
    /// <summary>Gets or sets the animation type.</summary>
    [JsonPropertyName("animation")]
    public string? Animation { get; set; }

    /// <summary>Gets or sets the animation speed in milliseconds.</summary>
    [JsonPropertyName("speed")]
    public string? Speed { get; set; }

    /// <summary>Gets or sets the animation easing function.</summary>
    [JsonPropertyName("easing")]
    public string? Easing { get; set; }

    /// <summary>Gets or sets the CSS class prefix for custom animations.</summary>
    [JsonPropertyName("prefixCss")]
    public string? PrefixCss { get; set; }

    /// <summary>Gets or sets the forward show CSS class.</summary>
    [JsonPropertyName("fwdShowCss")]
    public string? FwdShowCss { get; set; }

    /// <summary>Gets or sets the forward hide CSS class.</summary>
    [JsonPropertyName("fwdHideCss")]
    public string? FwdHideCss { get; set; }

    /// <summary>Gets or sets the backward show CSS class.</summary>
    [JsonPropertyName("bckShowCss")]
    public string? BckShowCss { get; set; }

    /// <summary>Gets or sets the backward hide CSS class.</summary>
    [JsonPropertyName("bckHideCss")]
    public string? BckHideCss { get; set; }
}

/// <summary>
/// Auto-progress configuration for SmartTab.
/// </summary>
public class SmartTabAutoProgress {
    /// <summary>Gets or sets whether auto-progress is enabled.</summary>
    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    /// <summary>Gets or sets the auto-progress interval in milliseconds.</summary>
    [JsonPropertyName("interval")]
    public int? Interval { get; set; }

    /// <summary>Gets or sets whether to pause auto-progress on focus.</summary>
    [JsonPropertyName("stopOnFocus")]
    public bool? StopOnFocus { get; set; }
}

/// <summary>
/// Keyboard navigation configuration for SmartTab.
/// </summary>
public class SmartTabKeyboard {
    /// <summary>Gets or sets whether keyboard navigation is enabled.</summary>
    [JsonPropertyName("keyNavigation")]
    public bool? KeyNavigation { get; set; }

    /// <summary>Gets or sets the left/up arrow key codes.</summary>
    [JsonPropertyName("keyLeft")]
    public int[]? KeyLeft { get; set; }

    /// <summary>Gets or sets the right/down arrow key codes.</summary>
    [JsonPropertyName("keyRight")]
    public int[]? KeyRight { get; set; }

    /// <summary>Gets or sets the home key codes.</summary>
    [JsonPropertyName("keyHome")]
    public int[]? KeyHome { get; set; }

    /// <summary>Gets or sets the end key codes.</summary>
    [JsonPropertyName("keyEnd")]
    public int[]? KeyEnd { get; set; }
}