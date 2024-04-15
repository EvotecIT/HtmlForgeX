namespace HtmlForgeX;

public abstract class HtmlElement {
    public List<HtmlElement> Children { get; } = new List<HtmlElement>();

    public HtmlElement Add(HtmlElement child) {
        Children.Add(child);
        return this;
    }

    public abstract override string ToString();

    /// <summary>
    /// Adds the span.
    /// </summary>
    /// <param name="content">The content.</param>
    /// <returns></returns>
    public HtmlSpan Span(string content = "") {
        var span = new HtmlSpan { Content = content };
        this.Add(span);
        return span;
    }

    /// <summary>
    /// Adds the table.
    /// </summary>
    /// <param name="objects">The objects.</param>
    /// <param name="tableType">Type of the table.</param>
    /// <returns></returns>
    public HtmlTable Table(IEnumerable<object> objects, TableType tableType) {
        var table = HtmlTable.Create(objects, tableType);
        this.Add(table);
        return table;
    }

    public HtmlLineBreak LineBreak() {
        var lineBreak = new HtmlLineBreak();
        this.Add(lineBreak);
        return lineBreak;
    }
}