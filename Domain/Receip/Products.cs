using System.Text.RegularExpressions;

namespace Domain.Receip;

public class Products : List<Product>
{
    private readonly string[] _regexProduct = new[] {

        @"([-+]?\d*\.?\d+|[-+]?\d+).*(( )|(\.))([Uu][Nn]).*([-+]?\d*\.?\d+|[-+]?\d+)",
        @"([-+]?\d*\.?\d+|[-+]?\d+).*(( )|(\.))([Uu][Nn])",
        @"([-+]?\d*\.?\d+|[-+]?\d+).*([Kk][Gg]).*([-+]?\d*\.?\d+|[-+]?\d+)",
        @"([-+]?\d*\.?\d+|[-+]?\d+).*([Kk][Gg])"
    };


    public Products(string[] lines)
    {
        SetItems(lines);
    }

    public Products()
    {
    }

    private void SetItems(string[] lines)
    {
        foreach (var line in lines)
        {
            foreach (var regex in _regexProduct)
            {
                var match = Regex.Match(line, regex);

                if (!match.Success)
                    continue;

                var value = match.Groups[0].Value;
                if (!string.IsNullOrEmpty(value))
                {
                    Add(new Product
                    {
                        Name = value
                    } );
                    break;
                }
            }
        }
    }
}