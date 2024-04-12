using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;
public class HtmlTag {
    public string Tag { get; set; }
    public string Value { get; set; }
    public List<HtmlTag> Children { get; set; } = new List<HtmlTag>();
    public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
    public bool SelfClosing { get; set; }
    public bool NoClosing { get; set; }

    public HtmlTag(string tag) {
        Tag = tag;
    }

    public HtmlTag(string tag, string value = "", bool selfClosing = false, bool noClosing = false) {
        Tag = tag;
        Value = value;
        SelfClosing = selfClosing;
        NoClosing = noClosing;
    }

    public HtmlTag(string tag, string value = "", Dictionary<string, object> attributes = null, bool selfClosing = false, bool noClosing = false) {
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

    public HtmlTag Class(string className) {
        Attributes["class"] = className;
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
}
