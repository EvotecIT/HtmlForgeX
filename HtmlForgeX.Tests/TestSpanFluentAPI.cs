using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestSpanFluentAPI {

    [TestMethod]
    public void SpanFluentAPI_UserExample_AppendContentWithColors() {
        // Test case from user's example - this should show the issue
        var document = new Document();
        
        var span4 = new Span()
            .AppendContent("Should be RED").WithColor(RGBColor.Red)
            .AppendContent("Should be BLUE").WithColor(RGBColor.Blue)
            .AppendContent("Should be GREEN").WithColor(RGBColor.Green);

        document.Body.Add(span4);
        
        var html = document.ToString();
        Console.WriteLine("Original broken approach:");
        Console.WriteLine(html);
        
        // This approach is broken but let's test what it produces
        Assert.IsTrue(html.Contains("Should be RED") || html.Contains("Should be BLUE") || html.Contains("Should be GREEN"), 
            "Should contain at least one text");
        
        // Now test the new working approach
        var document2 = new Document();
        
        var span5 = new Span()
            .AddColoredText("Should be RED", RGBColor.Red)
            .AddColoredText("Should be BLUE", RGBColor.Blue)
            .AddColoredText("Should be GREEN", RGBColor.Green);

        document2.Body.Add(span5);
        
        var html2 = document2.ToString();
        Console.WriteLine("\nNew working approach:");
        Console.WriteLine(html2);
        
        // Check if all colors are applied correctly
        Assert.IsTrue(html2.Contains("Should be RED"), "Should contain red text");
        Assert.IsTrue(html2.Contains("Should be BLUE"), "Should contain blue text");
        Assert.IsTrue(html2.Contains("Should be GREEN"), "Should contain green text");
        
        // Check for multiple color styles
        var redColorIndex = html2.IndexOf("#FF0000");
        var blueColorIndex = html2.IndexOf("#0000FF");
        var greenColorIndex = html2.IndexOf("#008000");
        
        Assert.IsTrue(redColorIndex >= 0, "Should contain red color");
        Assert.IsTrue(blueColorIndex >= 0, "Should contain blue color");
        Assert.IsTrue(greenColorIndex >= 0, "Should contain green color");
    }
    
    [TestMethod]
    public void SpanFluentAPI_BodySpan_WithColor() {
        // Test Body.Span() method
        var document = new Document();
        
        document.Body.Span("Hello World").WithColor(RGBColor.Red).WithFontSize("20px");
        
        var html = document.ToString();
        Console.WriteLine("Body.Span() HTML:");
        Console.WriteLine(html);
        
        // Check if styling is applied
        Assert.IsTrue(html.Contains("Hello World"), "Should contain the text");
        Assert.IsTrue(html.Contains("color: #"), "Should contain color style");
        Assert.IsTrue(html.Contains("font-size: 20px"), "Should contain font size");
    }
    
    [TestMethod]
    public void SpanFluentAPI_DirectSpan_WithColor() {
        // Test direct span creation
        var document = new Document();
        
        var span = new Span { Content = "Direct span" };
        span.WithColor(RGBColor.Blue);
        document.Body.Add(span);
        
        var html = document.ToString();
        Console.WriteLine("Direct Span HTML:");
        Console.WriteLine(html);
        
        // Check if styling is applied
        Assert.IsTrue(html.Contains("Direct span"), "Should contain the text");
        Assert.IsTrue(html.Contains("color: #"), "Should contain color style");
    }
    
    [TestMethod]
    public void SpanFluentAPI_AppendContentBehavior() {
        // Test to understand AppendContent behavior
        var span = new Span();
        span.AppendContent("First").WithColor(RGBColor.Red);
        span.AppendContent("Second").WithColor(RGBColor.Blue);
        
        var html = span.ToString();
        Console.WriteLine("AppendContent behavior:");
        Console.WriteLine(html);
        
        // Analyze the structure
        Assert.IsTrue(html.Contains("First"), "Should contain first text");
        Assert.IsTrue(html.Contains("Second"), "Should contain second text");
    }
    
    [TestMethod]
    public void Element_Text_SimpleAPI() {
        // Test the new simplified Text API
        var document = new Document();
        
        // Test simple text with color
        document.Body.Text("Red Text", RGBColor.Red);
        document.Body.Text("Blue Text", RGBColor.Blue, "20px");
        document.Body.Text("Normal Text", null, null); // Explicitly call the Span version
        
        var html = document.ToString();
        Console.WriteLine("Simple Text API:");
        Console.WriteLine(html);
        
        // Verify content and styling
        Assert.IsTrue(html.Contains("Red Text"), "Should contain red text");
        Assert.IsTrue(html.Contains("Blue Text"), "Should contain blue text");
        Assert.IsTrue(html.Contains("Normal Text"), "Should contain normal text");
        Assert.IsTrue(html.Contains("#FF0000"), "Should contain red color");
        Assert.IsTrue(html.Contains("#0000FF"), "Should contain blue color");
        Assert.IsTrue(html.Contains("font-size: 20px"), "Should contain font size");
    }
    
    [TestMethod]
    public void SpanFluentAPI_AddStyledText() {
        // Test the new AddStyledText method
        var document = new Document();
        
        var span = new Span()
            .AddStyledText("Bold Red", RGBColor.Red, "16px", FontWeight.Bold)
            .AddStyledText(" Normal Blue", RGBColor.Blue)
            .AddStyledText(" Large Green", RGBColor.Green, "24px");
        
        document.Body.Add(span);
        
        var html = document.ToString();
        Console.WriteLine("AddStyledText API:");
        Console.WriteLine(html);
        
        // Verify all text is present
        Assert.IsTrue(html.Contains("Bold Red"), "Should contain bold red text");
        Assert.IsTrue(html.Contains("Normal Blue"), "Should contain normal blue text");
        Assert.IsTrue(html.Contains("Large Green"), "Should contain large green text");
        
        // Verify styles are applied
        Assert.IsTrue(html.Contains("#FF0000"), "Should contain red color");
        Assert.IsTrue(html.Contains("#0000FF"), "Should contain blue color");
        Assert.IsTrue(html.Contains("#008000"), "Should contain green color");
        Assert.IsTrue(html.Contains("font-weight: bold"), "Should contain bold weight");
        Assert.IsTrue(html.Contains("font-size: 16px"), "Should contain 16px size");
        Assert.IsTrue(html.Contains("font-size: 24px"), "Should contain 24px size");
    }
}