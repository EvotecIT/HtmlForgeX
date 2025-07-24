namespace HtmlForgeX.Resources;

/// <summary>
/// Library definition providing Quill assets, enabling rich text editing within
/// generated documents.
/// </summary>
public class QuillLibrary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuillLibrary"/> class.
    /// </summary>
    public QuillLibrary() {
        Header = new LibraryLinks {
            CssLink = [
                "https://cdn.jsdelivr.net/npm/quill@2.0.2/dist/quill.snow.css",
                "https://cdn.jsdelivr.net/npm/quill@2.0.2/dist/quill.bubble.css"
            ],
            Css = ["quill.snow.css", "quill.bubble.css"],
            JsLink = [
                "https://cdn.jsdelivr.net/npm/quill@2.0.2/dist/quill.js"
            ],
            Js = ["quill.js"]
        };
        Comment = "Quill rich text editor";
        LicenseLink = "https://github.com/quilljs/quill/blob/develop/LICENSE";
        License = "BSD-3-Clause";
        SourceCodes = "https://github.com/quilljs/quill";
    }
}