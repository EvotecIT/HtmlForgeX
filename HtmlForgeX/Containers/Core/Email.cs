using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Threading;
using HtmlForgeX.Logging;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Represents an email document with XHTML&#160;1.0 Strict compliance for email
/// clients. Provides a simplified object model for generating HTML emails.
/// </summary>
public class Email : Element {
    private static readonly InternalLogger _logger = new();

    private int _embeddingWarningCount;

    /// <summary>
    /// Gets the number of embedding warnings collected during generation.
    /// </summary>
    public int EmbeddingWarningCount => _embeddingWarningCount;

    internal void IncrementEmbeddingWarning() => _embeddingWarningCount++;

    /// <summary>
    /// Configuration and state for this email document instance.
    /// </summary>
    public DocumentConfiguration Configuration { get; } = new();

    /// <summary>
    /// Gets the <see cref="EmailHead"/> section where metadata and styles are defined.
    /// </summary>
    public EmailHead Head { get; }

    /// <summary>
    /// Gets the <see cref="EmailBody"/> containing the main message content.
    /// </summary>
    public EmailBody Body { get; }

    /// <summary>
    /// Gets the header area rendered at the top of the email.
    /// </summary>
    public EmailHeader Header { get; }

    /// <summary>
    /// Gets the footer area rendered at the bottom of the email.
    /// </summary>
    public EmailFooter Footer { get; }

    /// <summary>
    /// Gets or sets the library mode for the email. Only inline mode is supported.
    /// </summary>
    public EmailLibraryMode LibraryMode {
        get => Configuration.Email.AutoEmbedImages ? EmailLibraryMode.InlineOnly : EmailLibraryMode.InlineOnly; // Email only supports inline
        set { /* Email only supports inline mode */ }
    }

    /// <summary>
    /// Gets or sets the file system path where the email will be saved.
    /// </summary>
    public string Path {
        get => Configuration.Email.DefaultPadding; // Reuse for path storage
        set => Configuration.Email.DefaultPadding = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Email"/> class.
    /// </summary>
    /// <param name="librariesMode">Initial library mode (must be inline CSS only).</param>
    public Email(EmailLibraryMode? librariesMode = null) {
        // Set default email configuration
        Configuration.Email.AutoEmbedImages = false; // Default to false, can be enabled
        Configuration.Email.OptimizeImages = false;
        Configuration.Email.SmartImageDetection = true;
        Configuration.DarkModeSupport = true;

        // Initialize Head, Body, Header, and Footer with reference to this email's configuration
        Head = new EmailHead(this);
        Body = new EmailBody(this);
        Header = new EmailHeader();
        Footer = new EmailFooter();

        // Set the email reference for all components so they can propagate it to children
        Head.Email = this;
        Body.Email = this;
        Header.Email = this;
        Footer.Email = this;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Email"/> class with custom configuration.
    /// </summary>
    /// <param name="configuration">The document configuration to use.</param>
    public Email(DocumentConfiguration configuration) {
        Configuration = configuration ?? new DocumentConfiguration();

        // Initialize Head, Body, Header, and Footer with reference to this email's configuration
        Head = new EmailHead(this);
        Body = new EmailBody(this);
        Header = new EmailHeader();
        Footer = new EmailFooter();

        // Set the email reference for all components so they can propagate it to children
        Head.Email = this;
        Body.Email = this;
        Header.Email = this;
        Footer.Email = this;
    }

    /// <summary>
    /// Enables automatic image embedding for all images in this email.
    /// </summary>
    /// <param name="timeout">Timeout in seconds for URL downloads (default: 30).</param>
    /// <param name="optimize">Whether to enable image optimization (default: false).</param>
    /// <returns>The Email object, allowing for method chaining.</returns>
    public Email EnableImageEmbedding(int timeout = 30, bool optimize = false) {
        Configuration.Email.AutoEmbedImages = true;
        Configuration.Email.EmbeddingTimeout = timeout;
        Configuration.Email.OptimizeImages = optimize;
        if (optimize) {
            Configuration.Images.AutoOptimize = true;
        }
        return this;
    }

    /// <summary>
    /// Disables automatic image embedding for this email.
    /// </summary>
    /// <returns>The Email object, allowing for method chaining.</returns>
    public Email DisableImageEmbedding() {
        Configuration.Email.AutoEmbedImages = false;
        return this;
    }

    /// <summary>
    /// Configures image optimization settings for this email.
    /// </summary>
    /// <param name="maxWidth">Maximum width in pixels (default: 800).</param>
    /// <param name="maxHeight">Maximum height in pixels (default: 600).</param>
    /// <param name="quality">JPEG quality 0-100 (default: 85).</param>
    /// <returns>The Email object, allowing for method chaining.</returns>
    public Email ConfigureImageOptimization(int maxWidth = 800, int maxHeight = 600, int quality = 85) {
        Configuration.Images.AutoOptimize = true;
        Configuration.Images.MaxWidth = maxWidth;
        Configuration.Images.MaxHeight = maxHeight;
        Configuration.Images.Quality = quality;
        return this;
    }

    /// <summary>
    /// Sets the maximum file size for automatic image embedding.
    /// </summary>
    /// <param name="maxSizeBytes">Maximum file size in bytes (default: 2MB).</param>
    /// <returns>The Email object, allowing for method chaining.</returns>
    public Email SetMaxEmbedFileSize(long maxSizeBytes) {
        Configuration.Email.MaxEmbedFileSize = maxSizeBytes;
        return this;
    }

    /// <summary>
    /// Enables or disables smart image detection (file vs URL detection).
    /// </summary>
    /// <param name="enabled">Whether to enable smart detection (default: true).</param>
    /// <returns>The Email object, allowing for method chaining.</returns>
    public Email SetSmartImageDetection(bool enabled = true) {
        Configuration.Email.SmartImageDetection = enabled;
        return this;
    }

    /// <summary>
    /// Enables or disables logging of embedding warnings.
    /// </summary>
    /// <param name="enabled">Whether to log warnings (default: true).</param>
    /// <returns>The Email object, allowing for method chaining.</returns>
    public Email SetEmbeddingWarnings(bool enabled = true) {
        Configuration.Email.LogEmbeddingWarnings = enabled;
        return this;
    }

    /// <summary>
    /// Configures layout settings for this email using string values.
    /// </summary>
    /// <param name="containerPadding">Container padding (default: "12px").</param>
    /// <param name="contentPadding">Content padding (default: "8px").</param>
    /// <param name="maxWidth">Maximum content width (default: "600px").</param>
    /// <returns>The Email object, allowing for method chaining.</returns>
    public Email ConfigureLayout(string containerPadding = "12px", string contentPadding = "8px", string maxWidth = "600px") {
        Configuration.Layout.ContainerPadding = containerPadding;
        Configuration.Layout.ContentPadding = contentPadding;
        Configuration.Layout.MaxContentWidth = maxWidth;

        // IMPORTANT: Also update the Email configuration to ensure consistency
        // Convert maxWidth to pixels for EmailBody.MaxWidth (which expects int)
        if (maxWidth.EndsWith("px")) {
            if (int.TryParse(maxWidth.Replace("px", ""), out int widthPx)) {
                Configuration.Email.MaxWidth = widthPx;
            }
        } else if (maxWidth.EndsWith("%")) {
            // For percentage widths, use a reasonable default
            Configuration.Email.MaxWidth = 600;
        } else {
            // Try to parse as number (assume pixels)
            if (int.TryParse(maxWidth, out int widthNum)) {
                Configuration.Email.MaxWidth = widthNum;
            }
        }

        // Apply layout changes to EmailLayout static properties for backward compatibility
        EmailLayout.ContainerPadding = containerPadding;
        EmailLayout.ContentPadding = contentPadding;

        return this;
    }

    /// <summary>
    /// Configures layout settings for this email using predefined enum values.
    /// Provides easy-to-use presets while maintaining full control.
    /// </summary>
    /// <param name="layoutSize">Predefined layout size (default: Standard).</param>
    /// <param name="containerPadding">Container padding size (default: Medium).</param>
    /// <param name="contentPadding">Content padding size (default: Small).</param>
    /// <returns>The Email object, allowing for method chaining.</returns>
    public Email ConfigureLayout(EmailLayoutSize layoutSize = EmailLayoutSize.Standard,
                                EmailPaddingSize containerPadding = EmailPaddingSize.Medium,
                                EmailPaddingSize contentPadding = EmailPaddingSize.Small) {
        var maxWidth = layoutSize.ToCssValue();
        var containerPaddingValue = containerPadding.ToCssValue();
        var contentPaddingValue = contentPadding.ToCssValue();

        return ConfigureLayout(containerPaddingValue, contentPaddingValue, maxWidth);
    }

    /// <summary>
    /// Configures layout settings with custom width but predefined padding.
    /// Perfect for when you know the exact width you want but prefer enum padding.
    /// </summary>
    /// <param name="customMaxWidth">Custom maximum width (e.g., "750px", "90%").</param>
    /// <param name="containerPadding">Container padding size (default: Medium).</param>
    /// <param name="contentPadding">Content padding size (default: Small).</param>
    /// <returns>The Email object, allowing for method chaining.</returns>
    public Email ConfigureLayout(string customMaxWidth,
                                EmailPaddingSize containerPadding = EmailPaddingSize.Medium,
                                EmailPaddingSize contentPadding = EmailPaddingSize.Small) {
        var containerPaddingValue = containerPadding.ToCssValue();
        var contentPaddingValue = contentPadding.ToCssValue();

        return ConfigureLayout(containerPaddingValue, contentPaddingValue, customMaxWidth);
    }

    /// <summary>
    /// Enables dark mode support for this email.
    /// </summary>
    /// <param name="enabled">Whether to enable dark mode support (default: true).</param>
    /// <returns>The Email object, allowing for method chaining.</returns>
    public Email SetDarkModeSupport(bool enabled = true) {
        Configuration.DarkModeSupport = enabled;
        Configuration.Email.DarkModeSupport = enabled;
        return this;
    }

    /// <summary>
    /// Sets the theme mode for this email.
    /// </summary>
    /// <param name="mode">The theme mode (Light, Dark, or Auto).</param>
    /// <returns>The Email object, allowing for method chaining.</returns>
    public Email SetThemeMode(EmailThemeMode mode) {
        Configuration.Email.ThemeMode = mode;
        Configuration.DarkModeSupport = mode != EmailThemeMode.Light;
        Configuration.Email.DarkModeSupport = mode != EmailThemeMode.Light;
        return this;
    }

    /// <summary>
    /// Saves the email to disk.
    /// </summary>
    /// <param name="path">File path.</param>
    /// <param name="openInBrowser">Whether to open the file after saving.</param>
    public void Save(string path, bool openInBrowser = false) {
        PathUtilities.Validate(path);
        Configuration.Email.DefaultPadding = path; // Store path in configuration

        var countErrors = Configuration.Email.LogEmbeddingWarnings ? EmbeddingWarningCount : 0;
        if (countErrors > 0) {
            Console.WriteLine($"There were {countErrors} found during generation of HTML.");
        }

        var directory = System.IO.Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory)) {
            try {
                System.IO.Directory.CreateDirectory(directory);
            } catch (Exception ex) {
                _logger.WriteError($"Failed to create directory '{directory}'. {ex.Message}");
            }
        }
        try {
            FileWriteLock.Semaphore.Wait();
            File.WriteAllText(path, ToString(), Encoding.UTF8);
        } catch (Exception ex) {
            _logger.WriteError($"Failed to write file '{path}'. {ex.Message}");
        } finally {
            FileWriteLock.Semaphore.Release();
        }
        if (!Helpers.Open(path, openInBrowser)) {
            _logger.WriteError($"Failed to open file '{path}' using the default application.");
        }
    }

    /// <summary>
    /// Saves the email to disk asynchronously.
    /// </summary>
    /// <param name="path">File path.</param>
    /// <param name="openInBrowser">Whether to open the file after saving.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    public async Task SaveAsync(string path, bool openInBrowser = false, CancellationToken cancellationToken = default) {
        PathUtilities.Validate(path);
        Configuration.Email.DefaultPadding = path; // Store path in configuration

        var countErrors = Configuration.Email.LogEmbeddingWarnings ? EmbeddingWarningCount : 0;
        if (countErrors > 0) {
            Console.WriteLine($"There were {countErrors} found during generation of HTML.");
        }

        var directory = System.IO.Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory)) {
            try {
                System.IO.Directory.CreateDirectory(directory);
            } catch (Exception ex) {
                _logger.WriteError($"Failed to create directory '{directory}'. {ex.Message}");
            }
        }
        await FileWriteLock.Semaphore.WaitAsync(cancellationToken).ConfigureAwait(false);
        try {
#if NET5_0_OR_GREATER
            await File.WriteAllTextAsync(path, ToString(), Encoding.UTF8, cancellationToken).ConfigureAwait(false);
#else
            using var writer = new StreamWriter(path, false, Encoding.UTF8);
            cancellationToken.ThrowIfCancellationRequested();
            await writer.WriteAsync(ToString()).ConfigureAwait(false);
#endif
        } catch (OperationCanceledException) {
            throw;
        } catch (Exception ex) {
            _logger.WriteError($"Failed to write file '{path}'. {ex.Message}");
        } finally {
            FileWriteLock.Semaphore.Release();
        }
        if (!Helpers.Open(path, openInBrowser)) {
            _logger.WriteError($"Failed to open file '{path}' using the default application.");
        }
    }

    /// <summary>
    /// Converts the Email to its XHTML string representation.
    /// </summary>
    /// <returns>Complete XHTML email document as string.</returns>
    public override string ToString() {
        // Pre-register libraries from all elements before rendering the head
        RegisterAllLibraries();

        var html = StringBuilderCache.Acquire();
        html.AppendLine("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Strict//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd\">");
        html.AppendLine("<html xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" style=\"color-scheme: light dark; supported-color-schemes: light dark;\">");
        html.Append(Head.ToString());
        html.AppendLine();

        // Build body with header and footer integrated
        var bodyContent = Body.ToString();

        // Insert header at the beginning of body content if it has children
        if (Header.Children.Count > 0) {
            var headerContent = Header.ToString();
            // Insert header right after the opening body tags
            var bodyOpeningEnd = bodyContent.IndexOf("<td class=\"p-sm\"");
            if (bodyOpeningEnd > 0) {
                var insertPoint = bodyContent.IndexOf('>', bodyOpeningEnd) + 1;
                bodyContent = bodyContent.Insert(insertPoint, "\n" + headerContent);
            }
        }

        // Insert footer at the end of body content if it has children
        if (Footer.Children.Count > 0) {
            var footerContent = Footer.ToString();
            // Insert footer right before the closing body tags
            var bodyClosingStart = bodyContent.LastIndexOf("</td>");
            if (bodyClosingStart > 0) {
                bodyContent = bodyContent.Insert(bodyClosingStart, footerContent + "\n");
            }
        }

        html.Append(bodyContent);
        html.AppendLine();
        html.AppendLine("</html>");
        return StringBuilderCache.GetStringAndRelease(html);
    }

    /// <summary>
    /// Recursively registers libraries from all elements in the email.
    /// </summary>
    private void RegisterAllLibraries() {
        // Register libraries from Head
        Head.RegisterLibraries();
        RegisterLibrariesFromElement(Head);

        // Register libraries from Header and its children
        Header.RegisterLibraries();
        RegisterLibrariesFromElement(Header);

        // Register libraries from Body and its children
        Body.RegisterLibraries();
        RegisterLibrariesFromElement(Body);

        // Register libraries from Footer and its children
        Footer.RegisterLibraries();
        RegisterLibrariesFromElement(Footer);
    }

    /// <summary>
    /// Recursively registers libraries from an element and all its children.
    /// </summary>
    /// <param name="element">The element to process.</param>
    private void RegisterLibrariesFromElement(Element element) {
        foreach (var child in element.Children.WhereNotNull()) {
            child.RegisterLibraries();
            RegisterLibrariesFromElement(child);
        }
    }

    /// <summary>
    /// Adds a predefined email library.
    /// </summary>
    /// <param name="library">Library identifier.</param>
    public void AddLibrary(EmailLibraries library) {
        Configuration.Email.Libraries.TryAdd(library, 0);
    }
}