namespace HtmlForgeX.Resources;

/// <summary>
/// Library descriptor for DataTables Buttons extension.
/// </summary>
internal class DataTablesButtons : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="DataTablesButtons"/> class.
    /// </summary>
    public DataTablesButtons() {
        Header = new LibraryLinks {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/datatables.net-buttons@3.0.2/js/dataTables.buttons.min.js",
                "https://cdn.jsdelivr.net/npm/datatables.net-buttons-bs5@3.0.2/js/buttons.bootstrap5.min.js",
                "https://cdnjs.cloudflare.com/ajax/libs/jszip/3.10.1/jszip.min.js",
                "https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.2.7/pdfmake.min.js",
                "https://cdnjs.cloudflare.com/ajax/libs/pdfmake/0.2.7/vfs_fonts.js",
                "https://cdn.jsdelivr.net/npm/datatables.net-buttons@3.0.2/js/buttons.html5.min.js",
                "https://cdn.jsdelivr.net/npm/datatables.net-buttons@3.0.2/js/buttons.print.min.js",
                "https://cdn.jsdelivr.net/npm/datatables.net-buttons@3.0.2/js/buttons.colVis.min.js"
            ],
            Js = [
                "dataTables.buttons.min.js",
                "buttons.bootstrap5.min.js",
                "jszip.min.js",
                "pdfmake.min.js",
                "vfs_fonts.js",
                "buttons.html5.min.js",
                "buttons.print.min.js",
                "buttons.colVis.min.js"
            ],
            CssLink = ["https://cdn.jsdelivr.net/npm/datatables.net-buttons-bs5@3.0.2/css/buttons.bootstrap5.min.css"],
            Css = ["buttons.bootstrap5.min.css"]
        };
        Comment = "DataTables Buttons extension - Export and column visibility controls";
        LicenseLink = "https://www.datatables.net/license/mit";
        License = "MIT";
        SourceCodes = "https://github.com/DataTables/Buttons";
    }
}