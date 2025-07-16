using System;
using System.IO;

namespace HtmlForgeX.Examples.Experimenting;

internal static class ExampleImageUtilities {
    public static void Demonstrate() {
        var path = Path.Combine("..", "..", "..", "Assets", "Images", "WhiteBackground", "Logo-evotec.png");
        if (!File.Exists(path)) {
            Console.WriteLine($"Example image not found: {path}");
            return;
        }

        var (bytes, mime) = ImageUtilities.LoadImageFromFile(path);
        Console.WriteLine($"Loaded {bytes.Length} bytes as {mime}");
    }
}