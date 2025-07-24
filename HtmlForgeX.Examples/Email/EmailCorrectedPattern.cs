using System;

namespace HtmlForgeX.Examples.Emails;

/// <summary>
/// Example team member data class for demonstrating type-safe table population.
/// </summary>
public class TeamMember {
    public string Name { get; set; } = "";
    public string Role { get; set; } = "";
    public string Experience { get; set; } = "";
}

/// <summary>
/// Example demonstrating proper EmailBox spacing and consistent layout patterns.
/// Shows how to use multiple EmailBox elements with proper margins and spacing.
/// </summary>
public static class EmailCorrectedPattern
{
    public static void Create(bool openInBrowser = false)
    {
        HelpersSpectre.Success("Creating corrected email pattern example...");

        var email = new Email();

        // Email settings
        email.Head.AddTitle("Welcome to HtmlForgeX!")
                  .AddEmailCoreStyles();

        // Header box - contains logo and main welcome message
        email.Body.EmailBox(emailBox => {
            emailBox.WithOuterMargin("0 auto 24px auto").WithMaxWidth("600px");

                        // Header with logo using new direct pattern
            email.Header.WithPadding("20px");
            email.Header.EmailRow(row => {
                row.EmailColumn(col => {
                    col.SetAlignment(Alignment.Center);
                    col.EmailImage("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                        .WithWidth("150px")
                        .WithHeight("42px")
                        .WithAlternativeText("HtmlForgeX Logo")
                        .WithLink("https://htmlforgex.com", true);
                });
            });

            emailBox.EmailText("🎉 Welcome to HtmlForgeX!")
                .WithFontSize("32px")
                .WithFontWeight("bold")
                .WithAlignment(Alignment.Center)
                .WithColor("#111827");

            emailBox.EmailText("We're excited to have you join our community of developers.")
                .WithFontSize("18px")
                .WithColor("#374151")
                .WithAlignment(Alignment.Center)
                .WithLineHeight("1.6");
        });

        // Getting started section - separate box for better spacing
        email.Body.EmailBox(emailBox => {
            emailBox.WithOuterMargin("0 auto 24px auto").WithMaxWidth("600px");

            emailBox.EmailText("Getting Started")
                .WithFontSize("24px")
                .WithFontWeight("bold")
                .WithColor("#111827");

            emailBox.EmailText("Here's what you can do next:")
                .WithFontSize("16px")
                .WithColor("#6B7280")
                .WithLineHeight("1.6");

            // Action items list with proper spacing
            emailBox.EmailList(list => {
                list.AddItem("Complete your profile setup")
                    .WithColor("#059669")
                    .WithFontWeight("600");
                list.AddItem("Explore our component library")
                    .WithColor("#0EA5E9")
                    .WithFontWeight("600");
                list.AddItem("Create your first dashboard")
                    .WithColor("#8B5CF6")
                    .WithFontWeight("600");
                list.AddItem("Join our community forum")
                    .WithColor("#F59E0B")
                    .WithFontWeight("600");
            });
        });

        // Features section - demonstrates consistent text positioning
        email.Body.EmailBox(emailBox => {
            emailBox.WithOuterMargin("0 auto 24px auto").WithMaxWidth("600px");

            emailBox.EmailText("📦 Features")
                .WithFontSize("20px")
                .WithFontWeight("bold")
                .WithColor("#111827");

            emailBox.EmailList(list => {
                list.AddItem("Easy-to-use fluent API");
                list.AddItem("No HTML/CSS knowledge required");
                list.AddItem("Email-safe components");
            });

            emailBox.EmailText("🛠️ Support")
                .WithFontSize("20px")
                .WithFontWeight("bold")
                .WithColor("#111827");

            emailBox.EmailList(list => {
                list.AddItem("Comprehensive documentation");
                list.AddItem("Community forum");
                list.AddItem("GitHub repository");
            });
        });

        // Feature comparison table - proper styling applied
        email.Body.EmailBox(emailBox => {
            emailBox.WithOuterMargin("0 auto 24px auto").WithMaxWidth("600px");

            emailBox.EmailTable(table => {
                table.SetStyle(EmailTableStyle.FeatureComparison);
                table.AddHeader(new[] { "Feature", "Free", "Pro" });
                table.AddRow(new[] { "Basic Components", "✅", "✅" });
                table.AddRow(new[] { "Email Templates", "✅", "✅" });
                table.AddRow(new[] { "Advanced Charts", "❌", "✅" });
                table.AddRow(new[] { "Priority Support", "❌", "✅" });
            });
        });

        // Team members section - demonstrates proper table styling
        email.Body.EmailBox(emailBox => {
            emailBox.WithOuterMargin("0 auto 24px auto").WithMaxWidth("600px");

            emailBox.EmailText("Team Members")
                .WithFontSize("20px")
                .WithFontWeight("bold")
                .WithColor("#111827");

            emailBox.EmailTable(table => {
                table.SetStyle(EmailTableStyle.TeamMembers);
                table.AddHeader(new[] { "Name", "Role", "Experience" });
                table.AddRow(new[] { "John", "Developer", "5 years" });
                table.AddRow(new[] { "Jane", "Designer", "3 years" });
                table.AddRow(new[] { "Bob", "Manager", "8 years" });
            });
        });

        // Call to action - demonstrates button spacing in rows
        email.Body.EmailBox(emailBox => {
            emailBox.WithOuterMargin("0 auto 0 auto").WithMaxWidth("600px"); // No bottom margin for last box

            emailBox.EmailText("Ready to get started?")
                .WithFontSize("24px")
                .WithFontWeight("bold")
                .WithAlignment(Alignment.Center)
                .WithColor("#111827");

            // Buttons with proper spacing
            emailBox.EmailRow(row => {
                row.SetColumnSpacing("16px");
                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    var startButton = new EmailButton("Get Started Now", "https://htmlforgex.com/start");
                    col.Add(startButton);
                });

                row.EmailColumn(col => {
                    col.SetWidth("50%");
                    var learnButton = new EmailButton("Learn More", "https://htmlforgex.com/docs");
                    col.Add(learnButton);
                });
            });

            emailBox.EmailText("Questions? Reply to this email or visit our help center.")
                .WithFontSize("14px")
                .WithColor("#6B7280")
                .WithAlignment(Alignment.Center);
        });

        // Save email
        email.Save("corrected-email-pattern.html", openInBrowser);
        HelpersSpectre.Success("✅ Corrected email pattern created successfully!");
        HelpersSpectre.Success("📧 Demonstrates: Proper EmailBox spacing, consistent text positioning, multiple sections, proper margins");
    }
}