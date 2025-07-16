namespace HtmlForgeX;

/// <summary>
/// Represents the possible states of a wizard step.
/// </summary>
public enum SmartWizardStepState {
    /// <summary>Default state - step is available but not active.</summary>
    Default,
    /// <summary>Active state - step is currently being viewed.</summary>
    Active,
    /// <summary>Done state - step has been completed.</summary>
    Done,
    /// <summary>Disabled state - step cannot be accessed.</summary>
    Disabled,
    /// <summary>Hidden state - step is not visible.</summary>
    Hidden,
    /// <summary>Error state - step has validation errors.</summary>
    Error,
    /// <summary>Warning state - step has warnings.</summary>
    Warning
}