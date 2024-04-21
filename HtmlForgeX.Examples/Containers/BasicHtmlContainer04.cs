using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlForgeX.Examples.Containers;
internal class BasicHtmlContainer04 {
    public static void Demo01(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Basic Demo Document Container 4");

        // Create a list of simple objects
        var data = new List<dynamic> {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
            new { Name = "Bob", Age = 35, Occupation = "Architect" }
        };

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
                    column.CardMini().Avatar(TablerIcon.BrandFacebook).BackgroundColor(BadgeColor.Blue).TextColor(BadgeColor.White).Title("172 likes").Subtitle("2 today");
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.CardMini().Avatar(TablerIcon.BrandTwitter).BackgroundColor(BadgeColor.Blue).TextColor(BadgeColor.White).Title("600 shares").Subtitle("16 today");
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.CardMini().Avatar(TablerIcon.ShoppingCart).BackgroundColor(BadgeColor.Cyan).TextColor(BadgeColor.Orange).Title("100 orders").Subtitle("0 today");
                });
                row.Column(TablerColumnNumber.Three, column => {
                    column.CardMini().Avatar(TablerIcon.CurrencyDollar).BackgroundColor(BadgeColor.Azure).TextColor(BadgeColor.White).Title("5 sales").Subtitle("3 waiting");
                });
                // second line of 3 cards
                row.Column(TablerColumnNumber.Four, column => {
                    // let's build a card with an avatar manually
                    column.Card(card => {
                        card.Row(cardTitle => {
                            cardTitle.HeaderLevel(HeaderLevel.H3, "Title").Class("card-title");
                        });
                        card.Row(cardRow => {
                            cardRow.Column(TablerColumnNumber.Auto, avatarColumn => {
                                avatarColumn.Avatar().Icon(TablerIcon.License).BackgroundColor(BadgeColor.Cyan).TextColor(BadgeColor.Blue);
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
                        card.Add(new TablerAvatar().Icon(TablerIcon.License).BackgroundColor(BadgeColor.Cyan).TextColor(BadgeColor.Blue));
                    });
                });
                row.Column(TablerColumnNumber.Four, column => {
                    column.CardMini().Avatar(TablerIcon.License);

                });


            });
        });

        document.Save("BasicDemoDocumentContainer04.html", openInBrowser);
    }
}
