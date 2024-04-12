using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

public class HtmlHead {
    public string Title { get; set; }
    public List<HtmlTag> MetaTags { get; set; } = new List<HtmlTag>();

    public HtmlHead AddTitle(string title) {
        Title = title;
        return this;
    }

    public HtmlHead AddMeta(string name, string content) {
        MetaTags.Add(new HtmlTag("meta", attributes: new Dictionary<string, object> { { "name", name }, { "content", content } }, selfClosing: true));
        return this;
    }

    public override string ToString() {
        StringBuilder head = new StringBuilder();
        head.AppendLine("<head>");

        if (!string.IsNullOrEmpty(Title)) {
            head.AppendLine($"\t<title>{Title}</title>");
        }

        foreach (var metaTag in MetaTags) {
            head.AppendLine($"\t{metaTag}");
        }

        head.AppendLine("</head>");

        return head.ToString();
    }
}
