using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Provides functionality for generating HTML tables and populating them from
/// model data.
/// </summary>
public class Table : Element {
    private readonly TableType? Library;
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new();
    /// <summary>Collection of table headers.</summary>
    public List<string> TableHeaders { get; set; } = new List<string>();

    /// <summary>Collection of table footers.</summary>
    public List<string> TableFooters { get; set; } = new List<string>();

    /// <summary>Collection of table rows.</summary>
    public List<List<string>> TableRows { get; set; } = new List<List<string>>();

    private static PropertyInfo[] GetCachedProperties(Type type) {
        return PropertyCache.GetOrAdd(type, t => t.GetProperties());
    }

    private static PropertyInfo? GetCachedProperty(Type type, string name) {
        return Array.Find(GetCachedProperties(type), p => p.Name == name);
    }

    /// <summary>
    /// Initializes a new empty table instance.
    /// </summary>
    /// <param name="library">Optional table style library.</param>
    public Table(TableType? library = null) {
        Library = library;
        // Libraries will be registered via RegisterLibraries method
    }

    /// <summary>
    /// Initializes a table from the provided objects.
    /// </summary>
    /// <param name="objects">Objects representing each row.</param>
    /// <param name="library">Optional table style library.</param>
    public Table(IEnumerable<object> objects, TableType? library = null) {
        Library = library;
        // Libraries will be registered via RegisterLibraries method

        this.AddObjects(objects);
    }

    /// <summary>
    /// Registers the required libraries for Table based on its TableType.
    /// </summary>
    protected internal override void RegisterLibraries() {
        AddLibrariesBasedOnTableType();
    }

    /// <summary>
    /// Adds a table header cell.
    /// </summary>
    /// <param name="header">Header text.</param>
    /// <returns>The current table.</returns>
    public Table AddHeader(string header) {
        TableHeaders.Add(header);
        return this;
    }
    /// <summary>
    /// Adds multiple header cells.
    /// </summary>
    public Table AddHeaders(params string[] headers) {
        TableHeaders.AddRange(headers);
        return this;
    }

    /// <summary>
    /// Adds a table footer cell.
    /// </summary>
    public Table AddFooter(string footer) {
        TableFooters.Add(footer);
        return this;
    }

    /// <summary>
    /// Adds multiple footer cells.
    /// </summary>
    public Table AddFooters(params string[] footers) {
        TableFooters.AddRange(footers);
        return this;
    }

    /// <summary>
    /// Adds a row consisting of cell strings.
    /// </summary>
    public Table AddRow(List<string> row) {
        TableRows.Add(row);
        return this;
    }

    /// <summary>
    /// Adds multiple table rows.
    /// </summary>
    public Table AddRows(params List<string>[] rows) {
        TableRows.AddRange(rows);
        return this;
    }

    /// <summary>
    /// Adds rows to the table using public properties of the supplied objects.
    /// </summary>
    /// <param name="objects">Collection of objects to read values from.</param>
    /// <param name="addFooter">When true, footer cells are generated from property names.</param>
    /// <returns>The current table instance.</returns>
    public Table AddObjects(IEnumerable<object> objects, bool addFooter = false) {
        if (objects == null || !objects.Any()) return this;

        var firstObject = objects.FirstOrDefault();

        if (firstObject == null) {
            // Handle the case where the first object is null
            return this;
        }

        if (firstObject is IEnumerable enumerable && firstObject is not string && firstObject is not IDictionary) {
            var flattened = new List<object>();
            foreach (var obj in objects.WhereNotNull()) {
                if (obj is IEnumerable inner && obj is not string && obj is not IDictionary) {
                    foreach (var innerItem in inner) {
                        flattened.Add(innerItem!);
                    }
                } else {
                    flattened.Add(obj);
                }
            }
            return AddObjects(flattened, addFooter);
        }

        if (firstObject is IDictionary<string, object>) {
            AddDictionaryObjects(objects.Cast<IDictionary<string, object>>(), addFooter);
        } else if (IsStandardObject(firstObject)) {
            AddStandardObjects(objects, addFooter);
        } else {
            AddPsObjectLike(objects, addFooter);
        }

        return this;
    }

    private bool IsStandardObject(object obj) {
        var type = obj.GetType();
        return type.IsClass && !type.IsPrimitive && !type.IsValueType && type != typeof(string) && !IsDynamicObject(type);
    }

    private bool IsDynamicObject(Type type) {
        return GetCachedProperty(type, "Members") != null || GetCachedProperty(type, "Properties") != null ||
               type.GetInterfaces().Any(i => i == typeof(System.Dynamic.IDynamicMetaObjectProvider));
    }


    private void AddStandardObjects(IEnumerable<object> objects, bool addFooter) {
        var type = objects.First().GetType();
        var properties = GetCachedProperties(type);

        // Add the headers
        foreach (var property in properties) {
            AddHeader(property.Name);
        }

        // Add the rows
        foreach (var obj in objects.WhereNotNull()) {
            var row = new List<string>();
            foreach (var property in properties) {
                try {
                    var value = property.GetValue(obj);
                    row.Add(value?.ToString() ?? "");
                } catch (Exception ex) {
                    Document?.Configuration.Errors.Add($"Error getting value for property {property.Name}: {ex.Message}");
                    row.Add("");
                }
            }
            AddRow(row);
        }

        if (addFooter) {
            // Add the footers
            foreach (var property in properties) {
                AddFooter(property.Name);
            }
        }
    }

    private void AddDictionaryObjects(IEnumerable<IDictionary<string, object>> dictObjects, bool addFooter) {
        // Add the headers
        foreach (var key in dictObjects.First().Keys) {
            AddHeader(key);
        }

        // Add the rows
        foreach (var dict in dictObjects) {
            var row = new List<string>();
            foreach (var key in dict.Keys) {
                try {
                    var value = dict[key];
                    row.Add(value?.ToString() ?? "");
                } catch (Exception ex) {
                    Document?.Configuration.Errors.Add($"Error getting value for key {key}: {ex.Message}");
                    row.Add("");
                }
            }
            AddRow(row);
        }

        if (addFooter) {
            // Add the footers
            foreach (var key in dictObjects.First().Keys) {
                AddFooter(key);
            }
        }
    }
    private bool IsPsObjectLike(object obj) {
        var type = obj.GetType();

        // Check for properties typically present in a PSObject
        return GetCachedProperty(type, "Properties") != null &&
               GetCachedProperty(type, "Members") != null;
    }

    private void AddPsObjectLike(IEnumerable<object> objects, bool addFooter) {
        var firstObject = objects.First();

        if (IsPsObjectLike(firstObject)) {
            var properties = GetPsObjectProperties(firstObject);

            // Add the headers
            foreach (var property in properties) {
                AddHeader(property.Key);
            }

            // Add the rows
            foreach (var obj in objects.WhereNotNull()) {
                var row = new List<string>();
                foreach (var property in GetPsObjectProperties(obj)) {
                    row.Add(property.Value?.ToString() ?? "");
                }
                AddRow(row);
            }

            if (addFooter) {
                // Add the footers
                foreach (var property in properties) {
                    AddFooter(property.Key);
                }
            }
        }
    }

    private IDictionary<string, object> GetPsObjectProperties(object psObject) {
        var properties = new Dictionary<string, object>();

        var propertiesProperty = GetCachedProperty(psObject.GetType(), "Properties");
        if (propertiesProperty != null) {
            var propertiesValue = propertiesProperty.GetValue(psObject);
            var enumerable = propertiesValue as IEnumerable;

            if (enumerable != null) {
                foreach (var item in enumerable.Cast<object?>().WhereNotNull()) {
                    var nameProperty = GetCachedProperty(item!.GetType(), "Name");
                    var valueProperty = GetCachedProperty(item!.GetType(), "Value");

                    if (nameProperty != null && valueProperty != null) {
                        var name = nameProperty.GetValue(item)?.ToString();
                        var value = valueProperty.GetValue(item);
                        if (name != null) {
                            properties[name] = value!;
                        }
                    }
                }
            }
        }

        return properties;
    }





    /// <summary>
    /// Returns the generated HTML table markup.
    /// </summary>
    /// <returns>HTML markup for the table.</returns>
    public override string ToString() {
        return BuildTable();
    }

    /// <summary>
    /// Builds the table markup using the configured headers, rows and footers.
    /// </summary>
    /// <returns>HTML markup for the table.</returns>
    public virtual string BuildTable() {
        var html = StringBuilderCache.Acquire();
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

        // Add table footers
        if (TableFooters.Count > 0) {
            html.Append("<tfoot><tr>");
            foreach (var footer in TableFooters) {
                html.Append($"<td>{footer}</td>");
            }
            html.Append("</tr></tfoot>");
        }

        return StringBuilderCache.GetStringAndRelease(html);
    }

    /// <summary>
    /// Creates a table instance using the specified objects and table type.
    /// </summary>
    /// <param name="objects">Source objects to populate the table.</param>
    /// <param name="tableType">Desired table style.</param>
    /// <returns>Concrete <see cref="Table"/> implementation.</returns>
    public static Table Create(IEnumerable<object> objects, TableType tableType) {
        Table table;
        switch (tableType) {
            case TableType.BootstrapTable:
                table = new BootstrapTable(objects, tableType);
                break;
            case TableType.DataTables:
                table = new DataTablesTable(objects, tableType);
                break;
            case TableType.Tabler:
                table = new TablerTable(objects, tableType);
                break;
            default:
                throw new Exception("Table type not supported");
        }
        return table;
    }

    /// <summary>
    /// Creates a table from a single object or collection.
    /// </summary>
    /// <param name="obj">Object or collection to convert.</param>
    /// <param name="tableType">Desired table style.</param>
    /// <returns>Concrete <see cref="Table"/> implementation.</returns>
    public static Table Create(object obj, TableType tableType) {
        if (obj is IEnumerable enumerable && obj is not string && obj is not IDictionary) {
            return Create(enumerable.Cast<object>(), tableType);
        }

        return Create(new[] { obj }, tableType);
    }

    private void AddLibrariesBasedOnTableType() {
        if (Library.HasValue) {
            switch (Library.Value) {
                case TableType.BootstrapTable:
                    Document?.AddLibrary(Libraries.Bootstrap);
                    break;
                case TableType.DataTables:
                    Document?.AddLibrary(Libraries.Bootstrap);
                    Document?.AddLibrary(Libraries.JQuery);
                    Document?.AddLibrary(Libraries.DataTables);
                    break;
                case TableType.Tabler:
                    Document?.AddLibrary(Libraries.Bootstrap);
                    Document?.AddLibrary(Libraries.Tabler);
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