using Domain.Helpers;

namespace Domain.Receip;

public class Client
{
    private readonly string[] _regexCpf = new[]
    {
        @"[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}"
    };

    public string Document { get; set; }

    public Client(string[] lines)
    {
        SetDocument(lines);
    }

    public Client()
    {
    }

    private void SetDocument(string[] lines)
    {
        Document = RegexHelper.ProcessRegex(lines, _regexCpf, ValidatorHelper.IsCpf);
    }
}