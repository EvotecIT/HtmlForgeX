using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace HtmlForgeX;

/// <summary>
/// Shared utility for image embedding functionality
/// Used by both EmailImage and TablerCardImage to avoid code duplication
/// </summary>
public static class ImageEmbeddingHelper {

    /// <summary>
    /// Embeds an image from a file path as base64
    /// </summary>
    /// <param name="filePath">Path to the image file</param>
    /// <param name="maxFileSize">Maximum file size allowed for embedding (0 = no limit)</param>
    /// <param name="logWarnings">Whether to log warnings to console</param>
    /// <returns>ImageEmbeddingResult containing the embedding data or error info</returns>
    public static ImageEmbeddingResult EmbedFromFile(string filePath, long maxFileSize = 0, bool logWarnings = false) {
        try {
            if (!File.Exists(filePath)) {
                return ImageEmbeddingResult.CreateFailure("File not found: " + filePath);
            }

            var fileInfo = new FileInfo(filePath);

            // Check file size if limit is specified
            if (maxFileSize > 0 && fileInfo.Length > maxFileSize) {
                var message = "File " + filePath + " (" + fileInfo.Length + " bytes) exceeds maximum embed size (" + maxFileSize + " bytes)";
                if (logWarnings) {
                    Console.WriteLine("Warning: " + message + ". Using direct path.");
                }
                return ImageEmbeddingResult.CreateFailure(message);
            }

            var bytes = File.ReadAllBytes(filePath);
            var extension = Path.GetExtension(filePath).ToLowerInvariant();
            var mimeType = GetMimeTypeFromExtension(extension);
            var base64Data = Convert.ToBase64String(bytes);

            return ImageEmbeddingResult.CreateSuccess(base64Data, mimeType);
        } catch (Exception ex) {
            var message = "Failed to embed image " + filePath + ": " + ex.Message;
            if (logWarnings) {
                Console.WriteLine("Warning: " + message);
            }
            return ImageEmbeddingResult.CreateFailure(message);
        }
    }

    /// <summary>
    /// Embeds an image from a URL as base64
    /// </summary>
    /// <param name="url">URL to download and embed</param>
    /// <param name="timeoutSeconds">Timeout for the download</param>
    /// <param name="maxFileSize">Maximum file size allowed for embedding (0 = no limit)</param>
    /// <param name="logWarnings">Whether to log warnings to console</param>
    /// <returns>ImageEmbeddingResult containing the embedding data or error info</returns>
    public static ImageEmbeddingResult EmbedFromUrl(string url, int timeoutSeconds = 30, long maxFileSize = 0, bool logWarnings = false) {
        try {
            using var httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromSeconds(timeoutSeconds);

            var response = httpClient.GetAsync(url).Result;
            if (!response.IsSuccessStatusCode) {
                return ImageEmbeddingResult.CreateFailure("HTTP " + response.StatusCode + ": " + response.ReasonPhrase);
            }

            var bytes = response.Content.ReadAsByteArrayAsync().Result;

            // Check file size if limit is specified
            if (maxFileSize > 0 && bytes.Length > maxFileSize) {
                var message = "URL " + url + " content (" + bytes.Length + " bytes) exceeds maximum embed size (" + maxFileSize + " bytes)";
                if (logWarnings) {
                    Console.WriteLine("Warning: " + message + ". Using direct URL.");
                }
                return ImageEmbeddingResult.CreateFailure(message);
            }

            var contentType = response.Content.Headers.ContentType?.MediaType ?? "";
            var mimeType = !string.IsNullOrEmpty(contentType) ? contentType : GetMimeTypeFromUrl(url);
            var base64Data = Convert.ToBase64String(bytes);

            return ImageEmbeddingResult.CreateSuccess(base64Data, mimeType);
        } catch (Exception ex) {
            var message = "Failed to embed image from URL " + url + ": " + ex.Message;
            if (logWarnings) {
                Console.WriteLine("Warning: " + message);
            }
            return ImageEmbeddingResult.CreateFailure(message);
        }
    }

    /// <summary>
    /// Smart embedding - auto-detects whether source is a file path or URL
    /// </summary>
    /// <param name="source">File path or URL</param>
    /// <param name="timeoutSeconds">Timeout for URL downloads</param>
    /// <param name="maxFileSize">Maximum file size allowed for embedding (0 = no limit)</param>
    /// <param name="logWarnings">Whether to log warnings to console</param>
    /// <returns>ImageEmbeddingResult containing the embedding data or error info</returns>
    public static ImageEmbeddingResult EmbedSmart(string source, int timeoutSeconds = 30, long maxFileSize = 0, bool logWarnings = false) {
        if (string.IsNullOrEmpty(source)) {
            return ImageEmbeddingResult.CreateFailure("Source is null or empty");
        }

        // Check if it's a URL
        if (Uri.TryCreate(source, UriKind.Absolute, out Uri? uri) &&
           (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)) {
            return EmbedFromUrl(source, timeoutSeconds, maxFileSize, logWarnings);
        }

        // Check if it's a file path
        if (File.Exists(source)) {
            return EmbedFromFile(source, maxFileSize, logWarnings);
        }

        return ImageEmbeddingResult.CreateFailure("Source is neither a valid URL nor an existing file: " + source);
    }

    /// <summary>
    /// Gets MIME type from file extension
    /// </summary>
    /// <param name="extension">File extension (with or without dot)</param>
    /// <returns>MIME type string</returns>
    public static string GetMimeTypeFromExtension(string extension) {
        if (string.IsNullOrEmpty(extension)) {
            return "image/jpeg";
        }

        var ext = extension.StartsWith(".") ? extension : "." + extension;
        ext = ext.ToLowerInvariant();

        switch (ext) {
            case ".jpg":
            case ".jpeg":
                return "image/jpeg";
            case ".png":
                return "image/png";
            case ".gif":
                return "image/gif";
            case ".webp":
                return "image/webp";
            case ".svg":
                return "image/svg+xml";
            case ".bmp":
                return "image/bmp";
            case ".ico":
                return "image/x-icon";
            case ".tiff":
            case ".tif":
                return "image/tiff";
            default:
                return "image/jpeg";
        }
    }

    /// <summary>
    /// Gets MIME type from URL by examining the file extension
    /// </summary>
    /// <param name="url">URL to examine</param>
    /// <returns>MIME type string</returns>
    public static string GetMimeTypeFromUrl(string url) {
        try {
            var uri = new Uri(url);
            var extension = Path.GetExtension(uri.LocalPath);
            return GetMimeTypeFromExtension(extension);
        } catch {
            return "image/jpeg";
        }
    }
}

/// <summary>
/// Result of an image embedding operation providing metadata about the
/// generated base64 payload.
/// </summary>
public class ImageEmbeddingResult {
    /// <summary>Indicates whether the embedding succeeded.</summary>
    public bool Success { get; private set; }
    /// <summary>Base64 encoded image data.</summary>
    public string Base64Data { get; private set; } = string.Empty;
    /// <summary>Embedded image MIME type.</summary>
    public string MimeType { get; private set; } = string.Empty;
    /// <summary>Error message if the embedding failed.</summary>
    public string ErrorMessage { get; private set; } = string.Empty;

    private ImageEmbeddingResult() { }

    /// <summary>
    /// Creates a successful embedding result.
    /// </summary>
    /// <param name="base64Data">Encoded image data.</param>
    /// <param name="mimeType">MIME type of the image.</param>
    /// <returns>A successful <see cref="ImageEmbeddingResult"/> instance.</returns>
    public static ImageEmbeddingResult CreateSuccess(string base64Data, string mimeType) {
        return new ImageEmbeddingResult {
            Success = true,
            Base64Data = base64Data,
            MimeType = mimeType
        };
    }

    /// <summary>
    /// Creates a failed embedding result.
    /// </summary>
    /// <param name="errorMessage">Description of the failure.</param>
    /// <returns>A failed <see cref="ImageEmbeddingResult"/> instance.</returns>
    public static ImageEmbeddingResult CreateFailure(string errorMessage) {
        return new ImageEmbeddingResult {
            Success = false,
            ErrorMessage = errorMessage
        };
    }
}