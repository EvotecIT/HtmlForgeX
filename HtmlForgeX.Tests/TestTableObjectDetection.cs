using System.Collections.Generic;
using System.Dynamic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestTableObjectDetection {
    private class CustomType {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    private class FakePsProperty {
        public string Name { get; set; } = string.Empty;
        public object? Value { get; set; }
    }

    private class FakePsObject : DynamicObject {
        public List<FakePsProperty> Properties { get; } = new();
        public List<FakePsProperty> Members => Properties;

        public void Add(string name, object? value) {
            Properties.Add(new FakePsProperty { Name = name, Value = value });
        }
    }

    [TestMethod]
    public void CreateTableFromListPassedAsObject() {
        var list = new List<CustomType> {
            new CustomType { Name = "Alice", Age = 30 },
            new CustomType { Name = "Bob", Age = 40 }
        };

        var table = HtmlForgeX.Table.Create((object)list, TableType.BootstrapTable);

        Assert.AreEqual(2, table.TableHeaders.Count);
        Assert.AreEqual(2, table.TableRows.Count);
    }

    [TestMethod]
    public void CreateTableFromFakePsObject() {
        var obj = new FakePsObject();
        obj.Add("Name", "Alice");
        obj.Add("Age", 30);

        var table = HtmlForgeX.Table.Create(obj, TableType.BootstrapTable);

        Assert.AreEqual(2, table.TableHeaders.Count);
        Assert.AreEqual(1, table.TableRows.Count);
        Assert.AreEqual("Alice", table.TableRows[0][0]);
        Assert.AreEqual("30", table.TableRows[0][1]);
    }
}