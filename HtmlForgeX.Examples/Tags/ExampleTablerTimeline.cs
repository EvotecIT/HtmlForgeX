namespace HtmlForgeX.Examples.Tags;

internal static class ExampleTablerTimeline {
    public static void Create(bool openInBrowser = false) {
        using var document = new Document { Head = { Title = "Timeline Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column => {
                    column.Card(card => {
                        card.Timeline(timeline => {
                            timeline.Item(item => {
                                item.Time(DateTime.Now.AddHours(-2))
                                    .Icon(TablerIconType.TimelineEventPlus)
                                    .Color(TablerColor.Success)
                                    .Title("Task Created")
                                    .Description("The task was created.");
                            });
                            timeline.Item(item => {
                                item.Time(DateTime.Now.AddHours(-1))
                                    .Icon(TablerIconType.TimelineEvent)
                                    .Color(TablerColor.Warning)
                                    .Title("Task Running")
                                    .Description("Processing in progress...");
                            });
                            timeline.Item(item => {
                                item.Time(DateTime.Now)
                                    .Icon(TablerIconType.Check)
                                    .Color(TablerColor.Blue)
                                    .Title("Task Completed")
                                    .Description("The task finished successfully.");
                            });
                        });
                    });
                });
            });
        });

        document.Save("TimelineDemo.html", openInBrowser);
    }
}
