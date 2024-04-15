using HtmlForgeX;
using HtmlForgeX.Examples;
using HtmlForgeX.Examples.ByHand;
using HtmlForgeX.Examples.Containers;
using HtmlForgeX.Examples.Tables;
using HtmlForgeX.Examples.Tags;

//BasicHtmlTagBuilding.Demo1();
//BasicHtmlTagBuilding.Demo2();
//BasicHtmlTagBuilding.Demo3();
//BasicHtmlTagBuilding.Demo4();
//BasicHtmlBuilding.Demo1(true);
//BasicHtmlBuilding.Demo2(true);
//BasicHtmlTable01.Demo1(true);
//BasicHtmlContainer01.Demo01(true);

BasicHtmlContainer02.Demo02(true);
return;

//Test();

void Test() {
    //var value = new HtmlSpan().AddContent("This is table with DataTables").WithAlignment(FontAlignment.Center).WithColor(RGBColor.TractorRed).ToString();

    //Console.WriteLine(value);

    //Console.WriteLine("----");

    //var value1 = new HtmlSpan().AddContent("This is table with DataTables").WithAlignment(FontAlignment.Center)
    //    .WithColor(RGBColor.TractorRed).AppendContent(" continue?");

    //Console.WriteLine(value1);

    //Console.WriteLine("----");

    var value2 = new HtmlDocument();
    value2.Body.Span("This is table with DataTables").WithAlignment(FontAlignment.Center)
    .WithColor(RGBColor.TractorRed).AppendContent(" continue?");

    Console.WriteLine(value2);

    Console.WriteLine("----");

    var value3 = new HtmlDocument().Body.Span("This is table with DataTables").WithAlignment(FontAlignment.Center)
        .WithColor(RGBColor.TractorRed).AppendContent(" continue?");

    Console.WriteLine(value3);

    Console.WriteLine("----");

    var span = new HtmlDocument().Body.Span("This is table with DataTables").WithAlignment(FontAlignment.Center)
        .WithColor(RGBColor.TractorRed).AppendContent(" continue?");
    var value4 = span;
    Console.WriteLine(value4);

    Console.WriteLine("----");


    Console.WriteLine("---- Hello World");




    //var document = new HtmlDocument();
    //document.Body.Span("Hello, world!")
    //    .WithColor(RGBColor.Red).WithFontSize("20px").WithAlignment(FontAlignment.Justify)
    //    .AppendContent(" Welcome to HTML by HtmlForgeX")
    //    .WithColor(RGBColor.HarvestGold).WithBackgroundColor(RGBColor.AirForceBlue)
    //    .AppendContent(" Hurray!");
    //Console.WriteLine(document.ToString());
}