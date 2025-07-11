# Base64 Image Embedding Guide

## Overview

HtmlForgeX now supports comprehensive base64 image embedding for offline email compatibility. This feature allows you to embed images directly into email HTML as base64 data URIs, ensuring that images display correctly even when the email is viewed offline or when image blocking is enabled in email clients.

## Key Features

### 🔧 Multiple Embedding Methods
- **File Embedding**: Embed images from local file paths
- **URL Embedding**: Download and embed images from remote URLs
- **Smart Embedding**: Automatically detect file paths vs URLs
- **Direct Base64**: Use pre-encoded base64 data

### ⚡ Image Optimization
- Configurable image resizing (max width/height)
- JPEG quality control (0-100%)
- Automatic optimization during embedding
- Size reduction for better email performance

### 🎯 Email Client Compatibility
- Works with most email clients (Outlook, Gmail, Apple Mail, etc.)
- Bypasses image blocking security measures
- Ensures consistent email appearance across platforms
- No external dependencies required

## Usage Examples

### Basic File Embedding

```csharp
// Embed a local image file
content.EmailImage("path/to/logo.png")
    .EmbedFromFile("path/to/logo.png")
    .WithWidth("150px")
    .WithAlignment("center");
```

### URL Embedding

```csharp
// Embed an image from a URL
content.EmailImage("https://example.com/logo.png")
    .EmbedFromUrl("https://example.com/logo.png")
    .WithWidth("150px")
    .WithAlignment("center");
```

### Smart Embedding (Recommended)

```csharp
// Automatically detect file path vs URL
content.EmailImage("path/to/logo.png")
    .EmbedSmart("path/to/logo.png")  // Auto-detects file
    .WithWidth("150px")
    .WithAlignment("center");

content.EmailImage("https://example.com/logo.png")
    .EmbedSmart("https://example.com/logo.png")  // Auto-detects URL
    .WithWidth("150px")
    .WithAlignment("center");
```

### With Image Optimization

```csharp
// Embed with size and quality optimization
content.EmailImage("path/to/large-image.jpg")
    .EmbedFromFile("path/to/large-image.jpg")
    .WithOptimization(800, 600, 85)  // Max 800x600, 85% quality
    .WithWidth("400px")
    .WithAlignment("center");
```

### Direct Base64 Embedding

```csharp
// Use pre-encoded base64 data
var base64Data = "iVBORw0KGgoAAAANSUhEUgAAAAEAAAABCAYAAAAfFcSJAAAADUlEQVR42mP8/5+hHgAHggJ/PchI7wAAAABJRU5ErkJggg==";
content.EmailImage()
    .EmbedFromBase64(base64Data, "image/png")
    .WithWidth("100px")
    .WithAlignment("center");
```

### Advanced Styling with Embedding

```csharp
// Combine embedding with advanced styling
content.EmailImage("path/to/logo.png")
    .EmbedFromFile("path/to/logo.png")
    .WithWidth("120px")
    .WithAlignment("center")
    .WithBorder("2px solid #059669")
    .WithBorderRadius("8px")
    .WithLink("https://example.com")
    .WithAlternativeText("Company Logo");
```

## Method Reference

### Embedding Methods

#### `.EmbedFromFile(string filePath)`
Embeds an image from a local file path as base64.

**Parameters:**
- `filePath`: Path to the image file

**Supported Formats:**
- JPEG (.jpg, .jpeg)
- PNG (.png)
- GIF (.gif)
- SVG (.svg)
- WebP (.webp)
- BMP (.bmp)
- TIFF (.tiff, .tif)
- ICO (.ico)

#### `.EmbedFromUrl(string url, int timeoutSeconds = 30)`
Downloads and embeds an image from a remote URL.

**Parameters:**
- `url`: URL of the image to download
- `timeoutSeconds`: Timeout for the download (default: 30 seconds)

#### `.EmbedSmart(string source, int timeoutSeconds = 30)`
Automatically detects whether the source is a file path or URL and handles appropriately.

**Parameters:**
- `source`: File path or URL
- `timeoutSeconds`: Timeout for URL downloads (default: 30 seconds)

#### `.EmbedFromBase64(string base64Data, string mimeType)`
Embeds an image using pre-encoded base64 data.

**Parameters:**
- `base64Data`: Base64 encoded image data
- `mimeType`: MIME type of the image (e.g., "image/png")

### Optimization Methods

#### `.WithOptimization(int maxWidth = 0, int maxHeight = 0, int quality = 85)`
Enables image optimization with specified parameters.

**Parameters:**
- `maxWidth`: Maximum width in pixels (0 = no limit)
- `maxHeight`: Maximum height in pixels (0 = no limit)
- `quality`: JPEG quality (0-100, default: 85)

#### `.WithoutOptimization()`
Disables image optimization.

## Best Practices

### 1. Choose the Right Method
- Use `.EmbedSmart()` for most cases - it automatically handles detection
- Use `.EmbedFromFile()` when you know you're working with local files
- Use `.EmbedFromUrl()` when you need specific timeout control for URLs
- Use `.EmbedFromBase64()` when you already have base64 data

### 2. Optimize Images
```csharp
// For large images, always use optimization
emailImage.WithOptimization(800, 600, 80);  // Reasonable size and quality
```

### 3. Keep Email Size Manageable
- Base64 encoding increases file size by ~33%
- Keep total email size under 100KB when possible
- Use optimization for images larger than 200KB

### 4. Test Across Email Clients
- Test in Outlook, Gmail, Apple Mail, and other target clients
- Some clients have base64 size limits
- Consider fallback strategies for very large images

### 5. Use Appropriate Alternative Text
```csharp
emailImage.WithAlternativeText("Descriptive alt text for accessibility");
```

## Email Client Compatibility

### ✅ Fully Supported
- Microsoft Outlook (2016+)
- Apple Mail
- Mozilla Thunderbird
- Most desktop email clients

### ⚠️ Partially Supported
- Gmail (works but may have size limits)
- Yahoo Mail (works but may have size limits)
- Outlook.com (works but may have size limits)

### ❌ Limited Support
- Very old email clients (pre-2010)
- Some mobile email apps with strict security policies

## Troubleshooting

### Images Not Displaying
1. **Check file paths**: Ensure the file exists and path is correct
2. **Verify image format**: Use supported formats (PNG, JPEG, GIF, etc.)
3. **Check email size**: Large base64 images may exceed email size limits
4. **Test in different clients**: Some clients have stricter base64 policies

### Performance Issues
1. **Enable optimization**: Use `.WithOptimization()` for large images
2. **Reduce image dimensions**: Resize images before embedding
3. **Use appropriate quality**: 80-85% JPEG quality is usually sufficient

### URL Embedding Failures
1. **Check connectivity**: Ensure the URL is accessible
2. **Increase timeout**: Use longer timeout for slow connections
3. **Verify URL format**: Ensure URL points to an actual image file
4. **Handle HTTPS**: Some servers require HTTPS for image access

## Error Handling

The embedding methods include automatic fallback behavior:

```csharp
// If embedding fails, falls back to original source
emailImage.EmbedFromFile("non-existent-file.png");
// Result: Uses "non-existent-file.png" as src (normal image link)

emailImage.EmbedFromUrl("https://invalid-url.com/image.png");
// Result: Uses the URL as src (normal image link)
```

## Migration from Standard Images

### Before (Standard Image Links)
```csharp
content.EmailImage("https://example.com/logo.png")
    .WithWidth("150px")
    .WithAlignment("center");
```

### After (Base64 Embedded)
```csharp
content.EmailImage("https://example.com/logo.png")
    .EmbedSmart("https://example.com/logo.png")  // Add this line
    .WithWidth("150px")
    .WithAlignment("center");
```

## Advanced Examples

### Conditional Embedding
```csharp
var emailImage = content.EmailImage("path/to/logo.png");

if (embedImagesForOfflineUse)
{
    emailImage.EmbedSmart("path/to/logo.png");
}

emailImage.WithWidth("150px").WithAlignment("center");
```

### Multiple Images with Different Strategies
```csharp
// Logo - always embed for branding consistency
content.EmailImage("assets/logo.png")
    .EmbedFromFile("assets/logo.png")
    .WithWidth("200px")
    .WithAlignment("center");

// Product images - embed with optimization
content.EmailImage("products/product1.jpg")
    .EmbedFromFile("products/product1.jpg")
    .WithOptimization(400, 300, 80)
    .WithWidth("200px");

// Remote images - smart embedding with fallback
content.EmailImage("https://cdn.example.com/banner.jpg")
    .EmbedSmart("https://cdn.example.com/banner.jpg")
    .WithWidth("600px");
```

## Conclusion

Base64 image embedding in HtmlForgeX provides a powerful solution for creating offline-compatible emails that display consistently across email clients. By following the best practices and using the appropriate embedding methods, you can ensure your emails look professional and load reliably regardless of the recipient's email client or network conditions.

For more examples, see the `ExampleBase64EmbeddingEmail.cs` file in the Examples project.