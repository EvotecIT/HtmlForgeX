namespace HtmlForgeX.Resources;

/// <summary>
/// Library descriptor for Tabler flag icons.
/// </summary>
internal class TablerFlags : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="TablerFlags"/> class.
    /// </summary>
    public TablerFlags() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/@tabler/core@1.3.0/dist/css/tabler-flags.min.css"],
            Css = ["tabler-flags.min.css"]
        };
        Comment = "Tabler Flags library - Country flag icons";
        LicenseLink = "https://github.com/tabler/tabler/blob/dev/LICENSE";
        License = "MIT";
        Website = "https://tabler.io/";
        SourceCodes = "https://github.com/tabler/tabler";
        Default = false;
        Email = false;
    }
}