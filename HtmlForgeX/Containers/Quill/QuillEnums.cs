using System.ComponentModel;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Available themes for the Quill editor.
/// </summary>
[JsonConverter(typeof(DescriptionEnumConverter<QuillTheme>))]
public enum QuillTheme {
    [Description("snow")] Snow,
    [Description("bubble")] Bubble
}

/// <summary>
/// Supported Quill formatting options used across modules and toolbars.
/// </summary>
[JsonConverter(typeof(DescriptionEnumConverter<QuillFormat>))]
public enum QuillFormat {
    [Description("background")] Background,
    [Description("bold")] Bold,
    [Description("color")] Color,
    [Description("font")] Font,
    [Description("code")] Code,
    [Description("italic")] Italic,
    [Description("link")] Link,
    [Description("size")] Size,
    [Description("strike")] Strike,
    [Description("script")] Script,
    [Description("underline")] Underline,
    [Description("blockquote")] Blockquote,
    [Description("header")] Header,
    [Description("indent")] Indent,
    [Description("list")] List,
    [Description("align")] Align,
    [Description("direction")] Direction,
    [Description("code-block")] CodeBlock,
    [Description("formula")] Formula,
    [Description("image")] Image,
    [Description("video")] Video
}
