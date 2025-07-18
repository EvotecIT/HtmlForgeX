using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Converts ChartJsPosition enum to lowercase string.
/// </summary>
public class ChartJsPositionConverter : JsonConverter<ChartJsPosition> {
    /// <summary>
    /// Reads a <see cref="ChartJsPosition"/> value from JSON.
    /// </summary>
    /// <param name="reader">The JSON reader.</param>
    /// <param name="typeToConvert">The target type to convert.</param>
    /// <param name="options">The serializer options.</param>
    /// <returns>The parsed <see cref="ChartJsPosition"/>.</returns>
    public override ChartJsPosition Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var value = reader.GetString();
        return value?.ToLowerInvariant() switch {
            "top" => ChartJsPosition.Top,
            "bottom" => ChartJsPosition.Bottom,
            "left" => ChartJsPosition.Left,
            "right" => ChartJsPosition.Right,
            "center" => ChartJsPosition.Center,
            _ => ChartJsPosition.Top
        };
    }

    /// <summary>
    /// Writes a <see cref="ChartJsPosition"/> value as JSON.
    /// </summary>
    /// <param name="writer">The JSON writer.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">The serializer options.</param>
    public override void Write(Utf8JsonWriter writer, ChartJsPosition value, JsonSerializerOptions options) {
        writer.WriteStringValue(value.ToString().ToLowerInvariant());
    }
}

/// <summary>
/// Converts ChartJsAlign enum to lowercase string.
/// </summary>
public class ChartJsAlignConverter : JsonConverter<ChartJsAlign> {
    /// <summary>
    /// Reads a <see cref="ChartJsAlign"/> value from JSON.
    /// </summary>
    /// <param name="reader">The JSON reader.</param>
    /// <param name="typeToConvert">The target type to convert.</param>
    /// <param name="options">The serializer options.</param>
    /// <returns>The parsed <see cref="ChartJsAlign"/>.</returns>
    public override ChartJsAlign Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var value = reader.GetString();
        return value?.ToLowerInvariant() switch {
            "start" => ChartJsAlign.Start,
            "center" => ChartJsAlign.Center,
            "end" => ChartJsAlign.End,
            _ => ChartJsAlign.Center
        };
    }

    /// <summary>
    /// Writes a <see cref="ChartJsAlign"/> value as JSON.
    /// </summary>
    /// <param name="writer">The JSON writer.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">The serializer options.</param>
    public override void Write(Utf8JsonWriter writer, ChartJsAlign value, JsonSerializerOptions options) {
        writer.WriteStringValue(value.ToString().ToLowerInvariant());
    }
}

/// <summary>
/// Converts ChartJsInteractionMode enum to lowercase string.
/// </summary>
public class ChartJsInteractionModeConverter : JsonConverter<ChartJsInteractionMode> {
    /// <summary>
    /// Reads a <see cref="ChartJsInteractionMode"/> value from JSON.
    /// </summary>
    /// <param name="reader">The JSON reader.</param>
    /// <param name="typeToConvert">The target type to convert.</param>
    /// <param name="options">The serializer options.</param>
    /// <returns>The parsed <see cref="ChartJsInteractionMode"/>.</returns>
    public override ChartJsInteractionMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var value = reader.GetString();
        return value?.ToLowerInvariant() switch {
            "index" => ChartJsInteractionMode.Index,
            "dataset" => ChartJsInteractionMode.Dataset,
            "nearest" => ChartJsInteractionMode.Nearest,
            "point" => ChartJsInteractionMode.Point,
            "x" => ChartJsInteractionMode.X,
            "y" => ChartJsInteractionMode.Y,
            _ => ChartJsInteractionMode.Nearest
        };
    }

    /// <summary>
    /// Writes a <see cref="ChartJsInteractionMode"/> value as JSON.
    /// </summary>
    /// <param name="writer">The JSON writer.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">The serializer options.</param>
    public override void Write(Utf8JsonWriter writer, ChartJsInteractionMode value, JsonSerializerOptions options) {
        writer.WriteStringValue(value.ToString().ToLowerInvariant());
    }
}

/// <summary>
/// Converts ChartJsFontStyle enum to lowercase string.
/// </summary>
public class ChartJsFontStyleConverter : JsonConverter<ChartJsFontStyle> {
    /// <summary>
    /// Reads a <see cref="ChartJsFontStyle"/> value from JSON.
    /// </summary>
    /// <param name="reader">The JSON reader.</param>
    /// <param name="typeToConvert">The target type to convert.</param>
    /// <param name="options">The serializer options.</param>
    /// <returns>The parsed <see cref="ChartJsFontStyle"/>.</returns>
    public override ChartJsFontStyle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var value = reader.GetString();
        return value?.ToLowerInvariant() switch {
            "normal" => ChartJsFontStyle.Normal,
            "italic" => ChartJsFontStyle.Italic,
            "oblique" => ChartJsFontStyle.Oblique,
            _ => ChartJsFontStyle.Normal
        };
    }

    /// <summary>
    /// Writes a <see cref="ChartJsFontStyle"/> value as JSON.
    /// </summary>
    /// <param name="writer">The JSON writer.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">The serializer options.</param>
    public override void Write(Utf8JsonWriter writer, ChartJsFontStyle value, JsonSerializerOptions options) {
        writer.WriteStringValue(value.ToString().ToLowerInvariant());
    }
}

/// <summary>
/// Converts ChartJsFontWeight enum to lowercase string or numeric value.
/// </summary>
public class ChartJsFontWeightConverter : JsonConverter<ChartJsFontWeight> {
    /// <summary>
    /// Reads a <see cref="ChartJsFontWeight"/> value from JSON.
    /// </summary>
    /// <param name="reader">The JSON reader.</param>
    /// <param name="typeToConvert">The target type to convert.</param>
    /// <param name="options">The serializer options.</param>
    /// <returns>The parsed <see cref="ChartJsFontWeight"/>.</returns>
    public override ChartJsFontWeight Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        if (reader.TokenType == JsonTokenType.String) {
            var value = reader.GetString();
            return value?.ToLowerInvariant() switch {
                "normal" => ChartJsFontWeight.Normal,
                "bold" => ChartJsFontWeight.Bold,
                "lighter" => ChartJsFontWeight.Lighter,
                "bolder" => ChartJsFontWeight.Bolder,
                _ => ChartJsFontWeight.Normal
            };
        }
        return ChartJsFontWeight.Normal;
    }

    /// <summary>
    /// Writes a <see cref="ChartJsFontWeight"/> value as JSON.
    /// </summary>
    /// <param name="writer">The JSON writer.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">The serializer options.</param>
    public override void Write(Utf8JsonWriter writer, ChartJsFontWeight value, JsonSerializerOptions options) {
        writer.WriteStringValue(value.ToString().ToLowerInvariant());
    }
}

/// <summary>
/// Converts nullable ChartJsPosition enum.
/// </summary>
public class ChartJsPositionNullableConverter : JsonConverter<ChartJsPosition?> {
    /// <summary>
    /// Reads a nullable <see cref="ChartJsPosition"/> value from JSON.
    /// </summary>
    /// <param name="reader">The JSON reader.</param>
    /// <param name="typeToConvert">The target type to convert.</param>
    /// <param name="options">The serializer options.</param>
    /// <returns>The parsed <see cref="ChartJsPosition"/> value or <c>null</c>.</returns>
    public override ChartJsPosition? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        if (reader.TokenType == JsonTokenType.Null) {
            return null;
        }
        var value = reader.GetString();
        return value?.ToLowerInvariant() switch {
            "top" => ChartJsPosition.Top,
            "bottom" => ChartJsPosition.Bottom,
            "left" => ChartJsPosition.Left,
            "right" => ChartJsPosition.Right,
            "center" => ChartJsPosition.Center,
            _ => null
        };
    }

    /// <summary>
    /// Writes a nullable <see cref="ChartJsPosition"/> value as JSON.
    /// </summary>
    /// <param name="writer">The JSON writer.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">The serializer options.</param>
    public override void Write(Utf8JsonWriter writer, ChartJsPosition? value, JsonSerializerOptions options) {
        if (value.HasValue) {
            writer.WriteStringValue(value.Value.ToString().ToLowerInvariant());
        } else {
            writer.WriteNullValue();
        }
    }
}

/// <summary>
/// Converts nullable ChartJsAlign enum.
/// </summary>
public class ChartJsAlignNullableConverter : JsonConverter<ChartJsAlign?> {
    /// <summary>
    /// Reads a nullable <see cref="ChartJsAlign"/> value from JSON.
    /// </summary>
    /// <param name="reader">The JSON reader.</param>
    /// <param name="typeToConvert">The target type to convert.</param>
    /// <param name="options">The serializer options.</param>
    /// <returns>The parsed <see cref="ChartJsAlign"/> value or <c>null</c>.</returns>
    public override ChartJsAlign? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        if (reader.TokenType == JsonTokenType.Null) {
            return null;
        }
        var value = reader.GetString();
        return value?.ToLowerInvariant() switch {
            "start" => ChartJsAlign.Start,
            "center" => ChartJsAlign.Center,
            "end" => ChartJsAlign.End,
            _ => null
        };
    }

    /// <summary>
    /// Writes a nullable <see cref="ChartJsAlign"/> value as JSON.
    /// </summary>
    /// <param name="writer">The JSON writer.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">The serializer options.</param>
    public override void Write(Utf8JsonWriter writer, ChartJsAlign? value, JsonSerializerOptions options) {
        if (value.HasValue) {
            writer.WriteStringValue(value.Value.ToString().ToLowerInvariant());
        } else {
            writer.WriteNullValue();
        }
    }
}

/// <summary>
/// Converts nullable ChartJsInteractionMode enum.
/// </summary>
public class ChartJsInteractionModeNullableConverter : JsonConverter<ChartJsInteractionMode?> {
    /// <summary>
    /// Reads a nullable <see cref="ChartJsInteractionMode"/> value from JSON.
    /// </summary>
    /// <param name="reader">The JSON reader.</param>
    /// <param name="typeToConvert">The target type to convert.</param>
    /// <param name="options">The serializer options.</param>
    /// <returns>The parsed <see cref="ChartJsInteractionMode"/> value or <c>null</c>.</returns>
    public override ChartJsInteractionMode? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        if (reader.TokenType == JsonTokenType.Null) {
            return null;
        }
        var value = reader.GetString();
        return value?.ToLowerInvariant() switch {
            "index" => ChartJsInteractionMode.Index,
            "dataset" => ChartJsInteractionMode.Dataset,
            "nearest" => ChartJsInteractionMode.Nearest,
            "point" => ChartJsInteractionMode.Point,
            "x" => ChartJsInteractionMode.X,
            "y" => ChartJsInteractionMode.Y,
            _ => null
        };
    }

    /// <summary>
    /// Writes a nullable <see cref="ChartJsInteractionMode"/> value as JSON.
    /// </summary>
    /// <param name="writer">The JSON writer.</param>
    /// <param name="value">The value to write.</param>
    /// <param name="options">The serializer options.</param>
    public override void Write(Utf8JsonWriter writer, ChartJsInteractionMode? value, JsonSerializerOptions options) {
        if (value.HasValue) {
            writer.WriteStringValue(value.Value.ToString().ToLowerInvariant());
        } else {
            writer.WriteNullValue();
        }
    }
}