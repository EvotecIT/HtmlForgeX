namespace HtmlForgeX;

/// <summary>
/// Text transformation options.
/// </summary>
public enum TextTransform {
    /// <summary>Uppercase all letters.</summary>
    Uppercase,

    /// <summary>Lowercase all letters.</summary>
    Lowercase,

    /// <summary>Capitalize each word.</summary>
    Capitalize,

    /// <summary>No transformation.</summary>
    None,

    /// <summary>Inherit from parent.</summary>
    Inherit,

    /// <summary>Use the CSS initial value.</summary>
    Initial
}