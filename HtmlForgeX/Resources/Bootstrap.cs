namespace HtmlForgeX.Resources;

public class Bootstrap : Library {
    public Bootstrap() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"],
            JsLink = ["https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"]
        };
        Comment = "Bootstrap library";
        LicenseLink = "https://github.com/twbs/bootstrap/blob/main/LICENSE";
        License = "MIT";
        SourceCodes = "https://github.com/twbs/bootstrap/";
        Default = true;
        Email = false;
    }
}
