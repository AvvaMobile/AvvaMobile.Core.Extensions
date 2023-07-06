using System.Globalization;
using System.Text.RegularExpressions;

namespace AvvaMobile.Core.Extensions
{
    public static class ListExtension
    {
        public static bool AllSame<T>(List<T> values)
        {
            return values.Distinct().Count() == 1;
        }

        public static bool AllDifferent<T>(List<T> values)
        {
            return values.Distinct().Count() == values.Count;
        }
    }
}