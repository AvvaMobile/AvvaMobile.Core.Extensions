using System.Globalization;
using System.Text.RegularExpressions;

namespace AvvaMobile.Core.Extensions;

public static class StringExtension
{
    public static bool IsNullOrEmtpy(this string str)
    {
        return string.IsNullOrEmpty(str);
    }

    public static bool IsNotNull(this string str)
    {
        return !string.IsNullOrEmpty(str);
    }

    public static string ToEmptyStringIndicator(this string str)
    {
        return string.IsNullOrEmpty(str) ? "--" : str;
    }

    public static string ReplaceENTER(this string str)
    {
        return string.IsNullOrEmpty(str) ? string.Empty : str.Replace(Environment.NewLine, "<br/>");
    }

    public static string ToStringData(this object str)
    {
        return str?.ToString() ?? string.Empty;
    }

    public static string ToPhoneNumber(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }
        else if (str.Length == 10)
        {
            return Regex.Replace(str, @"^\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*$", "0 ($1$2$3) $4$5$6 $7$8 $9$10");
        }
        else if (str.Length == 11)
        {
            return Regex.Replace(str, @"^\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*$", "$1 ($2$3$4) $5$6$7 $8$9 $10$11");
        }
        else if (str.Length == 12)
        {
            return Regex.Replace(str, @"^\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*(\d)\D*$", "+$1$2 ($3$4$5) $6$7$8 $9$10 $11$12");
        }
        else
        {
            return str;
        }
    }

    public static string ClearPhoneNumber(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }

        str = Regex.Replace(str, "[^0-9]+", string.Empty);

        switch (str.Length)
        {
            // 10 = '532 111 22 33'
            case 10:
                str = "90" + str;
                break;
            // 11 = '0 532 111 22 33'
            case 11:
                str = "9" + str;
                break;
        }

        return str;
    }

    public static string ClearHTMLTags(this string str)
    {
        return string.IsNullOrEmpty(str) ? str : Regex.Replace(str, "<.*?>", " ");
    }

    private const string Dash = "-";

    private const string Dot = ".";

    public static string ToKeyword(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return str;
        }
        str = str.Trim();
        str = str.ToLower(new CultureInfo("en-US"));
        str = str.Replace("ğ", "g");
        str = str.Replace("ü", "u");
        str = str.Replace("ş", "s");
        str = str.Replace("ı", "i");
        str = str.Replace("ö", "o");
        str = str.Replace("ç", "c");
        str = str.Replace("Ğ", "g");
        str = str.Replace("Ü", "u");
        str = str.Replace("Ş", "s");
        str = str.Replace("İ", "i");
        str = str.Replace("Ö", "o");
        str = str.Replace("Ç", "c");
        str = str.Replace("+", Dash);
        str = str.Replace("'", string.Empty);
        str = str.Replace("(", string.Empty);
        str = str.Replace(")", string.Empty);
        str = str.Replace(" ", Dash);
        str = str.Replace("/", Dash);
        str = str.Replace("&", Dash);
        str = str.Replace("!", string.Empty);
        str = str.Replace("?", string.Empty);
        str = str.Replace(".", string.Empty);
        str = str.Replace(":", string.Empty);
        str = str.Replace(@"\", Dash);
        str = str.Replace("---", Dash);
        str = str.Replace("--", Dash);
        str = str.Replace("\"", Dash);
        str = str.Replace("%", string.Empty);
        return str;
    }

    /// <summary>
    /// Waits a date sting as formatted "dd.MM.yyyy" and return datetime object.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static DateTime DateTimeParseExact(this string str)
    {
        CultureInfo provider = CultureInfo.InvariantCulture;
        return DateTime.ParseExact(str, "dd.MM.yyyy", provider);
    }

    /// <summary>
    /// Return initial characters of first two words of a string.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string GetInitials(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return string.Empty;
        }

        var words = str.Split(' ');
        return words.Length switch
        {
            1 => words[0].Substring(0, 1),
            >= 2 => words[0].Substring(0, 1) + words[1].Substring(0, 1),
            _ => string.Empty
        };
    }

    public static bool ToBool(this string str)
    {
        return bool.Parse(str);
    }

    public static int ToInt(this string str)
    {
        return int.Parse(str);
    }

    public static decimal ToDecimal(this string str)
    {
        return decimal.Parse(str);
    }

    public static long ToLong(this string str)
    {
        return long.Parse(str);
    }
        
    public static string PrepareCDNUrl(this string imageUrl, string baseUrl, string folder)
    {
        return string.IsNullOrEmpty(imageUrl) ? null : $"{baseUrl}{folder}{imageUrl}";
    }
        
    public static string PrepareS3Url(this string imageUrl, string baseUrl, string bucketName)
    {
        return string.IsNullOrEmpty(imageUrl) ? null : $"{baseUrl}{bucketName}{imageUrl}";
    }
        
    public static string CreditCardMaskify(this string str)
    {
        return "**** **** **** " + str;
    }

    public static string CreditCardLast4Digits(this string str)
    {
        return str.Substring(str.Length - 4);
    }

    public static bool ValidateDateFormat(string value)
    {
        return Regex.Match(value, @"^\s*(3[01]|[12][0-9]|0?[1-9])\.(1[012]|0?[1-9])\.((?:19|20)\d{2})\s*$").Success;
    }
    public static string FormatToIBAN(this string str)
    {
        if (string.IsNullOrEmpty(str))
        {
            return null;
        }
        return Regex.Replace(str, ".{4}", "$0 ").Trim();
    }
}