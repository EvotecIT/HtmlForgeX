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
            document.Save("test.html", true);

        }
    }
}
