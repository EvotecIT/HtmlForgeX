namespace HtmlForgeX.Resources;

public class Jquery : Library {
    public Jquery() {
        Header = new LibraryLinks {
            JsLink = ["https://cdn.jsdelivr.net/npm/jquery@3.7.1/dist/jquery.min.js"]
        };
        Comment = "Jquery library";
        LicenseLink = "https://jquery.org/license/";
        License = "MIT";
        SourceCodes = "https://github.com/jquery/jquery";
    }
}
