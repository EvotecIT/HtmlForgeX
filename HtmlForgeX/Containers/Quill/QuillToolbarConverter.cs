using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Custom JSON converter for Quill toolbar configuration.
/// </summary>
public class QuillToolbarConverter : JsonConverter<object> {
    /// <summary>
    /// Reads JSON and converts it to an object. Not implemented for this converter.
    /// </summary>
    /// <param name="reader">The JSON reader.</param>
    /// <param name="typeToConvert">The type to convert to.</param>
    /// <param name="options">The serializer options.</param>
    /// <returns>The converted object.</returns>
    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        throw new NotImplementedException("Deserialization is not supported");
    }

    /// <summary>
    /// Writes the specified value as JSON.
    /// </summary>
    /// <param name="writer">The JSON writer.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">The serializer options.</param>
    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options) {
        switch (value) {
            case List<QuillFormat> formats:
                WriteSimpleToolbar(writer, formats);
                break;
            case List<List<QuillFormat>> groupedFormats:
                WriteGroupedToolbar(writer, groupedFormats);
                break;
            case QuillToolbarConfig config:
                WriteAdvancedToolbar(writer, config);
                break;
            default:
                JsonSerializer.Serialize(writer, value, options);
                break;
        }
    }

    private void WriteSimpleToolbar(Utf8JsonWriter writer, List<QuillFormat> formats) {
        writer.WriteStartArray();
        foreach (var format in formats) {
            writer.WriteStringValue(GetFormatDescription(format));
        }
        writer.WriteEndArray();
    }

    private void WriteGroupedToolbar(Utf8JsonWriter writer, List<List<QuillFormat>> groups) {
        writer.WriteStartArray();
        foreach (var group in groups) {
            writer.WriteStartArray();

            foreach (var format in group) {
                if (format == QuillFormat.List) {
                    // Expand List into two button objects
                    writer.WriteStartObject();
                    writer.WritePropertyName("list");
                    writer.WriteStringValue("ordered");
                    writer.WriteEndObject();

                    writer.WriteStartObject();
                    writer.WritePropertyName("list");
                    writer.WriteStringValue("bullet");
                    writer.WriteEndObject();
                } else if (format == QuillFormat.Indent) {
                    // Expand Indent into two button objects
                    writer.WriteStartObject();
                    writer.WritePropertyName("indent");
                    writer.WriteStringValue("-1");
                    writer.WriteEndObject();

                    writer.WriteStartObject();
                    writer.WritePropertyName("indent");
                    writer.WriteStringValue("+1");
                    writer.WriteEndObject();
                } else {
                    // Regular format as string
                    writer.WriteStringValue(GetFormatDescription(format));
                }
            }

            writer.WriteEndArray();
        }
        writer.WriteEndArray();
    }

    private void WriteAdvancedToolbar(Utf8JsonWriter writer, QuillToolbarConfig config) {
        writer.WriteStartArray();
        for (int i = 0; i < config.Items.Count; i++) {
            var item = config.Items[i];
            if (item is QuillToolbarButton button) {
                writer.WriteStringValue(GetFormatDescription(button.Format));
            } else if (item is QuillListAndIndentGroup) {
                // List and indent buttons in a single array
                writer.WriteStartArray();
                writer.WriteStartObject();
                writer.WritePropertyName("list");
                writer.WriteStringValue("ordered");
                writer.WriteEndObject();
                writer.WriteStartObject();
                writer.WritePropertyName("list");
                writer.WriteStringValue("bullet");
                writer.WriteEndObject();
                writer.WriteStartObject();
                writer.WritePropertyName("indent");
                writer.WriteStringValue("-1");
                writer.WriteEndObject();
                writer.WriteStartObject();
                writer.WritePropertyName("indent");
                writer.WriteStringValue("+1");
                writer.WriteEndObject();
                writer.WriteEndArray();
            } else if (item is QuillListButton listButton) {
                // For advanced toolbar, list buttons should be in an array
                if (i < config.Items.Count - 1 && config.Items[i + 1] is QuillListButton) {
                    // Start array for list buttons
                    writer.WriteStartArray();
                    writer.WriteStartObject();
                    writer.WritePropertyName("list");
                    writer.WriteStringValue(listButton.Value);
                    writer.WriteEndObject();
                    // Write the next list button
                    i++;
                    var nextList = (QuillListButton)config.Items[i];
                    writer.WriteStartObject();
                    writer.WritePropertyName("list");
                    writer.WriteStringValue(nextList.Value);
                    writer.WriteEndObject();
                    writer.WriteEndArray();
                } else {
                    // Single list button - shouldn't happen with our API
                    writer.WriteStartObject();
                    writer.WritePropertyName("list");
                    writer.WriteStringValue(listButton.Value);
                    writer.WriteEndObject();
                }
            } else if (item is QuillIndentButton indentButton) {
                // For advanced toolbar, indent buttons should be in an array
                if (i < config.Items.Count - 1 && config.Items[i + 1] is QuillIndentButton) {
                    // Start array for indent buttons
                    writer.WriteStartArray();
                    writer.WriteStartObject();
                    writer.WritePropertyName("indent");
                    writer.WriteStringValue(indentButton.Value);
                    writer.WriteEndObject();
                    // Write the next indent button
                    i++;
                    var nextIndent = (QuillIndentButton)config.Items[i];
                    writer.WriteStartObject();
                    writer.WritePropertyName("indent");
                    writer.WriteStringValue(nextIndent.Value);
                    writer.WriteEndObject();
                    writer.WriteEndArray();
                } else {
                    // Single indent button - shouldn't happen with our API
                    writer.WriteStartObject();
                    writer.WritePropertyName("indent");
                    writer.WriteStringValue(indentButton.Value);
                    writer.WriteEndObject();
                }
            } else if (item is QuillToolbarDropdown dropdown) {
                // Dropdowns should be wrapped in an array
                writer.WriteStartArray();
                writer.WriteStartObject();
                writer.WritePropertyName(dropdown.Type);

                if (dropdown.Type == "align" && dropdown.Options.Count == 0) {
                    // Align with no options should be an empty array
                    writer.WriteStartArray();
                    writer.WriteEndArray();
                } else if (dropdown.Type == "header") {
                    // Header values should be numbers, not strings
                    writer.WriteStartArray();
                    foreach (var option in dropdown.Options) {
                        if (option == null) {
                            writer.WriteBooleanValue(false);
                        } else if (int.TryParse(option, out int headerLevel)) {
                            writer.WriteNumberValue(headerLevel);
                        } else {
                            writer.WriteStringValue(option);
                        }
                    }
                    writer.WriteEndArray();
                } else {
                    // Other dropdowns with string values
                    writer.WriteStartArray();
                    foreach (var option in dropdown.Options) {
                        if (option == null) {
                            writer.WriteBooleanValue(false);
                        } else {
                            writer.WriteStringValue(option);
                        }
                    }
                    writer.WriteEndArray();
                }

                writer.WriteEndObject();
                writer.WriteEndArray();
            } else if (item is QuillToolbarGroup group) {
                writer.WriteStartArray();
                foreach (var format in group.Formats) {
                    writer.WriteStringValue(GetFormatDescription(format));
                }
                writer.WriteEndArray();
            }
        }
        writer.WriteEndArray();
    }

    private static string GetFormatDescription(QuillFormat format) {
        var memberInfo = typeof(QuillFormat).GetMember(format.ToString()).FirstOrDefault();
        if (memberInfo != null) {
            var descriptionAttribute = memberInfo.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
            if (descriptionAttribute != null) {
                return descriptionAttribute.Description;
            }
        }
        return format.ToString().ToLowerInvariant();
    }
}

/// <summary>
/// Advanced toolbar configuration for Quill.
/// </summary>
public class QuillToolbarConfig {
    /// <summary>
    /// Gets the toolbar items.
    /// </summary>
    public List<object> Items { get; } = new();

    /// <summary>
    /// Adds a simple button to the toolbar.
    /// </summary>
    public QuillToolbarConfig Button(QuillFormat format) {
        Items.Add(new QuillToolbarButton { Format = format });
        return this;
    }

    /// <summary>
    /// Adds a dropdown to the toolbar.
    /// </summary>
    public QuillToolbarConfig Dropdown(string type, params string?[] options) {
        Items.Add(new QuillToolbarDropdown { Type = type, Options = options.ToList() });
        return this;
    }

    /// <summary>
    /// Adds a button group to the toolbar.
    /// </summary>
    public QuillToolbarConfig Group(params QuillFormat[] formats) {
        Items.Add(new QuillToolbarGroup { Formats = formats.ToList() });
        return this;
    }

    /// <summary>
    /// Adds list buttons (ordered and bullet) to the toolbar.
    /// </summary>
    public QuillToolbarConfig ListButtons() {
        Items.Add(new QuillListButton { Value = "ordered" });
        Items.Add(new QuillListButton { Value = "bullet" });
        return this;
    }

    /// <summary>
    /// Adds indent buttons (outdent and indent) to the toolbar.
    /// </summary>
    public QuillToolbarConfig IndentButtons() {
        Items.Add(new QuillIndentButton { Value = "-1" });
        Items.Add(new QuillIndentButton { Value = "+1" });
        return this;
    }

    /// <summary>
    /// Adds list and indent buttons in a single group.
    /// </summary>
    public QuillToolbarConfig ListAndIndentButtons() {
        Items.Add(new QuillListAndIndentGroup());
        return this;
    }
}

internal class QuillToolbarButton {
    public QuillFormat Format { get; set; }
}

internal class QuillToolbarDropdown {
    public string Type { get; set; } = string.Empty;
    public List<string?> Options { get; set; } = new();
}

internal class QuillToolbarGroup {
    public List<QuillFormat> Formats { get; set; } = new();
}

internal class QuillListButton {
    public string Value { get; set; } = string.Empty;
}

internal class QuillIndentButton {
    public string Value { get; set; } = string.Empty;
}

internal class QuillListAndIndentGroup {
    // Marker class for list and indent buttons together
}