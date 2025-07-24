using System.Collections.Generic;
using HtmlForgeX.Tags;
namespace HtmlForgeX.Examples.Tags;


internal static class HtmlTagDivExample {
    public static void Create() {
        HelpersSpectre.PrintTitle("Div Tag Example");

        HtmlTag tag = new HtmlTag("div", "Hello, World!", new Dictionary<string, object> {
            { "style", new Dictionary<string, object> {
                { "color", "red" },
                { "font-size", "24px" }
            } }
        });

        HelpersSpectre.PrintHtmlTag(tag);
    }
}
