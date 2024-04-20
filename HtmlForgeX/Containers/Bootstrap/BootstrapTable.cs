using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlForgeX;

public class BootstrapTable : Table {
    public string Id;
    public List<BootStrapTableStyle> StyleList { get; set; } = new List<BootStrapTableStyle>();

    public BootstrapTable() : base() {
        Id = GlobalStorage.GenerateRandomId("table");
    }

    public BootstrapTable(IEnumerable<object> objects, TableType library) : base(objects, library) {
        Id = GlobalStorage.GenerateRandomId("table");
    }

    public override string BuildTable() {
        string tableInside = base.BuildTable();
        string classNames = StyleList.BuildTableStyles();
        var tableTag = new HtmlTag("table")
            .Id(Id)
            .Class(classNames)
            .SetValue(tableInside);
        return tableTag.ToString();
    }

    public BootstrapTable Style(BootStrapTableStyle style) {
        StyleList.Add(style);
        return this;
    }
}
