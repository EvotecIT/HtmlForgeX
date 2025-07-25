namespace HtmlForgeX;

/// <summary>
/// Represents a table-based row layout for email compatibility.
/// Uses HTML tables instead of CSS flexbox/grid for maximum email client support.
/// </summary>
public class EmailRow : Element {
    /// <summary>
    /// Gets or sets additional CSS classes for the row.
    /// </summary>
    public string CssClass { get; set; } = "row";

    /// <summary>
    /// Gets or sets the table layout mode.
    /// </summary>
    public string TableLayout { get; set; } = "fixed";

    /// <summary>
    /// Gets or sets the spacing between columns.
    /// </summary>
    public string ColumnSpacing { get; set; } = "16px";

    /// <summary>
    /// Gets or sets whether to automatically add spacing between columns.
    /// </summary>
    public bool AutoSpaceColumns { get; set; } = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailRow"/> class.
    /// </summary>
    public EmailRow() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailRow"/> class with a custom CSS class.
    /// </summary>
    /// <param name="cssClass">The CSS class to apply.</param>
    public EmailRow(string cssClass) {
        CssClass = cssClass;
    }

    /// <summary>
    /// Adds a column to the row.
    /// </summary>
    /// <param name="column">The column to add.</param>
    /// <returns>The EmailRow object, allowing for method chaining.</returns>
    public EmailRow Add(EmailColumn column) {
        // Propagate Email reference to the column
        if (column != null && this.Email != null) {
            column.Email = this.Email;
        }
        base.Add(column);
        return this;
    }

    /// <summary>
    /// Adds a column to the row using a configuration action.
    /// </summary>
    /// <param name="config">The configuration action for the column.</param>
    /// <returns>The EmailColumn that was added.</returns>
    public EmailColumn AddColumn(Action<EmailColumn> config) {
        var column = new EmailColumn();
        column.Email = this.Email;  // Set Email reference BEFORE configuration
        config(column);
        this.Add(column);
        return column;
    }

    /// <summary>
    /// Adds a column to the row using a configuration action.
    /// This method provides the same functionality as AddColumn but with the standard EmailColumn naming convention.
    /// </summary>
    /// <param name="config">The configuration action for the column.</param>
    /// <returns>The EmailColumn that was added.</returns>
    public new EmailColumn EmailColumn(Action<EmailColumn> config) {
        var column = new EmailColumn();
        column.Email = this.Email;  // Set Email reference BEFORE configuration
        config(column);
        this.Add(column);
        return column;
    }

    /// <summary>
    /// Adds a spacer column to create spacing between content columns.
    /// </summary>
    /// <param name="width">The width of the spacer in pixels.</param>
    /// <returns>The EmailRow object, allowing for method chaining.</returns>
    public EmailRow AddSpacer(int width = 24) {
        var spacer = new EmailColumn();
        spacer.SetWidth($"{width}px");
        spacer.CssClass = "col-spacer";
        this.Add(spacer);
        return this;
    }

    /// <summary>
    /// Sets the spacing between columns.
    /// </summary>
    /// <param name="spacing">The spacing value.</param>
    /// <returns>The EmailRow object, allowing for method chaining.</returns>
    public EmailRow SetColumnSpacing(string spacing) {
        ColumnSpacing = spacing;
        AutoSpaceColumns = true;
        return this;
    }

    /// <summary>
    /// Disables automatic spacing between columns.
    /// </summary>
    /// <returns>The EmailRow object, allowing for method chaining.</returns>
    public EmailRow DisableAutoSpacing() {
        AutoSpaceColumns = false;
        return this;
    }

    /// <summary>
    /// Converts the EmailRow to its HTML table representation.
    /// </summary>
    /// <returns>HTML string representing the email row as a table.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        // Create table element with row styling
        var tableStyle = $@"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;
            border-collapse: collapse; width: 100%; table-layout: {TableLayout};";

        html.AppendLine($@"<table class=""{CssClass}"" cellspacing=""0"" cellpadding=""0"" style=""{tableStyle}"">
<tr>");

        // Render child columns
        for (int i = 0; i < Children.Count; i++) {
            var child = Children[i];
            var isLastChild = i == Children.Count - 1;

            if (child is EmailColumn column) {
                // Build cell style with configurable wrapping behavior
                var wrapCss = column.WrapMode.ToCssProperties();
                var cellStyles = new List<string> {
                    "font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif",
                    wrapCss
                };

                if (!string.IsNullOrEmpty(column.Width)) {
                    cellStyles.Add($"width: {column.Width}");
                    cellStyles.Add($"max-width: {column.Width}");
                }

                if (!string.IsNullOrEmpty(column.TextAlign) && column.TextAlign != "left") {
                    cellStyles.Add($"text-align: {column.TextAlign}");
                }

                if (AutoSpaceColumns && !isLastChild) {
                    cellStyles.Add($"padding-right: {ColumnSpacing}");
                }

                var cellStyle = string.Join("; ", cellStyles);
                var alignAttr = !string.IsNullOrEmpty(column.TextAlign) && column.TextAlign != "left" ? $@" align=""{column.TextAlign}""" : "";

                html.AppendLine($@"<td class=""{column.CssClass}"" style=""{cellStyle}"" valign=""{column.VerticalAlign.ToCssValue()}""{alignAttr}>");

                // Render column content
                var columnContent = column.GetContentString();
                if (!string.IsNullOrEmpty(columnContent)) {
                    html.AppendLine(columnContent);
                }

                html.AppendLine("</td>");
            } else {
                // For non-column children, wrap in a single cell spanning all columns
                var nonColumnStyle = "font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif;";
                html.AppendLine($@"<td style=""{nonColumnStyle}"">");

                var childContent = child.ToString();
                if (!string.IsNullOrEmpty(childContent)) {
                    html.AppendLine(childContent);
                }

                html.AppendLine("</td>");
            }
        }

        html.AppendLine($@"</tr>
</table>");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}