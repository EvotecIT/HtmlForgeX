namespace HtmlForgeX;

public class TablerSteps : Element {
    private StepsOrientation PrivateOrientation { get; set; } = StepsOrientation.Horizontal;
    private bool PrivateStepCounting { get; set; } = false;
    private TablerColor? PrivateStepsColor { get; set; }
    private List<TablerStepItem> StepItems { get; set; } = new List<TablerStepItem>();

    public TablerSteps Orientation(StepsOrientation orientation) {
        PrivateOrientation = orientation;
        return this;
    }

    public TablerSteps Color(TablerColor color) {
        PrivateStepsColor = color;
        return this;
    }

    public TablerSteps StepCounting() {
        PrivateStepCounting = true;
        return this;
    }

    public TablerSteps AddStep(string text, bool isActive = false) {
        StepItems.Add(new TablerStepItem(text, isActive));
        return this;
    }

    public TablerSteps AddStep(string name, string text, bool isActive = false) {
        StepItems.Add(new TablerStepItem(name, text, isActive));
        return this;
    }

    public override string ToString() {
        var stepsUl = new HtmlTag("ul");

        stepsUl.Class("steps").Class(PrivateOrientation.EnumToString());
        if (PrivateStepCounting) {
            stepsUl.Class("steps-counter");
        }
        stepsUl.Class(PrivateStepsColor?.ToTablerSteps());

        foreach (var stepItem in StepItems) {
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

    public TablerStepItem(string name, bool isActive = false) {
        Name = name;
        IsActive = isActive;
    }

    public TablerStepItem(string name, string text, bool isActive = false) {
        Name = name;
        Text = text;
        IsActive = isActive;
    }

    public TablerStepItem TextStyle(TablerTextStyle textStyle) {
        PrivateTextStyle = textStyle;
        return this;
    }

    public TablerStepItem HeaderStyle(HeaderLevelTag headerStyle) {
        PrivateHeaderLevel = headerStyle;
        return this;
    }

    public override string ToString() {
        return ToString(StepsOrientation.Vertical);
    }

    public string ToString(StepsOrientation orientation) {
        var stepItemLi = new HtmlTag("li");
        stepItemLi.Class("step-item");
        if (IsActive) {
            stepItemLi.Class("active");
        }
        if (orientation == StepsOrientation.Vertical) {
            var nameDiv = new HtmlTag("div").Class(PrivateHeaderLevel.EnumToString()).Class(MarginStyle.EnumToString()).Value(Name);
            var textDiv = new HtmlTag("div").Class(PrivateTextStyle.EnumToString().ToLower()).Value(Text);
            stepItemLi.Value(nameDiv).Value(textDiv);
        } else {
            stepItemLi.Value(Name);
        }

        return stepItemLi.ToString();
    }
}