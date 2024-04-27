namespace HtmlForgeX.Tags;

public class Abbr(string value) : HtmlTag("abbr", value) {
    public Abbr Title(string title) {
        Attributes["title"] = title;
        return this;
    }
}

public class Address(string value) : HtmlTag("address", value);

public class Article(string value) : HtmlTag("article", value);

public class BR() : HtmlTag("br", TagMode.NoClosing);

public class LineBreak() : HtmlTag("br", TagMode.NoClosing);

public class HR() : HtmlTag("hr", TagMode.NoClosing);

public class HorizontalRule() : HtmlTag("hr", TagMode.NoClosing);

public class H1(string value) : HtmlTag("h1", value);

public class H2(string value) : HtmlTag("h2", value);

public class H3(string value) : HtmlTag("h3", value);

public class H4(string value) : HtmlTag("h4", value);

public class H5(string value) : HtmlTag("h5", value);

public class H6(string value) : HtmlTag("h6", value);

/// <summary>
/// The non-breaking space character entity. Provides a space that will not break into a new line.
/// Allows for the creation of a space character that will not break into a new line (usually 1 space wide).
/// </summary>
/// <seealso cref="HtmlForgeX.Element" />
public class NonBreakingSpace : Element {
    public override string ToString() {
        return "&nbsp;";
    }
}

/// <summary>
/// The en space character entity. Provides a space equal to the width of a capital N.
/// Allows for the creation of a space character that is wider than a standard space character (usually 2 spaces wide).
/// </summary>
/// <seealso cref="HtmlForgeX.Element" />
public class EnSpace : Element {
    public override string ToString() {
        return "&ensp;";
    }
}

/// <summary>
/// The em space character entity. Provides a space equal to the width of a capital M.
/// Allows for the creation of a space character that is wider than a standard space character (usually 4 spaces wide).
/// </summary>
/// <seealso cref="HtmlForgeX.Element" />
public class EmSpace : Element {
    public override string ToString() {
        return "&emsp;";
    }
}

public class Strong(string value) : HtmlTag("strong", value);