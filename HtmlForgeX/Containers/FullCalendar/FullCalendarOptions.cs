namespace HtmlForgeX;

/// <summary>
/// Configuration options for the FullCalendar component.
/// </summary>
public class FullCalendarOptions {
    /// <summary>
    /// Gets or sets the toolbar displayed at the top of the calendar.
    /// </summary>
    [JsonConverter(typeof(FullCalendarToolbarConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("headerToolbar")]
    public FullCalendarToolbar? HeaderToolbar { get; set; }

    /// <summary>
    /// Gets or sets the toolbar displayed at the bottom of the calendar.
    /// </summary>
    [JsonConverter(typeof(FullCalendarToolbarConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("footerToolbar")]
    public FullCalendarToolbar? FooterToolbar { get; set; }

    /// <summary>
    /// Gets or sets the initial date the calendar will display.
    /// </summary>
    [JsonConverter(typeof(Iso8601DateConverter))]
    [JsonPropertyName("initialDate")]
    public DateTime InitialDate { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets a value indicating whether the current time indicator is displayed.
    /// </summary>
    [JsonPropertyName("nowIndicator")]
    public bool NowIndicator { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether day and week names act as navigation links.
    /// </summary>
    [JsonPropertyName("navLinks")]
    public bool NavLinks { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether business hours are highlighted.
    /// </summary>
    [JsonPropertyName("businessHours")]
    public bool BusinessHours { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether events can be modified by the user.
    /// </summary>
    [JsonPropertyName("editable")]
    public bool Editable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to limit events per day and show a "more" link.
    /// </summary>
    [JsonPropertyName("dayMaxEventRows")]
    public bool DayMaxEventRows { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether week numbers are displayed.
    /// </summary>
    [JsonPropertyName("weekNumbers")]
    public bool WeekNumbers { get; set; }

    /// <summary>
    /// Gets or sets the method used to calculate week numbers.
    /// </summary>
    [JsonPropertyName("weekNumberCalculation")]
    public string WeekNumberCalculation { get; set; } = "ISO";

    /// <summary>
    /// Gets or sets a value indicating whether date range selection is enabled.
    /// </summary>
    [JsonPropertyName("selectable")]
    public bool Selectable { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether a placeholder event is shown when selecting dates.
    /// </summary>
    [JsonPropertyName("selectMirror")]
    public bool SelectMirror { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether toolbar buttons use icons.
    /// </summary>
    [JsonPropertyName("buttonIcons")]
    public bool ButtonIcons { get; set; }

    /// <summary>
    /// Gets or sets configuration for custom calendar views.
    /// </summary>
    [JsonConverter(typeof(ViewOptionDictionaryConverter))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    [JsonPropertyName("views")]
    public Dictionary<FullCalendarViewOption, FullCalendarView> Views { get; set; } = new Dictionary<FullCalendarViewOption, FullCalendarView> {
        [FullCalendarViewOption.ListWeek] = new FullCalendarView { ButtonText = "list week" },
        [FullCalendarViewOption.ListMonth] = new FullCalendarView { ButtonText = "list month" },
        [FullCalendarViewOption.ListYear] = new FullCalendarView { ButtonText = "list year" },
        [FullCalendarViewOption.ListDay] = new FullCalendarView { ButtonText = "list day" }
    };

    /// <summary>
    /// Gets or sets the collection of calendar events.
    /// </summary>
    [JsonPropertyName("events")]
    public List<FullCalendarEvent> Events { get; set; } = new List<FullCalendarEvent>();

    /// <summary>
    /// Gets or sets the time formatting options for event rendering.
    /// </summary>
    [JsonPropertyName("eventTimeFormat")]
    public FullCalendarEventTimeFormat EventTimeFormat { get; set; } = new FullCalendarEventTimeFormat();

    /// <summary>
    /// Gets or sets the format used for slot labels.
    /// </summary>
    [JsonPropertyName("slotLabelFormat")]
    public FullCalendarEventTimeFormat TimeFormat { get; set; } = new FullCalendarEventTimeFormat();

    /// <summary>
    /// Gets or sets JavaScript executed when an event element is added to the DOM.
    /// </summary>
    [JsonConverter(typeof(JavaScriptFunctionConverter))]
    [JsonPropertyName("eventDidMount")]
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

    /// <summary>
    /// Gets or sets JavaScript executed when an event is clicked.
    /// </summary>
    [JsonConverter(typeof(JavaScriptFunctionConverter))]
    [JsonPropertyName("eventClick")]
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