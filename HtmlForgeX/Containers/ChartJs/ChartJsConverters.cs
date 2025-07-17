using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Converts ChartJsPosition enum to lowercase string.
/// </summary>
public class ChartJsPositionConverter : JsonConverter<ChartJsPosition> {
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

    public override void Write(Utf8JsonWriter writer, ChartJsPosition value, JsonSerializerOptions options) {
        writer.WriteStringValue(value.ToString().ToLowerInvariant());
    }
}

/// <summary>
/// Converts ChartJsAlign enum to lowercase string.
/// </summary>
public class ChartJsAlignConverter : JsonConverter<ChartJsAlign> {
    public override ChartJsAlign Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var value = reader.GetString();
        return value?.ToLowerInvariant() switch {
            "start" => ChartJsAlign.Start,
            "center" => ChartJsAlign.Center,
            "end" => ChartJsAlign.End,
            _ => ChartJsAlign.Center
        };
    }

    public override void Write(Utf8JsonWriter writer, ChartJsAlign value, JsonSerializerOptions options) {
        writer.WriteStringValue(value.ToString().ToLowerInvariant());
    }
}

/// <summary>
/// Converts ChartJsInteractionMode enum to lowercase string.
/// </summary>
public class ChartJsInteractionModeConverter : JsonConverter<ChartJsInteractionMode> {
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

    public override void Write(Utf8JsonWriter writer, ChartJsInteractionMode value, JsonSerializerOptions options) {
        writer.WriteStringValue(value.ToString().ToLowerInvariant());
    }
}

/// <summary>
/// Converts ChartJsFontStyle enum to lowercase string.
/// </summary>
public class ChartJsFontStyleConverter : JsonConverter<ChartJsFontStyle> {
    public override ChartJsFontStyle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
        var value = reader.GetString();
        return value?.ToLowerInvariant() switch {
            "normal" => ChartJsFontStyle.Normal,
            "italic" => ChartJsFontStyle.Italic,
            "oblique" => ChartJsFontStyle.Oblique,
            _ => ChartJsFontStyle.Normal
        };
    }

    public override void Write(Utf8JsonWriter writer, ChartJsFontStyle value, JsonSerializerOptions options) {
        writer.WriteStringValue(value.ToString().ToLowerInvariant());
    }
}

/// <summary>
/// Converts ChartJsFontWeight enum to lowercase string or numeric value.
/// </summary>
public class ChartJsFontWeightConverter : JsonConverter<ChartJsFontWeight> {
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

    public override void Write(Utf8JsonWriter writer, ChartJsFontWeight value, JsonSerializerOptions options) {
        writer.WriteStringValue(value.ToString().ToLowerInvariant());
    }
}

/// <summary>
/// Converts nullable ChartJsPosition enum.
/// </summary>
public class ChartJsPositionNullableConverter : JsonConverter<ChartJsPosition?> {
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

    public override void Write(Utf8JsonWriter writer, ChartJsInteractionMode? value, JsonSerializerOptions options) {
        if (value.HasValue) {
            writer.WriteStringValue(value.Value.ToString().ToLowerInvariant());
        } else {
            writer.WriteNullValue();
        }
    }
}