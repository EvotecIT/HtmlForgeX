namespace HtmlForgeX;

/// <summary>
/// Defines how an HTML tag should be rendered.
/// </summary>
public enum TagMode {
    /// <summary>Tag with a separate opening and closing element, for example <c>&lt;div&gt;</c>.</summary>
    Normal,

    /// <summary>Tag that does not include a closing element, such as <c>&lt;br&gt;</c>.</summary>
    NoClosing,

    /// <summary>Tag that self-closes within a single element, for example <c>&lt;img /&gt;</c>.</summary>
    SelfClosing
}
