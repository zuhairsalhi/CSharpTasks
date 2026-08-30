using System;
using System.Globalization;

namespace Task13.App
{
    public static class StringExtensions
    {
        public static string ToTitleCase(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return text;
            }

            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

            return textInfo.ToTitleCase(text.ToLower());
        }

        public static string Truncate(this string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            if (maxLength < 0)
            {
                throw new ArgumentException(
                    "Maximum length cannot be negative."
                );
            }

            if (text.Length <= maxLength)
            {
                return text;
            }

            return text.Substring(0, maxLength) + "...";
        }

        public static bool IsValidEmail(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            return text.Contains("@") &&
                   text.Contains(".");
        }

        public static string ToSlug(this string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return string.Empty;
            }

            return text
                .ToLower()
                .Trim()
                .Replace(" ", "-");
        }
    }
}