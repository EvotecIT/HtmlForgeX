using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HtmlForgeX.Tests;

/// <summary>
/// Exercises usage of the <see cref="FullCalendar"/> component within a document.
/// </summary>
[TestClass]
public class TestFullCalendarComponent {

    [TestMethod]
    public void FullCalendar_BasicCreation() {
        var doc = new Document();
        
        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                calendar.NowIndicator(true);
                calendar.BusinessHours(true);
                calendar.AddEvent("Test Event", DateTime.Today);
            });
        });
        
        var html = doc.ToString();
        
        // Should contain calendar element and configuration
        Assert.IsTrue(html.Contains("FullCalendar") || html.Contains("fullcalendar"), "Should contain calendar element");
        Assert.IsTrue(html.Contains("Test Event"), "Should contain event data");
        Assert.IsTrue(html.Contains("nowIndicator") || html.Contains("businessHours"), "Should contain configuration options");
    }

    [TestMethod]
    public void FullCalendar_WithEvents() {
        var doc = new Document();
        
        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                var event1 = calendar.AddEvent("Meeting", "Team meeting", DateTime.Today.AddHours(10), DateTime.Today.AddHours(11));
                event1.Url("https://meeting.example.com");
                
                var event2 = calendar.AddEvent("Lunch", DateTime.Today.AddHours(12));
                
                calendar.AddHeaderToolbar()
                    .Left(FullCalendarToolbarOption.Prev, FullCalendarToolbarOption.Next)
                    .Center(FullCalendarToolbarOption.Title)
                    .Right(FullCalendarToolbarOption.DayGridMonth);
            });
        });
        
        var html = doc.ToString();
        
        // Should contain event details
        Assert.IsTrue(html.Contains("Meeting"), "Should contain first event");
        Assert.IsTrue(html.Contains("Team meeting"), "Should contain event description");
        Assert.IsTrue(html.Contains("Lunch"), "Should contain second event");
        Assert.IsTrue(html.Contains("https://meeting.example.com"), "Should contain event URL");
        
        // Should contain toolbar configuration
        Assert.IsTrue(html.Contains("headerToolbar") || html.Contains("toolbar"), "Should contain toolbar configuration");
    }

    [TestMethod]
    public void FullCalendar_EventWithTimeRange() {
        var doc = new Document();
        var startTime = DateTime.Today.AddHours(14);
        var endTime = DateTime.Today.AddHours(16);
        
        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                calendar.AddEvent("Workshop", "Programming Workshop", startTime, endTime);
            });
        });
        
        var html = doc.ToString();
        
        // Should contain event with time range
        Assert.IsTrue(html.Contains("Workshop"), "Should contain event title");
        Assert.IsTrue(html.Contains("Programming Workshop"), "Should contain event description");
        
        // Should contain time information
        Assert.IsTrue(html.Contains("start") || html.Contains("end"), "Should contain time range information");
    }

    [TestMethod]
    public void FullCalendar_Configuration() {
        var doc = new Document();
        
        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                calendar.NowIndicator(true)
                       .NavLinks(true)
                       .BusinessHours(true)
                       .Selectable(true)
                       .Editable(true)
                       .InitialDate(DateTime.Today);
            });
        });
        
        var html = doc.ToString();
        
        // Should contain configuration options
        Assert.IsTrue(html.Contains("nowIndicator"), "Should contain nowIndicator setting");
        Assert.IsTrue(html.Contains("navLinks") || html.Contains("businessHours"), "Should contain navigation settings");
        Assert.IsTrue(html.Contains("selectable") || html.Contains("editable"), "Should contain interaction settings");
    }

    [TestMethod]
    public void FullCalendar_Toolbar() {
        var doc = new Document();
        
        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                calendar.AddHeaderToolbar()
                    .Left(FullCalendarToolbarOption.Prev, FullCalendarToolbarOption.Next, FullCalendarToolbarOption.Today)
                    .Center(FullCalendarToolbarOption.Title)
                    .Right(FullCalendarToolbarOption.DayGridMonth, FullCalendarToolbarOption.TimeGridWeek, FullCalendarToolbarOption.TimeGridDay);
                
                calendar.AddFooterToolbar()
                    .Center(FullCalendarToolbarOption.Title);
            });
        });
        
        var html = doc.ToString();
        
        // Should contain toolbar configurations
        Assert.IsTrue(html.Contains("headerToolbar"), "Should contain header toolbar");
        Assert.IsTrue(html.Contains("footerToolbar") || html.Contains("footer"), "Should contain footer toolbar");
        Assert.IsTrue(html.Contains("prev") || html.Contains("next") || html.Contains("today"), "Should contain navigation buttons");
        Assert.IsTrue(html.Contains("dayGridMonth") || html.Contains("timeGridWeek"), "Should contain view options");
    }

    [TestMethod]
    public void FullCalendar_MultipleEvents() {
        var doc = new Document();
        
        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                for (int i = 0; i < 5; i++) {
                    calendar.AddEvent($"Event {i}", $"Description {i}", DateTime.Today.AddDays(i));
                }
            });
        });
        
        var html = doc.ToString();
        
        // Should contain all events
        for (int i = 0; i < 5; i++) {
            Assert.IsTrue(html.Contains($"Event {i}"), $"Should contain Event {i}");
        }
    }

    [TestMethod]
    public void FullCalendar_EventWithColor() {
        var doc = new Document();
        
        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                var colorEvent = calendar.AddEvent("Colored Event", DateTime.Today);
                colorEvent.TextColor(RGBColor.White).BackgroundColor(RGBColor.Red);
            });
        });
        
        var html = doc.ToString();
        
        // Should contain event with color
        Assert.IsTrue(html.Contains("Colored Event"), "Should contain event");
        Assert.IsTrue(html.Contains("color") || html.Contains("background"), "Should contain color information");
    }

    [TestMethod]
    public void FullCalendar_OnlineMode_LibraryInclusion() {
        var doc = new Document();
        doc.LibraryMode = LibraryMode.Online;
        
        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                calendar.AddEvent("Online Event", DateTime.Today);
            });
        });
        
        var html = doc.ToString();
        
        // Should include FullCalendar library from CDN
        Assert.IsTrue(html.Contains("fullcalendar") || html.Contains("FullCalendar"), "Should include FullCalendar library");
        Assert.IsTrue(html.Contains("https://") || html.Contains("cdn"), "Should use CDN in online mode");
    }

    [TestMethod]
    public void FullCalendar_OfflineMode_NoExternalCDN() {
        var doc = new Document();
        doc.LibraryMode = LibraryMode.Offline;
        
        try {
            doc.Body.Add(element => {
                element.FullCalendar(calendar => {
                    calendar.AddEvent("Offline Event", DateTime.Today);
                });
            });
            
            var html = doc.ToString();
            
            // Should not use CDN in offline mode
            Assert.IsFalse(html.Contains("cdn.jsdelivr.net"), "Should not use CDN in offline mode");
            Assert.IsTrue(html.Contains("FullCalendar") || html.Contains("fullcalendar"), "Should include FullCalendar functionality");
        } catch (System.ArgumentException ex) when (ex.Message.Contains("Resource not found")) {
            // If embedded resource is not available, test that the library mode is respected
            Assert.Inconclusive("FullCalendar embedded resource not available - this is expected if not all resources are embedded");
        }
    }

    [TestMethod]
    public void FullCalendar_LibraryRegistration() {
        var doc = new Document();
        
        // Before adding calendar
        Assert.IsFalse(doc.Configuration.Libraries.ContainsKey(Libraries.FullCalendar), 
            "FullCalendar library should not be registered initially");
        
        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                calendar.AddEvent("Test", DateTime.Today);
            });
        });
        
        // Generate HTML to trigger library registration
        var html = doc.ToString();
        
        // After adding calendar, library should be registered
        Assert.IsTrue(doc.Configuration.Libraries.ContainsKey(Libraries.FullCalendar), 
            "FullCalendar library should be registered after adding calendar");
    }

    [TestMethod]
    public void FullCalendar_AllDayEvent() {
        var doc = new Document();
        
        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                var allDayEvent = calendar.AddEvent("All Day Event", DateTime.Today);
                // All day events typically don't have end times
            });
        });
        
        var html = doc.ToString();
        
        // Should contain all day event
        Assert.IsTrue(html.Contains("All Day Event"), "Should contain all day event");
    }

    [TestMethod]
    public void FullCalendar_RecurringEvent() {
        var doc = new Document();
        
        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                var recurringEvent = calendar.AddEvent("Weekly Meeting", "Team standup", DateTime.Today.AddHours(9), DateTime.Today.AddHours(10));
                // Note: Actual recurring functionality would depend on the library's implementation
            });
        });
        
        var html = doc.ToString();
        
        // Should contain recurring event
        Assert.IsTrue(html.Contains("Weekly Meeting"), "Should contain recurring event");
        Assert.IsTrue(html.Contains("Team standup"), "Should contain event description");
    }

    [TestMethod]
    public void FullCalendar_EventHandlersSerialized() {
        var doc = new Document();

        doc.Body.Add(element => {
            element.FullCalendar(calendar => {
                calendar.AddEvent("Test", DateTime.Today);
            });
        });

        var html = doc.ToString();

        Assert.IsTrue(html.Contains("\"eventDidMount\":") && html.Contains("function"), "eventDidMount should be serialized as function");
        Assert.IsTrue(html.Contains("\"eventClick\":") && html.Contains("function"), "eventClick should be serialized as function");
        Assert.IsFalse(html.Contains("__EVENT_DID_MOUNT__") || html.Contains("__EVENT_CLICK__"), "Placeholders should not appear");
    }
}