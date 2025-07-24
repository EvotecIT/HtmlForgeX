using System;
using System.IO;

namespace HtmlForgeX.Examples.Experimenting;

internal static class ExampleImageUtilities {
    public static void Create() {
        var path = Path.Combine("..", "..", "..", "Assets", "Images", "WhiteBackground", "Logo-evotec.png");
        if (!File.Exists(path)) {
            HelpersSpectre.Success($"Example image not found: {path}");
            return;
        }

        var (bytes, mime) = ImageUtilities.LoadImageFromFile(path);
        HelpersSpectre.Success($"Loaded {bytes.Length} bytes as {mime}");
    }
}
