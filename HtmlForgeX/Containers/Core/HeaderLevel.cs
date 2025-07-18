namespace HtmlForgeX;

/// <summary>
/// Represents an HTML header element (<c>h1</c> through <c>h6</c>) with helper
/// methods for setting common header attributes.
/// </summary>
public class HeaderLevel : Element {
    private HeaderLevelTag PrivateTag { get; }

    private string? PrivateText { get; }

    private string? PrivateClass { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="HeaderLevel"/> class.
    /// </summary>
    /// <param name="level">The level.</param>
    /// <param name="text">The text.</param>
    public HeaderLevel(HeaderLevelTag level, string text) {
        PrivateTag = level;
        PrivateText = text;
    }

    /// <summary>
    /// Add one or more classes to the HeaderLevel.
    /// For example: <h1 class="card-title"></h1>
    /// </summary>
    /// <param name="className">Name of the class.</param>
    /// <returns>The current <see cref="HeaderLevel"/> instance.</returns>
    public HeaderLevel Class(string className) {
        PrivateClass += className;
        return this;
    }

    /// <summary>
    /// Converts the header element to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the header.</returns>
    public override string ToString() {
        var tag = new HtmlTag(PrivateTag.ToString()).Value(PrivateText);
        if (!string.IsNullOrEmpty(PrivateClass)) {
            tag.Class(PrivateClass);
        }
        return tag.ToString();
    }
}