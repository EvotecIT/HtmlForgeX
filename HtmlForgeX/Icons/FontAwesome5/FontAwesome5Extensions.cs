using System.ComponentModel;
using System.Reflection;

namespace HtmlForgeX;

/// <summary>
/// Extension methods for FontAwesome5Solid icons
/// </summary>
public static class FontAwesome5SolidExtensions {
    /// <summary>
    /// Gets the Unicode character code for the icon
    /// </summary>
    public static string GetCode(this FontAwesome5Solid icon) {
        var field = typeof(FontAwesome5Solid).GetField(icon.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? string.Empty;
    }
    
    /// <summary>
    /// Gets the Font Awesome icon name for the icon
    /// </summary>
    public static string GetIconName(this FontAwesome5Solid icon) {
        var field = typeof(FontAwesome5Solid).GetField(icon.ToString());
        var attribute = field?.GetCustomAttribute<IconNameAttribute>();
        return attribute?.Name ?? string.Empty;
    }
}

/// <summary>
/// Extension methods for FontAwesome5Regular icons
/// </summary>
public static class FontAwesome5RegularExtensions {
    /// <summary>
    /// Gets the Unicode character code for the icon
    /// </summary>
    public static string GetCode(this FontAwesome5Regular icon) {
        var field = typeof(FontAwesome5Regular).GetField(icon.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? string.Empty;
    }
    
    /// <summary>
    /// Gets the Font Awesome icon name for the icon
    /// </summary>
    public static string GetIconName(this FontAwesome5Regular icon) {
        var field = typeof(FontAwesome5Regular).GetField(icon.ToString());
        var attribute = field?.GetCustomAttribute<IconNameAttribute>();
        return attribute?.Name ?? string.Empty;
    }
}

/// <summary>
/// Extension methods for FontAwesome5Brands icons
/// </summary>
public static class FontAwesome5BrandsExtensions {
    /// <summary>
    /// Gets the Unicode character code for the icon
    /// </summary>
    public static string GetCode(this FontAwesome5Brands icon) {
        var field = typeof(FontAwesome5Brands).GetField(icon.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? string.Empty;
    }
    
    /// <summary>
    /// Gets the Font Awesome icon name for the icon
    /// </summary>
    public static string GetIconName(this FontAwesome5Brands icon) {
        var field = typeof(FontAwesome5Brands).GetField(icon.ToString());
        var attribute = field?.GetCustomAttribute<IconNameAttribute>();
        return attribute?.Name ?? string.Empty;
    }
}