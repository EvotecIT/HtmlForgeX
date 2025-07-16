using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Represents a step in the SmartWizard component.
/// </summary>
public class SmartWizardStep : ElementContainer {
    /// <summary>Gets or sets the step identifier.</summary>
    public string Id { get; set; }

    /// <summary>Gets or sets the step title.</summary>
    public string Title { get; set; }

    /// <summary>Gets or sets the step subtitle or description.</summary>
    public string? Subtitle { get; set; }

    /// <summary>Gets or sets the step icon.</summary>
    public TablerIconType? Icon { get; set; }

    /// <summary>Gets or sets the step state.</summary>
    public SmartWizardStepState State { get; set; } = SmartWizardStepState.Default;

    /// <summary>Gets or sets whether this step is disabled.</summary>
    public bool Disabled { get; set; }

    /// <summary>Gets or sets whether this step is hidden.</summary>
    public bool Hidden { get; set; }

    /// <summary>Gets or sets a custom CSS class for the step anchor.</summary>
    public string? AnchorClass { get; set; }

    /// <summary>Gets or sets a custom CSS class for the step content.</summary>
    public string? ContentClass { get; set; }

    /// <summary>Gets or sets the URL for ajax content loading.</summary>
    public string? AjaxUrl { get; set; }

    /// <summary>Gets or sets whether to cache ajax content.</summary>
    public bool CacheAjax { get; set; } = true;

    /// <summary>Gets or sets custom validation function name.</summary>
    public string? ValidationFunction { get; set; }

    /// <summary>Gets or sets whether this step is optional.</summary>
    public bool Optional { get; set; }

    /// <summary>Gets or sets the step progress percentage (0-100).</summary>
    public int? Progress { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SmartWizardStep"/> class.
    /// </summary>
    /// <param name="title">The step title.</param>
    public SmartWizardStep(string title) {
        Title = title;
        Id = GlobalStorage.GenerateRandomId("step");
    }

    /// <summary>
    /// Sets the step subtitle or description.
    /// </summary>
    /// <param name="subtitle">The subtitle text.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizardStep WithSubtitle(string subtitle) {
        Subtitle = subtitle;
        return this;
    }

    /// <summary>
    /// Sets the step icon.
    /// </summary>
    /// <param name="icon">The icon type.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizardStep WithIcon(TablerIconType icon) {
        Icon = icon;
        return this;
    }

    /// <summary>
    /// Sets the step state.
    /// </summary>
    /// <param name="state">The step state.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizardStep WithState(SmartWizardStepState state) {
        State = state;
        return this;
    }

    /// <summary>
    /// Marks the step as disabled.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizardStep AsDisabled() {
        Disabled = true;
        State = SmartWizardStepState.Disabled;
        return this;
    }

    /// <summary>
    /// Marks the step as hidden.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizardStep AsHidden() {
        Hidden = true;
        State = SmartWizardStepState.Hidden;
        return this;
    }

    /// <summary>
    /// Marks the step as optional.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizardStep AsOptional() {
        Optional = true;
        return this;
    }

    /// <summary>
    /// Marks the step as having an error.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizardStep WithError() {
        State = SmartWizardStepState.Error;
        return this;
    }

    /// <summary>
    /// Marks the step as having a warning.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizardStep WithWarning() {
        State = SmartWizardStepState.Warning;
        return this;
    }

    /// <summary>
    /// Marks the step as done/completed.
    /// </summary>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizardStep AsDone() {
        State = SmartWizardStepState.Done;
        return this;
    }

    /// <summary>
    /// Sets the step progress percentage.
    /// </summary>
    /// <param name="progress">The progress percentage (0-100).</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizardStep WithProgress(int progress) {
        Progress = Math.Max(0, Math.Min(100, progress));
        return this;
    }

    /// <summary>
    /// Sets a custom CSS class for the step anchor.
    /// </summary>
    /// <param name="cssClass">The CSS class name.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizardStep WithAnchorClass(string cssClass) {
        AnchorClass = cssClass;
        return this;
    }

    /// <summary>
    /// Sets a custom CSS class for the step content.
    /// </summary>
    /// <param name="cssClass">The CSS class name.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizardStep WithContentClass(string cssClass) {
        ContentClass = cssClass;
        return this;
    }

    /// <summary>
    /// Configures ajax content loading for this step.
    /// </summary>
    /// <param name="url">The URL to load content from.</param>
    /// <param name="cache">Whether to cache the loaded content.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizardStep WithAjaxContent(string url, bool cache = true) {
        AjaxUrl = url;
        CacheAjax = cache;
        return this;
    }

    /// <summary>
    /// Sets a custom validation function for this step.
    /// </summary>
    /// <param name="functionName">The JavaScript function name for validation.</param>
    /// <returns>The current instance for method chaining.</returns>
    public SmartWizardStep WithValidation(string functionName) {
        ValidationFunction = functionName;
        return this;
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
    /// Builds the step anchor markup.
    /// </summary>
    internal string BuildStepAnchor(int stepIndex, bool isActive = false) {
        var classes = new List<string> { "nav-link" };
        
        // Add state-based classes
        switch (State) {
            case SmartWizardStepState.Active:
                classes.Add("active");
                break;
            case SmartWizardStepState.Done:
                classes.Add("done");
                break;
            case SmartWizardStepState.Disabled:
                classes.Add("disabled");
                break;
            case SmartWizardStepState.Error:
                classes.Add("danger");
                break;
            case SmartWizardStepState.Warning:
                classes.Add("warning");
                break;
        }

        if (isActive) classes.Add("active");
        if (Disabled) classes.Add("disabled");
        if (Optional) classes.Add("optional");
        if (!string.IsNullOrEmpty(AnchorClass)) classes.Add(AnchorClass);

        var attributes = new List<string> {
            $"href=\"#{Id}\"",
            $"data-bs-toggle=\"tab\"",
            $"data-step-index=\"{stepIndex}\""
        };

        if (Disabled) attributes.Add("tabindex=\"-1\"");
        if (Hidden) attributes.Add("style=\"display: none;\"");

        // Build content
        var content = new List<string>();
        
        // Add step number or icon
        if (Icon.HasValue) {
            var iconClass = GetIconClass(Icon.Value);
            content.Add($"<i class=\"{iconClass} me-2\"></i>");
        } else {
            content.Add($"<span class=\"sw-step-number\">{stepIndex + 1}</span>");
        }

        // Add title and subtitle
        content.Add($"<span class=\"sw-step-title\">{Title}</span>");
        if (!string.IsNullOrEmpty(Subtitle)) {
            content.Add($"<small class=\"sw-step-subtitle d-block text-muted\">{Subtitle}</small>");
        }

        // Add progress indicator if set
        if (Progress.HasValue) {
            content.Add($"<div class=\"sw-step-progress\" style=\"width: {Progress}%\"></div>");
        }

        return $"<a class=\"{string.Join(" ", classes)}\" {string.Join(" ", attributes)}>{string.Join("", content)}</a>";
    }

    /// <summary>
    /// Builds the step content markup.
    /// </summary>
    internal string BuildStepContent(int stepIndex, bool isActive = false) {
        var classes = new List<string> { "tab-pane", "step-content" };
        if (isActive) classes.Add("active");
        if (!string.IsNullOrEmpty(ContentClass)) classes.Add(ContentClass);

        var attributes = new List<string> {
            $"id=\"{Id}\"",
            $"role=\"tabpanel\"",
            $"data-step-index=\"{stepIndex}\""
        };

        if (Hidden) attributes.Add("style=\"display: none;\"");

        // Build content
        string content;
        if (!string.IsNullOrEmpty(AjaxUrl)) {
            content = $"<div class=\"text-center p-4\"><div class=\"spinner-border\" role=\"status\"><span class=\"visually-hidden\">Loading...</span></div></div>";
        } else {
            content = string.Join("", Children.WhereNotNull().Select(child => child.ToString()));
        }

        return $"<div class=\"{string.Join(" ", classes)}\" {string.Join(" ", attributes)}>{content}</div>";
    }

    /// <summary>
    /// Gets the step index for state arrays.
    /// </summary>
    internal int GetStepIndex(List<SmartWizardStep> allSteps) {
        return allSteps.IndexOf(this);
    }
}