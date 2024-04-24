namespace HtmlForgeX;

/// <summary>
/// The mode of the tag for rendering
/// </summary>
public enum TagMode {
    // Normal tag with opening and closing tags
    Normal,
    // Tag with no closing tag (e.g. <br>)
    NoClosing,
    // Self-closing tag (e.g. <img />)
    SelfClosing
}
