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
        /// Сonverts List to DataTable
        /// </summary>
        /// <typeparam name="T">input IList</typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }




        /// <summary> 
        /// Converts to Data Type and returns value or returns defaultValue if DBNull
        /// </summary> 
        public static T CastDBNull<T>(this object value, T defaultValue)
        {
            if (value == DBNull.Value || value == null) return defaultValue;
            return (T)Convert.ChangeType(value, typeof(T));
        }

        /// <summary> 
        /// Converts Nullable Value to DBNull or Returns value
        /// </summary> 
        public static object ToDBValue<T>(this T? value) where T : struct
        {
            return value.HasValue ? (object)value.Value : DBNull.Value;
        }

        /// <summary> 
        /// Converts string to DBNull or Returns string
        /// </summary> 
        public static object ToDBValue(this string Fld)
        {
            return String.IsNullOrEmpty(Fld) ? (object)DBNull.Value : Fld;
        }

        /// <summary> 
        /// Converts string to nullable int
        /// </summary> 
        public static int? ToNullableInt(this string s)
        {
            int i;
            if (int.TryParse(s, out i)) return i;
            return null;
        }

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
