namespace HtmlForgeX.Resources;

/// <summary>
/// Utility methods for embedding custom fonts.
/// </summary>
public static class FontLoader {
    /// <summary>
    /// Loads a font file and returns a <see cref="Style"/> object representing a CSS <c>@font-face</c> rule with the font embedded as Base64.
    /// </summary>
    /// <param name="fontFamily">Font family name.</param>
    /// <param name="fontFilePath">Path to the font file.</param>
    /// <returns>A <see cref="Style"/> containing the <c>@font-face</c> rule.</returns>
    /// <exception cref="FileNotFoundException">Thrown when <paramref name="fontFilePath"/> does not exist.</exception>
    public static Style LoadFontAsStyle(string fontFamily, string fontFilePath) {
        if (!File.Exists(fontFilePath)) {
            throw new FileNotFoundException($"Font file not found: {fontFilePath}", fontFilePath);
        }

        var extension = Path.GetExtension(fontFilePath).ToLowerInvariant();
        var mime = extension switch {
            ".woff2" => "font/woff2",
            ".woff" => "font/woff",
            ".ttf" => "font/ttf",
            ".otf" => "font/otf",
            _ => "application/octet-stream"
        };
        var format = extension switch {
            ".woff2" => "woff2",
            ".woff" => "woff",
            ".ttf" => "truetype",
            ".otf" => "opentype",
            _ => "truetype"
        };

        using var fileStream = File.OpenRead(fontFilePath);
        using var memoryStream = new MemoryStream();
        fileStream.CopyTo(memoryStream);
        var fontData = Convert.ToBase64String(memoryStream.ToArray());
        var escapedFontFamily = fontFamily.Replace("\"", "\\\"");
        var properties = new Dictionary<string, string> {
            { "font-family", $"\"{escapedFontFamily}\"" },
            { "src", $"url(data:{mime};base64,{fontData}) format('{format}')" }
        };
        return new Style("@font-face", properties);
    }

    /// <summary>
    /// Loads a font from a stream and returns a style representing the <c>@font-face</c> rule.
    /// </summary>
    /// <param name="fontFamily">Font family name.</param>
    /// <param name="fontStream">Stream containing the font data.</param>
    /// <param name="extension">File extension used to determine MIME type.</param>
    /// <returns>A <see cref="Style"/> containing the <c>@font-face</c> rule.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="fontStream"/> is null.</exception>
    public static Style LoadFontAsStyle(string fontFamily, Stream fontStream, string extension) {
        if (fontStream is null) {
            throw new ArgumentNullException(nameof(fontStream));
        }

        extension = extension.StartsWith(".") ? extension.ToLowerInvariant() : $".{extension.ToLowerInvariant()}";
        var mime = extension switch {
            ".woff2" => "font/woff2",
            ".woff" => "font/woff",
            ".ttf" => "font/ttf",
            ".otf" => "font/otf",
            _ => "application/octet-stream"
        };
        var format = extension switch {
            ".woff2" => "woff2",
            ".woff" => "woff",
            ".ttf" => "truetype",
            ".otf" => "opentype",
            _ => "truetype"
        };

        fontStream.Position = 0;
        using var memoryStream = new MemoryStream();
        fontStream.CopyTo(memoryStream);
        var fontData = Convert.ToBase64String(memoryStream.ToArray());
        var escapedFontFamily = fontFamily.Replace("\"", "\\\"");
        var properties = new Dictionary<string, string> {
            { "font-family", $"\"{escapedFontFamily}\"" },
            { "src", $"url(data:{mime};base64,{fontData}) format('{format}')" }
        };
        return new Style("@font-face", properties);
    }
}