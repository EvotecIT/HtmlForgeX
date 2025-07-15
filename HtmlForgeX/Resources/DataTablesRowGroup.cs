namespace HtmlForgeX.Resources;

/// <summary>
/// Library descriptor for DataTables RowGroup extension.
/// </summary>
internal class DataTablesRowGroup : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="DataTablesRowGroup"/> class.
    /// </summary>
    public DataTablesRowGroup() {
        Header = new LibraryLinks {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/datatables.net-rowgroup@1.5.0/js/dataTables.rowGroup.min.js",
                "https://cdn.jsdelivr.net/npm/datatables.net-rowgroup-bs5@1.5.0/js/rowGroup.bootstrap5.min.js"
            ],
            Js = [
                "dataTables.rowGroup.min.js",
                "rowGroup.bootstrap5.min.js"
            ],
            CssLink = ["https://cdn.jsdelivr.net/npm/datatables.net-rowgroup-bs5@1.5.0/css/rowGroup.bootstrap5.min.css"],
            Css = ["rowGroup.bootstrap5.min.css"]
        };
        Comment = "DataTables RowGroup extension - Group rows by column values";
        LicenseLink = "https://www.datatables.net/license/mit";
        License = "MIT";
        SourceCodes = "https://github.com/DataTables/RowGroup";
    }
}