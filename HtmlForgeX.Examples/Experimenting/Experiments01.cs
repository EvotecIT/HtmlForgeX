using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlForgeX.Examples.Experimenting;
internal class Experiments01 {
    public static void Create() {
        //var value = new HtmlSpan().AddContent("This is table with DataTables").WithAlignment(Alignment.Center).WithColor(RGBColor.TractorRed).ToString();

        //HelpersSpectre.Success(value);

        //HelpersSpectre.Success("----");

        //var value1 = new HtmlSpan().AddContent("This is table with DataTables").WithAlignment(Alignment.Center)
        //    .WithColor(RGBColor.TractorRed).AppendContent(" continue?");

        //HelpersSpectre.Success(value1);

        //HelpersSpectre.Success("----");

        using var value2 = new Document();
        value2.Body.Span("This is table with DataTables").WithAlignment(Alignment.Center)
            .WithColor(RGBColor.TractorRed).AppendContent(" continue?");

        HelpersSpectre.Info(value2.ToString());

        HelpersSpectre.Success("----");

        var value3 = new Document().Body.Span("This is table with DataTables").WithAlignment(Alignment.Center)
            .WithColor(RGBColor.TractorRed).AppendContent(" continue?");

        HelpersSpectre.Info(value3.ToString());

        HelpersSpectre.Success("----");

        var span = new Document().Body.Span("This is table with DataTables").WithAlignment(Alignment.Center)
            .WithColor(RGBColor.TractorRed).AppendContent(" continue?");
        var value4 = span;
        HelpersSpectre.Info(value4.ToString());

        HelpersSpectre.Success("----");


        HelpersSpectre.Success("---- Hello World");




        //var document = new HtmlDocument();
        //document.Body.Span("Hello, world!")
        //    .WithColor(RGBColor.Red).WithFontSize("20px").WithAlignment(Alignment.Justify)
        //    .AppendContent(" Welcome to HTML by HtmlForgeX")
        //    .WithColor(RGBColor.HarvestGold).WithBackgroundColor(RGBColor.AirForceBlue)
        //    .AppendContent(" Hurray!");
        //HelpersSpectre.Success(document.ToString());
    }
}