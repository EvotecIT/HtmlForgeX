namespace HtmlForgeX;

/// <summary>
/// Defines available Tabler modal sizes.
/// </summary>
public enum TablerModalSize {
    /// <summary>Default size.</summary>
    Default,
    /// <summary>Small modal.</summary>
    Small,
    /// <summary>Large modal.</summary>
    Large,
    /// <summary>Full width modal.</summary>
    FullWidth
}

/// <summary>
/// Extension helpers for <see cref="TablerModalSize"/> values.
/// </summary>
public static class TablerModalSizeExtensions {
    /// <summary>
    /// Converts modal size to the corresponding CSS class.
    /// </summary>
    /// <param name="size">Modal size.</param>
    /// <returns>CSS class name or empty string.</returns>
    public static string EnumToString(this TablerModalSize size) {
        return size switch {
            TablerModalSize.Small => "modal-sm",
            TablerModalSize.Large => "modal-lg",
            TablerModalSize.FullWidth => "modal-full-width",
            _ => string.Empty
        };
    }
}
