using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

public class TablerSteps : Element {
    private StepsOrientation PrivateOrientation { get; set; } = StepsOrientation.Horizontal;
    private bool PrivateStepCounting { get; set; } = false;
    private TablerColor? PrivateStepsColor { get; set; }
    private TablerMarginStyle? PrivateMargin { get; set; } = TablerMarginStyle.MY4; // Default margin like Tabler examples
    private List<TablerStepItem> StepItems { get; set; } = new List<TablerStepItem>();

/// <summary>
/// Method Orientation.
/// </summary>
    public TablerSteps Orientation(StepsOrientation orientation) {
        PrivateOrientation = orientation;
        return this;
    }

/// <summary>
/// Method Color.
/// </summary>
    public TablerSteps Color(TablerColor color) {
        PrivateStepsColor = color;
        return this;
    }

/// <summary>
/// Method StepCounting.
/// </summary>
    public TablerSteps StepCounting() {
        PrivateStepCounting = true;
        return this;
    }

/// <summary>
/// Method Margin.
/// </summary>
    public TablerSteps Margin(TablerMarginStyle margin) {
        PrivateMargin = margin;
        return this;
    }

/// <summary>
/// Method AddStep.
/// </summary>
    public TablerSteps AddStep(string text, bool isActive = false) {
        StepItems.Add(new TablerStepItem(text, isActive));
        return this;
    }

/// <summary>
/// Method AddStep.
/// </summary>
    public TablerSteps AddStep(string name, string text, bool isActive = false) {
        StepItems.Add(new TablerStepItem(name, text, isActive));
        return this;
    }

    /// <summary>
    /// Adds a step with a specific state (Pending, Active, Completed)
    /// </summary>
    public TablerSteps AddStep(string text, TablerStepState state) {
        StepItems.Add(new TablerStepItem(text, state));
        return this;
    }

    /// <summary>
    /// Adds a step with name, text and state
    /// </summary>
    public TablerSteps AddStep(string name, string text, TablerStepState state) {
        StepItems.Add(new TablerStepItem(name, text, state));
        return this;
    }

    /// <summary>
    /// Adds a clickable step with URL
    /// </summary>
    public TablerSteps AddClickableStep(string text, string url, TablerStepState state = TablerStepState.Pending) {
        StepItems.Add(new TablerStepItem(text, state).Url(url));
        return this;
    }

    /// <summary>
    /// Adds a clickable step with name, text, and URL
    /// </summary>
    public TablerSteps AddClickableStep(string name, string text, string url, TablerStepState state = TablerStepState.Pending) {
        StepItems.Add(new TablerStepItem(name, text, state).Url(url));
        return this;
    }

/// <summary>
/// Method ToString.
/// </summary>
    public override string ToString() {
        var stepsUl = new HtmlTag("ul");

        stepsUl.Class("steps").Class(PrivateOrientation.EnumToString());
        if (PrivateStepCounting) {
            stepsUl.Class("steps-counter");
        }
        stepsUl.Class(PrivateStepsColor?.ToTablerSteps());
        if (PrivateMargin.HasValue) {
            stepsUl.Class(PrivateMargin.Value.EnumToString());
        }

        // Add custom styling to remove unwanted connecting lines between steps
        stepsUl.Style("--step-border-color", "transparent")
               .Style("--step-border-width", "0")  
               .Style("border", "none");

        foreach (var stepItem in StepItems.WhereNotNull()) {
            stepsUl.Value(stepItem.ToString(PrivateOrientation));
        }

        return stepsUl.ToString();
    }
}


public class TablerStepItem : Element {
    private string Name { get; set; } = "";
    private new string Text { get; set; } = "";

    private HeaderLevelTag PrivateHeaderLevel { get; set; } = HeaderLevelTag.H4;
    private TablerMarginStyle MarginStyle { get; set; } = TablerMarginStyle.M0;
    private TablerTextStyle PrivateTextStyle { get; set; } = TablerTextStyle.Muted;

    private bool IsActive { get; set; } = false;
    private TablerStepState PrivateStepState { get; set; } = TablerStepState.Pending;
    private string PrivateUrl { get; set; } = "";
    private string PrivateTooltip { get; set; } = "";

    public TablerStepItem(string name, bool isActive = false) {
        Name = name;
        IsActive = isActive;
        PrivateStepState = isActive ? TablerStepState.Active : TablerStepState.Pending;
    }

    public TablerStepItem(string name, string text, bool isActive = false) {
        Name = name;
        Text = text;
        IsActive = isActive;
        PrivateStepState = isActive ? TablerStepState.Active : TablerStepState.Pending;
    }

    public TablerStepItem(string name, TablerStepState state) {
        Name = name;
        PrivateStepState = state;
        IsActive = state == TablerStepState.Active;
    }

    public TablerStepItem(string name, string text, TablerStepState state) {
        Name = name;
        Text = text;
        PrivateStepState = state;
        IsActive = state == TablerStepState.Active;
    }

/// <summary>
/// Method TextStyle.
/// </summary>
    public TablerStepItem TextStyle(TablerTextStyle textStyle) {
        PrivateTextStyle = textStyle;
        return this;
    }

/// <summary>
/// Method HeaderStyle.
/// </summary>
    public TablerStepItem HeaderStyle(HeaderLevelTag headerStyle) {
        PrivateHeaderLevel = headerStyle;
        return this;
    }

    /// <summary>
    /// Makes the step clickable with the specified URL
    /// </summary>
    public TablerStepItem Url(string url) {
        PrivateUrl = url;
        return this;
    }

    /// <summary>
    /// Adds a tooltip to the step
    /// </summary>
    public TablerStepItem Tooltip(string tooltip) {
        PrivateTooltip = tooltip;
        return this;
    }

    /// <summary>
    /// Sets the step state (Pending, Active, Completed)
    /// </summary>
    public TablerStepItem State(TablerStepState state) {
        PrivateStepState = state;
        IsActive = state == TablerStepState.Active;
        return this;
    }

/// <summary>
/// Method ToString.
/// </summary>
    public override string ToString() {
        return ToString(StepsOrientation.Vertical);
    }

/// <summary>
/// Method ToString.
/// </summary>
    public string ToString(StepsOrientation orientation) {
        var stepItemLi = new HtmlTag("li");
        stepItemLi.Class("step-item");
        
        // Apply state classes
        switch (PrivateStepState) {
            case TablerStepState.Active:
                stepItemLi.Class("active");
                break;
            case TablerStepState.Completed:
                stepItemLi.Class("completed");
                break;
            case TablerStepState.Pending:
                // No additional class needed for pending
                break;
        }
        
        // Add tooltip if specified
        if (!string.IsNullOrEmpty(PrivateTooltip)) {
            stepItemLi.Attribute("data-bs-toggle", "tooltip");
            stepItemLi.Attribute("title", PrivateTooltip);
        }
        
        // Determine if this should be clickable
        bool isClickable = !string.IsNullOrEmpty(PrivateUrl);
        
        if (isClickable) {
            // Create clickable step with <a> tag
            var linkTag = new HtmlTag("a").Attribute("href", PrivateUrl);
            
            if (orientation == StepsOrientation.Vertical) {
                var nameDiv = new HtmlTag("div").Class(PrivateHeaderLevel.EnumToString()).Class(MarginStyle.EnumToString()).Value(Name);
                var textDiv = new HtmlTag("div").Class(PrivateTextStyle.EnumToString().ToLower()).Value(Text);
                linkTag.Value(nameDiv).Value(textDiv);
            } else {
                linkTag.Value(Name);
            }
            
            stepItemLi.Value(linkTag);
        } else {
            // Create non-clickable step with <span> or direct content
            if (orientation == StepsOrientation.Vertical) {
                var nameDiv = new HtmlTag("div").Class(PrivateHeaderLevel.EnumToString()).Class(MarginStyle.EnumToString()).Value(Name);
                var textDiv = new HtmlTag("div").Class(PrivateTextStyle.EnumToString().ToLower()).Value(Text);
                stepItemLi.Value(nameDiv).Value(textDiv);
            } else {
                var spanTag = new HtmlTag("span").Value(Name);
                stepItemLi.Value(spanTag);
            }
        }

        return stepItemLi.ToString();
    }
}