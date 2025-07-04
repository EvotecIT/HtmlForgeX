using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlForgeX.Examples.Tags;
internal class ExampleTablerIcon {
    public static void Demo() {
        var icon = new TablerIconElement(TablerIconType.BasketDollar).Color(RGBColor.Akaroa).FontSize(24).StrokeWidth(0.1);
        Console.WriteLine(icon);
        var icon1 = new TablerIconElement(TablerIconType.BrandMastercard).Color(RGBColor.Akaroa).FontSize(24).StrokeWidth(0.1);
        Console.WriteLine(icon1);
    }
}
