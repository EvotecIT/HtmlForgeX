using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace HtmlForgeX;

/// <summary>
/// Support class to help building HTMLForgeX without huge effort on maintaining CSS and JS files.
/// </summary>
public class LibraryDownloader {
    /// <summary>
    /// Downloads all CSS and JS files for all libraries into given folder for easy inclusion in project
    /// </summary>
    /// <param name="rootPath">The root path.</param>
    public void DownloadLibrary(string rootPath) {
        foreach (Libraries library in Enum.GetValues(typeof(Libraries))) {
            if (library != Libraries.None) {
                DownloadLibrary(rootPath, library);
            }
        }
    }

    /// <summary>
    /// Downloads specific library CSS and JS files into given folder for easy inclusion in project
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="libraryEnum">The library enum.</param>
    public void DownloadLibrary(string path, Libraries libraryEnum) {
        var library = LibrariesConverter.MapLibraryEnumToLibraryObject(libraryEnum);
        foreach (var link in library.Header.JsLink) {
            DownloadFile(path, link);
        }

        foreach (var link in library.Header.CssLink) {
            DownloadFile(path, link);
        }
    }

    /// <summary>
    /// Generates the tabler icon code so it can be easily copied to the TablerIconLibrary class.
    /// </summary>
    /// <param name="cssFilePath">The CSS file path.</param>
    /// <returns></returns>
    public List<string> GenerateTablerIconCode(string cssFilePath) {
        var icons = new List<string>();
        var cssText = File.ReadAllText(cssFilePath);
        var regex = new Regex(@"\.ti-(.*?):before", RegexOptions.Compiled);
        var matches = regex.Matches(cssText);

        foreach (Match match in matches) {
            var iconName = match.Groups[1].Value;
            var pascalCaseName = ToPascalCase(iconName);
            icons.Add($"public static TablerIcon {pascalCaseName} => new TablerIcon(\"ti-{iconName}\");");
        }

        return icons;
    }

    /// <summary>
    /// Downloads the file from the URL.
    /// </summary>
    /// <param name="rootPath">The root path.</param>
    /// <param name="url">The URL.</param>
    /// <exception cref="System.ArgumentException">Unsupported file type: {fileName}</exception>
    private void DownloadFile(string rootPath, string url) {
        using (var client = new WebClient()) {
            var uri = new Uri(url);
            var fileName = Path.GetFileName(uri.AbsolutePath);
            string localPath;
            if (fileName.EndsWith(".css")) {
                localPath = Path.Combine(rootPath, "Styles", fileName);
            } else if (fileName.EndsWith(".js")) {
                localPath = Path.Combine(rootPath, "Scripts", fileName);
            } else {
                throw new ArgumentException($"Unsupported file type: {fileName}");
            }

            Directory.CreateDirectory(Path.GetDirectoryName(localPath));
            client.DownloadFile(url, localPath);
        }
    }


    /// <summary>
    /// Converts to pascalcase so icon names can be used as properties.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns></returns>
    private string ToPascalCase(string input) {
        var words = input.Split('-').Select(word => char.ToUpper(word[0]) + word.Substring(1)).ToList();
        for (int i = 0; i < words.Count; i++) {
            if (char.IsDigit(words[i][0])) {
                words[i] = NumberToWord(words[i]);
            }
        }
        return string.Join(string.Empty, words);
    }

    /// <summary>
    /// Numbers to word to help with pascal case conversion.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <returns></returns>
    private string NumberToWord(string input) {
        var output = new StringBuilder();
        foreach (var ch in input) {
            if (char.IsDigit(ch)) {
                switch (ch) {
                    case '1':
                        output.Append("One");
                        break;
                    case '2':
                        output.Append("Two");
                        break;
                    case '3':
                        output.Append("Three");
                        break;
                    case '4':
                        output.Append("Four");
                        break;
                    case '5':
                        output.Append("Five");
                        break;
                    case '6':
                        output.Append("Six");
                        break;
                    case '7':
                        output.Append("Seven");
                        break;
                    case '8':
                        output.Append("Eight");
                        break;
                    case '9':
                        output.Append("Nine");
                        break;
                    case '0':
                        output.Append("Zero");
                        break;
                }
            } else {
                output.Append(ch);
            }
        }
        return output.ToString();
    }
}
