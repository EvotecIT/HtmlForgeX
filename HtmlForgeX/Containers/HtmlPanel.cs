using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;
public class HtmlPanel : HtmlElement {
    public new HtmlPanel Add(HtmlElement element) {
        Children.Add(element);
        return this;
    }

    public HtmlPanel Add(string text) {
        Children.Add(new HtmlText { Text = text });
        return this;
    }

    public HtmlPanel Add(Action<HtmlPanel> buildAction) {
        buildAction(this);
        return this;
    }

    public override string ToString() {
        StringBuilder panelBuilder = new StringBuilder();
        panelBuilder.AppendLine("<div class=\"panel\">");

        // Add the HTML of the child elements
        foreach (var child in Children) {
            panelBuilder.AppendLine(child.ToString());
        }

        panelBuilder.AppendLine("</div>");

        return panelBuilder.ToString();
    }
}
