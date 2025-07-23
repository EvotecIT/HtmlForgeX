using HtmlForgeX.Examples;

namespace HtmlForgeX.Examples.Tags;

internal static class ExampleTablerColorHex {
    public static void Create() {
        HelpersSpectre.PrintTitle("TablerColor to Hex");
        HelpersSpectre.Info($"Primary: {TablerColor.Primary.ToHex()}");
        HelpersSpectre.Info($"Azure light: {TablerColor.AzureLight.ToHex()}");
    }
}
