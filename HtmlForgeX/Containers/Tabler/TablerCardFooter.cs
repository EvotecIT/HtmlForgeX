using System.Collections.Generic;
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

    private readonly HashSet<Element> _processedChildren = new();

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
        // CRITICAL FIX: Ensure all children have proper Document references before rendering
        EnsureChildrenHaveDocumentReference();

        // ADDITIONAL FIX: Force library registration for any children that may have missed it
        foreach (var child in Children.WhereNotNull()) {
            if (child.Document != null) {
                child.RegisterLibraries();
            }
        }

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

    /// <summary>
    /// Ensures all children have proper Document and Email references for library registration
    /// </summary>
    private void EnsureChildrenHaveDocumentReference() {
        if (Document == null) {
            return;
        }

        foreach (var child in Children.WhereNotNull()) {
            if (!_processedChildren.Contains(child)) {
                if (child.Document == null) {
                    child.Document = Document;
                    child.Email = Email;
                }

                child.OnAddedToDocument();
                _processedChildren.Add(child);
            } else if (child.Document == null) {
                child.Document = Document;
                child.Email = Email;
            }
        }
    }

    /// <summary>
    /// Override to ensure child elements have Document reference when initially added to document
    /// </summary>
    protected internal override void OnAddedToDocument() {
        // Propagate Document reference to all child elements
        EnsureChildrenHaveDocumentReference();

        // Call base implementation to register our own libraries
        base.OnAddedToDocument();
    }
}