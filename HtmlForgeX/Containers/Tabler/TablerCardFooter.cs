using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Represents the footer section of a Tabler card.
/// </summary>
public class TablerCardFooter : Element {
    /// <summary>
    /// Gets or sets optional footer text content.
    /// </summary>
    public string? Content { get; set; }

    /// <summary>
    /// Initializes or configures SetContent.
    /// </summary>
    public TablerCardFooter SetContent(string content) {
        Content = content;
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
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