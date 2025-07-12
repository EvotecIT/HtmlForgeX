using System;
using System.Linq;
namespace HtmlForgeX;

internal static class IdGenerator
{
    internal const int DefaultRandomIdLength = 8;
    private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private static readonly Random RandomGenerator = new();

    internal static string GenerateRandomId(string preText, int length = DefaultRandomIdLength)
    {
        if (string.IsNullOrWhiteSpace(preText))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(preText));
        }

        lock (RandomGenerator)
        {
            var randomId = new string(Enumerable.Repeat(Characters, length)
                .Select(s => s[RandomGenerator.Next(s.Length)]).ToArray());
            return $"{preText}-{randomId}";
        }
    }
}
