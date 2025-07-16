using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// SmartWizard component for creating step-by-step wizards with validation support.
/// </summary>
public class SmartWizard : Element {
    /// <summary>Gets the unique identifier for this SmartWizard instance.</summary>
    public string Id { get; }

    /// <summary>Gets the list of wizard steps.</summary>
    public List<SmartWizardStep> Steps { get; } = new();

    /// <summary>Gets the configuration options.</summary>
    public SmartWizardOptions Options { get; } = new();

    /// <summary>Gets or sets the orientation (horizontal or vertical).</summary>
    public bool IsVertical { get; set; }

    /// <summary>Gets or sets custom CSS classes for the container.</summary>
    public string? ContainerClass { get; set; }

    /// <summary>Gets or sets custom CSS classes for the nav container.</summary>
    public string? NavClass { get; set; }

    /// <summary>Gets or sets custom CSS classes for the content container.</summary>
    public string? ContentClass { get; set; }

    /// <summary>Event handlers for SmartWizard events.</summary>
    private readonly Dictionary<string, string> _eventHandlers = new();

    /// <summary>Custom validation functions for steps.</summary>
    private readonly Dictionary<int, string> _validationFunctions = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="SmartWizard"/> class.
    /// </summary>
    public SmartWizard() {
        Id = GlobalStorage.GenerateRandomId("smartwizard");
        
        // Set default options
        Options.Selected = 0;
        Options.Justified = true;
        Options.AutoAdjustHeight = true;
        Options.BackButtonSupport = true;
        Options.EnableUrlHash = true;
        
        // Default toolbar settings
        Options.Toolbar = new SmartWizardToolbar {
            Position = "bottom",
            ShowNextButton = true,
            ShowPreviousButton = true
        };
        
        // Default anchor settings
        Options.Anchor = new SmartWizardAnchor {
            EnableNavigation = true,
            EnableDoneState = true,
            MarkPreviousStepsAsDone = true,
            EnableDoneStateNavigation = true
        };
        
        // Default language settings
        Options.Language = new SmartWizardLanguage {
            Next = "Next",
            Previous = "Previous"
        };
    }

    #region Step Management

    /// <summary>
    /// Adds a new step to the wizard.
    /// </summary>
    /// <param name="title">The step title.</param>
    /// <param name="configure">Optional configuration action for the step.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard AddStep(string title, Action<SmartWizardStep>? configure = null) {
        var step = new SmartWizardStep(title);
        configure?.Invoke(step);
        Steps.Add(step);
        this.Add(step); // ensure document propagation for library registration
        return this;
    }

    /// <summary>
    /// Adds a new step with icon and subtitle.
    /// </summary>
    /// <param name="title">The step title.</param>
    /// <param name="icon">The step icon.</param>
    /// <param name="subtitle">The step subtitle.</param>
    /// <param name="configure">Optional configuration action for the step.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard AddStep(string title, TablerIconType icon, string? subtitle = null, Action<SmartWizardStep>? configure = null) {
        var step = new SmartWizardStep(title).WithIcon(icon);
        if (!string.IsNullOrEmpty(subtitle)) step.WithSubtitle(subtitle);
        configure?.Invoke(step);
        Steps.Add(step);
        this.Add(step); // ensure document propagation for library registration
        return this;
    }

    /// <summary>
    /// Adds a new step with icon and configuration.
    /// </summary>
    /// <param name="title">The step title.</param>
    /// <param name="icon">The step icon.</param>
    /// <param name="configure">Configuration action for the step.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard AddStep(string title, TablerIconType icon, Action<SmartWizardStep> configure) {
        var step = new SmartWizardStep(title).WithIcon(icon);
        configure.Invoke(step);
        Steps.Add(step);
        this.Add(step); // ensure document propagation for library registration
        return this;
    }

    /// <summary>
    /// Sets the initially selected step.
    /// </summary>
    /// <param name="index">The zero-based index of the step to select.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard WithSelectedStep(int index) {
        Options.Selected = index;
        return this;
    }

    /// <summary>
    /// Sets step states based on the current step configuration.
    /// </summary>
    private void UpdateStepStates() {
        var disabled = new List<int>();
        var errors = new List<int>();
        var warnings = new List<int>();
        var hidden = new List<int>();

        for (int i = 0; i < Steps.Count; i++) {
            var step = Steps[i];
            switch (step.State) {
                case SmartWizardStepState.Disabled:
                    disabled.Add(i);
                    break;
                case SmartWizardStepState.Error:
                    errors.Add(i);
                    break;
                case SmartWizardStepState.Warning:
                    warnings.Add(i);
                    break;
                case SmartWizardStepState.Hidden:
                    hidden.Add(i);
                    break;
            }
        }

        if (disabled.Any()) Options.DisabledSteps = disabled.ToArray();
        if (errors.Any()) Options.ErrorSteps = errors.ToArray();
        if (warnings.Any()) Options.WarningSteps = warnings.ToArray();
        if (hidden.Any()) Options.HiddenSteps = hidden.ToArray();
    }

    #endregion

    #region Styling

    /// <summary>
    /// Sets the theme for the SmartWizard.
    /// </summary>
    /// <param name="theme">The theme to apply.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard WithTheme(SmartWizardTheme theme) {
        Options.Theme = theme switch {
            SmartWizardTheme.Basic => "basic",
            SmartWizardTheme.Arrows => "arrows",
            SmartWizardTheme.Square => "square",
            SmartWizardTheme.Round => "round",
            SmartWizardTheme.Dots => "dots",
            SmartWizardTheme.Progress => "progress",
            SmartWizardTheme.Material => "material",
            SmartWizardTheme.Dark => "dark",
            _ => "basic"
        };
        return this;
    }

    /// <summary>
    /// Sets whether navigation menu should be justified.
    /// </summary>
    /// <param name="justified">Whether to justify navigation menu.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard Justified(bool justified = true) {
        Options.Justified = justified;
        return this;
    }

    /// <summary>
    /// Sets the wizard orientation to vertical.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard AsVertical() {
        IsVertical = true;
        return this;
    }

    /// <summary>
    /// Sets custom CSS classes for the container.
    /// </summary>
    /// <param name="cssClass">The CSS class names.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard WithContainerClass(string cssClass) {
        ContainerClass = cssClass;
        return this;
    }

    /// <summary>
    /// Sets custom CSS classes for the nav container.
    /// </summary>
    /// <param name="cssClass">The CSS class names.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard WithNavClass(string cssClass) {
        NavClass = cssClass;
        return this;
    }

    /// <summary>
    /// Sets custom CSS classes for the content container.
    /// </summary>
    /// <param name="cssClass">The CSS class names.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard WithContentClass(string cssClass) {
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
    public SmartWizard AutoAdjustHeight(bool enabled = true) {
        Options.AutoAdjustHeight = enabled;
        return this;
    }

    /// <summary>
    /// Enables or disables browser back button support.
    /// </summary>
    /// <param name="enabled">Whether to enable back button support.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard BackButtonSupport(bool enabled = true) {
        Options.BackButtonSupport = enabled;
        return this;
    }

    /// <summary>
    /// Enables or disables URL hash navigation.
    /// </summary>
    /// <param name="enabled">Whether to enable URL hash navigation.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard EnableUrlHash(bool enabled = true) {
        Options.EnableUrlHash = enabled;
        return this;
    }

    #endregion

    #region Toolbar

    /// <summary>
    /// Configures the toolbar position.
    /// </summary>
    /// <param name="position">The toolbar position.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard WithToolbar(SmartWizardToolbarPosition position) {
        Options.Toolbar ??= new SmartWizardToolbar();
        Options.Toolbar.Position = position switch {
            SmartWizardToolbarPosition.None => "none",
            SmartWizardToolbarPosition.Top => "top",
            SmartWizardToolbarPosition.Bottom => "bottom",
            SmartWizardToolbarPosition.Both => "both",
            _ => "bottom"
        };
        return this;
    }

    /// <summary>
    /// Configures toolbar buttons.
    /// </summary>
    /// <param name="showNext">Whether to show Next button.</param>
    /// <param name="showPrevious">Whether to show Previous button.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard WithToolbarButtons(bool showNext = true, bool showPrevious = true) {
        Options.Toolbar ??= new SmartWizardToolbar();
        Options.Toolbar.ShowNextButton = showNext;
        Options.Toolbar.ShowPreviousButton = showPrevious;
        return this;
    }

    /// <summary>
    /// Adds extra HTML content to the toolbar.
    /// </summary>
    /// <param name="html">The HTML content to add.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard WithToolbarContent(string html) {
        Options.Toolbar ??= new SmartWizardToolbar();
        Options.Toolbar.ExtraHtml = html;
        return this;
    }

    #endregion

    #region Navigation

    /// <summary>
    /// Configures anchor navigation behavior.
    /// </summary>
    /// <param name="configure">Configuration action for anchor settings.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard ConfigureNavigation(Action<SmartWizardAnchor> configure) {
        Options.Anchor ??= new SmartWizardAnchor();
        configure(Options.Anchor);
        return this;
    }

    /// <summary>
    /// Enables or disables step navigation.
    /// </summary>
    /// <param name="enabled">Whether to enable step navigation.</param>
    /// <param name="alwaysEnabled">Whether navigation is always enabled.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard EnableNavigation(bool enabled = true, bool alwaysEnabled = false) {
        Options.Anchor ??= new SmartWizardAnchor();
        Options.Anchor.EnableNavigation = enabled;
        Options.Anchor.EnableNavigationAlways = alwaysEnabled;
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
    public SmartWizard WithTransition(SmartTabAnimation animation, int speed = 400, string? easing = null) {
        Options.Transition ??= new SmartWizardTransition();
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

    #endregion

    #region Keyboard Navigation

    /// <summary>
    /// Configures keyboard navigation.
    /// </summary>
    /// <param name="enabled">Whether to enable keyboard navigation.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard WithKeyboardNavigation(bool enabled = true) {
        Options.Keyboard ??= new SmartWizardKeyboard();
        Options.Keyboard.KeyNavigation = enabled;
        return this;
    }

    /// <summary>
    /// Configures custom keyboard shortcuts.
    /// </summary>
    /// <param name="configure">Configuration action for keyboard settings.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard ConfigureKeyboard(Action<SmartWizardKeyboard> configure) {
        Options.Keyboard ??= new SmartWizardKeyboard();
        configure(Options.Keyboard);
        return this;
    }

    #endregion

    #region Language

    /// <summary>
    /// Sets the button text for the wizard.
    /// </summary>
    /// <param name="nextText">Text for the Next button.</param>
    /// <param name="previousText">Text for the Previous button.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard WithButtonText(string nextText = "Next", string previousText = "Previous") {
        Options.Language ??= new SmartWizardLanguage();
        Options.Language.Next = nextText;
        Options.Language.Previous = previousText;
        return this;
    }

    #endregion

    #region Validation

    /// <summary>
    /// Adds a validation function for a specific step.
    /// </summary>
    /// <param name="stepIndex">The step index.</param>
    /// <param name="validationFunction">The JavaScript validation function.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard AddStepValidation(int stepIndex, string validationFunction) {
        _validationFunctions[stepIndex] = validationFunction;
        return this;
    }

    #endregion

    #region Events

    /// <summary>
    /// Adds an event handler for the initialized event.
    /// </summary>
    /// <param name="handler">The JavaScript event handler code.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard OnInitialized(string handler) {
        _eventHandlers["initialized"] = handler;
        return this;
    }

    /// <summary>
    /// Adds an event handler for the loaded event.
    /// </summary>
    /// <param name="handler">The JavaScript event handler code.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard OnLoaded(string handler) {
        _eventHandlers["loaded"] = handler;
        return this;
    }

    /// <summary>
    /// Adds an event handler for the leaveStep event.
    /// </summary>
    /// <param name="handler">The JavaScript event handler code.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard OnLeaveStep(string handler) {
        _eventHandlers["leaveStep"] = handler;
        return this;
    }

    /// <summary>
    /// Adds an event handler for the showStep event.
    /// </summary>
    /// <param name="handler">The JavaScript event handler code.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizard OnShowStep(string handler) {
        _eventHandlers["showStep"] = handler;
        return this;
    }

    #endregion

    #region Methods

    /// <summary>
    /// Generates JavaScript code to navigate to the next step.
    /// </summary>
    /// <returns>JavaScript method call string.</returns>
    public string GoToNext() => $"$('#{Id}').smartWizard('next')";

    /// <summary>
    /// Generates JavaScript code to navigate to the previous step.
    /// </summary>
    /// <returns>JavaScript method call string.</returns>
    public string GoToPrevious() => $"$('#{Id}').smartWizard('prev')";

    /// <summary>
    /// Generates JavaScript code to navigate to a specific step.
    /// </summary>
    /// <param name="index">The step index.</param>
    /// <param name="force">Whether to force navigation.</param>
    /// <returns>JavaScript method call string.</returns>
    public string GoToStep(int index, bool force = false) => 
        $"$('#{Id}').smartWizard('goToStep', {index}, {force.ToString().ToLower()})";

    /// <summary>
    /// Generates JavaScript code to reset the wizard.
    /// </summary>
    /// <returns>JavaScript method call string.</returns>
    public string Reset() => $"$('#{Id}').smartWizard('reset')";

    /// <summary>
    /// Generates JavaScript code to set step state.
    /// </summary>
    /// <param name="stepIndexes">The step indexes.</param>
    /// <param name="state">The state to set.</param>
    /// <returns>JavaScript method call string.</returns>
    public string SetState(int[] stepIndexes, SmartWizardStepState state) {
        var stateStr = state switch {
            SmartWizardStepState.Default => "default",
            SmartWizardStepState.Active => "active",
            SmartWizardStepState.Done => "done",
            SmartWizardStepState.Disabled => "disable",
            SmartWizardStepState.Hidden => "hidden",
            SmartWizardStepState.Error => "error",
            SmartWizardStepState.Warning => "warning",
            _ => "default"
        };
        return $"$('#{Id}').smartWizard('setState', {JsonSerializer.Serialize(stepIndexes)}, '{stateStr}')";
    }

    #endregion

    #region Rendering

    /// <summary>
    /// Registers the required libraries for SmartWizard.
    /// </summary>
    protected internal override void RegisterLibraries() {
        base.RegisterLibraries();
        Document?.AddLibrary(Libraries.JQuery);
        Document?.AddLibrary(Libraries.SmartWizard, 10);
    }

    /// <summary>
    /// Builds the SmartWizard HTML markup.
    /// </summary>
    public override string ToString() {
        if (!Steps.Any()) {
            return "<!-- SmartWizard: No steps defined -->";
        }

        RegisterLibraries();
        UpdateStepStates();

        var containerClasses = new List<string> { "sw-main" };
        if (IsVertical) containerClasses.Add("sw-vertical");
        if (!string.IsNullOrEmpty(ContainerClass)) containerClasses.Add(ContainerClass);

        var navClasses = new List<string> { "nav", "sw-nav" };
        if (IsVertical) navClasses.Add("flex-column");
        if (!string.IsNullOrEmpty(NavClass)) navClasses.Add(NavClass);

        var contentClasses = new List<string> { "tab-content", "sw-content" };
        if (!string.IsNullOrEmpty(ContentClass)) contentClasses.Add(ContentClass);

        // Build steps navigation
        var stepsHtml = new List<string>();
        for (int i = 0; i < Steps.Count; i++) {
            var isActive = i == (Options.Selected ?? 0);
            stepsHtml.Add($"<li class=\"nav-item sw-step-item\" role=\"presentation\">{Steps[i].BuildStepAnchor(i, isActive)}</li>");
        }

        // Build step content
        var contentHtml = new List<string>();
        for (int i = 0; i < Steps.Count; i++) {
            var isActive = i == (Options.Selected ?? 0);
            contentHtml.Add(Steps[i].BuildStepContent(i, isActive));
        }

        // Build the complete structure
        var html = new List<string> {
            $"<div id=\"{Id}\" class=\"{string.Join(" ", containerClasses)}\">",
            $"  <ul class=\"{string.Join(" ", navClasses)}\" role=\"tablist\">",
            string.Join("\n    ", stepsHtml),
            "  </ul>",
            $"  <div class=\"{string.Join(" ", contentClasses)}\">",
            string.Join("\n    ", contentHtml),
            "  </div>",
            "</div>"
        };

        // Build initialization script
        var script = BuildInitializationScript();
        html.Add(script);

        return string.Join("\n", html);
    }

    /// <summary>
    /// Builds the SmartWizard initialization script.
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

        // Build validation handlers
        var validationScript = new List<string>();
        if (_validationFunctions.Any()) {
            validationScript.Add($@"
$('#{Id}').on('leaveStep', function(e, anchorObject, currentStepIndex, nextStepIndex, stepDirection) {{
    // Custom validation logic
    if (stepDirection === 'forward') {{
        switch(currentStepIndex) {{
            {string.Join("\n            ", _validationFunctions.Select(kv => $"case {kv.Key}: return {kv.Value}(currentStepIndex, nextStepIndex);"))}
        }}
    }}
    return true;
}});");
        }

        // Handle Ajax content loading
        var ajaxScript = new List<string>();
        foreach (var step in Steps.Where(s => !string.IsNullOrEmpty(s.AjaxUrl))) {
            var stepIndex = Steps.IndexOf(step);
            var cacheAttr = step.CacheAjax ? "true" : "false";
            ajaxScript.Add($@"
$('#{Id}').on('showStep', function(e, anchorObject, stepIndex) {{
    if (stepIndex === {stepIndex} && !anchorObject.data('loaded')) {{
        var $step = $('#{step.Id}');
        $.ajax({{
            url: '{step.AjaxUrl}',
            cache: {cacheAttr},
            success: function(data) {{
                $step.html(data);
                anchorObject.data('loaded', true);
            }},
            error: function() {{
                $step.html('<div class=""alert alert-danger"">Failed to load step content</div>');
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
    $('#{Id}').smartWizard({configJson});
    {string.Join("\n    ", eventScript)}
    {string.Join("\n    ", validationScript)}
    {string.Join("\n    ", ajaxScript)}
}});
</script>";

        return script;
    }

    #endregion
}