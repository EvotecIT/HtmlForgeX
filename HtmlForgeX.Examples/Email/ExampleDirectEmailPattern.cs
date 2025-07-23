using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Example demonstrating the DIRECT email pattern - simple top-to-bottom flow like writing in Outlook.
/// This matches the PowerShell EmailBody pattern without layout containers.
/// </summary>
public static class ExampleDirectEmailPattern
{
    public static void Create(bool openInBrowser = false)
    {
        HelpersSpectre.Success("Creating direct email pattern example (like PowerShell EmailBody)...");

        var email = new Email();

        // Email configuration
        email.Head.AddTitle("Direct Email Pattern - Top to Bottom Flow")
                  .AddEmailCoreStyles();

        // DIRECT pattern - like writing in Outlook, top to bottom
        email.Body
            .EmailText("This should be font 8pt, table should also be font 8pt")
            .WithFontSize("8pt")
            .WithFontFamily("Tahoma");

        // Add table directly
        email.Body.EmailTable(table => {
            table.SetClass("simple-table");
            table.AddHeader(new[] { "Name", "Priority", "Company" });
            table.AddRow(new[] { "1Password", "8", "1Password" });
            table.AddRow(new[] { "Visual Studio", "10", "Microsoft" });
        });

        // Line break
        email.Body.EmailLineBreak();

        // Text box with centered styling
        email.Body.EmailTextBox(textBox => {
            textBox.WithFontFamily("Calibri")
                   .WithFontSize("17px")
                   .WithTextDecoration("underline")
                   .WithColor("#e9967a") // DarkSalmon
                   .WithAlignment(Alignment.Center)
                   .AddText("Demonstration");
        });

        // Another line break
        email.Body.EmailLineBreak();

        // Multi-line text box
        email.Body.EmailTextBox(textBox => {
            textBox.WithFontFamily("Calibri")
                   .WithFontSize("15px")
                   .AddText(
                       "This is some text that's preformatted with Emoji 🤷‍♂️",
                       "Adding more text, notice this should be on next line",
                       "",
                       "Empty line above will cause a blank space. If you want to continue writing like you would do in normal email please use here strings as seen below.",
                       "This is tricky but it works like one ❤ big line... even though we've split this over few lines already this will be one continues line. Get it right? 😎",
                       ""
                   );
        });

        // Different line height example
        email.Body.EmailTextBox(textBox => {
            textBox.WithFontFamily("Calibri")
                   .WithFontSize("15px")
                   .WithLineHeight("1.5")
                   .AddText(
                       "This acts a bit differently with line height 1.5",
                       "Each line flows naturally",
                       "Like natural email text"
                   );
        });

        // Email list
        email.Body.EmailList(list => {
            list.WithFontSize("15px");
            list.AddItem("First item").WithColor("#ff0000"); // Red
            list.AddItem("2nd item").WithColor("#008000");   // Green

            // Nested list
            list.Add(nestedList => {
                nestedList.AddItem("3rd item").WithFontStyle("italic");
                nestedList.AddItem("4th item").WithTextDecoration("line-through");
            });
        });

        // Individual text lines with different styling
        email.Body
            .EmailText("This is some text that's preformatted with Emoji 🤷‍♂️")
            .WithFontFamily("Calibri")
            .WithFontSize("15px")
            .WithLineHeight("0.5");

        email.Body
            .EmailText("Adding more text, notice this should be on next line")
            .WithFontFamily("Calibri")
            .WithFontSize("15px")
            .WithLineHeight("0.5");

        email.Body
            .EmailText("") // Empty line
            .WithFontFamily("Calibri")
            .WithFontSize("15px")
            .WithLineHeight("1.0");

        email.Body
            .EmailText("Empty line above will cause a blank space.")
            .WithFontFamily("Calibri")
            .WithFontSize("15px")
            .WithLineHeight("1.75");

        email.Body
            .EmailText("    This is tricky but it works like one ❤")
            .WithFontFamily("Calibri")
            .WithFontSize("15px")
            .WithLineHeight("0.5");

        email.Body
            .EmailText("      big line... even though we've split this over few lines")
            .WithFontFamily("Calibri")
            .WithFontSize("15px")
            .WithLineHeight("0.5");

        email.Body
            .EmailText("      already this will be one continues line. Get it right? 😎")
            .WithFontFamily("Calibri")
            .WithFontSize("15px")
            .WithLineHeight("0.5");

        // Save email
        email.Save("direct-email-pattern.html", openInBrowser);
        HelpersSpectre.Success("✅ Direct email pattern created successfully!");
        HelpersSpectre.Success("📧 Demonstrates: Simple top-to-bottom flow, EmailText, EmailTextBox, EmailTable, EmailList");
        HelpersSpectre.Success("🎯 This is the SIMPLE pattern - like writing in Outlook!");
    }
}