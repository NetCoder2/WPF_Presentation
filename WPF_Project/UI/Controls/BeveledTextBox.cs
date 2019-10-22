using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace UI.Controls
{
    public class BeveledTextBox : TextBox
    {

        public static readonly DependencyProperty RoundRadiusXProperty;
        public static readonly DependencyProperty RoundRadiusYProperty;
        public static readonly DependencyProperty BackColorProperty;

        public double RoundRadiusX
        {
            get { return (double)GetValue(RoundRadiusXProperty); }
            set { SetValue(RoundRadiusXProperty, value); }
        }


        public double RoundRadiusY
        {
            get { return (double)GetValue(RoundRadiusYProperty); }
            set { SetValue(RoundRadiusYProperty, value); }
        }

        public SolidColorBrush BackColor
        {
            get { return (SolidColorBrush)GetValue(BackColorProperty); }
            set { SetValue(BackColorProperty, value); }
        }


        static BeveledTextBox()
        {


            RoundRadiusXProperty = DependencyProperty.Register("RoundRadiusX", typeof(double),
                    typeof(BeveledTextBox), new PropertyMetadata(5.0));

            RoundRadiusYProperty = DependencyProperty.Register("RoundRadiusY", typeof(double),
                typeof(BeveledTextBox), new PropertyMetadata(5.0));

            var defualtBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FFFDFDFD"));

            BackColorProperty = DependencyProperty.Register("BackColor", typeof(SolidColorBrush),
                typeof(BeveledTextBox), new PropertyMetadata(defualtBrush));

        }

    }
}
