using System.ComponentModel;

namespace HtmlForgeX.Extensions;

/// <summary>
/// Extension methods for enums.
/// </summary>
internal static class ExtensionsDescription {
    /// <summary>
    /// Retrieves the <see cref="DescriptionAttribute"/> value from an enum value.
    /// </summary>
    /// <typeparam name="T">Enum type.</typeparam>
    /// <param name="enumValue">Enum value to read.</param>
    /// <returns>Description text or the enum name.</returns>
    internal static string GetDescription<T>(this T enumValue) where T : IConvertible {
        if (!typeof(T).IsEnum) {
            throw new ArgumentException("Argument must be of type Enum");
        }

        var description = enumValue.ToString();
        var fieldInfo = enumValue.GetType().GetField(description!);
        var attributes = (DescriptionAttribute[])fieldInfo!.GetCustomAttributes(typeof(DescriptionAttribute), false);

        if (attributes != null && attributes.Length > 0) {
            description = attributes[0].Description;
        }

        return description!;
    }
}