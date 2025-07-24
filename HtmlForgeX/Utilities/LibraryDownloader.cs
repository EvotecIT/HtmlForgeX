using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using HtmlForgeX.Logging;

namespace HtmlForgeX;

/// <summary>
/// Support class to help building HtmlForgeX without the manual effort of
/// maintaining CSS and JS files locally. It downloads the external resources
/// referenced by available libraries.
/// </summary>
public class LibraryDownloader {
    private static readonly HttpClient _client = new();
    private static readonly InternalLogger _logger = new();
    private static readonly Regex IconRegex = new("\\.ti-(.*?):before", RegexOptions.Compiled);
    /// <summary>
    /// Downloads all CSS and JS files for all libraries into given folder for easy inclusion in project
    /// </summary>
    /// <param name="rootPath">The root path.</param>
    public async Task DownloadLibraryAsync(string rootPath) {
        var tasks = new List<Task>();
        foreach (Libraries library in Enum.GetValues(typeof(Libraries))) {
            if (library != Libraries.None) {
                tasks.Add(DownloadLibraryAsync(rootPath, library));
            }
        }
        await Task.WhenAll(tasks).ConfigureAwait(false);
    }

    /// <summary>
    /// Downloads specific library CSS and JS files into given folder for easy inclusion in project
    /// </summary>
    /// <param name="path">The path.</param>
    /// <param name="libraryEnum">The library enum.</param>
    public async Task DownloadLibraryAsync(string path, Libraries libraryEnum) {
        var library = LibrariesConverter.MapLibraryEnumToLibraryObject(libraryEnum);
        var links = library.Header.JsLink.Concat(library.Header.CssLink).ToList();
        if (links.Count == 0) {
            return;
        }

        var tasks = new List<Task>();
        int completed = 0;
        foreach (var link in links) {
            tasks.Add(Task.Run(async () => {
                await DownloadFileAsync(path, link).ConfigureAwait(false);
                int done = Interlocked.Increment(ref completed);
                _logger.WriteProgress(
                    libraryEnum.ToString(),
                    Path.GetFileName(link),
                    done * 100 / links.Count,
                    done,
                    links.Count);
            }));
        }

        await Task.WhenAll(tasks).ConfigureAwait(false);
    }

    /// <summary>
    /// Generates the tabler icon code so it can be easily copied to the TablerIconLibrary class.
    /// </summary>
    /// <param name="cssFilePath">The CSS file path.</param>
    /// <returns></returns>
    public async Task<List<string>> GenerateTablerIconCodeAsync(string cssFilePath) {
        var icons = new List<string>();
        string cssText;
#if NET5_0_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
        await using var stream = File.OpenRead(cssFilePath);
#else
        using var stream = File.OpenRead(cssFilePath);
#endif
        using var reader = new StreamReader(stream);
        cssText = await reader.ReadToEndAsync().ConfigureAwait(false);
        var matches = IconRegex.Matches(cssText);

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
    internal async Task DownloadFileAsync(string rootPath, string url) {
        var uri = new Uri(url);
        var fileName = Path.GetFileName(uri.AbsolutePath);
        var extension = Path.GetExtension(fileName).ToLowerInvariant();
        string localPath = extension switch {
            ".css" => Path.Combine(rootPath, "Styles", fileName),
            ".js" => Path.Combine(rootPath, "Scripts", fileName),
            ".woff" or ".woff2" or ".eot" or ".ttf" => Path.Combine(rootPath, "Fonts", fileName),
            ".svg" or ".png" or ".jpg" or ".jpeg" or ".gif" => Path.Combine(rootPath, "Images", fileName),
            _ => throw new ArgumentException($"Unsupported file type: {fileName}")
        };

        _logger.WriteVerbose($"Saving '{url}' to '{localPath}'");

        var directory = Path.GetDirectoryName(localPath);
        if (string.IsNullOrEmpty(directory)) {
            directory = rootPath;
        }
        try {
            Directory.CreateDirectory(directory);
        } catch (Exception ex) {
            _logger.WriteError($"Failed to create directory '{directory}'. {ex.Message}");
        }
#if NET5_0_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
        await using var fileStream = new FileStream(localPath, FileMode.Create, FileAccess.Write, FileShare.None);
#else
        using var fileStream = new FileStream(localPath, FileMode.Create, FileAccess.Write, FileShare.None);
#endif
        using HttpResponseMessage response = await _client.GetAsync(url, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
        if (!response.IsSuccessStatusCode) {
            _logger.WriteError($"Failed to download '{url}' - Status code: {(int)response.StatusCode}");
            throw new HttpRequestException($"Request for '{url}' failed with status code {response.StatusCode}");
        }

#if NET5_0_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
        await using var httpStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
#else
        using var httpStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
#endif
        await httpStream.CopyToAsync(fileStream).ConfigureAwait(false);
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