using HtmlForgeX.Tags;

namespace HtmlForgeX;

public abstract class Element {
    public List<Element> Children { get; } = new List<Element>();

    private Document? _document;
    private Email? _email;

    /// <summary>
    /// Gets or sets the parent EmailColumn reference. Used internally for column-aware rendering.
    /// </summary>
    protected internal EmailColumn? ParentColumn { get; set; }

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

    /// <summary>
    /// Adds a child element to this element.
    /// </summary>
    /// <param name="element">The element to add.</param>
    /// <returns>This element for method chaining.</returns>
    public virtual Element Add(Element element) {
        element.Email = this.Email;
        element.Document = this.Document;
        Children.Add(element);

        // Notify the element that it has been added to a document
        element.OnAddedToDocument();

        return this;
    }

    /// <summary>
    /// Called when this element is added to a document.
    /// Override this method to apply document-specific configuration.
    /// </summary>
    protected virtual void OnAddedToDocument() {
        // Base implementation does nothing
        // Derived classes can override to apply configuration
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
    /// Adds a simple text span with optional color and size.
    /// </summary>
    /// <param name="content">The text content.</param>
    /// <param name="color">Optional text color.</param>
    /// <param name="fontSize">Optional font size.</param>
    /// <returns></returns>
    public Span Text(string content, RGBColor? color = null, string? fontSize = null) {
        var span = new Span { Content = content };
        if (color != null) span.WithColor(color);
        if (fontSize != null) span.WithFontSize(fontSize);
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

    public MermaidDiagram DiagramMermaid(Action<MermaidDiagram> config) {
        var diagram = new MermaidDiagram();
        config(diagram);
        this.Add(diagram);
        return diagram;
    }

    public MermaidDiagram DiagramMermaid(string code) {
        var diagram = new MermaidDiagram();
        diagram.Code(code);
        this.Add(diagram);
        return diagram;
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

    // Email Extension Methods for Natural Builder Pattern

    /// <summary>
    /// Adds email text with customizable styling.
    /// </summary>
    /// <param name="content">The text content.</param>
    /// <returns>The EmailText object for further configuration.</returns>
    public EmailText EmailText(string content = "") {
        var emailText = new EmailText(content);
        this.Add(emailText);
        return emailText;
    }

    /// <summary>
    /// Adds email text with configuration action.
    /// </summary>
    /// <param name="config">Configuration action for the email text.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element EmailText(Action<EmailText> config) {
        var emailText = new EmailText();
        config(emailText);
        this.Add(emailText);
        return this;
    }

    /// <summary>
    /// Adds email table with configuration action.
    /// </summary>
    /// <param name="config">Configuration action for the email table.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element EmailTable(Action<EmailTable> config) {
        var emailTable = new EmailTable();
        config(emailTable);
        this.Add(emailTable);
        return this;
    }

    /// <summary>
    /// Adds email table populated from data collection.
    /// </summary>
    /// <typeparam name="T">The type of objects in the data collection.</typeparam>
    /// <param name="data">The data collection to populate the table.</param>
    /// <returns>The EmailTable object for further configuration.</returns>
    public EmailTable EmailTable<T>(IEnumerable<T> data) where T : class {
        var emailTable = new EmailTable();
        emailTable.PopulateFromData(data);
        this.Add(emailTable);
        return emailTable;
    }

    /// <summary>
    /// Adds email list with configuration action.
    /// </summary>
    /// <param name="config">Configuration action for the email list.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element EmailList(Action<EmailList> config) {
        var emailList = new EmailList();
        config(emailList);
        this.Add(emailList);
        return this;
    }

    /// <summary>
    /// Adds email row with configuration action.
    /// </summary>
    /// <param name="config">Configuration action for the email row.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element EmailRow(Action<EmailRow> config) {
        var emailRow = new EmailRow();
        config(emailRow);
        this.Add(emailRow);
        return this;
    }

    /// <summary>
    /// Adds email column with configuration action.
    /// </summary>
    /// <param name="config">Configuration action for the email column.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element EmailColumn(Action<EmailColumn> config) {
        var emailColumn = new EmailColumn();
        config(emailColumn);
        this.Add(emailColumn);
        return this;
    }

    /// <summary>
    /// Adds email box with configuration action.
    /// </summary>
    /// <param name="config">Configuration action for the email box.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element EmailBox(Action<EmailBox> config) {
        var emailBox = new EmailBox();
        config(emailBox);
        this.Add(emailBox);
        return this;
    }

    /// <summary>
    /// Adds email text box with configuration action.
    /// </summary>
    /// <param name="config">Configuration action for the email text box.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element EmailTextBox(Action<EmailTextBox> config) {
        var emailTextBox = new EmailTextBox();
        config(emailTextBox);
        this.Add(emailTextBox);
        return this;
    }

    /// <summary>
    /// Adds email image with configuration action.
    /// </summary>
    /// <param name="config">Configuration action for the email image.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element EmailImage(Action<EmailImage> config) {
        var emailImage = new EmailImage();
        config(emailImage);
        this.Add(emailImage);
        return this;
    }

    /// <summary>
    /// Adds email image with source.
    /// </summary>
    /// <param name="source">The image source URL.</param>
    /// <returns>The EmailImage object for further configuration.</returns>
    public EmailImage EmailImage(string source) {
        var emailImage = new EmailImage(source);
        this.Add(emailImage);
        return emailImage;
    }

    /// <summary>
    /// Adds email image with source and width.
    /// </summary>
    /// <param name="source">The image source URL.</param>
    /// <param name="width">The image width.</param>
    /// <returns>The EmailImage object for further configuration.</returns>
    public EmailImage EmailImage(string source, string width) {
        var emailImage = new EmailImage(source, width);
        this.Add(emailImage);
        return emailImage;
    }

    /// <summary>
    /// Adds line break for emails.
    /// </summary>
    /// <returns>The EmailLineBreak object for further configuration.</returns>
    public EmailLineBreak EmailLineBreak() {
        var lineBreak = new EmailLineBreak();
        this.Add(lineBreak);
        return lineBreak;
    }

    /// <summary>
    /// Adds line break for emails with specified height.
    /// </summary>
    /// <param name="height">The height of the line break.</param>
    /// <returns>The EmailLineBreak object for further configuration.</returns>
    public EmailLineBreak EmailLineBreak(string height) {
        var lineBreak = new EmailLineBreak(height);
        this.Add(lineBreak);
        return lineBreak;
    }

    /// <summary>
    /// Adds an email link with content and URL.
    /// </summary>
    /// <param name="content">The link text content.</param>
    /// <param name="href">The link URL.</param>
    /// <returns>The EmailLink object for further configuration.</returns>
    public EmailLink EmailLink(string content, string href) {
        var emailLink = new EmailLink(content, href);
        this.Add(emailLink);
        return emailLink;
    }

    /// <summary>
    /// Adds an email link with content, URL, and new window setting.
    /// </summary>
    /// <param name="content">The link text content.</param>
    /// <param name="href">The link URL.</param>
    /// <param name="openInNewWindow">Whether to open in a new window.</param>
    /// <returns>The EmailLink object for further configuration.</returns>
    public EmailLink EmailLink(string content, string href, bool openInNewWindow) {
        var emailLink = new EmailLink(content, href, openInNewWindow);
        this.Add(emailLink);
        return emailLink;
    }

    /// <summary>
    /// Adds an email link with a configuration action.
    /// </summary>
    /// <param name="config">The configuration action for the EmailLink.</param>
    /// <returns>The Element object for further chaining.</returns>
    public Element EmailLink(Action<EmailLink> config) {
        var emailLink = new EmailLink();
        config(emailLink);
        this.Add(emailLink);
        return this;
    }

    /// <summary>
    /// Adds email content wrapper that provides consistent single-column structure matching EmailColumn alignment.
    /// Use this when you need single-column content that aligns with multi-column layouts.
    /// </summary>
    /// <param name="config">Configuration action for the email content.</param>
    /// <returns>The current element for method chaining.</returns>
    public Element EmailContent(Action<EmailContent> config) {
        var emailContent = new EmailContent();
        config(emailContent);
        this.Add(emailContent);
        return this;
    }
}