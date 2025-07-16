using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlForgeX.Examples.Experimenting;
internal class Experiments01 {
    public static void Create() {
        //var value = new HtmlSpan().AddContent("This is table with DataTables").WithAlignment(Alignment.Center).WithColor(RGBColor.TractorRed).ToString();

        //Console.WriteLine(value);

        //Console.WriteLine("----");

        //var value1 = new HtmlSpan().AddContent("This is table with DataTables").WithAlignment(Alignment.Center)
        //    .WithColor(RGBColor.TractorRed).AppendContent(" continue?");

        //Console.WriteLine(value1);

        //Console.WriteLine("----");

        using var value2 = new Document();
        value2.Body.Span("This is table with DataTables").WithAlignment(Alignment.Center)
            .WithColor(RGBColor.TractorRed).AppendContent(" continue?");

        Console.WriteLine(value2);

        Console.WriteLine("----");

        var value3 = new Document().Body.Span("This is table with DataTables").WithAlignment(Alignment.Center)
            .WithColor(RGBColor.TractorRed).AppendContent(" continue?");

        Console.WriteLine(value3);

        Console.WriteLine("----");

        var span = new Document().Body.Span("This is table with DataTables").WithAlignment(Alignment.Center)
            .WithColor(RGBColor.TractorRed).AppendContent(" continue?");
        var value4 = span;
        Console.WriteLine(value4);

        Console.WriteLine("----");


        Console.WriteLine("---- Hello World");




        //var document = new HtmlDocument();
        //document.Body.Span("Hello, world!")
        //    .WithColor(RGBColor.Red).WithFontSize("20px").WithAlignment(Alignment.Justify)
        //    .AppendContent(" Welcome to HTML by HtmlForgeX")
        //    .WithColor(RGBColor.HarvestGold).WithBackgroundColor(RGBColor.AirForceBlue)
        //    .AppendContent(" Hurray!");
        //Console.WriteLine(document.ToString());
    }
}
