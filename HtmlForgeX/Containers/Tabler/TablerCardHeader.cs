using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// Tabler card header component with fluent API - no raw HTML required
/// </summary>
public class TablerCardHeader : Element {
    private string? TitleText { get; set; }
    private string? SubtitleText { get; set; }
    private TablerCardHeaderStyle HeaderStyle { get; set; } = TablerCardHeaderStyle.Default;
    private TablerAvatar? HeaderAvatar { get; set; }
    private List<TablerCardAction> Actions { get; set; } = new List<TablerCardAction>();
    private TablerCardNavigation? Navigation { get; set; }

    /// <summary>
    /// Set the card header title
    /// </summary>
    public TablerCardHeader Title(string title) {
        TitleText = title;
        return this;
    }

    /// <summary>
    /// Set the card header subtitle
    /// </summary>
    public TablerCardHeader Subtitle(string subtitle) {
        SubtitleText = subtitle;
        return this;
    }

    /// <summary>
    /// Set the header style (light, dark, transparent, etc.)
    /// </summary>
    public TablerCardHeader Style(TablerCardHeaderStyle style) {
        HeaderStyle = style;
        return this;
    }

    /// <summary>
    /// Add an avatar to the header
    /// </summary>
    public TablerCardHeader Avatar(Action<TablerAvatar> avatarConfig) {
        HeaderAvatar = new TablerAvatar();
        avatarConfig(HeaderAvatar);
        return this;
    }

    /// <summary>
    /// Add action buttons to the header
    /// </summary>
    public TablerCardHeader WithActions(Action<TablerCardActionBuilder> actionsConfig) {
        var builder = new TablerCardActionBuilder();
        actionsConfig(builder);
        Actions = builder.GetActions();
        return this;
    }

    /// <summary>
    /// Add navigation tabs or pills to the header
    /// </summary>
    public TablerCardHeader WithNavigation(Action<TablerCardNavigation> navConfig) {
        Navigation = new TablerCardNavigation();
        navConfig(Navigation);
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        var headerDiv = new HtmlTag("div");
        var classes = new List<string> { "card-header" };

        // Add header style classes
        var styleClass = HeaderStyle.ToTablerCardHeaderClass();
        if (!string.IsNullOrEmpty(styleClass)) {
            classes.Add(styleClass);
        }

        headerDiv.Class(string.Join(" ", classes));

        // Navigation goes first (tabs/pills)
        if (Navigation != null) {
            headerDiv.Value(Navigation.ToString());
        } else {
            // Regular header content
            if (HeaderAvatar != null || !string.IsNullOrEmpty(TitleText) || Actions.Count > 0) {
                var rowDiv = new HtmlTag("div").Class("row align-items-center");

                // Avatar column
                if (HeaderAvatar != null) {
                    var avatarCol = new HtmlTag("div").Class("col-auto");
                    avatarCol.Value(HeaderAvatar.ToString());
                    rowDiv.Value(avatarCol);
                }

                // Title/subtitle column
                if (!string.IsNullOrEmpty(TitleText)) {
                    var titleCol = new HtmlTag("div").Class("col");

                    var titleElement = new HtmlTag("h3").Class("card-title").Value(TitleText);
                    titleCol.Value(titleElement);

                    if (!string.IsNullOrEmpty(SubtitleText)) {
                        var subtitleElement = new HtmlTag("div").Class("card-subtitle").Value(SubtitleText);
                        titleCol.Value(subtitleElement);
                    }

                    rowDiv.Value(titleCol);
                }

                // Actions column
                if (Actions.Count > 0) {
                    var actionsCol = new HtmlTag("div").Class("col-auto");
                    var actionsDiv = new HtmlTag("div").Class("card-actions");

                    for (int i = 0; i < Actions.Count; i++) {
                        var action = Actions[i];

                        // Add spacing between buttons (except for the first one)
                        if (i > 0) {
                            // Create a wrapper div with margin for spacing
                            var actionWrapper = new HtmlTag("span").Class("ms-1");
                            actionWrapper.Value(action.ToString());
                            actionsDiv.Value(actionWrapper);
                        } else {
                            actionsDiv.Value(action.ToString());
                        }
                    }

                    actionsCol.Value(actionsDiv);
                    rowDiv.Value(actionsCol);
                }

                headerDiv.Value(rowDiv);
            } else {
                // Simple title only
                if (!string.IsNullOrEmpty(TitleText)) {
                    var titleElement = new HtmlTag("h3").Class("card-title").Value(TitleText);
                    headerDiv.Value(titleElement);
                }
            }
        }

        return headerDiv.ToString();
    }
}

/// <summary>
/// Builder for card header actions
/// </summary>
public class TablerCardActionBuilder {
    private List<TablerCardAction> actions = new List<TablerCardAction>();

    /// <summary>
    /// Initializes or configures Button.
    /// </summary>
    public TablerCardActionBuilder Button(string text, Action<TablerCardButton>? config = null) {
        var button = new TablerCardButton().WithText(text);
        config?.Invoke(button);
        actions.Add(button);
        return this;
    }

    /// <summary>
    /// Initializes or configures IconButton.
    /// </summary>
    public TablerCardActionBuilder IconButton(TablerIconType icon, Action<TablerCardButton>? config = null) {
        var button = new TablerCardButton().Icon(icon);
        config?.Invoke(button);
        actions.Add(button);
        return this;
    }

    public List<TablerCardAction> GetActions() => actions;
}