namespace HtmlForgeX.Resources;

/// <summary>
/// Library descriptor for DataTables integration.
/// </summary>
internal class DataTables : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="DataTables"/> class.
    /// </summary>
    public DataTables() {
        Header = new LibraryLinks {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/datatables.net@2.0.5/js/dataTables.min.js",
                "https://cdn.jsdelivr.net/npm/datatables.net-bs5@2.0.5/js/dataTables.bootstrap5.min.js"
            ],
            Js = ["dataTables.min.js", "dataTables.bootstrap5.min.js"],
            CssLink = ["https://cdn.jsdelivr.net/npm/datatables.net-bs5@2.0.5/css/dataTables.bootstrap5.min.css"],
            Css = ["dataTables.bootstrap5.min.css"],
            CssStyle = []
        };
        Comment = "DataTables library";
        LicenseLink = "https://www.datatables.net/license/mit";
        License = "MIT";
        SourceCodes = "";
    }
}
