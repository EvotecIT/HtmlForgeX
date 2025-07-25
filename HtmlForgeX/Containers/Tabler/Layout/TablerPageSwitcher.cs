namespace HtmlForgeX.Containers.Tabler;

/// <summary>
/// Handles page switching functionality for Tabler layouts with typed configuration
/// </summary>
public class TablerPageSwitcher : Element
{
    private readonly List<string> _pageIds = new();
    private string? _defaultPageId;
    private bool _updateNavigation = true;
    private string _pageSelector = ".layout-page";
    private string _navLinkSelector = ".nav-link";

    /// <summary>
    /// Initializes a new instance of the TablerPageSwitcher class
    /// </summary>
    public TablerPageSwitcher() : base()
    {
    }

    /// <summary>
    /// Registers the required libraries for this component
    /// </summary>
    protected internal override void RegisterLibraries()
    {
        Document?.AddLibrary(Libraries.Tabler);
    }

    /// <summary>
    /// Register a page ID for switching
    /// </summary>
    public TablerPageSwitcher RegisterPage(string pageId)
    {
        if (!_pageIds.Contains(pageId))
        {
            _pageIds.Add(pageId);
        }
        return this;
    }

    /// <summary>
    /// Set the default visible page
    /// </summary>
    public TablerPageSwitcher DefaultPage(string pageId)
    {
        _defaultPageId = pageId;
        return this;
    }

    /// <summary>
    /// Configure navigation update behavior
    /// </summary>
    public TablerPageSwitcher UpdateNavigation(bool update = true)
    {
        _updateNavigation = update;
        return this;
    }

    /// <summary>
    /// Configure page selector for switching
    /// </summary>
    public TablerPageSwitcher PageSelector(string selector)
    {
        _pageSelector = selector;
        return this;
    }

    /// <summary>
    /// Configure navigation link selector
    /// </summary>
    public TablerPageSwitcher NavLinkSelector(string selector)
    {
        _navLinkSelector = selector;
        return this;
    }

    /// <summary>
    /// Renders the page switcher script to HTML string
    /// </summary>
    /// <returns>HTML script element with page switching functionality</returns>
    public override string ToString()
    {
        if (_pageIds.Count <= 1)
        {
            return string.Empty;
        }

        var script = new HtmlTag("script");
        var jsContent = BuildPageSwitchingScript();
        script.Value(jsContent);
        
        return script.ToString();
    }

    /// <summary>
    /// Builds the JavaScript for page switching functionality
    /// </summary>
    /// <returns>JavaScript code as string</returns>
    private string BuildPageSwitchingScript()
    {
        var defaultPage = _defaultPageId ?? _pageIds.FirstOrDefault() ?? "";
        
        return $@"
document.addEventListener('DOMContentLoaded', function() {{
    // Initialize page visibility
    document.querySelectorAll('{_pageSelector}').forEach(function(page) {{
        page.style.display = page.id === '{defaultPage}' ? 'block' : 'none';
    }});

    // Handle navigation clicks for internal pages
    document.querySelectorAll('a[href^=""#""]').forEach(function(link) {{
        link.addEventListener('click', function(e) {{
            const targetId = this.getAttribute('href').substring(1);
            const targetPage = document.getElementById(targetId);
            
            if (targetPage && targetPage.classList.contains('{_pageSelector.TrimStart('.')}')) {{
                e.preventDefault();
                
                // Hide all pages
                document.querySelectorAll('{_pageSelector}').forEach(function(page) {{
                    page.style.display = 'none';
                }});
                
                // Show target page
                targetPage.style.display = 'block';
                
                {(_updateNavigation ? $@"
                // Update active navigation
                document.querySelectorAll('{_navLinkSelector}').forEach(function(navLink) {{
                    navLink.classList.remove('active');
                }});
                this.classList.add('active');" : "")}
            }}
        }});
    }});
}});";
    }
}