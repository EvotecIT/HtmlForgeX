namespace HtmlForgeX.Resources;

/// <summary>
/// Library descriptor for DataTables SearchBuilder extension.
/// </summary>
internal class DataTablesSearchBuilder : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="DataTablesSearchBuilder"/> class.
    /// </summary>
    public DataTablesSearchBuilder() {
        Header = new LibraryLinks {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/datatables.net-searchbuilder@1.7.1/js/dataTables.searchBuilder.min.js",
                "https://cdn.jsdelivr.net/npm/datatables.net-searchbuilder-bs5@1.7.1/js/searchBuilder.bootstrap5.min.js",
                "https://cdn.jsdelivr.net/npm/datatables.net-datetime@1.5.2/js/dataTables.dateTime.min.js"
            ],
            Js = [
                "dataTables.searchBuilder.min.js",
                "searchBuilder.bootstrap5.min.js",
                "dataTables.dateTime.min.js"
            ],
            CssLink = [
                "https://cdn.jsdelivr.net/npm/datatables.net-searchbuilder-bs5@1.7.1/css/searchBuilder.bootstrap5.min.css",
                "https://cdn.jsdelivr.net/npm/datatables.net-datetime@1.5.2/css/dataTables.dateTime.min.css"
            ],
            Css = [
                "searchBuilder.bootstrap5.min.css",
                "dataTables.dateTime.min.css"
            ]
        };
        Comment = "DataTables SearchBuilder extension - Advanced search interface";
        LicenseLink = "https://www.datatables.net/license/mit";
        License = "MIT";
        SourceCodes = "https://github.com/DataTables/SearchBuilder";
    }
}