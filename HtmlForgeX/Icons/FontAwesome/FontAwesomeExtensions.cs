using System.ComponentModel;
using System.Reflection;

namespace HtmlForgeX;

/// <summary>
/// Extension methods for FontAwesomeSolid icons
/// </summary>
public static class FontAwesomeSolidExtensions {
    /// <summary>
    /// Gets the Unicode character code for the icon
    /// </summary>
    public static string GetCode(this FontAwesomeSolid icon) {
        var field = typeof(FontAwesomeSolid).GetField(icon.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? string.Empty;
    }
    
    /// <summary>
    /// Gets the Font Awesome icon name for the icon
    /// </summary>
    public static string GetIconName(this FontAwesomeSolid icon) {
        var field = typeof(FontAwesomeSolid).GetField(icon.ToString());
        var attribute = field?.GetCustomAttribute<IconNameAttribute>();
        return attribute?.Name ?? string.Empty;
    }
}

/// <summary>
/// Extension methods for FontAwesomeRegular icons
/// </summary>
public static class FontAwesomeRegularExtensions {
    /// <summary>
    /// Gets the Unicode character code for the icon
    /// </summary>
    public static string GetCode(this FontAwesomeRegular icon) {
        var field = typeof(FontAwesomeRegular).GetField(icon.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? string.Empty;
    }
    
    /// <summary>
    /// Gets the Font Awesome icon name for the icon
    /// </summary>
    public static string GetIconName(this FontAwesomeRegular icon) {
        var field = typeof(FontAwesomeRegular).GetField(icon.ToString());
        var attribute = field?.GetCustomAttribute<IconNameAttribute>();
        return attribute?.Name ?? string.Empty;
    }
}

/// <summary>
/// Extension methods for FontAwesomeBrands icons
/// </summary>
public static class FontAwesomeBrandsExtensions {
    /// <summary>
    /// Gets the Unicode character code for the icon
    /// </summary>
    public static string GetCode(this FontAwesomeBrands icon) {
        var field = typeof(FontAwesomeBrands).GetField(icon.ToString());
        var attribute = field?.GetCustomAttribute<DescriptionAttribute>();
        return attribute?.Description ?? string.Empty;
    }
    
    /// <summary>
    /// Gets the Font Awesome icon name for the icon
    /// </summary>
    public static string GetIconName(this FontAwesomeBrands icon) {
        var field = typeof(FontAwesomeBrands).GetField(icon.ToString());
        var attribute = field?.GetCustomAttribute<IconNameAttribute>();
        return attribute?.Name ?? string.Empty;
    }
}