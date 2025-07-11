namespace HtmlForgeX;

/// <summary>
/// Extension methods for EmailTextWrapMode enum to convert to CSS properties.
/// </summary>
public static class EmailTextWrapModeExtensions
{
    /// <summary>
    /// Converts the EmailTextWrapMode to CSS properties for text wrapping.
    /// </summary>
    /// <param name="wrapMode">The wrap mode to convert.</param>
    /// <returns>CSS properties as a string for the specified wrap mode.</returns>
    public static string ToCssProperties(this EmailTextWrapMode wrapMode)
    {
        return wrapMode switch
        {
            EmailTextWrapMode.Default => "word-wrap: break-word; overflow-wrap: break-word; word-break: normal",

            // Natural: Allow breaking but prefer word boundaries - more email client friendly
            EmailTextWrapMode.Natural => "word-wrap: break-word; overflow-wrap: break-word; word-break: normal; white-space: normal",

            EmailTextWrapMode.Aggressive => "word-break: break-all; overflow-wrap: break-word; word-wrap: break-word",

            EmailTextWrapMode.Preserve => "white-space: pre; overflow-wrap: normal; word-break: normal",

            EmailTextWrapMode.Hyphenated => "word-wrap: break-word; overflow-wrap: break-word; hyphens: auto; word-break: normal",

            // Smart: Use better line-height and letter-spacing to make text fit better
            EmailTextWrapMode.Smart => "word-wrap: break-word; overflow-wrap: break-word; word-break: normal; letter-spacing: -0.02em; line-height: 1.4",

            _ => "word-wrap: break-word; overflow-wrap: break-word; word-break: normal"
        };
    }

    /// <summary>
    /// Gets a description of what the wrap mode does.
    /// </summary>
    /// <param name="wrapMode">The wrap mode to describe.</param>
    /// <returns>A human-readable description of the wrap mode behavior.</returns>
    public static string GetDescription(this EmailTextWrapMode wrapMode)
    {
        return wrapMode switch
        {
            EmailTextWrapMode.Default => "Allows breaking anywhere in long words to fit containers",
            EmailTextWrapMode.Natural => "Only breaks at natural word boundaries, keeps method names intact",
            EmailTextWrapMode.Aggressive => "Breaks anywhere, even mid-character, for very narrow spaces",
            EmailTextWrapMode.Preserve => "Maintains exact whitespace and prevents wrapping",
            EmailTextWrapMode.Hyphenated => "Breaks with hyphens where possible (email client dependent)",
            EmailTextWrapMode.Smart => "Tries to keep method names and camelCase intact",
            _ => "Default wrapping behavior"
        };
    }

    /// <summary>
    /// Gets example use cases for the wrap mode.
    /// </summary>
    /// <param name="wrapMode">The wrap mode to get examples for.</param>
    /// <returns>Example use cases as a string.</returns>
    public static string GetExamples(this EmailTextWrapMode wrapMode)
    {
        return wrapMode switch
        {
            EmailTextWrapMode.Default => "General text content, paragraphs, descriptions",
            EmailTextWrapMode.Natural => "Code samples, method names like 'ConfigureImageOptimization', URLs",
            EmailTextWrapMode.Aggressive => "Very narrow columns, mobile layouts, tight spacing",
            EmailTextWrapMode.Preserve => "Code blocks, ASCII art, exact formatting requirements",
            EmailTextWrapMode.Hyphenated => "Professional documents, long technical terms",
            EmailTextWrapMode.Smart => "API documentation, technical guides, code examples",
            _ => "General purpose text"
        };
    }

    /// <summary>
    /// Processes text content to insert soft line breaks at better positions for method chains.
    /// This provides a programmatic solution for better text wrapping in email clients.
    /// </summary>
    /// <param name="text">The text to process.</param>
    /// <param name="wrapMode">The wrap mode to apply.</param>
    /// <returns>Processed text with soft line breaks inserted where appropriate.</returns>
    public static string ProcessTextForWrapping(this string text, EmailTextWrapMode wrapMode)
    {
        if (string.IsNullOrEmpty(text) || wrapMode == EmailTextWrapMode.Preserve)
            return text;

        return wrapMode switch
        {
            EmailTextWrapMode.Natural => InsertSoftBreaksAtNaturalBoundaries(text),
            EmailTextWrapMode.Smart => InsertSoftBreaksForTechnicalContent(text),
            _ => text
        };
    }

        private static string InsertSoftBreaksAtNaturalBoundaries(string text)
    {
        // Insert soft line breaks after dots in method chains
        // This allows breaking at method boundaries like ConfigureImageOptimization().SetMaxEmbedFileSize()
        // Works with HTML-encoded content
        return text.Replace("().", "().<wbr>");
    }

    private static string InsertSoftBreaksForTechnicalContent(string text)
    {
        // More aggressive soft breaking for technical content
        var result = text;

        // Break after method calls with parentheses
        result = result.Replace("().", "().<wbr>");

        // Break before common method prefixes to make them more visible
        result = result.Replace(".Configure", ".<wbr>Configure");
        result = result.Replace(".Enable", ".<wbr>Enable");
        result = result.Replace(".Set", ".<wbr>Set");

        return result;
    }
}