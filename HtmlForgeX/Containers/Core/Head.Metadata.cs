using System;
using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// Metadata related properties and helpers for <see cref="Head"/>.
/// </summary>
public partial class Head {
    /// <summary>Gets or sets the title of the HTML document.</summary>
    public string? Title { get; set; }

    /// <summary>Gets or sets the charset.</summary>
    public string? Charset { get; set; } = "utf-8";

    /// <summary>Gets or sets the HTTP equiv.</summary>
    public string? HttpEquiv { get; set; }

    /// <summary>Gets or sets the content.</summary>
    public string? Content { get; set; }

    /// <summary>Gets or sets the viewport.</summary>
    public string? Viewport { get; set; }

    /// <summary>Gets or sets the author.</summary>
    public string? Author { get; set; }

    /// <summary>Gets or sets the revised date.</summary>
    public DateTime? Revised { get; set; }

    /// <summary>Gets or sets the page description meta tag.</summary>
    public string? Description { get; set; }

    /// <summary>Gets or sets the keywords meta tag.</summary>
    public string? Keywords { get; set; }

    /// <summary>Collection of additional meta tags.</summary>
    public List<HtmlTag> MetaTags { get; } = new();

    /// <summary>Represents the auto refresh time in seconds.</summary>
    public int? AutoRefresh { get; set; }

    /// <summary>Adds a title to the document.</summary>
    public Head AddTitle(string title) {
        Title = Helpers.HtmlEncode(title);
        return this;
    }

    /// <summary>Adds a meta tag with automatic property mapping.</summary>
    public Head AddMeta(string name, string content) {
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
            case "description":
                Description = content;
                break;
            case "keywords":
                Keywords = content;
                break;
            default:
                MetaTags.Add(new HtmlTag("meta", "", attributes: new Dictionary<string, object> { { "name", name }, { "content", content } }, TagMode.SelfClosing));
                break;
        }
        return this;
    }

    /// <summary>Adds or replaces the charset meta tag.</summary>
    public Head AddCharsetMeta(string charset) {
        Charset = charset;
        return this;
    }

    /// <summary>Adds an HTTP-equiv meta tag.</summary>
    public Head AddHttpEquivMeta(string httpEquiv, string content) {
        HttpEquiv = httpEquiv;
        Content = content;
        return this;
    }

    /// <summary>Adds a viewport meta tag.</summary>
    public Head AddViewportMeta(string content) {
        Viewport = content;
        return this;
    }

    /// <summary>Adds an author meta tag.</summary>
    public Head AddAuthorMeta(string author) {
        Author = author;
        return this;
    }

    /// <summary>Adds a revised date meta tag.</summary>
    public Head AddRevisedMeta(DateTime date) {
        Revised = date;
        return this;
    }
}