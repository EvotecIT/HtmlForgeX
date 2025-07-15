using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;
/// <summary>
/// Represents a generic HTML tag that can contain attributes and child elements.
/// This is the fundamental building block used when manually composing DOM
/// structures with HtmlForgeX.
/// </summary>
public class HtmlTag : Element {
    private string PrivateTag { get; set; }
    private TagMode PrivateTagMode { get; set; } = TagMode.Normal;
    private new List<object> Children { get; set; } = new List<object>();

    /// <summary>
    /// Gets the collection of attributes applied to this tag.
    /// </summary>
    public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

    /// <summary>
    /// Initializes a new instance of the <see cref="HtmlTag"/> class with the specified tag name.
    /// </summary>
    /// <param name="tag">The name of the tag.</param>
    public HtmlTag(string tag) {
        PrivateTag = tag;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HtmlTag"/> class with a value contained within the tag.
    /// </summary>
    /// <param name="tag">The name of the tag.</param>
    /// <param name="value">The inner value for the tag.</param>
    public HtmlTag(string tag, string? value) {
        PrivateTag = tag;
        if (value is not null) {
            Children.Add(value);
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HtmlTag"/> class with the specified tag mode.
    /// </summary>
    /// <param name="tag">The name of the tag.</param>
    /// <param name="tagMode">The <see cref="TagMode"/> indicating how the tag should be rendered.</param>
    public HtmlTag(string tag, TagMode tagMode) {
        PrivateTag = tag;
        PrivateTagMode = tagMode;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HtmlTag"/> class with a value and specific tag mode.
    /// </summary>
    /// <param name="tag">The name of the tag.</param>
    /// <param name="value">The inner value for the tag.</param>
    /// <param name="tagMode">The <see cref="TagMode"/> indicating how the tag should be rendered.</param>
    public HtmlTag(string tag, string? value, TagMode tagMode) {
        PrivateTag = tag;
        PrivateTagMode = tagMode;
        if (value is not null) {
            Children.Add(value);
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="HtmlTag"/> class with a value, attributes and tag mode.
    /// </summary>
    /// <param name="tag">The name of the tag.</param>
    /// <param name="value">The inner value for the tag.</param>
    /// <param name="attributes">Optional attributes to apply.</param>
    /// <param name="tagMode">The <see cref="TagMode"/> indicating how the tag should be rendered.</param>
    public HtmlTag(string tag, string? value, Dictionary<string, object>? attributes = null, TagMode tagMode = TagMode.Normal) {
        PrivateTag = tag;
        if (value is not null) {
            Children.Add(value);
        }
        PrivateTagMode = tagMode;

        if (attributes != null) {
            foreach (var attribute in attributes) {
                if (attribute.Value is Dictionary<string, string> nestedAttributes) {
                    StringBuilder nestedValue = new StringBuilder();
                    foreach (var nestedAttribute in nestedAttributes) {
                        nestedValue.Append($"{nestedAttribute.Key}: {nestedAttribute.Value}; ");
                    }
                    Attributes[attribute.Key] = nestedValue.ToString().TrimEnd(' ', ';');
                } else if (attribute.Value is Dictionary<string, object> nestedAttributes1) {
                    StringBuilder nestedValue = new StringBuilder();
                    foreach (var nestedAttribute in nestedAttributes1) {
                        nestedValue.Append($"{nestedAttribute.Key}: {nestedAttribute.Value}; ");
                    }
                    Attributes[attribute.Key] = nestedValue.ToString().TrimEnd(' ', ';');

                } else {
                    Attributes[attribute.Key] = attribute.Value.ToString();
                }
            }
        }
    }

    /// <summary>
    /// Sets the id attribute for the tag.
    /// </summary>
    /// <param name="id">The id value.</param>
    /// <returns>The current <see cref="HtmlTag"/> instance.</returns>
    public HtmlTag Id(string id) {
        Attributes["id"] = id;
        return this;
    }

    /// <summary>
    /// Adds a style declaration to the tag.
    /// </summary>
    /// <param name="name">The CSS property name.</param>
    /// <param name="value">The CSS property value.</param>
    /// <returns>The current <see cref="HtmlTag"/> instance.</returns>
    public HtmlTag Style(string name, string value) {
        if (!Attributes.ContainsKey("style") || Attributes["style"] is null) {
            Attributes["style"] = string.Empty;
        }

        var current = Attributes["style"]?.ToString() ?? string.Empty;
        current = current.Trim().TrimEnd(';');

        if (string.IsNullOrEmpty(current)) {
            current = $"{name}: {value}";
        } else {
            current = $"{current}; {name}: {value}";
        }

        Attributes["style"] = current.Trim().TrimEnd(';');
        return this;
    }

    /// <summary>
    /// Adds a CSS class to the tag.
    /// </summary>
    /// <param name="className">The class name to add.</param>
    /// <returns>The current <see cref="HtmlTag"/> instance.</returns>
    public HtmlTag Class(string? className) {
        // user used Class null so we don't do anything
        if (string.IsNullOrEmpty(className)) {
            return this;
        }
        // class doesn't exist so we create it
        if (!Attributes.ContainsKey("class")) {
            Attributes["class"] = string.Empty;
        } else if (!string.IsNullOrEmpty(Attributes["class"].ToString())) {
            // class exists and has a value so we add a space before adding the new class
            Attributes["class"] += " ";
        }
        Attributes["class"] += className;
        return this;
    }

    /// <summary>
    /// Sets the type attribute for the tag.
    /// </summary>
    /// <param name="type">The type value.</param>
    /// <returns>The current <see cref="HtmlTag"/> instance.</returns>
    public HtmlTag Type(string type) {
        Attributes["type"] = type;
        return this;
    }

    /// <summary>
    /// Returns the HTML representation of the tag.
    /// </summary>
    /// <returns>A string containing the rendered HTML.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();
        html.Append($"<{PrivateTag}");

        foreach (var attribute in Attributes) {
            if (attribute.Value != null && !string.IsNullOrEmpty(attribute.Value.ToString())) {
                if (attribute.Key == "style" && attribute.Value is Dictionary<string, object> styleDict) {
                    StringBuilder styleValue = new StringBuilder();
                    foreach (var style in styleDict) {
                        styleValue.Append($"{style.Key}: {style.Value}; ");
                    }
                    var styleString = styleValue.ToString().TrimEnd(' ', ';');
                    html.Append($" style=\"{Helpers.HtmlEncode(styleString)}\"");
                } else {
                    // Use invariant culture for numeric types to ensure consistent formatting
                    string valueString;
                    if (attribute.Value is IFormattable formattable) {
                        valueString = formattable.ToString(null, CultureInfo.InvariantCulture);
                    } else {
                        valueString = attribute.Value.ToString();
                    }
                    var value = Helpers.HtmlEncode(valueString?.Trim() ?? string.Empty);
                    html.Append($" {attribute.Key}=\"{value}\"");
                }
            }
        }

        if (PrivateTagMode == TagMode.SelfClosing) {
            // if the tag is self-closing we don't need to add the children
            html.Append("/>");
        } else if (PrivateTagMode == TagMode.NoClosing) {
            // if the tag is not-closing we don't need to add the children
            html.Append(">");
        } else {
            // if the tag is normal we add the children
            html.Append(">");
            foreach (var child in Children.WhereNotNull()) {
                if (child is string str) {
                    //html.Append(Helpers.HtmlEncode(str));
                    html.Append(str);
                } else if (child is RawHtml rawHtml) {
                    html.Append(rawHtml.Content);
                } else {
                    html.Append(child.ToString());
                }
            }
            html.Append($"</{PrivateTag}>");
        }
        html.Append(Environment.NewLine);
        var result = StringBuilderCache.GetStringAndRelease(html);
        return result.TrimEnd('\r', '\n');
    }

    /// <summary>
    /// Adds or updates an attribute on the tag.
    /// </summary>
    /// <param name="name">The attribute name.</param>
    /// <param name="value">The attribute value.</param>
    /// <returns>The current <see cref="HtmlTag"/> instance.</returns>
    public HtmlTag Attribute(string name, string value) {
        Attributes[name] = value;
        return this;
    }


    /// <summary>
    /// Appends a child tag.
    /// </summary>
    /// <param name="child">The child tag to add.</param>
    /// <returns>The current <see cref="HtmlTag"/> instance.</returns>
    public HtmlTag Value(HtmlTag? child) {
        if (child is not null) {
            Children.Add(child);
        }
        return this;
    }

    /// <summary>
    /// Appends a child element.
    /// </summary>
    /// <param name="value">The child element.</param>
    /// <returns>The current <see cref="HtmlTag"/> instance.</returns>
    public HtmlTag Value(Element? value) {
        if (value is not null) {
            Children.Add(value);
        }
        return this;
    }

    /// <summary>
    /// Appends a string value to the tag.
    /// </summary>
    /// <param name="value">The text value.</param>
    /// <returns>The current <see cref="HtmlTag"/> instance.</returns>
    public HtmlTag Value(string? value) {
        if (value != null) {
            Children.Add(value);
        }
        return this;
    }

    /// <summary>
    /// Appends multiple string values to the tag.
    /// </summary>
    /// <param name="value">String values to append.</param>
    /// <returns>The current <see cref="HtmlTag"/> instance.</returns>
    public HtmlTag Value(params string?[] value) {
        foreach (var val in value) {
            if (val is not null) {
                Children.Add(val);
            }
        }
        return this;
    }
    /// <summary>
    /// Appends multiple objects to the tag using their <see cref="object.ToString"/> representation.
    /// </summary>
    /// <param name="value">Objects to append.</param>
    /// <returns>The current <see cref="HtmlTag"/> instance.</returns>
    public HtmlTag Value(params object?[] value) {
        // this largely works because of ToString() on the object that we should make sure is there, implemented correctly
        foreach (var val in value) {
            if (val is not null) {
                Children.Add(val);
            }
        }
        return this;
    }
}
