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
                    col.Row(inner => {
                        inner.Column(TablerColumnNumber.Twelve, c => {
                            c.Card(card => {
                                card.Row(title => {
                                    title.HeaderLevel(HeaderLevelTag.H3, "Basic").Class("card-title");
                                });
                                card.Add(CreateRating("rating-default"));
                            });
                        });
                        inner.Column(TablerColumnNumber.Twelve, c => {
                            c.Card(card => {
                                card.Row(title => {
                                    title.HeaderLevel(HeaderLevelTag.H3, "Different icon").Class("card-title");
                                });
                                var iconContainer = new HtmlTag("div");
                                iconContainer.Class("space-y");
                                iconContainer.Value(CreateRating("rating-heart"));
                                iconContainer.Value(CreateRating("rating-ghost"));
                                iconContainer.Value(CreateRating("rating-circle"));
                                card.Add(iconContainer);
                            });
                        });
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Row(title => {
                            title.HeaderLevel(HeaderLevelTag.H3, "Custom colors").Class("card-title");
                        });
                        var colorContainer = new HtmlTag("div");
                        colorContainer.Class("space-y");
                        colorContainer.Value(CreateRating("rating-color"));
                        colorContainer.Value(CreateRating("rating-color-primary"));
                        colorContainer.Value(CreateRating("rating-color-red"));
                        colorContainer.Value(CreateRating("rating-color-lime"));
                        card.Add(colorContainer);
                    });
                });
                row.Column(TablerColumnNumber.Four, col => {
                    col.Card(card => {
                        card.Row(title => {
                            title.HeaderLevel(HeaderLevelTag.H3, "Custom sizes").Class("card-title");
                        });
                        var sizeContainer = new HtmlTag("div");
                        sizeContainer.Class("space-y");
                        sizeContainer.Value(CreateRating("rating-size-sm"));
                        sizeContainer.Value(CreateRating("rating-size-primary"));
                        sizeContainer.Value(CreateRating("rating-size-md"));
                        sizeContainer.Value(CreateRating("rating-size-lg"));
                        card.Add(sizeContainer);
                    });
                });
            });
        });

        var heartIcon = new TablerIconElement(TablerIconType.Heart).FillColor(RGBColor.Red).ToString().Replace("\"", "\\\"");
        var ghostIcon = new TablerIconElement(TablerIconType.Ghost).FillColor(RGBColor.Azure).ToString().Replace("\"", "\\\"");
        var circleIcon = new TablerIconElement(TablerIconType.Circle).FillColor(RGBColor.Green).ToString().Replace("\"", "\\\"");

        var starPrimary = new TablerIconElement(TablerIconType.Star).FillColor(RGBColor.Blue).ToString().Replace("\"", "\\\"");
        var starRed = new TablerIconElement(TablerIconType.Star).FillColor(RGBColor.Red).ToString().Replace("\"", "\\\"");
        var starLime = new TablerIconElement(TablerIconType.Star).FillColor(RGBColor.Lime).ToString().Replace("\"", "\\\"");

        var starSm = new TablerIconElement(TablerIconType.Star).FontSize(16).ToString().Replace("\"", "\\\"");
        var starMd = new TablerIconElement(TablerIconType.Star).FontSize(32).ToString().Replace("\"", "\\\"");
        var starLg = new TablerIconElement(TablerIconType.Star).FontSize(48).ToString().Replace("\"", "\\\"");

        document.Head.AddJsInline($@"document.addEventListener('DOMContentLoaded', function() {{
    new StarRating('#rating-default');
    new StarRating('#rating-heart', {{ stars: () => '{heartIcon}' }});
    new StarRating('#rating-ghost', {{ stars: () => '{ghostIcon}' }});
    new StarRating('#rating-circle', {{ stars: () => '{circleIcon}' }});
    new StarRating('#rating-color');
    new StarRating('#rating-color-primary', {{ stars: () => '{starPrimary}' }});
    new StarRating('#rating-color-red', {{ stars: () => '{starRed}' }});
    new StarRating('#rating-color-lime', {{ stars: () => '{starLime}' }});
    new StarRating('#rating-size-sm', {{ stars: () => '{starSm}' }});
    new StarRating('#rating-size-primary', {{ stars: () => '{starPrimary}' }});
    new StarRating('#rating-size-md', {{ stars: () => '{starMd}' }});
    new StarRating('#rating-size-lg', {{ stars: () => '{starLg}' }});
}});");

        document.Save("StarRatingDemo.html", openInBrowser);
    }

    private static TablerStarRating CreateRating(string id) {
        return new TablerStarRating { Id = id, Class = "star-rating" }
            .Option(5, "Excellent")
            .Option(4, "Very Good", true)
            .Option(3, "Average")
            .Option(2, "Poor")
            .Option(1, "Terrible");
    }
}
