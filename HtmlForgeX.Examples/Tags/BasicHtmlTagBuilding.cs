namespace HtmlForgeX.Examples.Tags {
    internal class BasicHtmlTagBuilding {
        public static void Demo1() {
            HelpersSpectre.PrintTitle("Basic Demo 1");

            HtmlTag tag = new HtmlTag("div", "Hello, World!", new Dictionary<string, object> {
                { "style", new Dictionary<string, object> {
                    { "color", "red" },
                    { "font-size", "24px" }
                } }
            });

            HelpersSpectre.PrintHtmlTag(tag);
        }

        public static void Demo5() {
            HelpersSpectre.PrintTitle("Basic Demo 1");

            HtmlTag tag = new HtmlTag("span", "Hello, World!", new Dictionary<string, object> {
                { "class", "myClass" },
                { "style", new Dictionary<string, string> {
                    { "font-size", "25px" },
                    { "margin", "5px" }
                } }
            });

            HelpersSpectre.PrintHtmlTag(tag);
        }


        public static void Demo2() {
            HelpersSpectre.PrintTitle("Basic Demo 2");

            var fluent = new HtmlTag("div").Class("control-group")
                .Value(new HtmlTag("div").Class("controls")
                    .Value(new HtmlTag("label").Class("checkbox")
                        .Value(new HtmlTag("input").Type("checkbox"))
                        .Value(" Remember me")))
                .Value(new HtmlTag("button").Type("submit").Class("btn").Value("Sign in"));

            HelpersSpectre.PrintHtmlTag(fluent);
        }

        public static void Demo3() {
            HelpersSpectre.PrintTitle("Basic Demo 3");

            var html = new HtmlTag("html");
            var head = new HtmlTag("head");
            var title = new HtmlTag("title").Value("HtmlForgeX Demo");
            var body = new HtmlTag("body");
            var h1 = new HtmlTag("h1").Value("HtmlForgeX Demo");
            var p = new HtmlTag("p").Value("This is a demo of the HtmlForgeX library.");

            head.Value(title);
            body.Value(h1).Value(p);
            html.Value(head).Value(body);

            HelpersSpectre.PrintHtmlTag(html);
        }

        public static void Demo4() {
            HelpersSpectre.PrintTitle("Basic Demo 4");

            var html = new HtmlTag("html");
            var head = new HtmlTag("head");
            var title = new HtmlTag("title").Value("HtmlForgeX Demo");
            var body = new HtmlTag("body");
            var h1 = new HtmlTag("h1").Value("HtmlForgeX Demo");
            var p = new HtmlTag("p").Value("This is a demo of the HtmlForgeX library.");
            var ul = new HtmlTag("ul");
            var li1 = new HtmlTag("li").Value("Item 1");
            var li2 = new HtmlTag("li").Value("Item 2");
            var li3 = new HtmlTag("li").Value("Item 3");

            head.Value(title);
            ul.Value(li1).Value(li2).Value(li3);
            body.Value(h1).Value(p).Value(ul);
            html.Value(head).Value(body);

            HelpersSpectre.PrintHtmlTag(html);
        }
    }
}
