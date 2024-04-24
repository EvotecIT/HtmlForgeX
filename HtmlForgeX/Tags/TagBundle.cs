namespace HtmlForgeX.Tags;

public class Abbr(string value) : HtmlTag("abbr", value) {
    public Abbr Title(string title) {
        Attributes["title"] = title;
        return this;
    }
}

public class Address(string value) : HtmlTag("address", value);

public class Article(string value) : HtmlTag("article", value);

public class BR() : HtmlTag("br", TagMode.NoClosing);

public class LineBreak() : HtmlTag("br", TagMode.NoClosing);

public class HR() : HtmlTag("hr", TagMode.NoClosing);

public class HorizontalRule() : HtmlTag("hr", TagMode.NoClosing);

public class H1(string value) : HtmlTag("h1", value);

public class H2(string value) : HtmlTag("h2", value);

public class H3(string value) : HtmlTag("h3", value);

public class H4(string value) : HtmlTag("h4", value);

public class H5(string value) : HtmlTag("h5", value);

public class H6(string value) : HtmlTag("h6", value);

public class Strong(string value) : HtmlTag("strong", value);