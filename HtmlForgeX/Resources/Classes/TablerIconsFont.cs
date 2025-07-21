namespace HtmlForgeX.Resources;

/// <summary>
/// Library descriptor for Tabler icon webfonts.
/// </summary>
internal class TablerIconsFont : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="TablerIconsFont"/> class.
    /// </summary>
    public TablerIconsFont() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/@tabler/icons-webfont@latest/dist/tabler-icons.min.css"],
            Css = ["tabler-icons.min.css"],
            JsLink = [],
            Js = []
        };
        Comment = "Tabler Icons Webfont library";
        LicenseLink = "https://github.com/tabler/tabler-icons/blob/main/LICENSE";
        License = "MIT";
        Website = "https://tablericons.com/";
        SourceCodes = "https://github.com/tabler/tabler-icons";
        Default = false;
        Email = false;
    }
}