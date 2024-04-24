using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Tags;
internal class BasicHtmlTagBuilding02 {
    public static void Demo1() {
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

        //  var image = new HtmlImage("/path/to/image.jpg", "An example image");
        //  var paragraph = new HtmlParagraph("This is a paragraph.");
        //var div = new HtmlDiv(link, image, paragraph);

        //var image = HtmlTags.Img("/path/to/image.jpg", "An example image");
        //var paragraph = HtmlTags.P("This is a paragraph.");
        //var div = HtmlTags.Div(link, image, paragraph);


        // HelpersSpectre.PrintHtmlTag(div);


        //var paragraph2 = HtmlTags.P("This is another paragraph.").Style("color", "#000");

        // HelpersSpectre.PrintHtmlTag(paragraph2);
        // HelpersSpectre.PrintTitle("Basic Demo 1 - 4");


        //var div1 = HtmlTags.Div(
        //               HtmlTags.P(new Strong("This is a paragraph."), "test"),
        //                          HtmlTags.P("This is another paragraph.").Style("color", "#000")
        //                      );
        // HelpersSpectre.PrintHtmlTag(div1);
    }
}
