namespace HtmlForgeX;

/// <summary>
/// Represents a simple CSS style definition that can be attached to an element
/// or output as part of a &lt;style&gt; block when rendering a document.
/// </summary>
/// <remarks>
/// This type can be used to build inline style declarations or generate style
/// blocks for inclusion in a document.
/// </remarks>
public class Style {
    /// <summary>
    /// Gets or sets the CSS selector associated with the style.
    /// </summary>
    public string? Selector { get; set; }

    /// <summary>
    /// Gets the collection of CSS properties for this style.
    /// </summary>
    public Dictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();

    /// <summary>
    /// Initializes a new instance of the <see cref="Style"/> class using a selector.
    /// </summary>
    /// <param name="selector">CSS selector to apply.</param>
    public Style(string selector) {
        Selector = selector;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Style"/> class with a selector and properties.
    /// </summary>
    /// <param name="selector">CSS selector to apply.</param>
    /// <param name="properties">Dictionary of CSS properties.</param>
    public Style(string selector, Dictionary<string, string> properties) {
        Selector = selector;
        Properties = properties;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Style"/> class.
    /// </summary>
    public Style() {

    }

    /// <summary>
    /// Adds or updates a CSS property.
    /// </summary>
    /// <param name="property">Name of the CSS property.</param>
    /// <param name="value">Value to assign.</param>
    /// <returns>The current <see cref="Style"/> instance.</returns>
    public Style Add(string property, string value) {
        Properties[property] = value;
        return this;
    }

    /// <summary>
    /// Returns a formatted CSS representation of the style.
    /// </summary>
    /// <remarks>
    /// The output string can be used directly within a <c>&lt;style&gt;</c> block
    /// or attached as an inline style attribute.
    /// </remarks>
    public override string ToString() {
        var properties = string.Join("; ", Properties.Select(kvp => $"{kvp.Key}: {kvp.Value}"));
        return $"{Selector} {{ {properties} }}";
    }
}