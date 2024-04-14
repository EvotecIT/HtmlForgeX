namespace HtmlForgeX.Resources;

internal class Tabler : Library {
    public Tabler() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/@tabler/core@1.0.0-beta20/dist/css/tabler.min.css"],
            JsLink = ["https://cdn.jsdelivr.net/npm/@tabler/core@1.0.0-beta20/dist/js/tabler.min.js"]
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
