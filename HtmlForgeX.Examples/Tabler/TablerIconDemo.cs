using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlForgeX.Examples.Tabler;
internal class TablerIconDemo {
    public static void Create() {
        var icon = new TablerIconElement(TablerIconType.BasketDollar).Color(RGBColor.Akaroa).FontSize(24).StrokeWidth(0.1);
        HelpersSpectre.Info(icon.ToString());
        var icon1 = new TablerIconElement(TablerIconType.BrandMastercard).Color(RGBColor.Akaroa).FontSize(24).StrokeWidth(0.1);
        HelpersSpectre.Info(icon1.ToString());
    }
}
