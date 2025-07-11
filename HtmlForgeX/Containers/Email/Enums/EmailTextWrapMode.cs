namespace HtmlForgeX;

/// <summary>
/// Defines different text wrapping behaviors for email components.
/// Controls how long words and method names break and wrap within containers.
/// </summary>
public enum EmailTextWrapMode
{
    /// <summary>
    /// Default wrapping - allows breaking anywhere in long words.
    /// Uses: word-wrap: break-word; overflow-wrap: break-word;
    /// Best for: General text content that needs to fit in containers.
    /// </summary>
    Default,

    /// <summary>
    /// Natural wrapping - only breaks at natural word boundaries.
    /// Uses: word-break: normal; overflow-wrap: normal;
    /// Best for: Code, method names, URLs that should stay intact.
    /// Example: "ConfigureImageOptimization" stays on one line if possible.
    /// </summary>
    Natural,

    /// <summary>
    /// Aggressive wrapping - breaks anywhere, even mid-character.
    /// Uses: word-break: break-all; overflow-wrap: break-word;
    /// Best for: Very narrow columns or when space is extremely limited.
    /// </summary>
    Aggressive,

    /// <summary>
    /// Preserve formatting - maintains exact whitespace and prevents wrapping.
    /// Uses: white-space: pre; overflow-wrap: normal;
    /// Best for: Code blocks, preformatted text, exact spacing requirements.
    /// </summary>
    Preserve,

    /// <summary>
    /// Hyphenated wrapping - breaks with hyphens where possible.
    /// Uses: word-wrap: break-word; hyphens: auto;
    /// Best for: Professional documents, long words that benefit from hyphenation.
    /// Note: Hyphenation support varies by email client.
    /// </summary>
    Hyphenated,

    /// <summary>
    /// Smart wrapping - tries to keep method names and camelCase intact.
    /// Uses: word-break: keep-all; overflow-wrap: break-word;
    /// Best for: Technical documentation, API references, code examples.
    /// </summary>
    Smart
}