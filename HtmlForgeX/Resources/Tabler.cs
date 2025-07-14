namespace HtmlForgeX.Resources;

/// <summary>
/// Core Tabler CSS/JS framework library descriptor.
/// </summary>
internal class Tabler : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="Tabler"/> class.
    /// </summary>
    public Tabler() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/@tabler/core@1.3.0/dist/css/tabler.min.css"],
            Css = ["tabler.min.css"],
            JsLink = ["https://cdn.jsdelivr.net/npm/@tabler/core@1.3.0/dist/js/tabler.min.js"],
            Js = ["tabler.min.js"]
        };
        Comment = "Tabler library";
        LicenseLink = "https://github.com/tabler/tabler/blob/dev/LICENSE";
        License = "MIT";
        Website = "https://tabler.io/";
        SourceCodes = "https://github.com/tabler/tabler";
        Default = true;
        Email = false;
    }
}
