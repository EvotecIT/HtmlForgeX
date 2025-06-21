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
        }
    }
}
