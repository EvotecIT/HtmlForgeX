using System.ComponentModel;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Available themes for the Quill editor.
/// </summary>
[JsonConverter(typeof(DescriptionEnumConverter<QuillTheme>))]
public enum QuillTheme {
    /// <summary>Standard "snow" theme.</summary>
    [Description("snow")] Snow,
    /// <summary>Minimal "bubble" theme.</summary>
    [Description("bubble")] Bubble
}

/// <summary>
/// Supported Quill formatting options used across modules and toolbars.
/// </summary>
[JsonConverter(typeof(DescriptionEnumConverter<QuillFormat>))]
public enum QuillFormat {
    /// <summary>Background color styling.</summary>
    [Description("background")] Background,
    /// <summary>Bold text.</summary>
    [Description("bold")] Bold,
    /// <summary>Font color styling.</summary>
    [Description("color")] Color,
    /// <summary>Font family selection.</summary>
    [Description("font")] Font,
    /// <summary>Inline code formatting.</summary>
    [Description("code")] Code,
    /// <summary>Italic text.</summary>
    [Description("italic")] Italic,
    /// <summary>Hyperlink formatting.</summary>
    [Description("link")] Link,
    /// <summary>Font size selection.</summary>
    [Description("size")] Size,
    /// <summary>Strike-through text.</summary>
    [Description("strike")] Strike,
    /// <summary>Super or subscript text.</summary>
    [Description("script")] Script,
    /// <summary>Underlined text.</summary>
    [Description("underline")] Underline,
    /// <summary>Block quote formatting.</summary>
    [Description("blockquote")] Blockquote,
    /// <summary>Heading levels.</summary>
    [Description("header")] Header,
    /// <summary>Indentation level.</summary>
    [Description("indent")] Indent,
    /// <summary>Ordered or bullet lists.</summary>
    [Description("list")] List,
    /// <summary>Text alignment.</summary>
    [Description("align")] Align,
    /// <summary>Text directionality.</summary>
    [Description("direction")] Direction,
    /// <summary>Code block styling.</summary>
    [Description("code-block")] CodeBlock,
    /// <summary>LaTeX formula embedding.</summary>
    [Description("formula")] Formula,
    /// <summary>Image embedding.</summary>
    [Description("image")] Image,
    /// <summary>Video embedding.</summary>
    [Description("video")] Video
}