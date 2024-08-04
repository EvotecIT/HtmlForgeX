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


                    item.AddItem("Another title", subItem => {
                        subItem.AddItem("Sub Title 1", item2 => {
                            item2.Text("Text in theory in Sub Title 1");
                            item2.Text("Text in theory in Sub Title 2");
                        });
                        subItem.AddItem("Sub Title 2", item3 => {
                            item3.ApexChart(chart => {
                                chart.Title.Text("Pie Chart").Color(RGBColor.FruitSalad);
                                chart.AddPie("Pie 1", 30).AddPie("Pie 2", 40).AddPie("Pie 3", 50);
                            });
                        });
                    });

                });
                scroll.AddItem("Another section", item => {
                    item.ApexChart(chart => {
                        chart.Title.Text("Donut Chart").Color(RGBColor.FruitSalad);
                        chart.AddDonut("Donut 1", 30).AddDonut("Donut 2", 40).AddDonut("Donut 3", 50);
                    });
                });
            });

        });
        document.Save("BasicDemoScrollingText.html", openInBrowser);
    }
}
