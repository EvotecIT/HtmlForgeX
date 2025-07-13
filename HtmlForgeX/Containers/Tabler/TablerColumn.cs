using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

public class TablerColumn : Element {
    public List<TablerCard> Cards { get; set; } = new List<TablerCard>();
    public string? Class { get; set; }

    public int Count { get; set; }

    public TablerColumn() {
        Class = "col";
    }

    public TablerColumn(TablerColumnNumber columnNumber) {
        Class = columnNumber.EnumToString();
    }

    public TablerColumn WithClass(string className) {
        Class = className;
        return this;
    }

    public override string ToString() {
        //Console.WriteLine("Generating HtmlColumn...");
        var childrenHtml = string.Join("", Children.WhereNotNull().Select(child => child.ToString()));
        var result = $"<div class=\"{Class}\">{childrenHtml}</div>";
        //Console.WriteLine("Generated HtmlColumn: " + result);
        return result;
    }

    public TablerColumn Add(Action<TablerColumn> config) {
        config(this);
        return this;
    }

    public TablerCard Card(Action<TablerCard> config) {
        var card = new TablerCard();
        config(card);
        this.Add(card);
        return card;
    }

    public new TablerCard Card(int count, Action<TablerCard> config) {
        var card = new TablerCard(count);
        config(card);
        this.Add(card);
        return card;
    }
}