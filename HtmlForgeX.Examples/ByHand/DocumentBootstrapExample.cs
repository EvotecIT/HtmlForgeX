using System.Collections.Generic;
using System.Linq;

using HtmlForgeX;
using HtmlForgeX.Resources;
namespace HtmlForgeX.Examples.ByHand;

internal static class DocumentBootstrapExample {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Basic Html Building 2");

        using Document document = new Document();
        document.AddLibrary(new Bootstrap());

        document.Head.Title = "DocumentBootstrapExample";
        document.Head.Author = "Przemysław Kłys";
        document.Head.Revised = DateTime.Now;

        document.Head.AddMeta("description", "This is a basic demo document");
        document.Head.AddMeta("keywords", "html, c#, .net, library");

        document.Head.AddCharsetMeta("utf-8");
        document.Head.AddViewportMeta("width=device-width, initial-scale=1.0");

        document.AddLibrary(Libraries.Primary);
        document.Head.AddStyle(
            new Style("body")
                .Add("font-family", "'Roboto Condensed', sans-serif")
                .Add("font-size", "8pt")
                .Add("margin", "0px")
        );

        document.Body
            .Add(new HtmlTag("div")
                .Value(new HtmlTag("h1", "Hello World!"))
                .Value(new HtmlTag("p", "This is a basic demo document."))
        );

        var span1 = new Span()
            .AddContent("This is the content")
            .WithColor(RGBColor.RedDevil)
            .WithBackgroundColor(RGBColor.Yellow)
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

        var span2 = span1.AddContent("more content").WithColor(RGBColor.AliceBlue);
        var span3 = span2.AddContent("even more content").WithColor(RGBColor.Armygreen);

        document.Body.Add(span1);
        document.Body.Add(span2);
        document.Body.Add(span3);

        document.Body.Add(new Span().AddContent("Should be Tractor Red").WithColor(RGBColor.TractorRed));

        var span10 = new Span()
            .AppendContent("Should be RED").WithColor(RGBColor.Red)
            .AppendContent("Should be BLUE").WithColor(RGBColor.Blue)
            .AppendContent("Should be GREEN").WithColor(RGBColor.Green);

        document.Body.Add(span10);

        var table = new DataTablesTable();
        table.AddHeaders("Header 1", "Header 2", "Header 3")
            .AddRows(
                new List<string> { "Row 1 Cell 1", "Row 1 Cell 2", "Row 1 Cell 3" },
                new List<string> { "Row 2 Cell 1", "Row 2 Cell 2", "Row 2 Cell 3" }
            );

        document.Body.Add(table);

        var processes = System.Diagnostics.Process.GetProcesses().ToList().GetRange(1, 5);
        var table1 = new BootstrapTable(processes, TableType.DataTables);
        document.Body.Add(table1);

        document.Save("DocumentBootstrapExample.html", openInBrowser);
    }
}