namespace HtmlForgeX;

/// <summary>
/// Represents the different accordion types available in Tabler
/// </summary>
public enum TablerAccordionType {
    /// <summary>
    /// Default accordion with borders and spacing
    /// </summary>
    Default,
    
    /// <summary>
    /// Flush accordion without borders and rounded corners
    /// </summary>
    Flush,
    
    /// <summary>
    /// Tabs-style accordion with spacing between items
    /// </summary>
    Tabs,
    
    /// <summary>
    /// Inverted accordion with toggle icon on the left
    /// </summary>
    Inverted,
    
    /// <summary>
    /// Plus-style accordion with plus/minus icons instead of chevron
    /// </summary>
    Plus
}

public static class TablerAccordionTypeExtensions {
/// <summary>
/// Method EnumToString.
/// </summary>
    public static string EnumToString(this TablerAccordionType type) {
        return type switch {
            TablerAccordionType.Default => "",
            TablerAccordionType.Flush => "accordion-flush",
            TablerAccordionType.Tabs => "accordion-tabs", 
            TablerAccordionType.Inverted => "accordion-inverted",
            TablerAccordionType.Plus => "accordion-plus",
            _ => ""
        };
    }
}