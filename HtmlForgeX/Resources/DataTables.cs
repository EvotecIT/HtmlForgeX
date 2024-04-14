namespace HtmlForgeX.Resources;

internal class DataTables : Library {
    public DataTables() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.datatables.net/2.0.3/css/dataTables.bootstrap5.min.css"],
            JsLink = [
                "https://cdn.datatables.net/2.0.3/js/dataTables.min.js",
                "https://cdn.datatables.net/2.0.3/js/dataTables.bootstrap5.min.js"
            ]
        };
        Comment = "DataTables library";
        LicenseLink = "https://www.datatables.net/license/mit";
        License = "MIT";
        SourceCodes = "";
    }
}
