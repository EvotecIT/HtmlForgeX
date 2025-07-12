using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX.Resources;
internal class TablerIconLibrary : Library {
    public TablerIconLibrary() {
        Header = new LibraryLinks {
            CssLink = ["https://cdn.jsdelivr.net/npm/@tabler/icons-webfont@3.31.0/dist/tabler-icons.min.css"],
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
