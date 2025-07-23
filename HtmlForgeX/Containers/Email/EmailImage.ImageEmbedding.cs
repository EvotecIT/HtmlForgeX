using System;
using System.IO;
using System.Threading.Tasks;
namespace HtmlForgeX;

public partial class EmailImage
{
    #region Image Embedding

    public EmailImage EmbedFromFile(string filePath)
    {
        try
        {
            if (System.IO.File.Exists(filePath))
            {
                var fileInfo = new System.IO.FileInfo(filePath);
                var maxSize = Email?.Configuration?.Email?.MaxEmbedFileSize ?? 2 * 1024 * 1024;
                if (fileInfo.Length > maxSize)
                {
                    if (Email?.Configuration?.Email?.LogEmbeddingWarnings == true && Email is not null)
                    {
                        Email.Configuration.Errors.Add("Warning: File size exceeds maximum embed size.");
                        Email.IncrementEmbeddingWarning();
                    }
                    Source = filePath;
                    return this;
                }

                var result = ImageUtilities.LoadImageFromFile(filePath, OptimizeImage, MaxWidth, MaxHeight, Quality);
                var bytes = result.Bytes;
                MimeType = result.MimeType;
                Base64Data = Convert.ToBase64String(bytes);
                EmbedAsBase64 = true;
                Source = $"data:{MimeType};base64,{Base64Data}";
            }
            else
            {
                Source = filePath;
            }
        }
        catch (Exception)
        {
            Source = filePath;
            if (Email?.Configuration?.Email?.LogEmbeddingWarnings == true && Email is not null)
            {
                Email.Configuration.Errors.Add("Warning: Failed to embed image.");
                Email.IncrementEmbeddingWarning();
            }
        }
        return this;
    }

    public EmailImage EmbedFromUrl(string url, int timeoutSeconds = 30) =>
        EmbedFromUrlAsync(url, timeoutSeconds).GetAwaiter().GetResult();

    public async Task<EmailImage> EmbedFromUrlAsync(string url, int timeoutSeconds = 30)
    {
        try
        {
            var download = await ImageUtilities.DownloadImageAsync(url, timeoutSeconds).ConfigureAwait(false);
            if (download is not null)
            {
                var (bytes, mimeType) = download.Value;
                var maxSize = Email?.Configuration?.Email?.MaxEmbedFileSize ?? 2 * 1024 * 1024;
                if (bytes.Length > maxSize)
                {
                    if (Email?.Configuration?.Email?.LogEmbeddingWarnings == true && Email is not null)
                    {
                        Email.Configuration.Errors.Add("Warning: URL content exceeds maximum embed size.");
                        Email.IncrementEmbeddingWarning();
                    }
                    Source = url;
                    return this;
                }

                MimeType = mimeType;
                if (OptimizeImage)
                {
                    var extension = ImageUtilities.GetExtensionFromMimeType(MimeType);
                    bytes = ImageUtilities.OptimizeImageBytes(bytes, extension, MaxWidth, MaxHeight, Quality);
                }

                Base64Data = Convert.ToBase64String(bytes);
                EmbedAsBase64 = true;
                Source = $"data:{MimeType};base64,{Base64Data}";
            }
            else
            {
                throw new Exception("Download failed");
            }
        }
        catch (Exception)
        {
            Source = url;
            if (Email?.Configuration?.Email?.LogEmbeddingWarnings == true && Email is not null)
            {
                Email.Configuration.Errors.Add("Warning: Failed to embed image from URL.");
                Email.IncrementEmbeddingWarning();
            }
        }
        return this;
    }

    public EmailImage EmbedSmart(string source, int timeoutSeconds = 30)
    {
        if (string.IsNullOrEmpty(source))
        {
            return this;
        }

        if (Uri.TryCreate(source, UriKind.Absolute, out var uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
        {
            return EmbedFromUrl(source, timeoutSeconds);
        }

        if (System.IO.File.Exists(source))
        {
            return EmbedFromFile(source);
        }

        Source = source;
        if (Email?.Configuration?.Email?.LogEmbeddingWarnings == true && Email is not null)
        {
            Email.Configuration.Errors.Add("Warning: Could not embed source - using direct source.");
            Email.IncrementEmbeddingWarning();
        }
        return this;
    }

    public EmailImage EmbedFromBase64(string base64Data, string mimeType)
    {
        Base64Data = base64Data;
        MimeType = mimeType;
        EmbedAsBase64 = true;
        Source = $"data:{MimeType};base64,{Base64Data}";
        return this;
    }

    public EmailImage EmbedDarkModeImage(string source, int timeoutSeconds = 30, bool useSmartDetection = true)
    {
        if (string.IsNullOrEmpty(source))
        {
            return this;
        }

        try
        {
            byte[] bytes;
            string mimeType;

            if (useSmartDetection)
            {
                if (Uri.TryCreate(source, UriKind.Absolute, out var uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps))
                {
                    var download = ImageUtilities.DownloadImage(source, timeoutSeconds);
                    if (download is null)
                    {
                        throw new Exception("Download failed");
                    }
                    (bytes, mimeType) = download.Value;
                }
                else if (System.IO.File.Exists(source))
                {
                    (bytes, mimeType) = ImageUtilities.LoadImageFromFile(source, OptimizeImage, MaxWidth, MaxHeight, Quality);
                }
                else
                {
                    throw new Exception("Source is neither a valid URL nor an existing file");
                }
            }
            else
            {
                (bytes, mimeType) = ImageUtilities.LoadImageFromFile(source, OptimizeImage, MaxWidth, MaxHeight, Quality);
            }

            var maxSize = Email?.Configuration?.Email?.MaxEmbedFileSize ?? 2 * 1024 * 1024;
            if (bytes.Length > maxSize)
            {
                if (Email?.Configuration?.Email?.LogEmbeddingWarnings == true && Email is not null)
                {
                    Email.Configuration.Errors.Add("Warning: Dark mode image exceeds maximum embed size.");
                    Email.IncrementEmbeddingWarning();
                }
                return this;
            }

            DarkModeBase64Data = Convert.ToBase64String(bytes);
            DarkModeMimeType = mimeType;
            DarkModeEmbedAsBase64 = true;
            DarkModeSource = $"data:{mimeType};base64,{DarkModeBase64Data}";
        }
        catch (Exception)
        {
            if (Email?.Configuration?.Email?.LogEmbeddingWarnings == true && Email is not null)
            {
                Email.Configuration.Errors.Add("Warning: Failed to embed dark mode image.");
                Email.IncrementEmbeddingWarning();
            }
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
