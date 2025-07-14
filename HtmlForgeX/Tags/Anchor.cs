namespace HtmlForgeX.Tags;

/// <summary>
/// Represents an HTML <c>&lt;a&gt;</c> tag. Use this class to create hyperlinks
/// with optional target, relationship, and styling attributes.
/// </summary>
public class Anchor : HtmlTag {
    /// <summary>
    /// Initializes a new instance of the <see cref="Anchor"/> class.
    /// </summary>
    public Anchor() : base("a") { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Anchor"/> class with a <c>href</c> value.
    /// </summary>
    /// <param name="hrefLink">URL for the <c>href</c> attribute.</param>
    /// <param name="text">Optional inner text.</param>
    public Anchor(string hrefLink, string text = "") : base("a") {
        if (string.IsNullOrWhiteSpace(hrefLink)) {
            throw new ArgumentException("hrefLink cannot be null or empty");
        }
        if (!Uri.IsWellFormedUriString(hrefLink, UriKind.RelativeOrAbsolute)) {
            throw new ArgumentException($"Invalid href value: {hrefLink}");
        }

        Attributes["href"] = hrefLink;
        Value(text);
    }

    /// <summary>
    /// Sets the <c>target</c> attribute.
    /// </summary>
    /// <param name="target">Target value.</param>
    /// <returns>The current <see cref="Anchor"/> instance.</returns>
    public Anchor Target(string target) {
        if (string.IsNullOrWhiteSpace(target)) {
            throw new ArgumentException("target cannot be null or empty");
        }
        Attributes["target"] = target;
        return this;
    }

    /// <summary>
    /// Sets the <c>name</c> attribute.
    /// </summary>
    /// <param name="name">Name value.</param>
    /// <returns>The current <see cref="Anchor"/> instance.</returns>
    public Anchor Name(string name) {
        if (string.IsNullOrWhiteSpace(name)) {
            throw new ArgumentException("name cannot be null or empty");
        }
        Attributes["name"] = name;
        return this;
    }

    /// <summary>
    /// Sets the <c>rel</c> attribute.
    /// </summary>
    /// <param name="rel">Relationship value.</param>
    /// <returns>The current <see cref="Anchor"/> instance.</returns>
    public Anchor Rel(string rel) {
        if (string.IsNullOrWhiteSpace(rel)) {
            throw new ArgumentException("rel cannot be null or empty");
        }
        Attributes["rel"] = rel;
        return this;
    }

    /// <summary>
    /// Sets the <c>download</c> attribute.
    /// </summary>
    /// <param name="download">Download value.</param>
    /// <returns>The current <see cref="Anchor"/> instance.</returns>
    public Anchor Download(string download) {
        if (string.IsNullOrWhiteSpace(download)) {
            throw new ArgumentException("download cannot be null or empty");
        }
        Attributes["download"] = download;
        return this;
    }

    /// <summary>
    /// Sets the <c>href</c> attribute.
    /// </summary>
    /// <param name="hrefLink">URL for the <c>href</c> attribute.</param>
    /// <returns>The current <see cref="Anchor"/> instance.</returns>
    public Anchor HrefLink(string hrefLink) {
        if (string.IsNullOrWhiteSpace(hrefLink)) {
            throw new ArgumentException("hrefLink cannot be null or empty");
        }
        if (!Uri.IsWellFormedUriString(hrefLink, UriKind.RelativeOrAbsolute)) {
            throw new ArgumentException($"Invalid href value: {hrefLink}");
        }
        Attributes["href"] = hrefLink;
        return this;
    }

    /// <summary>
    /// Sets the <c>hreflang</c> attribute.
    /// </summary>
    /// <param name="hreflang">Language code.</param>
    /// <returns>The current <see cref="Anchor"/> instance.</returns>
    public Anchor HrefLang(string hreflang) {
        if (string.IsNullOrWhiteSpace(hreflang)) {
            throw new ArgumentException("hreflang cannot be null or empty");
        }
        Attributes["hreflang"] = hreflang;
        return this;
    }

    /// <summary>
    /// Sets the <c>onclick</c> attribute.
    /// </summary>
    /// <param name="onClick">JavaScript code to execute.</param>
    /// <returns>The current <see cref="Anchor"/> instance.</returns>
    public Anchor OnClick(string onClick) {
        if (string.IsNullOrWhiteSpace(onClick)) {
            throw new ArgumentException("onClick cannot be null or empty");
        }
        Attributes["onclick"] = onClick;
        return this;
    }

    /// <summary>
    /// Sets the <c>media</c> attribute.
    /// </summary>
    /// <param name="media">Media attribute value.</param>
    /// <returns>The current <see cref="Anchor"/> instance.</returns>
    public Anchor Media(string media) {
        if (string.IsNullOrWhiteSpace(media)) {
            throw new ArgumentException("media cannot be null or empty");
        }
        Attributes["media"] = media;
        return this;
    }

    /// <summary>
    /// Sets the <c>ping</c> attribute.
    /// </summary>
    /// <param name="ping">Ping URL.</param>
    /// <returns>The current <see cref="Anchor"/> instance.</returns>
    public Anchor Ping(string ping) {
        if (string.IsNullOrWhiteSpace(ping)) {
            throw new ArgumentException("ping cannot be null or empty");
        }
        if (!Uri.IsWellFormedUriString(ping, UriKind.RelativeOrAbsolute)) {
            throw new ArgumentException($"Invalid ping value: {ping}");
        }
        Attributes["ping"] = ping;
        return this;
    }

    /// <summary>
    /// Sets the <c>referrerpolicy</c> attribute.
    /// </summary>
    /// <param name="referrerPolicy">Referrer policy value.</param>
    /// <returns>The current <see cref="Anchor"/> instance.</returns>
    public Anchor ReferrerPolicy(string referrerPolicy) {
        if (string.IsNullOrWhiteSpace(referrerPolicy)) {
            throw new ArgumentException("referrerPolicy cannot be null or empty");
        }
        Attributes["referrerpolicy"] = referrerPolicy;
        return this;
    }
}
