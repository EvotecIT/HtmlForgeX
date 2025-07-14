namespace HtmlForgeX.Resources;

/// <summary>
/// Provides metadata and asset links for the FullCalendar library.
/// </summary>
public class FullCalendarLibrary : Library {
    /// <summary>
    /// Initializes a new instance of the <see cref="FullCalendarLibrary"/> class.
    /// </summary>
    public FullCalendarLibrary() {
        Header = new LibraryLinks {
            JsLink = ["https://cdn.jsdelivr.net/npm/fullcalendar@6.1.13/index.global.min.js"],
            Js = [
                "fullCalendar.min.js"
            ],
            //CssStyle = [
            //    new Style {
            //        Selector = ".calendarFullCalendar",
            //        Properties = new Dictionary<string, string> {
            //            { "flex-basis", "100%" },
            //            { "margin", "5px" },
            //        }
            //    },
            //],
            JsScript = [@"var calendarTracker = {};"],
        };
        Comment = "FullCalendar library";
        LicenseLink = "https://github.com/fullcalendar/fullcalendar/blob/main/LICENSE.md";
        License = "MIT";
    }
}