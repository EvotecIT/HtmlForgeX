namespace HtmlForgeX.Examples.Containers;

internal class BasicVisNetwork {
    public static void Demo(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("VisNetwork Image Demo");

        using var document = new Document {
            Head = { Title = "VisNetwork Image Demo", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Offline,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.DiagramNetwork(network => {
                var server = new VisNetworkNode()
                    .IdValue(1)
                    .LabelText("Server")
                    .UseImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png");

                var client = new VisNetworkNode()
                    .IdValue(2)
                    .LabelText("Client")
                    .UseImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png");

                network.AddNode(server)
                       .AddNode(client)
                       .AddEdge(new VisNetworkEdge()
                           .FromNode(2)
                           .ToNode(1)
                           .EdgeLabel("connects")
                           .EdgeArrows(VisNetworkArrows.To));
            });
        });

        document.Save("VisNetworkImageDemo.html", openInBrowser);
    }
}
