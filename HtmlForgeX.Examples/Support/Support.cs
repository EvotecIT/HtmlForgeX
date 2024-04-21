using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlForgeX.Examples.Support;

internal class Support {
    /// <summary>
    /// Helps build HtmlForgeX library downloadable content
    /// </summary>
    public static void DownloadLibraries() {
        HtmlForgeX.LibraryDownloader libraryDownloader = new HtmlForgeX.LibraryDownloader();
        string path = @"C:\Support\GitHub\HtmlForgeX\HtmlForgeX\Resources";
        libraryDownloader.DownloadLibrary(path);
    }

    public static void GenerateTableIcons() {
        HtmlForgeX.LibraryDownloader libraryDownloader = new HtmlForgeX.LibraryDownloader();
        var list = libraryDownloader.GenerateTablerIconCode(
            @"C:\Users\przemyslaw.klys\Downloads\tabler-icons-3.2.0\webfont\tabler-icons.css");
        foreach (var item in list) {
            Console.WriteLine(item);
        }
    }
}