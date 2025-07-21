namespace HtmlForgeX;

/// <summary>
/// Font Awesome 5 Regular icons for use with VisNetwork and other components that require Font Awesome 5
/// </summary>
public enum FontAwesome5Regular {
    /// <summary>Address Book icon (fa-address-book)</summary>
    AddressBook = 0xf2b9,
    /// <summary>Address Card icon (fa-address-card)</summary>
    AddressCard = 0xf2bb,
    /// <summary>Bell icon (fa-bell)</summary>
    Bell = 0xf0f3,
    /// <summary>Calendar icon (fa-calendar)</summary>
    Calendar = 0xf133,
    /// <summary>Clock icon (fa-clock)</summary>
    Clock = 0xf017,
    /// <summary>Comment icon (fa-comment)</summary>
    Comment = 0xf075,
    /// <summary>Envelope icon (fa-envelope)</summary>
    Envelope = 0xf0e0,
    /// <summary>File icon (fa-file)</summary>
    File = 0xf15b,
    /// <summary>Folder icon (fa-folder)</summary>
    Folder = 0xf07b,
    /// <summary>Heart icon (fa-heart)</summary>
    Heart = 0xf004,
    /// <summary>Star icon (fa-star)</summary>
    Star = 0xf005,
    /// <summary>User icon (fa-user)</summary>
    User = 0xf007
}

/// <summary>
/// Extension methods for FontAwesome5Regular icons
/// </summary>
public static class FontAwesome5RegularExtensions {
    /// <summary>
    /// Gets the Unicode character code for the icon
    /// </summary>
    public static string GetCode(this FontAwesome5Regular icon) {
        return char.ConvertFromUtf32((int)icon);
    }
}