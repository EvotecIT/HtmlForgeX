using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

public class HtmlTablerColumn : HtmlElement {
    public List<HtmlTablerCard> Cards { get; set; } = new List<HtmlTablerCard>();
    public string? Class { get; set; }

    public HtmlTablerColumn WithClass(string className) {
        Class = className;
        return this;
    }

    public override string ToString() {
        Console.WriteLine("Generating HtmlColumn...");
        var childrenHtml = string.Join("", Children.Select(child => child.ToString()));
        var result = $"<div class=\"{Class}\">{childrenHtml}</div>";
        Console.WriteLine("Generated HtmlColumn: " + result);
        return result;
    }

    public HtmlTablerColumn Add(Action<HtmlTablerColumn> config) {
        config(this);
        return this;
    }

    public HtmlTablerCard Card(Action<HtmlTablerCard> config) {
        var card = new HtmlTablerCard();
        config(card);
        this.Add(card);
        return card;
    }
}