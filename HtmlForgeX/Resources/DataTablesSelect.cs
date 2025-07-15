namespace HtmlForgeX.Resources;

/// <summary>
/// Library descriptor for DataTables Select extension.
/// </summary>
internal class DataTablesSelect : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="DataTablesSelect"/> class.
    /// </summary>
    public DataTablesSelect() {
        Header = new LibraryLinks {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/datatables.net-select@2.0.3/js/dataTables.select.min.js",
                "https://cdn.jsdelivr.net/npm/datatables.net-select-bs5@2.0.3/js/select.bootstrap5.min.js"
            ],
            Js = [
                "dataTables.select.min.js",
                "select.bootstrap5.min.js"
            ],
            CssLink = ["https://cdn.jsdelivr.net/npm/datatables.net-select-bs5@2.0.3/css/select.bootstrap5.min.css"],
            Css = ["select.bootstrap5.min.css"]
        };
        Comment = "DataTables Select extension - Row and cell selection";
        LicenseLink = "https://www.datatables.net/license/mit";
        License = "MIT";
        SourceCodes = "https://github.com/DataTables/Select";
    }
}