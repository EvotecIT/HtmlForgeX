namespace HtmlForgeX;

/// <summary>
/// Represents an image element for email layouts with email-safe styling and attributes.
/// Provides image display with customizable dimensions, alignment, and accessibility features.
/// Supports both local file and URL embedding as base64 for offline email compatibility.
/// Uses DocumentConfiguration for centralized settings management.
/// </summary>
public class EmailImage : Element {
    /// <summary>
    /// Gets or sets the image source URL.
    /// </summary>
    public string Source { get; set; } = "";

    /// <summary>
    /// Gets or sets the image width.
    /// </summary>
    public string Width { get; set; } = "";

    /// <summary>
    /// Gets or sets the image height.
    /// </summary>
    public string Height { get; set; } = "";

    /// <summary>
    /// Gets or sets the alternative text for accessibility.
    /// </summary>
    public string AlternativeText { get; set; } = "";

    /// <summary>
    /// Gets or sets the image alignment.
    /// </summary>
    public string Alignment { get; set; } = "left";

    /// <summary>
    /// Gets or sets the margin around the image.
    /// </summary>
    public string Margin { get; set; } = "0 0 16px 0";

    /// <summary>
    /// Gets or sets the padding around the image.
    /// </summary>
    public string Padding { get; set; } = "0";

    /// <summary>
    /// Gets or sets the border for the image.
    /// </summary>
    public string Border { get; set; } = "none";

    /// <summary>
    /// Gets or sets the border radius for the image.
    /// </summary>
    public string BorderRadius { get; set; } = "0";

    /// <summary>
    /// Gets or sets whether the image should be a link.
    /// </summary>
    public string LinkUrl { get; set; } = "";

    /// <summary>
    /// Gets or sets whether the image should open in a new window.
    /// </summary>
    public bool OpenInNewWindow { get; set; } = false;

    /// <summary>
    /// Gets or sets the CSS class for the image container.
    /// </summary>
    public string CssClass { get; set; } = "logo";

    /// <summary>
    /// Gets or sets whether the image should be embedded as base64.
    /// </summary>
    public bool EmbedAsBase64 { get; set; } = false;

    /// <summary>
    /// Gets or sets the base64 encoded image data.
    /// </summary>
    public string Base64Data { get; set; } = "";

    /// <summary>
    /// Gets or sets the image MIME type for embedded images.
    /// </summary>
    public string MimeType { get; set; } = "";

    /// <summary>
    /// Gets or sets the maximum width for image optimization (in pixels).
    /// </summary>
    public int MaxWidth { get; set; } = 0;

    /// <summary>
    /// Gets or sets the maximum height for image optimization (in pixels).
    /// </summary>
    public int MaxHeight { get; set; } = 0;

    /// <summary>
    /// Gets or sets the quality for JPEG compression (0-100).
    /// </summary>
    public int Quality { get; set; } = 85;

    /// <summary>
    /// Gets or sets whether to enable automatic image optimization.
    /// </summary>
    public bool OptimizeImage { get; set; } = false;

    /// <summary>
    /// Gets or sets whether to skip automatic embedding for this specific image.
    /// When true, ignores document configuration for auto-embedding.
    /// </summary>
    public bool SkipAutoEmbedding { get; set; } = false;

    /// <summary>
    /// Stores the original source path before any embedding occurs.
    /// </summary>
    private string _originalSource = "";

    /// <summary>
    /// Gets or sets whether to force embedding for this specific image.
    /// When true, overrides document configuration to force embedding.
    /// </summary>
    public bool ForceEmbedding { get; set; } = false;

    /// <summary>
    /// Gets or sets the dark mode image source URL.
    /// When provided, this image will be used in dark mode instead of the main source.
    /// </summary>
    public string DarkModeSource { get; set; } = "";

    /// <summary>
    /// Gets or sets the dark mode alternative text.
    /// If not provided, uses the main AlternativeText.
    /// </summary>
    public string DarkModeAlternativeText { get; set; } = "";

    /// <summary>
    /// Gets or sets whether dark mode image should be embedded as base64.
    /// Follows the same embedding rules as the main image.
    /// </summary>
    public bool DarkModeEmbedAsBase64 { get; set; } = false;

    /// <summary>
    /// Gets or sets the dark mode base64 encoded image data.
    /// </summary>
    public string DarkModeBase64Data { get; set; } = "";

    /// <summary>
    /// Gets or sets the dark mode image MIME type.
    /// </summary>
    public string DarkModeMimeType { get; set; } = "";

    /// <summary>
    /// Gets or sets whether to enable automatic dark mode image swapping.
    /// When true, uses CSS and media queries to switch between light and dark images.
    /// </summary>
    public bool EnableDarkModeSwapping { get; set; } = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailImage"/> class.
    /// </summary>
    public EmailImage() {
        // Configuration will be applied when the image is added to a document
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailImage"/> class with source.
    /// Automatically embeds the image if document configuration enables auto-embedding.
    /// </summary>
    /// <param name="source">The image source URL or file path.</param>
    public EmailImage(string source) : this() {
        Source = source;
        _originalSource = source; // Store original source
        // Auto-embedding will be applied when added to document
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailImage"/> class with source and dimensions.
    /// Automatically embeds the image if document configuration enables auto-embedding.
    /// </summary>
    /// <param name="source">The image source URL or file path.</param>
    /// <param name="width">The image width.</param>
    /// <param name="height">The image height.</param>
    public EmailImage(string source, string width, string height = "") : this() {
        Source = source;
        _originalSource = source; // Store original source
        Width = width;
        Height = height;
        // Auto-embedding will be applied when added to document
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailImage"/> class with source, dimensions, and embedding control.
    /// </summary>
    /// <param name="source">The image source URL or file path.</param>
    /// <param name="width">The image width.</param>
    /// <param name="height">The image height.</param>
    /// <param name="autoEmbed">Whether to automatically embed this image (overrides document configuration).</param>
    public EmailImage(string source, string width, string height, bool autoEmbed) : this() {
        Source = source;
        _originalSource = source; // Store original source
        Width = width;
        Height = height;

        if (autoEmbed) {
            ForceEmbedding = true;
        } else {
            SkipAutoEmbedding = true;
        }
    }

    /// <summary>
    /// Applies document configuration settings to this image.
    /// Called automatically when the image is added to a document.
    /// </summary>
    internal void ApplyDocumentConfiguration() {
        if (Email?.Configuration == null) return;

        var emailConfig = Email.Configuration.Email;
        var imageConfig = Email.Configuration.Images;

        // Apply auto-optimization settings
        if (imageConfig.AutoOptimize && !OptimizeImage) {
            WithOptimization(imageConfig.MaxWidth, imageConfig.MaxHeight, imageConfig.Quality);
        }

        // Apply auto-embedding if enabled and not overridden
        if (emailConfig.AutoEmbedImages && !SkipAutoEmbedding && !EmbedAsBase64 && !string.IsNullOrEmpty(Source)) {
            if (emailConfig.SmartImageDetection) {
                EmbedSmart(Source, emailConfig.EmbeddingTimeout);
            } else {
                EmbedFromFile(Source); // Assume file path if smart detection is disabled
            }
        } else if (ForceEmbedding && !EmbedAsBase64 && !string.IsNullOrEmpty(Source)) {
            // Force embedding even if document config doesn't enable it
            if (emailConfig.SmartImageDetection) {
                EmbedSmart(Source, emailConfig.EmbeddingTimeout);
            } else {
                EmbedFromFile(Source);
            }
        }

        // Apply dark mode image embedding with same rules
        if (!string.IsNullOrEmpty(DarkModeSource) && EnableDarkModeSwapping) {
            if (emailConfig.AutoEmbedImages && !SkipAutoEmbedding && !DarkModeEmbedAsBase64) {
                EmbedDarkModeImage(DarkModeSource, emailConfig.EmbeddingTimeout, emailConfig.SmartImageDetection);
            } else if (ForceEmbedding && !DarkModeEmbedAsBase64) {
                EmbedDarkModeImage(DarkModeSource, emailConfig.EmbeddingTimeout, emailConfig.SmartImageDetection);
            }
        }
    }

    /// <summary>
    /// Sets the image source URL and optionally embeds it.
    /// </summary>
    /// <param name="source">The image source URL or file path.</param>
    /// <param name="autoEmbed">Whether to automatically embed this image (overrides document configuration).</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithSource(string source, bool? autoEmbed = null) {
        Source = source;
        _originalSource = source; // Store original source

        if (autoEmbed == true) {
            ForceEmbedding = true;
            SkipAutoEmbedding = false;
        } else if (autoEmbed == false) {
            SkipAutoEmbedding = true;
            ForceEmbedding = false;
        }

        // Apply configuration if already attached to a document
        ApplyDocumentConfiguration();

        return this;
    }

    /// <summary>
    /// Sets the image source URL.
    /// </summary>
    /// <param name="source">The image source URL.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithSource(string source) {
        return WithSource(source, null);
    }

    /// <summary>
    /// Sets the image width.
    /// </summary>
    /// <param name="width">The image width.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithWidth(string width) {
        Width = width;
        return this;
    }

    /// <summary>
    /// Sets the image height.
    /// </summary>
    /// <param name="height">The image height.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithHeight(string height) {
        Height = height;
        return this;
    }

    /// <summary>
    /// Sets the alternative text for accessibility.
    /// </summary>
    /// <param name="altText">The alternative text.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithAlternativeText(string altText) {
        AlternativeText = altText;
        return this;
    }

    /// <summary>
    /// Sets the image alignment.
    /// </summary>
    /// <param name="alignment">The alignment option.</param>
    /// <returns>The <see cref="EmailImage"/> instance.</returns>
    public EmailImage WithAlignment(Alignment alignment) {
        alignment.ValidateEmailAlignment();
        Alignment = alignment.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets the margin around the image.
    /// </summary>
    /// <param name="margin">The margin value.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithMargin(string margin) {
        margin.ValidateMargin();
        Margin = margin;
        return this;
    }

    /// <summary>
    /// Sets the border for the image.
    /// </summary>
    /// <param name="border">The border value.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithBorder(string border) {
        Border = border;
        return this;
    }

    /// <summary>
    /// Sets the border radius for the image.
    /// </summary>
    /// <param name="borderRadius">The border radius value.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithBorderRadius(string borderRadius) {
        BorderRadius = borderRadius;
        return this;
    }

    /// <summary>
    /// Makes the image a clickable link.
    /// </summary>
    /// <param name="url">The link URL.</param>
    /// <param name="openInNewWindow">Whether to open in new window.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithLink(string url, bool openInNewWindow = false) {
        LinkUrl = url;
        OpenInNewWindow = openInNewWindow;
        return this;
    }

    /// <summary>
    /// Sets the CSS class for the image container.
    /// </summary>
    /// <param name="cssClass">The CSS class.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithCssClass(string cssClass) {
        CssClass = cssClass;
        return this;
    }

        /// <summary>
    /// Skips automatic embedding for this image, even if document configuration enables it.
    /// </summary>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithoutAutoEmbedding() {
        SkipAutoEmbedding = true;
        ForceEmbedding = false;

        // Reset any auto-embedding that already happened and restore original source
        if (EmbedAsBase64 && !string.IsNullOrEmpty(_originalSource)) {
            EmbedAsBase64 = false;
            Base64Data = "";
            MimeType = "";
            Source = _originalSource; // Restore original file path
        }

        return this;
    }

    /// <summary>
    /// Enables automatic embedding for this image, even if document configuration disables it.
    /// </summary>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithAutoEmbedding() {
        ForceEmbedding = true;
        SkipAutoEmbedding = false;
        if (!EmbedAsBase64 && !string.IsNullOrEmpty(Source)) {
            ApplyDocumentConfiguration();
        }
        return this;
    }

    /// <summary>
    /// Embeds the image as base64 data URI from a local file path.
    /// </summary>
    /// <param name="filePath">The file path to embed.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage EmbedFromFile(string filePath) {
        try {
            if (System.IO.File.Exists(filePath)) {
                var fileInfo = new System.IO.FileInfo(filePath);

                // Check file size against configuration limit
                var maxSize = Email?.Configuration?.Email?.MaxEmbedFileSize ?? 2 * 1024 * 1024;
                if (fileInfo.Length > maxSize) {
                    if (Email?.Configuration?.Email?.LogEmbeddingWarnings == true && Email is not null) {
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
            } else {
                // File doesn't exist, fallback to file path
                Source = filePath;
            }
        } catch (Exception) {
            // Fallback to file path if embedding fails
            Source = filePath;
            if (Email?.Configuration?.Email?.LogEmbeddingWarnings == true && Email is not null) {
                Email.Configuration.Errors.Add("Warning: Failed to embed image.");
                Email.IncrementEmbeddingWarning();
            }
        }
        return this;
    }

    /// <summary>
    /// Embeds the image as base64 data URI from a URL.
    /// </summary>
    /// <param name="url">The URL to download and embed.</param>
    /// <param name="timeoutSeconds">Timeout in seconds for the download (default: 30).</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage EmbedFromUrl(string url, int timeoutSeconds = 30) =>
        EmbedFromUrlAsync(url, timeoutSeconds).GetAwaiter().GetResult();

    /// <summary>
    /// Asynchronously embeds the image from a URL.
    /// </summary>
    /// <param name="url">The URL to download and embed.</param>
    /// <param name="timeoutSeconds">Download timeout in seconds.</param>
    /// <returns>The current <see cref="EmailImage"/> instance.</returns>
    public async Task<EmailImage> EmbedFromUrlAsync(string url, int timeoutSeconds = 30) {
        try {
            var download = await ImageUtilities.DownloadImageAsync(url, timeoutSeconds).ConfigureAwait(false);
            if (download is not null) {
                var (bytes, mimeType) = download.Value;

                // Check file size against configuration limit
                var maxSize = Email?.Configuration?.Email?.MaxEmbedFileSize ?? 2 * 1024 * 1024;
                if (bytes.Length > maxSize) {
                if (Email?.Configuration?.Email?.LogEmbeddingWarnings == true && Email is not null) {
                    Email.Configuration.Errors.Add("Warning: URL content exceeds maximum embed size.");
                    Email.IncrementEmbeddingWarning();
                }
                    Source = url;
                    return this;
                }

                MimeType = mimeType;

                if (OptimizeImage) {
                    var extension = ImageUtilities.GetExtensionFromMimeType(MimeType);
                    bytes = ImageUtilities.OptimizeImageBytes(bytes, extension, MaxWidth, MaxHeight, Quality);
                }

                Base64Data = Convert.ToBase64String(bytes);
                EmbedAsBase64 = true;
                Source = $"data:{MimeType};base64,{Base64Data}";
            } else {
                throw new Exception("Download failed");
            }
        } catch (Exception) {
            // Fallback to URL if embedding fails
            Source = url;
            if (Email?.Configuration?.Email?.LogEmbeddingWarnings == true && Email is not null) {
                Email.Configuration.Errors.Add("Warning: Failed to embed image from URL.");
                Email.IncrementEmbeddingWarning();
            }
        }
        return this;
    }

    /// <summary>
    /// Smart embedding that automatically detects whether the source is a file path or URL and embeds accordingly.
    /// </summary>
    /// <param name="source">The file path or URL to embed.</param>
    /// <param name="timeoutSeconds">Timeout in seconds for URL downloads (default: 30).</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage EmbedSmart(string source, int timeoutSeconds = 30) {
        if (string.IsNullOrEmpty(source)) {
            return this;
        }

        // Check if it's a URL
        if (Uri.TryCreate(source, UriKind.Absolute, out Uri? uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)) {
            return EmbedFromUrl(source, timeoutSeconds);
        }

        // Check if it's a file path
        if (System.IO.File.Exists(source)) {
            return EmbedFromFile(source);
        }

        // If neither works, use as-is
        Source = source;
        if (Email?.Configuration?.Email?.LogEmbeddingWarnings == true && Email is not null) {
            Email.Configuration.Errors.Add("Warning: Could not embed source - using direct source.");
            Email.IncrementEmbeddingWarning();
        }
        return this;
    }

    /// <summary>
    /// Embeds the image with base64 data directly.
    /// </summary>
    /// <param name="base64Data">The base64 encoded image data.</param>
    /// <param name="mimeType">The MIME type of the image.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage EmbedFromBase64(string base64Data, string mimeType) {
        Base64Data = base64Data;
        MimeType = mimeType;
        EmbedAsBase64 = true;
        Source = $"data:{MimeType};base64,{Base64Data}";
        return this;
    }

    /// <summary>
    /// Embeds the dark mode image as base64 data URI.
    /// </summary>
    /// <param name="source">The dark mode image source (file path or URL).</param>
    /// <param name="timeoutSeconds">Timeout in seconds for URL downloads.</param>
    /// <param name="useSmartDetection">Whether to use smart detection for file vs URL.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage EmbedDarkModeImage(string source, int timeoutSeconds = 30, bool useSmartDetection = true) {
        if (string.IsNullOrEmpty(source)) {
            return this;
        }

        try {
            byte[] bytes;
            string mimeType;

            if (useSmartDetection) {
                // Use smart detection similar to main image
                if (Uri.TryCreate(source, UriKind.Absolute, out Uri? uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)) {
                    var download = ImageUtilities.DownloadImage(source, timeoutSeconds);
                    if (download is null) {
                        throw new Exception("Download failed");
                    }
                    (bytes, mimeType) = download.Value;
                } else if (System.IO.File.Exists(source)) {
                    (bytes, mimeType) = ImageUtilities.LoadImageFromFile(source, OptimizeImage, MaxWidth, MaxHeight, Quality);
                } else {
                    throw new Exception("Source is neither a valid URL nor an existing file");
                }
            } else {
                // Assume file path
                (bytes, mimeType) = ImageUtilities.LoadImageFromFile(source, OptimizeImage, MaxWidth, MaxHeight, Quality);
            }

            // Check file size against configuration limit
            var maxSize = Email?.Configuration?.Email?.MaxEmbedFileSize ?? 2 * 1024 * 1024;
            if (bytes.Length > maxSize) {
                if (Email?.Configuration?.Email?.LogEmbeddingWarnings == true && Email is not null) {
                    Email.Configuration.Errors.Add("Warning: Dark mode image exceeds maximum embed size.");
                    Email.IncrementEmbeddingWarning();
                }
                return this;
            }

            // Set dark mode image data
            DarkModeBase64Data = Convert.ToBase64String(bytes);
            DarkModeMimeType = mimeType;
            DarkModeEmbedAsBase64 = true;

            // Update DarkModeSource to use data URI
            DarkModeSource = $"data:{mimeType};base64,{DarkModeBase64Data}";

        } catch (Exception) {
            // Fallback to original source if embedding fails
            if (Email?.Configuration?.Email?.LogEmbeddingWarnings == true && Email is not null) {
                Email.Configuration.Errors.Add("Warning: Failed to embed dark mode image.");
                Email.IncrementEmbeddingWarning();
            }
        }

        return this;
    }

    /// <summary>
    /// Enables image optimization with specified parameters.
    /// </summary>
    /// <param name="maxWidth">Maximum width in pixels (0 = no limit).</param>
    /// <param name="maxHeight">Maximum height in pixels (0 = no limit).</param>
    /// <param name="quality">JPEG quality (0-100, default: 85).</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithOptimization(int maxWidth = 0, int maxHeight = 0, int quality = 85) {
        OptimizeImage = true;
        MaxWidth = maxWidth;
        MaxHeight = maxHeight;
        Quality = Math.Max(0, Math.Min(100, quality));
        return this;
    }

    /// <summary>
    /// Disables image optimization.
    /// </summary>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithoutOptimization() {
        OptimizeImage = false;
        return this;
    }

    /// <summary>
    /// Sets the dark mode image source.
    /// </summary>
    /// <param name="darkSource">The dark mode image source URL or file path.</param>
    /// <param name="darkAltText">Optional alternative text for dark mode image.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithDarkModeSource(string darkSource, string darkAltText = "") {
        DarkModeSource = darkSource;
        DarkModeAlternativeText = string.IsNullOrEmpty(darkAltText) ? AlternativeText : darkAltText;
        EnableDarkModeSwapping = true;
        return this;
    }

    /// <summary>
    /// Sets light and dark mode image sources as a pair.
    /// This is the recommended way to provide theme-aware images.
    /// </summary>
    /// <param name="lightSource">The light mode image source.</param>
    /// <param name="darkSource">The dark mode image source.</param>
    /// <param name="altText">Alternative text for both images.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithImagePair(string lightSource, string darkSource, string altText = "") {
        Source = lightSource;
        DarkModeSource = darkSource;
        AlternativeText = altText;
        DarkModeAlternativeText = altText;
        EnableDarkModeSwapping = true;
        return this;
    }

    /// <summary>
    /// Sets separate alternative texts for light and dark mode images.
    /// </summary>
    /// <param name="lightAltText">Alternative text for light mode image.</param>
    /// <param name="darkAltText">Alternative text for dark mode image.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithSeparateAltTexts(string lightAltText, string darkAltText) {
        AlternativeText = lightAltText;
        DarkModeAlternativeText = darkAltText;
        return this;
    }

    /// <summary>
    /// Disables dark mode image swapping for this image.
    /// The same image will be used in both light and dark modes.
    /// </summary>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithoutDarkModeSwapping() {
        EnableDarkModeSwapping = false;
        DarkModeSource = "";
        return this;
    }

    /// <summary>
    /// Enables dark mode image swapping (default behavior).
    /// </summary>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithDarkModeSwapping() {
        EnableDarkModeSwapping = true;
        return this;
    }

    /// <summary>
    /// Called when this element is added to a document.
    /// Applies document configuration settings automatically.
    /// </summary>
    protected internal override void OnAddedToDocument() {
        base.OnAddedToDocument();
        ApplyDocumentConfiguration();
    }

    /// <summary>
    /// Gets the MIME type from file extension.
    /// </summary>
    /// <param name="extension">The file extension.</param>
    /// <returns>The MIME type.</returns>
    private static string GetMimeTypeFromExtension(string extension) =>
        ImageUtilities.GetMimeTypeFromExtension(extension);

    /// <summary>
    /// Gets the MIME type from URL extension.
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns>The MIME type.</returns>
    private static string GetMimeTypeFromUrl(string url) =>
        ImageUtilities.GetMimeTypeFromUrl(url);

    /// <summary>
    /// Gets the file extension from MIME type.
    /// </summary>
    /// <param name="mimeType">The MIME type.</param>
    /// <returns>The file extension.</returns>
    private static string GetExtensionFromMimeType(string mimeType) =>
        ImageUtilities.GetExtensionFromMimeType(mimeType);

    /// <summary>
    /// Optimizes image bytes if optimization is enabled.
    /// Note: This is a placeholder for image optimization logic.
    /// In a real implementation, you would use a library like ImageSharp, SkiaSharp, or System.Drawing.
    /// </summary>
    /// <param name="bytes">The original image bytes.</param>
    /// <param name="extension">The file extension.</param>
    /// <returns>The optimized image bytes.</returns>
    private byte[] OptimizeImageBytes(byte[] bytes, string extension) =>
        ImageUtilities.OptimizeImageBytes(bytes, extension, MaxWidth, MaxHeight, Quality);

    /// <summary>
    /// Sets the margin using predefined spacing values.
    /// </summary>
    /// <param name="spacing">The predefined spacing value for all sides.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithMargin(EmailSpacing spacing) {
        Margin = spacing.ToCssValue();
        return this;
    }

    /// <summary>
    /// Sets the margin using predefined spacing values for vertical and horizontal.
    /// </summary>
    /// <param name="vertical">The predefined vertical spacing (top and bottom).</param>
    /// <param name="horizontal">The predefined horizontal spacing (left and right).</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithMargin(EmailSpacing vertical, EmailSpacing horizontal) {
        Margin = $"{vertical.ToCssValue()} {horizontal.ToCssValue()}";
        return this;
    }

    /// <summary>
    /// Sets the margin using predefined spacing values for all sides.
    /// </summary>
    /// <param name="top">The predefined top spacing.</param>
    /// <param name="right">The predefined right spacing.</param>
    /// <param name="bottom">The predefined bottom spacing.</param>
    /// <param name="left">The predefined left spacing.</param>
    /// <returns>The EmailImage object, allowing for method chaining.</returns>
    public EmailImage WithMargin(EmailSpacing top, EmailSpacing right, EmailSpacing bottom, EmailSpacing left) {
        Margin = $"{top.ToCssValue()} {right.ToCssValue()} {bottom.ToCssValue()} {left.ToCssValue()}";
        return this;
    }

    /// <summary>
    /// Converts the EmailImage to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the email image.</returns>
    public override string ToString() {
        if (EmbedAsBase64 && string.IsNullOrWhiteSpace(MimeType)) {
            throw new InvalidOperationException("EmbedAsBase64 is enabled but MimeType is not specified.");
        }

        var html = StringBuilderCache.Acquire();

        // Build image attributes for light mode image
        var imgAttributes = new List<string>();
        imgAttributes.Add($"src=\"{Helpers.HtmlEncode(Source)}\"");

        if (!string.IsNullOrEmpty(Width)) {
            imgAttributes.Add($"width=\"{Width}\"");
        }

        if (!string.IsNullOrEmpty(Height)) {
            imgAttributes.Add($"height=\"{Height}\"");
        }

        if (!string.IsNullOrEmpty(AlternativeText)) {
            imgAttributes.Add($"alt=\"{Helpers.HtmlEncode(AlternativeText)}\"");
        }

        // Build image style
        var imgStyle = new List<string>();
        imgStyle.Add("display: inline-block");
        imgStyle.Add("line-height: 100%");
        imgStyle.Add("outline: none");
        imgStyle.Add("text-decoration: none");
        imgStyle.Add("vertical-align: bottom");
        imgStyle.Add("font-size: 0");
        imgStyle.Add("border-style: none");
        imgStyle.Add("border-width: 0");

        if (!string.IsNullOrEmpty(Border) && Border != "none") {
            imgStyle.Add($"border: {Border}");
        }

        if (!string.IsNullOrEmpty(BorderRadius) && BorderRadius != "0") {
            imgStyle.Add($"border-radius: {BorderRadius}");
        }

        // Add CSS class for dark mode handling
        var cssClass = CssClass;
        if (EnableDarkModeSwapping && !string.IsNullOrEmpty(DarkModeSource)) {
            cssClass += " light-img";
        }

        if (!string.IsNullOrEmpty(cssClass)) {
            imgAttributes.Add($"class=\"{cssClass.Trim()}\"");
        }

        var imgStyleAttr = $" style=\"{string.Join("; ", imgStyle)}\"";

        // Check if we're being rendered inside an EmailColumn (part of a row)
        // If so, don't wrap in table structure - just return the content
        var isInColumn = IsInEmailColumn();

        if (isInColumn) {
            // When inside a column, render as a div, not a table
            // Inherit alignment from parent column if not explicitly set
            var effectiveAlignment = Alignment;
            if (Alignment == "left" && ParentColumn != null && !string.IsNullOrEmpty(ParentColumn.TextAlign)) {
                effectiveAlignment = ParentColumn.TextAlign;
            }

            var divStyle = $@"margin: {Margin}; padding: {Padding}; text-align: {effectiveAlignment};
                font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;
                max-width: 100%; overflow: hidden;";

            html.AppendLine($@"<div style=""{divStyle}"">");

            // Light mode image (always present)
            var imgTag = $@"<img {string.Join(" ", imgAttributes)}{imgStyleAttr} />";

            if (!string.IsNullOrEmpty(LinkUrl)) {
                var target = OpenInNewWindow ? " target=\"_blank\"" : "";
                var linkStyle = "color: #066FD1; text-decoration: none;";
                html.AppendLine($@"<a href=""{Helpers.HtmlEncode(LinkUrl)}""{target} style=""{linkStyle}"">{imgTag}</a>");
            } else {
                html.AppendLine(imgTag);
            }

            // Dark mode image (if provided and swapping is enabled)
            if (EnableDarkModeSwapping && !string.IsNullOrEmpty(DarkModeSource)) {
                // Build dark mode image attributes
                var darkImgAttributes = new List<string>();
                darkImgAttributes.Add($"src=\"{Helpers.HtmlEncode(DarkModeSource)}\"");

                if (!string.IsNullOrEmpty(Width)) {
                    darkImgAttributes.Add($"width=\"{Width}\"");
                }

                if (!string.IsNullOrEmpty(Height)) {
                    darkImgAttributes.Add($"height=\"{Height}\"");
                }

                var darkAltText = !string.IsNullOrEmpty(DarkModeAlternativeText) ? DarkModeAlternativeText : AlternativeText;
                if (!string.IsNullOrEmpty(darkAltText)) {
                    darkImgAttributes.Add($"alt=\"{Helpers.HtmlEncode(darkAltText)}\"");
                }

                // Dark mode image style (initially hidden)
                var darkImgStyle = new List<string>(imgStyle);
                darkImgStyle.Add("display: none");

                darkImgAttributes.Add($"class=\"{CssClass} dark-img\"");
                var darkImgStyleAttr = $" style=\"{string.Join("; ", darkImgStyle)}\"";

                // Add dark mode image with MSO conditional comments for Outlook compatibility
                html.AppendLine($@"
<!--[if !mso]><!-->");
                html.AppendLine($@"<div class=""dark-img"" style=""display: none; overflow: hidden; float: left; width: 0px; max-height: 0px; max-width: 0px; line-height: 0px; visibility: hidden;"" align=""{Alignment}"">");

                if (!string.IsNullOrEmpty(LinkUrl)) {
                    var target = OpenInNewWindow ? " target=\"_blank\"" : "";
                    html.AppendLine($@"<a href=""{Helpers.HtmlEncode(LinkUrl)}""{target} style=""color: #066FD1; text-decoration: none;"">");
                    html.AppendLine($@"<img {string.Join(" ", darkImgAttributes)}{darkImgStyleAttr} />");
                    html.AppendLine($@"</a>");
                } else {
                    html.AppendLine($@"<img {string.Join(" ", darkImgAttributes)}{darkImgStyleAttr} />");
                }

                html.AppendLine($@"</div>");
                html.AppendLine($@"<!--<![endif]-->");
            }

            html.AppendLine($@"</div>");
        } else {
            // When standalone, use table structure for email compatibility
            html.AppendLine($@"
<tr>
<td style=""margin: {Margin}; padding: {Padding}; text-align: {Alignment}; font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;"">
");

            // Light mode image (always present)
            if (!string.IsNullOrEmpty(LinkUrl)) {
                var target = OpenInNewWindow ? " target=\"_blank\"" : "";
                html.AppendLine($@"<a href=""{Helpers.HtmlEncode(LinkUrl)}""{target} style=""color: #066FD1; text-decoration: none;"">");
                html.AppendLine($@"<img {string.Join(" ", imgAttributes)}{imgStyleAttr} />");
                html.AppendLine($@"</a>");
            } else {
                html.AppendLine($@"<img {string.Join(" ", imgAttributes)}{imgStyleAttr} />");
            }

            // Dark mode image (if provided and swapping is enabled)
            if (EnableDarkModeSwapping && !string.IsNullOrEmpty(DarkModeSource)) {
                // Build dark mode image attributes
                var darkImgAttributes = new List<string>();
                darkImgAttributes.Add($"src=\"{Helpers.HtmlEncode(DarkModeSource)}\"");

                if (!string.IsNullOrEmpty(Width)) {
                    darkImgAttributes.Add($"width=\"{Width}\"");
                }

                if (!string.IsNullOrEmpty(Height)) {
                    darkImgAttributes.Add($"height=\"{Height}\"");
                }

                var darkAltText = !string.IsNullOrEmpty(DarkModeAlternativeText) ? DarkModeAlternativeText : AlternativeText;
                if (!string.IsNullOrEmpty(darkAltText)) {
                    darkImgAttributes.Add($"alt=\"{Helpers.HtmlEncode(darkAltText)}\"");
                }

                // Dark mode image style (initially hidden)
                var darkImgStyle = new List<string>(imgStyle);
                darkImgStyle.Add("display: none");

                darkImgAttributes.Add($"class=\"{CssClass} dark-img\"");
                var darkImgStyleAttr = $" style=\"{string.Join("; ", darkImgStyle)}\"";

                // Add dark mode image with MSO conditional comments for Outlook compatibility
                html.AppendLine($@"
<!--[if !mso]><!-->");
                html.AppendLine($@"<div class=""dark-img"" style=""display: none; overflow: hidden; float: left; width: 0px; max-height: 0px; max-width: 0px; line-height: 0px; visibility: hidden;"" align=""{Alignment}"">");

                if (!string.IsNullOrEmpty(LinkUrl)) {
                    var target = OpenInNewWindow ? " target=\"_blank\"" : "";
                    html.AppendLine($@"<a href=""{Helpers.HtmlEncode(LinkUrl)}""{target} style=""color: #066FD1; text-decoration: none;"">");
                    html.AppendLine($@"<img {string.Join(" ", darkImgAttributes)}{darkImgStyleAttr} />");
                    html.AppendLine($@"</a>");
                } else {
                    html.AppendLine($@"<img {string.Join(" ", darkImgAttributes)}{darkImgStyleAttr} />");
                }

                html.AppendLine($@"</div>");
                html.AppendLine($@"<!--<![endif]-->");
            }

            html.AppendLine($@"
</td>
</tr>
");
        }

        return StringBuilderCache.GetStringAndRelease(html);
    }

    /// <summary>
    /// Checks if this EmailImage is being rendered inside an EmailColumn.
    /// </summary>
    /// <returns>True if inside an EmailColumn, false otherwise.</returns>
    private bool IsInEmailColumn() {
        return ParentColumn != null;
    }
}