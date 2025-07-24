using System;

namespace HtmlForgeX.Examples.Tabler;

internal static class TablerTagDemo {
    public static void Create(bool openInBrowser = false) {
        using var document = new Document { Head = { Title = "Tag Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column => {
                    column.Card(card => {
                        card.DataGrid(dataGrid => {
                            dataGrid.Title("Tag").Content(new TablerTag("Example", TablerColor.Green).Dismissable());
                            dataGrid.Title("Large Tag").Content(new TablerTag("Download", TablerColor.Lime).TagSize(TablerTagSize.Large).Dismissable());
                            dataGrid.Title("Small Tag").Content(new TablerTag("Download", TablerColor.AzureLight).TagSize(TablerTagSize.Small).Dismissable());
                        });
                    });
                });
            });
        });

        document.Save("TablerTagDemo.html", openInBrowser);
    }
}
