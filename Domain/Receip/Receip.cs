using Domain.Helpers;

namespace Domain.Receip;

public class Receip
{
    private readonly string[] _regexTotal = 
    {
        @"([Tt][Oo][Tt][Aa][Ll]).*([R$]).*([-+]?\d*\.?\d+|[-+]?\d+)",
        @"([Vv][Aa][Ll][Oo][Rr]).*([R$]).*([-+]?\d*\.?\d+|[-+]?\d+)",
        @"([Pp][Aa][Gg][Aa][Rr]).*([R$]).*([-+]?\d*\.?\d+|[-+]?\d+)"
    };

    private readonly string[] _regexDate =
    {
        @"(0?[1-9]|[12][0-9]|3[01])[\/\-](0?[1-9]|1[012])[\/\-]\d{4}"
    };


    public string Id { get; set; }

    public Guid ClientId { get; set; }
    public Company Company { get; set; }
    public Client Client { get; set; }
    public Products Products { get; set; }
    public string Data { get; set; }
    public decimal Total { get; set; }
    public string TextReceip { get; set; }

    public Receip(Guid clientId, string textReceip)
    {
        ClientId = clientId;
        TextReceip = textReceip;

        var lines = PreProcessText(textReceip);

        Company = new Company(lines);
        Client = new Client(lines);
        Products = new Products(lines);

        SetTotal(lines);
        SetData(lines);
    }

    public Receip()
    {
    }

    private void SetTotal(string[] lines)
    {
        var result = RegexHelper.ProcessRegex(lines, _regexTotal);
        Total = RegexHelper.TryGetDecimal(result);
    }

    private void SetData(string[] lines)
    {
        Data = RegexHelper.ProcessRegex(lines, _regexDate);
    }

    private static string[] PreProcessText(string text)
    {
        text = text.ToUpper();
        text = text.Replace("  ", " ");
        text = text.Replace("'", "");
        text = text.Replace(",,", ",");
        text = text.Replace(",.", ",");
        text = text.Replace(".,", ",");
        text = text.Replace("..", ".");
        text = text.Replace(" ,", ",");
        text = text.Replace(" .", "");
        text = text.Replace(" !", "");
        text = text.Replace(" :", ":");
        text = text.Replace("_", "");
        text = text.Replace("-—", "—");
        text = text.Replace("—-", "—");
        text = text.Replace("\"", "");

        var replaceAgain = false;
        var oldText = text;

        do
        {
            text = text.Replace("\n:", "\n");
            text = text.Replace("\n-", "\n");
            text = text.Replace("\n—", "\n");
            text = text.Replace("\n ", "\n");
            replaceAgain = oldText != text;
            oldText = text ;

        } while (replaceAgain);

        text = text.Replace("VUL ITEM", "VL ITEM");
        text = text.Replace("ITEMM", "ITEM");
        text = text.Replace("ITENM", "ITEM");
        text = text.Replace("ACRESCIHO", "ACRESCIMO");
        text = text.Replace("CARTADON", "CARTAOON");

        oldText = text;

        do
        {
            text = text.Replace("0O0", "00");
            text = text.Replace("0O1", "01");
            text = text.Replace("0O2", "02");
            text = text.Replace("0O3", "03");
            text = text.Replace("0O4", "04");
            text = text.Replace("0O5", "05");
            text = text.Replace("0O6", "06");
            text = text.Replace("0O7", "07");
            text = text.Replace("0O8", "08");
            text = text.Replace("0O9", "09");

            text = text.Replace("OO0", "00");

            text = text.Replace("O00", "00");
            text = text.Replace("O01", "01");
            text = text.Replace("O02", "02");
            text = text.Replace("O03", "03");
            text = text.Replace("O04", "04");
            text = text.Replace("O05", "05");
            text = text.Replace("O06", "06");
            text = text.Replace("O07", "07");
            text = text.Replace("O08", "08");
            text = text.Replace("O09", "09");

            text = text.Replace("0C0", "00");
            text = text.Replace("0C1", "01");
            text = text.Replace("0C2", "02");
            text = text.Replace("0C3", "03");
            text = text.Replace("0C4", "04");
            text = text.Replace("0C5", "05");
            text = text.Replace("0C6", "06");
            text = text.Replace("0C7", "07");
            text = text.Replace("0C8", "08");
            text = text.Replace("0C9", "09");

            text = text.Replace("CC0", "00");

            text = text.Replace("C00", "00");
            text = text.Replace("C01", "01");
            text = text.Replace("C02", "02");
            text = text.Replace("C03", "03");
            text = text.Replace("C04", "04");
            text = text.Replace("C05", "05");
            text = text.Replace("C06", "06");
            text = text.Replace("C07", "07");
            text = text.Replace("C08", "08");
            text = text.Replace("C09", "09");

            replaceAgain = oldText != text;
            oldText = text;

        } while (replaceAgain);

        return text.Split("\n");
    }

}