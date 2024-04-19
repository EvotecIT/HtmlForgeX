namespace HtmlForgeX.Resources;

internal class DataTables : Library {
    public DataTables() {
        Header = new LibraryLinks {
            JsLink = [
                "https://cdn.datatables.net/2.0.3/js/dataTables.min.js",
                "https://cdn.datatables.net/2.0.3/js/dataTables.bootstrap5.min.js"
            ],
            JS = [@"var diagramTracker = {};"],
            CssLink = ["https://cdn.datatables.net/2.0.3/css/dataTables.bootstrap5.min.css"],
            CssStyle = [
                new Style {
                    Selector = ".diagram",
                    Properties = new Dictionary<string, string> {
                        { "min-height", "200px" },
                        { "width", "100%" },
                        { "height", "300px" },
                        { "border", "0px solid unset" }
                    }
                },
                new Style {
                    Selector = ".vis-network:focus",
                    Properties = new Dictionary<string, string> { { "outline", "none" } }
                }
            ]
        };
        Comment = "DataTables library";
        LicenseLink = "https://www.datatables.net/license/mit";
        License = "MIT";
        SourceCodes = "";
    }
}
