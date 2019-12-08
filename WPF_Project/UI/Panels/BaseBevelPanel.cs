using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Helpers;

namespace UI
{
    /// <summary>
    /// The base beveled panel class
    /// </summary>
    public class BaseBevelPanel : UserControl
    {
        public static readonly DependencyProperty PanelRadiusXProperty;
        public static readonly DependencyProperty PanelRadiusYProperty;
        public static readonly DependencyProperty ShadowHeightProperty;
        public static readonly DependencyProperty ShadowBlurProperty;
        public new static readonly DependencyProperty BorderThicknessProperty;
        public static readonly DependencyProperty RotateAngleProperty;
        public static DependencyProperty BackColorDarkProperty;
        private static readonly DependencyPropertyKey ReadOnlyBackColorDarkKey;

        public static DependencyProperty BackColorLightProperty;
        private static readonly DependencyPropertyKey ReadOnlyBackColorLightKey;

        public static DependencyProperty BackColorProperty;
        public static DependencyProperty BackColorEndProperty;

        /// <summary>
        /// The X radius of the panel
        /// </summary>
        public double PanelRadiusX
        {
            get { return (double)base.GetValue(PanelRadiusXProperty); }
            set { base.SetValue(PanelRadiusXProperty, value); }
        }

        /// <summary>
        /// The X radius of the panel
        /// </summary>
        public double PanelRadiusY
        {
            get { return (double)base.GetValue(PanelRadiusYProperty); }
            set { base.SetValue(PanelRadiusYProperty, value); }
        }

        /// <summary>
        /// The background color of the panel
        /// </summary>
        public Color BackColor
        {
            get { return (Color)base.GetValue(BackColorProperty); }
            set { base.SetValue(BackColorProperty, value); }
        }

        /// <summary>
        /// The dark background color of the panel
        /// </summary>
        public Color BackColorDark
        {
            get { return (Color)GetValue(BackColorDarkProperty); }
            protected set { SetValue(ReadOnlyBackColorDarkKey, value); }
        }

        /// <summary>
        /// The light background color of the panel
        /// </summary>
        public Color BackColorLight
        {
            get { return (Color)GetValue(BackColorLightProperty); }
            protected set { SetValue(ReadOnlyBackColorLightKey, value); }
        }

        public double ShadowHeight
        {
            get { return (double)base.GetValue(ShadowHeightProperty); }
            set { base.SetValue(ShadowHeightProperty, value); }
        }

        public double ShadowBlur
        {
            get { return (double)base.GetValue(ShadowBlurProperty); }
            set { base.SetValue(ShadowBlurProperty, value); }
        }

        public new double BorderThickness
        {
            get { return (double)base.GetValue(BorderThicknessProperty); }
            set { base.SetValue(BorderThicknessProperty, value); }
        }

        public double RotateAngle
        {
            get { return (double)base.GetValue(RotateAngleProperty); }
            set { base.SetValue(RotateAngleProperty, value); }
        }

        /// <summary>
        /// The end color of the brush background
        /// </summary>
        public Color BackColorEnd
        {
            get { return (Color)base.GetValue(BackColorEndProperty); }
            set { base.SetValue(BackColorEndProperty, value); }
        }


        static BaseBevelPanel()
        {
            PanelRadiusXProperty = DependencyProperty.Register("PanelRadiusX",
                typeof(double),
                typeof(BaseBevelPanel),
                new PropertyMetadata(8.0));

            PanelRadiusYProperty = DependencyProperty.Register("PanelRadiusY",
                typeof(double),
                typeof(BaseBevelPanel),
                new PropertyMetadata(8.0));

            BackColorProperty = DependencyProperty.Register("BackColor",
                typeof(Color),
                typeof(BaseBevelPanel),
                new PropertyMetadata((Color)Application.Current.Resources["PanelColor"], OnBackColorChanged));

            BackColorEndProperty = DependencyProperty.Register("BackColorEnd",
                typeof(Color),
                typeof(BaseBevelPanel),
                new PropertyMetadata(Colors.White));

            ShadowHeightProperty = DependencyProperty.Register("ShadowHeight",
                typeof(double),
                typeof(BaseBevelPanel),
                new PropertyMetadata(8.5));

            ShadowBlurProperty = DependencyProperty.Register("ShadowBlur",
                typeof(double),
                typeof(BaseBevelPanel),
                new PropertyMetadata(8.0));

            BorderThicknessProperty = DependencyProperty.Register("BorderThickness",
                typeof(double),
                typeof(BaseBevelPanel),
                new PropertyMetadata(2.0));

            RotateAngleProperty = DependencyProperty.Register("RotateAngle",
                typeof(double),
                typeof(BaseBevelPanel),
                new PropertyMetadata(0.0));

            ReadOnlyBackColorDarkKey = DependencyProperty.RegisterReadOnly("BackColorDark",
                typeof(Color), typeof(BaseBevelPanel), new FrameworkPropertyMetadata());
            BackColorDarkProperty = ReadOnlyBackColorDarkKey.DependencyProperty;


            ReadOnlyBackColorLightKey = DependencyProperty.RegisterReadOnly("BackColorLight",
                typeof(Color), typeof(BaseBevelPanel), new FrameworkPropertyMetadata());
            BackColorLightProperty = ReadOnlyBackColorLightKey.DependencyProperty;
        }

        private static void OnBackColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            BaseBevelPanel panel = (BaseBevelPanel)sender;
            var color = (Color)e.NewValue;


            try
            {
                panel.BackColorDark = Helper.ChangeColorBrightness(color, (float)-0.4);
                panel.BackColorDark = Helper.ChangeColorBrightness(color, (float)0.5);
            }
            catch
            {
                panel.BackColorDark = panel.BackColorDark = color;
            }
        }


        public BaseBevelPanel()
        {
            //if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            //{
            try
            {
                BackColorDark = Helper.ChangeColorBrightness(BackColor, (float)-0.4);
                BackColorLight = Helper.ChangeColorBrightness(BackColor, (float)0.5);
            }
            catch
            {
                BackColorDark = BackColorLight = BackColor;
            }
            //}

        }
    }
}
