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
                scroll.AddItem("Test1", "Test")
                    .AddItem("Test2", "test2");
            });

        });
        document.Save("BasicDemoScrollingText.html", openInBrowser);
    }
}
