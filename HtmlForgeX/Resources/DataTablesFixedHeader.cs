namespace HtmlForgeX.Resources;

/// <summary>
/// Library descriptor for DataTables FixedHeader extension.
/// </summary>
internal class DataTablesFixedHeader : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="DataTablesFixedHeader"/> class.
    /// </summary>
    public DataTablesFixedHeader() {
        Header = new LibraryLinks {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/datatables.net-fixedheader@4.0.1/js/dataTables.fixedHeader.min.js",
                "https://cdn.jsdelivr.net/npm/datatables.net-fixedheader-bs5@4.0.1/js/fixedHeader.bootstrap5.min.js"
            ],
            Js = [
                "dataTables.fixedHeader.min.js",
                "fixedHeader.bootstrap5.min.js"
            ],
            CssLink = ["https://cdn.jsdelivr.net/npm/datatables.net-fixedheader-bs5@4.0.1/css/fixedHeader.bootstrap5.min.css"],
            Css = ["fixedHeader.bootstrap5.min.css"]
        };
        Comment = "DataTables FixedHeader extension - Keep headers visible while scrolling";
        LicenseLink = "https://www.datatables.net/license/mit";
        License = "MIT";
        SourceCodes = "https://github.com/DataTables/FixedHeader";
    }
}