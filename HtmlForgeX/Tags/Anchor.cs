namespace HtmlForgeX.Tags;

public class Anchor : HtmlTag {
    public Anchor() : base("a") { }

    public Anchor(string hrefLink, string text = "") : base("a") {
        Attributes["href"] = hrefLink;
        Value(text);
    }

    public Anchor Target(string target) {
        Attributes["target"] = target;
        return this;
    }

    public Anchor Name(string name) {
        Attributes["name"] = name;
        return this;
    }

    public Anchor Rel(string rel) {
        Attributes["rel"] = rel;
        return this;
    }

    public Anchor Download(string download) {
        Attributes["download"] = download;
        return this;
    }

    public Anchor HrefLink(string hrefLink) {
        Attributes["href"] = hrefLink;
        return this;
    }

    public Anchor HrefLang(string hreflang) {
        Attributes["hreflang"] = hreflang;
        return this;
    }

    public Anchor OnClick(string onClick) {
        Attributes["onclick"] = onClick;
        return this;
    }

    public Anchor Media(string media) {
        Attributes["media"] = media;
        return this;
    }

    public Anchor Ping(string ping) {
        Attributes["ping"] = ping;
        return this;
    }

    public Anchor ReferrerPolicy(string referrerPolicy) {
        Attributes["referrerpolicy"] = referrerPolicy;
        return this;
    }
}
