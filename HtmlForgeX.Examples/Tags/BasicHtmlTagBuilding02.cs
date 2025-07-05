using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Tags;
internal partial class BasicHtmlTagBuilding {
    public static void Demo6() {
        HtmlTag tag = new HtmlTag("div", "Hello, World!", new Dictionary<string, object> {
            { "style", new Dictionary<string, object> {
                { "color", "red" },
                { "font-size", "24px" }
            } }
        });

        HelpersSpectre.PrintHtmlTag("HtmlTag - Demo 1", tag);

        var anchor1 = new Anchor("https://evample.com", "Example").HrefLink("https://evotec.xyz").HrefLang("EN");
        HelpersSpectre.PrintHtmlTag("Tag - HtmlAnchor 1", anchor1);

        var anchor2 = new Anchor("https://evample.com", "Example").HrefLink("https://evotec.xyz").Name("Example Website").HrefLink("https://evotec.xyz").Target("_blank");
        HelpersSpectre.PrintHtmlTag("Tag - HtmlAnchor 2", anchor2);

        var abbr1 = new Abbr("HTML").Title("Hyper Text Markup Language");
        HelpersSpectre.PrintHtmlTag("Tag - HtmlAbbr 1", abbr1);

        var strong = new Strong("This is a paragraph.");
        HelpersSpectre.PrintHtmlTag("Tag - HtmlStrong 1", strong);

        var address = new Address("This is an address.");
        HelpersSpectre.PrintHtmlTag("Tag - HtmlAddress 1", address);

        var article = new Article("This is an article.");
        HelpersSpectre.PrintHtmlTag("Tag - HtmlArticle 1", article);

        var br = new BR();
        HelpersSpectre.PrintHtmlTag("Tag - HtmlBr 1", br);

        var lineBreak = new LineBreak();
        HelpersSpectre.PrintHtmlTag("Tag - HtmlLineBreak 1", lineBreak);

        var hr = new HR();
        HelpersSpectre.PrintHtmlTag("Tag - HtmlHr 1", hr);

        var horizontalRule = new HorizontalRule();
        HelpersSpectre.PrintHtmlTag("Tag - HtmlHorizontalRule 1", horizontalRule);

        var h1 = new H1("This is a header 1.");
        HelpersSpectre.PrintHtmlTag("Tag - HtmlH1 1", h1);

        var h2 = new H2("This is a header 2.");
        HelpersSpectre.PrintHtmlTag("Tag - HtmlH2 1", h2);

        var h3 = new H3("This is a header 3.");
        HelpersSpectre.PrintHtmlTag("Tag - HtmlH3 1", h3);

        var h4 = new H4("This is a header 4.");
        HelpersSpectre.PrintHtmlTag("Tag - HtmlH4 1", h4);

        var h5 = new H5("This is a header 5.");
        HelpersSpectre.PrintHtmlTag("Tag - HtmlH5 1", h5);

        var h6 = new H6("This is a header 6.");
        HelpersSpectre.PrintHtmlTag("Tag - HtmlH6 1", h6);
    }
}
