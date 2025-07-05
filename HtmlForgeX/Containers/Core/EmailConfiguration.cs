using System.Collections.Concurrent;

namespace HtmlForgeX;

/// <summary>
/// Configuration class for Email documents.
/// Manages state, libraries, and settings specific to email generation.
/// </summary>
public class EmailConfiguration {
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
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// Collection of libraries registered for this email document.
    /// </summary>
    public ConcurrentDictionary<EmailLibraries, int> Libraries { get; } = new();

    /// <summary>
    /// Collection of errors that occurred during email generation.
    /// </summary>
    public List<string> Errors { get; } = new();

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