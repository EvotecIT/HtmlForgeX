using System;
using HtmlForgeX;

// Test class to trigger CS0108 warning
public class TestIconHiding : Element {
    // This should trigger CS0108 warning since Element has Icon methods
    public string Icon { get; set; }
    
    public override string ToString() => Icon ?? "";
}