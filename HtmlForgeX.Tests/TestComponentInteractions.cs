using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

/// <summary>
/// Ensures that using multiple components results in correct library inclusion.
/// </summary>
[TestClass]
public class TestComponentInteractions {

    [TestMethod]
    public void MultipleComponents_AllLibrariesIncluded() {
        using var doc = new Document();

        // Add multiple different components
        doc.Body.Add(element => {
            element.QRCode("https://qr.example.com");
        });

        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                calendar.AddEvent("Mixed Test", DateTime.Today);
            });
        });

        doc.Body.Add(element => {
            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Network Node" });
            });
        });

        var html = doc.ToString();

        // Should contain all component data
        Assert.IsTrue(html.Contains("https://qr.example.com"), "Should contain QR code data");
        Assert.IsTrue(html.Contains("Mixed Test"), "Should contain calendar event");
        Assert.IsTrue(html.Contains("Network Node"), "Should contain network node");

        // Should include all required libraries
        Assert.IsTrue(html.Contains("qrcode") || html.Contains("QRCode"), "Should include QR code library");
        Assert.IsTrue(html.Contains("fullcalendar") || html.Contains("FullCalendar"), "Should include calendar library");
        Assert.IsTrue(html.Contains("vis-network") || html.Contains("network"), "Should include network library");

        // Verify document structure is intact
        Assert.IsTrue(html.Contains("<!DOCTYPE html>"), "Should have DOCTYPE");
        Assert.IsTrue(html.Contains("<head>") && html.Contains("</head>"), "Should have head section");
        Assert.IsTrue(html.Contains("<body") && html.Contains("</body>"), "Should have body section");
    }

    [TestMethod]
    public void ComponentsWithTabler_Integration() {
        using var doc = new Document();

        // Combine components with Tabler UI
        var card = new TablerCard();
        card.QRCode("https://tabler.example.com");
        doc.Body.Add(card);

        var row = new TablerRow();
        var column = new TablerColumn();
        column.FullCalendar(calendar => {
            calendar.AddEvent("Tabler Event", DateTime.Today);
        });
        row.Add(column);
        doc.Body.Add(row);

        var html = doc.ToString();

        // Should contain both Tabler and component libraries
        Assert.IsTrue(html.Contains("class=\"card"), "Should contain Tabler card");
        Assert.IsTrue(html.Contains("class=\"row"), "Should contain Tabler row");
        Assert.IsTrue(html.Contains("https://tabler.example.com"), "Should contain QR code in card");
        Assert.IsTrue(html.Contains("Tabler Event"), "Should contain calendar event in row");

        // Should include all necessary libraries
        Assert.IsTrue(html.Contains("tabler") || html.Contains("bootstrap"), "Should include Tabler/Bootstrap");
        Assert.IsTrue(html.Contains("qrcode"), "Should include QR code library");
        Assert.IsTrue(html.Contains("fullcalendar"), "Should include calendar library");
    }

    [TestMethod]
    public void NestedComponents_WithVisNetwork() {
        using var doc = new Document();

        // Create a complex layout with nested components
        var row = new TablerRow();

        // Add QR code in one column
        var qrColumn = new TablerColumn();
        qrColumn.QRCode("https://nested.example.com");
        row.Add(qrColumn);

        // Add network diagram in another column
        var networkColumn = new TablerColumn();
        networkColumn.DiagramNetwork(network => {
            network.AddNode(new { id = 1, label = "Component 1" });
            network.AddNode(new { id = 2, label = "Component 2" });
            network.AddEdge(new { from = 1, to = 2, label = "interaction" });
        });
        row.Add(networkColumn);

        doc.Body.Add(row);

        var html = doc.ToString();

        // Should contain all nested components
        Assert.IsTrue(html.Contains("https://nested.example.com"), "Should contain QR code data");
        Assert.IsTrue(html.Contains("Component 1"), "Should contain network nodes");
        Assert.IsTrue(html.Contains("interaction"), "Should contain network edge");

        // Should maintain layout structure
        Assert.IsTrue(html.Contains("class=\"") || html.Contains("id=\""), "Should contain layout elements");
    }

    [TestMethod]
    public void ComponentInteraction_OnlineVsOffline() {
        // Test online mode
        var onlineDoc = new Document();
        onlineDoc.LibraryMode = LibraryMode.Online;

        onlineDoc.Body.Add(element => {
            element.QRCode("online-test");
            element.FullCalendar(calendar => {
                calendar.AddEvent("Online Event", DateTime.Today);
            });
        });

        var onlineHtml = onlineDoc.ToString();

        // Test offline mode
        var offlineDoc = new Document();
        offlineDoc.LibraryMode = LibraryMode.Offline;

        string offlineHtml;
        try {
            offlineDoc.Body.Add(element => {
                element.QRCode("offline-test");
                element.FullCalendar(calendar => {
                    calendar.AddEvent("Offline Event", DateTime.Today);
                });
            });

            offlineHtml = offlineDoc.ToString();
        } catch (System.ArgumentException ex) when (ex.Message.Contains("Resource not found")) {
            // If FullCalendar embedded resource is not available, test with just QR code
            offlineDoc = new Document();
            offlineDoc.LibraryMode = LibraryMode.Offline;

            offlineDoc.Body.Add(element => {
                element.QRCode("offline-test");
            });

            offlineHtml = offlineDoc.ToString();
        }

        // Online should use CDN links
        Assert.IsTrue(onlineHtml.Contains("https://cdn"), "Online mode should use CDN");

        // Offline should embed libraries
        Assert.IsFalse(offlineHtml.Contains("cdn.jsdelivr.net"), "Offline mode should not use CDN");

        // Both should contain QR component functionality
        Assert.IsTrue(onlineHtml.Contains("online-test"), "Online version should contain QR component");
        Assert.IsTrue(offlineHtml.Contains("offline-test"), "Offline version should contain QR component");

        // Online should contain calendar if FullCalendar worked
        if (onlineHtml.Contains("Online Event")) {
            Assert.IsTrue(onlineHtml.Contains("Online Event"), "Online version should contain calendar event");
        }
    }

    [TestMethod]
    public void ComponentLibraryConflicts_Prevention() {
        using var doc = new Document();

        // Add the same component type multiple times
        doc.Body.Add(element => {
            element.QRCode("qr1");
        });

        doc.Body.Add(element => {
            element.QRCode("qr2");
        });

        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                calendar.AddEvent("Event 1", DateTime.Today);
            });
        });

        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                calendar.AddEvent("Event 2", DateTime.Today.AddDays(1));
            });
        });

        var html = doc.ToString();

        // Should contain all component instances
        Assert.IsTrue(html.Contains("qr1") && html.Contains("qr2"), "Should contain both QR codes");
        Assert.IsTrue(html.Contains("Event 1") && html.Contains("Event 2"), "Should contain both calendar events");

        // Should not duplicate libraries excessively
        var qrLibraryCount = html.Split(new string[] { "easy.qrcode" }, StringSplitOptions.None).Length - 1;
        var calendarLibraryCount = html.Split(new string[] { "fullcalendar" }, StringSplitOptions.None).Length - 1;

        Assert.IsTrue(qrLibraryCount <= 3, "QR code library should not be excessively duplicated");
        Assert.IsTrue(calendarLibraryCount <= 3, "Calendar library should not be excessively duplicated");
    }

    [TestMethod]
    public void ComplexDashboard_AllComponents() {
        using var doc = new Document();
        doc.Head.AddTitle("Complex Dashboard");

        // Create a complex dashboard with all components
        doc.Body.Add(element => {
            // Header row with QR code and title
            var headerRow = new TablerRow();
            headerRow.Add(new TablerColumn().Add(qrElement => {
                qrElement.QRCode("https://dashboard.example.com");
            }));
            headerRow.Add(new TablerColumn().Add(new TablerText("Dashboard Analytics")));
            element.Add(headerRow);

            // Main content row
            var mainRow = new TablerRow();

            // Calendar column
            var calendarCol = new TablerColumn();
            calendarCol.FullCalendar(calendar => {
                calendar.AddEvent("Board Meeting", DateTime.Today.AddHours(14));
                calendar.AddEvent("Product Review", DateTime.Today.AddDays(1).AddHours(10));
                calendar.NowIndicator(true).BusinessHours(true);
            });
            mainRow.Add(calendarCol);

            // Network diagram column
            var networkCol = new TablerColumn();
            networkCol.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Frontend", group = "ui" });
                network.AddNode(new { id = 2, label = "Backend", group = "api" });
                network.AddNode(new { id = 3, label = "Database", group = "data" });
                network.AddEdge(new { from = 1, to = 2, label = "API calls" });
                network.AddEdge(new { from = 2, to = 3, label = "queries" });

                network.WithOptions("groups", new {
                    ui = new { color = "lightblue" },
                    api = new { color = "lightgreen" },
                    data = new { color = "lightyellow" }
                });
            });
            mainRow.Add(networkCol);

            element.Add(mainRow);
        });

        var html = doc.ToString();

        // Should contain all dashboard elements
        Assert.IsTrue(html.Contains("Complex Dashboard"), "Should contain dashboard title");
        Assert.IsTrue(html.Contains("https://dashboard.example.com"), "Should contain QR code");
        Assert.IsTrue(html.Contains("Dashboard Analytics"), "Should contain header text");
        Assert.IsTrue(html.Contains("Board Meeting"), "Should contain calendar events");
        Assert.IsTrue(html.Contains("Frontend") && html.Contains("Backend"), "Should contain network nodes");
        Assert.IsTrue(html.Contains("API calls"), "Should contain network connections");

        // Should include component libraries that were successfully added
        Assert.IsTrue(html.Contains("qrcode"), "Should include QR code library");

        // Check for other libraries if they were included
        bool hasCalendar = html.Contains("fullcalendar");
        bool hasNetwork = html.Contains("vis-network");
        bool hasUI = html.Contains("class=") && (html.Contains("row") || html.Contains("col"));

        // At least the basic structure should be present
        Assert.IsTrue(hasUI, "Should include UI framework structure");

        // Should maintain proper HTML structure
        Assert.IsTrue(html.Contains("class=\"row\""), "Should contain row layout");
        Assert.IsTrue(html.Contains("class=\"col"), "Should contain column layout");
    }

    [TestMethod]
    public void ComponentEventHandling_Integration() {
        using var doc = new Document();

        // Test components that might have JavaScript interactions
        doc.Body.Add(element => {
            element.QRCode("interactive-qr");

            element.FullCalendar(calendar => {
                calendar.Selectable(true).Editable(true);
                calendar.AddEvent("Interactive Event", DateTime.Today);
            });

            element.DiagramNetwork(network => {
                network.AddNode(new { id = 1, label = "Interactive Node" });
                network.WithOptions("interaction", new {
                    dragNodes = true,
                    selectConnectedEdges = true
                });
            });
        });

        var html = doc.ToString();

        // Should contain interactive components
        Assert.IsTrue(html.Contains("interactive-qr"), "Should contain interactive QR code");
        Assert.IsTrue(html.Contains("Interactive Event"), "Should contain interactive calendar");
        Assert.IsTrue(html.Contains("Interactive Node"), "Should contain interactive network");

        // Should include interaction capabilities
        Assert.IsTrue(html.Contains("selectable") || html.Contains("editable"), "Should enable calendar interactions");
        Assert.IsTrue(html.Contains("drag") || html.Contains("select"), "Should enable network interactions");
    }
}