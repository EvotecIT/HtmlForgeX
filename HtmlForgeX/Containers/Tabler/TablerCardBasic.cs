namespace HtmlForgeX;

public class TablerCardBasic : Element {
    private string? CardStyle { get; set; }
    private string SubHeaderText { get; set; } = "";
    private string H3Text { get; set; } = "";

    public TablerCardBasic() { }

    public TablerCardBasic(string title, string text) {
        SubHeaderText = title;
        H3Text = text;
    }

    public TablerCardBasic Title(string title) {
        SubHeaderText = title;
        return this;
    }

    public new TablerCardBasic Text(string text) {
        H3Text = text;
        return this;
    }

    public override string ToString() {
        // Create the outer div for the card
        var cardDiv = new HtmlTag("div");
        cardDiv.Class("card").Class(CardStyle);

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
}