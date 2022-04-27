using System;
using System.Globalization;

namespace PTA.Types.Extensions
{
    /// <summary>
    /// Extension methods for numeric types.
    /// </summary>
    public static class NumericExtensions
    {
        /// <summary>
        /// Returns double value as int.
        /// If value is halfway between two whole numbers, the even number is returned;
        /// that is, 4.5 is converted to 4, and 5.5 is converted to 6.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int AsInt(this double value) => Convert.ToInt32(value);

        /// <summary>
        /// Returns double value as string with dot as decimal point.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string AsString(this double value) => Convert.ToString(value, CultureInfo.InvariantCulture);
    }
}
