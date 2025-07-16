using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Configuration options for SmartWizard component.
/// </summary>
public class SmartWizardOptions {
    /// <summary>Gets or sets the initial selected step index.</summary>
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

    /// <summary>Gets or sets whether to enable step selection via URL hash.</summary>
    [JsonPropertyName("enableUrlHash")]
    public bool? EnableUrlHash { get; set; }

    /// <summary>Gets or sets the transition configuration.</summary>
    [JsonPropertyName("transition")]
    public SmartWizardTransition? Transition { get; set; }

    /// <summary>Gets or sets the toolbar configuration.</summary>
    [JsonPropertyName("toolbar")]
    public SmartWizardToolbar? Toolbar { get; set; }

    /// <summary>Gets or sets the anchor configuration.</summary>
    [JsonPropertyName("anchor")]
    public SmartWizardAnchor? Anchor { get; set; }

    /// <summary>Gets or sets the keyboard navigation configuration.</summary>
    [JsonPropertyName("keyboard")]
    public SmartWizardKeyboard? Keyboard { get; set; }

    /// <summary>Gets or sets the language configuration.</summary>
    [JsonPropertyName("lang")]
    public SmartWizardLanguage? Language { get; set; }

    /// <summary>Gets or sets the disabled steps array.</summary>
    [JsonPropertyName("disabledSteps")]
    public int[]? DisabledSteps { get; set; }

    /// <summary>Gets or sets the error steps array.</summary>
    [JsonPropertyName("errorSteps")]
    public int[]? ErrorSteps { get; set; }

    /// <summary>Gets or sets the warning steps array.</summary>
    [JsonPropertyName("warningSteps")]
    public int[]? WarningSteps { get; set; }

    /// <summary>Gets or sets the hidden steps array.</summary>
    [JsonPropertyName("hiddenSteps")]
    public int[]? HiddenSteps { get; set; }
}

/// <summary>
/// Transition configuration for SmartWizard animations.
/// </summary>
public class SmartWizardTransition {
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
/// Toolbar configuration for SmartWizard.
/// </summary>
public class SmartWizardToolbar {
    /// <summary>Gets or sets the toolbar position.</summary>
    [JsonPropertyName("position")]
    public string? Position { get; set; }

    /// <summary>Gets or sets whether to show the Next button.</summary>
    [JsonPropertyName("showNextButton")]
    public bool? ShowNextButton { get; set; }

    /// <summary>Gets or sets whether to show the Previous button.</summary>
    [JsonPropertyName("showPreviousButton")]
    public bool? ShowPreviousButton { get; set; }

    /// <summary>Gets or sets extra HTML content for the toolbar.</summary>
    [JsonPropertyName("extraHtml")]
    public string? ExtraHtml { get; set; }
}

/// <summary>
/// Anchor configuration for SmartWizard navigation.
/// </summary>
public class SmartWizardAnchor {
    /// <summary>Gets or sets whether to enable anchor navigation.</summary>
    [JsonPropertyName("enableNavigation")]
    public bool? EnableNavigation { get; set; }

    /// <summary>Gets or sets whether to always enable navigation.</summary>
    [JsonPropertyName("enableNavigationAlways")]
    public bool? EnableNavigationAlways { get; set; }

    /// <summary>Gets or sets whether to enable done state.</summary>
    [JsonPropertyName("enableDoneState")]
    public bool? EnableDoneState { get; set; }

    /// <summary>Gets or sets whether to mark previous steps as done.</summary>
    [JsonPropertyName("markPreviousStepsAsDone")]
    public bool? MarkPreviousStepsAsDone { get; set; }

    /// <summary>Gets or sets whether to unmark steps on back navigation.</summary>
    [JsonPropertyName("unDoneOnBackNavigation")]
    public bool? UnDoneOnBackNavigation { get; set; }

    /// <summary>Gets or sets whether to enable navigation on done steps.</summary>
    [JsonPropertyName("enableDoneStateNavigation")]
    public bool? EnableDoneStateNavigation { get; set; }
}

/// <summary>
/// Keyboard navigation configuration for SmartWizard.
/// </summary>
public class SmartWizardKeyboard {
    /// <summary>Gets or sets whether keyboard navigation is enabled.</summary>
    [JsonPropertyName("keyNavigation")]
    public bool? KeyNavigation { get; set; }

    /// <summary>Gets or sets the left arrow key codes.</summary>
    [JsonPropertyName("keyLeft")]
    public int[]? KeyLeft { get; set; }

    /// <summary>Gets or sets the right arrow key codes.</summary>
    [JsonPropertyName("keyRight")]
    public int[]? KeyRight { get; set; }

    /// <summary>Gets or sets the home key codes.</summary>
    [JsonPropertyName("keyHome")]
    public int[]? KeyHome { get; set; }

    /// <summary>Gets or sets the end key codes.</summary>
    [JsonPropertyName("keyEnd")]
    public int[]? KeyEnd { get; set; }
}

/// <summary>
/// Language configuration for SmartWizard.
/// </summary>
public class SmartWizardLanguage {
    /// <summary>Gets or sets the Next button text.</summary>
    [JsonPropertyName("next")]
    public string? Next { get; set; }

    /// <summary>Gets or sets the Previous button text.</summary>
    [JsonPropertyName("previous")]
    public string? Previous { get; set; }
}