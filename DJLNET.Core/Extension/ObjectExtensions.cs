using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJLNET.Core.Extension
{
    public static class ObjectExtensions
    {
        public static bool IsBetween<T>(this T t, T lowerBound, T upperBound, bool includeLowerBound = false, bool includeUpperBound = false)
        where T : IComparable<T>
        {
            if (t == null) throw new ArgumentNullException(nameof(t));

            var lowerCompareResult = t.CompareTo(lowerBound);
            var upperCompareResult = t.CompareTo(upperBound);

            return (includeLowerBound && lowerCompareResult == 0) ||
                (includeUpperBound && upperCompareResult == 0) ||
                (lowerCompareResult > 0 && upperCompareResult < 0);
        }

        public static bool IsBetween<T>(this T t, T lowerBound, T upperBound, IComparer<T> comparer, bool includeLowerBound = false, bool includeUpperBound = false)
        {
            if (comparer == null) throw new ArgumentNullException(nameof(comparer));

            var lowerCompareResult = comparer.Compare(t, lowerBound);
            var upperCompareResult = comparer.Compare(t, upperBound);

            return (includeLowerBound && lowerCompareResult == 0) ||
                (includeUpperBound && upperCompareResult == 0) ||
                (lowerCompareResult > 0 && upperCompareResult < 0);
        }

        public static bool In<T>(this T t, params T[] c)
        {
            return c.Any(i => i.Equals(t));
        }

        public static bool In<T>(this T t, IEnumerable<T> c)
        {
            return c.Any(i => i.Equals(t));
        }

        public static T If<T>(this T t, Predicate<T> predicate, Action<T> action) where T : class
        {
            if (t == null) throw new ArgumentNullException(nameof(t));
            if (predicate(t)) action(t);
            return t;
        }

        public static T If<T>(this T t, Predicate<T> predicate, Func<T, T> func) where T : struct
        {
            return predicate(t) ? func(t) : t;
        }

        public static T If<T>(this T t, Predicate<T> predicate, params Action<T>[] actions) where T : class
        {
            if (predicate(t)) actions.ToList().ForEach(x => x(t));
            return t;
        }

        public static void While<T>(this T t, Predicate<T> predicate, Action<T> action) where T : class
        {
            while (predicate(t)) action(t);
        }

        public static void While<T>(this T t, Predicate<T> predicate, params Action<T>[] actions) where T : class
        {
            while (predicate(t))
            {
                foreach (var action in actions)
                    action(t);
            }
        }
    }
}
