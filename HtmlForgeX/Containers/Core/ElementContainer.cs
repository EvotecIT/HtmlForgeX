using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Basic container element rendering its children.
/// </summary>
public class ElementContainer : Element {
    public override string ToString() {
        return string.Join("", Children.WhereNotNull().Select(child => child.ToString()));
    }
}