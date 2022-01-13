using System.Text;
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


    public Products(IEnumerable<string> lines)
    {
        SetItems(lines);
    }

    public Products()
    {
    }

    private void SetItems(IEnumerable<string> lines)
    {
        foreach (var line in lines)
        {
            foreach (var regex in _regexProduct)
            {
                var match = Regex.Match(line, regex);

                if (!match.Success)
                    continue;

                var value = match.Groups[0].Value;
                if (string.IsNullOrEmpty(value))
                    continue;

                var split = value.Split(" ");

                if (split.Length < 4)
                    continue;

                var productName = new StringBuilder(split[2]);

                foreach (var s in split[3..])
                {
                    if (int.TryParse(s, out _))
                        break;

                    productName.Append(" ");
                    productName.Append(s);
                }

                Add(new Product
                {
                    Name = productName.ToString()
                });

                break;
            }
        }
    }
}