using HtmlForgeX;
using HtmlForgeX.Tags;

namespace HtmlForgeX.Examples.Tabler;

public static class TablerIconFontDemo {
    public static void Run() {
        // Create a document with Tabler font icons
        using var document = new Document();
        document.Head.Title = "Tabler Font Icons Example";
        
        // Add a heading
        document.Body.Add(new H1("Tabler Icons - Font Version"));
        
        // Add some basic icons
        document.Body.Add(new HtmlTag("div")
            .Add(new TablerIconFont("home").WithSize("32px").WithColor(RGBColor.Blue))
            .Add(new HtmlTag("span", " "))
            .Add(new TablerIconFont("user").WithSize("32px").WithColor(RGBColor.Green))
            .Add(new HtmlTag("span", " "))
            .Add(new TablerIconFont("settings").WithSize("32px").WithColor(RGBColor.Red))
        );
        
        // Add icons using enum
        document.Body.Add(new H2("Icons from Enum"));
        document.Body.Add(new HtmlTag("div")
            .Add(new TablerIconFont(TablerIconType.Heart).WithSize("48px").WithColor("#e91e63"))
            .Add(new HtmlTag("span", " "))
            .Add(new TablerIconFont(TablerIconType.Star).WithSize("48px").WithColor("#ffc107"))
            .Add(new HtmlTag("span", " "))
            .Add(new TablerIconFont(TablerIconType.Search).WithSize("48px").WithColor("#2196f3"))
        );
        
        // Add styled icons
        document.Body.Add(new H2("Styled Icons"));
        document.Body.Add(new HtmlTag("div")
            .Add(new TablerIconFont("phone")
                .WithSize("64px")
                .WithStyle("transform", "rotate(45deg)")
                .WithStyle("transition", "transform 0.3s")
                .WithClass("hover-rotate"))
            .Add(new HtmlTag("span", " "))
            .Add(new TablerIconFont("mail")
                .WithSize("64px")
                .WithStyle("text-shadow", "2px 2px 4px rgba(0,0,0,0.3)"))
        );
        
        // Save the document
        document.Save("TablerIconFontDemo.html");
    }
}