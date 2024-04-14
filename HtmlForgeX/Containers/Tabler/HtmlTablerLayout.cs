namespace HtmlForgeX;

public class HtmlCard : HtmlElementContainer {
    public string? Content { get; set; }
    public string? Style { get; set; }

    public HtmlCard AddContent(string content) {
        Content = content;
        return this;
    }

    public HtmlCard WithStyle(string style) {
        Style = style;
        return this;
    }

    public override string ToString() {
        Console.WriteLine("Generating HtmlCard...");
        var result = $"<div class=\"card\"><div class=\"card-body\" style=\"{Style}\">{Content}</div></div>";
        Console.WriteLine("Generated HtmlCard: " + result);
        return result;
    }

}

public class HtmlColumn : HtmlElementContainer {
    public List<HtmlCard> Cards { get; set; } = new List<HtmlCard>();
    public string? Class { get; set; }

    public HtmlColumn WithClass(string className) {
        Class = className;
        return this;
    }

    public override string ToString() {
        Console.WriteLine("Generating HtmlColumn...");
        var childrenHtml = string.Join("", Children.Select(child => child.ToString()));
        var result = $"<div class=\"{Class}\">{childrenHtml}</div>";
        Console.WriteLine("Generated HtmlColumn: " + result);
        return result;
    }

}

public class HtmlRow : HtmlElementContainer {
    public List<HtmlColumn> Columns { get; set; } = new List<HtmlColumn>();

    public override string ToString() {
        Console.WriteLine("Generating HtmlRow...");
        var childrenHtml = string.Join("", Children.Select(child => child.ToString()));
        var result = $"<div class=\"row row-deck row-cards\">{childrenHtml}</div>";
        Console.WriteLine("Generated HtmlRow: " + result);
        return result;
    }

}

public class HtmlPage : HtmlElementContainer {
    public List<HtmlRow> Rows { get; set; } = new List<HtmlRow>();

    public HtmlPage() {
        GlobalStorage.Libraries.Add(Libraries.Bootstrap);
        GlobalStorage.Libraries.Add(Libraries.Tabler);
    }

    public override string ToString() {
        Console.WriteLine("Generating HtmlPage...");
        var childrenHtml = string.Join("", Children.Select(child => child.ToString()));
        var result = $"<div class=\"page-wrapper\"><div class=\"page-body\"><div class=\"container-xl\">{childrenHtml}</div></div></div>";
        Console.WriteLine("Generated HtmlPage: " + result);
        return result;
    }
}