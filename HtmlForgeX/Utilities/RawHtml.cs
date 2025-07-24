namespace HtmlForgeX;

/// <summary>
/// Wrapper for raw HTML content that should not be encoded
/// </summary>
internal class RawHtml {
    public string Content { get; }

    public RawHtml(string content, bool sanitize = false) {
        Content = sanitize ? HtmlSanitizer.Sanitize(content) : content;
    }

    public override string ToString() {
        return Content;
    }
}