namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Typed height dimension for Tabler components
    /// </summary>
    public class TablerHeight
    {
        private readonly string _value;

        private TablerHeight(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Height in pixels
        /// </summary>
        public static TablerHeight Pixels(int pixels) => new($"{pixels}px");

        /// <summary>
        /// Height in percentage
        /// </summary>
        public static TablerHeight Percent(int percent) => new($"{percent}%");

        /// <summary>
        /// Height in rem units
        /// </summary>
        public static TablerHeight Rem(double rem) => new($"{rem}rem");

        /// <summary>
        /// Height in em units
        /// </summary>
        public static TablerHeight Em(double em) => new($"{em}em");

        /// <summary>
        /// Height in viewport height units
        /// </summary>
        public static TablerHeight ViewportHeight(int vh) => new($"{vh}vh");

        /// <summary>
        /// Auto height
        /// </summary>
        public static TablerHeight Auto => new("auto");

        /// <summary>
        /// Full height (100%)
        /// </summary>
        public static TablerHeight Full => new("100%");

        /// <summary>
        /// Fit content height
        /// </summary>
        public static TablerHeight FitContent => new("fit-content");

        /// <summary>
        /// Min content height
        /// </summary>
        public static TablerHeight MinContent => new("min-content");

        /// <summary>
        /// Max content height
        /// </summary>
        public static TablerHeight MaxContent => new("max-content");

        /// <summary>
        /// Returns the string representation of the height
        /// </summary>
        /// <returns>Height value as string</returns>
        public override string ToString() => _value;
    }

    /// <summary>
    /// Typed width dimension for Tabler components
    /// </summary>
    public class TablerWidth
    {
        private readonly string _value;

        private TablerWidth(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Width in pixels
        /// </summary>
        public static TablerWidth Pixels(int pixels) => new($"{pixels}px");

        /// <summary>
        /// Width in percentage
        /// </summary>
        public static TablerWidth Percent(int percent) => new($"{percent}%");

        /// <summary>
        /// Width in rem units
        /// </summary>
        public static TablerWidth Rem(double rem) => new($"{rem}rem");

        /// <summary>
        /// Width in em units
        /// </summary>
        public static TablerWidth Em(double em) => new($"{em}em");

        /// <summary>
        /// Width in viewport width units
        /// </summary>
        public static TablerWidth ViewportWidth(int vw) => new($"{vw}vw");

        /// <summary>
        /// Auto width
        /// </summary>
        public static TablerWidth Auto => new("auto");

        /// <summary>
        /// Full width (100%)
        /// </summary>
        public static TablerWidth Full => new("100%");

        /// <summary>
        /// Fit content width
        /// </summary>
        public static TablerWidth FitContent => new("fit-content");

        /// <summary>
        /// Min content width
        /// </summary>
        public static TablerWidth MinContent => new("min-content");

        /// <summary>
        /// Max content width
        /// </summary>
        public static TablerWidth MaxContent => new("max-content");

        /// <summary>
        /// Returns the string representation of the width
        /// </summary>
        /// <returns>Width value as string</returns>
        public override string ToString() => _value;
    }

    /// <summary>
    /// Extension methods for applying dimensions to HtmlTag-based elements
    /// </summary>
    public static class TablerDimensionExtensions
    {
        /// <summary>
        /// Set element height using inline styles
        /// </summary>
        public static HtmlTag Height(this HtmlTag tag, TablerHeight height)
        {
            var currentStyle = tag.Attributes.ContainsKey("style") ? tag.Attributes["style"]?.ToString() ?? "" : "";
            var newStyle = AddOrUpdateStyleProperty(currentStyle, "height", height.ToString());
            tag.Attribute("style", newStyle);
            return tag;
        }

        /// <summary>
        /// Set element width using inline styles
        /// </summary>
        public static HtmlTag Width(this HtmlTag tag, TablerWidth width)
        {
            var currentStyle = tag.Attributes.ContainsKey("style") ? tag.Attributes["style"]?.ToString() ?? "" : "";
            var newStyle = AddOrUpdateStyleProperty(currentStyle, "width", width.ToString());
            tag.Attribute("style", newStyle);
            return tag;
        }

        /// <summary>
        /// Set element min height using inline styles
        /// </summary>
        public static HtmlTag MinHeight(this HtmlTag tag, TablerHeight height)
        {
            var currentStyle = tag.Attributes.ContainsKey("style") ? tag.Attributes["style"]?.ToString() ?? "" : "";
            var newStyle = AddOrUpdateStyleProperty(currentStyle, "min-height", height.ToString());
            tag.Attribute("style", newStyle);
            return tag;
        }

        /// <summary>
        /// Set element max height using inline styles
        /// </summary>
        public static HtmlTag MaxHeight(this HtmlTag tag, TablerHeight height)
        {
            var currentStyle = tag.Attributes.ContainsKey("style") ? tag.Attributes["style"]?.ToString() ?? "" : "";
            var newStyle = AddOrUpdateStyleProperty(currentStyle, "max-height", height.ToString());
            tag.Attribute("style", newStyle);
            return tag;
        }

        /// <summary>
        /// Set element min width using inline styles
        /// </summary>
        public static HtmlTag MinWidth(this HtmlTag tag, TablerWidth width)
        {
            var currentStyle = tag.Attributes.ContainsKey("style") ? tag.Attributes["style"]?.ToString() ?? "" : "";
            var newStyle = AddOrUpdateStyleProperty(currentStyle, "min-width", width.ToString());
            tag.Attribute("style", newStyle);
            return tag;
        }

        /// <summary>
        /// Set element max width using inline styles
        /// </summary>
        public static HtmlTag MaxWidth(this HtmlTag tag, TablerWidth width)
        {
            var currentStyle = tag.Attributes.ContainsKey("style") ? tag.Attributes["style"]?.ToString() ?? "" : "";
            var newStyle = AddOrUpdateStyleProperty(currentStyle, "max-width", width.ToString());
            tag.Attribute("style", newStyle);
            return tag;
        }

        private static string AddOrUpdateStyleProperty(string currentStyle, string property, string value)
        {
            if (string.IsNullOrEmpty(currentStyle))
                return $"{property}: {value};";

            // Simple approach: append new property (could be improved to handle duplicates)
            currentStyle = currentStyle.TrimEnd();
            if (!currentStyle.EndsWith(";"))
                currentStyle += ";";
            
            return $"{currentStyle} {property}: {value};";
        }
    }
}