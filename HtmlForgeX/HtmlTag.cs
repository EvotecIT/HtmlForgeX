using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;
public class HtmlTag : Element {
    private string PrivateTag { get; set; }
    private TagMode PrivateTagMode { get; set; } = TagMode.Normal;
    private new List<object> Children { get; set; } = new List<object>();
    public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();

    public HtmlTag(string tag) {
        PrivateTag = tag;
    }

    public HtmlTag(string tag, string value) {
        PrivateTag = tag;
        Children.Add(value);
    }

    public HtmlTag(string tag, TagMode tagMode) {
        PrivateTag = tag;
        PrivateTagMode = tagMode;
    }

    public HtmlTag(string tag, string value, TagMode tagMode) {
        PrivateTag = tag;
        PrivateTagMode = tagMode;
        Children.Add(value);
    }

    public HtmlTag(string tag, string value, Dictionary<string, object>? attributes = null, TagMode tagMode = TagMode.Normal) {
        PrivateTag = tag;
        Children.Add(value);
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

    public HtmlTag Id(string id) {
        Attributes["id"] = id;
        return this;
    }

    public HtmlTag Style(string name, string value) {
        if (!Attributes.ContainsKey("style")) {
            Attributes["style"] = string.Empty;
        }
        Attributes["style"] += $"{name}: {value}; ";
        return this;
    }

    public HtmlTag Class(string? className) {
        // user used Class null so we don't do anything
        if (className == null) {
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

    public HtmlTag Type(string type) {
        Attributes["type"] = type;
        return this;
    }

    public override string ToString() {
        StringBuilder html = new StringBuilder($"<{PrivateTag}");

        foreach (var attribute in Attributes) {
            if (attribute.Value != null && !string.IsNullOrEmpty(attribute.Value.ToString())) {
                if (attribute.Key == "style" && attribute.Value is Dictionary<string, object> styleDict) {
                    StringBuilder styleValue = new StringBuilder();
                    foreach (var style in styleDict) {
                        styleValue.Append($"{style.Key}: {style.Value}; ");
                    }
                    html.Append($" style=\"{styleValue.ToString().TrimEnd(' ', ';')}\"");
                } else {
                    html.Append($" {attribute.Key}=\"{attribute.Value.ToString()?.Trim()}\"");
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
            foreach (var child in Children) {
                html.Append(child);
            }
            html.Append($"</{PrivateTag}>");
        }
        return html.ToString();
    }

    public HtmlTag Attribute(string name, string value) {
        Attributes[name] = value;
        return this;
    }


    public HtmlTag Value(HtmlTag child) {
        Children.Add(child);
        return this;
    }

    public HtmlTag Value(Element value) {
        Children.Add(value);
        return this;
    }

    public HtmlTag Value(string? value) {
        if (value != null) {
            Children.Add(value);
        }
        return this;
    }

    public HtmlTag Value(params string[] value) {
        foreach (var val in value) {
            Children.Add(val);
        }
        return this;
    }
    public HtmlTag Value(params object[] value) {
        // this largely works because of ToString() on the object that we should make sure is there, implemented correctly
        foreach (var val in value) {
            Children.Add(val);
        }
        return this;
    }
}
