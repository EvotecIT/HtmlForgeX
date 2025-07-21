using System;
using System.Collections.Generic;
using System.Linq;

namespace HtmlForgeX;

/// <summary>
/// Static library for SVG icons with embedded content from tabler-icons
/// This is the manually maintained part of the partial class
/// </summary>
public static partial class TablerIconLibrary {
    /// <summary>
    /// Get an SVG icon by type
    /// </summary>
    public static TablerIcon GetIcon(TablerIconType TablerIconType) {
        var svgContent = GetSvgContent(TablerIconType);
        return new TablerIcon(svgContent);
    }

    /// <summary>
    /// Get raw SVG content for an icon
    /// </summary>
    public static string GetSvgContent(TablerIconType TablerIconType) {
        if (_iconContent.TryGetValue(TablerIconType, out var content)) {
            return content;
        }

        throw new ArgumentException($"Icon not found: {TablerIconType}");
    }

    /// <summary>
    /// Check if an icon exists
    /// </summary>
    public static bool HasIcon(TablerIconType TablerIconType) {
        return _iconContent.ContainsKey(TablerIconType);
    }

    /// <summary>
    /// Get all available icon types
    /// </summary>
    public static IEnumerable<TablerIconType> GetAllIcons() {
        return _iconContent.Keys;
    }

    /// <summary>
    /// Gets the total count of available icons in the library
    /// </summary>
    /// <returns>Total number of available icons</returns>
    public static int GetAvailableIconCount() {
        return Enum.GetValues(typeof(TablerIconType)).Length;
    }
}