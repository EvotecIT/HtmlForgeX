using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

public class FlexSection : HtmlElement {
    public new FlexSection Add(HtmlElement element) {
        Children.Add(element);
        return this;
    }

    public FlexSection Add(string text) {
        Children.Add(new HtmlText { Text = text });
        return this;
    }

    public FlexSection Add(Action<FlexSection> buildAction) {
        buildAction(this);
        return this;
    }

    public override string ToString() {
        StringBuilder sectionBuilder = new StringBuilder();
        sectionBuilder.AppendLine("<section>");

        // Add the HTML of the child elements
        foreach (var child in Children) {
            sectionBuilder.AppendLine(child.ToString());
        }

        sectionBuilder.AppendLine("</section>");

        return sectionBuilder.ToString();
    }
}

