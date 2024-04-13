using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

public class HtmlTable : HtmlElement {

    public HtmlTable() {

    }

    public HtmlTable(IEnumerable<object> objects) {
        this.AddObjects(objects);
    }


    public List<string> TableHeaders { get; set; } = new List<string>();
    public List<List<string>> TableRows { get; set; } = new List<List<string>>();

    public HtmlTable AddHeader(string header) {
        TableHeaders.Add(header);
        return this;
    }

    public HtmlTable AddRow(List<string> row) {
        TableRows.Add(row);
        return this;
    }

    public HtmlTable AddHeaders(params string[] headers) {
        TableHeaders.AddRange(headers);
        return this;
    }

    public HtmlTable AddRows(params List<string>[] rows) {
        TableRows.AddRange(rows);
        return this;
    }

    public HtmlTable AddObjects(IEnumerable<object> objects) {
        if (objects == null || !objects.Any()) return this;

        // Get the type of the objects
        var type = objects.First().GetType();

        // Get the properties of the objects
        var properties = type.GetProperties();

        // Add the headers
        foreach (var property in properties) {
            AddHeader(property.Name);
        }

        // Add the rows
        foreach (var obj in objects) {
            var row = new List<string>();
            foreach (var property in properties) {
                try {
                    var value = property.GetValue(obj);
                    row.Add(value != null ? value.ToString() : "");
                } catch (Exception) {
                    Console.WriteLine($"Error getting value for property {property.Name}");
                    row.Add("");

                }
            }
            AddRow(row);
        }

        return this;
    }


    public override string ToString() {
        StringBuilder html = new StringBuilder("<table>");

        // Add table headers
        if (TableHeaders.Count > 0) {
            html.Append("<thead><tr>");
            foreach (var header in TableHeaders) {
                html.Append($"<th>{header}</th>");
            }
            html.Append("</tr></thead>");
        }

        // Add table rows
        if (TableRows.Count > 0) {
            html.Append("<tbody>");
            foreach (var row in TableRows) {
                html.Append("<tr>");
                foreach (var cell in row) {
                    html.Append($"<td>{cell}</td>");
                }
                html.Append("</tr>");
            }
            html.Append("</tbody>");
        }

        html.Append("</table>");

        return html.ToString();
    }
}
