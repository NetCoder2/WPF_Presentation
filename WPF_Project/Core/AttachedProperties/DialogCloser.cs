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
    public class DialogCloser : BaseAttachedProperty<DialogCloser, bool?>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var window = sender as Window;
            if (window != null)
                window.DialogResult = e.NewValue as bool?;
        }
    }
}
