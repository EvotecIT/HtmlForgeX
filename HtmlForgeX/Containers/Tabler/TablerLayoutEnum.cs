namespace HtmlForgeX;

/// <summary>
/// Defines the layout types available for Tabler pages.
/// </summary>
public enum TablerLayout {
    /// <summary>
    /// Default layout with standard container width.
    /// </summary>
    Default,
    
    /// <summary>
    /// Fluid layout that spans the full width.
    /// </summary>
    Fluid,
    
    /// <summary>
    /// Boxed layout with constrained width.
    /// </summary>
    Boxed,
    
    /// <summary>
    /// Horizontal navigation layout.
    /// </summary>
    Horizontal,
    
    /// <summary>
    /// Vertical navigation layout with sidebar on the left.
    /// </summary>
    Vertical,
    
    /// <summary>
    /// Vertical navigation layout with sidebar on the right.
    /// </summary>
    VerticalRight,
    
    /// <summary>
    /// Vertical navigation with transparent background.
    /// </summary>
    VerticalTransparent,
    
    /// <summary>
    /// Fluid layout with vertical navigation.
    /// </summary>
    FluidVertical,
    
    /// <summary>
    /// Combination layout with both header and sidebar.
    /// </summary>
    Combo,
    
    /// <summary>
    /// Condensed layout with reduced spacing.
    /// </summary>
    Condensed,
    
    /// <summary>
    /// Right-to-left layout.
    /// </summary>
    RTL,
    
    /// <summary>
    /// Layout with dark navigation bar.
    /// </summary>
    NavbarDark,
    
    /// <summary>
    /// Layout where navbar overlaps content.
    /// </summary>
    NavbarOverlap,
    
    /// <summary>
    /// Layout with sticky navigation bar.
    /// </summary>
    NavbarSticky
}