using HtmlForgeX.Tags;

namespace HtmlForgeX;

public abstract class Element {
    public List<Element> Children { get; } = new List<Element>();

    private Document? _document;
    private Email? _email;

    /// <summary>
    /// Gets or sets the parent document reference. Used internally for library registration.
    /// </summary>
    protected internal Document? Document {
        get => _document;
        set {
            _document = value;
            // Propagate the document reference to all child elements
            PropagateDocumentToChildren();
        }
    }

    /// <summary>
    /// Gets or sets the parent email reference. Used internally for email-specific functionality.
    /// </summary>
    protected internal Email? Email {
        get => _email;
        set {
            _email = value;
            // Propagate the email reference to all child elements
            PropagateEmailToChildren();
        }
    }

    public Element Add(Element child) {
        Children.Add(child);
        // Propagate the document reference to child elements
        if (Document != null) {
            child.Document = Document;
        }
        // Propagate the email reference to child elements
        if (Email != null) {
            child.Email = Email;
        }
        return this;
    }

    /// <summary>
    /// Recursively sets the document reference for all child elements.
    /// </summary>
    private void PropagateDocumentToChildren() {
        foreach (var child in Children) {
            child.Document = Document;
        }
    }

    /// <summary>
    /// Recursively sets the email reference for all child elements.
    /// </summary>
    private void PropagateEmailToChildren() {
        foreach (var child in Children) {
            child.Email = Email;
        }
    }

    /// <summary>
    /// Registers required libraries for this element. Override in derived classes to register specific libraries.
    /// </summary>
    protected internal virtual void RegisterLibraries() {
        // Base implementation does nothing - override in derived classes
    }

    public abstract override string ToString();

    /// <summary>
    /// Adds the span.
    /// </summary>
    /// <param name="content">The content.</param>
    /// <returns></returns>
    public Span Span(string content = "") {
        var span = new Span { Content = content };
        this.Add(span);
        return span;
    }

    /// <summary>
    /// Adds the table.
    /// </summary>
    /// <param name="objects">The objects.</param>
    /// <param name="tableType">Type of the table.</param>
    /// <returns></returns>
    public Table Table(IEnumerable<object> objects, TableType tableType) {
        var table = HtmlForgeX.Table.Create(objects, tableType);
        this.Add(table);
        return table;
    }

    public Table Table(Object objects, TableType tableType) {
        var table = HtmlForgeX.Table.Create(objects, tableType);
        this.Add(table);
        return table;
    }

    public LineBreak LineBreak() {
        var lineBreak = new LineBreak();
        this.Add(lineBreak);
        return lineBreak;
    }

    public TablerDataGrid DataGrid(Action<TablerDataGrid> config) {
        var dataGrid = new TablerDataGrid();
        config(dataGrid);
        this.Add(dataGrid);
        return dataGrid;
    }

    public FancyTree FancyTree(Action<FancyTree> config) {
        var fancyTree = new FancyTree();
        config(fancyTree);
        this.Add(fancyTree);
        return fancyTree;
    }

    public ApexCharts ApexChart(Action<ApexCharts> config) {
        var apexChart = new ApexCharts();
        config(apexChart);
        this.Add(apexChart);
        return apexChart;
    }

    public VisNetwork DiagramNetwork(Action<VisNetwork> config) {
        var visNetwork = new VisNetwork();
        config(visNetwork);
        this.Add(visNetwork);
        return visNetwork;
    }

    public EasyQRCodeElement QRCode(string text) {
        var qrCode = new EasyQRCodeElement(text);
        this.Add(qrCode);
        return qrCode;
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

    public ScrollingText ScrollingText(Action<ScrollingText> config) {
        var scrollingText = new ScrollingText();
        config(scrollingText);
        this.Add(scrollingText);
        return scrollingText;
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
        if (null == tablerBackground) {
            progressBar.Item(TablerColor.Primary, percentage, "");
        } else {
            progressBar.Item(tablerBackground.Value, percentage, "");
        }
        this.Add(progressBar);
        return progressBar;
    }

    public TablerLogs Logs(string code) {
        var logs = new TablerLogs(code);
        this.Add(logs);
        return logs;
    }

    public TablerLogs Logs(string[] code) {
        var logs = new TablerLogs(code);
        this.Add(logs);
        return logs;
    }

    public TablerLogs Logs(List<string> code) {
        var logs = new TablerLogs(code);
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
}