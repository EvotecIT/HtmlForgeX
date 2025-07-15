using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Basic container element rendering its children.
/// </summary>
public class ElementContainer : Element {
    /// <summary>
    /// Renders all non-null child elements into a single HTML string.
    /// </summary>
    /// <returns>Concatenated HTML of all children.</returns>
    public override string ToString() {
        return string.Join("", Children.WhereNotNull().Select(child => child.ToString()));
    }
}