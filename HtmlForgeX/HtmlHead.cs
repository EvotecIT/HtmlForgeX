using System.Text;

namespace HtmlForgeX;

/// <summary>
/// Represents the head section of an HTML document.
/// This class allows you to add and manage meta tags, the title, and other elements in the head section.
/// </summary>
public class HtmlHead {
    /// <summary>
    /// Gets or sets the title of the HTML document.
    /// This is displayed in the title bar of the web browser.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the charset.
    /// </summary>
    /// <value>
    /// The charset.
    /// </value>
    public string Charset { get; set; }

    /// <summary>
    /// Gets or sets the HTTP equiv.
    /// </summary>
    /// <value>
    /// The HTTP equiv.
    /// </value>
    public string HttpEquiv { get; set; }

    /// <summary>
    /// Gets or sets the content.
    /// </summary>
    /// <value>
    /// The content.
    /// </value>
    public string Content { get; set; }

    /// <summary>
    /// Gets or sets the viewport.
    /// </summary>
    /// <value>
    /// The viewport.
    /// </value>
    public string Viewport { get; set; }

    /// <summary>
    /// Gets or sets the author.
    /// </summary>
    /// <value>
    /// The author.
    /// </value>
    public string Author { get; set; }

    /// <summary>
    /// Gets or sets the revised.
    /// </summary>
    /// <value>
    /// The revised.
    /// </value>
    public DateTime? Revised { get; set; }

    /// <summary>
    /// Gets or sets the meta tags.
    /// </summary>
    /// <value>
    /// The meta tags.
    /// </value>
    public List<HtmlTag> MetaTags { get; set; } = new List<HtmlTag>();

    /// <summary>
    /// Adds a title to the HTML document.
    /// This will be displayed in the title bar of the web browser.
    /// </summary>
    /// <param name="title">The title to add.</param>
    /// <returns>The HtmlHead object, allowing for method chaining.</returns>
    public HtmlHead AddTitle(string title) {
        Title = title;
        return this;
    }

    /// <summary>
    /// Adds a meta tag to the HTML document.
    /// If the name matches a known meta tag (charset, http-equiv, content, viewport, author), the corresponding property is set.
    /// </summary>
    /// <param name="name">The name of the meta tag.</param>
    /// <param name="content">The content of the meta tag.</param>
    /// <returns>The HtmlHead object, allowing for method chaining.</returns>
    public HtmlHead AddMeta(string name, string content) {
        switch (name.ToLower()) {
            case "charset":
                Charset = content;
                break;
            case "http-equiv":
                HttpEquiv = content;
                break;
            case "content":
                Content = content;
                break;
            case "viewport":
                Viewport = content;
                break;
            case "author":
                Author = content;
                break;
            default:
                MetaTags.Add(new HtmlTag("meta", "", attributes: new Dictionary<string, object> { { "name", name }, { "content", content } }, selfClosing: true));
                break;
        }
        return this;
    }

    public HtmlHead AddCharsetMeta(string charset) {
        Charset = charset;
        return this;
    }

    public HtmlHead AddHttpEquivMeta(string httpEquiv, string content) {
        HttpEquiv = httpEquiv;
        Content = content;
        return this;
    }

    public HtmlHead AddViewportMeta(string content) {
        Viewport = content;
        return this;
    }

    public HtmlHead AddAuthorMeta(string author) {
        Author = author;
        return this;
    }

    public HtmlHead AddRevisedMeta(DateTime date) {
        Revised = date;
        return this;
    }

    /// <summary>
    /// Converts the HtmlHead object to a string that represents the head section of an HTML document.
    /// This includes the title, meta tags, and other elements in the head section.
    /// </summary>
    /// <returns>A string that represents the head section of an HTML document.</returns>
    public override string ToString() {
        StringBuilder head = new StringBuilder();
        head.AppendLine("<head>");

        if (!string.IsNullOrEmpty(Title)) {
            head.AppendLine($"\t<title>{Title}</title>");
        }

        if (!string.IsNullOrEmpty(Charset)) {
            head.AppendLine($"\t<meta http-equiv=\"Content-Type\" content=\"text/html; charset={Charset}\">");
        }

        if (!string.IsNullOrEmpty(HttpEquiv) && !string.IsNullOrEmpty(Content)) {
            head.AppendLine($"\t<meta http-equiv=\"{HttpEquiv}\" content=\"{Content}\">");
        }

        if (!string.IsNullOrEmpty(Viewport)) {
            head.AppendLine($"\t<meta name=\"viewport\" content=\"{Viewport}\">");
        }

        if (!string.IsNullOrEmpty(Author)) {
            head.AppendLine($"\t<meta name=\"author\" content=\"{Author}\">");
        }

        if (Revised != null) {
            head.AppendLine($"\t<meta name=\"revised\" content=\"{Revised}\">");
        }

        foreach (var metaTag in MetaTags) {
            head.AppendLine($"\t{metaTag}");
        }

        head.AppendLine("</head>");

        return head.ToString();
    }
}
