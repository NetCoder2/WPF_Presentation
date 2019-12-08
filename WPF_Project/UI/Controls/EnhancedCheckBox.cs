using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using System.Windows.Input;
using System.Windows.Media;
using Helpers;
using System.Windows.Media.Animation;
using Helpers.Animation;

namespace UI.Controls
{
    public class EnhancedCheckBox : CheckBox
    {
        #region Private members

        private float colorAnimationDuaration = 0.5f;

        #endregion

        #region Dependency properties

        public static readonly DependencyProperty MainRectColorProperty;
        public static readonly DependencyProperty SmallRectColorProperty;
        public static readonly DependencyProperty MainLabelColorProperty;
        public static readonly DependencyProperty AdditionalLabelTitleColorProperty;
        public static readonly DependencyProperty AdditionalLabelColorProperty;
        public static readonly DependencyProperty CheckBoxColorProperty;
        public static readonly DependencyProperty AdditionalLabelProperty;
        public static readonly DependencyProperty AdditionalLabelTitleProperty;
        public static readonly DependencyProperty TitleLabelProperty;
        public static readonly DependencyProperty CheckSizeProperty;
        public static readonly DependencyProperty AdditionalLabelVisibleProperty;
        public static readonly DependencyProperty AdditionalLabelFontSizeProperty;
        public static readonly DependencyProperty SelectedSmallRectColorProperty;

        public SolidColorBrush MainRectColor
        {
            get { return (SolidColorBrush)base.GetValue(MainRectColorProperty); }
            set { base.SetValue(MainRectColorProperty, value); }
        }

        /// <summary>
        /// The color of the rectangle with title
        /// </summary>
        public SolidColorBrush SmallRectColor
        {
            get { return (SolidColorBrush)base.GetValue(SmallRectColorProperty); }
            set { base.SetValue(SmallRectColorProperty, value); }
        }

        /// <summary>
        /// The color of the rectangle with title when CheckBox checked
        /// </summary>
        public SolidColorBrush SelectedSmallRectColor
        {
            get { return (SolidColorBrush)base.GetValue(SelectedSmallRectColorProperty); }
            set { base.SetValue(SelectedSmallRectColorProperty, value); }
        }

        /// <summary>
        /// The fill color of main label
        /// </summary>
        public SolidColorBrush MainLabelColor
        {
            get { return (SolidColorBrush)base.GetValue(MainLabelColorProperty); }
            set { base.SetValue(MainLabelColorProperty, value); }
        }

        /// <summary>
        /// The fill color of additional title label
        /// </summary>
        public SolidColorBrush AdditionalLabelTitleColor
        {
            get { return (SolidColorBrush)base.GetValue(AdditionalLabelTitleColorProperty); }
            set { base.SetValue(AdditionalLabelTitleColorProperty, value); }
        }

        /// <summary>
        /// The fill color of additional label
        /// </summary>
        public SolidColorBrush AdditionalLabelColor
        {
            get { return (SolidColorBrush)base.GetValue(AdditionalLabelColorProperty); }
            set { base.SetValue(AdditionalLabelColorProperty, value); }
        }

        public string AdditionalLabel
        {
            get { return (string)base.GetValue(AdditionalLabelProperty); }
            set { base.SetValue(AdditionalLabelProperty, value); }
        }

        public string AdditionalLabelTitle
        {
            get { return (string)base.GetValue(AdditionalLabelTitleProperty); }
            set { base.SetValue(AdditionalLabelTitleProperty, value); }
        }

        public string TitleLabel
        {
            get { return (string)base.GetValue(TitleLabelProperty); }
            set { base.SetValue(TitleLabelProperty, value); }
        }

        /// <summary>
        /// The width and height of the rounded CheckBox
        /// </summary>
        public double CheckSize
        {
            get { return (double)base.GetValue(CheckSizeProperty); }
            set { base.SetValue(CheckSizeProperty, value); }
        }

        public bool AdditionalLabelVisible
        {
            get { return (bool)base.GetValue(AdditionalLabelVisibleProperty); }
            set { base.SetValue(CheckSizeProperty, value); }
        }

        public double AdditionalLabelFontSize
        {
            get { return (double)base.GetValue(AdditionalLabelFontSizeProperty); }
            set { base.SetValue(CheckSizeProperty, value); }
        }

        /// <summary>
        /// The back color of CheckBox
        /// </summary>
        public SolidColorBrush CheckBoxColor
        {
            get { return (SolidColorBrush)base.GetValue(CheckBoxColorProperty); }
            set { base.SetValue(CheckBoxColorProperty, value); }
        }

        private static void OnSmallRectColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            EnhancedCheckBox checkBox = (EnhancedCheckBox)sender;
            var brush = (SolidColorBrush)e.NewValue;

            if (!checkBox.IsChecked.Value)
            {
                checkBox.Background = brush;
            }

        }

        private static void OnSelectedSmallRectColorChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            EnhancedCheckBox checkBox = (EnhancedCheckBox)sender;
            var brush = (SolidColorBrush)e.NewValue;

            if (checkBox.IsChecked.Value)
            {
                checkBox.Background = brush;
            }
        }

        static EnhancedCheckBox()
        {

            MainRectColorProperty = DependencyProperty.Register("MainRectColor",
                typeof(SolidColorBrush),
                typeof(EnhancedCheckBox),
                new PropertyMetadata(new SolidColorBrush(Colors.White)));


            SelectedSmallRectColorProperty = DependencyProperty.Register("SelectedSmallRectColor",
                typeof(SolidColorBrush),
                typeof(EnhancedCheckBox),
                new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00aae8")),
                    OnSelectedSmallRectColorChanged));


            SmallRectColorProperty = DependencyProperty.Register("SmallRectColor",
                typeof(SolidColorBrush),
                typeof(EnhancedCheckBox),
                new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6b8e23")),
                    OnSmallRectColorChanged));

            MainLabelColorProperty = DependencyProperty.Register("MainLabelColor",
                typeof(SolidColorBrush),
                typeof(EnhancedCheckBox),
                new PropertyMetadata(new SolidColorBrush(Colors.White)));

            AdditionalLabelTitleColorProperty = DependencyProperty.Register("AdditionalLabelTitleColor",
                typeof(SolidColorBrush),
                typeof(EnhancedCheckBox),
                new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#d2691e"))));


            AdditionalLabelColorProperty = DependencyProperty.Register("AdditionalLabelColor",
                typeof(SolidColorBrush),
                typeof(EnhancedCheckBox),
                new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#008b8b"))));


            CheckBoxColorProperty = DependencyProperty.Register("CheckBoxColor",
                typeof(SolidColorBrush),
                typeof(EnhancedCheckBox),
                new PropertyMetadata(new SolidColorBrush((Color)ColorConverter.ConvertFromString("#00a8e9"))));


            AdditionalLabelProperty = DependencyProperty.Register("AdditionalLabel",
                typeof(string),
                typeof(EnhancedCheckBox),
                new PropertyMetadata(string.Empty));

            TitleLabelProperty = DependencyProperty.Register("TitleLabel",
                typeof(string),
                typeof(EnhancedCheckBox),
                new PropertyMetadata(string.Empty));


            AdditionalLabelTitleProperty = DependencyProperty.Register("AdditionalLabelTitle",
                typeof(string),
                typeof(EnhancedCheckBox),
                new PropertyMetadata(string.Empty));

            CheckSizeProperty = DependencyProperty.Register("CheckSize",
                typeof(double),
                typeof(EnhancedCheckBox),
                new PropertyMetadata(35.0));

            AdditionalLabelVisibleProperty = DependencyProperty.Register("AdditionalLabelVisible",
                typeof(bool),
                typeof(EnhancedCheckBox),
                new PropertyMetadata(true));

            AdditionalLabelFontSizeProperty = DependencyProperty.Register("AdditionalLabelFontSize",
                typeof(double),
                typeof(EnhancedCheckBox),
                new PropertyMetadata(14.0));


        }



        async protected override void OnChecked(RoutedEventArgs e)
        {
            Background = SelectedSmallRectColor;
            await ColorEffectAnimation();
        }

        async protected override void OnUnchecked(RoutedEventArgs e)
        {
            Background = SmallRectColor;
            await ColorEffectAnimation();
        }


        protected void OnPreviewMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {

        }

        public async Task ColorEffectAnimation()
        {
            if (!this.IsChecked.Value)
            {
                await this.BackgroundColorFade(SelectedSmallRectColor.Color, SmallRectColor.Color, colorAnimationDuaration);
            }
            else
            {
                await this.BackgroundColorFade(SmallRectColor.Color, SelectedSmallRectColor.Color, colorAnimationDuaration);
            }
        }


        public EnhancedCheckBox()
        {
            Background = IsChecked.Value ? SelectedSmallRectColor : SmallRectColor;
            PreviewMouseDown += OnPreviewMouseDown;
        }

        #endregion
    }
}
