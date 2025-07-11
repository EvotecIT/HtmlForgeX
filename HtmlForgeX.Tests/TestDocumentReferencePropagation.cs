using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestDocumentReferencePropagation
{
    [TestMethod]
    public void Element_Add_ShouldPropagate_DocumentReference()
    {
        // Arrange
        var document = new Document(LibraryMode.Online);
        var parentElement = new TablerPage();
        var childElement = new TablerCard();

        // Act
        document.Body.Add(parentElement);
        parentElement.Add(childElement);

        // Assert
        Assert.IsNotNull(parentElement.Document, "Parent element should have Document reference");
        Assert.IsNotNull(childElement.Document, "Child element should have Document reference");
        Assert.AreSame(document, parentElement.Document, "Parent should reference the correct Document");
        Assert.AreSame(document, childElement.Document, "Child should reference the correct Document");
    }

    [TestMethod]
    public void Element_Add_ShouldPropagate_EmailReference()
    {
        // Arrange
        var email = new Email();
        var parentElement = new EmailBox();
        var childElement = new EmailText();

        // Act
        email.Body.Add(parentElement);
        parentElement.Add(childElement);

        // Assert
        Assert.IsNotNull(parentElement.Email, "Parent element should have Email reference");
        Assert.IsNotNull(childElement.Email, "Child element should have Email reference");
        Assert.AreSame(email, parentElement.Email, "Parent should reference the correct Email");
        Assert.AreSame(email, childElement.Email, "Child should reference the correct Email");
    }

    [TestMethod]
    public void DeepNesting_ShouldPropagate_DocumentReference()
    {
        // Arrange
        var document = new Document(LibraryMode.Online);
        var page = new TablerPage();
        var row = new TablerRow();
        var column = new TablerColumn();
        var card = new TablerCard();

        // Act - Create deep nesting
        document.Body.Add(page);
        page.Add(row);
        row.Add(column);
        column.Add(card);

        // Assert
        Assert.AreSame(document, page.Document, "Page should reference Document");
        Assert.AreSame(document, row.Document, "Row should reference Document");
        Assert.AreSame(document, column.Document, "Column should reference Document");
        Assert.AreSame(document, card.Document, "Card should reference Document");
    }

    [TestMethod]
    public void FluentAPI_ShouldPropagate_DocumentReference()
    {
        // Arrange
        var document = new Document(LibraryMode.Online);
        var data = new[] { new { Name = "Test", Value = 123 } };

        // Act - Use fluent API like in examples
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(TablerColumnNumber.Twelve, column => {
                    column.Card(card => {
                        card.Table(data, TableType.DataTables);
                    });
                });
            });
        });

        // Assert - Generate HTML to trigger library registration
        var htmlOutput = document.ToString();

        // Verify libraries were registered (proving Document reference worked)
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Bootstrap),
            "Bootstrap should be registered via Document reference");
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Tabler),
            "Tabler should be registered via Document reference");
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.DataTables),
            "DataTables should be registered via Document reference");

        // Verify HTML contains library references
        Assert.IsTrue(htmlOutput.Contains("bootstrap"), "HTML should contain Bootstrap");
        Assert.IsTrue(htmlOutput.Contains("tabler"), "HTML should contain Tabler");
        Assert.IsTrue(htmlOutput.Contains("dataTables"), "HTML should contain DataTables");
    }

    [TestMethod]
    public void Element_WithoutDocumentReference_ShouldNotRegisterLibraries()
    {
        // Arrange
        var page = new TablerPage();
        var card = new TablerCard();

        // Act - Add without Document reference (simulating the bug)
        page.Add(card);

        // Assert - Since there's no Document reference, libraries shouldn't be registered
        Assert.IsNull(page.Document, "Page should not have Document reference");
        Assert.IsNull(card.Document, "Card should not have Document reference");

        // Create a document separately to test
        var document = new Document(LibraryMode.Online);

        // Libraries should not be registered in this document
        Assert.IsFalse(document.Configuration.Libraries.ContainsKey(Libraries.Bootstrap),
            "Bootstrap should not be registered without Document reference");
        Assert.IsFalse(document.Configuration.Libraries.ContainsKey(Libraries.Tabler),
            "Tabler should not be registered without Document reference");
    }

    [TestMethod]
    public void RegressionTest_BasicHtmlContainer01_ShouldWork()
    {
        // Arrange - Simulate the exact scenario from BasicHtmlContainer01
        var document = new Document {
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        var data = new[] {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
            new { Name = "Bob", Age = 35, Occupation = "Architect" }
        };

        // Act - Recreate the exact structure that was failing
        document.Body.Table(data, TableType.Tabler);

        var page = new TablerPage()
            .Add(new TablerRow()
                .Add(new TablerColumn().WithClass("col-6")
                    .Add(new TablerCard().Content("Card 1").Style("background-color: red;"))
                    .Add(new TablerCard().Content("Card 2").Style("background-color: blue;"))
                )
                .Add(new TablerColumn().WithClass("col-6")
                    .Add(new TablerCard().Content("Card 3").Style("background-color: green;"))
                    .Add(new TablerCard().Table(data, TableType.DataTables))
                )
            );

        document.Body.Add(page);
        var htmlOutput = document.ToString();

        // Assert - This should now work correctly
        Assert.IsTrue(htmlOutput.Contains("<!DOCTYPE html>"), "Should generate valid HTML");
        Assert.IsTrue(htmlOutput.Contains("<head>"), "Should have head section");
        Assert.IsTrue(htmlOutput.Contains("bootstrap.min.css"), "Should include Bootstrap CSS");
        Assert.IsTrue(htmlOutput.Contains("tabler.min.css"), "Should include Tabler CSS");
        Assert.IsTrue(htmlOutput.Contains("jquery.min.js"), "Should include jQuery");
        Assert.IsTrue(htmlOutput.Contains("dataTables.min.js"), "Should include DataTables JS");

        // Verify structure
        Assert.IsTrue(htmlOutput.Contains("page-wrapper"), "Should have Tabler page structure");
        Assert.IsTrue(htmlOutput.Contains("card-body"), "Should have card components");
        Assert.IsTrue(htmlOutput.Contains("col-6"), "Should have column classes");
        Assert.IsTrue(htmlOutput.Contains("DataTable"), "Should have DataTables initialization");

        // Verify it's not the broken version (just plain text)
        Assert.IsTrue(htmlOutput.Length > 2000,
            $"HTML should be substantial with all libraries, got {htmlOutput.Length} characters");

        // Count library references to ensure all are included
        var bootstrapCount = CountOccurrences(htmlOutput, "bootstrap");
        var tablerCount = CountOccurrences(htmlOutput, "tabler");
        var jqueryCount = CountOccurrences(htmlOutput, "jquery");
        var dataTablesCount = CountOccurrences(htmlOutput, "dataTables");

        Assert.IsTrue(bootstrapCount >= 2, $"Should have multiple Bootstrap references, got {bootstrapCount}");
        Assert.IsTrue(tablerCount >= 2, $"Should have multiple Tabler references, got {tablerCount}");
        Assert.IsTrue(jqueryCount >= 1, $"Should have jQuery reference, got {jqueryCount}");
        Assert.IsTrue(dataTablesCount >= 2, $"Should have multiple DataTables references, got {dataTablesCount}");
    }

    private static int CountOccurrences(string text, string pattern)
    {
        int count = 0;
        int index = 0;
        while ((index = text.IndexOf(pattern, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            count++;
            index += pattern.Length;
        }
        return count;
    }
}