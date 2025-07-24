namespace HtmlForgeX.Examples.VisNetwork;

internal class VisNetworkIdSizeExample
{
    public static void Create(bool openInBrowser = false)
    {
        HelpersSpectre.PrintTitle("VisNetwork Id & Size Demo");

        using var document = new Document
        {
            Head = { Title = "VisNetwork Id & Size Demo", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page =>
        {
            page.DiagramNetwork(network =>
            {
                network
                    .WithId("exampleNetwork")
                    .WithSize("100%", "300px");

                network.AddNode(1, node => node.WithLabel("First"));
                network.AddNode(2, node => node.WithLabel("Second"));
                network.AddEdge(1, 2);
            });
        });

        document.Save("VisNetworkIdSizeDemo.html", openInBrowser);
    }
}