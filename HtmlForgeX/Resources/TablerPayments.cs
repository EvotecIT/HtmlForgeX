namespace HtmlForgeX.Resources;

/// <summary>
/// Library descriptor for Tabler payment icon set.
/// </summary>
internal class TablerPayments : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="TablerPayments"/> class.
    /// </summary>
    public TablerPayments() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/@tabler/core@1.3.0/dist/css/tabler-payments.min.css"],
            Css = ["tabler-payments.min.css"]
        };
        Comment = "Tabler Payment Icons library - Payment provider logos";
        LicenseLink = "https://github.com/tabler/tabler/blob/dev/LICENSE";
        License = "MIT";
        Website = "https://tabler.io/";
        SourceCodes = "https://github.com/tabler/tabler";
        Default = false;
        Email = false;
    }
}