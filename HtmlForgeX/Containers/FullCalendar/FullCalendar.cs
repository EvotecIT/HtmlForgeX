namespace HtmlForgeX;

/// <summary>
/// Represents a FullCalendar instance used to display events.
/// </summary>
public class FullCalendar : Element {
    /// <summary>
    /// Gets or sets the identifier of the calendar container.
    /// </summary>
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets events displayed on the calendar.
    /// </summary>
    public List<FullCalendarEvent> Events {
        get => Options.Events;
        set => Options.Events = value;
    }

    /// <summary>
    /// Enables or disables the now indicator.
    /// </summary>
    /// <param name="value">Whether the indicator should be displayed.</param>
    /// <returns>The current <see cref="FullCalendar"/> instance.</returns>
    public FullCalendar NowIndicator(bool value) {
        Options.NowIndicator = value;
        return this;
    }

    /// <summary>
    /// Toggles navigation links on day/week names.
    /// </summary>
    /// <param name="value">Whether navigation links are enabled.</param>
    /// <returns>The current instance.</returns>
    public FullCalendar NavLinks(bool value) {
        Options.NavLinks = value;
        return this;
    }

    /// <summary>
    /// Sets whether business hours are highlighted.
    /// </summary>
    /// <param name="value">If set to <c>true</c>, business hours will be shown.</param>
    /// <returns>The current instance.</returns>
    public FullCalendar BusinessHours(bool value) {
        Options.BusinessHours = value;
        return this;
    }

    /// <summary>
    /// Defines whether dates can be selected.
    /// </summary>
    /// <param name="value">If <c>true</c>, date selection is allowed.</param>
    /// <returns>The current instance.</returns>
    public FullCalendar Selectable(bool value) {
        Options.Selectable = value;
        return this;
    }

    /// <summary>
    /// Mirrors selection to create an event-like placeholder.
    /// </summary>
    /// <param name="value">Whether mirror selection is active.</param>
    /// <returns>The current instance.</returns>
    public FullCalendar SelectMirror(bool value) {
        Options.SelectMirror = value;
        return this;
    }

    /// <summary>
    /// Determines if button text should use icons.
    /// </summary>
    /// <param name="value">If <c>true</c>, icons will be used.</param>
    /// <returns>The current instance.</returns>
    public FullCalendar ButtonIcons(bool value) {
        Options.ButtonIcons = value;
        return this;
    }

    /// <summary>
    /// Sets whether days should display a "more" link when too many events exist.
    /// </summary>
    /// <param name="value">If <c>true</c>, event rows will be collapsed.</param>
    /// <returns>The current instance.</returns>
    public FullCalendar DayMaxEventRows(bool value) {
        Options.DayMaxEventRows = value;
        return this;
    }

    /// <summary>
    /// Shows or hides week numbers.
    /// </summary>
    /// <param name="value">Whether week numbers are displayed.</param>
    /// <returns>The current instance.</returns>
    public FullCalendar WeekNumbers(bool value) {
        Options.WeekNumbers = value;
        return this;
    }

    /// <summary>
    /// Sets the week number calculation method.
    /// </summary>
    /// <param name="value">The calculation mode.</param>
    /// <returns>The current instance.</returns>
    public FullCalendar WeekNumberCalculation(string value) {
        Options.WeekNumberCalculation = value;
        return this;
    }

    /// <summary>
    /// Enables or disables event editing via drag and drop.
    /// </summary>
    /// <param name="value">If <c>true</c>, events can be edited.</param>
    /// <returns>The current instance.</returns>
    public FullCalendar Editable(bool value) {
        Options.Editable = value;
        return this;
    }

    /// <summary>
    /// Sets the initial date displayed by the calendar.
    /// </summary>
    /// <param name="value">Initial date.</param>
    /// <returns>The current instance.</returns>
    public FullCalendar InitialDate(DateTime value) {
        Options.InitialDate = value;
        return this;
    }

    /// <summary>
    /// Gets or sets configuration options for the calendar.
    /// </summary>
    public FullCalendarOptions Options { get; set; } = new FullCalendarOptions();

    /// <summary>
    /// Initializes a new instance of the <see cref="FullCalendar"/> class with a random identifier.
    /// </summary>
    public FullCalendar() {
        // Libraries will be registered via RegisterLibraries method
        Id = GlobalStorage.GenerateRandomId("fullCalendar");
    }

    /// <summary>
    /// Registers the required libraries for FullCalendar.
    /// </summary>
    /// <summary>
    /// Registers FullCalendar JavaScript libraries within the document.
    /// </summary>
    protected internal override void RegisterLibraries() {
        Document?.Configuration.Libraries.TryAdd(Libraries.FullCalendar, 0);
        Document?.Configuration.Libraries.TryAdd(Libraries.Popper, 0);
    }

    /// <summary>
    /// Builds the HTML and script necessary to render the calendar.
    /// </summary>
    /// <returns>The HTML string representation.</returns>
    public override string ToString() {
        var jsonOptions = new JsonSerializerOptions {
            WriteIndented = true
        };

        var divTag = new HtmlTag("div").Attribute("id", Id).Attribute("class", "calendarFullCalendar");
        var serializedOptions = System.Text.Json.JsonSerializer.Serialize(Options, jsonOptions);
        var scriptTag = new HtmlTag("script").Value($@"
        document.addEventListener('DOMContentLoaded', function () {{
            var calendarEl = document.getElementById('{Id}');
                var calendar = new FullCalendar.Calendar(calendarEl, {serializedOptions});
            calendar.render();
        }});
    ");

        return divTag + scriptTag.ToString();
    }


    /// <summary>
    /// Adds a new event to the calendar with a description.
    /// </summary>
    /// <param name="title">Event title.</param>
    /// <param name="description">Event description.</param>
    /// <param name="start">Start date.</param>
    /// <param name="end">Optional end date.</param>
    /// <returns>The created event.</returns>
    public FullCalendarEvent AddEvent(string title, string description, DateTime start, DateTime? end = null) {
        var eventItem = new FullCalendarEvent(title, description, start, end);
        Events.Add(eventItem);
        return eventItem;
    }

    /// <summary>
    /// Adds a new single-day event to the calendar.
    /// </summary>
    /// <param name="title">Event title.</param>
    /// <param name="start">Start date.</param>
    /// <returns>The created event.</returns>
    public FullCalendarEvent AddEvent(string title, DateTime start) {
        var eventItem = new FullCalendarEvent(title, start);
        Events.Add(eventItem);
        return eventItem;
    }

    /// <summary>
    /// Adds an existing event instance to the calendar.
    /// </summary>
    /// <param name="eventItem">Event instance.</param>
    /// <returns>The added event.</returns>
    public FullCalendarEvent AddEvent(FullCalendarEvent eventItem) {
        Events.Add(eventItem);
        return eventItem;
    }

    /// <summary>
    /// Adds and returns a toolbar displayed at the top of the calendar.
    /// </summary>
    /// <returns>The created toolbar.</returns>
    public FullCalendarToolbar AddHeaderToolbar() {
        var toolbar = new FullCalendarToolbar();
        Options.HeaderToolbar = toolbar;
        return toolbar;
    }

    /// <summary>
    /// Adds and returns a toolbar displayed at the bottom of the calendar.
    /// </summary>
    /// <returns>The created toolbar.</returns>
    public FullCalendarToolbar AddFooterToolbar() {
        var toolbar = new FullCalendarToolbar();
        Options.FooterToolbar = toolbar;
        return toolbar;
    }
}
