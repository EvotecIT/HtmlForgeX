using System;

namespace HtmlForgeX.Examples.ByHand;

internal class DuplicateLibraries
{
    public static void Demo(bool openInBrowser = false)
    {
        HelpersSpectre.PrintTitle("Duplicate Libraries Example");

        var doc = new Document();
        doc.Head.Title = "Duplicate Libraries Example";

        var library = new Library
        {
            Header = new LibraryLinks
            {
                CssLink = ["https://dup.example.com/style.css"],
                JsLink = ["https://dup.example.com/script.js"]
            }
        };

        doc.AddLibrary(library);
        doc.AddLibrary(library);

        doc.Body.Add(new HtmlTag("p", "Check the head for duplicates."));
        doc.Save("DuplicateLibrariesExample.html", openInBrowser);
    }
}
