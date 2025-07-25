namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler stat card component for displaying metrics with icon and change indicator
    /// </summary>
    public class TablerStatCard : Element
    {
        private string _title = "";
        private string _value = "";
        private string? _change;
        private TablerChangeType _changeType = TablerChangeType.None;
        private TablerIconType? _icon;
        private TablerColor _color = TablerColor.Default;
        private bool _loading = false;

        /// <summary>
        /// Initializes a new instance of the TablerStatCard class
        /// </summary>
        public TablerStatCard() : base()
        {
        }

        /// <summary>
        /// Registers the required libraries for this component
        /// </summary>
        protected internal override void RegisterLibraries()
        {
            if (Document != null)
            {
                Document.AddLibrary(Libraries.Tabler);
                if (_icon.HasValue)
                {
                    Document.AddLibrary(Libraries.TablerIcon);
                }
            }
        }

        /// <summary>
        /// Set card title
        /// </summary>
        public TablerStatCard Title(string title)
        {
            _title = title;
            return this;
        }

        /// <summary>
        /// Set card value
        /// </summary>
        public TablerStatCard Value(string value)
        {
            _value = value;
            return this;
        }

        /// <summary>
        /// Set change percentage
        /// </summary>
        public TablerStatCard Change(string change, TablerChangeType? type = null)
        {
            _change = change;
            if (type.HasValue)
                _changeType = type.Value;
            else if (change.StartsWith("+"))
                _changeType = TablerChangeType.Increase;
            else if (change.StartsWith("-"))
                _changeType = TablerChangeType.Decrease;
            return this;
        }

        /// <summary>
        /// Set change type explicitly
        /// </summary>
        public TablerStatCard ChangeType(TablerChangeType type)
        {
            _changeType = type;
            return this;
        }

        /// <summary>
        /// Set card icon
        /// </summary>
        public TablerStatCard Icon(TablerIconType icon)
        {
            _icon = icon;
            return this;
        }

        /// <summary>
        /// Set card color theme
        /// </summary>
        public TablerStatCard Color(TablerColor color)
        {
            _color = color;
            return this;
        }

        /// <summary>
        /// Show loading state
        /// </summary>
        public TablerStatCard Loading(bool loading = true)
        {
            _loading = loading;
            return this;
        }

        /// <summary>
        /// Renders the stat card to HTML string
        /// </summary>
        /// <returns>HTML representation of the stat card</returns>
        public override string ToString()
        {
            var card = new HtmlTag("div");
            card.Class("card");

            var cardBody = new HtmlTag("div");
            cardBody.Class("card-body");

            // Icon section
            if (_icon.HasValue)
            {
                var iconBg = new HtmlTag("div");
                iconBg.Class("d-flex");
                iconBg.Class("align-items-center");
                iconBg.Class("mb-3");

                var iconWrapper = new HtmlTag("div");
                iconWrapper.Class("me-3");
                
                var iconContainer = new HtmlTag("div");
                iconContainer.Class("bg-" + GetColorClass(_color));
                iconContainer.Class("text-white");
                iconContainer.Class("rounded");
                iconContainer.Class("p-3");
                
                var icon = TablerIconLibrary.GetIcon(_icon.Value);
                icon.Size(24);
                iconContainer.Value(icon.ToString());
                
                iconWrapper.Value(iconContainer.ToString());
                iconBg.Value(iconWrapper.ToString());

                // Value next to icon
                var valueDiv = new HtmlTag("div");
                var h1 = new HtmlTag("h1");
                h1.Class("mb-0");
                h1.Value(_value);
                valueDiv.Value(h1.ToString());
                iconBg.Value(valueDiv.ToString());

                cardBody.Value(iconBg.ToString());
            }
            else
            {
                // Value without icon
                var h1 = new HtmlTag("h1");
                h1.Class("mb-3");
                h1.Value(_value);
                cardBody.Value(h1.ToString());
            }

            // Title and change
            var titleRow = new HtmlTag("div");
            titleRow.Class("d-flex");
            titleRow.Class("align-items-center");
            titleRow.Class("justify-content-between");

            var titleDiv = new HtmlTag("div");
            titleDiv.Class("text-secondary");
            titleDiv.Value(_title);
            titleRow.Value(titleDiv.ToString());

            if (!string.IsNullOrEmpty(_change))
            {
                var changeDiv = new HtmlTag("div");
                var changeSpan = new HtmlTag("span");
                
                if (_changeType == TablerChangeType.Increase)
                {
                    changeSpan.Class("text-success");
                    changeSpan.Class("d-inline-flex");
                    changeSpan.Class("align-items-center");
                    var arrow = TablerIconLibrary.GetIcon(TablerIconType.TrendingUp);
                    arrow.Size(16);
                    changeSpan.Value(arrow.ToString());
                }
                else if (_changeType == TablerChangeType.Decrease)
                {
                    changeSpan.Class("text-danger");
                    changeSpan.Class("d-inline-flex");
                    changeSpan.Class("align-items-center");
                    var arrow = TablerIconLibrary.GetIcon(TablerIconType.TrendingDown);
                    arrow.Size(16);
                    changeSpan.Value(arrow.ToString());
                }
                
                changeSpan.Value(_change);
                changeDiv.Value(changeSpan.ToString());
                titleRow.Value(changeDiv.ToString());
            }

            cardBody.Value(titleRow.ToString());

            if (_loading)
            {
                cardBody.Class("placeholder-glow");
            }

            card.Value(cardBody.ToString());
            return card.ToString();
        }

        /// <summary>
        /// Gets the CSS color class for a TablerColor
        /// </summary>
        /// <param name="color">The color enum value</param>
        /// <returns>CSS color class string</returns>
        private string GetColorClass(TablerColor color)
        {
            return color switch
            {
                TablerColor.Blue => "blue",
                TablerColor.Azure => "azure",
                TablerColor.Indigo => "indigo",
                TablerColor.Purple => "purple",
                TablerColor.Pink => "pink",
                TablerColor.Red => "red",
                TablerColor.Orange => "orange",
                TablerColor.Yellow => "yellow",
                TablerColor.Lime => "lime",
                TablerColor.Green => "green",
                TablerColor.Teal => "teal",
                TablerColor.Cyan => "cyan",
                _ => "primary"
            };
        }
    }

    /// <summary>
    /// Represents change indicator types for stat cards
    /// </summary>
    public enum TablerChangeType
    {
        /// <summary>
        /// No change indicator
        /// </summary>
        None,
        /// <summary>
        /// Positive/increase indicator
        /// </summary>
        Increase,
        /// <summary>
        /// Negative/decrease indicator
        /// </summary>
        Decrease
    }
}