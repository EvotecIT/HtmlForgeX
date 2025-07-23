using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace HtmlForgeX;

/// <summary>
/// Shared utility for image embedding functionality
/// Used by both EmailImage and TablerCardImage to avoid code duplication
/// </summary>
public static class ImageEmbedding {

    /// <summary>
    /// Embeds an image from a file path as base64
    /// </summary>
    /// <param name="filePath">Path to the image file</param>
    /// <param name="maxFileSize">Maximum file size allowed for embedding (0 = no limit)</param>
    /// <param name="logWarnings">Whether to log warnings to console</param>
    /// <param name="optimize">Whether to optimize the image before encoding</param>
    /// <param name="maxWidth">Maximum width used when optimizing</param>
    /// <param name="maxHeight">Maximum height used when optimizing</param>
    /// <param name="quality">JPEG quality used for optimization</param>
    /// <returns>ImageEmbeddingResult containing the embedding data or error info</returns>
    public static ImageEmbeddingResult EmbedFromFile(
        string filePath,
        long maxFileSize = 0,
        bool logWarnings = false,
        bool optimize = false,
        int maxWidth = 0,
        int maxHeight = 0,
        int quality = 85) {
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

            var (bytes, mimeType) = ImageUtilities.LoadImageFromFile(filePath, optimize, maxWidth, maxHeight, quality);
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
    /// <param name="optimize">Whether to optimize the image before encoding</param>
    /// <param name="maxWidth">Maximum width used when optimizing</param>
    /// <param name="maxHeight">Maximum height used when optimizing</param>
    /// <param name="quality">JPEG quality used for optimization</param>
    /// <returns>ImageEmbeddingResult containing the embedding data or error info</returns>
    public static ImageEmbeddingResult EmbedFromUrl(
        string url,
        int timeoutSeconds = 30,
        long maxFileSize = 0,
        bool logWarnings = false,
        bool optimize = false,
        int maxWidth = 0,
        int maxHeight = 0,
        int quality = 85) =>
        EmbedFromUrlAsync(url, timeoutSeconds, maxFileSize, logWarnings, optimize, maxWidth, maxHeight, quality).GetAwaiter().GetResult();

    /// <summary>
    /// Asynchronously embeds an image from a URL as base64
    /// </summary>
    /// <param name="url">URL to download and embed</param>
    /// <param name="timeoutSeconds">Timeout for the download</param>
    /// <param name="maxFileSize">Maximum file size allowed for embedding (0 = no limit)</param>
    /// <param name="logWarnings">Whether to log warnings to console</param>
    /// <param name="optimize">Whether to optimize the image before encoding</param>
    /// <param name="maxWidth">Maximum width used when optimizing</param>
    /// <param name="maxHeight">Maximum height used when optimizing</param>
    /// <param name="quality">JPEG quality used for optimization</param>
    /// <returns>ImageEmbeddingResult containing the embedding data or error info</returns>
    public static async Task<ImageEmbeddingResult> EmbedFromUrlAsync(
        string url,
        int timeoutSeconds = 30,
        long maxFileSize = 0,
        bool logWarnings = false,
        bool optimize = false,
        int maxWidth = 0,
        int maxHeight = 0,
        int quality = 85) {
        try {
            var download = await ImageUtilities.DownloadImageAsync(url, timeoutSeconds).ConfigureAwait(false);
            if (download is null) {
                return ImageEmbeddingResult.CreateFailure("HTTP error while downloading " + url);
            }
            var (bytes, mimeType) = download.Value;

            // Check file size if limit is specified
            if (maxFileSize > 0 && bytes.Length > maxFileSize) {
                var message = "URL " + url + " content (" + bytes.Length + " bytes) exceeds maximum embed size (" + maxFileSize + " bytes)";
                if (logWarnings) {
                    Console.WriteLine("Warning: " + message + ". Using direct URL.");
                }
                return ImageEmbeddingResult.CreateFailure(message);
            }

            if (optimize) {
                var extension = ImageUtilities.GetExtensionFromMimeType(mimeType);
                bytes = ImageUtilities.OptimizeImageBytes(bytes, extension, maxWidth, maxHeight, quality);
            }

            // 'mimeType' already determined by DownloadImage
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
    /// <param name="optimize">Whether to optimize the image before encoding</param>
    /// <param name="maxWidth">Maximum width used when optimizing</param>
    /// <param name="maxHeight">Maximum height used when optimizing</param>
    /// <param name="quality">JPEG quality used for optimization</param>
    /// <returns>ImageEmbeddingResult containing the embedding data or error info</returns>
    public static ImageEmbeddingResult EmbedSmart(
        string source,
        int timeoutSeconds = 30,
        long maxFileSize = 0,
        bool logWarnings = false,
        bool optimize = false,
        int maxWidth = 0,
        int maxHeight = 0,
        int quality = 85) {
        if (string.IsNullOrEmpty(source)) {
            return ImageEmbeddingResult.CreateFailure("Source is null or empty");
        }

        // Check if it's a URL
        if (Uri.TryCreate(source, UriKind.Absolute, out Uri? uri) &&
           (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)) {
            return EmbedFromUrl(source, timeoutSeconds, maxFileSize, logWarnings, optimize, maxWidth, maxHeight, quality);
        }

        // Check if it's a file path
        if (File.Exists(source)) {
            return EmbedFromFile(source, maxFileSize, logWarnings, optimize, maxWidth, maxHeight, quality);
        }

        return ImageEmbeddingResult.CreateFailure("Source is neither a valid URL nor an existing file: " + source);
    }

    /// <summary>
    /// Gets MIME type from file extension
    /// </summary>
    /// <param name="extension">File extension (with or without dot)</param>
    /// <returns>MIME type string</returns>
public static string GetMimeTypeFromExtension(string extension) =>
    ImageUtilities.GetMimeTypeFromExtension(extension);

    /// <summary>
    /// Gets MIME type from URL by examining the file extension
    /// </summary>
    /// <param name="url">URL to examine</param>
    /// <returns>MIME type string</returns>
public static string GetMimeTypeFromUrl(string url) =>
    ImageUtilities.GetMimeTypeFromUrl(url);
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