using System.Net;
using System.IO;

namespace HtmlForgeX;

public class LibraryDownloader {

    public void DownloadLibrary(string rootPath) {
        foreach (Libraries library in Enum.GetValues(typeof(Libraries))) {
            if (library != Libraries.None) {
                DownloadLibrary(rootPath, library);
            }
        }
    }

    public void DownloadLibrary(string path, Libraries libraryEnum) {
        var library = LibrariesConverter.MapLibraryEnumToLibraryObject(libraryEnum);
        foreach (var link in library.Header.JsLink) {
            DownloadFile(path, link);
        }

        foreach (var link in library.Header.CssLink) {
            DownloadFile(path, link);
        }
    }

    private void DownloadFile(string rootPath, string url) {
        using (var client = new WebClient()) {
            var uri = new Uri(url);
            var fileName = Path.GetFileName(uri.AbsolutePath);
            var pathSegments = uri.AbsolutePath.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            if (fileName.EndsWith("css")) {

            } else if (fileName.EndsWith("js")) {

            }

            string localPath;
            if (fileName.EndsWith(".css")) {
                localPath = Path.Combine(rootPath, "Styles", fileName);
            } else if (fileName.EndsWith(".js")) {
                localPath = Path.Combine(rootPath, "Scripts", fileName);
            } else {
                throw new ArgumentException($"Unsupported file type: {fileName}");
            }

            //Console.WriteLine(localPath);

            Directory.CreateDirectory(Path.GetDirectoryName(localPath));
            client.DownloadFile(url, localPath);
        }
    }
}
