using System.Reflection;
using System.Linq;
using HtmlForgeX.Extensions;

namespace HtmlForgeX;

/// <summary>
/// Represents an email-compatible table component for displaying structured data.
/// </summary>
public class EmailTable : Element {
    /// <summary>
    /// Gets or sets the table headers.
    /// </summary>
    public List<EmailTableHeader> Headers { get; set; } = new();

    /// <summary>
    /// Gets or sets the table rows.
    /// </summary>
    public List<EmailTableRow> Rows { get; set; } = new();

    /// <summary>
    /// Gets or sets additional CSS classes for the table.
    /// </summary>
    public string CssClass { get; set; } = "table";

    /// <summary>
    /// Gets or sets whether to include borders.
    /// </summary>
    public bool IncludeBorders { get; set; } = true;

    /// <summary>
    /// Gets or sets the border color.
    /// </summary>
    public string BorderColor { get; set; } = "#e8ebee";

    /// <summary>
    /// Gets or sets whether to stripe alternate rows.
    /// </summary>
    public bool StripedRows { get; set; } = false;

    /// <summary>
    /// Gets or sets the stripe color.
    /// </summary>
    public string StripeColor { get; set; } = "#f9fafb";

    /// <summary>
    /// Gets or sets the header style.
    /// </summary>
    public string HeaderStyle { get; set; } = "text-transform: uppercase; font-weight: 600; color: #667382; font-size: 12px; background-color: #f8fafc; text-align: left; vertical-align: top;";

    /// <summary>
    /// Gets or sets the cell style.
    /// </summary>
    public string CellStyle { get; set; } = "color: #374151; font-size: 14px; line-height: 1.5; text-align: left; vertical-align: top;";

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailTable"/> class.
    /// </summary>
    public EmailTable() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="EmailTable"/> class with data.
    /// </summary>
    /// <param name="data">The data collection to populate the table.</param>
    public EmailTable(IEnumerable<object> data) {
        PopulateFromData(data);
    }

    /// <summary>
    /// Adds a header to the table.
    /// </summary>
    /// <param name="text">The header text.</param>
    /// <param name="align">The text alignment.</param>
    /// <param name="colspan">The column span.</param>
    /// <returns>The EmailTable object, allowing for method chaining.</returns>
    public EmailTable AddHeader(string text, string align = "left", int colspan = 1) {
        Headers.Add(new EmailTableHeader {
            Text = text,
            Align = align,
            ColSpan = colspan
        });
        return this;
    }

    /// <summary>
    /// Adds multiple headers to the table.
    /// </summary>
    /// <param name="headers">The header texts.</param>
    /// <returns>The EmailTable object, allowing for method chaining.</returns>
    public EmailTable AddHeader(params string[] headers) {
        foreach (var header in headers) {
            AddHeader(header);
        }
        return this;
    }

    /// <summary>
    /// Adds a row to the table.
    /// </summary>
    /// <param name="cells">The cell values for the row.</param>
    /// <returns>The EmailTableRow that was added.</returns>
    public EmailTableRow AddRow(params string[] cells) {
        var row = new EmailTableRow();
        foreach (var cell in cells) {
            row.AddCell(cell);
        }
        Rows.Add(row);
        return row;
    }

    /// <summary>
    /// Adds a row to the table using a configuration action.
    /// </summary>
    /// <param name="config">The configuration action for the row.</param>
    /// <returns>The EmailTableRow that was added.</returns>
    public EmailTableRow AddRow(Action<EmailTableRow> config) {
        var row = new EmailTableRow();
        config(row);
        Rows.Add(row);
        return row;
    }

    /// <summary>
    /// Sets whether to include borders.
    /// </summary>
    /// <param name="include">Whether to include borders.</param>
    /// <param name="color">The border color (optional).</param>
    /// <returns>The EmailTable object, allowing for method chaining.</returns>
    public EmailTable SetBorders(bool include, string color = "#e8ebee") {
        IncludeBorders = include;
        BorderColor = color;
        return this;
    }

    /// <summary>
    /// Sets whether to stripe alternate rows.
    /// </summary>
    /// <param name="striped">Whether to stripe rows.</param>
    /// <param name="color">The stripe color (optional).</param>
    /// <returns>The EmailTable object, allowing for method chaining.</returns>
    public EmailTable SetStriped(bool striped, string color = "#f9fafb") {
        StripedRows = striped;
        StripeColor = color;
        return this;
    }

    /// <summary>
    /// Sets the CSS class for the table.
    /// </summary>
    /// <param name="cssClass">The CSS class.</param>
    /// <returns>The EmailTable object, allowing for method chaining.</returns>
    public EmailTable SetClass(string cssClass) {
        CssClass = cssClass;
        return this;
    }

    /// <summary>
    /// Sets the table style using predefined styles.
    /// </summary>
    /// <param name="style">The predefined table style.</param>
    /// <returns>The EmailTable object, allowing for method chaining.</returns>
    public EmailTable SetStyle(EmailTableStyle style) {
        var (cssClass, striped, bordered, headerStyle, cellStyle, borderColor, stripeColor) = style.GetStyle();
        CssClass = cssClass;
        StripedRows = striped;
        IncludeBorders = bordered;
        HeaderStyle = headerStyle;
        CellStyle = cellStyle;
        BorderColor = borderColor;
        StripeColor = stripeColor;
        return this;
    }

    /// <summary>
    /// Populates the table from a data collection.
    /// </summary>
    /// <typeparam name="T">The type of objects in the data collection.</typeparam>
    /// <param name="data">The data collection to populate from.</param>
    /// <returns>The EmailTable object, allowing for method chaining.</returns>
    public EmailTable PopulateFromData<T>(IEnumerable<T> data) where T : class {
        if (data == null || !data.Any()) {
            return this;
        }

        var dataList = data.ToList();
        var firstItem = dataList.First();

        // Get property names from the first object using reflection
        var properties = typeof(T).GetProperties()
            .Where(p => p.CanRead && p.GetIndexParameters().Length == 0) // Exclude indexers
            .Select(p => p.Name)
            .ToArray();

        // Clear existing headers and rows
        Headers.Clear();
        Rows.Clear();

        // Add headers from property names
        AddHeader(properties);

        // Add rows from data
        foreach (var item in dataList.WhereNotNull()) {
            var values = new string[properties.Length];
            for (int i = 0; i < properties.Length; i++) {
                var prop = typeof(T).GetProperty(properties[i]);
                var value = prop?.GetValue(item)?.ToString() ?? "";
                values[i] = value;
            }
            AddRow(values);
        }

        return this;
    }

    /// <summary>
    /// Populates the table from a data collection (object version for backwards compatibility).
    /// </summary>
    /// <param name="data">The data collection to populate from.</param>
    /// <returns>The EmailTable object, allowing for method chaining.</returns>
    public EmailTable PopulateFromData(IEnumerable<object> data) {
        if (data == null || !data.Any()) {
            return this;
        }

        var dataList = data.ToList();
        var firstItem = dataList.First();

        // Get property names from the first object using reflection
        var properties = firstItem.GetType().GetProperties()
            .Where(p => p.CanRead && p.GetIndexParameters().Length == 0) // Exclude indexers
            .Select(p => p.Name)
            .ToArray();

        // Clear existing headers and rows
        Headers.Clear();
        Rows.Clear();

        // Add headers from property names
        AddHeader(properties);

        // Add rows from data
        foreach (var item in dataList.WhereNotNull()) {
            var values = new string[properties.Length];
            for (int i = 0; i < properties.Length; i++) {
                var prop = item.GetType().GetProperty(properties[i]);
                var value = prop?.GetValue(item)?.ToString() ?? "";
                values[i] = value;
            }
            AddRow(values);
        }

        return this;
    }

    /// <summary>
    /// Converts the EmailTable to its HTML representation.
    /// </summary>
    /// <returns>HTML string representing the email table.</returns>
    public override string ToString() {
        var html = StringBuilderCache.Acquire();

        var tableStyle = "font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; border-collapse: collapse; width: 100%; border-radius: 8px; overflow: hidden; box-shadow: 0 1px 3px rgba(0, 0, 0, 0.1);";

        html.AppendLine($@"
<table class=""{CssClass}"" cellspacing=""0"" cellpadding=""0"" style=""{tableStyle}"">
");

        // Render headers
        if (Headers.Count > 0) {
            html.AppendLine($@"
<tr>
");
            var totalHeaders = Headers.Count;
            var defaultWidth = totalHeaders > 0 ? (100.0 / totalHeaders).ToString("F1") + "%" : "";

            foreach (var header in Headers) {
                var colspanAttr = header.ColSpan > 1 ? $" colspan=\"{header.ColSpan}\"" : "";
                var alignAttr = !string.IsNullOrEmpty(header.Align) && header.Align != "left" ? $" align=\"{header.Align}\"" : "";
                var widthAttr = $" width=\"{defaultWidth}\"";

                var completeHeaderStyle = $"padding: {EmailLayout.GetTableCellPadding()}; {HeaderStyle}";
                html.AppendLine($@"<th{colspanAttr}{widthAttr} style=""{completeHeaderStyle}""{alignAttr}>{Helpers.HtmlEncode(header.Text)}</th>");
            }
            html.AppendLine($@"
</tr>
");
        }

        // Render rows
        for (int i = 0; i < Rows.Count; i++) {
            var row = Rows[i];
            var rowBgColor = "";

            if (StripedRows && i % 2 == 1) {
                rowBgColor = $" bgcolor=\"{StripeColor}\"";
            }

            html.AppendLine($@"
<tr{rowBgColor}>
");

            var totalCells = row.Cells.Count;
            var defaultCellWidth = totalCells > 0 ? (100.0 / totalCells).ToString("F1") + "%" : "";

            foreach (var cell in row.Cells) {
                var baseCellStyle = $"font-family: Inter, -apple-system, BlinkMacSystemFont, San Francisco, Segoe UI, Roboto, Helvetica Neue, Arial, sans-serif; padding: {EmailLayout.GetTableCellPadding()}; {CellStyle}";

                if (IncludeBorders && cell.IncludeTopBorder) {
                    baseCellStyle += $" border-top: 1px solid {BorderColor};";
                }

                // Use cell width if specified, otherwise use calculated default
                var cellWidth = !string.IsNullOrEmpty(cell.Width) ? cell.Width : defaultCellWidth;
                if (!string.IsNullOrEmpty(cellWidth)) {
                    baseCellStyle += $" width: {cellWidth};";
                }

                if (!string.IsNullOrEmpty(cell.InlineStyle)) {
                    baseCellStyle += " " + cell.InlineStyle;
                }

                var alignAttr = !string.IsNullOrEmpty(cell.Align) && cell.Align != "left" ? $" align=\"{cell.Align}\"" : "";
                var colspanAttr = cell.ColSpan > 1 ? $" colspan=\"{cell.ColSpan}\"" : "";
                var cssClassAttr = !string.IsNullOrEmpty(cell.CssClass) ? $" class=\"{cell.CssClass}\"" : "";
                var widthAttr = !string.IsNullOrEmpty(cellWidth) ? $" width=\"{cellWidth}\"" : "";

                html.AppendLine($@"<td{cssClassAttr}{widthAttr} style=""{baseCellStyle}""{alignAttr}{colspanAttr}>{cell.GetContentHtml()}</td>");
            }

            html.AppendLine($@"
</tr>
");
        }

        html.AppendLine($@"
</table>
");

        return StringBuilderCache.GetStringAndRelease(html);
    }
}

/// <summary>
/// Represents a table header in an email table.
/// </summary>
public class EmailTableHeader {
    public string Text { get; set; } = "";
    public string Align { get; set; } = "left";
    public int ColSpan { get; set; } = 1;
}

/// <summary>
/// Represents a table row in an email table.
/// </summary>
public class EmailTableRow {
    public List<EmailTableCell> Cells { get; set; } = new();

    /// <summary>
    /// Adds a simple text cell to the row.
    /// </summary>
    /// <param name="text">The cell text.</param>
    /// <param name="align">The text alignment.</param>
    /// <returns>The EmailTableCell that was added.</returns>
    public EmailTableCell AddCell(string text, string align = "left") {
        var cell = new EmailTableCell {
            Text = text,
            Align = align
        };
        Cells.Add(cell);
        return cell;
    }

    /// <summary>
    /// Adds a cell with custom configuration.
    /// </summary>
    /// <param name="config">The configuration action for the cell.</param>
    /// <returns>The EmailTableCell that was added.</returns>
    public EmailTableCell AddCell(Action<EmailTableCell> config) {
        var cell = new EmailTableCell();
        config(cell);
        Cells.Add(cell);
        return cell;
    }

    /// <summary>
    /// Adds an image cell to the row.
    /// </summary>
    /// <param name="imageSrc">The image source URL.</param>
    /// <param name="width">The image width.</param>
    /// <param name="height">The image height.</param>
    /// <param name="alt">The image alt text.</param>
    /// <returns>The EmailTableCell that was added.</returns>
    public EmailTableCell AddImageCell(string imageSrc, int width = 64, int height = 64, string alt = "") {
        var cell = new EmailTableCell();
        cell.SetImage(imageSrc, width, height, alt);
        Cells.Add(cell);
        return cell;
    }
}

/// <summary>
/// Represents a table cell in an email table.
/// </summary>
public class EmailTableCell {
    public string Text { get; set; } = "";
    public string Align { get; set; } = "left";
    public int ColSpan { get; set; } = 1;
    public string Width { get; set; } = "";
    public string CssClass { get; set; } = "";
    public string InlineStyle { get; set; } = "";
    public bool IncludeTopBorder { get; set; } = false;

    // Image properties
    public string ImageSrc { get; set; } = "";
    public int ImageWidth { get; set; } = 0;
    public int ImageHeight { get; set; } = 0;
    public string ImageAlt { get; set; } = "";
    public string ImageLink { get; set; } = "";

    // Rich content
    public string HtmlContent { get; set; } = "";

    /// <summary>
    /// Sets the cell text content.
    /// </summary>
    /// <param name="text">The text content.</param>
    /// <returns>The EmailTableCell object, allowing for method chaining.</returns>
    public EmailTableCell SetText(string text) {
        Text = text;
        HtmlContent = "";
        ImageSrc = "";
        return this;
    }

    /// <summary>
    /// Sets the cell as an image.
    /// </summary>
    /// <param name="src">The image source URL.</param>
    /// <param name="width">The image width.</param>
    /// <param name="height">The image height.</param>
    /// <param name="alt">The image alt text.</param>
    /// <param name="link">Optional link URL for the image.</param>
    /// <returns>The EmailTableCell object, allowing for method chaining.</returns>
    public EmailTableCell SetImage(string src, int width = 64, int height = 64, string alt = "", string link = "") {
        ImageSrc = src;
        ImageWidth = width;
        ImageHeight = height;
        ImageAlt = alt;
        ImageLink = link;
        Text = "";
        HtmlContent = "";
        return this;
    }

    /// <summary>
    /// Sets the cell HTML content.
    /// </summary>
    /// <param name="html">The HTML content.</param>
    /// <returns>The EmailTableCell object, allowing for method chaining.</returns>
    public EmailTableCell SetHtml(string html) {
        HtmlContent = html;
        Text = "";
        ImageSrc = "";
        return this;
    }

    /// <summary>
    /// Sets the cell alignment.
    /// </summary>
    /// <param name="align">The alignment (left, center, right).</param>
    /// <returns>The EmailTableCell object, allowing for method chaining.</returns>
    public EmailTableCell SetAlign(string align) {
        Align = align;
        return this;
    }

    /// <summary>
    /// Sets the cell width.
    /// </summary>
    /// <param name="width">The width value.</param>
    /// <returns>The EmailTableCell object, allowing for method chaining.</returns>
    public EmailTableCell SetWidth(string width) {
        Width = width;
        return this;
    }

    /// <summary>
    /// Enables the top border for this cell.
    /// </summary>
    /// <returns>The EmailTableCell object, allowing for method chaining.</returns>
    public EmailTableCell EnableTopBorder() {
        IncludeTopBorder = true;
        return this;
    }

    /// <summary>
    /// Gets the HTML content for the cell.
    /// </summary>
    /// <returns>HTML string representing the cell content.</returns>
    internal string GetContentHtml() {
        if (!string.IsNullOrEmpty(ImageSrc)) {
            var imageHtml = $"<img src=\"{Helpers.HtmlEncode(ImageSrc)}\" class=\"rounded bg-light\" width=\"{ImageWidth}\" height=\"{ImageHeight}\" alt=\"{Helpers.HtmlEncode(ImageAlt)}\" style=\"display: inline-block; line-height: 100%; outline: none; text-decoration: none; vertical-align: bottom; font-size: 0; background-color: #f6f6f6; border-radius: 4px; border-style: none; border-width: 0;\" />";

            if (!string.IsNullOrEmpty(ImageLink)) {
                return $"<a href=\"{Helpers.HtmlEncode(ImageLink)}\" style=\"color: #066FD1; text-decoration: none;\">{imageHtml}</a>";
            }

            return imageHtml;
        }

        if (!string.IsNullOrEmpty(HtmlContent)) {
            return HtmlContent;
        }

        return Helpers.HtmlEncode(Text);
    }
}