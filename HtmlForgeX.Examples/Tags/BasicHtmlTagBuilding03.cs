using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Tags;

internal partial class BasicHtmlTagBuilding {
    public static void Demo7() {
        var tag = new HtmlTag("span")
            .Style("color", "red")
            .Style("font-weight", "bold");

        HelpersSpectre.PrintHtmlTag("HtmlTag - Demo 7", tag);
    }
}