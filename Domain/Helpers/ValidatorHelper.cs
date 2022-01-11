namespace Domain.Helpers;

public class ValidatorHelper
{
    public static bool IsCpf(string cpf)
    {
        var m1 = new[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var m2 = new[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
            return false;

        var t = cpf[..9];
        var s = 0;

        for (var i = 0; i < 9; i++)
            s += int.Parse(t[i].ToString()) * m1[i];

        var r = s % 11;
        if (r < 2)
            r = 0;
        else
            r = 11 - r;

        var d = r.ToString();
        t += d;
        s = 0;

        for (var i = 0; i < 10; i++)
            s += int.Parse(t[i].ToString()) * m2[i];

        r = s % 11;
        if (r < 2)
            r = 0;
        else
            r = 11 - r;

        d += r.ToString();

        return cpf.EndsWith(d);
    }


    public static bool IsCnpj(string cnpj)
    {
        var m1 = new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        var m2 = new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        cnpj = cnpj.Trim();
        cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

        if (cnpj.Length != 14)
            return false;

        var t = cnpj[..12];
        var s = 0;

        for (var i = 0; i < 12; i++)
            s += int.Parse(t[i].ToString()) * m1[i];

        var r = (s % 11);

        if (r < 2)
            r = 0;
        else
            r = 11 - r;

        var d = r.ToString();
        t += d;
        s = 0;

        for (var i = 0; i < 13; i++)
            s += int.Parse(t[i].ToString()) * m2[i];

        r = (s % 11);
        if (r < 2)
            r = 0;
        else
            r = 11 - r;
        d += r.ToString();

        return cnpj.EndsWith(d);
    }
}