using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Example of creating a welcome email using HtmlForgeX email components.
/// Demonstrates user-friendly email building with no HTML/CSS knowledge required.
/// </summary>
public static class ExampleWelcomeEmail
{
    public static void Create(bool openInBrowser = false)
    {
        Console.WriteLine("Creating welcome email example...");

        var email = new Email();

        // Email settings
        email.Head.AddTitle("Welcome to HtmlForgeX!")
                  .AddEmailCoreStyles();

        // Header with company logo
        var header = new EmailHeader()
                            .SetLogo("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
            .SetLogoLink("https://htmlforgex.com");

        // Main content container
        var content = new EmailBox();

        // Welcome heading - using Span for full control
        var welcomeHeading = new Span()
            .AppendContent("Welcome to HtmlForgeX!")
            .WithFontSize("32px")
            .WithFontWeight(FontWeight.Bold)
            .WithAlignment(FontAlignment.Center)
            .WithColor(new RGBColor("#111827"));

        content.Add(new BasicElement().Add(welcomeHeading));

        // Subtitle with different styling
        var subtitle = new Span()
            .AppendContent("We're excited to have you join our community of developers building beautiful web interfaces.")
            .WithFontSize("18px")
            .WithColor(new RGBColor("#667382"))
            .WithAlignment(FontAlignment.Center)
            .WithLineHeight("1.6");

        content.Add(new BasicElement().Add(subtitle));

        // Action button
        var getStartedButton = new EmailButton("Get Started", "https://htmlforgex.com/dashboard");
        content.Add(new BasicElement().Add(getStartedButton));

        // Divider using Span styling
        var divider = new Span()
            .AppendContent("─────────────────────────────")
            .WithColor(new RGBColor("#e8ebee"))
            .WithAlignment(FontAlignment.Center);

        content.Add(new BasicElement().Add(divider));

        // Next steps section using flexible components
        var nextStepsTitle = new Span()
            .AppendContent("What's next?")
            .WithFontSize("20px")
            .WithFontWeight(FontWeight.Lighter)
            .WithColor(new RGBColor("#111827"));

        content.Add(new BasicElement().Add(nextStepsTitle));

        // Create a flexible list using Span components
        var listItem1 = new Span()
            .AppendContent("• ")
            .WithColor(new RGBColor("#066FD1"))
            .WithFontWeight(FontWeight.Bold)
            .AppendContent("Complete your profile setup")
            .WithColor(new RGBColor("#667382"));

        var listItem2 = new Span()
            .AppendContent("• ")
            .WithColor(new RGBColor("#066FD1"))
            .WithFontWeight(FontWeight.Bold)
            .AppendContent("Explore our component library")
            .WithColor(new RGBColor("#667382"));

        var listItem3 = new Span()
            .AppendContent("• ")
            .WithColor(new RGBColor("#066FD1"))
            .WithFontWeight(FontWeight.Bold)
            .AppendContent("Create your first dashboard")
            .WithColor(new RGBColor("#667382"));

        var listItem4 = new Span()
            .AppendContent("• ")
            .WithColor(new RGBColor("#066FD1"))
            .WithFontWeight(FontWeight.Bold)
            .AppendContent("Join our community forum")
            .WithColor(new RGBColor("#667382"));

        content.Add(new BasicElement().Add(listItem1));
        content.Add(new BasicElement().Add(listItem2));
        content.Add(new BasicElement().Add(listItem3));
        content.Add(new BasicElement().Add(listItem4));

        // Footer with flexible components
        var footer = new EmailBox();

        // Contact information using flexible Span building
        var contactInfo = new Span()
            .AppendContent("Questions? Contact us at ")
            .WithColor(new RGBColor("#667382"))
            .AppendContent("support@htmlforgex.com")
            .WithColor(new RGBColor("#066FD1"))
            .WithTextDecoration(TextDecoration.None);

        footer.Add(new BasicElement().Add(contactInfo));

        // Copyright notice
        var copyright = new Span()
            .AppendContent("© 2025 HtmlForgeX. All rights reserved.")
            .WithFontSize("14px")
            .WithColor(new RGBColor("#9CA3AF"))
            .WithAlignment(FontAlignment.Center);

        footer.Add(new BasicElement().Add(copyright));

        // Unsubscribe link
        var unsubscribe = new Span()
            .AppendContent("Don't want to receive these emails? ")
            .WithFontSize("14px")
            .WithColor(new RGBColor("#9CA3AF"))
            .AppendContent("Unsubscribe")
            .WithColor(new RGBColor("#066FD1"))
            .WithTextDecoration(TextDecoration.Underline);

        footer.Add(new BasicElement().Add(unsubscribe));

        // Assemble email
        email.Body.Add(header)
                  .Add(content)
                  .Add(footer);

        // Save email
        email.Save("welcome-email.html", openInBrowser);
        Console.WriteLine("✅ Welcome email created successfully!");
        Console.WriteLine("📧 Demonstrates: User-friendly text styling, flexible list building, contact information");
    }
}