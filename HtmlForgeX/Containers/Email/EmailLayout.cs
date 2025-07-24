namespace HtmlForgeX;

/// <summary>
/// Centralized layout configuration for email components.
/// Ensures consistent spacing and alignment across all email elements.
/// </summary>
public static class EmailLayout {

    /// <summary>
    /// Standard container padding for EmailBox elements.
    /// This is the base padding applied to email content containers.
    /// </summary>
    public static string ContainerPadding { get; set; } = "12px";

    /// <summary>
    /// Content padding for text and other elements inside containers.
    /// Provides inner spacing for readability.
    /// </summary>
    public static string ContentPadding { get; set; } = "8px";

    /// <summary>
    /// Table cell padding (vertical) for spacing between rows.
    /// </summary>
    public static string TableCellPaddingVertical { get; set; } = "8px";

    /// <summary>
    /// Table cell padding (horizontal) for spacing within cells.
    /// </summary>
    public static string TableCellPaddingHorizontal { get; set; } = "8px";

    /// <summary>
    /// Standard spacing between EmailBox elements.
    /// </summary>
    public static string BoxSpacing { get; set; } = "12px";

    /// <summary>
    /// Standard spacing between child elements within a container.
    /// </summary>
    public static string ChildSpacing { get; set; } = "12px";

    /// <summary>
    /// Gets the complete table cell padding string combining vertical and horizontal.
    /// </summary>
    public static string GetTableCellPadding() {
        return $"{TableCellPaddingVertical} {TableCellPaddingHorizontal}";
    }

    /// <summary>
    /// Gets the complete container padding for EmailBox elements.
    /// </summary>
    public static string GetContainerPadding() {
        return ContainerPadding;
    }

    /// <summary>
    /// Gets content padding that aligns with container padding.
    /// Used for text and other elements to maintain consistent alignment.
    /// </summary>
    public static string GetContentPadding() {
        return ContentPadding;
    }

    /// <summary>
    /// Sets global padding for all email components. Maintains alignment consistency.
    /// </summary>
    /// <param name="padding">The padding value (e.g., "8px", "16px")</param>
    public static void SetGlobalPadding(string padding) {
        ContainerPadding = padding;
        // Set proportional inner padding for readability
        var innerPadding = padding == "12px" ? "8px" :
                          padding == "16px" ? "12px" :
                          padding == "8px" ? "6px" : "8px";
        TableCellPaddingVertical = innerPadding;
        ContentPadding = innerPadding;
        TableCellPaddingHorizontal = innerPadding;
        BoxSpacing = padding;
        ChildSpacing = padding;
    }

    /// <summary>
    /// Sets compact spacing (8px) for tighter layouts.
    /// </summary>
    public static void SetCompactSpacing() {
        SetGlobalPadding("8px");
    }

    /// <summary>
    /// Sets generous spacing (16px) for more spacious layouts.
    /// </summary>
    public static void SetGenerousSpacing() {
        SetGlobalPadding("16px");
    }

    /// <summary>
    /// Resets all configuration to default values (12px).
    /// </summary>
    public static void ResetToDefaults() {
        SetGlobalPadding("12px");
    }
}