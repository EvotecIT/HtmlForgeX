using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

public class HtmlDocument {
    public HtmlHead Head = new HtmlHead();
    public HtmlBody Body = new HtmlBody();

    public HtmlDocument() {

    }

    public void Save(string path, bool openInBrowser = false) {
        System.IO.File.WriteAllText(path, this.ToString());
        Helpers.Open(path, openInBrowser);

    }

    public override string ToString() {
        StringBuilder html = new StringBuilder();

        html.AppendLine("<!DOCTYPE html>");
        html.AppendLine("<html>");
        html.AppendLine(this.Head.ToString());
        html.AppendLine(this.Body.ToString());
        html.AppendLine("</html>");

        return html.ToString();
    }
}