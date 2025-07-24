namespace HtmlForgeX;

/// <summary>
/// Defines the available avatar sizes.
/// </summary>
public enum AvatarSize {
    /// <summary>Extra small avatar.</summary>
    XS,
    /// <summary>Small avatar.</summary>
    SM,
    /// <summary>Medium avatar.</summary>
    MD,
    /// <summary>Large avatar.</summary>
    LG,
    /// <summary>Extra large avatar.</summary>
    XL
}

/// <summary>
/// Extension helpers for <see cref="AvatarSize"/> values.
/// </summary>
public static class AvatarSizeExtensions {
    /// <summary>
    /// Converts the avatar size to the corresponding Tabler CSS class.
    /// </summary>
    /// <param name="size">Avatar size value.</param>
    /// <returns>CSS class string.</returns>
    public static string EnumToString(this AvatarSize size) {
        return "avatar-" + size.ToString().ToLower();
    }
}