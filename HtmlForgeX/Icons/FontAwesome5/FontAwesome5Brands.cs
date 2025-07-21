namespace HtmlForgeX;

/// <summary>
/// Font Awesome 5 Brand icons for use with VisNetwork and other components that require Font Awesome 5
/// </summary>
public enum FontAwesome5Brands {
    /// <summary>GitHub icon (fa-github)</summary>
    GitHub = 0xf09b,
    /// <summary>Twitter icon (fa-twitter)</summary>
    Twitter = 0xf099,
    /// <summary>Facebook icon (fa-facebook)</summary>
    Facebook = 0xf09a,
    /// <summary>LinkedIn icon (fa-linkedin)</summary>
    LinkedIn = 0xf0e1,
    /// <summary>YouTube icon (fa-youtube)</summary>
    YouTube = 0xf167,
    /// <summary>Instagram icon (fa-instagram)</summary>
    Instagram = 0xf16d,
    /// <summary>Microsoft icon (fa-microsoft)</summary>
    Microsoft = 0xf3ca,
    /// <summary>Apple icon (fa-apple)</summary>
    Apple = 0xf179,
    /// <summary>Google icon (fa-google)</summary>
    Google = 0xf1a0,
    /// <summary>Amazon icon (fa-amazon)</summary>
    Amazon = 0xf270
}

/// <summary>
/// Extension methods for FontAwesome5Brands icons
/// </summary>
public static class FontAwesome5BrandsExtensions {
    /// <summary>
    /// Gets the Unicode character code for the icon
    /// </summary>
    public static string GetCode(this FontAwesome5Brands icon) {
        return char.ConvertFromUtf32((int)icon);
    }
}