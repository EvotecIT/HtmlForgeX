using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HtmlForgeX.Resources;

namespace HtmlForgeX.Examples.ByHand
{
    internal class BasicHtmlBuilding
    {
        public static void Demo1(bool openInBrowser = false)
        {
            HelpersSpectre.PrintTitle("Basic Html Building 1");

            using Document document = new Document();
            document.Head.Title = "Basic Html Building 1";
            document.Head.Author = "Przemysław Kłys";
            document.Head.Revised = DateTime.Now;

            document.Head.AddMeta("description", "This is a basic demo document");
            document.Head.AddMeta("keywords", "html, c#, .net, library");

            document.Head.AddCharsetMeta("utf-8");
            // document.Head.AddHttpEquivMeta("Content-Type", "text/html; charset=utf-8");
            document.Head.AddViewportMeta("width=device-width, initial-scale=1.0");

            // Add span 3 times in a single line, one after another
            document.Body.Span("Hello, world!")
                .WithColor(RGBColor.Red).WithFontSize("20px").WithAlignment(Alignment.Left)
                .AppendContent(" Welcome to HTML by HtmlForgeX")
                .WithColor(RGBColor.HarvestGold).WithBackgroundColor(RGBColor.AirForceBlue)
                .AppendContent(" Hurray!");

            document.Body.LineBreak();

            //// Add span x 3 one after another in a single line
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

            // Add span x 3 one after another in a single line
            document.Body.Span("Hello, world!")
               .WithColor(RGBColor.Red)
               .WithFontSize("20px")
               .WithAlignment(Alignment.Justify);

            document.Body.Span(" Welcome to HTML by HtmlForgeX")
                   .WithColor(RGBColor.HarvestGold)
                   .WithBackgroundColor(RGBColor.AirForceBlue);

            document.Body.Span(" Hurray!");

            document.Body.LineBreak();

            document.Save("BasicDemoDocument1.html", openInBrowser);
        }


        public static void Demo2(bool openInBrowser = false)
        {
            HelpersSpectre.PrintTitle("Basic Html Building 2");

            using Document document = new Document();

            document.AddLibrary(new Bootstrap());

            document.Head.Title = "Basic Html Building 2";
            document.Head.Author = "Przemysław Kłys";
            document.Head.Revised = DateTime.Now;

            document.Head.AddMeta("description", "This is a basic demo document");
            document.Head.AddMeta("keywords", "html, c#, .net, library");

            document.Head.AddCharsetMeta("utf-8");

            document.Head.AddViewportMeta("width=device-width, initial-scale=1.0");

            // lets add default styles
            document.AddLibrary(Libraries.Primary);

            // lets add custom styles
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

            // get processes from the system
            var processes = System.Diagnostics.Process.GetProcesses().ToList().GetRange(1, 5);

            var table1 = new BootstrapTable(processes, TableType.DataTables);
            document.Body.Add(table1);


            document.Save("BasicDemoDocument2.html", openInBrowser);

        }

        public static void DemoAnalytics(bool openInBrowser = false)
        {
            HelpersSpectre.PrintTitle("Analytics Example");

            using var document = new Document();
            document.Head.AddTitle("Analytics Demo");
            document.Head.AddAnalytics(AnalyticsProvider.GoogleAnalytics, "G-XXXXXXX");

            document.Body.Span("Hello Analytics!");

            document.Save("AnalyticsDemo.html", openInBrowser);
        }

        public static void DemoAnalyticsSpecialChars(bool openInBrowser = false)
        {
            HelpersSpectre.PrintTitle("Analytics Special Characters Example");

            var document = new Document();
            document.Head.AddTitle("Analytics Special Characters Demo");
            document.Head.AddAnalytics(AnalyticsProvider.GoogleAnalytics, "G-\"A&B<C>'");

            document.Body.Span("Hello Analytics Special Characters!");

            document.Save("AnalyticsDemoSpecialChars.html", openInBrowser);
        }

        public static void DemoSanitizedRawHtml(bool openInBrowser = false)
        {
            HelpersSpectre.PrintTitle("Sanitized RawHtml Example");

            var document = new Document();
            document.Head.AddTitle("Sanitized RawHtml Demo");

            var div = new HtmlTag("div")
                .ValueRaw("<script>alert('x')</script><span>Safe</span>", true);

            document.Body.Add(div);

            document.Save("SanitizedRawHtml.html", openInBrowser);
        }
    }
}
