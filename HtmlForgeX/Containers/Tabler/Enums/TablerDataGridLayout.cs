namespace HtmlForgeX;

/// <summary>
/// Defines layout options for DataGrid components.
/// </summary>
public enum TablerDataGridLayout {
    /// <summary>Default stacked layout</summary>
    Default,
    /// <summary>Compact layout with reduced spacing</summary>
    Compact,
    /// <summary>Spacious layout with increased spacing</summary>
    Spacious,
    /// <summary>Horizontal layout for wide screens</summary>
    Horizontal,
    /// <summary>Custom layout with user-defined spacing</summary>
    Custom
}

/// <summary>
/// Defines content alignment options for DataGrid items.
/// </summary>
public enum TablerDataGridContentAlignment {
    /// <summary>Left-aligned content</summary>
    Left,
    /// <summary>Center-aligned content</summary>
    Center,
    /// <summary>Right-aligned content</summary>
    Right,
    /// <summary>Justified content (full width)</summary>
    Justified
}

/// <summary>
/// Defines responsive behavior for DataGrid components.
/// </summary>
public enum TablerDataGridResponsive {
    /// <summary>No responsive behavior</summary>
    None,
    /// <summary>Stack on mobile devices</summary>
    Mobile,
    /// <summary>Stack on tablets and smaller</summary>
    Tablet,
    /// <summary>Always stacked layout</summary>
    Always,
    /// <summary>Responsive with custom breakpoints</summary>
    Custom
}

/// <summary>
/// Defines title width options for DataGrid items.
/// </summary>
public enum TablerDataGridTitleWidth {
    /// <summary>Auto width based on content</summary>
    Auto,
    /// <summary>Narrow width (120px)</summary>
    Narrow,
    /// <summary>Medium width (160px)</summary>
    Medium,
    /// <summary>Wide width (200px)</summary>
    Wide,
    /// <summary>Extra wide width (240px)</summary>
    ExtraWide,
    /// <summary>Custom width</summary>
    Custom
}

public static class TablerDataGridLayoutExtensions {
    /// <summary>
    /// Gets the CSS classes for the specified layout.
    /// </summary>
    /// <param name="layout">The layout enum value.</param>
    /// <returns>CSS classes as string.</returns>
    public static string ToCssClasses(this TablerDataGridLayout layout) {
        return layout switch {
            TablerDataGridLayout.Default => "datagrid",
            TablerDataGridLayout.Compact => "datagrid datagrid-compact",
            TablerDataGridLayout.Spacious => "datagrid datagrid-spacious",
            TablerDataGridLayout.Horizontal => "datagrid datagrid-horizontal",
            TablerDataGridLayout.Custom => "datagrid",
            _ => "datagrid"
        };
    }

    /// <summary>
    /// Converts content alignment to CSS value.
    /// </summary>
    /// <param name="alignment">The alignment enum value.</param>
    /// <returns>CSS alignment value as string.</returns>
    public static string ToCssValue(this TablerDataGridContentAlignment alignment) {
        return alignment switch {
            TablerDataGridContentAlignment.Left => "left",
            TablerDataGridContentAlignment.Center => "center",
            TablerDataGridContentAlignment.Right => "right",
            TablerDataGridContentAlignment.Justified => "justify",
            _ => "left"
        };
    }

    /// <summary>
    /// Converts title width to CSS value.
    /// </summary>
    /// <param name="width">The width enum value.</param>
    /// <returns>CSS width value as string.</returns>
    public static string ToCssValue(this TablerDataGridTitleWidth width) {
        return width switch {
            TablerDataGridTitleWidth.Auto => "auto",
            TablerDataGridTitleWidth.Narrow => "120px",
            TablerDataGridTitleWidth.Medium => "160px",
            TablerDataGridTitleWidth.Wide => "200px",
            TablerDataGridTitleWidth.ExtraWide => "240px",
            TablerDataGridTitleWidth.Custom => "auto",
            _ => "auto"
        };
    }

    /// <summary>
    /// Gets the responsive CSS classes.
    /// </summary>
    /// <param name="responsive">The responsive enum value.</param>
    /// <returns>CSS classes as string.</returns>
    public static string ToResponsiveClasses(this TablerDataGridResponsive responsive) {
        return responsive switch {
            TablerDataGridResponsive.None => "",
            TablerDataGridResponsive.Mobile => "datagrid-responsive-sm",
            TablerDataGridResponsive.Tablet => "datagrid-responsive-md",
            TablerDataGridResponsive.Always => "datagrid-responsive",
            TablerDataGridResponsive.Custom => "",
            _ => ""
        };
    }
}