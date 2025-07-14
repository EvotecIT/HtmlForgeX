namespace HtmlForgeX.Examples.Tags;

internal static class ExampleTablerProgressBarShowcase {
    public static void Create(bool openInBrowser = false) {
        var document = new Document { Head = { Title = "Progress Bar Showcase" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column => {
                    column.Card(card => {
                        card.Content("Demonstrates various progress bar configurations.");
                        card.Add(new TablerProgressBar().Item(TablerColor.Primary, 20, "Default 20%"));
                        card.LineBreak();
                        card.Add(new TablerProgressBar().Item(TablerColor.Success, 75, "Success 75%"));
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Small).Item(TablerColor.Danger, 45, "Small Danger 45%");
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Separated)
                            .Item(TablerColor.Primary, 30, "A")
                            .Item(TablerColor.Info, 70, "B");
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Indeterminate).Item(TablerColor.Primary, 100, "Indeterminate");
                        card.LineBreak();
                        card.Add(new TablerProgressBar().Margin(TablerMargin.BottomNormal)
                            .Item(TablerColor.Warning, 50, "With Margin"));
                        card.LineBreak();
                        card.Add(new TablerProgressBar().Padding(TablerPadding.VerticalHalf)
                            .Item(TablerColor.Cyan, 60, "With Padding"));
                        card.LineBreak();
                        card.Add(new TablerProgressBar().Margin(TablerMargin.TopHalf)
                            .Padding(TablerPadding.HorizontalQuarter)
                            .Item(TablerColor.Lime, 40, "Margin & Padding"));
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Small, 50, TablerColor.Facebook);
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Small)
                            .Item(TablerColor.Primary, 33, "One")
                            .Item(TablerColor.Success, 33, "Two")
                            .Item(TablerColor.Danger, 34, "Three");
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Separated, 100, TablerColor.Red);
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Small, 20, TablerColor.Indigo);
                        card.LineBreak();
                        card.Add(new TablerProgressBar(TablerProgressBarType.Indeterminate)
                            .Margin(TablerMargin.TopQuarter)
                            .Item(TablerColor.Teal, 100, "Indeterminate w/ margin"));
                        card.LineBreak();
                        card.Add(new TablerProgressBar().Item(TablerColor.Purple, 80, "Purple 80%"));
                        card.LineBreak();
                        card.Add(new TablerProgressBar().Item(TablerColor.Yellow, 10, "Yellow 10%"));
                        card.LineBreak();
                        card.Add(new TablerProgressBar().Item(TablerColor.Cyan, 75, "Cyan 75%"));
                        card.LineBreak();
                        card.Add(new TablerProgressBar().Item(TablerColor.Black, 100, "Complete"));
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Separated)
                            .Item(TablerColor.Green, 25, "A")
                            .Item(TablerColor.Red, 75, "B");
                        card.LineBreak();
                        card.Add(new TablerProgressBar().Item(TablerColor.Pink, 40, "Pink 40%"));
                        card.LineBreak();
                        card.ProgressBar(TablerProgressBarType.Small).Item(TablerColor.Lime, 55, "Lime 55%");
                    });
                });
            });
            page.Row(row => {
                row.Column(column => {
                    column.Card(card => {
                        card.ProgressBar(TablerProgressBarType.Small)
                            .Item(TablerColor.Primary, 40, "Upload")
                            .Item(TablerColor.Success, 60, "Process")
                            .Margin(TablerMargin.BottomNormal);
                        card.ProgressBar(TablerProgressBarType.Separated)
                            .Item(TablerColor.Green, 25, "A")
                            .Item(TablerColor.Red, 75, "B")
                            .Margin(TablerMargin.BottomAuto)
                            .Padding(TablerPadding.HorizontalQuarter);
                    });
                });
            });
        });

        document.Save("ProgressBarShowcase.html", openInBrowser);
    }
}
