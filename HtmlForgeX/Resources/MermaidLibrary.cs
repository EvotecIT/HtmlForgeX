using System.Collections.Generic;

namespace HtmlForgeX.Resources;
public class MermaidLibrary : Library {
    public MermaidLibrary() {
        Header = new LibraryLinks {
            JsLink = [
                "https://cdn.jsdelivr.net/npm/mermaid@10/dist/mermaid.min.js"
            ],
            Js = [
                "mermaid.min.js"
            ],
            JsScript = ["mermaid.initialize({ startOnLoad: false });"]
        };
        Comment = "Mermaid diagramming library";
        LicenseLink = "https://github.com/mermaid-js/mermaid/blob/develop/LICENSE";
        License = "MIT";
        SourceCodes = "https://github.com/mermaid-js/mermaid";
        Default = false;
        Email = false;
    }
}
