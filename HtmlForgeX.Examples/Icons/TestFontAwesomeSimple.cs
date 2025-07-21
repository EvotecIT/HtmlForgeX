using System;

namespace HtmlForgeX.Examples.Icons {
    internal class TestFontAwesomeSimple {
        public static void Create(bool openInBrowser = true) {
            HelpersSpectre.PrintTitle("FontAwesome Simple Test");

            using var document = new Document {
                Head = { 
                    Title = "FontAwesome Simple Test", 
                    Author = "HtmlForgeX"
                },
                LibraryMode = LibraryMode.Online,
                ThemeMode = ThemeMode.Light
            };

            document.Body.Page(page => {
                page.H1("FontAwesome Icons Test - Online Mode");
                
                page.H2("Solid Icons");
                page.Icon(FontAwesomeSolid.User).WithSize(FontAwesomeSize.X2);
                page.Text(" User Icon").LineBreak();
                
                page.Icon(FontAwesomeSolid.Lock).WithSize(FontAwesomeSize.X2).WithColor(RGBColor.Red);
                page.Text(" Lock Icon (Red)").LineBreak();
                
                page.Icon(FontAwesomeSolid.Server).WithSize(FontAwesomeSize.X3).WithColor(RGBColor.Blue);
                page.Text(" Server Icon (Blue)").LineBreak();
                
                page.H2("Regular Icons");
                page.Icon(FontAwesomeRegular.Heart).WithSize(FontAwesomeSize.X2).WithColor(RGBColor.Pink);
                page.Text(" Heart Icon").LineBreak();
                
                page.H2("Brand Icons");
                page.Icon(FontAwesomeBrands.GitHub).WithSize(FontAwesomeSize.X3);
                page.Text(" GitHub Icon").LineBreak();
                
                page.Icon(FontAwesomeBrands.Twitter).WithSize(FontAwesomeSize.X2).WithColor("#1DA1F2");
                page.Text(" Twitter Icon").LineBreak();
                
                // Test in VisNetwork
                page.H2("FontAwesome in VisNetwork");
                page.DiagramNetwork(network => {
                    network
                        .WithId("fontAwesomeTest")
                        .WithSize("100%", "400px")
                        .WithPhysics(false);

                    network.AddNode(1, node => node
                        .WithLabel("Server")
                        .WithShape(VisNetworkNodeShape.Icon)
                        .WithIcon(icon => icon
                            .WithFontAwesome(FontAwesomeSolid.Server)
                            .WithColor(RGBColor.DarkBlue)
                        )
                        .WithPosition(-200, 0)
                    );
                    
                    network.AddNode(2, node => node
                        .WithLabel("Database")
                        .WithShape(VisNetworkNodeShape.Icon)
                        .WithIcon(icon => icon
                            .WithFontAwesome(FontAwesomeSolid.Database)
                            .WithColor(RGBColor.DarkGreen)
                        )
                        .WithPosition(0, 0)
                    );
                    
                    network.AddNode(3, node => node
                        .WithLabel("GitHub")
                        .WithShape(VisNetworkNodeShape.Icon)
                        .WithIcon(icon => icon
                            .WithFontAwesome(FontAwesomeBrands.GitHub)
                            .WithColor(RGBColor.Black)
                        )
                        .WithPosition(200, 0)
                    );
                    
                    network.AddEdge(1, 2);
                    network.AddEdge(2, 3);
                });
            });

            document.Save("TestFontAwesomeSimple.html", openInBrowser);
            Console.WriteLine("FontAwesome Simple Test created successfully!");
        }
    }
}