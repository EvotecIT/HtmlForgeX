using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX.Resources;

/// <summary>
/// Library descriptor for Tabler icon fonts.
/// </summary>
internal class TablerIconLibrary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="TablerIconLibrary"/> class.
    /// </summary>
    public TablerIconLibrary() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/@tabler/icons-webfont@latest/dist/tabler-icons.min.css"],
            Css = ["tabler-icons.min.css"],
            JsLink = [],
            Js = []
        };
        Comment = "Tabler Icon library";
        LicenseLink = "https://github.com/tabler/tabler-icons/blob/main/LICENSE";
        License = "MIT";
        Website = "https://tablericons.com/";
        SourceCodes = "https://github.com/tabler/tabler-icons";
        Default = true;
        Email = false;
    }
}
