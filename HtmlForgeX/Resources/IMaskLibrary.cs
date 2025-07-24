namespace HtmlForgeX.Resources;

internal class IMaskLibrary : Library {
    public IMaskLibrary() {
        Header = new LibraryLinks {
            JsLink = ["https://cdn.jsdelivr.net/npm/imask@7.6.0/dist/imask.min.js"],
            Js = ["imask.min.js"]
        };
        Comment = "IMask input masking";
        LicenseLink = "https://github.com/uNmAnNeR/imaskjs/blob/master/LICENSE";
        License = "MIT";
        SourceCodes = "https://github.com/uNmAnNeR/imaskjs";
    }
}