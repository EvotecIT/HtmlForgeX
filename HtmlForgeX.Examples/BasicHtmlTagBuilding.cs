namespace HtmlForgeX.Examples {
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
                .Append(new HtmlTag("div").Class("controls")
                    .Append(new HtmlTag("label").Class("checkbox")
                        .Append(new HtmlTag("input").Type("checkbox"))
                        .Append(" Remember me")))
                .Append(new HtmlTag("button").Type("submit").Class("btn").Append("Sign in"));

            HelpersSpectre.PrintHtmlTag(fluent);
        }

        public static void Demo3() {
            HelpersSpectre.PrintTitle("Basic Demo 3");

            var html = new HtmlTag("html");
            var head = new HtmlTag("head");
            var title = new HtmlTag("title").Append("HtmlForgeX Demo");
            var body = new HtmlTag("body");
            var h1 = new HtmlTag("h1").Append("HtmlForgeX Demo");
            var p = new HtmlTag("p").Append("This is a demo of the HtmlForgeX library.");

            head.Append(title);
            body.Append(h1).Append(p);
            html.Append(head).Append(body);

            HelpersSpectre.PrintHtmlTag(html);
        }

        public static void Demo4() {
            HelpersSpectre.PrintTitle("Basic Demo 4");

            var html = new HtmlTag("html");
            var head = new HtmlTag("head");
            var title = new HtmlTag("title").Append("HtmlForgeX Demo");
            var body = new HtmlTag("body");
            var h1 = new HtmlTag("h1").Append("HtmlForgeX Demo");
            var p = new HtmlTag("p").Append("This is a demo of the HtmlForgeX library.");
            var ul = new HtmlTag("ul");
            var li1 = new HtmlTag("li").Append("Item 1");
            var li2 = new HtmlTag("li").Append("Item 2");
            var li3 = new HtmlTag("li").Append("Item 3");

            head.Append(title);
            ul.Append(li1).Append(li2).Append(li3);
            body.Append(h1).Append(p).Append(ul);
            html.Append(head).Append(body);

            HelpersSpectre.PrintHtmlTag(html);
        }
    }
}
