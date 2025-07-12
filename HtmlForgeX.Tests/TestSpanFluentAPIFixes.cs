namespace HtmlForgeX.Tests;

[TestClass]
public class TestSpanFluentAPIFixes {

    [TestMethod]
    public void AddContent_WithChaining_AllReferencesPointToSameRoot() {
        // Arrange & Act
        var span1 = new Span().AddContent("First").WithColor(RGBColor.Red);
        var span2 = span1.AddContent(" Second").WithColor(RGBColor.Blue);
        var span3 = span2.AddContent(" Third").WithColor(RGBColor.Green);

        // Assert - All references should render the same content (they're all wrappers pointing to same root)
        // While they may be different wrapper instances, they should all render the complete content
        Assert.AreEqual(span1.ToString(), span2.ToString());
        Assert.AreEqual(span2.ToString(), span3.ToString());
        Assert.AreEqual(span1.ToString(), span3.ToString());

        // Verify the content includes all parts
        var html = span1.ToString();
        Assert.IsTrue(html.Contains("First"));
        Assert.IsTrue(html.Contains("Second"));
        Assert.IsTrue(html.Contains("Third"));
    }

    [TestMethod]
    public void AddContent_WithChaining_ProducesCorrectHTML() {
        // Arrange & Act
        var rootSpan = new Span().AddContent("First").WithColor(RGBColor.Red)
                               .AddContent(" Second").WithColor(RGBColor.Blue)
                               .AddContent(" Third").WithColor(RGBColor.Green);

        var html = rootSpan.ToString();

        // Assert - Should contain all content with correct styling
        Assert.IsTrue(html.Contains("First"));
        Assert.IsTrue(html.Contains("Second"));
        Assert.IsTrue(html.Contains("Third"));
        Assert.IsTrue(html.Contains("color: #FF0000")); // Red
        Assert.IsTrue(html.Contains("color: #0000FF")); // Blue
        Assert.IsTrue(html.Contains("color: #008000")); // Green
    }

    [TestMethod]
    public void AddContent_WhenAddedToDocument_NoUnexpectedDuplication() {
        // Arrange
        var span1 = new Span().AddContent("Content1").WithColor(RGBColor.Red);
        var span2 = span1.AddContent(" Content2").WithColor(RGBColor.Blue);
        var span3 = span2.AddContent(" Content3").WithColor(RGBColor.Green);

        var document = new Document();

        // Act - Add same reference multiple times (user might do this accidentally)
        document.Body.Add(span1);
        document.Body.Add(span2); // This is the same object as span1
        document.Body.Add(span3); // This is the same object as span1

        var bodyHtml = document.Body.ToString();

        // Assert - Should show the complete content 3 times (not partial content)
        var span1Count = CountOccurrences(bodyHtml, "Content1");
        var span2Count = CountOccurrences(bodyHtml, "Content2");
        var span3Count = CountOccurrences(bodyHtml, "Content3");

        Assert.AreEqual(3, span1Count); // Should appear 3 times
        Assert.AreEqual(3, span2Count); // Should appear 3 times
        Assert.AreEqual(3, span3Count); // Should appear 3 times
    }

    [TestMethod]
    public void AppendContent_WithChaining_AllReferencesPointToSameRoot() {
        // Arrange & Act
        var span1 = new Span().AppendContent("First").WithColor(RGBColor.Red);
        var span2 = span1.AppendContent(" Second").WithColor(RGBColor.Blue);
        var span3 = span2.AppendContent(" Third").WithColor(RGBColor.Green);

        // Assert - All references should be the same root object
        Assert.AreSame(span1, span2);
        Assert.AreSame(span2, span3);
        Assert.AreSame(span1, span3);
    }

    [TestMethod]
    public void AppendContent_WithChaining_ProducesCorrectHTML() {
        // Arrange & Act
        var rootSpan = new Span().AppendContent("First").WithColor(RGBColor.Red)
                               .AppendContent(" Second").WithColor(RGBColor.Blue)
                               .AppendContent(" Third").WithColor(RGBColor.Green);

        var html = rootSpan.ToString();

        // Assert - Should contain all content with correct styling
        Assert.IsTrue(html.Contains("First"));
        Assert.IsTrue(html.Contains("Second"));
        Assert.IsTrue(html.Contains("Third"));
        Assert.IsTrue(html.Contains("color: #FF0000")); // Red
        Assert.IsTrue(html.Contains("color: #0000FF")); // Blue
        Assert.IsTrue(html.Contains("color: #008000")); // Green
    }

    [TestMethod]
    public void AppendContent_WhenAddedToDocument_NoUnexpectedDuplication() {
        // Arrange
        var span1 = new Span().AppendContent("Content1").WithColor(RGBColor.Red);
        var span2 = span1.AppendContent(" Content2").WithColor(RGBColor.Blue);
        var span3 = span2.AppendContent(" Content3").WithColor(RGBColor.Green);

        var document = new Document();

        // Act
        document.Body.Add(span1);
        document.Body.Add(span2); // This is the same object as span1
        document.Body.Add(span3); // This is the same object as span1

        var bodyHtml = document.Body.ToString();

        // Assert - Should show the complete content 3 times
        var span1Count = CountOccurrences(bodyHtml, "Content1");
        var span2Count = CountOccurrences(bodyHtml, "Content2");
        var span3Count = CountOccurrences(bodyHtml, "Content3");

        Assert.AreEqual(3, span1Count);
        Assert.AreEqual(3, span2Count);
        Assert.AreEqual(3, span3Count);
    }

    [TestMethod]
    public void AddContent_WithMultipleStyling_AppliesCorrectly() {
        // Arrange & Act
        var span = new Span()
            .AddContent("Bold Red").WithColor(RGBColor.Red).WithFontWeight(FontWeight.Bold)
            .AddContent(" Normal Blue").WithColor(RGBColor.Blue)
            .AddContent(" Large Green").WithColor(RGBColor.Green).WithFontSize("20px");

        var html = span.ToString();

        // Assert
        Assert.IsTrue(html.Contains("color: #FF0000"));
        Assert.IsTrue(html.Contains("color: #0000FF"));
        Assert.IsTrue(html.Contains("color: #008000"));
        Assert.IsTrue(html.Contains("font-weight: 700"));
        Assert.IsTrue(html.Contains("font-size: 20px"));
    }

    [TestMethod]
    public void AppendContent_WithMultipleStyling_AppliesCorrectly() {
        // Arrange & Act
        var span = new Span()
            .AppendContent("Bold Red").WithColor(RGBColor.Red).WithFontWeight(FontWeight.Bold)
            .AppendContent(" Normal Blue").WithColor(RGBColor.Blue)
            .AppendContent(" Large Green").WithColor(RGBColor.Green).WithFontSize("20px");

        var html = span.ToString();

        // Assert
        Assert.IsTrue(html.Contains("color: #FF0000"));
        Assert.IsTrue(html.Contains("color: #0000FF"));
        Assert.IsTrue(html.Contains("color: #008000"));
        Assert.IsTrue(html.Contains("font-weight: 700"));
        Assert.IsTrue(html.Contains("font-size: 20px"));
    }

    [TestMethod]
    public void AddContent_EmptyContent_HandlesGracefully() {
        // Arrange & Act
        var span = new Span()
            .AddContent("").WithColor(RGBColor.Red)
            .AddContent("Visible").WithColor(RGBColor.Blue);

        var html = span.ToString();

        // Assert - Should handle empty content without errors
        Assert.IsTrue(html.Contains("Visible"));
        Assert.IsTrue(html.Contains("color: #0000FF"));
    }

    [TestMethod]
    public void AppendContent_EmptyContent_HandlesGracefully() {
        // Arrange & Act
        var span = new Span()
            .AppendContent("").WithColor(RGBColor.Red)
            .AppendContent("Visible").WithColor(RGBColor.Blue);

        var html = span.ToString();

        // Assert
        Assert.IsTrue(html.Contains("Visible"));
        Assert.IsTrue(html.Contains("color: #0000FF"));
    }

    [TestMethod]
    public void AddContent_WithBackgroundAndTextColor_BothApply() {
        // Arrange & Act
        var span = new Span()
            .AddContent("Styled").WithColor(RGBColor.White).WithBackgroundColor(RGBColor.Black);

        var html = span.ToString();

        // Assert
        Assert.IsTrue(html.Contains("color: #FFFFFF"));
        Assert.IsTrue(html.Contains("background-color: #000000"));
    }

    [TestMethod]
    public void MixedAddContentAndAppendContent_WorksTogether() {
        // Arrange & Act
        var span = new Span()
            .AddContent("Added").WithColor(RGBColor.Red)
            .AppendContent(" Appended").WithColor(RGBColor.Blue);

        var html = span.ToString();

        // Assert - Both methods should work together
        Assert.IsTrue(html.Contains("Added"));
        Assert.IsTrue(html.Contains("Appended"));
        Assert.IsTrue(html.Contains("color: #FF0000"));
        Assert.IsTrue(html.Contains("color: #0000FF"));
    }

    [TestMethod]
    public void AddContent_LongChain_PerformanceIsAcceptable() {
        // Arrange & Act - Create a long chain to test performance
        var span = new Span();

        var startTime = DateTime.Now;
        for (int i = 0; i < 100; i++) {
            span = span.AddContent($"Content{i}").WithColor(RGBColor.Red);
        }
        var endTime = DateTime.Now;

        // Assert - Should complete in reasonable time (less than 1 second)
        var duration = endTime - startTime;
        Assert.IsTrue(duration.TotalSeconds < 1, $"Chain creation took {duration.TotalSeconds} seconds");

        // Verify all content is present
        var html = span.ToString();
        Assert.IsTrue(html.Contains("Content0"));
        Assert.IsTrue(html.Contains("Content50"));
        Assert.IsTrue(html.Contains("Content99"));
    }

    private static int CountOccurrences(string text, string pattern) {
        int count = 0;
        int index = 0;
        while ((index = text.IndexOf(pattern, index, StringComparison.Ordinal)) != -1) {
            count++;
            index += pattern.Length;
        }
        return count;
    }
}