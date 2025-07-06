namespace HtmlForgeX.Resources;

internal class TablerThemes : Library {
    public TablerThemes() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/@tabler/core@1.3.0/dist/css/tabler-themes.min.css"],
            Css = ["tabler-themes.min.css"]
        };
        Comment = "Tabler Themes library - Theme system support with CSS custom properties";
        LicenseLink = "https://github.com/tabler/tabler/blob/dev/LICENSE";
        License = "MIT";
        Website = "https://tabler.io/";
        SourceCodes = "https://github.com/tabler/tabler";
        Default = false;
        Email = false;
    }
}