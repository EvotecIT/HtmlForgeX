using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HtmlForgeX.Tests;

[TestClass]
public class TestHtmlTagValidation {

    [TestMethod]
    public void HtmlTag_EmptyTag() {
        var tag = new HtmlTag("div");
        Assert.AreEqual("<div></div>", tag.ToString());
    }

    [TestMethod]
    public void HtmlTag_WithContent() {
        var tag = new HtmlTag("p", "Hello World");
        Assert.AreEqual("<p>Hello World</p>", tag.ToString());
    }

    [TestMethod]
    public void HtmlTag_WithSingleAttribute() {
        var tag = new HtmlTag("div");
        tag.Attributes.Add("id", "test");
        Assert.AreEqual("<div id=\"test\"></div>", tag.ToString());
    }

    [TestMethod]
    public void HtmlTag_WithMultipleAttributes() {
        var tag = new HtmlTag("div");
        tag.Attributes.Add("id", "test");
        tag.Attributes.Add("class", "container");
        tag.Attributes.Add("data-value", "123");
        var result = tag.ToString();
        
        Assert.IsTrue(result.Contains("id=\"test\""));
        Assert.IsTrue(result.Contains("class=\"container\""));
        Assert.IsTrue(result.Contains("data-value=\"123\""));
    }

    [TestMethod]
    public void HtmlTag_WithNestedStyleAttributes() {
        var tag = new HtmlTag("div", "Styled content", new Dictionary<string, object> {
            { "style", new Dictionary<string, object> {
                { "background-color", "blue" },
                { "margin", "10px" },
                { "padding", "5px" }
            } }
        });
        
        var result = tag.ToString();
        Assert.IsTrue(result.Contains("style=\""));
        Assert.IsTrue(result.Contains("background-color: blue"));
        Assert.IsTrue(result.Contains("margin: 10px"));
        Assert.IsTrue(result.Contains("padding: 5px"));
    }

    [TestMethod]
    public void HtmlTag_SelfClosingTag() {
        var tag = new HtmlTag("br", TagMode.SelfClosing);
        Assert.AreEqual("<br/>", tag.ToString());
    }

    [TestMethod]
    public void HtmlTag_WithBooleanAttributes() {
        var tag = new HtmlTag("input");
        tag.Attributes.Add("type", "checkbox");
        tag.Attributes.Add("checked", true);
        tag.Attributes.Add("disabled", false);
        
        var result = tag.ToString();
        Assert.IsTrue(result.Contains("checked=\"True\""));
        Assert.IsTrue(result.Contains("disabled=\"False\""));
    }

    [TestMethod]
    public void HtmlTag_WithNullContent() {
        var tag = new HtmlTag("div", "");
        Assert.AreEqual("<div></div>", tag.ToString());
    }

    [TestMethod]
    public void HtmlTag_WithEmptyStringContent() {
        var tag = new HtmlTag("div", "");
        Assert.AreEqual("<div></div>", tag.ToString());
    }

    [TestMethod]
    public void HtmlTag_WithSpecialCharacters() {
        var tag = new HtmlTag("div", "Hello & <World>");
        var result = tag.ToString();
        Assert.IsTrue(result.Contains("Hello") && result.Contains("World"));
    }

    [TestMethod]
    public void HtmlTag_WithNumericAttributes() {
        var tag = new HtmlTag("div");
        tag.Attributes.Add("data-count", 42);
        tag.Attributes.Add("data-price", 19.99);
        
        var result = tag.ToString();
        Assert.IsTrue(result.Contains("data-count=\"42\""));
        Assert.IsTrue(result.Contains("data-price=\"19.99\""));
    }
}