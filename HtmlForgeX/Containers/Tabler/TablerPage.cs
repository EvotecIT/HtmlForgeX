using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Root container for constructing a Tabler-based page layout.
/// </summary>
public class TablerPage : Element {
    /// <summary>
    /// Initializes or configures TablerPage.
    /// </summary>
    public TablerPage() {
        // Libraries will be registered via RegisterLibraries method
    }

    /// <summary>
    /// Registers the required libraries for TablerPage.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.Configuration.Libraries.TryAdd(Libraries.Bootstrap, 0);
        Document?.Configuration.Libraries.TryAdd(Libraries.Tabler, 0);
    }

    /// <summary>
    /// Initializes or configures Row.
    /// </summary>
    public new TablerRow Row(Action<TablerRow> config) {
        var row = new TablerRow(TablerRowType.Cards, TablerRowType.Deck);
        // Automatically add bottom spacing to separate rows visually
        row.WithBottomSpacing(TablerSpacing.Medium);
        this.Add(row);
        config(row);
        return row;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        //Console.WriteLine("Generating HtmlPage...");
        var layoutClass = GetLayoutClass();
        var pageWrapper = new HtmlTag("div").Class($"page-wrapper{layoutClass}");

        var pageBody = new HtmlTag("div").Class("page-body");
        pageWrapper.Value(pageBody);

        // Choose container type based on layout
        var containerClass = GetContainerClass();
        var container = new HtmlTag("div").Class(containerClass);
        foreach (var child in Children.WhereNotNull()) {
            container.Value(child);
        }
        pageBody.Value(container);

        //Console.WriteLine("Generated HtmlPage: " + pageWrapper);
        return pageWrapper.ToString();
    }

    private string GetLayoutClass() {
        return Layout switch {
            TablerLayout.Default => "",
            TablerLayout.Fluid => " layout-fluid",
            TablerLayout.Boxed => " layout-boxed",
            TablerLayout.Horizontal => " layout-horizontal",
            TablerLayout.Vertical => " layout-vertical",
            TablerLayout.VerticalRight => " layout-vertical-right",
            TablerLayout.VerticalTransparent => " layout-vertical-transparent",
            TablerLayout.FluidVertical => " layout-fluid-vertical",
            TablerLayout.Combo => " layout-combo",
            TablerLayout.Condensed => " layout-condensed",
            TablerLayout.RTL => " layout-rtl",
            TablerLayout.NavbarDark => " layout-navbar-dark",
            TablerLayout.NavbarOverlap => " layout-navbar-overlap",
            TablerLayout.NavbarSticky => " layout-navbar-sticky",
            _ => ""
        };
    }

    private string GetContainerClass() {
        return Layout switch {
            TablerLayout.Fluid or TablerLayout.FluidVertical => "container-fluid",
            TablerLayout.Boxed => "container",
            _ => "container-xl"
        };
    }

    /// <summary>
    /// Initializes or configures Add.
    /// </summary>
    public TablerPage Add(Action<TablerPage> config) {
        config(this);
        return this;
    }

    /// <summary>
    /// Initializes or configures Column.
    /// </summary>
    public TablerColumn Column(Action<TablerColumn> config) {
        var column = new TablerColumn();
        config(column);
        this.Add(column);
        return column;
    }

    /// <summary>
    /// Gets or sets the overall layout configuration for the page.
    /// </summary>
    public TablerLayout Layout { get; set; }
}