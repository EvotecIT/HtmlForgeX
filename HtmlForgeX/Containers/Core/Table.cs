using System;
using System.Collections.Generic;
using System.Reflection;
using System.Collections.Concurrent;
using System.Collections;
using System.Text;

namespace HtmlForgeX;

public class Table : Element {
    private readonly TableType? Library;
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new();
    public List<string> TableHeaders { get; set; } = new List<string>();
    public List<string> TableFooters { get; set; } = new List<string>();
    public List<List<string>> TableRows { get; set; } = new List<List<string>>();

    private static PropertyInfo[] GetCachedProperties(Type type) {
        return PropertyCache.GetOrAdd(type, t => t.GetProperties());
    }

    private static PropertyInfo? GetCachedProperty(Type type, string name) {
        return Array.Find(GetCachedProperties(type), p => p.Name == name);
    }

    public Table(TableType? library = null) {
        Library = library;
        // Libraries will be registered via RegisterLibraries method
    }

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

    public Table AddHeader(string header) {
        TableHeaders.Add(header);
        return this;
    }
    public Table AddHeaders(params string[] headers) {
        TableHeaders.AddRange(headers);
        return this;
    }

    public Table AddFooter(string footer) {
        TableFooters.Add(footer);
        return this;
    }

    public Table AddFooters(params string[] footers) {
        TableFooters.AddRange(footers);
        return this;
    }

    public Table AddRow(List<string> row) {
        TableRows.Add(row);
        return this;
    }

    public Table AddRows(params List<string>[] rows) {
        TableRows.AddRange(rows);
        return this;
    }

    public Table AddObjects(IEnumerable<object> objects, bool addFooter = false) {
        if (objects == null || !objects.Any()) return this;

        var firstObject = objects.FirstOrDefault();

        if (firstObject == null) {
            // Handle the case where the first object is null
            return this;
        }

        if (firstObject is IEnumerable enumerable && firstObject is not string && firstObject is not IDictionary) {
            var flattened = new List<object>();
            foreach (var obj in objects) {
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
        foreach (var obj in objects) {
            var row = new List<string>();
            foreach (var property in properties) {
                try {
                    var value = property.GetValue(obj);
                    row.Add(value != null ? value.ToString() : "");
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
                    row.Add(value != null ? value.ToString() : "");
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
            foreach (var obj in objects) {
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
                foreach (var item in enumerable) {
                    var nameProperty = GetCachedProperty(item.GetType(), "Name");
                    var valueProperty = GetCachedProperty(item.GetType(), "Value");

                    if (nameProperty != null && valueProperty != null) {
                        var name = nameProperty.GetValue(item)?.ToString();
                        var value = valueProperty.GetValue(item);
                        if (name != null) {
                            properties[name] = value;
                        }
                    }
                }
            }
        }

        return properties;
    }





    public override string ToString() {
        return BuildTable();
    }

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
                    Document?.Configuration.Libraries.TryAdd(Libraries.Bootstrap, 0);
                    break;
                case TableType.DataTables:
                    Document?.Configuration.Libraries.TryAdd(Libraries.Bootstrap, 0);
                    Document?.Configuration.Libraries.TryAdd(Libraries.JQuery, 0);
                    Document?.Configuration.Libraries.TryAdd(Libraries.DataTables, 0);
                    break;
                case TableType.Tabler:
                    Document?.Configuration.Libraries.TryAdd(Libraries.Bootstrap, 0);
                    Document?.Configuration.Libraries.TryAdd(Libraries.Tabler, 0);
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