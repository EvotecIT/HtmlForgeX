namespace HtmlForgeX.Resources;

internal class TablerSocials : Library {
    public TablerSocials() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/@tabler/core@1.3.0/dist/css/tabler-socials.min.css"],
            Css = ["tabler-socials.min.css"]
        };
        Comment = "Tabler Social Icons library - Social media platform icons";
        LicenseLink = "https://github.com/tabler/tabler/blob/dev/LICENSE";
        License = "MIT";
        Website = "https://tabler.io/";
        SourceCodes = "https://github.com/tabler/tabler";
        Default = false;
        Email = false;
    }
}