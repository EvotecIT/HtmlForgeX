namespace HtmlForgeX.Resources;

/// <summary>
/// Library descriptor for DataTables SearchPanes extension.
/// </summary>
internal class DataTablesSearchPanes : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="DataTablesSearchPanes"/> class.
    /// </summary>
    public DataTablesSearchPanes() {
        Header = new LibraryLinks {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/datatables.net-searchpanes@2.3.1/js/dataTables.searchPanes.min.js",
                "https://cdn.jsdelivr.net/npm/datatables.net-searchpanes-bs5@2.3.1/js/searchPanes.bootstrap5.min.js",
                "https://cdn.jsdelivr.net/npm/datatables.net-select@2.0.3/js/dataTables.select.min.js",
                "https://cdn.jsdelivr.net/npm/datatables.net-select-bs5@2.0.3/js/select.bootstrap5.min.js"
            ],
            Js = [
                "dataTables.searchPanes.min.js",
                "searchPanes.bootstrap5.min.js",
                "dataTables.select.min.js",
                "select.bootstrap5.min.js"
            ],
            CssLink = [
                "https://cdn.jsdelivr.net/npm/datatables.net-searchpanes-bs5@2.3.1/css/searchPanes.bootstrap5.min.css",
                "https://cdn.jsdelivr.net/npm/datatables.net-select-bs5@2.0.3/css/select.bootstrap5.min.css"
            ],
            Css = [
                "searchPanes.bootstrap5.min.css",
                "select.bootstrap5.min.css"
            ]
        };
        Comment = "DataTables SearchPanes extension - Faceted search interface";
        LicenseLink = "https://www.datatables.net/license/mit";
        License = "MIT";
        SourceCodes = "https://github.com/DataTables/SearchPanes";
    }
}