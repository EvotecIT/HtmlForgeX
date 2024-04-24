namespace HtmlForgeX.Resources;

internal class Primary : Library {
    public Primary() {
        Header = new LibraryLinks {
            CssStyle = new List<Style> {
                new Style {
                    Selector = "body",
                    Properties = new Dictionary<string, string> {
                        { "font-family", "'Roboto Condensed', sans-serif" },
                        { "font-size", "8pt" },
                        { "margin", "0px" }
                    }
                },
                new Style {
                    Selector = "input",
                    Properties = new Dictionary<string, string> {
                        { "font-size", "8pt" }
                    }
                },
                new Style {
                    Selector = ".main-section",
                    Properties = new Dictionary<string, string> {
                        { "margin-top", "0px" }
                    }
                }
            }

        };
        Comment = "Main definition, similar to PSWriteHTML";
        LicenseLink = "MIT";
    }
}
