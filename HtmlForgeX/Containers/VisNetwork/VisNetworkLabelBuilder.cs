using System.Net;
using System.Text;

namespace HtmlForgeX;

/// <summary>
/// Provides a fluent API for building HTML-formatted labels for VisNetwork nodes and edges.
/// 
/// IMPORTANT: VisJS has limited native HTML support. Only the following tags work natively:
/// - &lt;b&gt; for bold text
/// - &lt;i&gt; for italic text  
/// - &lt;code&gt; for monospace text
/// - \n for line breaks (recommended over &lt;br&gt;)
/// 
/// Other HTML tags like &lt;u&gt;, &lt;span&gt;, &lt;div&gt;, &lt;small&gt; etc. are NOT supported by VisJS.
/// They will be rendered as plain text. For full HTML support, consider using the 
/// visjs-html-nodes plugin (https://github.com/NickvanDyke/visjs-html-nodes).
/// </summary>
public class VisNetworkLabelBuilder {
    private readonly StringBuilder _html;

    /// <summary>
    /// Initializes a new instance of the VisNetworkLabelBuilder class.
    /// </summary>
    public VisNetworkLabelBuilder() {
        _html = new StringBuilder();
    }

    /// <summary>
    /// Adds bold text to the label.
    /// </summary>
    /// <param name="text">The text to make bold</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder Bold(string text) {
        _html.Append($"<b>{WebUtility.HtmlEncode(text)}</b>");
        return this;
    }

    /// <summary>
    /// Adds italic text to the label.
    /// </summary>
    /// <param name="text">The text to make italic</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder Italic(string text) {
        _html.Append($"<i>{WebUtility.HtmlEncode(text)}</i>");
        return this;
    }

    /// <summary>
    /// Adds plain text to the label.
    /// </summary>
    /// <param name="text">The text to add</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder Text(string text) {
        _html.Append(WebUtility.HtmlEncode(text));
        return this;
    }

    /// <summary>
    /// Adds a line break to the label.
    /// Uses \n for line breaks as recommended by VisJS documentation.
    /// </summary>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder LineBreak() {
        _html.Append("\n");
        return this;
    }


    /// <summary>
    /// Adds code/monospace text to the label.
    /// This is one of the few HTML tags natively supported by VisJS.
    /// </summary>
    /// <param name="text">The text to display in monospace font</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder Code(string text) {
        _html.Append($"<code>{WebUtility.HtmlEncode(text)}</code>");
        return this;
    }

    /// <summary>
    /// Creates a simple bulleted list item using supported HTML.
    /// Uses "• " prefix since &lt;ul&gt;/&lt;li&gt; are not supported.
    /// </summary>
    /// <param name="text">The list item text</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder BulletPoint(string text) {
        _html.Append("• ").Append(WebUtility.HtmlEncode(text)).Append("\n");
        return this;
    }

    /// <summary>
    /// Creates a multi-format line with bold label and regular value.
    /// Useful for key-value pairs like "Status: Active".
    /// </summary>
    /// <param name="label">The label text (will be bold)</param>
    /// <param name="value">The value text</param>
    /// <returns>The label builder for method chaining</returns>
    public VisNetworkLabelBuilder LabelValue(string label, string value) {
        _html.Append($"<b>{WebUtility.HtmlEncode(label)}:</b> {WebUtility.HtmlEncode(value)}");
        return this;
    }

    /// <summary>
    /// Builds the final HTML label string.
    /// </summary>
    /// <returns>The HTML-formatted label</returns>
    public string Build() {
        return _html.ToString();
    }

    /// <summary>
    /// Implicitly converts the builder to a string.
    /// </summary>
    /// <param name="builder">The label builder</param>
    public static implicit operator string(VisNetworkLabelBuilder builder) {
        return builder.Build();
    }
}