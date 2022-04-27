using System;
using System.Collections.Generic;
using System.Linq;

namespace PTA.TestBase
{
    public static class Comparator
    {
        public static bool CompareProperties<T>(T self, T to, params string[] ignore) where T : class
        {
            if (self != null && to != null)
            {
                Type type = typeof(T);
                List<string> ignoreList = new(ignore);
                foreach (System.Reflection.PropertyInfo pi in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                {
                    if (!ignoreList.Contains(pi.Name))
                    {
                        object selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                        object toValue = type.GetProperty(pi.Name).GetValue(to, null);

                        if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return self == to;
        }

        public static void ComparePropertiesAndThrowIfMismatch<T>(T self, T to, params string[] ignore) where T : class
        {
            if (self != null && to != null)
            {
                Type type = typeof(T);
                List<string> ignoreList = new(ignore);
                foreach (System.Reflection.PropertyInfo pi in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
                {
                    if (!ignoreList.Contains(pi.Name))
                    {
                        object selfValue = type.GetProperty(pi.Name).GetValue(self, null);
                        object toValue = type.GetProperty(pi.Name).GetValue(to, null);

                        if (selfValue != toValue && (selfValue == null || !selfValue.Equals(toValue)))
                        {
                            if (selfValue is int[] && toValue is int[])
                            {
                                var selfValueArray = selfValue as int[];
                                var toValueArray = toValue as int[];

                                if (Enumerable.SequenceEqual(selfValueArray, toValueArray))
                                {
                                    continue;
                                }
                            }

                            if (selfValue is DateTime selfDateTime && toValue is DateTime toDateTime)
                            {
                                var diff = selfDateTime.Subtract(toDateTime);
                                if (diff.TotalSeconds < 1 && diff.TotalSeconds > -1)
                                    continue;
                            }

                            throw new InvalidOperationException($"Objects are not equal, property: {pi.Name}, expected: {selfValue}, current: {toValue}");
                        }
                    }
                }
            }
            else
            {
                throw new InvalidOperationException($"Objects are not equal, exptected: {self}, current: {to}");
            }
        }
    }
}
