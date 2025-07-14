using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace HtmlForgeX;

/// <summary>
/// Represents a node in a Vis Network diagram.
/// </summary>
public class VisNetworkNode {
    /// <summary>
    /// Gets or sets the unique identifier of the node.
    /// </summary>
    public object? Id { get; set; }

    /// <summary>
    /// Gets or sets the text label displayed inside the node.
    /// </summary>
    public string? Label { get; set; }

    /// <summary>
    /// Gets or sets the tooltip title shown when hovering over the node.
    /// </summary>
    public string? Title { get; set; }

    /// <summary>
    /// Gets or sets the image URL or data URI used when the <see cref="Shape"/>
    /// is set to <see cref="VisNetworkNodeShape.Image"/>.
    /// </summary>
    public string? Image { get; set; }

    /// <summary>
    /// Gets or sets the visual representation of the node.
    /// </summary>
    public VisNetworkNodeShape? Shape { get; set; }

    /// <summary>
    /// Gets or sets the optional group name for the node.
    /// </summary>
    public string? Group { get; set; }

    /// <summary>
    /// Gets or sets the color of the node using a CSS color string.
    /// </summary>
    public string? Color { get; set; }

    /// <summary>
    /// Gets or sets the size of the node in pixels.
    /// </summary>
    public double? Size { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the node should be hidden.
    /// </summary>
    public bool? Hidden { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether physics calculations
    /// are enabled for this node.
    /// </summary>
    public bool? Physics { get; set; }

    /// <summary>
    /// Gets or sets the X coordinate used for the initial positioning
    /// of the node.
    /// </summary>
    public double? X { get; set; }

    /// <summary>
    /// Gets or sets the Y coordinate used for the initial positioning
    /// of the node.
    /// </summary>
    public double? Y { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether automatic image embedding
    /// should be skipped when offline mode is active.
    /// </summary>
    public bool SkipAutoEmbedding { get; set; }

    /// <summary>
    /// Gets a dictionary of custom key/value pairs that will be serialized
    /// along with the node definition.
    /// </summary>
    public Dictionary<string, object> Custom { get; } = new();

    /// <summary>
    /// Adds a custom property that will be serialized with the node.
    /// </summary>
    /// <param name="key">Property name.</param>
    /// <param name="value">Property value.</param>
    /// <returns>The current <see cref="VisNetworkNode"/> instance.</returns>
    public VisNetworkNode SetCustom(string key, object value) {
        Custom[key] = value;
        return this;
    }

    /// <summary>
    /// Sets the node identifier.
    /// </summary>
    /// <param name="id">Identifier value.</param>
    /// <returns>The current <see cref="VisNetworkNode"/> instance.</returns>
    public VisNetworkNode IdValue(object id) {
        Id = id;
        return this;
    }

    /// <summary>
    /// Sets the text label shown on the node.
    /// </summary>
    /// <param name="label">Label text.</param>
    /// <returns>The current <see cref="VisNetworkNode"/> instance.</returns>
    public VisNetworkNode LabelText(string label) {
        Label = label;
        return this;
    }

    /// <summary>
    /// Sets the tooltip title for the node.
    /// </summary>
    /// <param name="title">Title text.</param>
    /// <returns>The current <see cref="VisNetworkNode"/> instance.</returns>
    public VisNetworkNode TitleText(string title) {
        Title = title;
        return this;
    }

    /// <summary>
    /// Uses an external image for the node.
    /// </summary>
    /// <param name="url">URL of the image.</param>
    /// <returns>The current <see cref="VisNetworkNode"/> instance.</returns>
    public VisNetworkNode UseImage(string url) {
        Image = url;
        Shape ??= VisNetworkNodeShape.Image;
        return this;
    }

    /// <summary>
    /// Embeds an image from a file or URL into the document.
    /// </summary>
    /// <param name="source">Local path or URL of the image.</param>
    /// <param name="timeoutSeconds">Download timeout in seconds.</param>
    /// <returns>The current <see cref="VisNetworkNode"/> instance.</returns>
    public VisNetworkNode UseImageOffline(string source, int timeoutSeconds = 30) {
        Image = EmbedImage(source, timeoutSeconds);
        Shape ??= VisNetworkNodeShape.Image;
        return this;
    }

    /// <summary>
    /// Sets the visual shape of the node.
    /// </summary>
    /// <param name="shape">Shape type.</param>
    /// <returns>The current <see cref="VisNetworkNode"/> instance.</returns>
    public VisNetworkNode NodeShape(VisNetworkNodeShape shape) {
        Shape = shape;
        return this;
    }

    /// <summary>
    /// Assigns the node to a group.
    /// </summary>
    /// <param name="group">Group name.</param>
    /// <returns>The current <see cref="VisNetworkNode"/> instance.</returns>
    public VisNetworkNode NodeGroup(string group) {
        Group = group;
        return this;
    }

    /// <summary>
    /// Sets the node color using a CSS color string.
    /// </summary>
    /// <param name="color">Color value.</param>
    /// <returns>The current <see cref="VisNetworkNode"/> instance.</returns>
    public VisNetworkNode NodeColor(string color) {
        Color = color;
        return this;
    }

    /// <summary>
    /// Sets the node color using an <see cref="RGBColor"/> object.
    /// </summary>
    /// <param name="color">Color instance.</param>
    /// <returns>The current <see cref="VisNetworkNode"/> instance.</returns>
    public VisNetworkNode NodeColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    /// <summary>
    /// Sets the size of the node.
    /// </summary>
    /// <param name="size">Size value.</param>
    /// <returns>The current <see cref="VisNetworkNode"/> instance.</returns>
    public VisNetworkNode NodeSize(double size) {
        Size = size;
        return this;
    }

    /// <summary>
    /// Determines whether the node should be hidden.
    /// </summary>
    /// <param name="hidden">True to hide the node.</param>
    /// <returns>The current <see cref="VisNetworkNode"/> instance.</returns>
    public VisNetworkNode NodeHidden(bool hidden = true) {
        Hidden = hidden;
        return this;
    }

    /// <summary>
    /// Enables or disables physics calculations for the node.
    /// </summary>
    /// <param name="physics">True to enable physics.</param>
    /// <returns>The current <see cref="VisNetworkNode"/> instance.</returns>
    public VisNetworkNode NodePhysics(bool physics = true) {
        Physics = physics;
        return this;
    }

    /// <summary>
    /// Prevents the library from automatically embedding the image when offline mode is active.
    /// </summary>
    /// <returns>The current <see cref="VisNetworkNode"/> instance.</returns>
    public VisNetworkNode WithoutAutoEmbedding() {
        SkipAutoEmbedding = true;
        return this;
    }

    /// <summary>
    /// Sets the initial position of the node.
    /// </summary>
    /// <param name="x">X coordinate.</param>
    /// <param name="y">Y coordinate.</param>
    /// <returns>The current <see cref="VisNetworkNode"/> instance.</returns>
    public VisNetworkNode Position(double x, double y) {
        X = x;
        Y = y;
        return this;
    }

    internal void ApplyDocumentConfiguration(Document? document) {
        if (document == null) return;

        if (string.IsNullOrEmpty(Image)) return;

        if (SkipAutoEmbedding) return;

        if (Image.StartsWith("data:", StringComparison.OrdinalIgnoreCase)) return;

        if (document.Configuration.LibraryMode == LibraryMode.Offline && document.Configuration.Images.AutoEmbedImages) {
            Image = EmbedImage(Image, document.Configuration.Images.EmbeddingTimeout);
            Shape ??= VisNetworkNodeShape.Image;
        }
    }

    internal Dictionary<string, object> ToDictionary() {
        var dict = new Dictionary<string, object>(Custom);
        if (Id != null) dict["id"] = Id;
        if (Label != null) dict["label"] = Label;
        if (Title != null) dict["title"] = Title;
        if (Image != null) dict["image"] = Image;
        if (Shape != null) dict["shape"] = Shape.Value.EnumToString();
        if (Group != null) dict["group"] = Group;
        if (Color != null) dict["color"] = Color;
        if (Size != null) dict["size"] = Size;
        if (Hidden != null) dict["hidden"] = Hidden;
        if (Physics != null) dict["physics"] = Physics;
        if (X != null) dict["x"] = X;
        if (Y != null) dict["y"] = Y;
        if (Image != null && Shape == null) dict["shape"] = "image";
        return dict;
    }

    private static string EmbedImage(string source, int timeoutSeconds) {
        if (string.IsNullOrEmpty(source)) {
            return source;
        }

        try {
            byte[] bytes;
            string mimeType;

            if (Uri.TryCreate(source, UriKind.Absolute, out var uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps)) {
                using var httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(timeoutSeconds) };
                var response = httpClient.GetAsync(source).Result;
                if (!response.IsSuccessStatusCode) {
                    return source;
                }

                bytes = response.Content.ReadAsByteArrayAsync().Result;
                mimeType = response.Content.Headers.ContentType?.MediaType ?? GetMimeTypeFromUrl(source);
            } else if (File.Exists(source)) {
                bytes = File.ReadAllBytes(source);
                var extension = Path.GetExtension(source).ToLowerInvariant();
                mimeType = GetMimeTypeFromExtension(extension);
            } else {
                return source;
            }

            var base64 = Convert.ToBase64String(bytes);
            return $"data:{mimeType};base64,{base64}";
        } catch {
            return source;
        }
    }

    private static string GetMimeTypeFromExtension(string extension) => extension switch {
        ".jpg" or ".jpeg" => "image/jpeg",
        ".png" => "image/png",
        ".gif" => "image/gif",
        ".svg" => "image/svg+xml",
        ".webp" => "image/webp",
        ".bmp" => "image/bmp",
        ".tiff" or ".tif" => "image/tiff",
        ".ico" => "image/x-icon",
        _ => "image/png"
    };

    private static string GetMimeTypeFromUrl(string url) {
        try {
            var uri = new Uri(url);
            var extension = Path.GetExtension(uri.LocalPath);
            return GetMimeTypeFromExtension(extension);
        } catch {
            return "image/png";
        }
    }
}
