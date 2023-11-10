using System.Globalization;

namespace AvvaMobile.Core.Extensions;

public static class Decimal
{
    /// <summary>
    /// Returns a string as Turkish Lira formatted.
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string ToTL(this decimal? val)
    {
        if (val == null)
        {
            return "0 TL";
        }

        return val.Value.ToString("N2") + " TL";
    }

    /// <summary>
    /// Returns a string as Turkish Lira formatted.
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string ToTL(this decimal val)
    {
        return val.ToString("N2") + " TL";
    }

    /// <summary>
    /// Returns 0 if object is null, otherwise returns value of the object.
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static decimal DefaultIfEmpty(this decimal? val)
    {
        return val ?? 0;
    }

    /// <summary>
    /// Formats the value as N0.
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string ToFormattedPrice(this decimal val)
    {
        return val.ToString("N0");
    }

    /// <summary>
    /// Formats the value as N0.
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string ToFormattedPrice(this decimal? val)
    {
        return val != null ? val.Value.ToString("N0") : "-";
    }

    /// <summary>
    /// Formats the value as N2.
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string ToFormattedDecimal(this decimal val)
    {
        return val.ToString("N2");
    }

    /// <summary>
    /// Formats the value as N2.
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string ToFormattedDecimal(this decimal? val)
    {
        return !val.HasValue ? string.Empty : val.Value.ToString("N2");
    }

    /// <summary>
    /// Formats the value as N2.
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string ToFormattedPercentage(this decimal? val)
    {
        return !val.HasValue ? string.Empty : ToFormattedPercentage(val.Value);
    }

    /// <summary>
    /// Formats the value as N2.
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string ToFormattedPercentage(this decimal val)
    {
        return $"% {val:N2}";
    }

    /// <summary>
    /// Returns an hyphen as empty string indicator if object is null, otherwise returns value of the object.
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static string ToEmptyStringIndicator(this decimal? val)
    {
        return val.HasValue ? val.Value.ToString(CultureInfo.InvariantCulture) : "--";
    }
        
    public static decimal DivideSafely(this decimal Numerator, decimal Denominator)
    {
        return (Denominator == 0) ? 0 : Numerator / Denominator;
    }
    
    public static string ToFacebookPrice(this decimal value)
    {
        return value.ToString("0.00").Replace(".", "").Replace(",", "");
    }

    public static decimal FromFacebookPriceToDecimal(this decimal value)
    {
        return Math.Floor(value * 100) / 100;
    }
}