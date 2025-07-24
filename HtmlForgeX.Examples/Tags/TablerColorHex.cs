using HtmlForgeX.Examples;

namespace HtmlForgeX.Examples.Tags;

internal static class TablerColorHex {
    public static void Create() {
        HelpersSpectre.PrintTitle("TablerColor to Hex");
        HelpersSpectre.Info($"Primary: {TablerColor.Primary.ToHex()}");
        HelpersSpectre.Info($"Azure light: {TablerColor.AzureLight.ToHex()}");
    }
}
