using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

public class TablerDataGridItem : Element {
    public Element TitleElement { get; set; }
    public Element ContentElement { get; set; }

    public TablerDataGridItem Title(string title) {
        TitleElement = new HtmlTag("div").Class("datagrid-title").Value(title);
        return this;
    }

    public TablerDataGridItem Content(string content) {
        ContentElement = new HtmlTag("div").Class("datagrid-content").Value(content);
        return this;
    }
    public TablerDataGridItem Content(Element content) {
        ContentElement = new HtmlTag("div").Class("datagrid-content").Value(content.ToString());
        return this;
    }

    public override string ToString() {
        StringBuilder html = new StringBuilder("<div class=\"datagrid-item\">");

        if (TitleElement != null) {
            html.Append(TitleElement.ToString());
        }

        if (ContentElement != null) {
            html.Append(ContentElement.ToString());
        }

        html.Append("</div>");

        return html.ToString();
    }
}
