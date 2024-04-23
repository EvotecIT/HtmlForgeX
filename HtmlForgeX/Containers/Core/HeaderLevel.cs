namespace HtmlForgeX;

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
    /// <returns></returns>
    public HeaderLevel Class(string className) {
        PrivateClass += className;
        return this;
    }

    public override string ToString() {
        var tag = new HtmlTag(PrivateTag.ToString()).Value(PrivateText);
        if (!string.IsNullOrEmpty(PrivateClass)) {
            tag.Class(PrivateClass);
        }
        return tag.ToString();
    }
}