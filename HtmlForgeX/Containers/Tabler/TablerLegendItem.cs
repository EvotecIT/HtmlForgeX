namespace HtmlForgeX;

/// <summary>
/// Represents a legend entry consisting of a colored indicator and label.
/// </summary>
public class TablerLegendItem : Element {
    private string Name { get; set; }
    private string Value { get; set; }
    private TablerColor Color { get; set; }
    private string PaddingClass { get; set; }

    /// <summary>
    /// Initializes or configures TablerLegendItem.
    /// </summary>
    public TablerLegendItem(string name, string value, TablerColor color, string paddingClass) {
        Name = name;
        Value = value;
        Color = color;
        PaddingClass = paddingClass;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var legendTag = new HtmlTag("span")
            .Class("legend")
            .Class(Color.ToTablerBackground());

        var nameTag = new HtmlTag("span")
            .Value(Name);

        var valueTag = new HtmlTag("span")
            .Class("d-none")
            .Class("d-md-inline")
            .Class("d-lg-none")
            .Class("d-xxl-inline")
            .Class("ms-2")
            .Class("text-muted")
            .Value(Value);

        // finally, wrap it all up in a div
        var divTag = new HtmlTag("div")
            .Class("col-auto")
            .Class("d-flex")
            .Class("align-items-center")
            .Class(PaddingClass)
            .Value(legendTag, nameTag, valueTag);

        return divTag.ToString();
    }
}