namespace HtmlForgeX.Tags;

public class Abbr(string value) : HtmlTag("abbr", value) {
    public Abbr Title(string title) {
        Attributes["title"] = title;
        return this;
    }
}

public class Address(string value) : HtmlTag("address", value);

public class Article(string value) : HtmlTag("article", value);

public class Strong(string value) : HtmlTag("strong", value);