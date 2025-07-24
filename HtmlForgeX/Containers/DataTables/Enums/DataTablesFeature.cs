namespace HtmlForgeX;

/// <summary>
/// DataTables feature toggles for enabling/disabling functionality
/// </summary>
public enum DataTablesFeature {
    /// <summary>Enable pagination controls</summary>
    Paging,

    /// <summary>Enable global search functionality</summary>
    Searching,

    /// <summary>Enable column sorting</summary>
    Ordering,

    /// <summary>Enable horizontal scrolling</summary>
    ScrollX,

    /// <summary>Enable vertical scrolling</summary>
    ScrollY,

    /// <summary>Enable state saving across sessions</summary>
    StateSave,

    /// <summary>Enable processing indicator</summary>
    Processing,

    /// <summary>Enable server-side processing</summary>
    ServerSide,

    /// <summary>Enable automatic column width calculation</summary>
    AutoWidth,

    /// <summary>Enable deferred rendering for performance</summary>
    DeferRender,

    /// <summary>Enable responsive design</summary>
    Responsive,

    /// <summary>Enable fixed header</summary>
    FixedHeader,

    /// <summary>Enable fixed columns</summary>
    FixedColumns,

    /// <summary>Enable row grouping</summary>
    RowGroup,

    /// <summary>Enable search builder</summary>
    SearchBuilder,

    /// <summary>Enable search panes</summary>
    SearchPanes,

    /// <summary>Enable column visibility controls</summary>
    ColVis,

    /// <summary>Enable buttons extension</summary>
    Buttons
}