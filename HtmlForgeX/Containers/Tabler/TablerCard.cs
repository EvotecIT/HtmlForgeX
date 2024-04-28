namespace HtmlForgeX;

public class TablerCard : Element {
    private TablerCardFooter PrivateFooter { get; set; } = new TablerCardFooter();

    public string? CardContent { get; set; }
    public string? CardInnerStyle { get; set; }

    private string? CardOuterStyle { get; set; }

    private int Number { get; set; }

    public TablerCard() {
        CardOuterStyle = $"col";
    }

    public TablerCard(int number) {
        CardOuterStyle = $"col-{number}";
    }

    public TablerCard Content(string content) {
        CardContent = content;
        return this;
    }

    public TablerCard Style(string style) {
        CardInnerStyle = style;
        return this;
    }

    public TablerCardFooter Footer() {
        PrivateFooter = new TablerCardFooter();
        return PrivateFooter;
    }


    public TablerCard Footer(Action<TablerCardFooter> footer) {
        var footerElement = new TablerCardFooter();
        footer(footerElement);
        PrivateFooter = footerElement;
        return this;
    }

    public override string ToString() {
        //Console.WriteLine("Generating HtmlCard...");

        // Create the outer div for the card
        var cardDiv = new HtmlTag("div");
        cardDiv.Class("card").Class(CardOuterStyle).Class(null);

        // Create the inner div for the card body
        var cardBodyDiv = new HtmlTag("div");
        cardBodyDiv.Class("card-body").Value(CardContent);
        cardBodyDiv.Attributes["style"] = CardInnerStyle;

        // Add the card body to the card
        cardDiv.Value(cardBodyDiv);

        // Add any child elements to the card body
        foreach (var child in Children) {
            cardBodyDiv.Value(child.ToString());
        }

        // Add the card footer to the card if Footer is not null
        if (PrivateFooter != null) {
            cardDiv.Value(PrivateFooter.ToString());
        }

        var result = cardDiv.ToString();

        // Console.WriteLine("Generated HtmlCard: " + result);
        return result;
    }


    public TablerCard Add(Action<TablerCard> config) {
        config(this);
        return this;
    }
}
