using System.Collections.Generic;
using HtmlForgeX.Containers.Tabler;

namespace HtmlForgeX.Examples.Containers
{
    internal class TablerDashboardDemo
    {
        internal static void Create(bool openInBrowser = false)
        {
            var document = new Document();
            document.Configuration.LibraryMode = LibraryMode.Online;
            document.Configuration.ThemeMode = ThemeMode.System;

            // Professional Dashboard with Tabler Components
            document.Body.Header(header => header
                .Brand("HtmlForgeX", ".")
                .Logo("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                .DarkModeToggle()
                .NotificationBell()
                .Notification("New update available", "Version 2.0 has been released", TablerNotificationType.Info)
                .Notification("Server maintenance", "Scheduled for tonight at 2 AM", TablerNotificationType.Warning)
                .Action("View on GitHub", "https://github.com/EvotecIT/HtmlForgeX", TablerButtonVariant.Primary)
                .UserProfile(profile => {
                    profile.Name = "John Doe";
                    profile.Title = "Administrator";
                    profile.AvatarUrl = "https://preview.tabler.io/static/avatars/000m.jpg";
                })
            );

            // Simplified typed page structure - complex fluent APIs will be implemented later
            var page = new TablerPage();
            var wrapper = new TablerPageWrapper();
            var header = new TablerPageHeader();
            var title = new TablerPageTitle().Title("Dashboard").PreTitle("Overview");
            
            header.Add(title);
            wrapper.Add(header);
            
            var body = new TablerPageBody();
            var statsRow = new TablerStatsRow();
            statsRow.Card("Revenue", "$4,300", "+5%", TablerIconType.CurrencyDollar, TablerColor.Blue);
            statsRow.Card("Users", "2,986", "+3%", TablerIconType.Users, TablerColor.Green);
            statsRow.Card("Orders", "1,526", "-2%", TablerIconType.ShoppingCart, TablerColor.Red);
            statsRow.Card("Performance", "94.1%", "+1%", TablerIconType.ChartBar, TablerColor.Yellow);
            
            body.Add(statsRow);
            
            // Chart card
            var chartCard = new TablerCard();
            // Will implement fluent API later - for now just basic card
            body.Add(chartCard);
            
            // Table card with badges
            var tableCard = new TablerCard();
            var table = new TablerTable();
            table.AddHeaders("Order ID", "Customer", "Date", "Status", "Total");
            table.AddRow(new List<string> { "#1234", "John Smith", "2024-01-20", 
                new TablerBadge("Completed").Color(TablerBadgeColor.Success).ToString(), 
                "$125.00" });
            table.AddRow(new List<string> { "#1235", "Jane Doe", "2024-01-20", 
                new TablerBadge("Pending").Color(TablerBadgeColor.Warning).ToString(), 
                "$89.50" });
            table.AddRow(new List<string> { "#1236", "Bob Johnson", "2024-01-19", 
                new TablerBadge("Processing").Color(TablerBadgeColor.Info).ToString(), 
                "$256.75" });
            table.AddRow(new List<string> { "#1237", "Alice Brown", "2024-01-19", 
                new TablerBadge("Cancelled").Color(TablerBadgeColor.Danger).ToString(), 
                "$45.00" });
            
            tableCard.Add(table);
            body.Add(tableCard);
            
            wrapper.Add(body);
            page.Add(wrapper);
            document.Body.Add(page);

            // Add breadcrumb
            document.Body.Breadcrumb(bc => bc
                .Item("Home", ".")
                .Item("Dashboard", "./dashboard.html")
                .Active("Analytics")
            );

            // Footer
            document.Body.Footer(footer => footer
                .Company("EvotecIT", "https://evotec.xyz")
                .Link("Documentation", "#")
                .Link("License", "#")
                .Link("Source code", "https://github.com/EvotecIT/HtmlForgeX")
                .Social(TablerSocialPlatform.GitHub, "https://github.com/EvotecIT")
                .Social(TablerSocialPlatform.Twitter, "https://twitter.com/evotecit")
            );

            document.Save("TablerDashboard.html");
        }
    }

    internal class TablerDashboardWithSidebarDemo
    {
        internal static void Create(bool openInBrowser = false)
        {
            var document = new Document();
            document.Configuration.LibraryMode = LibraryMode.Online;
            document.Configuration.ThemeMode = ThemeMode.System;

            // Simplified typed page structure with sidebar
            var page = new TablerPage();
            
            // Sidebar
            var sidebar = TablerSidebar.Create(sb => sb
                .Brand("HtmlForgeX")
                .Logo("../../../../Assets/Images/WhiteBackground/Logo-evotec.png")
                .UserProfile("John Doe", "Administrator", "https://preview.tabler.io/static/avatars/000m.jpg")
                .Section("Main")
                .Item("Dashboard", TablerIconType.Home, "./")
                .Item("Orders", "16", "./orders.html")
                .Item("Customers", TablerIconType.Users, "./customers.html")
                .Divider()
                .Section("Analytics")
                .Dropdown("Reports", TablerIconType.FileAnalytics, dd => dd
                    .Item("Sales Report", "./reports/sales.html")
                    .Item("Customer Report", "./reports/customers.html")
                    .Item("Product Report", "./reports/products.html")
                )
                .Item("Real-time", TablerIconType.Activity, "./realtime.html")
                .Divider()
                .Section("Settings")
                .Item("General", TablerIconType.Settings, "./settings.html")
                .Item("Security", TablerIconType.Shield, "./security.html")
                .Item("Integrations", TablerIconType.Plug, "./integrations.html")
            );
            page.Add(sidebar);
            
            // Main wrapper
            var wrapper = new TablerPageWrapper();
            
            // Header
            var header = TablerHeader.Create(h => h
                .DarkModeToggle()
                .NotificationBell()
                .Notification("System update", "New features available", TablerNotificationType.Info)
                .UserProfile(profile => {
                    profile.Name = "John Doe";
                    profile.Title = "Administrator";
                    profile.AvatarUrl = "https://preview.tabler.io/static/avatars/000m.jpg";
                })
            );
            wrapper.Add(header);
            
            // Page header
            var pageHeader = new TablerPageHeader();
            var pageTitle = new TablerPageTitle().Title("Dashboard with Sidebar");
            pageHeader.Add(pageTitle);
            wrapper.Add(pageHeader);
            
            // Page body
            var body = new TablerPageBody();
            
            // Alert
            var alert = new TablerAlert("Welcome to HtmlForgeX Dashboard", "This is a professional dashboard demo showcasing the new navigation components.", TablerColor.Blue, TablerAlertType.Dismissible);
            body.Add(alert);
            
            // Sample cards
            var row = new TablerRow();
            for (int i = 1; i <= 3; i++)
            {
                var col = new TablerColumn(TablerColumnNumber.MediumFour);
                var card = new TablerCard();
                // Simple card implementation - complex fluent API will be added later
                col.Add(card);
                row.Add(col);
            }
            body.Add(row);
            
            wrapper.Add(body);
            
            // Footer
            var footer = TablerFooter.Create(f => f
                .Style(TablerFooterStyle.Light)
                .Company("EvotecIT", "https://evotec.xyz")
                .Link("About", "#")
                .Link("Documentation", "#")
                .Link("Support", "#")
                .Social(TablerSocialPlatform.GitHub, "https://github.com/EvotecIT")
            );
            wrapper.Add(footer);
            
            page.Add(wrapper);
            document.Body.Add(page);

            document.Save("TablerDashboardWithSidebar.html");
        }
    }
}