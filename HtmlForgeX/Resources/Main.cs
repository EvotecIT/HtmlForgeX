namespace HtmlForgeX.Resources;

/// <summary>
/// Base styling library used across documents.
/// </summary>
internal class Primary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="Primary"/> class.
    /// </summary>
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

    /// <summary>
    /// Loads a custom font file and adds it to the library styles.
    /// </summary>
    /// <param name="fontFamily">Font family name.</param>
    /// <param name="fontFilePath">Path to the font file.</param>
    public void LoadFont(string fontFamily, string fontFilePath) {
        Header.CssStyle.Add(FontLoader.LoadFontAsStyle(fontFamily, fontFilePath));
    }

    /// <summary>
    /// Loads a custom font stream and adds it to the library styles.
    /// </summary>
    /// <param name="fontFamily">Font family name.</param>
    /// <param name="fontStream">Stream containing the font.</param>
    /// <param name="extension">Font file extension.</param>
    public void LoadFont(string fontFamily, Stream fontStream, string extension) {
        Header.CssStyle.Add(FontLoader.LoadFontAsStyle(fontFamily, fontStream, extension));
    }
}
