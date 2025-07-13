using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

public class TablerCardFooter : Element {
    public string? Content { get; set; }

    public TablerCardFooter SetContent(string content) {
        Content = content;
        return this;
    }

    public override string ToString() {
        // We only want to render the footer if there are children
        if (Children.Count > 0) {
            var footerDiv = new HtmlTag("div");
            footerDiv.Class("card-footer").Value(Content);

            foreach (var child in Children.WhereNotNull()) {
                footerDiv.Value(child);
            }

            return footerDiv.ToString();
        }
        return "";

    }
}
