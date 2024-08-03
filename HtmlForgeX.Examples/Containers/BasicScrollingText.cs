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
                    item.Card(card => {
                        card.Steps().StepCounting().Color(TablerColor.Red)
                            .AddStep("Order received", false)
                            .AddStep("Processing", true)
                            .AddStep("Shipped", false)
                            .AddStep("Delivered", false);
                    });
                    item.Steps().StepCounting().Color(TablerColor.Red)
                        .AddStep("Order received", false)
                        .AddStep("Processing", true)
                        .AddStep("Shipped", false);

                    item.LineBreak();

                    item.FancyTree(fancyTree => {
                        fancyTree.AutoScroll(true).MinimumExpandLevel(2);
                        fancyTree.Title("Enable TSDebugMode")
                            .Icon("https://cdn-icons-png.flaticon.com/512/5610/5610944.png");
                        fancyTree.Title("Check OS UBR")
                            .Icon("https://cdn-icons-png.flaticon.com/512/1294/1294758.png");
                    });
                });
                scroll.AddItem().Title("MyTitle").Content(item => {
                    item.ApexChart(chart => {
                        chart.Title.Text("Bar chart");
                        chart.AddBar("Bar 1", 30).AddBar("Bar 2", 40).AddBar("Bar 3", 50);
                    });
                });
            });

        });
        document.Save("BasicDemoScrollingText.html", openInBrowser);
    }
}
