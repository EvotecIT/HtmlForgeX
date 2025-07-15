using System.Collections.Generic;
using System.Linq;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Enhanced Tabler DataGrid component that provides a fluent C# API for creating key-value data displays
/// with rich content types, configurable spacing, responsive behavior, and all Tabler datagrid features
/// without exposing HTML/CSS/JS knowledge requirements to users.
/// </summary>
public class TablerDataGrid : Element {
    /// <summary>
    /// Collection of items displayed in the grid.
    /// </summary>
    public List<TablerDataGridItem> Items { get; set; } = new List<TablerDataGridItem>();

    // Configuration properties
    private TablerDataGridLayout Layout { get; set; } = TablerDataGridLayout.Default;
    private TablerDataGridSpacing GridSpacing { get; set; } = TablerDataGridSpacing.Medium;
    private string? CustomSpacing { get; set; }
    private TablerDataGridResponsive ResponsiveBehavior { get; set; } = TablerDataGridResponsive.None;
    private TablerDataGridTitleWidth DefaultTitleWidth { get; set; } = TablerDataGridTitleWidth.Auto;
    private string? CustomDefaultTitleWidth { get; set; }
    private TablerMargin? GridMargin { get; set; }
    private TablerPadding? GridPadding { get; set; }
    private string? CustomCssStyle { get; set; }
    private string? ContainerCssClasses { get; set; }

    /// <summary>
    /// Adds a new data grid item using a configuration action.
    /// </summary>
    /// <param name="config">Configuration action for the item.</param>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid AddItem(Action<TablerDataGridItem> config) {
        var item = new TablerDataGridItem();
        config(item);
        Items.Add(item);
        return this;
    }

    /// <summary>
    /// Adds a pre-configured data grid item.
    /// </summary>
    /// <param name="item">The data grid item to add.</param>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid AddItem(TablerDataGridItem item) {
        Items.Add(item);
        return this;
    }

    /// <summary>
    /// Adds a simple title-content item.
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <param name="content">The content text.</param>
    /// <returns>The created TablerDataGridItem for further configuration.</returns>
    public TablerDataGridItem AddItem(string title, string content) {
        var item = new TablerDataGridItem().Title(title).Content(content);
        Items.Add(item);
        return item;
    }

    /// <summary>
    /// Adds a title-element item.
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <param name="content">The content element.</param>
    /// <returns>The created TablerDataGridItem for further configuration.</returns>
    public TablerDataGridItem AddItem(string title, Element content) {
        var item = new TablerDataGridItem().Title(title).Content(content);
        Items.Add(item);
        return item;
    }

    /// <summary>
    /// Adds a badge item with specified color and style.
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <param name="badgeText">The badge text.</param>
    /// <param name="color">The badge color.</param>
    /// <param name="style">The badge style.</param>
    /// <returns>The created TablerDataGridItem for further configuration.</returns>
    public TablerDataGridItem AddBadgeItem(string title, string badgeText, TablerColor color = TablerColor.Primary, TablerBadgeStyle style = TablerBadgeStyle.Normal) {
        var item = new TablerDataGridItem().Title(title).BadgeContent(badgeText, color, style);
        Items.Add(item);
        return item;
    }

    /// <summary>
    /// Adds a status item with specified color.
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <param name="statusText">The status text.</param>
    /// <param name="color">The status color.</param>
    /// <returns>The created TablerDataGridItem for further configuration.</returns>
    public TablerDataGridItem AddStatusItem(string title, string statusText, TablerColor color = TablerColor.Success) {
        var item = new TablerDataGridItem().Title(title).StatusContent(statusText, color);
        Items.Add(item);
        return item;
    }

    /// <summary>
    /// Adds an avatar item with user information.
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <param name="userName">The user name.</param>
    /// <param name="avatarConfig">Configuration action for the avatar.</param>
    /// <returns>The created TablerDataGridItem for further configuration.</returns>
    public TablerDataGridItem AddAvatarItem(string title, string userName, Action<TablerAvatar> avatarConfig) {
        var item = new TablerDataGridItem().Title(title).AvatarContent(userName, avatarConfig);
        Items.Add(item);
        return item;
    }

    /// <summary>
    /// Adds an avatar list item with multiple users.
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <param name="avatarConfigs">Configuration actions for each avatar.</param>
    /// <returns>The created TablerDataGridItem for further configuration.</returns>
    public TablerDataGridItem AddAvatarListItem(string title, params Action<TablerAvatar>[] avatarConfigs) {
        var item = new TablerDataGridItem().Title(title).AvatarListContent(avatarConfigs);
        Items.Add(item);
        return item;
    }

    /// <summary>
    /// Adds an icon item with optional text.
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <param name="iconType">The icon type.</param>
    /// <param name="text">Optional text to display with the icon.</param>
    /// <param name="color">Optional icon color.</param>
    /// <returns>The created TablerDataGridItem for further configuration.</returns>
    public TablerDataGridItem AddIconItem(string title, TablerIconType iconType, string? text = null, TablerColor? color = null) {
        var item = new TablerDataGridItem().Title(title).IconContent(iconType, text, color);
        Items.Add(item);
        return item;
    }

    /// <summary>
    /// Adds a checkbox item.
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <param name="isChecked">Whether the checkbox is checked.</param>
    /// <param name="label">Optional label for the checkbox.</param>
    /// <param name="name">Optional name attribute.</param>
    /// <returns>The created TablerDataGridItem for further configuration.</returns>
    public TablerDataGridItem AddCheckboxItem(string title, bool isChecked = false, string? label = null, string? name = null) {
        var item = new TablerDataGridItem().Title(title).CheckboxContent(isChecked, label, name);
        Items.Add(item);
        return item;
    }

    /// <summary>
    /// Adds a form control item (input field).
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <param name="inputType">The input type.</param>
    /// <param name="placeholder">Optional placeholder text.</param>
    /// <param name="value">Optional default value.</param>
    /// <param name="name">Optional name attribute.</param>
    /// <returns>The created TablerDataGridItem for further configuration.</returns>
    public TablerDataGridItem AddFormControlItem(string title, string inputType = "text", string? placeholder = null, string? value = null, string? name = null) {
        var item = new TablerDataGridItem().Title(title).FormControlContent(inputType, placeholder, value, name);
        Items.Add(item);
        return item;
    }

    /// <summary>
    /// Creates a new item and returns it for inline configuration.
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <returns>The created TablerDataGridItem for configuration chaining.</returns>
    public TablerDataGridItem Title(string title) {
        var item = new TablerDataGridItem().Title(title);
        Items.Add(item);
        return item;
    }

    // Configuration methods for the DataGrid container

    /// <summary>
    /// Sets the layout style for the data grid.
    /// </summary>
    /// <param name="layout">The layout style.</param>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid WithLayout(TablerDataGridLayout layout) {
        Layout = layout;
        return this;
    }

    /// <summary>
    /// Sets the spacing between grid items using predefined values.
    /// </summary>
    /// <param name="spacing">The spacing value.</param>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid WithSpacing(TablerDataGridSpacing spacing) {
        GridSpacing = spacing;
        return this;
    }

    /// <summary>
    /// Sets custom spacing between grid items.
    /// </summary>
    /// <param name="customSpacing">Custom CSS spacing value.</param>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid WithCustomSpacing(string customSpacing) {
        GridSpacing = TablerDataGridSpacing.Custom;
        CustomSpacing = customSpacing;
        return this;
    }

    /// <summary>
    /// Sets the responsive behavior for the data grid.
    /// </summary>
    /// <param name="responsive">The responsive behavior.</param>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid WithResponsive(TablerDataGridResponsive responsive) {
        ResponsiveBehavior = responsive;
        return this;
    }

    /// <summary>
    /// Sets the default title width for all items.
    /// </summary>
    /// <param name="width">The default title width.</param>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid WithDefaultTitleWidth(TablerDataGridTitleWidth width) {
        DefaultTitleWidth = width;
        return this;
    }

    /// <summary>
    /// Sets custom default title width for all items.
    /// </summary>
    /// <param name="customWidth">Custom CSS width value.</param>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid WithCustomDefaultTitleWidth(string customWidth) {
        DefaultTitleWidth = TablerDataGridTitleWidth.Custom;
        CustomDefaultTitleWidth = customWidth;
        return this;
    }

    /// <summary>
    /// Sets margin using Tabler margin utilities.
    /// </summary>
    /// <param name="margin">The margin value.</param>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid WithMargin(TablerMargin margin) {
        GridMargin = margin;
        return this;
    }

    /// <summary>
    /// Sets padding using Tabler padding utilities.
    /// </summary>
    /// <param name="padding">The padding value.</param>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid WithPadding(TablerPadding padding) {
        GridPadding = padding;
        return this;
    }

    /// <summary>
    /// Sets custom CSS styles for the data grid container.
    /// </summary>
    /// <param name="cssStyle">Custom CSS style string.</param>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid WithCustomStyle(string cssStyle) {
        CustomCssStyle = cssStyle;
        return this;
    }

    /// <summary>
    /// Adds custom CSS classes to the container (for advanced users).
    /// </summary>
    /// <param name="cssClasses">Additional CSS classes.</param>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid WithCustomClasses(string cssClasses) {
        ContainerCssClasses = cssClasses;
        return this;
    }

    // Convenience methods for common patterns

    /// <summary>
    /// Creates a compact data grid with reduced spacing.
    /// </summary>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid AsCompact() {
        return WithLayout(TablerDataGridLayout.Compact).WithSpacing(TablerDataGridSpacing.Small);
    }

    /// <summary>
    /// Creates a spacious data grid with increased spacing.
    /// </summary>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid AsSpacious() {
        return WithLayout(TablerDataGridLayout.Spacious).WithSpacing(TablerDataGridSpacing.Large);
    }

    /// <summary>
    /// Enables mobile-responsive behavior.
    /// </summary>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid AsMobileResponsive() {
        return WithResponsive(TablerDataGridResponsive.Mobile);
    }

    /// <summary>
    /// Enables full responsive behavior.
    /// </summary>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid AsFullyResponsive() {
        return WithResponsive(TablerDataGridResponsive.Always);
    }

    /// <summary>
    /// Sets narrow title widths for compact display.
    /// </summary>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid WithNarrowTitles() {
        return WithDefaultTitleWidth(TablerDataGridTitleWidth.Narrow);
    }

    /// <summary>
    /// Sets wide title widths for spacious display.
    /// </summary>
    /// <returns>The TablerDataGrid for method chaining.</returns>
    public TablerDataGrid WithWideTitles() {
        return WithDefaultTitleWidth(TablerDataGridTitleWidth.Wide);
    }

    /// <summary>
    /// Generates the HTML output for the data grid.
    /// </summary>
    /// <returns>The HTML string representation.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        // Build CSS classes for the container
        var cssClasses = new List<string> { Layout.ToCssClasses() };

        // Add responsive classes
        var responsiveClasses = ResponsiveBehavior.ToResponsiveClasses();
        if (!string.IsNullOrEmpty(responsiveClasses)) {
            cssClasses.Add(responsiveClasses);
        }

        // Add Tabler utility classes
        if (GridMargin.HasValue) {
            cssClasses.Add(GridMargin.Value.EnumToString());
        }

        if (GridPadding.HasValue) {
            cssClasses.Add(GridPadding.Value.EnumToString());
        }

        // Add custom classes
        if (!string.IsNullOrEmpty(ContainerCssClasses)) {
            cssClasses.Add(ContainerCssClasses);
        }

        // Build inline styles for the container
        var inlineStyles = new List<string>();

        if (GridSpacing == TablerDataGridSpacing.Custom && !string.IsNullOrEmpty(CustomSpacing)) {
            inlineStyles.Add($"gap: {CustomSpacing}");
        } else if (GridSpacing != TablerDataGridSpacing.Medium) {
            inlineStyles.Add($"gap: {GridSpacing.ToCssValue()}");
        }

        // Add default title width styles
        if (DefaultTitleWidth == TablerDataGridTitleWidth.Custom && !string.IsNullOrEmpty(CustomDefaultTitleWidth)) {
            inlineStyles.Add($"--datagrid-title-width: {CustomDefaultTitleWidth}");
        } else if (DefaultTitleWidth != TablerDataGridTitleWidth.Auto) {
            inlineStyles.Add($"--datagrid-title-width: {DefaultTitleWidth.ToCssValue()}");
        }

        if (!string.IsNullOrEmpty(CustomCssStyle)) {
            inlineStyles.Add(CustomCssStyle);
        }

        // Start container
        html.Append($@"<div class=""{string.Join(" ", cssClasses)}""");

        if (inlineStyles.Count > 0) {
            html.Append($@" style=""{string.Join("; ", inlineStyles)}""");
        }

        html.Append(">");

        // Add all items
        foreach (var item in Items.WhereNotNull()) {
            html.Append(item.ToString());
        }

        html.Append("</div>");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}