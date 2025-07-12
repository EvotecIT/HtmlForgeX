using System.Collections.Concurrent;

namespace HtmlForgeX;

/// <summary>
/// Configuration class for Document instances.
/// Manages state, libraries, and settings for document generation.
/// </summary>
public class DocumentConfiguration {
    private readonly object _syncRoot = new();
    private string _path = System.IO.Path.GetTempPath();
    private string _stylePath = string.Empty;
    private string _scriptPath = string.Empty;
    /// <summary>
    /// Gets or sets the library mode for this document.
    /// </summary>
    public LibraryMode LibraryMode { get; set; } = LibraryMode.Online;

    /// <summary>
    /// Gets or sets the theme mode for this document.
    /// </summary>
    public ThemeMode ThemeMode { get; set; } = ThemeMode.System;

    /// <summary>
    /// Gets or sets the file path for this document.
    /// </summary>
    public string Path {
        get { lock (_syncRoot) { return _path; } }
        set { lock (_syncRoot) { _path = value; } }
    }

    /// <summary>
    /// Gets or sets the style path for this document.
    /// </summary>
    public string StylePath {
        get { lock (_syncRoot) { return _stylePath; } }
        set { lock (_syncRoot) { _stylePath = value; } }
    }

    /// <summary>
    /// Gets or sets the script path for this document.
    /// </summary>
    public string ScriptPath {
        get { lock (_syncRoot) { return _scriptPath; } }
        set { lock (_syncRoot) { _scriptPath = value; } }
    }

    /// <summary>
    /// Gets or sets whether deferred scripts are enabled.
    /// </summary>
    public bool EnableDeferredScripts { get; set; } = false;

    /// <summary>
    /// Gets or sets whether dark mode support is enabled.
    /// </summary>
    public bool DarkModeSupport { get; set; } = true;

    /// <summary>
    /// Collection of libraries registered for this document. Acts as a
    /// thread-safe set to avoid duplicate registrations.
    /// </summary>
    public ConcurrentDictionary<Libraries, byte> Libraries { get; } = new();

    /// <summary>
    /// Collection of errors that occurred during document generation.
    /// </summary>
    public ConcurrentBag<string> Errors { get; } = new();

    /// <summary>
    /// Email-specific configuration.
    /// </summary>
    public EmailConfiguration Email { get; } = new();

    /// <summary>
    /// Image-specific configuration.
    /// </summary>
    public ImageConfiguration Images { get; } = new();

    /// <summary>
    /// Layout-specific configuration.
    /// </summary>
    public LayoutConfiguration Layout { get; } = new();
    
    /// <summary>
    /// Generates a random ID with the specified prefix.
    /// </summary>
    /// <param name="preText">The prefix for the ID.</param>
    /// <param name="length">Length of the random part (default: 8).</param>
    /// <returns>Generated identifier.</returns>
    public string GenerateRandomId(string preText, int length = IdGenerator.DefaultRandomIdLength) {
        return IdGenerator.GenerateRandomId(preText, length);
    }
}

/// <summary>
/// Image processing configuration settings.
/// </summary>
public class ImageConfiguration {
    /// <summary>
    /// Gets or sets whether to automatically optimize images.
    /// </summary>
    public bool AutoOptimize { get; set; } = false;

    /// <summary>
    /// Gets or sets the maximum width for image optimization (in pixels).
    /// </summary>
    public int MaxWidth { get; set; } = 800;

    /// <summary>
    /// Gets or sets the maximum height for image optimization (in pixels).
    /// </summary>
    public int MaxHeight { get; set; } = 600;

    /// <summary>
    /// Gets or sets the quality for JPEG compression (0-100).
    /// </summary>
    public int Quality { get; set; } = 85;

    /// <summary>
    /// Gets or sets the default image format for optimization.
    /// </summary>
    public string DefaultFormat { get; set; } = "png";

    /// <summary>
    /// Gets or sets whether to preserve image metadata during optimization.
    /// </summary>
    public bool PreserveMetadata { get; set; } = false;
}

/// <summary>
/// Layout configuration settings.
/// </summary>
public class LayoutConfiguration {
    /// <summary>
    /// Gets or sets the default container padding.
    /// </summary>
    public string ContainerPadding { get; set; } = "12px";

    /// <summary>
    /// Gets or sets the default content padding.
    /// </summary>
    public string ContentPadding { get; set; } = "8px";

    /// <summary>
    /// Gets or sets the default spacing between elements.
    /// </summary>
    public string ElementSpacing { get; set; } = "12px";

    /// <summary>
    /// Gets or sets whether to use responsive design by default.
    /// </summary>
    public bool UseResponsiveDesign { get; set; } = true;

    /// <summary>
    /// Gets or sets the default maximum content width.
    /// </summary>
    public string MaxContentWidth { get; set; } = "600px";
}