using System.Collections.Generic;
using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Tags;

internal static class HtmlTagSpanExample {
    public static void Create() {
        HelpersSpectre.PrintTitle("Span Tag Example");

        HtmlTag tag = new HtmlTag("span", "Hello, World!", new Dictionary<string, object> {
            { "class", "myClass" },
            { "style", new Dictionary<string, string> {
                { "font-size", "25px" },
                { "margin", "5px" }
            } }
        });

        HelpersSpectre.PrintHtmlTag(tag);
    }
}
