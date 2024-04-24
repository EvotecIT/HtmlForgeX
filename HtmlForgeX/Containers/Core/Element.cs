using HtmlForgeX.Tags;

namespace HtmlForgeX;

public abstract class Element {
    public List<Element> Children { get; } = new List<Element>();

    public Element Add(Element child) {
        Children.Add(child);
        return this;
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
        var progressBar = new TablerProgressBar(TablerProgressBarType.Regular, type);
        this.Add(progressBar);
        return progressBar;
    }

    public TablerProgressBar ProgressBar(TablerProgressBarType type, int percentage, TablerBackground? tablerBackground = null) {
        var progressBar = new TablerProgressBar(TablerProgressBarType.Regular, type);
        if (null == tablerBackground) {
            progressBar.AddItem(TablerBackground.Primary, percentage, "");
        } else {
            progressBar.AddItem(tablerBackground, percentage, "");
        }
        this.Add(progressBar);
        return progressBar;
    }

    public TablerLogs Logs(string code) {
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
}