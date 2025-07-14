namespace HtmlForgeX.Resources;

/// <summary>
/// Library definition providing Quill assets.
/// </summary>
public class QuillLibrary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuillLibrary"/> class.
    /// </summary>
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
