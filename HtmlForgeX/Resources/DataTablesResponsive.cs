namespace HtmlForgeX.Resources;

/// <summary>
/// Library descriptor for DataTables Responsive extension.
/// </summary>
internal class DataTablesResponsive : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="DataTablesResponsive"/> class.
    /// </summary>
    public DataTablesResponsive() {
        Header = new LibraryLinks {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/datatables.net-responsive@3.0.2/js/dataTables.responsive.min.js",
                "https://cdn.jsdelivr.net/npm/datatables.net-responsive-bs5@3.0.2/js/responsive.bootstrap5.min.js"
            ],
            Js = [
                "dataTables.responsive.min.js",
                "responsive.bootstrap5.min.js"
            ],
            CssLink = ["https://cdn.jsdelivr.net/npm/datatables.net-responsive-bs5@3.0.2/css/responsive.bootstrap5.min.css"],
            Css = ["responsive.bootstrap5.min.css"]
        };
        Comment = "DataTables Responsive extension - Mobile-friendly responsive tables";
        LicenseLink = "https://www.datatables.net/license/mit";
        License = "MIT";
        SourceCodes = "https://github.com/DataTables/Responsive";
    }
}