using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Containers;
internal class BasicScrollingText {
    public static void Demo01(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Basic Demo Scrolling Text");

        var document = new Document {
            Head = { Title = "Basic Demo Scrolling Text", Author = "Przemysław Kłys", Revised = DateTime.Now },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };
        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;

            page.ScrollingText(scroll => {
                scroll.AddItem("First Section", "Text content");
                scroll.AddItem("Second Section", item => {
                    item.Text("Section 2 - Text 1");
                });
                scroll.AddItem("MyTitle", item => {
                    item.Text("Text within MyTitle");
                    item.Text("Text within MyTitle2");

                    item.ScrollingTextItem("Another title", subItem => {
                        //subItem.AddItem("Sub Title 1", item2 => {
                        //    item2.Text("Text in theory in Sub Title 1");
                        //    item2.Text("Text in theory in Sub Title 2");
                        //});

                    });

                });


            });

        });
        document.Save("BasicDemoScrollingText.html", openInBrowser);
    }
}
