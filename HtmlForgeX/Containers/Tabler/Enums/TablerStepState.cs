namespace HtmlForgeX;

/// <summary>
/// Represents the different states a step can have
/// </summary>
public enum TablerStepState {
    /// <summary>
    /// Step is pending/future - not yet reached
    /// </summary>
    Pending,

    /// <summary>
    /// Step is currently active
    /// </summary>
    Active,

    /// <summary>
    /// Step has been completed
    /// </summary>
    Completed
}
