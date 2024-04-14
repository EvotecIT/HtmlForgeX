using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

public class HtmlTablerPage : HtmlElementContainer {
    public List<HtmlTablerRow> Rows { get; set; } = new List<HtmlTablerRow>();

    public HtmlTablerPage() {
        GlobalStorage.Libraries.Add(Libraries.Bootstrap);
        GlobalStorage.Libraries.Add(Libraries.Tabler);
    }

    public override string ToString() {
        Console.WriteLine("Generating HtmlPage...");
        var childrenHtml = string.Join("", Children.Select(child => child.ToString()));
        var result = $"<div class=\"page-wrapper\"><div class=\"page-body\"><div class=\"container-xl\">{childrenHtml}</div></div></div>";
        Console.WriteLine("Generated HtmlPage: " + result);
        return result;
    }

    public HtmlTablerPage Add(Action<HtmlTablerPage> config) {
        config(this);
        return this;
    }

    public HtmlTablerColumn Column(Action<HtmlTablerColumn> config) {
        var column = new HtmlTablerColumn();
        config(column);
        this.Add(column);
        return column;
    }
}
