namespace HtmlForgeX.Examples.Tabler;

internal static class TablerStarRatingDemo {
    public static void Create(bool openInBrowser = false) {
        using var document = new Document { Head = { Title = "Star Rating Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column => {
                    column.Card(card => {
                        card.Form(form => {
                            form.StarRating("rating", r => r.MaxStars(5).Value(4).OnChange("console.log('changed')"));
                        });
                    });
                });
            });
        });
        document.Save("TablerStarRatingDemo.html", openInBrowser);
    }
}