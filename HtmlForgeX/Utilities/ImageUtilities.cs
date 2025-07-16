using System;
using System.IO;
using System.Net.Http;
using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// Common image helper utilities for loading and basic metadata detection.
/// </summary>
internal static class ImageUtilities {
    private static readonly Dictionary<string, string> ExtensionToMime = new(StringComparer.OrdinalIgnoreCase) {
        [".jpg"] = "image/jpeg",
        [".jpeg"] = "image/jpeg",
        [".png"] = "image/png",
        [".gif"] = "image/gif",
        [".svg"] = "image/svg+xml",
        [".webp"] = "image/webp",
        [".bmp"] = "image/bmp",
        [".tiff"] = "image/tiff",
        [".tif"] = "image/tiff",
        [".ico"] = "image/x-icon",
    };

    private static readonly Dictionary<string, string> MimeToExtension;

    static ImageUtilities() {
        MimeToExtension = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        foreach (var kv in ExtensionToMime) {
            if (!MimeToExtension.ContainsKey(kv.Value)) {
                MimeToExtension[kv.Value] = kv.Key;
            }
        }
        MimeToExtension["image/jpg"] = ".jpg";
    }
    /// <summary>
    /// Loads image bytes from disk without locking the file.
    /// </summary>
    public static byte[] LoadImageBytes(string filePath) {
        using var fileStream = File.OpenRead(filePath);
        using var memoryStream = new MemoryStream();
        fileStream.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }

    /// <summary>
    /// Loads image bytes from disk and optionally optimizes them.
    /// </summary>
    /// <param name="filePath">Path to the image file.</param>
    /// <param name="optimize">Whether to optimize the loaded bytes.</param>
    /// <param name="maxWidth">Maximum width for optimization.</param>
    /// <param name="maxHeight">Maximum height for optimization.</param>
    /// <param name="quality">JPEG quality used for optimization.</param>
    /// <returns>Tuple containing bytes and detected MIME type.</returns>
    public static (byte[] Bytes, string MimeType) LoadImageFromFile(
        string filePath,
        bool optimize = false,
        int maxWidth = 0,
        int maxHeight = 0,
        int quality = 85) {
        var bytes = LoadImageBytes(filePath);
        var extension = Path.GetExtension(filePath).ToLowerInvariant();
        var mimeType = GetMimeTypeFromExtension(extension);

        if (optimize) {
            bytes = OptimizeImageBytes(bytes, extension, maxWidth, maxHeight, quality);
        }

        return (bytes, mimeType);
    }

    /// <summary>
    /// Downloads image bytes from a URL.
    /// </summary>
    public static (byte[] Bytes, string MimeType)? DownloadImage(string url, int timeoutSeconds) {
        using var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(timeoutSeconds) };
        using var response = httpClient.GetAsync(url).Result;
        if (!response.IsSuccessStatusCode) {
            return null;
        }

        var bytes = response.Content.ReadAsByteArrayAsync().Result;
        var contentType = response.Content.Headers.ContentType?.MediaType ?? string.Empty;
        var mimeType = !string.IsNullOrEmpty(contentType) ? contentType : GetMimeTypeFromUrl(url);
        return (bytes, mimeType);
    }

    /// <summary>
    /// Determines MIME type from file extension.
    /// </summary>
    public static string GetMimeTypeFromExtension(string extension) {
        if (string.IsNullOrEmpty(extension)) {
            return "image/png";
        }

        var ext = extension.StartsWith(".") ? extension : "." + extension;
        return ExtensionToMime.TryGetValue(ext, out var mime) ? mime : "image/png";
    }

    /// <summary>
    /// Determines MIME type based on URL extension.
    /// </summary>
    public static string GetMimeTypeFromUrl(string url) {
        try {
            var uri = new Uri(url);
            var extension = Path.GetExtension(uri.LocalPath);
            return GetMimeTypeFromExtension(extension);
        } catch {
            return "image/png";
        }
    }

    /// <summary>
    /// Returns common file extension for a MIME type.
    /// </summary>
    public static string GetExtensionFromMimeType(string mimeType) {
        if (string.IsNullOrEmpty(mimeType)) {
            return ".png";
        }

        return MimeToExtension.TryGetValue(mimeType, out var ext) ? ext : ".png";
    }

    /// <summary>
    /// Placeholder for future image optimization/resizing.
    /// </summary>
    public static byte[] OptimizeImageBytes(byte[] bytes, string extension, int maxWidth, int maxHeight, int quality) {
        // Image optimization is not implemented yet.
        return bytes;
    }
}