using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace BindableUI.Droid.Utils
{
    internal static class EnumerableExtensions
    {
        private static void DynamicUsing(object resource, Action action)
        {
            try
            {
                action();
            }
            finally
            {
                IDisposable d = resource as IDisposable;
                if (d != null)
                {
                    d.Dispose();
                }
            }
        }

        public static int Count(this IEnumerable source)
        {
            var col = source as ICollection;
            if (col != null)
            {
                return col.Count;
            }

            int count = 0;
            IEnumerator e = source.GetEnumerator();
            DynamicUsing(e, () =>
            {
                checked
                {
                    while (e.MoveNext())
                    {
                        count++;
                    }
                }
            });

            return count;
        }

        /// <summary>
        /// Returns element at index, or null.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static object ElementAtOrDefault(this IEnumerable source, int index)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (index >= 0)
            {
                IList list = source as IList;
                if (list != null)
                {
                    return (index < list.Count) ? list[index] : null;
                }
                //The worst case - we need to iterate an enumerable
                else
                {
                    IEnumerator e = source.GetEnumerator();
                    object returnedObject = null;
                    DynamicUsing(e, () =>
                    {
                        while (true)
                        {
                            if (!e.MoveNext())
                            {
                                break;
                            }

                            if (index == 0)
                            {
                                returnedObject = e.Current;
                                break;
                            }
                            index--;
                        }
                    }
                    );
                    return returnedObject;
                }
            }
            return null;
        }

        /// <summary>
        /// Index of the first occurence of <paramref name="value"/> in <paramref name="source"/> 
        /// or -1 if there were no occurencies of <paramref name="value"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <returns>-1 if the value was not found</returns>
        public static int IndexOf(this IEnumerable source, object value)
        {
            IList list = source as IList;
            if (list != null)
            {
                return list.IndexOf(value);
            }

            int index = 0;
            foreach (object element in source)
            {
                if (value == element)
                {
                    return index;
                }
                index++;
            }

            return -1;
        }

        /// <summary>
        /// Index of the first occurence of <paramref name="value"/> in <paramref name="source"/> 
        /// or -1 if there were no occurencies of <paramref name="value"/>.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="value"></param>
        /// <returns>-1 if the value was not found</returns>
        public static int IndexOf<T>(this IEnumerable<T> source, T value)
        {
            IList<T> list = source as IList<T>;
            if (list != null)
            {
                return list.IndexOf(value);
            }

            int index = 0;
            foreach (T element in source)
            {
                if (object.Equals(value, element))
                {
                    return index;
                }
                index++;
            }

            return -1;
        }
    }
}
