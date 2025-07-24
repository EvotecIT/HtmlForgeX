namespace HtmlForgeX.Examples.Tables;

internal class DataTablesTypedObjectsExample {
    private class Employee {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Occupation { get; set; } = string.Empty;
    }

    public static void Create(bool openInBrowser = false) {
        HelpersSpectre.PrintTitle("Typed Objects Table Demo");

        using var document = new Document {
            Head = {
                Title = "Typed Objects Table Demo",
                Author = "Przemysław Kłys",
                Revised = DateTime.Now,
                Description = "Demonstrates table generation from various object types",
                Keywords = "table, typed, objects",
                Charset = "utf-8"
            }
        };

        // Build table from typed objects
        var employees = new List<Employee> {
            new Employee { Name = "Alice", Age = 25, Occupation = "Developer" },
            new Employee { Name = "Frank", Age = 32, Occupation = "Designer" },
            new Employee { Name = "Grace", Age = 29, Occupation = "Analyst" }
        };

        var employeeTable = (DataTablesTable)document.Body.Table(employees, TableType.DataTables);
        employeeTable.Configure(o => o.PageLength = 5);

        // Build table from dictionary objects
        var dictionaryData = new List<Dictionary<string, object>> {
            new() { ["Key"] = "One", ["Value"] = 1 },
            new() { ["Key"] = "Two", ["Value"] = 2 },
            new() { ["Key"] = "Three", ["Value"] = 3 }
        };

        document.Body.Table(dictionaryData, TableType.Tabler);

        // Build table from dynamic objects
        var data = new List<dynamic> {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
            new { Name = "Bob", Age = 35, Occupation = "Architect" }
        };

        document.Body.Table(data, TableType.BootstrapTable);

        document.Save("DataTablesTypedObjectsExample.html", openInBrowser);
    }
}