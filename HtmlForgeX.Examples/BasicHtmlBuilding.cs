using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlForgeX.Examples {
    internal class BasicHtmlBuilding {
        public static void Demo1() {
            HelpersSpectre.PrintTitle("Basic Demo Document 1");

            HtmlDocument document = new HtmlDocument();
            document.Head.Title = "Basic Demo Document 1";
            document.Head.Author = "Przemysław Kłys";
            document.Head.Revised = DateTime.Now;

            document.Head.AddMeta("description", "This is a basic demo document");
            document.Head.AddMeta("keywords", "html, c#, .net, library");


            document.Head.AddCharsetMeta("utf-8");
            // document.Head.AddHttpEquivMeta("Content-Type", "text/html; charset=utf-8");
            document.Head.AddViewportMeta("width=device-width, initial-scale=1.0");

            document.Save("BasicDemoDocument1.html", true);

        }
    }
}
