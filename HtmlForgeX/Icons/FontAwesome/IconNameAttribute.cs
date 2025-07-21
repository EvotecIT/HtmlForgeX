using System;

namespace HtmlForgeX;

/// <summary>
/// Specifies the Font Awesome icon name (kebab-case) for an enum value
/// </summary>
[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class IconNameAttribute : Attribute {
    /// <summary>
    /// Gets the Font Awesome icon name
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Initializes a new instance of the IconNameAttribute class
    /// </summary>
    /// <param name="name">The Font Awesome icon name (e.g., "address-book", "github")</param>
    public IconNameAttribute(string name) {
        Name = name;
    }
}