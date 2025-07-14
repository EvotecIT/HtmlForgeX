namespace HtmlForgeX;

public class TablerCardBasic : Element {
    private string? PrivateCardStyle { get; set; }
    private string SubHeaderText { get; set; } = "";
    private string H3Text { get; set; } = "";
    private TablerMarginStyle? PrivateMargin { get; set; }
    private bool AutoMargin { get; set; } = true; // Enable automatic margin detection by default

    public TablerCardBasic() { }

    public TablerCardBasic(string title, string text) {
        SubHeaderText = title;
        H3Text = text;
    }

/// <summary>
/// Method Title.
/// </summary>
    public TablerCardBasic Title(string title) {
        SubHeaderText = title;
        return this;
    }

/// <summary>
/// Method Text.
/// </summary>
    public new TablerCardBasic Text(string text) {
        H3Text = text;
        return this;
    }

/// <summary>
/// Method Margin.
/// </summary>
    public TablerCardBasic Margin(TablerMarginStyle margin) {
        PrivateMargin = margin;
        AutoMargin = false; // Disable auto margin when explicitly set
        return this;
    }

/// <summary>
/// Method DisableAutoMargin.
/// </summary>
    public TablerCardBasic DisableAutoMargin() {
        AutoMargin = false;
        return this;
    }

/// <summary>
/// Method ToString.
/// </summary>
    public override string ToString() {
        // Create the outer div for the card
        var cardDiv = new HtmlTag("div");
        cardDiv.Class("card").Class(PrivateCardStyle);
        
        // Apply margin - either explicit or auto-detected
        var marginToApply = GetEffectiveMargin();
        if (marginToApply.HasValue) {
            cardDiv.Class(marginToApply.Value.EnumToString());
        }

        // Create the inner div for the card body
        var cardBodyDiv = new HtmlTag("div");
        cardBodyDiv.Class("card-body");

        // Add subheader to the card
        if (!string.IsNullOrEmpty(SubHeaderText)) {
            var subheader = new HtmlTag("div").Class("subheader").Value(SubHeaderText);
            cardBodyDiv.Value(subheader);
        }

        // Add h3 to the card
        if (!string.IsNullOrEmpty(H3Text)) {
            var h3 = new HtmlTag("div").Class("h3").Class("m-0").Value(H3Text);
            cardBodyDiv.Value(h3);
        }

        // Add the card body to the card
        cardDiv.Value(cardBodyDiv);

        return cardDiv.ToString();
    }

    private TablerMarginStyle? GetEffectiveMargin() {
        // If explicitly set, use that
        if (PrivateMargin.HasValue) {
            return PrivateMargin;
        }

        // If auto margin is disabled, return null
        if (!AutoMargin) {
            return null;
        }

        // Auto-detect margin based on common patterns
        // For cards in vertical stacks (common pattern), apply bottom margin
        // This heuristic works for most use cases like the BasicHtmlContainer04 scenario
        return TablerMarginStyle.MB3;
    }
}