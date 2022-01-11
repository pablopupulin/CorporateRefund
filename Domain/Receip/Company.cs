using System.Text.RegularExpressions;
using Domain.Helpers;

namespace Domain.Receip;

public class Company
{
    private readonly string[] _regexCnpj = {
        @"[0-9]{2}\.?[0-9]{3}\.?[0-9]{3}\/?[0-9]{4}\-?[0-9]{2}"
    };

    private readonly string[] _regexName =
    {
        @"\A.*"
    };

    public string Document { get; set; }
    public string Name { get; set; }

    public Company(string[] lines)
    {
        SetDocument(lines);
        SetName(lines);
    }

    public Company()
    {
    }

    private void SetDocument(string[] lines)
    {
        Document = RegexHelper.ProcessRegex(lines, _regexCnpj, ValidatorHelper.IsCnpj);
    }

    private void SetName(string[] lines)
    {
        foreach (var regex in _regexName)
        {
            var match = Regex.Match(lines[0], regex);

            if (!match.Success)
                continue;

            var value = match.Groups[0].Value;
            if (!string.IsNullOrEmpty(value))
            {
                Name = value;
            }
        }
    }
}