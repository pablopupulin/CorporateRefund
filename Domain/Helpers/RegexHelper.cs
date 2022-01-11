using System.Globalization;
using System.Text.RegularExpressions;

namespace Domain.Helpers;

public static class RegexHelper
{
    public static string ProcessRegex(string[] lines, string[] listRegex, Func<string, bool> condition)
    {
        foreach (var line in lines)
        {
            foreach (var regex in listRegex)
            {
                var match = Regex.Match(line, regex);

                if (!match.Success)
                    continue;

                var value = match.Groups[0].Value;
                if (!string.IsNullOrEmpty(value) && condition(value))
                {
                    return value;
                }
            }
        }

        return string.Empty;
    }

    public static string ProcessRegex(string[] lines, string[] listRegex)
    {
        return ProcessRegex(lines, listRegex, _ => true);
    }

    public static decimal TryGetDecimal(string text)
    {
        var value = Regex.Match(text, @"(\d+(\.\d+)?)|(\.\d+)").Value;

        decimal.TryParse(value, out var result);
        return result;
    }

   
}