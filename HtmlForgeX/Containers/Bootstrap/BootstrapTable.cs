using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

/// <summary>
/// Renders an HTML table styled using Bootstrap classes. Provides convenience
/// properties for applying Bootstrap table utilities.
/// </summary>
public class BootstrapTable : Table {
    /// <summary>
    /// Gets the unique identifier of the table element.
    /// </summary>
    public string Id;

    /// <summary>
    /// Gets the collection of styles applied to the table.
    /// </summary>
    public List<BootStrapTableStyle> StyleList { get; set; } = new List<BootStrapTableStyle>();

    /// <summary>
    /// Initializes a new instance of the <see cref="BootstrapTable"/> class.
    /// </summary>
    public BootstrapTable() : base() {
        Id = GlobalStorage.GenerateRandomId("table");
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BootstrapTable"/> class with data.
    /// </summary>
    /// <param name="objects">Objects to render.</param>
    /// <param name="library">Table type library.</param>
    public BootstrapTable(IEnumerable<object> objects, TableType library) : base(objects, library) {
        Id = GlobalStorage.GenerateRandomId("table");
    }

    /// <summary>
    /// Builds the HTML table markup.
    /// </summary>
    /// <returns>The generated HTML.</returns>
    public override string BuildTable() {
        string tableInside = base.BuildTable();
        string classNames = StyleList.BuildTableStyles();
        var tableTag = new HtmlTag("table")
            .Id(Id)
            .Class(classNames)
            .Value(tableInside);
        return tableTag.ToString();
    }

    /// <summary>
    /// Adds a style to the table.
    /// </summary>
    /// <param name="style">Style to apply.</param>
    /// <returns>The current <see cref="BootstrapTable"/> instance.</returns>
    public BootstrapTable Style(BootStrapTableStyle style) {
        StyleList.Add(style);
        return this;
    }
}
