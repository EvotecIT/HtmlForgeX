namespace HtmlForgeX.Resources;

public class DataTablesRowGroupLibrary : Library
{
    public DataTablesRowGroupLibrary()
    {
        Header = new LibraryLinks
        {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/datatables.net-rowgroup@1.5.2/js/dataTables.rowGroup.min.js"
            ],
            Js = ["dataTables.rowGroup.min.js"]
        };
        Comment = "DataTables RowGroup extension";
        LicenseLink = "https://www.datatables.net/license/mit";
        License = "MIT";
    }
}
