using HtmlForgeX.Tags;

namespace HtmlForgeX;

public abstract partial class Element {
    public TablerDataGrid DataGrid(Action<TablerDataGrid> config) {
        var dataGrid = new TablerDataGrid();
        config(dataGrid);
        this.Add(dataGrid);
        return dataGrid;
    }

    public TablerForm Form(Action<TablerForm> config) {
        var form = new TablerForm();
        config(form);
        this.Add(form);
        return form;
    }

    public TablerColumn Column(Action<TablerColumn> config) {
        var column = new TablerColumn();
        config(column);
        this.Add(column);
        return column;
    }

    public TablerColumn Column(TablerColumnNumber number, Action<TablerColumn> config) {
        var column = new TablerColumn(number);
        config(column);
        this.Add(column);
        return column;
    }

    public TablerRow Row(Action<TablerRow> config) {
        var row = new TablerRow();
        config(row);
        this.Add(row);
        return row;
    }

    public TablerAvatar Avatar() {
        var avatar = new TablerAvatar();
        this.Add(avatar);
        return avatar;
    }

    public TablerText Text(string text) {
        var tablerText = new TablerText(text);
        this.Add(tablerText);
        return tablerText;
    }

    public TablerText Text() {
        var tablerText = new TablerText();
        this.Add(tablerText);
        return tablerText;
    }

    public TablerCard Card(Action<TablerCard> config) {
        var card = new TablerCard();
        config(card);
        this.Add(card);
        return card;
    }

    public TablerCard Card(int count, Action<TablerCard> config) {
        var card = new TablerCard(count);
        config(card);
        this.Add(card);
        return card;
    }

    public TablerCardMini CardMini() {
        var card = new TablerCardMini();
        this.Add(card);
        return card;
    }

    public TablerCardBasic CardBasic() {
        var card = new TablerCardBasic();
        this.Add(card);
        return card;
    }

    public TablerCardBasic CardBasic(string title, string text) {
        var card = new TablerCardBasic(title, text);
        this.Add(card);
        return card;
    }

    public HeaderLevel HeaderLevel(HeaderLevelTag level, string text) {
        var header = new HeaderLevel(level, text);
        this.Add(header);
        return header;
    }

    public TablerProgressBar ProgressBar(TablerProgressBarType type) {
        var progressBar = new TablerProgressBar(type);
        this.Add(progressBar);
        return progressBar;
    }

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

    public TablerLogs Logs(string code, RGBColor backgroundColor, RGBColor textColor) {
        var logs = new TablerLogs(code).CustomColors(backgroundColor, textColor);
        this.Add(logs);
        return logs;
    }

    public TablerLogs Logs(string[] code, RGBColor backgroundColor, RGBColor textColor) {
        var logs = new TablerLogs(code).CustomColors(backgroundColor, textColor);
        this.Add(logs);
        return logs;
    }

    public TablerLogs Logs(List<string> code, RGBColor backgroundColor, RGBColor textColor) {
        var logs = new TablerLogs(code).CustomColors(backgroundColor, textColor);
        this.Add(logs);
        return logs;
    }

    public TablerSteps Steps() {
        var steps = new TablerSteps();
        this.Add(steps);
        return steps;
    }

    public TablerAccordion Accordion(Action<TablerAccordion> config) {
        var accordion = new TablerAccordion();
        config(accordion);
        this.Add(accordion);
        return accordion;
    }

    public TablerTabs Tabs(Action<TablerTabs> config) {
        var tabs = new TablerTabs();
        config(tabs);
        this.Add(tabs);
        return tabs;
    }

    public TablerDivider Divider(string text) {
        var divider = new TablerDivider(text);
        this.Add(divider);
        return divider;
    }

    public TablerAlert Alert(string title, string message, TablerColor alertColor = TablerColor.Default, TablerAlertType alertType = TablerAlertType.Regular) {
        var alert = new TablerAlert(title, message, alertColor, alertType);
        this.Add(alert);
        return alert;
    }

    public TablerTracking Tracking() {
        var tracking = new TablerTracking();
        this.Add(tracking);
        return tracking;
    }

    public FullCalendar FullCalendar(Action<FullCalendar> config) {
        var fullCalendar = new FullCalendar();
        config(fullCalendar);
        this.Add(fullCalendar);
        return fullCalendar;
    }

    public UnorderedList TablerList() {
        var unorderedList = new UnorderedList();
        this.Add(unorderedList);
        return unorderedList;
    }

    public TablerToast Toast(string title, string message, TablerToastType type = TablerToastType.Default) {
        var toast = new TablerToast(title, message, type);
        this.Add(toast);
        return toast;
    }

    public TablerToast Toast(Action<TablerToast> config) {
        var toast = new TablerToast();
        config(toast);
        this.Add(toast);
        return toast;
    }

    public TablerTimeline Timeline(Action<TablerTimeline> config) {
        var timeline = new TablerTimeline();
        config(timeline);
        this.Add(timeline);
        return timeline;
    }
}
