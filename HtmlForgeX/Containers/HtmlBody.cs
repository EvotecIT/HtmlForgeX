using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

public class HtmlBody : HtmlElement {
    public new HtmlBody Add(HtmlElement element) {
        Children.Add(element);
        return this;
    }

    public HtmlBody Add(string text) {
        Children.Add(new HtmlText { Text = text });
        return this;
    }

    public HtmlBody Add(Action<HtmlBody> buildAction) {
        buildAction(this);
        return this;
    }
    public override string ToString() {
        StringBuilder bodyBuilder = new StringBuilder();
        bodyBuilder.AppendLine("<body>");

        // Add the HTML of the child elements
        foreach (var child in Children) {
            bodyBuilder.AppendLine(child.ToString());
        }

        bodyBuilder.AppendLine("</body>");

        return bodyBuilder.ToString();
    }
}