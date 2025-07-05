using System;
namespace HtmlForgeX.Examples.Containers;

internal class ExampleStarRating {
    public static void Demo(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Star Rating Demo");

        var document = new Document {
            Head = {
                Title = "Star Rating Demo",
                Author = "HtmlForgeX",
                Revised = DateTime.Now
            },
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        document.Body.Page(page => {
            page.Layout = TablerLayout.Fluid;
            page.Row(row => {
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Row(title => {
                            title.HeaderLevel(HeaderLevelTag.H3, "Basic").Class("card-title");
                        });
                        card.Add(new TablerStarRating { Id = "rating-default", Class = "star-rating" }
                            .Option(5, "Excellent")
                            .Option(4, "Very Good", true)
                            .Option(3, "Average")
                            .Option(2, "Poor")
                            .Option(1, "Terrible"));
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Row(title => {
                            title.HeaderLevel(HeaderLevelTag.H3, "Heart Icon").Class("card-title");
                        });
                        card.Add(new TablerStarRating { Id = "rating-heart", Class = "star-rating" }
                            .Option(5, "Excellent")
                            .Option(4, "Very Good", true)
                            .Option(3, "Average")
                            .Option(2, "Poor")
                            .Option(1, "Terrible"));
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Row(title => {
                            title.HeaderLevel(HeaderLevelTag.H3, "Ghost Icon").Class("card-title");
                        });
                        card.Add(new TablerStarRating { Id = "rating-ghost", Class = "star-rating" }
                            .Option(5, "Excellent")
                            .Option(4, "Very Good", true)
                            .Option(3, "Average")
                            .Option(2, "Poor")
                            .Option(1, "Terrible"));
                    });
                });
            });
        });

        var heartIcon = new TablerIconElement(TablerIconType.Heart).FillColor(RGBColor.Red).ToString().Replace("\"", "\\\"");
        var ghostIcon = new TablerIconElement(TablerIconType.Ghost).FillColor(RGBColor.Azure).ToString().Replace("\"", "\\\"");

        document.Head.AddJsInline($@"document.addEventListener('DOMContentLoaded', function() {{
    new StarRating('#rating-default');
    new StarRating('#rating-heart', {{ stars: () => '{heartIcon}' }});
    new StarRating('#rating-ghost', {{ stars: () => '{ghostIcon}' }});
}});");

        document.Save("StarRatingDemo.html", openInBrowser);
    }
}
