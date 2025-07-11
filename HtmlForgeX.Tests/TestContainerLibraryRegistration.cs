using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestContainerLibraryRegistration
{
    [TestMethod]
    public void TablerPage_ShouldRegisterBootstrapAndTablerLibraries()
    {
        // Arrange
        var document = new Document(LibraryMode.Online);
        var page = new TablerPage();

        // Act
        document.Body.Add(page);
        var htmlOutput = document.ToString();

        // Assert
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Bootstrap),
            "TablerPage should register Bootstrap library");
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Tabler),
            "TablerPage should register Tabler library");

        // Verify HTML includes the libraries
        Assert.IsTrue(htmlOutput.Contains("bootstrap"),
            "HTML should contain Bootstrap library reference");
        Assert.IsTrue(htmlOutput.Contains("tabler"),
            "HTML should contain Tabler library reference");
    }

    [TestMethod]
    public void DataTablesTable_ShouldRegisterRequiredLibraries()
    {
        // Arrange
        var document = new Document(LibraryMode.Online);
        var data = new[] {
            new { Name = "John", Age = 30 },
            new { Name = "Jane", Age = 28 }
        };

        // Act
        document.Body.Table(data, TableType.DataTables);
        var htmlOutput = document.ToString();

        // Assert
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Bootstrap),
            "DataTables should register Bootstrap library");
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.JQuery),
            "DataTables should register jQuery library");
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.DataTables),
            "DataTables should register DataTables library");

        // Verify HTML includes the libraries
        Assert.IsTrue(htmlOutput.Contains("jquery"),
            "HTML should contain jQuery library reference");
        Assert.IsTrue(htmlOutput.Contains("dataTables"),
            "HTML should contain DataTables library reference");
    }

    [TestMethod]
    public void TablerTable_ShouldRegisterBootstrapAndTablerLibraries()
    {
        // Arrange
        var document = new Document(LibraryMode.Online);
        var data = new[] {
            new { Name = "John", Age = 30 },
            new { Name = "Jane", Age = 28 }
        };

        // Act
        document.Body.Table(data, TableType.Tabler);
        var htmlOutput = document.ToString();

        // Assert
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Bootstrap),
            "Tabler table should register Bootstrap library");
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Tabler),
            "Tabler table should register Tabler library");

        // Verify HTML includes the libraries
        Assert.IsTrue(htmlOutput.Contains("bootstrap"),
            "HTML should contain Bootstrap library reference");
        Assert.IsTrue(htmlOutput.Contains("tabler"),
            "HTML should contain Tabler library reference");
    }

    [TestMethod]
    public void DocumentReference_ShouldPropagate_ToChildElements()
    {
        // Arrange
        var document = new Document(LibraryMode.Online);
        var page = new TablerPage();
        var card = new TablerCard();

        // Act
        document.Body.Add(page);
        page.Add(card);

        // Assert
        Assert.IsNotNull(page.Document, "TablerPage should have Document reference");
        Assert.IsNotNull(card.Document, "TablerCard should have Document reference");
        Assert.AreSame(document, page.Document, "TablerPage should reference the same Document");
        Assert.AreSame(document, card.Document, "TablerCard should reference the same Document");
    }

    [TestMethod]
    public void NestedComponents_ShouldAllRegisterLibraries()
    {
        // Arrange
        var document = new Document(LibraryMode.Online);
        var data = new[] {
            new { Name = "John", Age = 30 },
            new { Name = "Jane", Age = 28 }
        };

        // Act - Create nested structure like in BasicHtmlContainer01
        document.Body.Page(page => {
            page.Row(row => {
                row.Column(TablerColumnNumber.Six, column => {
                    column.Card(card => {
                        card.Table(data, TableType.DataTables);
                    });
                });
            });
        });

        var htmlOutput = document.ToString();

        // Assert - All required libraries should be registered
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Bootstrap),
            "Nested components should register Bootstrap library");
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Tabler),
            "Nested components should register Tabler library");
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.JQuery),
            "Nested components should register jQuery library");
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.DataTables),
            "Nested components should register DataTables library");

        // Verify HTML structure and libraries
        Assert.IsTrue(htmlOutput.Contains("page-wrapper"),
            "HTML should contain Tabler page structure");
        Assert.IsTrue(htmlOutput.Contains("card"),
            "HTML should contain card structure");
        Assert.IsTrue(htmlOutput.Contains("DataTable"),
            "HTML should contain DataTables initialization");
        Assert.IsTrue(htmlOutput.Contains("jquery"),
            "HTML should contain jQuery library");
        Assert.IsTrue(htmlOutput.Contains("bootstrap"),
            "HTML should contain Bootstrap library");
        Assert.IsTrue(htmlOutput.Contains("tabler"),
            "HTML should contain Tabler library");
    }

    [TestMethod]
    public void LibraryMode_Offline_ShouldIncludeInlineStyles()
    {
        // Arrange
        var document = new Document(LibraryMode.Offline);
        var page = new TablerPage();

        // Act
        document.Body.Add(page);
        var htmlOutput = document.ToString();

        // Assert
        Assert.IsTrue(htmlOutput.Contains("<style>"),
            "Offline mode should include inline styles");
        Assert.IsFalse(htmlOutput.Contains("cdn.jsdelivr.net"),
            "Offline mode should not include CDN links");
    }

    [TestMethod]
    public void LibraryMode_Online_ShouldIncludeCDNLinks()
    {
        // Arrange
        var document = new Document(LibraryMode.Online);
        var page = new TablerPage();

        // Act
        document.Body.Add(page);
        var htmlOutput = document.ToString();

        // Assert
        Assert.IsTrue(htmlOutput.Contains("cdn.jsdelivr.net"),
            "Online mode should include CDN links");
        Assert.IsTrue(htmlOutput.Contains("<link rel=\"stylesheet\""),
            "Online mode should include CSS link tags");
        Assert.IsTrue(htmlOutput.Contains("<script src="),
            "Online mode should include script tags with src");
    }

    [TestMethod]
    public void Document_WithOfflineLibraryMode_ShouldNotIncludeLibraries()
    {
        // Arrange
        var document = new Document();
        document.LibraryMode = LibraryMode.Offline; // Explicitly set offline mode
        var page = new TablerPage();

        // Act
        document.Body.Add(page);
        var htmlOutput = document.ToString();

        // Assert
        // Libraries should still be registered in configuration
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Bootstrap),
            "Libraries should be registered even in offline mode");

        // Offline mode should not include external CDN references
        Assert.IsFalse(htmlOutput.Contains("cdn.jsdelivr.net") || htmlOutput.Contains("unpkg.com"),
            "HTML should not contain external CDN references in offline mode");
    }

    [TestMethod]
    public void ComplexContainerExample_ShouldWorkCorrectly()
    {
        // Arrange
        var document = new Document {
            LibraryMode = LibraryMode.Online,
            ThemeMode = ThemeMode.Light
        };

        var data = new[] {
            new { Name = "John", Age = 30, Occupation = "Engineer" },
            new { Name = "Jane", Age = 28, Occupation = "Doctor" },
            new { Name = "Bob", Age = 35, Occupation = "Architect" }
        };

        // Act - Recreate the BasicHtmlContainer01 structure
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

        // Assert
        Assert.IsTrue(document.Configuration.Libraries.Count >= 4,
            $"Should register at least 4 libraries, but got {document.Configuration.Libraries.Count}");

        // Verify specific libraries
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Bootstrap));
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.Tabler));
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.JQuery));
        Assert.IsTrue(document.Configuration.Libraries.ContainsKey(Libraries.DataTables));

        // Verify HTML structure
        Assert.IsTrue(htmlOutput.Contains("page-wrapper"));
        Assert.IsTrue(htmlOutput.Contains("card-body"));
        Assert.IsTrue(htmlOutput.Contains("col-6"));
        Assert.IsTrue(htmlOutput.Contains("DataTable"));

        // Verify library includes
        Assert.IsTrue(htmlOutput.Contains("bootstrap.min.css"));
        Assert.IsTrue(htmlOutput.Contains("tabler.min.css"));
        Assert.IsTrue(htmlOutput.Contains("jquery.min.js"));
        Assert.IsTrue(htmlOutput.Contains("dataTables.min.js"));

        // Verify the HTML is substantial (not just empty structure)
        Assert.IsTrue(htmlOutput.Length > 1000,
            $"Generated HTML should be substantial, but was only {htmlOutput.Length} characters");
    }
}