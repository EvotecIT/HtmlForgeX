namespace HtmlForgeX.Resources;

/// <summary>
/// Library descriptor for DataTables FixedColumns extension.
/// </summary>
internal class DataTablesFixedColumns : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="DataTablesFixedColumns"/> class.
    /// </summary>
    public DataTablesFixedColumns() {
        Header = new LibraryLinks {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/datatables.net-fixedcolumns@5.0.1/js/dataTables.fixedColumns.min.js",
                "https://cdn.jsdelivr.net/npm/datatables.net-fixedcolumns-bs5@5.0.1/js/fixedColumns.bootstrap5.min.js"
            ],
            Js = [
                "dataTables.fixedColumns.min.js",
                "fixedColumns.bootstrap5.min.js"
            ],
            CssLink = ["https://cdn.jsdelivr.net/npm/datatables.net-fixedcolumns-bs5@5.0.1/css/fixedColumns.bootstrap5.min.css"],
            Css = ["fixedColumns.bootstrap5.min.css"]
        };
        Comment = "DataTables FixedColumns extension - Keep columns fixed while scrolling";
        LicenseLink = "https://www.datatables.net/license/mit";
        License = "MIT";
        SourceCodes = "https://github.com/DataTables/FixedColumns";
    }
}