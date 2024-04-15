using System.Text;

namespace HtmlForgeX;

public class HtmlDocument : HtmlElement {
    public HtmlHead Head = new HtmlHead();
    public HtmlBody Body = new HtmlBody();

    public LibraryMode LibraryMode {
        get => GlobalStorage.LibraryMode;
        set => GlobalStorage.LibraryMode = value;
    }

    public HtmlDocument(LibraryMode? librariesMode = null) {
        if (librariesMode != null) {
            GlobalStorage.LibraryMode = librariesMode.Value;
        }
    }

    public void Save(string path, bool openInBrowser = false) {
        var countErrors = GlobalStorage.Errors.Count;
        if (countErrors > 0) {
            Console.WriteLine($"There were {countErrors} found during generation of HTML.");
            //foreach (var error in GlobalStorage.Errors) {
            //    Console.WriteLine(error);
            //}
        }

        System.IO.File.WriteAllText(path, this.ToString());
        Helpers.Open(path, openInBrowser);
    }

    public override string ToString() {
        StringBuilder html = new StringBuilder();

        html.AppendLine("<!DOCTYPE html>");
        html.AppendLine("<html>");
        html.AppendLine(this.Head.ToString());
        html.AppendLine(this.Body.ToString());
        html.AppendLine("</html>");

        return html.ToString();
    }

    public void AddLibrary(Libraries library) {
        GlobalStorage.Libraries.Add(library);
    }

    public void AddLibrary(Library library) {
        if (GlobalStorage.LibraryMode == LibraryMode.Online) {
            foreach (var link in library.Header.CssLink) {
                this.Head.AddCssLink(link);
            }

            foreach (var link in library.Header.JsLink) {
                this.Head.AddJsLink(link);
            }
        } else if (GlobalStorage.LibraryMode == LibraryMode.Offline) {
            foreach (var css in library.Header.Css) {
                var cssContent = System.IO.File.ReadAllText(css);
                this.Head.AddCssInline(cssContent);
            }

            foreach (var js in library.Header.JS) {
                var jsContent = System.IO.File.ReadAllText(js);
                this.Head.AddJsInline(jsContent);
            }
        }
    }
}
