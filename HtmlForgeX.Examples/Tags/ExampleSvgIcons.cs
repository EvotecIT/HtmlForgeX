using System;

namespace HtmlForgeX.Examples.Tags;

internal class ExampleSvgIcons {
    public static void Create() {
        Console.WriteLine("=== SVG Icons Demo ===");

        // Basic icon usage
        var alertIcon = TablerIconLibrary.GetIcon(TablerIconType.AlertCircle).StrokeColor(RGBColor.Red).Size(24);
        Console.WriteLine("Alert Icon: " + alertIcon);

        // Styled icon with positioning
        var successIcon = TablerIconLibrary.GetIcon(TablerIconType.AdjustmentsCheck)
            .StrokeColor(RGBColor.Green)
            .Size(32)
            .Margin("10px")
            .VerticalAlign("middle");
        Console.WriteLine("Success Icon: " + successIcon);

        // Transformed icon
        var rotatedArrow = TablerIconLibrary.GetIcon(TablerIconType.ArrowRight)
            .Size(24)
            .Rotate(45)
            .StrokeColor(RGBColor.Blue);
        Console.WriteLine("Rotated Arrow: " + rotatedArrow);

        // Custom styled icon
        var heartIcon = TablerIconLibrary.GetIcon(TablerIconType.ActivityHeartbeat)
            .Size(48)
            .FillColor(RGBColor.Pink)
            .StrokeColor(RGBColor.Red)
            .StrokeWidth(3)
            .AddStyle("filter", "drop-shadow(2px 2px 4px rgba(0,0,0,0.3))");
        Console.WriteLine("Custom Heart: " + heartIcon);

        // Custom SVG icon
        var customIcon = new TablerIcon(@"<path d=""M12 2L2 7v10c0 5.55 3.84 9.74 9 11 5.16-1.26 9-5.45 9-11V7l-10-5z""/>")
            .StrokeColor(RGBColor.Green)
            .Size(32);
        Console.WriteLine("Custom Shield: " + customIcon);

        Console.WriteLine("\n=== Benefits over TablerIcon ===");
        Console.WriteLine("✓ No external CSS dependencies");
        Console.WriteLine("✓ Full positioning control");
        Console.WriteLine("✓ Transform support (rotate, scale)");
        Console.WriteLine("✓ Custom styling capabilities");
        Console.WriteLine("✓ Inline SVG with crisp rendering");
        Console.WriteLine("✓ Custom SVG content support");
        Console.WriteLine($"✓ {TablerIconLibrary.GetAvailableIconCount()} icons available");
    }
}
