using System.Globalization;

namespace PTA.Types.Extensions
{
    /// <summary>
    /// String extension methods.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Abbreviation for the string.Format method.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string Fill(this string text, params object[] parameters)
        {
            return string.Format(text, parameters);
        }

        /// <summary>
        /// Parses string as double, uses dot as decimal point separator.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static double AsDouble(this string text)
        {
            return double.Parse(text, CultureInfo.InvariantCulture);
        }
    }
}
