namespace HtmlForgeX.Tests;

[TestClass]
public class TestIdGeneration {
    [TestMethod]
    public void GenerateRandomIdIsUnique() {
        const int iterations = 1000;
        var ids = new HashSet<string>();

        for (var i = 0; i < iterations; i++) {
            var table = new DataTablesTable();
            Assert.IsTrue(ids.Add(table.Id), $"Duplicate id generated: {table.Id}");
            Assert.AreEqual("table-".Length + 8, table.Id.Length);
        }
    }

    [TestMethod]
    public void GenerateRandomIdCustomLength() {
        var globalStorage = typeof(DataTablesTable).Assembly.GetType("HtmlForgeX.GlobalStorage")!;
        var method = globalStorage.GetMethod("GenerateRandomId", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)!;
        var id = (string)method.Invoke(null, new object?[] { "test", 5 })!;
        Assert.AreEqual("test-".Length + 5, id.Length);
    }
}
