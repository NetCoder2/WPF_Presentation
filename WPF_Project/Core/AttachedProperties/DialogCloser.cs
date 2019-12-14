using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Core
{
    /// <summary>
    /// The attached property to return a particular DialogResult for a Dialog Window
    /// </summary>
    public class DialogCloser  : DependencyObject
    {
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.RegisterAttached(
                "Value", typeof(bool), typeof(DialogCloser),
                new UIPropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));


        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

            var window = d as Window;
            if (window != null)
                window.DialogResult = e.NewValue as bool?;
        }

        public static void SetValue(DependencyObject target, Boolean value)
        {
            target.SetValue(ValueProperty, value);
        }

        public static bool GetValue(DependencyObject target)
        {
            return (bool)target.GetValue(ValueProperty);
        }


    }
}
