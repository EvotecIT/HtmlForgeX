using System.Text.Json.Serialization;

namespace HtmlForgeX;

/// <summary>
/// Supported locales for VisNetwork interface texts.
/// </summary>
[JsonConverter(typeof(VisNetworkEnumConverter<VisNetworkLocale>))]
public enum VisNetworkLocale {
    /// <summary>
    /// English locale.
    /// </summary>
    En,

    /// <summary>
    /// Spanish locale.
    /// </summary>
    Es,

    /// <summary>
    /// German locale.
    /// </summary>
    De,

    /// <summary>
    /// French locale.
    /// </summary>
    Fr,

    /// <summary>
    /// Italian locale.
    /// </summary>
    It,

    /// <summary>
    /// Dutch locale.
    /// </summary>
    Nl,

    /// <summary>
    /// Portuguese locale.
    /// </summary>
    Pt,

    /// <summary>
    /// Russian locale.
    /// </summary>
    Ru,

    /// <summary>
    /// Ukrainian locale.
    /// </summary>
    Uk,

    /// <summary>
    /// Chinese locale.
    /// </summary>
    Zh,

    /// <summary>
    /// Japanese locale.
    /// </summary>
    Ja
}