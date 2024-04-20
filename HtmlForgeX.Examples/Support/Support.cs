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
}