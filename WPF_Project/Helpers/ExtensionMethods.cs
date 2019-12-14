using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Helpers
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// Finds the required string resource
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static string GeStringResource(this string resourceName)
        {
            string res = String.Empty;
            if (Application.Current != null)
            {
                res = (string)Application.Current.Resources[resourceName];
                res = res != null ? (string)res : String.Empty;
            }
            return res;
        }

        /// <summary>
        /// Finds the required resource
        /// </summary>
        /// <param name="resourceName"></param>
        /// <returns></returns>
        public static object GetResource(this string resourceName)
        {
            if (Application.Current != null)
            {
                return Application.Current.TryFindResource(resourceName);
                //return Application.Current.Resources[resourceName];
            }
            return null;
        }

        /// <summary>
        /// ForEach method for IEnumerable
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var cur in enumerable)
            {
                action(cur);
            }
        }
    }
}
