using System;
using System.IO;
using System.Threading.Tasks;
namespace HtmlForgeX;

public partial class EmailImage {
    #region Image Embedding

    /// <summary>
    /// Embeds an image from a file path as base64
    /// </summary>
    /// <param name="filePath">The path to the image file</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage EmbedFromFile(string filePath) {
        var maxSize = Email?.Configuration?.Email?.MaxEmbedFileSize ?? 2 * 1024 * 1024;
        var logWarnings = Email?.Configuration?.Email?.LogEmbeddingWarnings == true;

        var result = ImageEmbedding.EmbedFromFile(filePath, maxSize, logWarnings, OptimizeImage, MaxWidth, MaxHeight, Quality);
        if (result.Success) {
            MimeType = result.MimeType;
            Base64Data = result.Base64Data;
            EmbedAsBase64 = true;
            Source = $"data:{MimeType};base64,{Base64Data}";
        } else {
            Source = filePath;
            if (logWarnings && Email is not null) {
                Email.Configuration.Errors.Add($"Warning: {result.ErrorMessage}");
                Email.IncrementEmbeddingWarning();
            }
        }

        return this;
    }

    /// <summary>
    /// Embeds an image from a URL as base64 (synchronous)
    /// </summary>
    /// <param name="url">The URL of the image</param>
    /// <param name="timeoutSeconds">Timeout in seconds for downloading</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage EmbedFromUrl(string url, int timeoutSeconds = 30) =>
        EmbedFromUrlAsync(url, timeoutSeconds).GetAwaiter().GetResult();

    /// <summary>
    /// Embeds an image from a URL as base64 (asynchronous)
    /// </summary>
    /// <param name="url">The URL of the image</param>
    /// <param name="timeoutSeconds">Timeout in seconds for downloading</param>
    /// <returns>A task that represents the asynchronous operation</returns>
    public async Task<EmailImage> EmbedFromUrlAsync(string url, int timeoutSeconds = 30) {
        var maxSize = Email?.Configuration?.Email?.MaxEmbedFileSize ?? 2 * 1024 * 1024;
        var logWarnings = Email?.Configuration?.Email?.LogEmbeddingWarnings == true;

        var result = await ImageEmbedding.EmbedFromUrlAsync(url, timeoutSeconds, maxSize, logWarnings, OptimizeImage, MaxWidth, MaxHeight, Quality).ConfigureAwait(false);

        if (result.Success) {
            MimeType = result.MimeType;
            Base64Data = result.Base64Data;
            EmbedAsBase64 = true;
            Source = $"data:{MimeType};base64,{Base64Data}";
        } else {
            Source = url;
            if (logWarnings && Email is not null) {
                Email.Configuration.Errors.Add($"Warning: {result.ErrorMessage}");
                Email.IncrementEmbeddingWarning();
            }
        }

        return this;
    }

    /// <summary>
    /// Automatically detects whether source is a file path or URL and embeds accordingly
    /// </summary>
    /// <param name="source">The image source (file path or URL)</param>
    /// <param name="timeoutSeconds">Timeout in seconds for URL downloads</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage EmbedSmart(string source, int timeoutSeconds = 30) {
        if (string.IsNullOrEmpty(source)) {
            return this;
        }

        var maxSize = Email?.Configuration?.Email?.MaxEmbedFileSize ?? 2 * 1024 * 1024;
        var logWarnings = Email?.Configuration?.Email?.LogEmbeddingWarnings == true;

        var result = ImageEmbedding.EmbedSmart(source, timeoutSeconds, maxSize, logWarnings, OptimizeImage, MaxWidth, MaxHeight, Quality);

        if (result.Success) {
            MimeType = result.MimeType;
            Base64Data = result.Base64Data;
            EmbedAsBase64 = true;
            Source = $"data:{MimeType};base64,{Base64Data}";
        } else {
            Source = source;
            if (logWarnings && Email is not null) {
                Email.Configuration.Errors.Add($"Warning: {result.ErrorMessage}");
                Email.IncrementEmbeddingWarning();
            }
        }

        return this;
    }

    /// <summary>
    /// Embeds an image from existing base64 data
    /// </summary>
    /// <param name="base64Data">The base64 encoded image data</param>
    /// <param name="mimeType">The MIME type of the image</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage EmbedFromBase64(string base64Data, string mimeType) {
        Base64Data = base64Data;
        MimeType = mimeType;
        EmbedAsBase64 = true;
        Source = $"data:{MimeType};base64,{Base64Data}";
        return this;
    }

    /// <summary>
    /// Embeds a dark mode variant of the image
    /// </summary>
    /// <param name="source">The dark mode image source</param>
    /// <param name="timeoutSeconds">Timeout in seconds for URL downloads</param>
    /// <param name="useSmartDetection">Whether to use smart detection for source type</param>
    /// <returns>The EmailImage instance for method chaining</returns>
    public EmailImage EmbedDarkModeImage(string source, int timeoutSeconds = 30, bool useSmartDetection = true) {
        if (string.IsNullOrEmpty(source)) {
            return this;
        }

        var maxSize = Email?.Configuration?.Email?.MaxEmbedFileSize ?? 2 * 1024 * 1024;
        var logWarnings = Email?.Configuration?.Email?.LogEmbeddingWarnings == true;

        ImageEmbeddingResult result;
        if (useSmartDetection) {
            result = ImageEmbedding.EmbedSmart(source, timeoutSeconds, maxSize, logWarnings, OptimizeImage, MaxWidth, MaxHeight, Quality);
        } else if (Uri.TryCreate(source, UriKind.Absolute, out var uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)) {
            result = ImageEmbedding.EmbedFromUrl(source, timeoutSeconds, maxSize, logWarnings, OptimizeImage, MaxWidth, MaxHeight, Quality);
        } else {
            result = ImageEmbedding.EmbedFromFile(source, maxSize, logWarnings, OptimizeImage, MaxWidth, MaxHeight, Quality);
        }

        if (result.Success) {
            DarkModeBase64Data = result.Base64Data;
            DarkModeMimeType = result.MimeType;
            DarkModeEmbedAsBase64 = true;
            DarkModeSource = $"data:{result.MimeType};base64,{result.Base64Data}";
        } else if (logWarnings && Email is not null) {
            Email.Configuration.Errors.Add($"Warning: {result.ErrorMessage}");
            Email.IncrementEmbeddingWarning();
        }

        return this;
    }

    private static string GetMimeTypeFromExtension(string extension) =>
        ImageUtilities.GetMimeTypeFromExtension(extension);

    private static string GetMimeTypeFromUrl(string url) =>
        ImageUtilities.GetMimeTypeFromUrl(url);

    private static string GetExtensionFromMimeType(string mimeType) =>
        ImageUtilities.GetExtensionFromMimeType(mimeType);

    private byte[] OptimizeImageBytes(byte[] bytes, string extension) =>
        ImageUtilities.OptimizeImageBytes(bytes, extension, MaxWidth, MaxHeight, Quality);

    #endregion
}