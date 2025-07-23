using HtmlForgeX.Tags;

namespace HtmlForgeX;

public abstract partial class Element {
    /// <summary>
    /// Adds and configures a <see cref="TablerDataGrid"/> element.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The created data grid.</returns>
    public TablerDataGrid DataGrid(Action<TablerDataGrid> config) {
        var dataGrid = new TablerDataGrid();
        config(dataGrid);
        this.Add(dataGrid);
        return dataGrid;
    }

    /// <summary>
    /// Adds and configures a <see cref="TablerForm"/> element.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The created form element.</returns>
    public TablerForm Form(Action<TablerForm> config) {
        var form = new TablerForm();
        config(form);
        this.Add(form);
        return form;
    }

    /// <summary>
    /// Adds and configures a <see cref="TablerColumn"/> element.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The created column element.</returns>
    public TablerColumn Column(Action<TablerColumn> config) {
        var column = new TablerColumn();
        config(column);
        this.Add(column);
        return column;
    }

    /// <summary>
    /// Adds and configures a <see cref="TablerColumn"/> element with a specific width.
    /// </summary>
    /// <param name="number">Column width.</param>
    /// <param name="config">Configuration action.</param>
    /// <returns>The created column element.</returns>
    public TablerColumn Column(TablerColumnNumber number, Action<TablerColumn> config) {
        var column = new TablerColumn(number);
        config(column);
        this.Add(column);
        return column;
    }

    /// <summary>
    /// Adds and configures a <see cref="TablerRow"/> element.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The created row element.</returns>
    public TablerRow Row(Action<TablerRow> config) {
        var row = new TablerRow();
        config(row);
        this.Add(row);
        return row;
    }

    /// <summary>
    /// Adds a simple <see cref="TablerAvatar"/> element.
    /// </summary>
    /// <returns>The created avatar element.</returns>
    public TablerAvatar Avatar() {
        var avatar = new TablerAvatar();
        this.Add(avatar);
        return avatar;
    }

    /// <summary>
    /// Adds a text element with initial value.
    /// </summary>
    /// <param name="text">Initial text.</param>
    /// <returns>The created text element.</returns>
    public TablerText Text(string text) {
        var tablerText = new TablerText(text);
        this.Add(tablerText);
        return tablerText;
    }

    /// <summary>
    /// Adds an empty text element.
    /// </summary>
    /// <returns>The created text element.</returns>
    public TablerText Text() {
        var tablerText = new TablerText();
        this.Add(tablerText);
        return tablerText;
    }

    /// <summary>
    /// Adds and configures a <see cref="TablerCard"/>.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The created card element.</returns>
    public TablerCard Card(Action<TablerCard> config) {
        var card = new TablerCard();
        config(card);
        this.Add(card);
        return card;
    }

    /// <summary>
    /// Adds and configures a <see cref="TablerCard"/> with a preset count.
    /// </summary>
    /// <param name="count">Initial counter value.</param>
    /// <param name="config">Configuration action.</param>
    /// <returns>The created card element.</returns>
    public TablerCard Card(int count, Action<TablerCard> config) {
        var card = new TablerCard(count);
        config(card);
        this.Add(card);
        return card;
    }

    /// <summary>
    /// Adds a mini variant of <see cref="TablerCard"/>.
    /// </summary>
    /// <returns>The created card element.</returns>
    public TablerCardMini CardMini() {
        var card = new TablerCardMini();
        this.Add(card);
        return card;
    }

    /// <summary>
    /// Adds a basic tabler card.
    /// </summary>
    /// <returns>The created card element.</returns>
    public TablerCardBasic CardBasic() {
        var card = new TablerCardBasic();
        this.Add(card);
        return card;
    }

    /// <summary>
    /// Adds a basic card with title and text.
    /// </summary>
    /// <param name="title">Card title.</param>
    /// <param name="text">Card text.</param>
    /// <returns>The created card element.</returns>
    public TablerCardBasic CardBasic(string title, string text) {
        var card = new TablerCardBasic(title, text);
        this.Add(card);
        return card;
    }

    /// <summary>
    /// Adds a header element of the specified level.
    /// </summary>
    /// <param name="level">Header level.</param>
    /// <param name="text">Header text.</param>
    /// <returns>The created header element.</returns>
    public HeaderLevel HeaderLevel(HeaderLevelTag level, string text) {
        var header = new HeaderLevel(level, text);
        this.Add(header);
        return header;
    }

    /// <summary>
    /// Adds a progress bar of a given type.
    /// </summary>
    /// <param name="type">Progress bar type.</param>
    /// <returns>The created progress bar.</returns>
    public TablerProgressBar ProgressBar(TablerProgressBarType type) {
        var progressBar = new TablerProgressBar(type);
        this.Add(progressBar);
        return progressBar;
    }

    /// <summary>
    /// Adds a progress bar prepopulated with a value.
    /// </summary>
    /// <param name="type">Progress bar type.</param>
    /// <param name="percentage">Initial percentage value.</param>
    /// <param name="tablerBackground">Optional background color.</param>
    /// <returns>The created progress bar.</returns>
    public TablerProgressBar ProgressBar(TablerProgressBarType type, int percentage, TablerColor? tablerBackground = null) {
        var progressBar = new TablerProgressBar(type);
        if (tablerBackground is null) {
            progressBar.Item(TablerColor.Primary, percentage, "");
        } else {
            progressBar.Item(tablerBackground.Value, percentage, "");
        }
        this.Add(progressBar);
        return progressBar;
    }

    /// <summary>
    /// Adds a log viewer with source code as a single string.
    /// </summary>
    /// <param name="code">Code to display.</param>
    /// <param name="theme">Color theme.</param>
    /// <param name="backgroundClass">Optional custom background class.</param>
    /// <param name="textClass">Optional custom text class.</param>
    /// <returns>The created log element.</returns>
    public TablerLogs Logs(string code, TablerLogsTheme theme = TablerLogsTheme.Dark, string? backgroundClass = null, string? textClass = null) {
        var logs = new TablerLogs(code);
        if (backgroundClass != null && textClass != null) {
            logs.CustomTheme(backgroundClass, textClass);
        } else {
            logs.Theme(theme);
        }
        this.Add(logs);
        return logs;
    }

    /// <summary>
    /// Adds a log viewer from an array of strings.
    /// </summary>
    public TablerLogs Logs(string[] code, TablerLogsTheme theme = TablerLogsTheme.Dark, string? backgroundClass = null, string? textClass = null) {
        var logs = new TablerLogs(code);
        if (backgroundClass != null && textClass != null) {
            logs.CustomTheme(backgroundClass, textClass);
        } else {
            logs.Theme(theme);
        }
        this.Add(logs);
        return logs;
    }

    /// <summary>
    /// Adds a log viewer from a list of strings.
    /// </summary>
    public TablerLogs Logs(List<string> code, TablerLogsTheme theme = TablerLogsTheme.Dark, string? backgroundClass = null, string? textClass = null) {
        var logs = new TablerLogs(code);
        if (backgroundClass != null && textClass != null) {
            logs.CustomTheme(backgroundClass, textClass);
        } else {
            logs.Theme(theme);
        }
        this.Add(logs);
        return logs;
    }

    /// <summary>
    /// Adds a log viewer with custom colors.
    /// </summary>
    public TablerLogs Logs(string code, RGBColor backgroundColor, RGBColor textColor) {
        var logs = new TablerLogs(code).CustomColors(backgroundColor, textColor);
        this.Add(logs);
        return logs;
    }

    /// <summary>
    /// Adds a log viewer from an array of strings with custom colors.
    /// </summary>
    public TablerLogs Logs(string[] code, RGBColor backgroundColor, RGBColor textColor) {
        var logs = new TablerLogs(code).CustomColors(backgroundColor, textColor);
        this.Add(logs);
        return logs;
    }

    /// <summary>
    /// Adds a log viewer from a list of strings with custom colors.
    /// </summary>
    public TablerLogs Logs(List<string> code, RGBColor backgroundColor, RGBColor textColor) {
        var logs = new TablerLogs(code).CustomColors(backgroundColor, textColor);
        this.Add(logs);
        return logs;
    }

    /// <summary>
    /// Adds a steps component.
    /// </summary>
    public TablerSteps Steps() {
        var steps = new TablerSteps();
        this.Add(steps);
        return steps;
    }

    /// <summary>
    /// Adds and configures an accordion component.
    /// </summary>
    public TablerAccordion Accordion(Action<TablerAccordion> config) {
        var accordion = new TablerAccordion();
        config(accordion);
        this.Add(accordion);
        return accordion;
    }

    /// <summary>
    /// Adds and configures tab navigation.
    /// </summary>
    public TablerTabs Tabs(Action<TablerTabs> config) {
        var tabs = new TablerTabs();
        config(tabs);
        this.Add(tabs);
        return tabs;
    }

    /// <summary>
    /// Adds a divider element with text.
    /// </summary>
    /// <param name="text">Divider caption.</param>
    /// <returns>The created divider.</returns>
    public TablerDivider Divider(string text) {
        var divider = new TablerDivider(text);
        this.Add(divider);
        return divider;
    }

    /// <summary>
    /// Adds an alert element.
    /// </summary>
    public TablerAlert Alert(string title, string message, TablerColor alertColor = TablerColor.Default, TablerAlertType alertType = TablerAlertType.Regular) {
        var alert = new TablerAlert(title, message, alertColor, alertType);
        this.Add(alert);
        return alert;
    }

    /// <summary>
    /// Adds an invisible tracking pixel component.
    /// </summary>
    public TablerTracking Tracking() {
        var tracking = new TablerTracking();
        this.Add(tracking);
        return tracking;
    }

    /// <summary>
    /// Adds and configures a FullCalendar component.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The created calendar element.</returns>
    public FullCalendar FullCalendar(Action<FullCalendar> config) {
        var fullCalendar = new FullCalendar();
        config(fullCalendar);
        this.Add(fullCalendar);
        return fullCalendar;
    }

    /// <summary>
    /// Adds an unordered list styled with Tabler classes.
    /// </summary>
    public UnorderedList TablerList() {
        var unorderedList = new UnorderedList();
        this.Add(unorderedList);
        return unorderedList;
    }

    /// <summary>
    /// Adds a toast notification with preset text.
    /// </summary>
    public TablerToast Toast(string title, string message, TablerToastType type = TablerToastType.Default) {
        var toast = new TablerToast(title, message, type);
        this.Add(toast);
        return toast;
    }

    /// <summary>
    /// Adds and configures a toast notification.
    /// </summary>
    public TablerToast Toast(Action<TablerToast> config) {
        var toast = new TablerToast();
        config(toast);
        this.Add(toast);
        return toast;
    }

    /// <summary>
    /// Adds and configures a timeline component.
    /// </summary>
    public TablerTimeline Timeline(Action<TablerTimeline> config) {
        var timeline = new TablerTimeline();
        config(timeline);
        this.Add(timeline);
        return timeline;
    }

    /// <summary>
    /// Adds a TablerInput form element.
    /// </summary>
    /// <param name="name">Input name and identifier.</param>
    /// <param name="config">Optional configuration action.</param>
    /// <returns>The created TablerInput.</returns>
    public TablerInput TablerInput(string name, Action<TablerInput>? config = null) {
        var input = new TablerInput(name);
        config?.Invoke(input);
        this.Add(input);
        return input;
    }

    /// <summary>
    /// Adds a TablerSelect form element.
    /// </summary>
    /// <param name="name">Select name and identifier.</param>
    /// <param name="config">Optional configuration action.</param>
    /// <returns>The created TablerSelect.</returns>
    public TablerSelect TablerSelect(string name, Action<TablerSelect>? config = null) {
        var select = new TablerSelect(name);
        config?.Invoke(select);
        this.Add(select);
        return select;
    }

    /// <summary>
    /// Adds a TablerTextarea form element.
    /// </summary>
    /// <param name="name">Textarea name and identifier.</param>
    /// <param name="config">Optional configuration action.</param>
    /// <returns>The created TablerTextarea.</returns>
    public TablerTextarea TablerTextarea(string name, Action<TablerTextarea>? config = null) {
        var textarea = new TablerTextarea(name);
        config?.Invoke(textarea);
        this.Add(textarea);
        return textarea;
    }

    /// <summary>
    /// Adds and configures a SmartTab component.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The created SmartTab.</returns>
    public SmartTab SmartTab(Action<SmartTab> config) {
        var smartTab = new SmartTab();
        config(smartTab);
        this.Add(smartTab);
        return smartTab;
    }

    /// <summary>
    /// Adds and configures a SmartWizard component.
    /// </summary>
    /// <param name="config">Configuration action.</param>
    /// <returns>The created SmartWizard.</returns>
    public SmartWizard SmartWizard(Action<SmartWizard> config) {
        var smartWizard = new SmartWizard();
        config(smartWizard);
        this.Add(smartWizard);
        return smartWizard;
    }

    /// <summary>
    /// Adds and configures a countdown timer element.
    /// </summary>
    /// <param name="config">Optional configuration action.</param>
    /// <returns>The created <see cref="TablerCountdown"/>.</returns>
    public TablerCountdown Countdown(Action<TablerCountdown>? config = null) {
        var countdown = new TablerCountdown();
        config?.Invoke(countdown);
        this.Add(countdown);
        return countdown;
    }
}