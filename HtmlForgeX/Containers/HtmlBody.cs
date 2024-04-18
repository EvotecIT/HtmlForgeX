using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

public class HtmlBody : HtmlElement {
    public ThemeMode ThemeMode { get; set; }

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

    public TablerPage Page() {
        var page = new TablerPage();
        this.Add(page);
        return page;
    }

    public TablerPage Page(Action<TablerPage> config) {
        var page = new TablerPage();
        config(page);
        this.Add(page);
        return page;
    }

    public override string ToString() {
        StringBuilder bodyBuilder = new StringBuilder();
        if (ThemeMode == ThemeMode.Dark) {
            bodyBuilder.AppendLine("<body data-bs-theme=\"dark\">");
        } else if (ThemeMode == ThemeMode.Light) {
            bodyBuilder.AppendLine("<body data-bs-theme=\"light\">");
        } else {
            bodyBuilder.AppendLine("<body>");
        }
        // Add the HTML of the child elements
        foreach (var child in Children) {
            bodyBuilder.AppendLine(child.ToString());
        }

        bodyBuilder.AppendLine("</body>");

        return bodyBuilder.ToString();
    }
}
