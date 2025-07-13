namespace HtmlForgeX.Resources;
public class QuillLibrary : Library {
    public QuillLibrary() {
        Header = new LibraryLinks {
            CssLink = [
                "https://cdn.jsdelivr.net/npm/quill@1.3.7/dist/quill.snow.css"
            ],
            Css = ["quill.snow.css"],
            JsLink = [
                "https://cdn.jsdelivr.net/npm/quill@1.3.7/dist/quill.min.js"
            ],
            Js = ["quill.min.js"]
        };
        Comment = "Quill rich text editor";
        LicenseLink = "https://github.com/quilljs/quill/blob/develop/LICENSE";
        License = "BSD-3-Clause";
        SourceCodes = "https://github.com/quilljs/quill";
    }
}
