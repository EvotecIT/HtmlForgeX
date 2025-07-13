using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace HtmlForgeX;

public class VisNetworkNode {
    public object? Id { get; set; }
    public string? Label { get; set; }
    public string? Title { get; set; }
    public string? Image { get; set; }
    public VisNetworkNodeShape? Shape { get; set; }
    public string? Group { get; set; }
    public string? Color { get; set; }
    public double? Size { get; set; }
    public bool? Hidden { get; set; }
    public bool? Physics { get; set; }
    public double? X { get; set; }
    public double? Y { get; set; }
    public bool SkipAutoEmbedding { get; set; }
    public Dictionary<string, object> Custom { get; } = new();

    public VisNetworkNode SetCustom(string key, object value) {
        Custom[key] = value;
        return this;
    }

    public VisNetworkNode IdValue(object id) {
        Id = id;
        return this;
    }

    public VisNetworkNode LabelText(string label) {
        Label = label;
        return this;
    }

    public VisNetworkNode TitleText(string title) {
        Title = title;
        return this;
    }

    public VisNetworkNode UseImage(string url) {
        Image = url;
        Shape ??= VisNetworkNodeShape.Image;
        return this;
    }

    public VisNetworkNode UseImageOffline(string source, int timeoutSeconds = 30) {
        Image = EmbedImage(source, timeoutSeconds);
        Shape ??= VisNetworkNodeShape.Image;
        return this;
    }

    public VisNetworkNode NodeShape(VisNetworkNodeShape shape) {
        Shape = shape;
        return this;
    }

    public VisNetworkNode NodeGroup(string group) {
        Group = group;
        return this;
    }

    public VisNetworkNode NodeColor(string color) {
        Color = color;
        return this;
    }

    public VisNetworkNode NodeColor(RGBColor color) {
        Color = color.ToHex();
        return this;
    }

    public VisNetworkNode NodeSize(double size) {
        Size = size;
        return this;
    }

    public VisNetworkNode NodeHidden(bool hidden = true) {
        Hidden = hidden;
        return this;
    }

    public VisNetworkNode NodePhysics(bool physics = true) {
        Physics = physics;
        return this;
    }

    public VisNetworkNode WithoutAutoEmbedding() {
        SkipAutoEmbedding = true;
        return this;
    }

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
