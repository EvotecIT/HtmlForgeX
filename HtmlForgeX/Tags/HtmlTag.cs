using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;
public class HtmlTag : Element {
    private string PrivateTag { get; set; }
    //private string PrivateValue { get; set; } = "";
    public new List<object> Children { get; set; } = new List<object>();
    public Dictionary<string, object> Attributes { get; set; } = new Dictionary<string, object>();
    public bool SelfClosing { get; set; }
    public bool NoClosing { get; set; }

    public HtmlTag(string tag) {
        PrivateTag = tag;
    }

    public HtmlTag(string tag, string value) {
        PrivateTag = tag;
        Children.Add(value);
    }

    public HtmlTag(string tag, bool selfClosing) {
        PrivateTag = tag;
        SelfClosing = selfClosing;
    }

    public HtmlTag(string tag, string value, bool selfClosing, bool noClosing = false) {
        PrivateTag = tag;
        Children.Add(value);
        SelfClosing = selfClosing;
        NoClosing = noClosing;
    }

    public HtmlTag(string tag, string value, Dictionary<string, object> attributes = null, bool selfClosing = false, bool noClosing = false) {
        PrivateTag = tag;
        Children.Add(value);
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

        //if (attributes != null) {
        //    foreach (var attribute in attributes) {
        //        //   if (attribute.Key == "style" && attribute.Value is Dictionary<string, string> styleDict) {
        //        StringBuilder styleValue = new StringBuilder();
        //        foreach (var style in styleDict) {
        //            styleValue.Append($"{style.Key}: {style.Value}; ");
        //        }
        //        Attributes[attribute.Key] = styleValue.ToString().TrimEnd(' ', ';');
        //        // } else {
        //        //     Attributes[attribute.Key] = attribute.Value.ToString();
        //        // }
        //    }
        //}

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

        //foreach (var attribute in Attributes) {
        //    if (attribute.Value != null && !string.IsNullOrEmpty(attribute.Value.ToString())) {
        //        html.Append($" {attribute.Key}=\"{attribute.Value}\"");
        //    }
        //}

        foreach (var attribute in Attributes) {
            if (attribute.Value != null && !string.IsNullOrEmpty(attribute.Value.ToString())) {
                if (attribute.Key == "style" && attribute.Value is Dictionary<string, object> styleDict) {
                    StringBuilder styleValue = new StringBuilder();
                    foreach (var style in styleDict) {
                        styleValue.Append($"{style.Key}: {style.Value}; ");
                    }
                    html.Append($" style=\"{styleValue.ToString().TrimEnd(' ', ';')}\"");
                } else {
                    html.Append($" {attribute.Key}=\"{attribute.Value}\"");
                }
            }
        }

        if (SelfClosing) {
            html.Append("/>");
        } else {
            html.Append(">");

            foreach (var child in Children) {
                html.Append(child);
            }

            if (!NoClosing) {
                html.Append($"</{PrivateTag}>");
            }
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
}
