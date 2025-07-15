namespace HtmlForgeX;

/// <summary>
/// Pagination styles for DataTables
/// </summary>
public enum DataTablesPagingType
{
    /// <summary>Simple 'Previous' and 'Next' buttons only</summary>
    Simple,

    /// <summary>Simple with page numbers</summary>
    SimpleNumbers,

    /// <summary>Full pagination with all controls</summary>
    Full,

    /// <summary>Full pagination with page numbers</summary>
    FullNumbers,

    /// <summary>First, Previous, Next, Last buttons</summary>
    FirstLastNumbers,

    /// <summary>Ellipsis pagination for large page counts</summary>
    Ellipsis
}