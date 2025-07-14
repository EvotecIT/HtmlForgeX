namespace HtmlForgeX;

/// <summary>
/// The mode of the tag for rendering
/// </summary>
public enum TagMode {
    /// <summary>
    /// Normal tag with opening and closing elements.
    /// </summary>
    Normal,
    /// <summary>
    /// Tag without a closing element, for example &lt;br&gt;.
    /// </summary>
    NoClosing,
    /// <summary>
    /// Self-closing tag, for example &lt;img /&gt;.
    /// </summary>
    SelfClosing
}
