using System.Collections.Generic;

namespace HtmlForgeX;

/// <summary>
/// Tabler card body component with fluent API - no raw HTML required
/// </summary>
public class TablerCardBody : Element {
    private string? TitleText { get; set; }
    private string? BodyText { get; set; }
    private List<TablerCardText> TextElements { get; set; } = new List<TablerCardText>();
    private List<TablerCardList> Lists { get; set; } = new List<TablerCardList>();
    private List<TablerDataGrid> DataGrids { get; set; } = new List<TablerDataGrid>();
    private TablerCardImage? BodyImage { get; set; }
    private TablerCardAlignment Alignment { get; set; } = TablerCardAlignment.Start;

    /// <summary>
    /// Set the card body title
    /// </summary>
    public TablerCardBody Title(string title) {
        TitleText = title;
        return this;
    }

    /// <summary>
    /// Set the main body text
    /// </summary>
    public TablerCardBody Text(string text) {
        BodyText = text;
        return this;
    }

    /// <summary>
    /// Add formatted text element
    /// </summary>
    public TablerCardBody AddText(Action<TablerCardText> textConfig) {
        var textElement = new TablerCardText();
        textConfig(textElement);
        TextElements.Add(textElement);
        return this;
    }

    /// <summary>
    /// Add a list to the card body
    /// </summary>
    public TablerCardBody AddList(Action<TablerCardList> listConfig) {
        var list = new TablerCardList();
        listConfig(list);
        Lists.Add(list);
        return this;
    }

    /// <summary>
    /// Add a DataGrid to the card body using the enhanced TablerDataGrid component
    /// </summary>
    public TablerCardBody DataGrid(Action<TablerDataGrid> dataGridConfig) {
        var dataGrid = new TablerDataGrid();
        dataGridConfig(dataGrid);
        DataGrids.Add(dataGrid);
        return this;
    }

    /// <summary>
    /// Add an image to the card body
    /// </summary>
    public TablerCardBody Image(Action<TablerCardImage> imageConfig) {
        BodyImage = new TablerCardImage();
        imageConfig(BodyImage);
        return this;
    }

    /// <summary>
    /// Set content alignment
    /// </summary>
    public TablerCardBody Align(TablerCardAlignment alignment) {
        Alignment = alignment;
        return this;
    }

    public override string ToString() {
        var bodyDiv = new HtmlTag("div");
        var classes = new List<string> { "card-body" };

        // Add alignment classes
        var alignmentClass = Alignment.ToTablerCardAlignmentClass();
        if (!string.IsNullOrEmpty(alignmentClass)) {
            classes.Add(alignmentClass);
        }

        bodyDiv.Class(string.Join(" ", classes));

        // Add title if specified
        if (!string.IsNullOrEmpty(TitleText)) {
            var titleElement = new HtmlTag("h3").Class("card-title").Value(TitleText);
            bodyDiv.Value(titleElement);
        }

        // Add main text if specified
        if (!string.IsNullOrEmpty(BodyText)) {
            var textElement = new HtmlTag("p").Value(BodyText);
            bodyDiv.Value(textElement);
        }

        // Add formatted text elements
        foreach (var textElement in TextElements) {
            bodyDiv.Value(textElement.ToString());
        }

        // Add lists
        foreach (var list in Lists) {
            bodyDiv.Value(list.ToString());
        }

        // Add DataGrids
        foreach (var dataGrid in DataGrids) {
            bodyDiv.Value(dataGrid.ToString());
        }

        // Add image if specified
        if (BodyImage != null) {
            bodyDiv.Value(BodyImage.ToString());
        }

        return bodyDiv.ToString();
    }
}

/// <summary>
/// Formatted text element for card bodies
/// </summary>
public class TablerCardText : Element {
    private string? Content { get; set; }
    private TablerTextStyle TextStyle { get; set; } = TablerTextStyle.Muted;
    private TablerFontWeight FontWeight { get; set; } = TablerFontWeight.Medium;
    private TablerColor? TextColor { get; set; }
    private TablerTextAlignment TextAlignment { get; set; } = TablerTextAlignment.Start;
    private bool IsStrong { get; set; } = false;
    private bool IsEmphasized { get; set; } = false;
    private string HtmlTag { get; set; } = "p";

    public TablerCardText WithContent(string content) {
        Content = content;
        return this;
    }

    public TablerCardText Style(TablerTextStyle style) {
        TextStyle = style;
        return this;
    }

    public TablerCardText Weight(TablerFontWeight weight) {
        FontWeight = weight;
        return this;
    }

    public TablerCardText Color(TablerColor color) {
        TextColor = color;
        return this;
    }

    public TablerCardText Align(TablerTextAlignment alignment) {
        TextAlignment = alignment;
        return this;
    }

    public TablerCardText Strong() {
        IsStrong = true;
        return this;
    }

    public TablerCardText Emphasized() {
        IsEmphasized = true;
        return this;
    }

    public TablerCardText Tag(string tag) {
        HtmlTag = tag;
        return this;
    }

    public override string ToString() {
        var textElement = new HtmlTag(HtmlTag);
        var classes = new List<string>();

        // Add text style classes
        var styleClass = TextStyle.EnumToString();
        if (!string.IsNullOrEmpty(styleClass)) {
            classes.Add(styleClass);
        }

        // Add weight classes
        var weightClass = GetFontWeightClass(FontWeight);
        if (!string.IsNullOrEmpty(weightClass)) {
            classes.Add(weightClass);
        }

        // Add color classes
        if (TextColor.HasValue) {
            classes.Add(TextColor.Value.ToTablerText());
        }

        // Add alignment classes
        var alignmentClass = TextAlignment.ToTablerTextAlignmentClass();
        if (!string.IsNullOrEmpty(alignmentClass)) {
            classes.Add(alignmentClass);
        }

        if (classes.Count > 0) {
            textElement.Class(string.Join(" ", classes));
        }

        // Wrap content in formatting tags if needed
        var content = Content ?? "";
        if (IsStrong) {
            content = $"<strong>{content}</strong>";
        }
        if (IsEmphasized) {
            content = $"<em>{content}</em>";
        }

        textElement.Value(content);
        return textElement.ToString();
    }

    private static string GetFontWeightClass(TablerFontWeight weight) {
        return weight switch {
            TablerFontWeight.Medium => "fw-medium",
            _ => ""
        };
    }
}

/// <summary>
/// Text alignment options
/// </summary>
public enum TablerTextAlignment {
    Start,
    Center,
    End,
    Justify
}

/// <summary>
/// Extension methods for text alignment
/// </summary>
public static class TablerTextAlignmentExtensions {
    public static string ToTablerTextAlignmentClass(this TablerTextAlignment alignment) {
        return alignment switch {
            TablerTextAlignment.Start => "text-start",
            TablerTextAlignment.Center => "text-center",
            TablerTextAlignment.End => "text-end",
            TablerTextAlignment.Justify => "text-justify",
            _ => ""
        };
    }
}