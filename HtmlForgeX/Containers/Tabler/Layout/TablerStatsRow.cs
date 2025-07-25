namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Tabler stats row component for displaying stat cards in a responsive grid
    /// </summary>
    public class TablerStatsRow : Element
    {
        private TablerRowType _rowType = TablerRowType.Deck;
        private TablerGutter _gutter = TablerGutter.Default;

        /// <summary>
        /// Initializes a new instance of the TablerStatsRow class
        /// </summary>
        public TablerStatsRow() : base()
        {
        }

        /// <summary>
        /// Set row type
        /// </summary>
        public TablerStatsRow Type(TablerRowType type)
        {
            _rowType = type;
            return this;
        }

        /// <summary>
        /// Set gutter spacing
        /// </summary>
        public TablerStatsRow Gutter(TablerGutter gutter)
        {
            _gutter = gutter;
            return this;
        }

        /// <summary>
        /// Add a stat card
        /// </summary>
        public TablerStatsRow Card(string title, string value, Action<TablerStatCard>? configure = null)
        {
            var column = new TablerColumn(TablerColumnNumber.SmallSixLargeThree);
            
            var card = new TablerStatCard()
                .Title(title)
                .Value(value);
                
            configure?.Invoke(card);
            
            column.Add(card);
            Add(column);
            return this;
        }

        /// <summary>
        /// Add a stat card with all options
        /// </summary>
        public TablerStatsRow Card(string title, string value, string change, TablerIconType icon, TablerColor color)
        {
            return Card(title, value, card => card
                .Change(change)
                .Icon(icon)
                .Color(color)
            );
        }

        /// <summary>
        /// Renders the stats row to HTML string
        /// </summary>
        /// <returns>HTML representation of the stats row</returns>
        public override string ToString()
        {
            var row = new HtmlTag("div");
            row.Class("row");

            if (_rowType == TablerRowType.Deck)
                row.Class("row-deck");
            else if (_rowType == TablerRowType.Cards)
                row.Class("row-cards");

            // Apply gutter
            var gutterClass = _gutter switch
            {
                TablerGutter.None => "g-0",
                TablerGutter.Small => "g-2",
                TablerGutter.Large => "g-4",
                TablerGutter.ExtraLarge => "g-5",
                _ => "g-3"
            };
            row.Class(gutterClass);

            foreach (var child in Children)
            {
                row.Value(child.ToString());
            }

            return row.ToString();
        }
    }

    /// <summary>
    /// Represents gutter (spacing) options for grid layouts
    /// </summary>
    public enum TablerGutter
    {
        /// <summary>
        /// No gutter spacing
        /// </summary>
        None,
        /// <summary>
        /// Small gutter spacing
        /// </summary>
        Small,
        /// <summary>
        /// Default gutter spacing
        /// </summary>
        Default,
        /// <summary>
        /// Large gutter spacing
        /// </summary>
        Large,
        /// <summary>
        /// Extra large gutter spacing
        /// </summary>
        ExtraLarge
    }
}