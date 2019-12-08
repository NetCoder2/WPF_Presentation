using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Core
{
    /// <summary>
    /// A  converter that hides Dependency Object if it has true value
    /// </summary>
    public class BooleanVisibilityConverter : IValueConverter
    { 

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // if aplication is in the design mode or vale is true
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()) || !(bool)value)
            {
                return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
