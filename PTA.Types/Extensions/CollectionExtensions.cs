using System;
using System.Collections.Generic;
using System.Linq;

namespace PTA.Types.Extensions
{
    /// <summary>
    /// Collection extension methods.
    /// </summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Returns the sequence of subsequent pairs from given collection.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static IEnumerable<TResult> SelectTwo<TSource, TResult>(
            this IEnumerable<TSource> source, Func<TSource, TSource, TResult> selector)
        {
            return Enumerable.Zip(source, source.Skip(1), selector);
        }
    }
}
