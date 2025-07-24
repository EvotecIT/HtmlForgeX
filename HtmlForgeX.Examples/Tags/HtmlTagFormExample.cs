using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Tags;

internal static class HtmlTagFormExample {
    public static void Create() {
        HelpersSpectre.PrintTitle("Fluent Form Example");

        var tag = new HtmlTag("div").Class("control-group")
            .Value(new HtmlTag("div").Class("controls")
                .Value(new HtmlTag("label").Class("checkbox")
                    .Value(new HtmlTag("input").Type("checkbox"))
                    .Value(" Remember me")))
            .Value(new HtmlTag("button").Type("submit").Class("btn").Value("Sign in"));

        HelpersSpectre.PrintHtmlTag(tag);
    }
}