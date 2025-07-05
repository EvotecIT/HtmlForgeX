namespace HtmlForgeX.Examples.Tags;

internal static class ExampleTablerAlerts {
    public static void Demo() {
        var document = new Document { Head = { Title = "Alerts Demo" } };
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(column => {
                    column.Card(card => {
                        card.Alert(string.Empty, "An error occurred!", TablerColor.Danger)
                            .Icon(TablerIconType.AlertCircle);
                        card.Alert(string.Empty, "Some information is missing!", TablerColor.Warning)
                            .Icon(TablerIconType.AlertTriangle);
                        card.Alert(string.Empty, "Completed successfully!", TablerColor.Success)
                            .Icon(TablerIconType.Check);
                        card.Alert(string.Empty, "Just a quick note!", TablerColor.Info)
                            .Icon(TablerIconType.InfoCircle);
                    });
                });
                row.Column(column => {
                    column.Card(card => {
                        card.Alert(string.Empty, "An error occurred!", TablerColor.Danger, TablerAlertType.Dismissible)
                            .Icon(TablerIconType.AlertCircle)
                            .Action("https://example.com", "Link");
                        card.Alert(string.Empty, "Some information is missing!", TablerColor.Warning, TablerAlertType.Dismissible)
                            .Icon(TablerIconType.AlertTriangle)
                            .Action("https://example.com", "Link");
                        card.Alert(string.Empty, "Completed successfully!", TablerColor.Success, TablerAlertType.Dismissible)
                            .Icon(TablerIconType.Check)
                            .Action("https://example.com", "Link");
                        card.Alert(string.Empty, "Just a quick note!", TablerColor.Info, TablerAlertType.Dismissible)
                            .Icon(TablerIconType.InfoCircle)
                            .Action("https://example.com", "Link");
                    });
                });
                row.Column(column => {
                    column.Card(card => {
                        card.Alert("Password does not meet requirements:", "<ul class=\"alert-list\"><li>Minimum 8 characters</li><li>Include a special character</li></ul>", TablerColor.Danger, TablerAlertType.Dismissible)
                            .WithDescription()
                            .Icon(TablerIconType.AlertCircle);
                        card.Alert("Some information is missing!", "This is a custom alert box with a description.", TablerColor.Warning, TablerAlertType.Dismissible)
                            .WithDescription()
                            .Icon(TablerIconType.AlertTriangle);
                        card.Alert("Completed successfully!", "This is a custom alert box with a description.", TablerColor.Success, TablerAlertType.Dismissible)
                            .WithDescription()
                            .Icon(TablerIconType.Check);
                        card.Alert("Just a quick note!", "This is a custom alert box with a description.", TablerColor.Info, TablerAlertType.Dismissible)
                            .WithDescription()
                            .Icon(TablerIconType.InfoCircle);
                    });
                });
                row.Column(column => {
                    column.Card(card => {
                        card.Alert("Password does not meet requirements:", "<ul class=\"alert-list\"><li>Minimum 8 characters</li><li>Include a special character</li></ul>", TablerColor.Danger, TablerAlertType.Dismissible)
                            .WithDescription()
                            .Icon(TablerIconType.AlertCircle)
                            .Important();
                        card.Alert("This is a custom alert box!", "This is a custom alert box with a description.", TablerColor.Success, TablerAlertType.Dismissible)
                            .WithDescription()
                            .Icon(TablerIconType.Check)
                            .Important();
                        card.Alert("This is a custom alert box!", "This is a custom alert box with a description.", TablerColor.Warning, TablerAlertType.Dismissible)
                            .WithDescription()
                            .Icon(TablerIconType.AlertTriangle)
                            .Important();
                        card.Alert("This is a custom alert box!", "This is a custom alert box with a description.", TablerColor.Info, TablerAlertType.Dismissible)
                            .WithDescription()
                            .Icon(TablerIconType.InfoCircle)
                            .Important();
                    });
                });
                row.Column(column => {
                    column.Card(card => {
                        card.Alert("Password does not meet requirements:", "<ul class=\"alert-list\"><li>Minimum 8 characters</li><li>Include a special character</li></ul>", TablerColor.Danger, TablerAlertType.Dismissible)
                            .WithDescription()
                            .Icon(TablerIconType.AlertCircle)
                            .Minor();
                        card.Alert("This is a custom alert box!", "This is a custom alert box with a description.", TablerColor.Success, TablerAlertType.Dismissible)
                            .WithDescription()
                            .Icon(TablerIconType.Check)
                            .Minor();
                        card.Alert("This is a custom alert box!", "This is a custom alert box with a description.", TablerColor.Warning, TablerAlertType.Dismissible)
                            .WithDescription()
                            .Icon(TablerIconType.AlertTriangle)
                            .Minor();
                        card.Alert("This is a custom alert box!", "This is a custom alert box with a description.", TablerColor.Info, TablerAlertType.Dismissible)
                            .WithDescription()
                            .Icon(TablerIconType.InfoCircle)
                            .Minor();
                    });
                });
            });
        });

        document.Save("TablerAlertsDemo.html", true);
    }
}
