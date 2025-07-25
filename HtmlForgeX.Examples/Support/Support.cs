using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlForgeX.Examples.Support;

public static class Support {
    /// <summary>
    /// Helps build HtmlForgeX library downloadable content
    /// </summary>
    public static async Task DownloadLibrariesAsync() {
        HtmlForgeX.LibraryDownloader libraryDownloader = new HtmlForgeX.LibraryDownloader();
        string path = @"C:\Support\GitHub\HtmlForgeX\HtmlForgeX\Resources";
        await libraryDownloader.DownloadLibraryAsync(path).ConfigureAwait(false);
    }

    public static async Task GenerateTableIconsAsync() {
        HtmlForgeX.LibraryDownloader libraryDownloader = new HtmlForgeX.LibraryDownloader();
        var list = await libraryDownloader.GenerateTablerIconCodeAsync(
            @"C:\Users\przemyslaw.klys\Downloads\tabler-icons-3.2.0\webfont\tabler-icons.css");
        foreach (var item in list) {
            HelpersSpectre.Success(item);
        }
    }
}