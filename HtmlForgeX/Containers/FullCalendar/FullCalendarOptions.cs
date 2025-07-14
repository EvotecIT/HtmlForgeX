namespace HtmlForgeX;

/// <summary>
/// Configuration options for the FullCalendar component.
/// </summary>
public class FullCalendarOptions {
    [JsonConverter(typeof(FullCalendarToolbarConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("headerToolbar")]
    /// <summary>
    /// Gets or sets the toolbar displayed at the top of the calendar.
    /// </summary>
    public FullCalendarToolbar HeaderToolbar { get; set; }

    [JsonConverter(typeof(FullCalendarToolbarConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("footerToolbar")]
    /// <summary>
    /// Gets or sets the toolbar displayed at the bottom of the calendar.
    /// </summary>
    public FullCalendarToolbar FooterToolbar { get; set; }

    [JsonConverter(typeof(Iso8601DateConverter))]
    [JsonPropertyName("initialDate")]
    /// <summary>
    /// Gets or sets the initial date the calendar will display.
    /// </summary>
    public DateTime InitialDate { get; set; } = DateTime.Now;

    [JsonPropertyName("nowIndicator")]
    /// <summary>
    /// Gets or sets a value indicating whether the current time indicator is displayed.
    /// </summary>
    public bool NowIndicator { get; set; }

    [JsonPropertyName("navLinks")]
    /// <summary>
    /// Gets or sets a value indicating whether day and week names act as navigation links.
    /// </summary>
    public bool NavLinks { get; set; }

    [JsonPropertyName("businessHours")]
    /// <summary>
    /// Gets or sets a value indicating whether business hours are highlighted.
    /// </summary>
    public bool BusinessHours { get; set; }

    [JsonPropertyName("editable")]
    /// <summary>
    /// Gets or sets a value indicating whether events can be modified by the user.
    /// </summary>
    public bool Editable { get; set; }

    [JsonPropertyName("dayMaxEventRows")]
    /// <summary>
    /// Gets or sets a value indicating whether to limit events per day and show a "more" link.
    /// </summary>
    public bool DayMaxEventRows { get; set; }

    [JsonPropertyName("weekNumbers")]
    /// <summary>
    /// Gets or sets a value indicating whether week numbers are displayed.
    /// </summary>
    public bool WeekNumbers { get; set; }

    [JsonPropertyName("weekNumberCalculation")]
    /// <summary>
    /// Gets or sets the method used to calculate week numbers.
    /// </summary>
    public string WeekNumberCalculation { get; set; } = "ISO";

    [JsonPropertyName("selectable")]
    /// <summary>
    /// Gets or sets a value indicating whether date range selection is enabled.
    /// </summary>
    public bool Selectable { get; set; }

    [JsonPropertyName("selectMirror")]
    /// <summary>
    /// Gets or sets a value indicating whether a placeholder event is shown when selecting dates.
    /// </summary>
    public bool SelectMirror { get; set; }

    [JsonPropertyName("buttonIcons")]
    /// <summary>
    /// Gets or sets a value indicating whether toolbar buttons use icons.
    /// </summary>
    public bool ButtonIcons { get; set; }

    [JsonConverter(typeof(ViewOptionDictionaryConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("views")]
    /// <summary>
    /// Gets or sets configuration for custom calendar views.
    /// </summary>
    public Dictionary<FullCalendarViewOption, FullCalendarView> Views { get; set; } = new Dictionary<FullCalendarViewOption, FullCalendarView> {
        [FullCalendarViewOption.ListWeek] = new FullCalendarView { ButtonText = "list week" },
        [FullCalendarViewOption.ListMonth] = new FullCalendarView { ButtonText = "list month" },
        [FullCalendarViewOption.ListYear] = new FullCalendarView { ButtonText = "list year" },
        [FullCalendarViewOption.ListDay] = new FullCalendarView { ButtonText = "list day" }
    };

    [JsonPropertyName("events")]
    /// <summary>
    /// Gets or sets the collection of calendar events.
    /// </summary>
    public List<FullCalendarEvent> Events { get; set; } = new List<FullCalendarEvent>();

    [JsonPropertyName("eventTimeFormat")]
    /// <summary>
    /// Gets or sets the time formatting options for event rendering.
    /// </summary>
    public FullCalendarEventTimeFormat EventTimeFormat { get; set; } = new FullCalendarEventTimeFormat();

    [JsonPropertyName("slotLabelFormat")]
    /// <summary>
    /// Gets or sets the format used for slot labels.
    /// </summary>
    public FullCalendarEventTimeFormat TimeFormat { get; set; } = new FullCalendarEventTimeFormat();

    [JsonConverter(typeof(JavaScriptFunctionConverter))]
    [JsonPropertyName("eventDidMount")]
    /// <summary>
    /// Gets or sets JavaScript executed when an event element is added to the DOM.
    /// </summary>
    public string EventDidMount { get; set; } = @"
        function (info) {
            var tooltip = new Tooltip(info.el, {
                title: info.event.extendedProps.description,
                placement: 'top',
                trigger: 'hover',
                container: 'body'
            });
        }
    ";

    [JsonConverter(typeof(JavaScriptFunctionConverter))]
    [JsonPropertyName("eventClick")]
    /// <summary>
    /// Gets or sets JavaScript executed when an event is clicked.
    /// </summary>
    public string EventClick { get; set; } = @"
        function (info) {
            var eventObj = info.event;
            if (eventObj.extendedProps.targetName) {
                window.open(eventObj.url, eventObj.extendedProps.targetName);
                info.jsEvent.preventDefault(); // prevents browser from following link in current tab.
            }
        }
    ";
}