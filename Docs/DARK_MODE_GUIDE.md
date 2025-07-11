# HtmlForgeX Email Dark Mode Guide

## Overview

HtmlForgeX provides comprehensive dark mode support for email templates that actually works across major email clients. The implementation follows email client best practices and includes proper fallbacks.

## ✅ What's Implemented

### 1. **Configuration System**
- Document-style configuration: `email.SetThemeMode(EmailThemeMode.Dark)`
- Three theme modes: Light, Dark, and Auto
- Per-email configuration with proper inheritance

### 2. **Comprehensive CSS Support**
- Dark backgrounds (`#1f2937` for body, `#2b3648` for content boxes)
- Light text colors with proper contrast ratios
- Dark mode button styling with adjusted colors
- Dark mode table support with proper borders
- Link color adjustments (`#60a5fa` for better visibility)
- Media query support for auto mode

### 3. **Email Client Compatibility**
- Proper color scheme meta tags
- XHTML 1.0 Strict compliance
- Microsoft Outlook namespace support
- Apple Mail dark mode detection
- Gmail dark mode compatibility

### 4. **Component Coverage**
- EmailBox backgrounds and borders
- EmailText color adjustments
- EmailButton dark mode variants
- EmailTable header and cell styling
- EmailHeader and EmailFooter support
- EmailLink color modifications

### 5. **🆕 Enhanced Features (Latest)**
- **Image Variants**: Automatic switching between light and dark images
- **Enhanced Links**: Better contrast and hover states in dark mode
- **Improved Tables**: Comprehensive styling with proper borders and cell colors
- **Smart Image Detection**: Automatic embedding of both light and dark variants
- **Theme-Aware Colors**: All components automatically adjust colors based on theme

## 🚀 Usage Examples

### Basic Dark Mode

```csharp
var email = new Email()
    .SetThemeMode(EmailThemeMode.Dark)  // Enable dark mode
    .EnableImageEmbedding()
    .ConfigureLayout();

email.Head.AddTitle("Dark Mode Email")
          .AddEmailCoreStyles();

email.Body.EmailBox(emailBox => {
    emailBox.EmailContent(content => {
        content.EmailText("🌙 Dark Mode Demo")
            .WithFontSize(EmailFontSize.Heading1)
            .WithAlignment("center");
    });
});

email.Save("dark-mode-email.html");
```

### Auto Mode (System Preference)

```csharp
var email = new Email()
    .SetThemeMode(EmailThemeMode.Auto)  // Adapts to user's system
    .EnableImageEmbedding()
    .ConfigureLayout();
```

### Light Mode (Default)

```csharp
var email = new Email()
    .SetThemeMode(EmailThemeMode.Light)  // Explicit light mode
    .EnableImageEmbedding()
    .ConfigureLayout();
```

### 🆕 Enhanced Features Usage

#### Image Variants (Automatic Light/Dark Switching)

```csharp
// Method 1: Set light and dark images as a pair (Recommended)
var logoImage = new EmailImage()
    .WithImagePair(
        "logo-light.png",    // Light mode image
        "logo-dark.png",     // Dark mode image
        "Company Logo"       // Alt text for both
    )
    .WithWidth("150px")
    .WithAlignment("center");

// Method 2: Add dark mode variant to existing image
var existingImage = new EmailImage("logo-light.png")
    .WithDarkModeSource("logo-dark.png")
    .WithWidth("150px");

// Method 3: Disable dark mode switching for specific images
var staticImage = new EmailImage("photo.jpg")
    .WithoutDarkModeSwapping(); // Same image in both modes
```

#### Enhanced Links with Theme-Aware Colors

```csharp
// Basic link - automatically adjusts colors for dark mode
var basicLink = new EmailLink("Visit Website", "https://example.com");

// Custom colored link - overrides theme defaults
var customLink = new EmailLink("Custom Link", "https://example.com")
    .WithColor("#10b981")        // Custom color overrides theme
    .WithHoverColor("#059669");  // Custom hover color

// Link with enhanced styling
var styledLink = new EmailLink("Contact Support", "mailto:support@example.com")
    .WithFontWeight(EmailFontWeight.SemiBold)
    .WithAlignment("center")
    .WithNewWindow(true);
```

#### Improved Tables with Enhanced Dark Mode

```csharp
// Enable enhanced dark mode styling for tables
var tableData = new List<dynamic> {
    new { Name = "John Doe", Email = "john@example.com", Status = "Active" },
    new { Name = "Jane Smith", Email = "jane@example.com", Status = "Pending" }
};

emailBox.EmailTable(tableData)
    .SetStyle(EmailTableStyle.Striped)
    .SetCssClass("email-table");  // Enables enhanced dark mode styling
```

#### Smart Image Detection and Embedding

```csharp
// Automatically embeds both light and dark variants
var smartImage = new EmailImage()
    .WithImagePair(
        "https://example.com/logo-light.png",  // URL
        "./assets/logo-dark.png",              // Local file
        "Smart Logo"
    )
    .WithAutoEmbedding();  // Embeds both variants automatically
```

## 🎨 Dark Mode Color Scheme

| Component | Light Mode | Dark Mode |
|-----------|------------|-----------|
| Body Background | `#f9fafb` | `#1f2937` |
| Content Box | `#ffffff` | `#2b3648` |
| Primary Text | `#4b5563` | `rgba(255,255,255,0.8)` |
| Headings | `#111827` | `rgba(255,255,255,0.9)` |
| Muted Text | `#667382` | `rgba(255,255,255,0.4)` |
| Primary Button | `#066FD1` | `#1d4ed8` |
| Links | `#066FD1` | `#60a5fa` |
| Table Headers | `#667382` | `rgba(255,255,255,0.6)` |
| Borders | `#e8ebee` | `#4b5563` |

### 🆕 Enhanced Color Scheme

| Component | Light Mode | Dark Mode | Notes |
|-----------|------------|-----------|-------|
| **Links** | `#066FD1` | `#60a5fa` | Enhanced contrast for better readability |
| **Link Hover** | `#0056B3` | `#93c5fd` | Lighter blue for hover state |
| **Link Visited** | `#551A8B` | `#a78bfa` | Purple variants for visited links |
| **Link Active** | `#CC0000` | `#c4b5fd` | Active state colors |
| **Table Stripes** | `#f9fafb` | `#374151` | Alternating row colors |
| **Table Hover** | `#f3f4f6` | `#4b5563` | Row hover effect |
| **Table Borders** | `#e5e7eb` | `#4b5563` | Enhanced border visibility |

## 📧 Email Client Support

### ✅ **Fully Supported**
- **Apple Mail** (macOS/iOS) - Native dark mode detection
- **Outlook 2019+** (Windows/Mac) - CSS override support
- **Gmail** (Web/Mobile) - Theme-aware styling
- **Yahoo Mail** - Basic dark mode support
- **Thunderbird** - CSS media query support

### ⚠️ **Partial Support**
- **Outlook 2016/2013** - Limited CSS support, fallback colors used
- **Outlook.com** - Basic styling only
- **AOL Mail** - Limited dark mode features

### ❌ **Not Supported**
- **Outlook 2007/2010** - No dark mode support (graceful fallback)

## 🔧 Technical Implementation

### Meta Tags for Dark Mode Detection

```html
<meta name="color-scheme" content="light dark" />
<meta name="supported-color-schemes" content="light dark only" />
```

### CSS Architecture

The system uses a combination of:

1. **CSS Classes**: `.theme-dark` for forced dark mode
2. **Media Queries**: `@media (prefers-color-scheme: dark)` for auto mode
3. **Inline Styles**: For maximum email client compatibility
4. **Important Overrides**: `!important` for reliable color application

### Auto Mode Implementation

```css
@media (prefers-color-scheme: dark) {
    .auto-dark-mode .box {
        background-color: #2b3648 !important;
        color: rgba(255, 255, 255, 0.7) !important;
    }
}
```

## 🧪 Testing Dark Mode

### Testing in Development

1. **Enable dark mode example**:
   ```csharp
   // In Program.cs, uncomment:
   ExampleDarkModeEmail.Create(openInBrowser: true);
   ```

2. **Create comparison emails**:
   ```csharp
   ExampleDarkModeEmail.CreateLightModeComparison(true);
   ExampleDarkModeEmail.CreateAutoModeExample(true);
   ```

### Testing in Email Clients

1. **Apple Mail**: Switch system dark mode on/off
2. **Outlook**: Use built-in theme switcher
3. **Gmail**: Check in both light and dark themes
4. **Mobile**: Test on iOS/Android with system dark mode

## 🎯 Best Practices

### 1. **Color Contrast**
- Maintain WCAG AA contrast ratios (4.5:1 minimum)
- Test with actual email clients, not just browsers
- Use semi-transparent whites for better readability

### 2. **Image Considerations**
- Use dark mode logo variants when possible
- Consider image backgrounds in dark mode
- Test image visibility on dark backgrounds

### 3. **Fallback Strategy**
- Always provide light mode fallbacks
- Use progressive enhancement approach
- Test on older email clients

### 4. **Content Strategy**
- Write content that works in both themes
- Avoid hard-coded color references in text
- Use semantic color names in documentation

## 🐛 Troubleshooting

### Common Issues

1. **Colors not applying**: Check if `!important` is needed
2. **Outlook not working**: Verify XHTML compliance
3. **Auto mode not detecting**: Ensure proper meta tags
4. **Images invisible**: Check image backgrounds and contrast

### Debug Checklist

- [ ] Meta tags present in `<head>`
- [ ] CSS classes applied to body element
- [ ] Dark mode images provided for logos
- [ ] Table CSS class set to `email-table`
- [ ] Image variants properly configured
- [ ] Link colors not overridden by custom CSS

### 🆕 Enhanced Features Troubleshooting

#### Image Variants Not Switching

1. **Check image paths**: Ensure both light and dark images exist
   ```csharp
   // Verify both images are accessible
   var image = new EmailImage()
       .WithImagePair("./logo-light.png", "./logo-dark.png", "Logo");
   ```

2. **Verify CSS classes**: Dark mode images need proper CSS classes
   ```html
   <!-- Light image should have class="light-img" -->
   <!-- Dark image should have class="dark-img" -->
   ```

3. **Check embedding**: Both images should embed if auto-embedding is enabled
   ```csharp
   // Force embedding for both variants
   var image = new EmailImage()
       .WithImagePair("logo-light.png", "logo-dark.png", "Logo")
       .WithAutoEmbedding();
   ```

#### Links Not Showing Proper Colors

1. **Custom colors override theme**: Check if custom colors are set
   ```csharp
   // This will override theme colors
   var link = new EmailLink("Text", "url").WithColor("#custom");

   // This will use theme colors
   var link = new EmailLink("Text", "url"); // No custom color
   ```

2. **CSS specificity issues**: Ensure theme CSS has proper `!important`
   ```css
   .theme-dark a {
       color: #60a5fa !important;
   }
   ```

#### Tables Not Styling Properly

1. **Missing CSS class**: Tables need `email-table` class for enhanced styling
   ```csharp
   // Correct usage
   emailBox.EmailTable(data)
       .SetCssClass("email-table");

   // Won't get enhanced styling
   emailBox.EmailTable(data); // Missing CSS class
   ```

2. **Check table structure**: Ensure proper HTML structure
   ```html
   <table class="email-table">
       <thead>
           <tr><th>Header</th></tr>
       </thead>
       <tbody>
           <tr><td>Data</td></tr>
       </tbody>
   </table>
   ```

#### Email Client Specific Issues

1. **Outlook image swapping**: Some Outlook versions may not support CSS image swapping
   - **Solution**: Use VML fallbacks or provide single optimized image

2. **Gmail link colors**: Gmail may override link colors
   - **Solution**: Use inline styles with `!important`

3. **Apple Mail image caching**: Images may not switch immediately
   - **Solution**: Use different filenames for light/dark variants

### Performance Considerations

#### Image Variants and File Size

1. **Optimize both variants**: Ensure both light and dark images are optimized
   ```csharp
   var image = new EmailImage()
       .WithImagePair("logo-light.png", "logo-dark.png", "Logo")
       .WithOptimization(maxWidth: 300, maxHeight: 100, quality: 85);
   ```

2. **Consider file size limits**: Both images count toward email size
   ```csharp
   var email = new Email()
       .SetMaxEmbedFileSize(1 * 1024 * 1024); // 1MB total limit
   ```

3. **Smart loading**: Use conditional loading for large images
   ```csharp
   var image = new EmailImage()
       .WithImagePair("logo-light.png", "logo-dark.png", "Logo")
       .WithoutAutoEmbedding(); // Load via URL instead of embedding
   ```

## 📚 Examples

The following examples demonstrate dark mode functionality:

- `ExampleDarkModeEmail.Create()` - Comprehensive dark mode demo
- `ExampleDarkModeEmail.CreateLightModeComparison()` - Side-by-side comparison
- `ExampleDarkModeEmail.CreateAutoModeExample()` - System preference detection

## 🔮 Future Enhancements

### Planned Features
- [ ] High contrast mode support
- [ ] Custom dark mode color schemes
- [ ] Image auto-inversion for dark mode
- [ ] Better Outlook 365 support
- [ ] Dark mode email analytics

### Advanced Configuration
```csharp
// Future API (not yet implemented)
var email = new Email()
    .SetThemeMode(EmailThemeMode.Auto)
    .ConfigureDarkModeColors(
        background: "#1a1a1a",
        text: "#e0e0e0",
        accent: "#4a9eff"
    )
    .EnableHighContrastMode(true);
```

## 📖 Related Documentation

- [Email System Analysis](EMAIL_SYSTEM_ANALYSIS.md)
- [Component Reference](COMPONENT_REFERENCE.md)
- [Development Guide](DEVELOPMENT_GUIDE.md)
- [Getting Started](GETTING_STARTED.md)

---

**Dark mode that actually works in email clients! 🌙**