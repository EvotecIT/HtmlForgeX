namespace HtmlForgeX.Resources;

/// <summary>
/// Provides metadata and asset links for the Bootstrap framework which supplies
/// a wide variety of responsive layout and component utilities.
/// </summary>
public class Bootstrap : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="Bootstrap"/> class.
    /// </summary>
    public Bootstrap() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"],
            JsLink = ["https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"],
            Js = ["bootstrap.bundle.min.js"],
            Css = ["bootstrap.min.css"]
        };
        Comment = "Bootstrap library";
        LicenseLink = "https://github.com/twbs/bootstrap/blob/main/LICENSE";
        License = "MIT";
        SourceCodes = "https://github.com/twbs/bootstrap/";
        Default = true;
        Email = false;
    }
}
