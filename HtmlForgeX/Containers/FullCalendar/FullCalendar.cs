namespace HtmlForgeX;

public class FullCalendar : Element {
    public string Id { get; set; }

    public List<FullCalendarEvent> Events {
        get => Options.Events;
        set => Options.Events = value;
    }

    public FullCalendar NowIndicator(bool value) {
        Options.NowIndicator = value;
        return this;
    }

    public FullCalendar NavLinks(bool value) {
        Options.NavLinks = value;
        return this;
    }

    public FullCalendar BusinessHours(bool value) {
        Options.BusinessHours = value;
        return this;
    }

    public FullCalendar Selectable(bool value) {
        Options.Selectable = value;
        return this;
    }

    public FullCalendar SelectMirror(bool value) {
        Options.SelectMirror = value;
        return this;
    }

    public FullCalendar ButtonIcons(bool value) {
        Options.ButtonIcons = value;
        return this;
    }

    public FullCalendar DayMaxEventRows(bool value) {
        Options.DayMaxEventRows = value;
        return this;
    }

    public FullCalendar WeekNumbers(bool value) {
        Options.WeekNumbers = value;
        return this;
    }

    public FullCalendar WeekNumberCalculation(string value) {
        Options.WeekNumberCalculation = value;
        return this;
    }

    public FullCalendar Editable(bool value) {
        Options.Editable = value;
        return this;
    }

    public FullCalendar InitialDate(DateTime value) {
        Options.InitialDate = value;
        return this;
    }

    public FullCalendarOptions Options { get; set; } = new FullCalendarOptions();

    public FullCalendar() {
        // add library to the global storage, for HTML processing
        GlobalStorage.Libraries.Add(Libraries.FullCalendar);
        GlobalStorage.Libraries.Add(Libraries.Popper);
        Id = GlobalStorage.GenerateRandomId("fullCalendar");
    }

    public override string ToString() {
        var jsonOptions = new JsonSerializerOptions {
            WriteIndented = true
        };

        var divTag = new HtmlTag("div").Attribute("id", Id).Attribute("class", "calendarFullCalendar");
        var serializedOptions = System.Text.Json.JsonSerializer.Serialize(Options, jsonOptions);
        serializedOptions = serializedOptions.Replace("\"__EVENT_DID_MOUNT__\"", Options.EventDidMount);
        serializedOptions = serializedOptions.Replace("\"__EVENT_CLICK__\"", Options.EventClick);
        var scriptTag = new HtmlTag("script").Value($@"
        document.addEventListener('DOMContentLoaded', function () {{
                var calendarEl = document.getElementById('{Id}');
                var calendar = new FullCalendar.Calendar(calendarEl, {serializedOptions});
                calendar.render();
            }});
        ");

        return divTag + scriptTag.ToString();
    }


    public FullCalendarEvent AddEvent(string title, string description, DateTime start, DateTime? end = null) {
        var eventItem = new FullCalendarEvent(title, description, start, end);
        Events.Add(eventItem);
        return eventItem;
    }

    public FullCalendarEvent AddEvent(string title, DateTime start) {
        var eventItem = new FullCalendarEvent(title, start);
        Events.Add(eventItem);
        return eventItem;
    }

    public FullCalendarEvent AddEvent(FullCalendarEvent eventItem) {
        Events.Add(eventItem);
        return eventItem;
    }

    public FullCalendarToolbar AddHeaderToolbar() {
        var toolbar = new FullCalendarToolbar();
        Options.HeaderToolbar = toolbar;
        return toolbar;
    }

    public FullCalendarToolbar AddFooterToolbar() {
        var toolbar = new FullCalendarToolbar();
        Options.FooterToolbar = toolbar;
        return toolbar;
    }
}
