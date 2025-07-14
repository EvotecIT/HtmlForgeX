namespace HtmlForgeX.Tags;

/// <summary>
/// Represents an HTML <c>&lt;abbr&gt;</c> tag.
/// </summary>
/// <remarks>
/// The <c>&lt;abbr&gt;</c> tag is used to denote an abbreviation or acronym and can
/// include a tooltip with the expanded text via the <c>title</c> attribute.
/// </remarks>
public class Abbr(string value) : HtmlTag("abbr", value) {
    /// <summary>
    /// Sets the <c>title</c> attribute providing the expanded abbreviation text.
    /// </summary>
    /// <param name="title">Full text for the abbreviation.</param>
    /// <returns>The current <see cref="Abbr"/> instance.</returns>
    public Abbr Title(string title) {
        Attributes["title"] = title;
        return this;
    }
}

/// <summary>
/// Represents an HTML <c>&lt;address&gt;</c> tag.
/// </summary>
public class Address(string value) : HtmlTag("address", value);

/// <summary>
/// Represents an HTML <c>&lt;article&gt;</c> tag.
/// </summary>
public class Article(string value) : HtmlTag("article", value);

/// <summary>
/// Represents an HTML <c>&lt;br&gt;</c> tag.
/// </summary>
public class BR() : HtmlTag("br", TagMode.NoClosing);

/// <summary>
/// Alias for <see cref="BR"/>, provides a line break.
/// </summary>
public class LineBreak() : HtmlTag("br", TagMode.NoClosing);

/// <summary>
/// Represents an HTML <c>&lt;hr&gt;</c> tag.
/// </summary>
public class HR() : HtmlTag("hr", TagMode.NoClosing);

/// <summary>
/// Alias for <see cref="HR"/>, renders a horizontal rule.
/// </summary>
public class HorizontalRule() : HtmlTag("hr", TagMode.NoClosing);

/// <summary>
/// Represents an HTML <c>&lt;h1&gt;</c> tag.
/// </summary>
public class H1(string value) : HtmlTag("h1", value);

/// <summary>
/// Represents an HTML <c>&lt;h2&gt;</c> tag.
/// </summary>
public class H2(string value) : HtmlTag("h2", value);

/// <summary>
/// Represents an HTML <c>&lt;h3&gt;</c> tag.
/// </summary>
public class H3(string value) : HtmlTag("h3", value);

/// <summary>
/// Represents an HTML <c>&lt;h4&gt;</c> tag.
/// </summary>
public class H4(string value) : HtmlTag("h4", value);

/// <summary>
/// Represents an HTML <c>&lt;h5&gt;</c> tag.
/// </summary>
public class H5(string value) : HtmlTag("h5", value);

/// <summary>
/// Represents an HTML <c>&lt;h6&gt;</c> tag.
/// </summary>
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

/// <summary>
/// Represents an HTML <c>&lt;strong&gt;</c> tag used for emphasizing text.
/// </summary>
public class Strong(string value) : HtmlTag("strong", value);