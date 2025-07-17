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
    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        throw new NotImplementedException("Deserialization is not supported");
    }

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
                writer.WriteStringValue(GetFormatDescription(format));
            }
            writer.WriteEndArray();
        }
        writer.WriteEndArray();
    }

    private void WriteAdvancedToolbar(Utf8JsonWriter writer, QuillToolbarConfig config) {
        writer.WriteStartArray();
        foreach (var item in config.Items) {
            if (item is QuillToolbarButton button) {
                // Special handling for buttons that need dropdown format
                if (button.Format == QuillFormat.List) {
                    writer.WriteStartObject();
                    writer.WritePropertyName("list");
                    writer.WriteStartArray();
                    writer.WriteStringValue("ordered");
                    writer.WriteStringValue("bullet");
                    writer.WriteEndArray();
                    writer.WriteEndObject();
                } else if (button.Format == QuillFormat.Indent) {
                    writer.WriteStartObject();
                    writer.WritePropertyName("indent");
                    writer.WriteStartArray();
                    writer.WriteStringValue("-1");
                    writer.WriteStringValue("+1");
                    writer.WriteEndArray();
                    writer.WriteEndObject();
                } else {
                    writer.WriteStringValue(GetFormatDescription(button.Format));
                }
            } else if (item is QuillToolbarDropdown dropdown) {
                // Standard dropdown format for header, align, etc.
                writer.WriteStartObject();
                writer.WritePropertyName(dropdown.Type);
                writer.WriteStartArray();
                foreach (var option in dropdown.Options) {
                    if (option == null) {
                        writer.WriteNullValue();
                    } else {
                        writer.WriteStringValue(option);
                    }
                }
                writer.WriteEndArray();
                writer.WriteEndObject();
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