using System.Collections.Generic;

using HtmlForgeX;
using HtmlForgeX.Resources;
namespace HtmlForgeX.Examples.ByHand;

internal static class DocumentSpanStylesExample {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Basic Html Building 1");

        using Document document = new Document();
        document.Head.Title = "DocumentSpanStylesExample";
        document.Head.Author = "Przemysław Kłys";
        document.Head.Revised = DateTime.Now;

        document.Head.AddMeta("description", "This is a basic demo document");
        document.Head.AddMeta("keywords", "html, c#, .net, library");

        document.Head.AddCharsetMeta("utf-8");
        document.Head.AddViewportMeta("width=device-width, initial-scale=1.0");

        document.Body.Span("Hello, world!")
            .WithColor(RGBColor.Red).WithFontSize("20px").WithAlignment(Alignment.Left)
            .AppendContent(" Welcome to HTML by HtmlForgeX")
            .WithColor(RGBColor.HarvestGold).WithBackgroundColor(RGBColor.AirForceBlue)
            .AppendContent(" Hurray!");

        document.Body.LineBreak();

        var span1 = new Span()
            .AddContent("This is the content")
            .WithColor(RGBColor.RedDevil)
            .WithBackgroundColor(RGBColor.GreenMist)
            .WithFontSize("12px")
            .WithLineHeight("1.5")
            .WithFontWeight(FontWeight.Bold)
            .WithFontStyle(FontStyle.Italic)
            .WithFontVariant(FontVariant.SmallCaps)
            .WithFontFamily("Arial")
            .WithAlignment(Alignment.Center)
            .WithTextDecoration(TextDecoration.Underline)
            .WithTextTransform(TextTransform.Uppercase)
            .WithDirection(Direction.Rtl)
            .WithDisplay(Display.Block)
            .WithOpacity(0.8);

        var span2 = span1.AddContent(" more content").WithColor(RGBColor.BlueDiamond);
        var span3 = span2.AddContent(" even more content").WithColor(RGBColor.WhiteSmoke).WithBackgroundColor(RGBColor.Redwood);

        document.Body.Add(span1);
        document.Body.LineBreak();
        document.Body.Add(span2);
        document.Body.LineBreak();
        document.Body.Add(span3);
        document.Body.LineBreak();

        var span4 = new Span()
            .AppendContent("Should be RED").WithColor(RGBColor.Red)
            .AppendContent("Should be BLUE").WithColor(RGBColor.Blue)
            .AppendContent("Should be GREEN").WithColor(RGBColor.Green);

        document.Body.Add(span4);
        document.Body.LineBreak();

        document.Body.Span("Hello, world!")
            .WithColor(RGBColor.Red)
            .WithFontSize("20px")
            .WithAlignment(Alignment.Justify);

        document.Body.Span(" Welcome to HTML by HtmlForgeX")
            .WithColor(RGBColor.HarvestGold)
            .WithBackgroundColor(RGBColor.AirForceBlue);

        document.Body.Span(" Hurray!");
        document.Body.LineBreak();

        document.Save("DocumentSpanStylesExample.html", openInBrowser);
    }
}