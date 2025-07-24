using System;
using System.IO;
using System.Threading.Tasks;
namespace HtmlForgeX;

public partial class EmailImage {
    #region Image Embedding

    /// <summary>
    /// Embeds an image from a local file.
    /// </summary>
    /// <param name="filePath">Path to the image file.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
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
    /// Downloads and embeds an image from a URL synchronously.
    /// </summary>
    /// <param name="url">Image URL.</param>
    /// <param name="timeoutSeconds">Timeout in seconds.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage EmbedFromUrl(string url, int timeoutSeconds = 30) =>
        EmbedFromUrlAsync(url, timeoutSeconds).GetAwaiter().GetResult();

    /// <summary>
    /// Downloads and embeds an image from a URL asynchronously.
    /// </summary>
    /// <param name="url">Image URL.</param>
    /// <param name="timeoutSeconds">Timeout in seconds.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
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
    /// Automatically selects the best embedding method for a source.
    /// </summary>
    /// <param name="source">File path or URL.</param>
    /// <param name="timeoutSeconds">Timeout in seconds.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
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
    /// Embeds an image using base64 data.
    /// </summary>
    /// <param name="base64Data">Base64 encoded image.</param>
    /// <param name="mimeType">Image MIME type.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public EmailImage EmbedFromBase64(string base64Data, string mimeType) {
        Base64Data = base64Data;
        MimeType = mimeType;
        EmbedAsBase64 = true;
        Source = $"data:{MimeType};base64,{Base64Data}";
        return this;
    }

    /// <summary>
    /// Embeds an alternative image for dark mode.
    /// </summary>
    /// <param name="source">Source file or URL.</param>
    /// <param name="timeoutSeconds">Timeout in seconds.</param>
    /// <param name="useSmartDetection">Use smart detection to choose source type.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
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