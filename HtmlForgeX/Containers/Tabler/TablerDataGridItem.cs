using System;
using System.Collections.Generic;
using System.Text;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Represents an enhanced data grid item that supports rich content types, spacing configuration,
/// and all features from Tabler's datagrid component without exposing HTML classes to users.
/// </summary>
public class TablerDataGridItem : Element {
    private Element? TitleElement { get; set; }
    private Element? ContentElement { get; set; }

    // Configuration properties
    private TablerDataGridSpacing ItemSpacing { get; set; } = TablerDataGridSpacing.Medium;
    private string? CustomSpacing { get; set; }
    private TablerDataGridContentAlignment ContentAlignment { get; set; } = TablerDataGridContentAlignment.Left;
    private TablerDataGridTitleWidth TitleWidth { get; set; } = TablerDataGridTitleWidth.Auto;
    private string? CustomTitleWidth { get; set; }
    private TablerMargin? Margin { get; set; }
    private TablerPadding? Padding { get; set; }
    private string? CustomCssStyle { get; set; }

    /// <summary>
    /// Sets the title for this data grid item.
    /// </summary>
    /// <param name="title">The title text.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem Title(string title) {
        TitleElement = new HtmlTag("div").Class("datagrid-title").Value(title);
        return this;
    }

    /// <summary>
    /// Sets simple text content for this data grid item.
    /// </summary>
    /// <param name="content">The content text.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem Content(string content) {
        ContentElement = new HtmlTag("div").Class("datagrid-content").Value(content);
        return this;
    }

    /// <summary>
    /// Sets element content for this data grid item.
    /// </summary>
    /// <param name="content">The content element.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem Content(Element content) {
        ContentElement = new HtmlTag("div").Class("datagrid-content").Value(content);
        return this;
    }

    /// <summary>
    /// Sets badge content using TablerBadgeSpan.
    /// </summary>
    /// <param name="text">The badge text.</param>
    /// <param name="color">The badge color.</param>
    /// <param name="style">The badge style.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem BadgeContent(string text, TablerColor color = TablerColor.Primary, TablerBadgeStyle style = TablerBadgeStyle.Normal) {
        var badge = new TablerBadgeSpan(text, color, style);
        return Content(badge);
    }

    /// <summary>
    /// Sets status content with a status span.
    /// </summary>
    /// <param name="text">The status text.</param>
    /// <param name="color">The status color.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem StatusContent(string text, TablerColor color = TablerColor.Success) {
        var statusHtml = $@"<span class=""status status-{color.ToString().ToLower()}"">{text}</span>";
        ContentElement = new HtmlTag("div").Class("datagrid-content").Value(statusHtml);
        return this;
    }

    /// <summary>
    /// Sets avatar content with user information.
    /// </summary>
    /// <param name="config">Configuration action for the avatar.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem AvatarContent(Action<TablerAvatar> config) {
        var container = new HtmlTag("div").Class("d-flex align-items-center");
        var avatar = new TablerAvatar();
        config(avatar);
        container.Value(avatar);

        ContentElement = new HtmlTag("div").Class("datagrid-content").Value(container);
        return this;
    }

    /// <summary>
    /// Sets avatar content with user name.
    /// </summary>
    /// <param name="userName">The user name to display.</param>
    /// <param name="config">Configuration action for the avatar.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem AvatarContent(string userName, Action<TablerAvatar> config) {
        var container = new HtmlTag("div").Class("d-flex align-items-center");
        var avatar = new TablerAvatar();
        config(avatar);
        avatar.Size(AvatarSize.XS).Margin(TablerMarginStyle.M2);

        container.Value(avatar);
        container.Value(new HtmlTag("span").Value(userName));

        ContentElement = new HtmlTag("div").Class("datagrid-content").Value(container);
        return this;
    }

    /// <summary>
    /// Sets avatar list content showing multiple users.
    /// </summary>
    /// <param name="avatarConfigs">Configuration actions for each avatar.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem AvatarListContent(params Action<TablerAvatar>[] avatarConfigs) {
        var container = new HtmlTag("div").Class("avatar-list avatar-list-stacked");

        foreach (var config in avatarConfigs) {
            var avatar = new TablerAvatar().Size(AvatarSize.XS);
            config(avatar);
            container.Value(avatar);
        }

        ContentElement = new HtmlTag("div").Class("datagrid-content").Value(container);
        return this;
    }

    /// <summary>
    /// Sets icon content with optional text.
    /// </summary>
    /// <param name="iconType">The icon type.</param>
    /// <param name="text">Optional text to display with the icon.</param>
    /// <param name="color">Optional icon color.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem IconContent(TablerIconType iconType, string? text = null, TablerColor? color = null) {
        var container = new HtmlTag("span");
        var icon = new TablerIconElement(iconType);

        // Apply color as CSS class to container for proper Tabler styling
        if (color.HasValue) {
            container.Class(color.Value.ToTablerText());
        }

        container.Value(icon);

        if (!string.IsNullOrEmpty(text)) {
            container.Value($" {text}");
        }

        ContentElement = new HtmlTag("div").Class("datagrid-content").Value(container);
        return this;
    }

    /// <summary>
    /// Sets checkbox content.
    /// </summary>
    /// <param name="isChecked">Whether the checkbox is checked.</param>
    /// <param name="label">Optional label for the checkbox.</param>
    /// <param name="name">Optional name attribute.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem CheckboxContent(bool isChecked = false, string? label = null, string? name = null) {
        var checkboxHtml = new StringBuilder();
        checkboxHtml.Append(@"<label class=""form-check"">");
        checkboxHtml.Append($@"<input class=""form-check-input"" type=""checkbox""");

        if (isChecked) checkboxHtml.Append(" checked");
        if (!string.IsNullOrEmpty(name)) checkboxHtml.Append($@" name=""{name}""");

        checkboxHtml.Append(" />");

        if (!string.IsNullOrEmpty(label)) {
            checkboxHtml.Append($@"<span class=""form-check-label"">{label}</span>");
        }

        checkboxHtml.Append("</label>");

        ContentElement = new HtmlTag("div").Class("datagrid-content").Value(checkboxHtml.ToString());
        return this;
    }

    /// <summary>
    /// Sets form control content (input field).
    /// </summary>
    /// <param name="inputType">The input type (text, email, etc.).</param>
    /// <param name="placeholder">Optional placeholder text.</param>
    /// <param name="value">Optional default value.</param>
    /// <param name="name">Optional name attribute.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem FormControlContent(string inputType = "text", string? placeholder = null, string? value = null, string? name = null) {
        var inputHtml = new StringBuilder();
        inputHtml.Append($@"<input type=""{inputType}"" class=""form-control form-control-flush""");

        if (!string.IsNullOrEmpty(placeholder)) inputHtml.Append($@" placeholder=""{placeholder}""");
        if (!string.IsNullOrEmpty(value)) inputHtml.Append($@" value=""{value}""");
        if (!string.IsNullOrEmpty(name)) inputHtml.Append($@" name=""{name}""");

        inputHtml.Append(" />");

        ContentElement = new HtmlTag("div").Class("datagrid-content").Value(inputHtml.ToString());
        return this;
    }

    /// <summary>
    /// Sets complex HTML content (for advanced scenarios).
    /// </summary>
    /// <param name="htmlContent">The HTML content.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem HtmlContent(string htmlContent) {
        ContentElement = new HtmlTag("div").Class("datagrid-content").Value(htmlContent);
        return this;
    }

    // Spacing and layout configuration methods

    /// <summary>
    /// Sets the spacing for this item using predefined values.
    /// </summary>
    /// <param name="spacing">The spacing value.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem WithSpacing(TablerDataGridSpacing spacing) {
        ItemSpacing = spacing;
        return this;
    }

    /// <summary>
    /// Sets custom spacing for this item.
    /// </summary>
    /// <param name="customSpacing">Custom CSS spacing value.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem WithCustomSpacing(string customSpacing) {
        ItemSpacing = TablerDataGridSpacing.Custom;
        CustomSpacing = customSpacing;
        return this;
    }

    /// <summary>
    /// Sets the content alignment.
    /// </summary>
    /// <param name="alignment">The content alignment.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem WithContentAlignment(TablerDataGridContentAlignment alignment) {
        ContentAlignment = alignment;
        return this;
    }

    /// <summary>
    /// Sets the title width using predefined values.
    /// </summary>
    /// <param name="width">The title width.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem WithTitleWidth(TablerDataGridTitleWidth width) {
        TitleWidth = width;
        return this;
    }

    /// <summary>
    /// Sets custom title width.
    /// </summary>
    /// <param name="customWidth">Custom CSS width value.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem WithCustomTitleWidth(string customWidth) {
        TitleWidth = TablerDataGridTitleWidth.Custom;
        CustomTitleWidth = customWidth;
        return this;
    }

    /// <summary>
    /// Sets margin using Tabler margin utilities.
    /// </summary>
    /// <param name="margin">The margin value.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem WithMargin(TablerMargin margin) {
        Margin = margin;
        return this;
    }

    /// <summary>
    /// Sets padding using Tabler padding utilities.
    /// </summary>
    /// <param name="padding">The padding value.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem WithPadding(TablerPadding padding) {
        Padding = padding;
        return this;
    }

    /// <summary>
    /// Sets custom CSS styles for advanced customization.
    /// </summary>
    /// <param name="cssStyle">Custom CSS style string.</param>
    /// <returns>The TablerDataGridItem for method chaining.</returns>
    public TablerDataGridItem WithCustomStyle(string cssStyle) {
        CustomCssStyle = cssStyle;
        return this;
    }

    /// <summary>
    /// Generates the HTML output for this data grid item.
    /// </summary>
    /// <returns>The HTML string representation.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        // Build CSS classes
        var cssClasses = new List<string> { "datagrid-item" };

        if (Margin.HasValue) {
            cssClasses.Add(Margin.Value.EnumToString());
        }

        if (Padding.HasValue) {
            cssClasses.Add(Padding.Value.EnumToString());
        }

        // Build inline styles
        var inlineStyles = new List<string>();

        if (ItemSpacing == TablerDataGridSpacing.Custom && !string.IsNullOrEmpty(CustomSpacing)) {
            inlineStyles.Add($"padding: {CustomSpacing}");
        } else if (ItemSpacing != TablerDataGridSpacing.Medium) {
            inlineStyles.Add($"padding: {ItemSpacing.ToCssValue()}");
        }

        if (!string.IsNullOrEmpty(CustomCssStyle)) {
            inlineStyles.Add(CustomCssStyle);
        }

        // Start item container
        html.Append($@"<div class=""{string.Join(" ", cssClasses)}""");

        if (inlineStyles.Count > 0) {
            html.Append($@" style=""{string.Join("; ", inlineStyles)}""");
        }

        html.Append(">");

        // Add title element with configuration
        if (TitleElement != null) {
            var titleStyles = new List<string>();

            if (TitleWidth == TablerDataGridTitleWidth.Custom && !string.IsNullOrEmpty(CustomTitleWidth)) {
                titleStyles.Add($"width: {CustomTitleWidth}");
            } else if (TitleWidth != TablerDataGridTitleWidth.Auto) {
                titleStyles.Add($"width: {TitleWidth.ToCssValue()}");
            }

            if (titleStyles.Count > 0) {
                var titleContent = TitleElement.ToString();
                var titleWithStyle = titleContent.Replace(@"class=""datagrid-title""",
                    $@"class=""datagrid-title"" style=""{string.Join("; ", titleStyles)}""");
                html.Append(titleWithStyle);
            } else {
                html.Append(TitleElement.ToString());
            }
        }

        // Add content element with configuration
        if (ContentElement != null) {
            var contentStyles = new List<string>();

            if (ContentAlignment != TablerDataGridContentAlignment.Left) {
                contentStyles.Add($"text-align: {ContentAlignment.ToCssValue()}");
            }

            if (contentStyles.Count > 0) {
                var contentHtml = ContentElement.ToString();
                var contentWithStyle = contentHtml.Replace(@"class=""datagrid-content""",
                    $@"class=""datagrid-content"" style=""{string.Join("; ", contentStyles)}""");
                html.Append(contentWithStyle);
            } else {
                html.Append(ContentElement.ToString());
            }
        }

        html.Append("</div>");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}
