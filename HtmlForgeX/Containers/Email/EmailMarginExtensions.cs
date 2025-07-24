namespace HtmlForgeX;

/// <summary>
/// Validation helpers for margin values used in email components.
/// </summary>
public static class EmailMarginExtensions {
    private static readonly System.Text.RegularExpressions.Regex MarginRegex = new(
        "^(0|auto|[0-9]+(\\.[0-9]+)?(px|em|%))( (0|auto|[0-9]+(\\.[0-9]+)?(px|em|%))){0,3}$",
        System.Text.RegularExpressions.RegexOptions.Compiled);

    /// <summary>
    /// Validates that a margin string uses numeric values followed by px, em, or %.
    /// </summary>
    /// <param name="margin">Margin string to validate.</param>
    public static void ValidateMargin(this string margin) {
        if (string.IsNullOrWhiteSpace(margin) || !MarginRegex.IsMatch(margin)) {
            throw new System.ArgumentException(
                "Margin must be numeric values followed by px, em, or %, or 'auto', separated by spaces.",
                nameof(margin));
        }
    }
}