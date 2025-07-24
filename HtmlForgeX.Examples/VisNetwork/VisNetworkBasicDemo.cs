namespace HtmlForgeX.Examples.VisNetwork;

internal class VisNetworkBasicDemo {
    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("VisNetwork Basic Demo - Fluent API");

        using var document = new Document {
            Head = { Title = "VisNetwork Basic Demo", Author = "HtmlForgeX" },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.DiagramNetwork(network => {
                network
                    .WithId("basicNetwork")
                    .WithSize("100%", "400px")
                    .WithOptions(options => {
                        options.WithNodes(nodes => {
                            nodes.WithBorderWidth(2);
                        });
                    });

                // Add server node with image
                network.AddNode(1, node => node
                    .WithLabel("Server")
                    .WithShape(VisNetworkNodeShape.CircularImage)
                    .WithImage("Assets/Icons/UxWing/server-icon.png")
                    .WithSize(60)
                );

                // Add client node with image
                network.AddNode(2, node => node
                    .WithLabel("Client")
                    .WithShape(VisNetworkNodeShape.CircularImage)
                    .WithImage("Assets/Icons/UxWing/desktop-monitor-display-icon.png")
                    .WithSize(60)
                );

                // Add connection
                network.AddEdge(2, 1, edge => edge
                    .WithLabel("connects")
                    .WithArrows(new VisNetworkArrowOptions().WithTo(true))
                );
            });
        });

        document.Save("VisNetworkBasicDemo.html", openInBrowser);
    }
}
