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
        var tag = new HtmlTag(PrivateTag.ToString()).SetValue(PrivateText);
        if (!string.IsNullOrEmpty(PrivateClass)) {
            tag.Class(PrivateClass);
        }
        return tag.ToString();
    }

    //public static HeaderLevel H1 => new HeaderLevel("h1");
    //public static HeaderLevel H2 => new HeaderLevel("h2");
    //public static HeaderLevel H3 => new HeaderLevel("h3");
    //public static HeaderLevel H4 => new HeaderLevel("h4");
    //public static HeaderLevel H5 => new HeaderLevel("h5");
    //public static HeaderLevel H6 => new HeaderLevel("h6");
}