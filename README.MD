# HtmlForgeX - HTML / CSS / JavaScript generator for .NET

[![nuget downloads](https://img.shields.io/nuget/dt/HtmlForgeX?label=nuget%20downloads)](https://www.nuget.org/packages/HtmlForgeX)
[![nuget version](https://img.shields.io/nuget/v/HtmlForgeX)](https://www.nuget.org/packages/HtmlForgeX)
[![license](https://img.shields.io/github/license/EvotecIT/HtmlForgeX.svg)](#)
[![Test .NET Libraries](https://github.com/EvotecIT/HtmlForgeX/actions/workflows/test-dotnet.yml/badge.svg?branch=master)](https://github.com/EvotecIT/HtmlForgeX/actions/workflows/test-dotnet.yml)
[![codecov](https://codecov.io/gh/EvotecIT/HtmlForgeX/branch/master/graph/badge.svg)](https://codecov.io/gh/EvotecIT/HtmlForgeX)
[![Discord](https://img.shields.io/discord/508328927853281280?style=flat-square&label=discord%20chat)](https://evo.yt/discord)

If you would like to contact me you can do so via Twitter or LinkedIn.

[![twitter](https://img.shields.io/twitter/follow/PrzemyslawKlys.svg?label=Twitter%20%40PrzemyslawKlys&style=social)](https://twitter.com/PrzemyslawKlys)
[![blog](https://img.shields.io/badge/Blog-evotec.xyz-2A6496.svg)](https://evotec.xyz/hub)
[![linked](https://img.shields.io/badge/LinkedIn-pklys-0077B5.svg?logo=LinkedIn)](https://www.linkedin.com/in/pklys)

## About
`HtmlForgeX` is a .NET library that simplifies the creation of HTML documents, pages and reports.
It provides a fluent API to create HTML / CSS / JavaScript without knowing any of it.
It is designed to be simple and easy to use, and to provide a way to create HTML content in a more readable and maintainable way.

I have similar project [PSWriteHTML](https://github.com/evotecit/PSWriteHTML) for PowerShell that is used by many people.
This project aims to provide similar functionality for .NET developers.

*As I am not really a developer, and I hardly know what I'm doing if you know how to help out - please do.*

- If you see bad practice, please open an issue/submit PR.
- If you know how to do something in HTML/CSS/JS/C# that could help this project - please open an issue/submit PR
- If you see something that could work better - please open an issue/submit PR
- If you see something that I made a fool of myself - please open an issue/submit PR
- If you see something that works not the way I think it works - please open an issue/submit PR

I hope you get the drift? If it's bad - open an issue/fix it! I don't know what I'm doing!
The main thing is - it has to work with .NET Framework 4.7.2, .NET Standard 2.0 and so on.

**This project is under development and as such there's a lot of things that can and will change, especially if some people help out.**

### Used libraries

This project uses the following awesome libraries and frameworks that make it what it is:

- [ApexCharts](https://apexcharts.com/) - license MIT
- [Bootstrap](https://getbootstrap.com/) - license MIT
- [DataTables](https://datatables.net/) - license MIT
- [EasyQRCodeJS](https://github.com/ushelp/EasyQRCodeJS) - license MIT
- [FancyTree](https://github.com/mar10/fancytree) - license MIT
- [JQuery](https://jquery.com/) - license MIT
- [Tabler](https://tabler.github.io/) - license MIT
- [VisNetwork](https://visjs.org/) - license MIT

Please support their creators by checking them out and starring their projects.

### Project folder structure

- `HtmlForgeX` - main project
  - Containers - classes that represent HTML containers
  - Enums - enums used in the project
  - Extensions - extension methods
  - Resources - resources used in the project
    - Classes - C# classes describing resources
    - Scripts - JavaScript files, embedded resources
    - Styles - CSS files, embedded resources
- `HtmlForgeX.Tests` - tests for the project
- `HtmlForgeX.Examples` - demo project


### Configuring EmailBox

Use the fluent `With` methods on `EmailBox` when the instance is available:

```csharp
var box = new EmailBox()
    .WithPadding("16px")
    .WithBackground("#f8f9fa");
```

`EmailBoxBuilder` exposes the same methods for lambda-based configuration:

```csharp
email.Body.EmailBox(b => b
    .WithPadding("16px")
    .WithBackground("#f8f9fa")
    .WithOuterMargin("0 auto")
    .WithMaxWidth("600px"));
```

Choose the builder when you need to reuse a configuration or build the box inside a delegate.


## Examples

### Example - Create a simple dashboard with different components

This example shows how to create a simple dashboard with different components like cards, tables, charts, diagrams, and more.
WIth a few lines of code, you can create a complex HTML document with a lot of components.

![BasicDemoDocumentContainer03](https://raw.githubusercontent.com/EvotecIT/HtmlForgeX/master/Assets/Examples/Example1-1.png)
![BasicDemoDocumentContainer03](https://raw.githubusercontent.com/EvotecIT/HtmlForgeX/master/Assets/Examples/Example1-2.png)

Here's how you do it - with just over 300 lines of code:

```csharp
// Create a list of simple objects
var data = new List<dynamic> {
    new { Name = "John", Age = 30, Occupation = "Engineer" },
    new { Name = "Jane", Age = 28, Occupation = "Doctor" },
    new { Name = "Bob", Age = 35, Occupation = "Architect" }
};

var data1 = new List<dynamic> {
    new { Name = "John", Age = 30, Occupation = "Engineer" },
    new { Name = "Jane", Age = 28, Occupation = "Doctor" },
    new { Name = "Bob", Age = 35, Occupation = "Architect" },
    new { Name = "John", Age = 30, Occupation = "Engineer" },
};

var data2 = new List<dynamic> {
    new { Name = "John", Age = 30, Occupation = "Engineer" },
    new { Name = "Jane", Age = 28, Occupation = "Doctor" },
};

var document = new Document {
    Head = {
        Title = "Basic Demo Document Container 3", Author = "Przemysław Kłys", Revised = DateTime.Now
    },
    LibraryMode = LibraryMode.Online,
    ThemeMode = ThemeMode.Light
};
document.Body.Page(page => {
    page.Layout = TablerLayout.Fluid;
    page.Row(row => {
        // first line of 4 cards
        row.Column(TablerColumnNumber.Three, column => {
            column.CardMini().Avatar(TablerIcon.BrandFacebook).BackgroundColor(TablerColor.Facebook).TextColor(TablerColor.White).Title("172 likes").Subtitle("2 today");
        });
        row.Column(TablerColumnNumber.Three, column => {
            column.CardMini().Avatar(TablerIcon.BrandTwitter).BackgroundColor(TablerColor.Twitter).TextColor(TablerColor.White).Title("600 shares").Subtitle("16 today");
        });
        row.Column(TablerColumnNumber.Three, column => {
            column.CardMini().Avatar(TablerIcon.ShoppingCart).BackgroundColor(TablerColor.CyanLight).TextColor(TablerColor.Orange).Title("100 orders").Subtitle("0 today");
        });
        row.Column(TablerColumnNumber.Three, column => {
            column.CardMini().Avatar(TablerIcon.CurrencyDollar).BackgroundColor(TablerColor.OrangeLight).TextColor(TablerColor.White).Title("5 sales").Subtitle("3 waiting");
        });
        // second line of 3 cards
        row.Column(TablerColumnNumber.Four, column => {
            // let's build a card with an avatar manually
            column.Card(card => {
                card.Row(cardTitle => {
                    cardTitle.HeaderLevel(HeaderLevelTag.H4, "Title").Class("card-title");
                });
                card.Row(cardRow => {
                    cardRow.Column(TablerColumnNumber.Auto, avatarColumn => {
                        avatarColumn.Avatar().Icon(TablerIcon.License).BackgroundColor(TablerColor.Gray300).TextColor(TablerColor.Pink);
                    });
                    cardRow.Column(textColumn => {
                        textColumn.Text("132 sales").Weight(TablerFontWeight.Medium);
                        textColumn.Text("12 waiting payments").Style(TablerTextStyle.Muted);
                    });
                });
            });
        });
        row.Column(TablerColumnNumber.Four, column => {
            column.Card(card => {
                card.Add(new TablerAvatar().Icon(TablerIcon.License).BackgroundColor(TablerColor.BlueLight).TextColor(TablerColor.Flickr));
            });
        });
        row.Column(TablerColumnNumber.Four, column => {
            column.CardMini().Avatar(TablerIcon.License);

        });

        row.Column(TablerColumnNumber.Four, column => {
            column.Card(card => {
                card.Span("This is inside card").AddContent(" with some color").WithColor(RGBColor.Amber);
                card.LineBreak();
                card.Span("This is continuing after").AppendContent(" linebreak ").WithColor(RGBColor.RedDevil).AppendContent(" cool?");
            });
        });
        row.Column(TablerColumnNumber.Eight, column => {
            column.Card(card => {
                var table1 = (DataTablesTable)card.Table(data, TableType.DataTables);
                table1.EnableOrdering = false;
                table1.EnableSearching = false;
            });
        });
        row.Column(TablerColumnNumber.Eight, column => {
            column.Card(card => {
                card.DataGrid(dataGrid => {
                    dataGrid.AddItem("Registrar", "Third Party");
                    dataGrid.AddItem("Port number", "3306");
                    dataGrid.AddItem("Creator", "Przemysław Kłys");
                    dataGrid.AddItem("Edge network", new TablerBadgeStatus("Active", TablerColor.Green));
                    dataGrid.Title("Domain Information").Content("This is the domain information");
                    dataGrid.AddItem("Expiration date", DateTime.Now.AddDays(5).ToString());
                    dataGrid.AddItem("Age", "5 days");
                    dataGrid.Title("Expiring").Content(new TablerBadgeSpan("Soon", TablerColor.Azure, textColor: TablerColor.White));
                    dataGrid.Title("Registrar").Content(new TablerBadgeSpan("Testing", TablerColor.OrangeLight, TablerBadgeStyle.Normal));
                    dataGrid.Title("Pill").Content(new TablerBadgeSpan("1", TablerColor.Azure, TablerBadgeStyle.Pill, TablerColor.White));
                    dataGrid.Title("Outline").Content(new TablerBadgeSpan("Testing", TablerColor.Azure, TablerBadgeStyle.Outline, TablerColor.Cyan));
                    dataGrid.Title("Text Color").Content(new TablerBadgeSpan("Testing", TablerColor.Facebook, TablerBadgeStyle.Normal, TablerColor.Green));
                    dataGrid.Title("Normal").Content(new TablerBadgeSpan("Testing", TablerColor.AzureLight, TablerBadgeStyle.Normal));
                    dataGrid.Title("Tag").Content(new TablerTag("New", TablerColor.Lime).Dismissable());
                    dataGrid.Title("Large Tag").Content(new TablerTag("Download", TablerColor.Green).TagSize(TablerTagSize.Large).Dismissable());

                });
            });
        });
        row.Column(TablerColumnNumber.Four, column => {
            column.Card(4, card => {
                card.FancyTree(fancyTree => {
                    fancyTree.Title("Enable TSDebugMode").Icon("https://cdn-icons-png.flaticon.com/512/5610/5610944.png");
                    fancyTree.Title("Check OS UBR").Icon("https://cdn-icons-png.flaticon.com/512/1294/1294758.png");
                    fancyTree.Title("OS is not supported - Needs to be Updated");
                    fancyTree.Title("OS Supported")
                        .AddNode(new FancyTreeNode("Pre-Check", "https://cdn-icons-png.flaticon.com/512/1294/1294758.png", true))
                        .AddNode(node => {
                            node.Title("Checking if DB is up and running");
                            node.AddNode(nextNode => {
                                nextNode.Title("DB is up and running");
                                nextNode.AddNode("Testing DB Connection");
                                nextNode.AddNode("DB Connection Successful");
                            });
                        });

                    fancyTree.Title("Test");
                    fancyTree.Title("OS Not Supported").AddNode(node => {
                        node.Title("Shutdown PC");
                        node.AddNode("Node nested under Shutdown 2-1");
                        node.AddNode("Node nested under Shutdown 2-2");
                    });
                    fancyTree.Title("Other").Icon("https://cdn-icons-png.flaticon.com/512/5610/5610944.png").AddNode(node => {
                        node.Title("PC Start Up").Icon("https://cdn-icons-png.flaticon.com/512/1294/1294758.png").AddNode(nestedNode => {
                            nestedNode.Title("Cleanup");
                        });
                    });
                    // Creates nesting of node, within node, within node, within node
                    fancyTree.Title("Test")
                        .AddNode("PC Start Up")
                        .AddNode("Cleanup")
                        .AddNode("PC Shut Down", "https://cdn-icons-png.flaticon.com/512/10309/10309341.png");

                });
            });
        });
        row.Column(TablerColumnNumber.Four, column => {
            column.Card(4, card => {
                card.ApexChart(chart => {
                    chart.Title.Text("Pie Chart").Color(RGBColor.FruitSalad);
                    chart.AddPie("Pie 1", 30).AddPie("Pie 2", 40).AddPie("Pie 3", 50);
                });
            });
        });
        row.Column(TablerColumnNumber.Four, column => {
            column.Card(card => {
                card.ApexChart(chart => {
                    chart.Title.Text("Bar chart");
                    chart.AddBar("Bar 1", 30).AddBar("Bar 2", 40).AddBar("Barat 3", 50);
                });
            });
        });
        row.Column(TablerColumnNumber.Four, column => {
            column.Card(card => {
                card.ApexChart(chart => {
                    chart.Title.Text("Donut Chart").Color(RGBColor.FruitSalad);
                    chart.AddDonut("Donut 1", 30).AddDonut("Donut 2", 40).AddDonut("Donut 3", 50);
                });
            });
        });
        row.Column(TablerColumnNumber.Eight, column => {
            column.Card(card => {
                card.DiagramNetwork(diagam => {
                    diagam.AddNode(new { id = 1, label = "Node 1" });
                    diagam.AddNode(new { id = 2, label = "Node 2" });
                    diagam.AddNode(new { id = 3, label = "Node 3" });
                    diagam.AddEdge(new { from = 1, to = 2 });
                    diagam.AddEdge(new { from = 2, to = 3 });
                    diagam.SetOption("nodes", new { shape = "box" });
                    diagam.SetOption("edges", new { arrows = "to" });
                });
            });
        });
        row.Column(TablerColumnNumber.Four, column => {
            column.Card(card => {
                card.QRCode("https://evotec.xyz");
            });
        });
        // this will add a new row and push it all wide
        row.Column(TablerColumnNumber.Twelve, column => {
            column.Card(card => {
                card.Span("This is inside card").AddContent(" with some color").WithColor(RGBColor.Amber);
                card.LineBreak();
                card.Span("This is continuing after").AppendContent(" linebreak ").WithColor(RGBColor.RedDevil).AppendContent(" cool?");
                var table1 = ((DataTablesTable)card.Table(data, TableType.DataTables)).Style(BootStrapTableStyle.Striped);
                table1.EnableOrdering = true;
                table1.EnableSearching = true;
                table1.EnableScrollX = true;
            });
        });
    });
});

document.Save("BasicDemoDocumentContainer03.html", openInBrowser);
```


### Example - Different components in cards

This example shows how to create different components in cards like progress bars, steps, logs, accordions, and more.

![BasicDemoDocumentContainer04](https://raw.githubusercontent.com/EvotecIT/HtmlForgeX/master/Assets/Examples/Example2-1.png)
![BasicDemoDocumentContainer04](https://raw.githubusercontent.com/EvotecIT/HtmlForgeX/master/Assets/Examples/Example2-2.png)

With just over 200 lines of code, you can create a complex HTML document with a lot of components:

```csharp
// Create a list of simple objects
var data = new List<dynamic> {
    new { Name = "John", Age = 30, Occupation = "Engineer" },
    new { Name = "Jane", Age = 28, Occupation = "Doctor" },
    new { Name = "Bob", Age = 35, Occupation = "Architect" }
};

var logs = @"
Effective URL            https://evotec.xyz
Redirect count           0
Name lookup time         3.4e-05
Connect time             0.000521
Pre-transfer time        0.0
Start-transfer time      0.0
App connect time         0.0
Redirect time            0.0
Total time               28.000601
Response code            0
Return keyword           operation_timedout
";

var document = new Document {
    Head = {
        Title = "Basic Demo Document Container 4", Author = "Przemysław Kłys", Revised = DateTime.Now
    },
    LibraryMode = LibraryMode.Online,
    ThemeMode = ThemeMode.Light
};
document.Body.Page(page => {
    page.Layout = TablerLayout.Fluid;
    page.Row(row => {
        // first line of 4 cards
        row.Column(TablerColumnNumber.Three, column => {
            column.CardMini().Avatar(TablerIcon.BrandFacebook).BackgroundColor(TablerColor.Facebook)
                .TextColor(TablerColor.White).Title("172 likes").Subtitle("2 today");
        });
        row.Column(TablerColumnNumber.Three, column => {
            column.CardMini().Avatar(TablerIcon.BrandTwitter).BackgroundColor(TablerColor.Twitter)
                .TextColor(TablerColor.White).Title("600 shares").Subtitle("16 today");
        });
        row.Column(TablerColumnNumber.Three, column => {
            column.CardMini().Avatar(TablerIcon.ShoppingCart).BackgroundColor(TablerColor.Gray200)
                .TextColor(TablerColor.Orange).Title("100 orders").Subtitle("0 today");
        });
        row.Column(TablerColumnNumber.Three, column => {
            column.CardMini().Avatar(TablerIcon.CurrencyDollar).BackgroundColor(TablerColor.CyanLight)
                .TextColor(TablerColor.White).Title("5 sales").Subtitle("3 waiting");
        });
        // second line of 3 cards
        row.Column(TablerColumnNumber.Four, column => {
            // let's build a card with an avatar manually
            column.Card(card => {
                card.Row(cardTitle => {
                    cardTitle.HeaderLevel(HeaderLevelTag.H4, "Title").Class("card-title");
                });
                card.Row(cardRow => {
                    cardRow.Column(TablerColumnNumber.Auto, avatarColumn => {
                        avatarColumn.Avatar().Icon(TablerIcon.License).BackgroundColor(TablerColor.Cyan)
                            .TextColor(TablerColor.Blue);
                    });
                    cardRow.Column(textColumn => {
                        textColumn.Text("132 sales").Weight(TablerFontWeight.Medium);
                        textColumn.Text("12 waiting payments").Style(TablerTextStyle.Muted);
                    });
                });
            });
        });
        row.Column(TablerColumnNumber.Four, column => {
            column.Card(card => {
                card.Add(new TablerAvatar().Icon(TablerIcon.License).BackgroundColor(TablerColor.Cyan)
                    .TextColor(TablerColor.Blue));
            });
        });
        row.Column(TablerColumnNumber.Four, column => {
            column.Card(card => {
                card.ProgressBar(TablerProgressBarType.Small)
                    .Item(TablerColor.Primary, 44, "")
                    .Item(TablerColor.Info, 23, "")
                    .Item(TablerColor.Success, 33, "");
                card.LineBreak();
                card.ProgressBar(TablerProgressBarType.Small)
                    .Item(TablerColor.Primary, 44, "Test");
                card.LineBreak();
                card.ProgressBar(TablerProgressBarType.Separated)
                    .Item(TablerColor.Primary, 44, "Test")
                    .Item(TablerColor.Info, 23, "Test")
                    .Item(TablerColor.Success, 33, "Test");
                card.LineBreak();
                card.ProgressBar(TablerProgressBarType.Small, 50, TablerColor.Facebook);
                card.LineBreak();
                card.ProgressBar(TablerProgressBarType.Indeterminate, 100, TablerColor.Facebook);
            });
        });
        row.Column(TablerColumnNumber.Four, column => {
            column.Row(rowNested => {
                rowNested.Column(TablerColumnNumber.Twelve, column => {
                    column.CardBasic("Currently Up for", "14 days 2 hours 54 minutes 32 seconds");
                });
                rowNested.Column(TablerColumnNumber.Twelve, column => {
                    column.CardBasic().Title("Last checked at").Text("27 seconds ago");
                });
                rowNested.Column(TablerColumnNumber.Twelve, column => {
                    column.CardBasic("Incidents", "3");
                });
                rowNested.Column(TablerColumnNumber.Twelve, column => {
                    column.CardBasic().Title("Uptime").Text("99.98%");
                });
            });
        });
        row.Column(TablerColumnNumber.Eight, column => {
            column.Card(card => {
                card.Logs("HTTP/1.1 200 Connection established").Title(HeaderLevelTag.H4, "Connection");
                card.Logs(logs).Title(HeaderLevelTag.H4, "Timings");
            });

        });
        row.Column(TablerColumnNumber.Four, column => {
            column.Card(card => {
                card.Steps().Color(TablerColor.AzureLight)
                    .AddStep("Order received", false)
                    .AddStep("Processing", true)
                    .AddStep("Shipped", false)
                    .AddStep("Delivered", false);

            });
        });
        row.Column(TablerColumnNumber.Four, column => {
            column.Card(card => {
                card.Steps().Orientation(StepsOrientation.Vertical).Color(TablerColor.Facebook)
                    .AddStep("Order received", "text", false)
                    .AddStep("Processing", "more text", true)
                    .AddStep("Shipped", "oops", false)
                    .AddStep("Delivered", "opps", false);
            });
        });
        row.Column(TablerColumnNumber.Four, column => {
            column.Card(card => {
                card.Steps().StepCounting().Color(TablerColor.Red)
                    .AddStep("Order received", false)
                    .AddStep("Processing", true)
                    .AddStep("Shipped", false)
                    .AddStep("Delivered", false);
            });
        });
        row.Column(TablerColumnNumber.Twelve, column => {
            column.Card(card => {
                card.Accordion(accordion => {
                    // works
                    accordion.AddItem("John", new Span().AddContent("Test1"));
                    // works
                    accordion.AddItem("Jane", new Span().AddContent("Test2"));
                    // works
                    accordion.AddItem("Johny", item => {
                        item.Content(new Span().AddContent("Test2"));
                        item.Content(new TablerSteps().StepCounting().Color(TablerColor.Red)
                            .AddStep("Order received", false)
                            .AddStep("Processing", true)
                            .AddStep("Shipped", false)
                            .AddStep("Delivered", false));
                    });
                    accordion.AddItem("Johny 2").Content(item => {
                        item.Steps().StepCounting().Color(TablerColor.Red)
                            .AddStep("Order received", false)
                            .AddStep("Processing", true)
                            .AddStep("Shipped", false)
                            .AddStep("Delivered", false);
                    });

                    accordion.AddItem("Johny 2").Content(item => {
                        item.DataGrid(grid => {
                            grid.AddItem("Test", "Ok");
                            grid.AddItem("Test2", "Ok2");
                        });
                    });
                });
            });
        });
        row.Column(TablerColumnNumber.Six, column => {
            column.Card(card => {
                card.Logs("HTTP/1.1 200 Connection established").Title(HeaderLevelTag.H4, "Connection");
                card.Footer().Logs(logs).Title(HeaderLevelTag.H4, "Timings");

            });
        });

        row.Column(TablerColumnNumber.Six, column => {
            column.Card(card => {
                card.Logs("HTTP/1.1 200 Connection established").Title(HeaderLevelTag.H4, "Connection");

                card.Footer(cardFooter => {
                    cardFooter.Logs(logs).Title(HeaderLevelTag.H4, "Timings");
                    cardFooter.Logs(logs).Title(HeaderLevelTag.H4, "Timings");
                });

            });
        });

        row.Column(TablerColumnNumber.Six, column => {
            column.Card(card => {
                card.Row(rowWithinCard => {
                    rowWithinCard.Column(TablerColumnNumber.Twelve, column => {
                        column.CardBasic("Currently Up for", "14 days 2 hours 54 minutes 32 seconds");
                    });
                    rowWithinCard.Column(TablerColumnNumber.Twelve, column => {
                        column.CardBasic().Title("Last checked at").Text("27 seconds ago");
                    });
                });
            });
        });
        row.Column(TablerColumnNumber.Six, column => {
            column.Card(card => {
                card.Row(rowWithinCard => {
                    rowWithinCard.Column(TablerColumnNumber.MediumAuto, column => {
                        column.CardBasic("Currently Up for", "14 days 2 hours 54 minutes 32 seconds");
                    });
                    rowWithinCard.Column(TablerColumnNumber.MediumAuto, column => {
                        column.CardBasic().Title("Last checked at").Text("27 seconds ago");
                    });
                });
            });
        });

        row.Column(TablerColumnNumber.Six, column => {
            column.Tabs(tabs => {
                //tabs.Navigation(TabNavigation.Fill);
                tabs.AddTab("Tab 1", new Strong("Content 1")).Active();
                tabs.AddTab("Tab 2", new Strong("Content 2")).Disabled();
                tabs.AddTab("Tab 3", new Strong("Content 3")).MoveTabs(TabState.MoveStart);
            });
        });


    });

    page.Divider("Test2");

    page.Row(row => {
        // first line of 4 cards
        row.Column(TablerColumnNumber.Three, column => {
            column.Card(card => {
                card.Alert("Wow! Everything worked!", "Your account has been created!")
                    .Icon(TablerIcon.BrandTwitter).Color(TablerColor.Danger);
            });
        });
        row.Column(TablerColumnNumber.Three, column => {
            column.Card(card => {
                card.Alert("Wow! Everything worked!", "Your account has been created!")
                    .Color(TablerColor.Facebook);
            });
        });
        row.Column(TablerColumnNumber.Three, column => {
            column.Card(card => {
                card.Alert("Did you know?", "Here is something that you might like to know.", TablerColor.Green,
                    TablerAlertType.Dismissible).Icon(TablerIcon.InfoCircle);
            });
        });
        row.Column(TablerColumnNumber.Three, column => {
            column.Card(card => {
                card.Alert("Wow! Everything worked!", "Your account has been created!")
                    .Icon(TablerIcon.ExclamationCircle).Color(TablerColor.Twitter);
            });
        });
        row.Column(TablerColumnNumber.Three, column => {
            column.Card(card => {
                card.Alert("I'm so sorry…", "Your account has been deleted and can't be restored.")
                    .Icon(TablerIcon.FaceIdError).Color(TablerColor.Warning);
            });
        });
        row.Column(TablerColumnNumber.Three, column => {
            column.Card(card => {
                card.Tracking()
                    .Block("Operational", TablerColor.Success)
                    .Block("Operational", TablerColor.Success)
                    .Block("Operational", TablerColor.Success)
                    .Block("Operational", TablerColor.Success)
                    .Block("Operational", TablerColor.Success)
                    .Block("No data", TablerColor.Failed)
                    .Block("No data", TablerColor.Failed)
                    .Block("Operational", TablerColor.Success)
                    .Block("Operational", TablerColor.Success)
                    .Block("Operational", TablerColor.Success)
                    .Block("Operational", TablerColor.Success)
                    .Block("Operational", TablerColor.Success)
                    .Block("Downtime", TablerColor.Danger)
                    .Block("Operational", TablerColor.Success)
                    .Block("Operational", TablerColor.Success)
                    .Block("Operational", TablerColor.Success)
                    .Block("Operational", TablerColor.Success)
                    .Block("Operational", TablerColor.Success)
                    .Block("Operational", TablerColor.Success);
            });
        });
        row.Column(TablerColumnNumber.Three, column => {
            column.Card(card => {
                card.Avatar().Icon(TablerIcon.BrandTwitter).Margin(TablerMarginStyle.M2);
            });
        });
        row.Column(TablerColumnNumber.Three, column => {
            column.Card(card => {
                card.Avatar()
                    .Image(
                        "https://upload.wikimedia.org/wikipedia/commons/thumb/6/61/HTML5_logo_and_wordmark.svg/1920px-HTML5_logo_and_wordmark.svg.png")
                    .Size(AvatarSize.MD)
                    .Margin(TablerMarginStyle.M2);
            });
        });
    });
});
document.Save("BasicDemoDocumentContainer04.html", openInBrowser);
```


## Support This Project

If you find this project helpful, please consider supporting its development.
Your sponsorship will help the maintainers dedicate more time to maintenance and new feature development for everyone.

It takes a lot of time and effort to create and maintain this project.
By becoming a sponsor, you can help ensure that it stays free and accessible to everyone who needs it.

To become a sponsor, you can choose from the following options:

 - [Become a sponsor via GitHub Sponsors :heart:](https://github.com/sponsors/PrzemyslawKlys)
 - [Become a sponsor via PayPal :heart:](https://paypal.me/PrzemyslawKlys)

Your sponsorship is completely optional and not required for using this project.
We want this project to remain open-source and available for anyone to use for free,
regardless of whether they choose to sponsor it or not.

If you work for a company that uses our .NET libraries or PowerShell Modules,
please consider asking your manager or marketing team if your company would be interested in supporting this project.
Your company's support can help us continue to maintain and improve this project for the benefit of everyone.

Thank you for considering supporting this project!

## Please share with the community

Please consider sharing a post about HtmlForgeX and the value it provides. It really does help!

[![Share on reddit](https://img.shields.io/badge/share%20on-reddit-red?logo=reddit)](https://reddit.com/submit?url=https://github.com/EvotecIT/HtmlForgeX&title=HtmlForgeX)
[![Share on hacker news](https://img.shields.io/badge/share%20on-hacker%20news-orange?logo=ycombinator)](https://news.ycombinator.com/submitlink?u=https://github.com/EvotecIT/HtmlForgeX)
[![Share on twitter](https://img.shields.io/badge/share%20on-twitter-03A9F4?logo=twitter)](https://twitter.com/share?url=https://github.com/EvotecIT/HtmlForgeX&t=HtmlForgeX)
[![Share on facebook](https://img.shields.io/badge/share%20on-facebook-1976D2?logo=facebook)](https://www.facebook.com/sharer/sharer.php?u=https://github.com/EvotecIT/HtmlForgeX)
[![Share on linkedin](https://img.shields.io/badge/share%20on-linkedin-3949AB?logo=linkedin)](https://www.linkedin.com/shareArticle?url=https://github.com/EvotecIT/HtmlForgeX&title=HtmlForgeX)

## SVG Icon System

### Migration from TablerIcon

**Old TablerIcon System (REPLACED):**
```csharp
// OLD: CSS-based icons with external dependencies
TablerIcon.ArrowDown   // "ti-arrow-down"
TablerIcon.Settings    // "ti-settings"
TablerIcon.User        // "ti-user"
```

**New SVG Icon System:**
```csharp
// NEW: Direct SVG with full styling control
SvgIconLibrary.GetIcon(TablerIconType.ArrowDown)
SvgIconLibrary.GetIcon(TablerIconType.Settings)
SvgIconLibrary.GetIcon(TablerIconType.User)

// With advanced styling capabilities
var styledIcon = SvgIconLibrary.GetIcon(TablerIconType.Heart)
    .Size(32)
    .StrokeColor(RGBColor.Red)
    .FillColor(RGBColor.Pink)
    .Rotate(45)
    .AddStyle("filter", "drop-shadow(2px 2px 4px rgba(0,0,0,0.3))");
```

### Benefits of New System

✅ **1,780+ Icons Available** - Download-on-demand from GitHub
✅ **Zero External Dependencies** - No CSS files needed
✅ **Full Styling Control** - Colors, sizes, transforms, custom CSS
✅ **Crisp SVG Rendering** - Vector graphics, not font icons
✅ **Transform Support** - Rotate, scale, position
✅ **Custom Styling** - Filters, shadows, animations
✅ **Clean Repository** - No large icon files to commit

### Icon Generation

The system automatically downloads and generates icons during build:

```powershell
# Manual regeneration (only when needed)
.\Regenerate-Icons.ps1

# Force regeneration
.\Regenerate-Icons.ps1 -Force

# Generate specific icon sets
.\Regenerate-Icons.ps1 -IconSet outline -MaxIcons 500
```

**Performance:**
- **First build:** ~15 seconds (downloads + generates)
- **Subsequent builds:** ~0 seconds (smart change detection)

---

*The new SVG system completely replaces the old 5,000+ line TablerIcon class with a modern, flexible, and dependency-free approach.*
