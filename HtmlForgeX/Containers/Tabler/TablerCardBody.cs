using System.Collections.Generic;

using HtmlForgeX.Extensions;

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
    /// Add text to the body (appends instead of replacing)
    /// </summary>
    public new TablerText Text(string text) {
        // Create a TablerText element that supports Tabler styling
        var tablerText = new TablerText(text);
        this.Add(tablerText);
        return tablerText;
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
    public new TablerCardBody DataGrid(Action<TablerDataGrid> dataGridConfig) {
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

    /// <summary>
    /// Apply text style to the card body
    /// </summary>
    public TablerCardBody Style(TablerTextStyle style) {
        // This method is for fluent API compatibility with examples
        // The actual styling is handled by individual text elements
        return this;
    }

    /// <summary>
    /// Apply font weight to the card body
    /// </summary>
    public TablerCardBody Weight(TablerFontWeight weight) {
        // This method is for fluent API compatibility with examples
        // The actual weight is handled by individual text elements
        return this;
    }

    /// <summary>
    /// Hide inherited Document property to ensure proper propagation to children
    /// </summary>
    public new Document? Document {
        get => base.Document;
        set {
            base.Document = value;
            // Ensure all existing children get the Document reference
            foreach (var child in Children.WhereNotNull()) {
                child.Document = value;
            }
        }
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
    public override string ToString() {
        // CRITICAL FIX: Ensure all children have proper Document references before rendering
        EnsureChildrenHaveDocumentReference();

        // ADDITIONAL FIX: Force library registration for any children that may have missed it
        foreach (var child in Children.WhereNotNull()) {
            if (child.Document != null) {
                child.RegisterLibraries();
            }
        }

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
            // Ensure Document reference for internal elements
            if (textElement.Document == null && this.Document != null) {
                textElement.Document = this.Document;
                textElement.Email = this.Email;
            }
            bodyDiv.Value(textElement.ToString());
        }

        // Add lists
        foreach (var list in Lists) {
            // Ensure Document reference for internal elements
            if (list.Document == null && this.Document != null) {
                list.Document = this.Document;
                list.Email = this.Email;
            }
            bodyDiv.Value(list.ToString());
        }

        // Add DataGrids
        foreach (var dataGrid in DataGrids) {
            // Ensure Document reference for internal elements
            if (dataGrid.Document == null && this.Document != null) {
                dataGrid.Document = this.Document;
                dataGrid.Email = this.Email;
            }
            bodyDiv.Value(dataGrid.ToString());
        }

        // Add image if specified
        if (BodyImage != null) {
            // Ensure Document reference for internal elements
            if (BodyImage.Document == null && this.Document != null) {
                BodyImage.Document = this.Document;
                BodyImage.Email = this.Email;
            }
            bodyDiv.Value(BodyImage.ToString());
        }

        // Add any child elements that were added directly (e.g., via extension methods)
        foreach (var child in Children.WhereNotNull()) {
            bodyDiv.Value(child.ToString());
        }

        return bodyDiv.ToString();
    }

    /// <summary>
    /// Ensures all children have proper Document and Email references for library registration
    /// </summary>
    private void EnsureChildrenHaveDocumentReference() {
        if (this.Document == null) return;

        foreach (var child in Children.WhereNotNull()) {
            if (child.Document == null) {
                child.Document = this.Document;
                child.Email = this.Email;
                // Call OnAddedToDocument to trigger library registration
                child.OnAddedToDocument();
            }
        }
    }

    /// <summary>
    /// Override to ensure child elements have Document reference when initially added to document
    /// </summary>
    protected internal override void OnAddedToDocument() {
        // Propagate Document reference to all child elements and internal collections
        EnsureChildrenHaveDocumentReference();

        // Also propagate to internal element collections
        foreach (var textElement in TextElements) {
            if (textElement.Document == null && this.Document != null) {
                textElement.Document = this.Document;
                textElement.Email = this.Email;
                textElement.OnAddedToDocument();
            }
        }

        foreach (var list in Lists) {
            if (list.Document == null && this.Document != null) {
                list.Document = this.Document;
                list.Email = this.Email;
                list.OnAddedToDocument();
            }
        }

        foreach (var dataGrid in DataGrids) {
            if (dataGrid.Document == null && this.Document != null) {
                dataGrid.Document = this.Document;
                dataGrid.Email = this.Email;
                dataGrid.OnAddedToDocument();
            }
        }

        if (BodyImage != null && BodyImage.Document == null && this.Document != null) {
            BodyImage.Document = this.Document;
            BodyImage.Email = this.Email;
            BodyImage.OnAddedToDocument();
        }

        // Call base implementation to register our own libraries
        base.OnAddedToDocument();
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

    /// <summary>
    /// Initializes or configures WithContent.
    /// </summary>
    public TablerCardText WithContent(string content) {
        Content = content;
        return this;
    }

    /// <summary>
    /// Initializes or configures Style.
    /// </summary>
    public TablerCardText Style(TablerTextStyle style) {
        TextStyle = style;
        return this;
    }

    /// <summary>
    /// Initializes or configures Weight.
    /// </summary>
    public TablerCardText Weight(TablerFontWeight weight) {
        FontWeight = weight;
        return this;
    }

    /// <summary>
    /// Initializes or configures Color.
    /// </summary>
    public TablerCardText Color(TablerColor color) {
        TextColor = color;
        return this;
    }

    /// <summary>
    /// Initializes or configures Align.
    /// </summary>
    public TablerCardText Align(TablerTextAlignment alignment) {
        TextAlignment = alignment;
        return this;
    }

    /// <summary>
    /// Initializes or configures Strong.
    /// </summary>
    public TablerCardText Strong() {
        IsStrong = true;
        return this;
    }

    /// <summary>
    /// Initializes or configures Emphasized.
    /// </summary>
    public TablerCardText Emphasized() {
        IsEmphasized = true;
        return this;
    }

    /// <summary>
    /// Initializes or configures Tag.
    /// </summary>
    public TablerCardText Tag(string tag) {
        HtmlTag = tag;
        return this;
    }

    /// <summary>
    /// Initializes or configures ToString.
    /// </summary>
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
            TablerFontWeight.Bold => "fw-bold",
            TablerFontWeight.Light => "fw-light",
            TablerFontWeight.Normal => "fw-normal",
            _ => ""
        };
    }
}

/// <summary>
/// Text alignment options
/// </summary>
public enum TablerTextAlignment {
    /// <summary>Align text to the start.</summary>
    Start,
    /// <summary>Center align the text.</summary>
    Center,
    /// <summary>Align text to the end.</summary>
    End,
    /// <summary>Justify the text.</summary>
    Justify
}

/// <summary>
/// Extension methods for text alignment
/// </summary>
public static class TablerTextAlignmentExtensions {
    /// <summary>
    /// Initializes or configures ToTablerTextAlignmentClass.
    /// </summary>
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