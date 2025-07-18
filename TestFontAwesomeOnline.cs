using System;

namespace HtmlForgeX.Examples {
    class TestFontAwesomeOnline {
        static void Main() {
            using var document = new Document {
                Head = { 
                    Title = "FontAwesome Online Mode Test", 
                    Author = "HtmlForgeX"
                },
                LibraryMode = LibraryMode.Online,
                ThemeMode = ThemeMode.Light
            };

            document.Body.Page(page => {
                page.H1("FontAwesome Icons - Online Mode Test");
                
                page.H2("Testing FontAwesome Icons");
                page.Icon(FontAwesomeSolid.User).WithSize(FontAwesomeSize.X2);
                page.Text(" User Icon").LineBreak();
                
                page.Icon(FontAwesomeSolid.Lock).WithSize(FontAwesomeSize.X2).WithColor(RGBColor.Red);
                page.Text(" Lock Icon").LineBreak();
                
                page.Icon(FontAwesomeBrands.Github).WithSize(FontAwesomeSize.X3);
                page.Text(" GitHub Brand Icon").LineBreak();
                
                // Test in VisNetwork
                page.H2("FontAwesome in VisNetwork");
                page.DiagramNetwork(network => {
                    network
                        .WithId("fontAwesomeTest")
                        .WithSize("100%", "300px")
                        .WithPhysics(false);

                    network.AddNode(1, node => node
                        .WithLabel("Server")
                        .WithShape(VisNetworkNodeShape.Icon)
                        .WithIcon(icon => icon.WithFontAwesome(FontAwesomeSolid.Server))
                        .WithPosition(0, 0)
                    );
                });
            });

            document.Save("TestFontAwesomeOnline.html");
            Console.WriteLine("Test file created: TestFontAwesomeOnline.html");
        }
    }
}