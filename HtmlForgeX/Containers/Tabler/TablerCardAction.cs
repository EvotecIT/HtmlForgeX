using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// Base class for card actions (buttons, links, etc.)
/// </summary>
public abstract class TablerCardAction : Element {
    public abstract override string ToString();
}

/// <summary>
/// Card action button with proper Tabler styling
/// </summary>
public class TablerCardButton : TablerCardAction {
    private string? ButtonText { get; set; }
    private TablerIconType? ButtonIcon { get; set; }
    private string ButtonUrl { get; set; } = "#";
    private TablerButtonVariant Variant { get; set; } = TablerButtonVariant.Primary;
    private TablerButtonSize Size { get; set; } = TablerButtonSize.Default;
    private bool IsActionButton { get; set; } = false;
    
    public TablerCardButton WithText(string text) {
        ButtonText = text;
        return this;
    }
    
    public TablerCardButton Icon(TablerIconType icon) {
        ButtonIcon = icon;
        return this;
    }
    
    public TablerCardButton Url(string url) {
        ButtonUrl = url;
        return this;
    }
    
    public TablerCardButton Style(TablerButtonVariant variant) {
        Variant = variant;
        return this;
    }
    
    public TablerCardButton WithSize(TablerButtonSize size) {
        Size = size;
        return this;
    }
    
    public TablerCardButton AsActionButton() {
        IsActionButton = true;
        return this;
    }
    
    public override string ToString() {
        var buttonTag = new HtmlTag("a");
        var classes = new List<string>();
        
        if (IsActionButton) {
            classes.Add("btn-action");
        } else {
            classes.Add("btn");
            
            // Add variant classes
            var variantClass = GetButtonVariantClass(Variant);
            if (!string.IsNullOrEmpty(variantClass)) {
                classes.Add(variantClass);
            }
            
            // Add size classes
            var sizeClass = GetButtonSizeClass(Size);
            if (!string.IsNullOrEmpty(sizeClass)) {
                classes.Add(sizeClass);
            }
        }
        
        buttonTag.Class(string.Join(" ", classes));
        buttonTag.Attribute("href", ButtonUrl);
        
        // Add icon if specified
        if (ButtonIcon.HasValue) {
            buttonTag.Value(new TablerIconElement(ButtonIcon.Value).ToString());
        }
        
        // Add text if specified
        if (!string.IsNullOrEmpty(ButtonText)) {
            if (ButtonIcon.HasValue) {
                buttonTag.Value(" " + ButtonText);
            } else {
                buttonTag.Value(ButtonText);
            }
        }
        
        return buttonTag.ToString();
    }
    
    private static string GetButtonVariantClass(TablerButtonVariant variant) {
        return variant switch {
            TablerButtonVariant.Primary => "btn-primary",
            TablerButtonVariant.Secondary => "btn-secondary",
            TablerButtonVariant.Success => "btn-success",
            TablerButtonVariant.Warning => "btn-warning",
            TablerButtonVariant.Danger => "btn-danger",
            TablerButtonVariant.Info => "btn-info",
            TablerButtonVariant.Light => "btn-light",
            TablerButtonVariant.Dark => "btn-dark",
            _ => ""
        };
    }
    
    private static string GetButtonSizeClass(TablerButtonSize size) {
        return size switch {
            TablerButtonSize.Small => "btn-sm",
            TablerButtonSize.Large => "btn-lg",
            _ => ""
        };
    }
}

