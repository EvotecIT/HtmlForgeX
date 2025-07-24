namespace HtmlForgeX.Resources;

internal class TomSelectLibrary : Library {
    public TomSelectLibrary() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/tom-select@2.2.2/dist/css/tom-select.bootstrap5.min.css"],
            Css = ["tom-select.bootstrap5.min.css"],
            JsLink = ["https://cdn.jsdelivr.net/npm/tom-select@2.2.2/dist/js/tom-select.base.min.js"],
            Js = ["tom-select.base.min.js"]
        };
        Comment = "Tom Select dropdowns";
        LicenseLink = "https://github.com/orchidjs/tom-select/blob/master/LICENSE";
        License = "MIT";
        SourceCodes = "https://github.com/orchidjs/tom-select";
    }
}