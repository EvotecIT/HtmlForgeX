using System.Collections.Concurrent;

namespace HtmlForgeX;

/// <summary>
/// Configuration class for Email documents.
/// Manages state, libraries, and settings specific to email generation.
/// </summary>
public class EmailConfiguration {
    private readonly object _syncRoot = new();
    private string _path = string.Empty;
    /// <summary>
    /// Gets or sets the library mode for this email document.
    /// Email documents only support inline CSS mode.
    /// </summary>
    public EmailLibraryMode LibraryMode { get; set; } = EmailLibraryMode.InlineOnly;

    /// <summary>
    /// Gets or sets the theme mode for this email document.
    /// </summary>
    public EmailThemeMode ThemeMode { get; set; } = EmailThemeMode.Light;

    /// <summary>
    /// Gets or sets the file path for this email document.
    /// </summary>
    public string Path {
        get { lock (_syncRoot) { return _path; } }
        set { lock (_syncRoot) { _path = value; } }
    }

    /// <summary>
    /// Collection of libraries registered for this email document. Works as a
    /// set to prevent duplicate library registrations.
    /// </summary>
    public ConcurrentDictionary<EmailLibraries, byte> Libraries { get; } = new();

    /// <summary>
    /// Collection of errors that occurred during email generation.
    /// </summary>
    public ConcurrentBag<string> Errors { get; } = new();

    /// <summary>
    /// Gets or sets the maximum width for the email content (in pixels).
    /// Default is 640px which is email standard.
    /// </summary>
    public int MaxWidth { get; set; } = 640;

    /// <summary>
    /// Gets or sets whether dark mode support is enabled.
    /// </summary>
    public bool DarkModeSupport { get; set; } = true;

    /// <summary>
    /// Gets or sets whether to include preheader text.
    /// </summary>
    public bool IncludePreheader { get; set; } = true;

    /// <summary>
    /// Gets or sets the preheader text for email preview.
    /// </summary>
    public string PreheaderText { get; set; } = "This is preheader text. Some clients will show this text as a preview.";

    /// <summary>
    /// Gets or sets whether to automatically embed images as base64 data URIs.
    /// When enabled, all EmailImage instances will attempt to embed images unless overridden.
    /// </summary>
    public bool AutoEmbedImages { get; set; } = false;

    /// <summary>
    /// Gets or sets the timeout in seconds for downloading remote images for embedding.
    /// </summary>
    public int EmbeddingTimeout { get; set; } = 30;

    /// <summary>
    /// Gets or sets whether to automatically optimize images during embedding.
    /// </summary>
    public bool OptimizeImages { get; set; } = false;

    /// <summary>
    /// Gets or sets the default email layout padding.
    /// </summary>
    public string DefaultPadding { get; set; } = "12px";

    /// <summary>
    /// Gets or sets whether to use consistent spacing between email elements.
    /// </summary>
    public bool UseConsistentSpacing { get; set; } = true;

    /// <summary>
    /// Gets or sets whether to automatically detect and handle file paths vs URLs in images.
    /// </summary>
    public bool SmartImageDetection { get; set; } = true;

    /// <summary>
    /// Gets or sets whether to include fallback images for email clients that don't support base64.
    /// </summary>
    public bool IncludeFallbackImages { get; set; } = false;

    /// <summary>
    /// Gets or sets the maximum file size (in bytes) for automatic image embedding.
    /// Images larger than this will not be embedded automatically.
    /// </summary>
    public long MaxEmbedFileSize { get; set; } = 2 * 1024 * 1024; // 2MB

    /// <summary>
    /// Gets or sets whether to log warnings when image embedding fails.
    /// </summary>
    public bool LogEmbeddingWarnings { get; set; } = true;
}

/// <summary>
/// Enum for email library modes.
/// </summary>
public enum EmailLibraryMode {
    /// <summary>
    /// Only inline CSS allowed - no external resources or JavaScript.
    /// </summary>
    InlineOnly
}

/// <summary>
/// Enum for email theme modes.
/// </summary>
public enum EmailThemeMode {
    /// <summary>
    /// Light theme.
    /// </summary>
    Light,
    /// <summary>
    /// Dark theme.
    /// </summary>
    Dark,
    /// <summary>
    /// Auto theme that supports both light and dark.
    /// </summary>
    Auto
}

/// <summary>
/// Enum for predefined email libraries.
/// </summary>
public enum EmailLibraries {
    /// <summary>
    /// Core email styling library.
    /// </summary>
    EmailCore,
    /// <summary>
    /// Tabler email components.
    /// </summary>
    TablerEmail,
    /// <summary>
    /// Email button components.
    /// </summary>
    EmailButtons,
    /// <summary>
    /// Email table components.
    /// </summary>
    EmailTables
}