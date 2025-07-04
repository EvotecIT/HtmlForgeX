namespace HtmlForgeX;

public class TablerAlert : Element {
    private string Title { get; }
    private string Message { get; }
    private TablerColor AlertColor { get; set; }
    private TablerAlertType AlertType { get; }
    private TablerIconElement? AlertIcon { get; set; }
    private string AlertImportant { get; set; }

    public TablerAlert(string title, string message, TablerColor alertColor = TablerColor.Default, TablerAlertType alertType = TablerAlertType.Regular) {
        Title = title;
        Message = message;
        AlertColor = alertColor;
        AlertType = alertType;
    }

    public TablerAlert Icon(TablerIconType TablerIconType) {
        AlertIcon = new TablerIconElement(TablerIconType).FontSize(24);
        return this;
    }

    public TablerAlert Color(TablerColor color) {
        AlertColor = color;
        return this;
    }

    public TablerAlert Important() {
        AlertImportant = "alert-important";
        return this;
    }

    public override string ToString() {
        var alertTypeClass = AlertType == TablerAlertType.Dismissible ? "alert-dismissible" : "";
        var alertTag = new HtmlTag("div")
            .Class("alert")
            .Class(AlertColor.ToTablerAlert())
            .Class(alertTypeClass)
            .Class(AlertImportant)
            .Attribute("role", "alert");

        var flex = new HtmlTag("div").Class("d-flex");

        var divAlertDetails = new HtmlTag("div");

        if (AlertIcon != null) {
            var divIcon = new HtmlTag("div")
                .Value(AlertIcon)
                .Value(new NonBreakingSpace(), new NonBreakingSpace()); // Add some space between icon and text, not great but works

            flex.Value(divIcon);
        }

        if (!string.IsNullOrEmpty(Title)) {
            divAlertDetails.Value(new HtmlTag("h4").Class("alert-title").Value(Title));
        }

        if (!string.IsNullOrEmpty(Message)) {
            divAlertDetails.Value(new HtmlTag("div").Class("text-secondary").Value(Message));
        }
        flex.Value(divAlertDetails);
        alertTag.Value(flex);

        if (AlertType == TablerAlertType.Dismissible) {
            alertTag.Value(new HtmlTag("a").Class("btn-close").Attribute("data-bs-dismiss", "alert").Attribute("aria-label", "close"));
        }


        return alertTag.ToString();
    }
}
