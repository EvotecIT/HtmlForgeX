using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Defines a row in a Tabler Page Layout.
/// When using the TablerRow, you can specify the row type.
/// By default, the row type is set to Default, however when dealing with Page Layouts you usually should have both Deck and Cards.
/// But for other purposes of layout such as within Card you should use the Default row type
/// </summary>
/// <seealso cref="HtmlForgeX.Element" />
public class TablerRow : Element {
    private HashSet<TablerRowType> RowTypes { get; set; } = new HashSet<TablerRowType>();
    private List<string> AdditionalClasses { get; set; } = new List<string>();
    
    // Spacing properties
    private TablerSpacing? MarginTop { get; set; }
    private TablerSpacing? MarginBottom { get; set; }
    private TablerSpacing? MarginStart { get; set; }
    private TablerSpacing? MarginEnd { get; set; }
    private TablerSpacing? MarginHorizontal { get; set; }
    private TablerSpacing? MarginVertical { get; set; }
    private TablerSpacing? MarginAll { get; set; }
    
    private TablerSpacing? PaddingTop { get; set; }
    private TablerSpacing? PaddingBottom { get; set; }
    private TablerSpacing? PaddingStart { get; set; }
    private TablerSpacing? PaddingEnd { get; set; }
    private TablerSpacing? PaddingHorizontal { get; set; }
    private TablerSpacing? PaddingVertical { get; set; }
    private TablerSpacing? PaddingAll { get; set; }
    
    private TablerSpacing? GutterSpacing { get; set; }

    public TablerRow(params TablerRowType[] rowTypes) {
        RowTypes.Add(TablerRowType.Default);
        foreach (var rowType in rowTypes) {
            RowTypes.Add(rowType);
        }
    }

/// <summary>
/// Method ToString.
/// </summary>
    public override string ToString() {
        HtmlTag rowTag = new HtmlTag("div");
        
        // Add row type classes
        foreach (var rowType in RowTypes) {
            rowTag.Class(rowType.EnumToString());
        }
        
        // Add spacing classes
        AddSpacingClasses(rowTag);
        
        // Add any additional classes
        foreach (var additionalClass in AdditionalClasses) {
            rowTag.Class(additionalClass);
        }
        
        foreach (var child in Children.WhereNotNull()) {
            rowTag.Value(child);
        }
        return rowTag.ToString();
    }
    
    private void AddSpacingClasses(HtmlTag tag) {
        // Margin classes (specific directions take precedence)
        if (MarginTop.HasValue) tag.Class(MarginTop.Value.ToMarginClass(TablerSpacingDirection.Top));
        if (MarginBottom.HasValue) tag.Class(MarginBottom.Value.ToMarginClass(TablerSpacingDirection.Bottom));
        if (MarginStart.HasValue) tag.Class(MarginStart.Value.ToMarginClass(TablerSpacingDirection.Start));
        if (MarginEnd.HasValue) tag.Class(MarginEnd.Value.ToMarginClass(TablerSpacingDirection.End));
        if (MarginHorizontal.HasValue) tag.Class(MarginHorizontal.Value.ToMarginClass(TablerSpacingDirection.Horizontal));
        if (MarginVertical.HasValue) tag.Class(MarginVertical.Value.ToMarginClass(TablerSpacingDirection.Vertical));
        if (MarginAll.HasValue) tag.Class(MarginAll.Value.ToMarginClass(TablerSpacingDirection.All));
        
        // Padding classes
        if (PaddingTop.HasValue) tag.Class(PaddingTop.Value.ToPaddingClass(TablerSpacingDirection.Top));
        if (PaddingBottom.HasValue) tag.Class(PaddingBottom.Value.ToPaddingClass(TablerSpacingDirection.Bottom));
        if (PaddingStart.HasValue) tag.Class(PaddingStart.Value.ToPaddingClass(TablerSpacingDirection.Start));
        if (PaddingEnd.HasValue) tag.Class(PaddingEnd.Value.ToPaddingClass(TablerSpacingDirection.End));
        if (PaddingHorizontal.HasValue) tag.Class(PaddingHorizontal.Value.ToPaddingClass(TablerSpacingDirection.Horizontal));
        if (PaddingVertical.HasValue) tag.Class(PaddingVertical.Value.ToPaddingClass(TablerSpacingDirection.Vertical));
        if (PaddingAll.HasValue) tag.Class(PaddingAll.Value.ToPaddingClass(TablerSpacingDirection.All));
        
        // Gutter spacing for columns
        if (GutterSpacing.HasValue) tag.Class(GutterSpacing.Value.ToGapClass());
    }

    #region Fluent API Methods for Spacing
    
    /// <summary>
    /// Sets margin for all directions
    /// </summary>
    public TablerRow WithMargin(TablerSpacing spacing) {
        MarginAll = spacing;
        return this;
    }
    
    /// <summary>
    /// Sets margin for specific direction
    /// </summary>
    public TablerRow WithMargin(TablerSpacing spacing, TablerSpacingDirection direction) {
        switch (direction) {
            case TablerSpacingDirection.Top: MarginTop = spacing; break;
            case TablerSpacingDirection.Bottom: MarginBottom = spacing; break;
            case TablerSpacingDirection.Start: MarginStart = spacing; break;
            case TablerSpacingDirection.End: MarginEnd = spacing; break;
            case TablerSpacingDirection.Horizontal: MarginHorizontal = spacing; break;
            case TablerSpacingDirection.Vertical: MarginVertical = spacing; break;
            case TablerSpacingDirection.All: MarginAll = spacing; break;
        }
        return this;
    }
    
    /// <summary>
    /// Sets padding for all directions
    /// </summary>
    public TablerRow WithPadding(TablerSpacing spacing) {
        PaddingAll = spacing;
        return this;
    }
    
    /// <summary>
    /// Sets padding for specific direction
    /// </summary>
    public TablerRow WithPadding(TablerSpacing spacing, TablerSpacingDirection direction) {
        switch (direction) {
            case TablerSpacingDirection.Top: PaddingTop = spacing; break;
            case TablerSpacingDirection.Bottom: PaddingBottom = spacing; break;
            case TablerSpacingDirection.Start: PaddingStart = spacing; break;
            case TablerSpacingDirection.End: PaddingEnd = spacing; break;
            case TablerSpacingDirection.Horizontal: PaddingHorizontal = spacing; break;
            case TablerSpacingDirection.Vertical: PaddingVertical = spacing; break;
            case TablerSpacingDirection.All: PaddingAll = spacing; break;
        }
        return this;
    }
    
    /// <summary>
    /// Sets gutter spacing between columns
    /// </summary>
    public TablerRow WithGutter(TablerSpacing spacing) {
        GutterSpacing = spacing;
        return this;
    }
    
    /// <summary>
    /// Adds custom CSS class
    /// </summary>
    public TablerRow WithClass(string cssClass) {
        if (!string.IsNullOrEmpty(cssClass)) {
            AdditionalClasses.Add(cssClass);
        }
        return this;
    }
    
    /// <summary>
    /// Convenient method to add vertical spacing (common use case)
    /// </summary>
    public TablerRow WithVerticalSpacing(TablerSpacing spacing = TablerSpacing.Medium) {
        return WithMargin(spacing, TablerSpacingDirection.Vertical);
    }
    
    /// <summary>
    /// Convenient method to add bottom margin (common use case for separating rows)
    /// </summary>
    public TablerRow WithBottomSpacing(TablerSpacing spacing = TablerSpacing.Medium) {
        return WithMargin(spacing, TablerSpacingDirection.Bottom);
    }
    
    #endregion

/// <summary>
/// Method Column.
/// </summary>
    public TablerColumn Column(Action<TablerColumn> config) {
        var column = new TablerColumn();
        config(column);
        this.Add(column);
        return column;
    }

/// <summary>
/// Method Column.
/// </summary>
    public TablerColumn Column(TablerColumnNumber number, Action<TablerColumn> config) {
        var column = new TablerColumn(number);
        config(column);
        this.Add(column);
        return column;
    }
}