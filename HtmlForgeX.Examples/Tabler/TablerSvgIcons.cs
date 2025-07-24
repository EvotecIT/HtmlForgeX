using System;

namespace HtmlForgeX.Examples.Tabler;

internal class TablerSvgIcons {
    public static void Create() {
        HelpersSpectre.Success("=== SVG Icons Demo ===");

        // Basic icon usage
        var alertIcon = TablerIconLibrary.GetIcon(TablerIconType.AlertCircle).StrokeColor(RGBColor.Red).Size(24);
        HelpersSpectre.Success("Alert Icon: " + alertIcon);

        // Styled icon with positioning
        var successIcon = TablerIconLibrary.GetIcon(TablerIconType.AdjustmentsCheck)
            .StrokeColor(RGBColor.Green)
            .Size(32)
            .Margin("10px")
            .VerticalAlign("middle");
        HelpersSpectre.Success("Success Icon: " + successIcon);

        // Transformed icon
        var rotatedArrow = TablerIconLibrary.GetIcon(TablerIconType.ArrowRight)
            .Size(24)
            .Rotate(45)
            .StrokeColor(RGBColor.Blue);
        HelpersSpectre.Success("Rotated Arrow: " + rotatedArrow);

        // Custom styled icon
        var heartIcon = TablerIconLibrary.GetIcon(TablerIconType.ActivityHeartbeat)
            .Size(48)
            .FillColor(RGBColor.Pink)
            .StrokeColor(RGBColor.Red)
            .StrokeWidth(3)
            .AddStyle("filter", "drop-shadow(2px 2px 4px rgba(0,0,0,0.3))");
        HelpersSpectre.Success("Custom Heart: " + heartIcon);

        // Custom SVG icon
        var customIcon = new TablerIcon(@"<path d=""M12 2L2 7v10c0 5.55 3.84 9.74 9 11 5.16-1.26 9-5.45 9-11V7l-10-5z""/>")
            .StrokeColor(RGBColor.Green)
            .Size(32);
        HelpersSpectre.Success("Custom Shield: " + customIcon);

        HelpersSpectre.Success("\n=== Benefits over TablerIcon ===");
        HelpersSpectre.Success("✓ No external CSS dependencies");
        HelpersSpectre.Success("✓ Full positioning control");
        HelpersSpectre.Success("✓ Transform support (rotate, scale)");
        HelpersSpectre.Success("✓ Custom styling capabilities");
        HelpersSpectre.Success("✓ Inline SVG with crisp rendering");
        HelpersSpectre.Success("✓ Custom SVG content support");
        HelpersSpectre.Success($"✓ {TablerIconLibrary.GetAvailableIconCount()} icons available");
    }
}
