using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Example demonstrating the LAYOUT email pattern - structured rows and columns.
/// This matches the PowerShell EmailLayout pattern with EmailLayoutRow/EmailLayoutColumn.
/// </summary>
public static class EmailLayoutPattern
{
    public static void Create(bool openInBrowser = false)
    {
        HelpersSpectre.Success("Creating layout email pattern example (like PowerShell EmailLayout)...");

        var email = new Email();

        // Email configuration
        email.Head.AddTitle("Layout Email Pattern - Structured Rows and Columns")
                  .AddEmailCoreStyles();

        // LAYOUT pattern - structured with rows and columns
        email.Body.EmailBox(emailBox => {
            emailBox.WithPadding("8px"); // Reduce padding for layout

            // First row - full width image
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("600px");
                    col.EmailImage("https://picsum.photos/600/100?image=14", "600");
                });
            });

            // Second row - two columns with text
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("300px");
                    col.EmailText("This should be font 8pt, table should also be font 8pt")
                       .WithFontSize("8pt")
                       .WithFontFamily("Tahoma");
                });
                row.EmailColumn(col => {
                    col.SetWidth("300px");
                    col.EmailText("This should be font 8pt, table should also be font 8pt")
                       .WithFontSize("8pt")
                       .WithFontFamily("Tahoma");
                });
            });

            // Third row - table and text
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("300px");
                    col.EmailText("Test").WithFontSize("15pt");
                    col.EmailTable(table => {
                        table.SetClass("layout-table");
                        table.AddHeader(new[] { "Name", "Priority", "Company", "CompanyName" });
                        table.AddRow(new[] { "1Password", "8", "1Password", "" });
                        table.AddRow(new[] { "1Password", "10", "1Password", "" });
                    });
                });
                row.EmailColumn(col => {
                    col.SetWidth("300px");
                    col.EmailText("Test").WithFontSize("15pt");
                });
            });

            // Fourth row - two images
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("300px");
                    col.EmailImage("https://picsum.photos/300/100?image=15", "300")
                       .WithAlternativeText("picsumarry1");
                });
                row.EmailColumn(col => {
                    col.SetWidth("300px");
                    col.EmailImage("https://picsum.photos/300/100?image=10", "300")
                       .WithAlternativeText("picsumarry2");
                });
            });

            // Fifth row - empty column and text box
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    // Empty column
                });
                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    col.EmailLineBreak();
                    col.EmailTextBox(textBox => {
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
                });
            });

            // Sixth row - centered content
            emailBox.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetAlignment(Alignment.Center);
                    col.EmailText("This is some text that's preformatted with Emoji 🤷‍♂️")
                       .WithFontFamily("Calibri")
                       .WithFontSize("15px")
                       .WithLineHeight("0.5");
                    col.EmailText("Adding more text, notice this should be on next line")
                       .WithFontFamily("Calibri")
                       .WithFontSize("15px")
                       .WithLineHeight("0.5");
                    col.EmailText("")
                       .WithFontFamily("Calibri")
                       .WithFontSize("15px")
                       .WithLineHeight("1.0");
                    col.EmailText("E line... even though we've split this over few lines")
                       .WithFontFamily("Calibri")
                       .WithFontSize("15px")
                       .WithLineHeight("0.5");
                    col.EmailText("      already this will be one continues line. Get it right? 😎")
                       .WithFontFamily("Calibri")
                       .WithFontSize("15px")
                       .WithLineHeight("0.5");
                });
            });
        });

        // Save email
        email.Save("layout-email-pattern.html", openInBrowser);
        HelpersSpectre.Success("✅ Layout email pattern created successfully!");
        HelpersSpectre.Success("📧 Demonstrates: Structured layout, EmailRow, EmailColumn, EmailImage, multi-column design");
        HelpersSpectre.Success("🎯 This is the LAYOUT pattern - for complex structured emails!");
    }
}