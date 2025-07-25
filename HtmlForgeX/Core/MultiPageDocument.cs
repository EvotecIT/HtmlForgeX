using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlForgeX;

/// <summary>
/// Represents a collection of related HTML documents that can be generated as a multi-page site.
/// </summary>
public class MultiPageDocument : IDisposable {
    private readonly List<Document> _documents = new();
    private readonly Dictionary<string, string> _pageMapping = new();
    private TablerNavbar? _sharedNavigation;
    private string? _sharedFooter;
    private TablerLayout _layoutType = TablerLayout.Default;
    private DocumentConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the MultiPageDocument class.
    /// </summary>
    public MultiPageDocument(LibraryMode libraryMode = LibraryMode.Online, ThemeMode themeMode = ThemeMode.Light) {
        _configuration = new DocumentConfiguration {
            LibraryMode = libraryMode,
            ThemeMode = themeMode
        };
    }

    /// <summary>
    /// Sets the shared navigation for all pages.
    /// </summary>
    public MultiPageDocument WithSharedNavigation(Action<TablerNavbar> config) {
        _sharedNavigation = new TablerNavbar();
        config(_sharedNavigation);
        return this;
    }

    /// <summary>
    /// Sets the shared footer for all pages.
    /// </summary>
    public MultiPageDocument WithSharedFooter(string footer) {
        _sharedFooter = footer;
        return this;
    }

    /// <summary>
    /// Sets the layout type for all pages.
    /// </summary>
    public MultiPageDocument WithLayout(TablerLayout layoutType) {
        _layoutType = layoutType;
        return this;
    }

    /// <summary>
    /// Adds a page to the multi-page document.
    /// </summary>
    public MultiPageDocument AddPage(string pageId, string fileName, string title, Action<Document> config) {
        var document = new Document(_configuration.LibraryMode) {
            ThemeMode = _configuration.ThemeMode,
            Head = { Title = title }
        };

        // Apply shared navigation
        if (_sharedNavigation != null) {
            document.Body.Add(_sharedNavigation.Clone());
        }

        // Create layout container
        var layoutContainer = new TablerLayoutContainer().WithLayout(_layoutType);
        
        // Add single page
        layoutContainer.AddPage(pageId, title, page => {
            // Let user configure the page content through the document
            config(document);
            
            // Transfer body children to the page
            foreach (var child in document.Body.Children.Where(c => c != _sharedNavigation).ToList()) {
                page.Add(child);
                document.Body.Children.Remove(child);
            }
        });

        // Add footer if specified
        if (!string.IsNullOrEmpty(_sharedFooter)) {
            layoutContainer.WithFooter(_sharedFooter!);
        }

        document.Body.Add(layoutContainer);
        
        _documents.Add(document);
        _pageMapping[pageId] = fileName;

        return this;
    }

    /// <summary>
    /// Adds a page with direct layout configuration.
    /// </summary>
    public MultiPageDocument AddPageWithLayout(string pageId, string fileName, string title, Action<TablerLayoutPage> config) {
        var document = new Document(_configuration.LibraryMode) {
            ThemeMode = _configuration.ThemeMode,
            Head = { Title = title }
        };

        // Create layout container with shared navigation
        var layoutContainer = new TablerLayoutContainer().WithLayout(_layoutType);
        
        if (_sharedNavigation != null) {
            layoutContainer.WithNavbar(nav => {
                // Copy navigation items, updating links to point to correct files
                foreach (var item in _sharedNavigation.GetNavigationItems()) {
                    nav.AddItem(navItem => {
                        if (item.Text != null) navItem.WithText(item.Text);
                        
                        // Update href to point to the correct file
                        if (item.InternalPageId != null && _pageMapping.ContainsKey(item.InternalPageId)) {
                            navItem.WithHref(_pageMapping[item.InternalPageId]);
                        } else if (item.Href != null) {
                            navItem.WithHref(item.Href);
                        }
                        
                        if (item.Icon.HasValue) {
                            navItem.WithIcon(item.Icon.Value, item.IconColor);
                        }
                        
                        // Mark active if this is the current page
                        if (item.InternalPageId == pageId) {
                            navItem.Active();
                        }
                    });
                }
            });
        }

        // Add the page
        layoutContainer.AddPage(pageId, title, config);

        // Add footer if specified
        if (!string.IsNullOrEmpty(_sharedFooter)) {
            layoutContainer.WithFooter(_sharedFooter!);
        }

        document.Body.Add(layoutContainer);
        _documents.Add(document);
        _pageMapping[pageId] = fileName;

        return this;
    }

    /// <summary>
    /// Saves all documents to the specified directory.
    /// </summary>
    public void SaveAll(string outputDirectory, bool openInBrowser = false) {
        // Ensure directory exists
        Directory.CreateDirectory(outputDirectory);

        // Update navigation links in all documents
        UpdateNavigationLinks();

        // Save each document
        for (int i = 0; i < _documents.Count; i++) {
            var document = _documents[i];
            var fileName = _pageMapping.Values.ElementAt(i);
            var filePath = Path.Combine(outputDirectory, fileName);
            
            document.Save(filePath, openInBrowser && i == 0); // Only open first page
        }
    }

    /// <summary>
    /// Saves all documents asynchronously to the specified directory.
    /// </summary>
    public async Task SaveAllAsync(string outputDirectory, bool openInBrowser = false) {
        // Ensure directory exists
        Directory.CreateDirectory(outputDirectory);

        // Update navigation links in all documents
        UpdateNavigationLinks();

        // Save each document
        var tasks = new List<Task>();
        for (int i = 0; i < _documents.Count; i++) {
            var document = _documents[i];
            var fileName = _pageMapping.Values.ElementAt(i);
            var filePath = Path.Combine(outputDirectory, fileName);
            
            tasks.Add(document.SaveAsync(filePath, openInBrowser && i == 0));
        }

        await Task.WhenAll(tasks);
    }

    /// <summary>
    /// Updates navigation links to point to actual files.
    /// </summary>
    private void UpdateNavigationLinks() {
        // This is handled in AddPageWithLayout method
    }

    /// <summary>
    /// Disposes of all documents.
    /// </summary>
    public void Dispose() {
        foreach (var document in _documents) {
            document.Dispose();
        }
        _documents.Clear();
    }
}

/// <summary>
/// Extension class for TablerNavbar to support cloning and item access.
/// </summary>
internal static class TablerNavbarExtensions {
    internal static TablerNavbar Clone(this TablerNavbar navbar) {
        // Simple clone that preserves navigation structure
        var clone = new TablerNavbar();
        
        // Copy basic properties
        if (navbar._brand != null) clone.WithBrand(navbar._brand, navbar._brandUrl);
        if (navbar._logoUrl != null) clone.WithLogo(navbar._logoUrl, navbar._brandUrl);
        clone.WithStyle(navbar._style);
        clone.WithExpand(navbar._expand);
        clone.WithSticky(navbar._sticky);
        clone.WithDark(navbar._dark);

        // Copy navigation items
        foreach (var item in navbar._items) {
            clone.AddItem(navItem => {
                if (item._text != null) navItem.WithText(item._text);
                if (item._href != null) navItem.WithHref(item._href);
                if (item._icon.HasValue) navItem.WithIcon(item._icon.Value, item._iconColor);
                if (item._active) navItem.Active();
                if (item._disabled) navItem.Disabled();
                if (!string.IsNullOrEmpty(item._badgeText)) navItem.WithBadge(item._badgeText!, item._badgeColor);
                if (!string.IsNullOrEmpty(item._internalPageId)) navItem.WithInternalPageId(item._internalPageId!);
            });
        }

        return clone;
    }

    internal static IEnumerable<NavigationItemInfo> GetNavigationItems(this TablerNavbar navbar) {
        return navbar._items.Select(item => new NavigationItemInfo {
            Text = item._text,
            Href = item._href,
            InternalPageId = item._internalPageId,
            Icon = item._icon,
            IconColor = item._iconColor
        });
    }
}

/// <summary>
/// Helper class to store navigation item information.
/// </summary>
internal class NavigationItemInfo {
    public string? Text { get; set; }
    public string? Href { get; set; }
    public string? InternalPageId { get; set; }
    public TablerIconType? Icon { get; set; }
    public TablerColor? IconColor { get; set; }
}