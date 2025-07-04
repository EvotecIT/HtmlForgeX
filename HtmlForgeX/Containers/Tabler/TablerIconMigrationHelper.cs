namespace HtmlForgeX;

/// <summary>
/// Helper class to ease migration from TablerIcon to SvgIcon with similar API
/// </summary>
public static class TablerIconMigrationHelper {

    /// <summary>
    /// Create an SvgIcon with TablerIconElement-like API for easier migration
    /// </summary>
    public static TablerIcon CreateIcon(TablerIcon icon) {
        return icon;
    }

    /// <summary>
    /// Add color (equivalent to TablerIconElement.Color)
    /// </summary>
    public static TablerIcon Color(this TablerIcon icon, RGBColor color) {
        return icon.StrokeColor(color);
    }

    /// <summary>
    /// Set font size (equivalent to TablerIconElement.FontSize)
    /// </summary>
    public static TablerIcon FontSize(this TablerIcon icon, int size) {
        return icon.Size(size);
    }

    /// <summary>
    /// Creates a TablerIconElement-compatible wrapper for gradual migration
    /// </summary>
    public class TablerIconElement : Element {
        private readonly TablerIcon _icon;

        public TablerIconElement(TablerIcon icon) {
            _icon = icon;
        }

        public TablerIconElement Color(RGBColor color) {
            _icon.StrokeColor(color);
            return this;
        }

        public TablerIconElement FontSize(int size) {
            _icon.Size(size);
            return this;
        }

        public TablerIconElement StrokeWidth(double width) {
            _icon.StrokeWidth(width);
            return this;
        }

        public override string ToString() {
            return _icon.ToString();
        }
    }
}