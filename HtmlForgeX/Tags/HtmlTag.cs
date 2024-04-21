using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;
public class HtmlTag : Element {
    private string Tag { get; set; }
    private string Value { get; set; } = "";
    public new List<HtmlTag> Children { get; set; } = new List<HtmlTag>();
    public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
    public bool SelfClosing { get; set; }
    public bool NoClosing { get; set; }

    public HtmlTag(string tag) {
        Tag = tag;
    }

    public HtmlTag(string tag, string value) {
        Tag = tag;
        Value = value;
    }

    public HtmlTag(string tag, string value, bool selfClosing, bool noClosing = false) {
        Tag = tag;
        Value = value;
        SelfClosing = selfClosing;
        NoClosing = noClosing;
    }

    public HtmlTag(string tag, string value, Dictionary<string, object> attributes = null, bool selfClosing = false, bool noClosing = false) {
        Tag = tag;
        Value = value;
        SelfClosing = selfClosing;
        NoClosing = noClosing;

        if (attributes != null) {
            foreach (var attribute in attributes) {
                if (attribute.Value is Dictionary<string, string> nestedAttributes) {
                    StringBuilder nestedValue = new StringBuilder();
                    foreach (var nestedAttribute in nestedAttributes) {
                        nestedValue.Append($"{nestedAttribute.Key}: {nestedAttribute.Value}; ");
                    }
                    Attributes[attribute.Key] = nestedValue.ToString().TrimEnd(' ', ';');
                } else {
                    Attributes[attribute.Key] = attribute.Value.ToString();
                }
            }
        }
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

    public HtmlTag Id(string id) {
        Attributes["id"] = id;
        return this;
    }

    public HtmlTag Type(string type) {
        Attributes["type"] = type;
        return this;
    }

    public HtmlTag Append(HtmlTag child) {
        Children.Add(child);
        return this;
    }

    public HtmlTag Append(string value) {
        Value += value;
        return this;
    }

    public HtmlTag Append(Element value) {
        Value += value.ToString();
        return this;
    }

    public override string ToString() {
        StringBuilder html = new StringBuilder($"<{Tag}");

        foreach (var attribute in Attributes) {
            if (attribute.Value != null && !string.IsNullOrEmpty(attribute.Value.ToString())) {
                html.Append($" {attribute.Key}=\"{attribute.Value}\"");
            }
        }

        if (SelfClosing) {
            html.Append("/>");
        } else {
            html.Append(">");

            foreach (var child in Children) {
                html.Append(child.ToString());
            }

            if (!string.IsNullOrEmpty(Value)) {
                html.Append(Value);
            }

            if (!NoClosing) {
                html.Append($"</{Tag}>");
            }
        }

        return html.ToString();
    }

    public HtmlTag SetAttribute(string name, string value) {
        Attributes[name] = value;
        return this;
    }

    public HtmlTag SetValue(string? value) {
        if (value != null) {
            Value += value;
        }

        return this;
    }
}
