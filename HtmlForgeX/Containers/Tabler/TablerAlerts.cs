namespace HtmlForgeX;

/// <summary>
/// Component for displaying alert messages in Tabler style.
/// </summary>
public class TablerAlert : Element {
    private string Title { get; }
    private string Message { get; }
    private TablerColor AlertColor { get; set; }
    private TablerAlertType AlertType { get; }
    private TablerIconElement? AlertIcon { get; set; }
    private string AlertImportant { get; set; }
    private string AlertMinor { get; set; }
    private bool UseHeadingStyle { get; set; }
    private string? ActionHref { get; set; }
    private string? ActionText { get; set; }

    /// <summary>
    /// Initializes or configures TablerAlert.
    /// </summary>
    public TablerAlert(string title, string message, TablerColor alertColor = TablerColor.Default, TablerAlertType alertType = TablerAlertType.Regular) {
        Title = title;
        Message = message;
        AlertColor = alertColor;
        AlertType = alertType;
    }

    /// <summary>
    /// Initializes or configures Icon.
    /// </summary>
    public TablerAlert Icon(TablerIconType TablerIconType) {
        AlertIcon = new TablerIconElement(TablerIconType).FontSize(24);
        return this;
    }

    /// <summary>
    /// Initializes or configures Color.
    /// </summary>
    public TablerAlert Color(TablerColor color) {
        AlertColor = color;
        return this;
    }

    /// <summary>
    /// Initializes or configures Important.
    /// </summary>
    public TablerAlert Important() {
        AlertImportant = "alert-important";
        return this;
    }

    /// <summary>
    /// Initializes or configures Minor.
    /// </summary>
    public TablerAlert Minor() {
        AlertMinor = "alert-minor";
        return this;
    }

    /// <summary>
    /// Initializes or configures WithDescription.
    /// </summary>
    public TablerAlert WithDescription() {
        UseHeadingStyle = true;
        return this;
    }

    /// <summary>
    /// Initializes or configures Action.
    /// </summary>
    public TablerAlert Action(string href, string text) {
        ActionHref = href;
        ActionText = text;
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var alertTypeClass = AlertType == TablerAlertType.Dismissible ? "alert-dismissible" : "";
        var alertTag = new HtmlTag("div")
            .Class("alert")
            .Class(AlertColor.ToTablerAlert())
            .Class(alertTypeClass)
            .Class(AlertImportant)
            .Class(AlertMinor)
            .Attribute("role", "alert");

        if (AlertIcon != null) {
            var divIcon = new HtmlTag("div").Class("alert-icon").Value(AlertIcon);
            alertTag.Value(divIcon);
        }

        if (!string.IsNullOrEmpty(Title) || !string.IsNullOrEmpty(Message)) {
            var divAlertDetails = new HtmlTag("div");
            if (!string.IsNullOrEmpty(Title)) {
                var cls = UseHeadingStyle ? "alert-heading" : "alert-title";
                divAlertDetails.Value(new HtmlTag("h4").Class(cls).Value(Title));
            }
            if (!string.IsNullOrEmpty(Message)) {
                var cls = UseHeadingStyle ? "alert-description" : "text-secondary";
                divAlertDetails.Value(new HtmlTag("div").Class(cls).Value(Message));
            }
            alertTag.Value(divAlertDetails);
        }

        if (!string.IsNullOrEmpty(ActionHref) && !string.IsNullOrEmpty(ActionText)) {
            alertTag.Value(new Anchor(ActionHref, ActionText).Class("alert-action"));
        }

        if (AlertType == TablerAlertType.Dismissible) {
            alertTag.Value(new HtmlTag("a").Class("btn-close").Attribute("data-bs-dismiss", "alert").Attribute("aria-label", "close"));
        }


        return alertTag.ToString();
    }
}