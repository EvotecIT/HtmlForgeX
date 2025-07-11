using HtmlForgeX;


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
            Assert.AreEqual("table-".Length + IdGenerator.DefaultRandomIdLength, table.Id.Length);
        }
    }

    [TestMethod]
    public void GenerateRandomIdCustomLength() {
        var id = GlobalStorage.GenerateRandomId("test", 5);
        Assert.AreEqual("test-".Length + 5, id.Length);
    }

    [TestMethod]
    public void GenerateRandomIdInvalidInput() {
        Assert.ThrowsException<ArgumentException>(() => GlobalStorage.GenerateRandomId(null!, 5));
        Assert.ThrowsException<ArgumentException>(() => GlobalStorage.GenerateRandomId(" ", 5));
    }
}