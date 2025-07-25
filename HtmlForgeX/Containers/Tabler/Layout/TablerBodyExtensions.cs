namespace HtmlForgeX.Containers.Tabler
{
    /// <summary>
    /// Extension methods for Body to add Tabler page components
    /// </summary>
    public static class TablerBodyExtensions
    {
        /// <summary>
        /// Add a Tabler page structure to the body
        /// </summary>
        public static Body Page(this Body body, Action<TablerPage> configure)
        {
            var page = new TablerPage();
            configure(page);
            body.Add(page);
            return body;
        }
    }
}