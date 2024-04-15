using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

public class HtmlTable : HtmlElement {
    private TableType? Library;
    public List<string> TableHeaders { get; set; } = new List<string>();
    public List<string> TableFooters { get; set; } = new List<string>();
    public List<List<string>> TableRows { get; set; } = new List<List<string>>();

    public HtmlTable(TableType? library = null) {
        Library = library;
        AddLibrariesBasedOnTableType();
    }

    public HtmlTable(IEnumerable<object> objects, TableType? library = null) {
        Library = library;
        AddLibrariesBasedOnTableType();

        this.AddObjects(objects);
    }

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
                } catch (Exception ex) {
                    GlobalStorage.Errors.Add($"Error getting value for property {property.Name}: {ex.Message}");
                    row.Add("");
                }
            }
            AddRow(row);
        }

        return this;
    }

    public override string ToString() {
        return BuildTable();
    }

    public virtual string BuildTable() {
        StringBuilder html = new StringBuilder();
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

        return html.ToString();
    }

    public static HtmlTable Create(IEnumerable<object> objects, TableType tableType) {
        HtmlTable table;
        switch (tableType) {
            case TableType.BootstrapTable:
                table = new HtmlTableBootstrap(objects, tableType);
                break;
            case TableType.DataTables:
                table = new HtmlTableDataTables(objects, tableType);
                break;
            case TableType.Tabler:
                table = new HtmlTableTabler(objects, tableType);
                break;
            default:
                throw new Exception("Table type not supported");
        }
        return table;
    }


    private void AddLibrariesBasedOnTableType() {
        if (Library.HasValue) {
            switch (Library.Value) {
                case TableType.BootstrapTable:
                    GlobalStorage.Libraries.Add(Libraries.Bootstrap);
                    break;
                case TableType.DataTables:
                    GlobalStorage.Libraries.Add(Libraries.Bootstrap);
                    GlobalStorage.Libraries.Add(Libraries.JQuery);
                    GlobalStorage.Libraries.Add(Libraries.DataTables);
                    break;
                case TableType.Tabler:
                    GlobalStorage.Libraries.Add(Libraries.Bootstrap);
                    GlobalStorage.Libraries.Add(Libraries.Tabler);
                    break;
                default:
                    throw new Exception("Library not supported");
            }
        }
    }

    //private string BuildTable(string tableClass) {
    //    StringBuilder html;
    //    if (tableClass == string.Empty) {
    //        html = new StringBuilder("<table>");
    //    } else {
    //        html = new StringBuilder($"<table class=\"{tableClass}\">");
    //    }

    //    // Add table headers
    //    if (TableHeaders.Count > 0) {
    //        html.Append("<thead><tr>");
    //        foreach (var header in TableHeaders) {
    //            html.Append($"<th>{header}</th>");
    //        }
    //        html.Append("</tr></thead>");
    //    }

    //    // Add table rows
    //    if (TableRows.Count > 0) {
    //        html.Append("<tbody>");
    //        foreach (var row in TableRows) {
    //            html.Append("<tr>");
    //            foreach (var cell in row) {
    //                html.Append($"<td>{cell}</td>");
    //            }
    //            html.Append("</tr>");
    //        }
    //        html.Append("</tbody>");
    //    }

    //    html.Append("</table>");

    //    return html.ToString();
    //}

}