using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Defines the layout types supported by the Tabler framework.
/// Each layout type controls the overall page structure and behavior.
/// </summary>
public enum TablerLayout {
    /// <summary>
    /// Default layout with standard container behavior
    /// </summary>
    Default,

    /// <summary>
    /// Fluid layout with full-width containers
    /// </summary>
    Fluid,

    /// <summary>
    /// Boxed layout with constrained width containers
    /// </summary>
    Boxed,

    /// <summary>
    /// Horizontal navigation layout with top navbar
    /// </summary>
    Horizontal,

    /// <summary>
    /// Vertical navigation with left sidebar
    /// </summary>
    Vertical,

    /// <summary>
    /// Vertical navigation with right sidebar
    /// </summary>
    VerticalRight,

    /// <summary>
    /// Vertical navigation with transparent sidebar
    /// </summary>
    VerticalTransparent,

    /// <summary>
    /// Fluid layout with vertical sidebar navigation
    /// </summary>
    FluidVertical,

    /// <summary>
    /// Combination layout with vertical sidebar (dark theme)
    /// </summary>
    Combo,

    /// <summary>
    /// Condensed layout with tighter spacing
    /// </summary>
    Condensed,

    /// <summary>
    /// Right-to-left layout for RTL languages
    /// </summary>
    RTL,

    /// <summary>
    /// Layout with dark themed navbar
    /// </summary>
    NavbarDark,

    /// <summary>
    /// Layout with overlapping navbar
    /// </summary>
    NavbarOverlap,

    /// <summary>
    /// Layout with sticky navbar that stays at top when scrolling
    /// </summary>
    NavbarSticky
}