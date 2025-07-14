namespace HtmlForgeX;
/// <summary>
/// Determines how libraries are loaded.
/// </summary>
public enum LibraryMode {
    /// <summary>
    /// Load libraries from online sources.
    /// </summary>
    Online,
    /// <summary>
    /// Do not load libraries; assume they are provided offline.
    /// </summary>
    Offline,
    /// <summary>
    /// Load libraries from local files bundled with the output.
    /// </summary>
    OfflineWithFiles
}