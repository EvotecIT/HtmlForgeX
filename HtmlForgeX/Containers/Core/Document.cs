using System.Text;

namespace HtmlForgeX;

public class Document : Element {
    public Head Head = new Head();
    public Body Body = new Body();

    public LibraryMode LibraryMode {
        get => GlobalStorage.LibraryMode;
        set => GlobalStorage.LibraryMode = value;
    }

    public ThemeMode ThemeMode {
        get => GlobalStorage.ThemeMode;
        set => GlobalStorage.ThemeMode = value;
    }

    public string Path {
        get => GlobalStorage.Path;
        set => GlobalStorage.Path = value;
    }

    public string StylePath {
        get => GlobalStorage.StylePath;
        set => GlobalStorage.StylePath = value;
    }

    public string ScriptPath {
        get => GlobalStorage.ScriptPath;
        set => GlobalStorage.ScriptPath = value;
    }

    public Document(LibraryMode? librariesMode = null) {
        if (librariesMode != null) {
            GlobalStorage.LibraryMode = librariesMode.Value;
        }
    }

    public void Save(string path, bool openInBrowser = false, string scriptPath = "", string stylePath = "") {
        GlobalStorage.Path = path;
        if (!string.IsNullOrEmpty(scriptPath)) {
            GlobalStorage.ScriptPath = scriptPath;
        }

        if (!string.IsNullOrEmpty(stylePath)) {
            GlobalStorage.StylePath = stylePath;
        }

        var countErrors = GlobalStorage.Errors.Count;
        if (countErrors > 0) {
            Console.WriteLine($"There were {countErrors} found during generation of HTML.");
        }

        var directory = System.IO.Path.GetDirectoryName(path);
        if (!string.IsNullOrEmpty(directory)) {
            System.IO.Directory.CreateDirectory(directory);
        }
        File.WriteAllText(path, this.ToString());
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

            foreach (var js in library.Header.Js) {
                var jsContent = System.IO.File.ReadAllText(js);
                this.Head.AddJsInline(jsContent);
            }
        }
    }
}
