using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Helpers.Animation
{
    /// <summary>
    /// Animation helpers for <see cref="StoryBoard"/>
    /// </summary>
    public static class StoryboardHelpers
    {
        /// <summary>
        /// Adds a fade animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="seconds">The time the animation will take</param>
        public static void AddFadeIn(this Storyboard storyboard,
            DependencyObject e,
            double from,
            double to,
            float milliSeconds)
        {
            // Create the margin animate from right 
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(milliSeconds)),
                From = from,
                To = to,
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            Storyboard.SetTarget(animation, e);
            // Add this to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a zoom X animation to the storyboard
        /// </summary>
        public static DoubleAnimation AddScaleXAnimation(this Storyboard storyboard,
            DependencyObject e,
            double from,
            double to,
            float seconds)
        {

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromMilliseconds(seconds * 1000)
            };

            // Set the target property name
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath("RenderTransform.ScaleX"));
            Storyboard.SetTarget(widthAnimation, e);
            storyboard.Children.Add(widthAnimation);
            return widthAnimation;
        }

        /// <summary>
        /// Adds a zoom Y animation to the storyboard
        /// </summary>
        public static DoubleAnimation AddScaleYAnimation(this Storyboard storyboard,
            DependencyObject e,
            double from,
            double to,
            float seconds)
        {

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromMilliseconds(seconds * 1000)
            };

            // Set the target property name
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath("RenderTransform.ScaleY"));
            Storyboard.SetTarget(widthAnimation, e);
            storyboard.Children.Add(widthAnimation);
            return widthAnimation;
        }

        /// <summary>
        /// Adds a height animation to the storyboard
        /// </summary>
        public static DoubleAnimation AddHeightAnimation(this Storyboard storyboard,
            DependencyObject e,
            double from,
            double to,
            float seconds)
        {

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromMilliseconds(seconds * 1000)
            };

            // Set the target property name
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath("Height"));
            Storyboard.SetTarget(widthAnimation, e);
            storyboard.Children.Add(widthAnimation);
            return widthAnimation;
        }

        /// <summary>
        /// Adds a width animation to the storyboard
        /// </summary>
        public static DoubleAnimation AddWidthAnimation(this Storyboard storyboard,
            DependencyObject e,
            double from,
            double to,
            float seconds)
        {

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromMilliseconds(seconds * 1000)
            };

            // Set the target property name
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath("Width"));
            Storyboard.SetTarget(widthAnimation, e);
            storyboard.Children.Add(widthAnimation);
            return widthAnimation;
        }

        /// <summary>
        /// Adds a slide from right animation to the storyboard
        /// </summary>
        /// <param name="seconds">The time the animation will take</param>
        public static DoubleAnimation AddSlideFromRight(this Storyboard storyboard,
            DependencyObject e,
            double from,
            double to,
            float milliSeconds)
        {

            DoubleAnimation widthAnimation = new DoubleAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromMilliseconds(milliSeconds)
            };

            // Set the target property name
            Storyboard.SetTargetProperty(widthAnimation, new PropertyPath("Left"));
            Storyboard.SetTarget(widthAnimation, e);
            storyboard.Children.Add(widthAnimation);
            return widthAnimation;
        }


        /// <summary>
        /// Adds a background color animation to the storyboard
        /// </summary>
        /// <param name="seconds">The time the animation will take</param>
        public static ColorAnimation AddBackgroundColorFade(
            this Storyboard storyboard,
            DependencyObject e,
            Color from,
            Color to,
            float seconds)
        {

            ColorAnimation colorAnimation = new ColorAnimation
            {
                From = from,
                To = to,
                Duration = TimeSpan.FromMilliseconds(seconds * 1000)
            };

            // Set the target property name
            Storyboard.SetTargetProperty(colorAnimation, new PropertyPath("(0).(1)", Control.BackgroundProperty, SolidColorBrush.ColorProperty));
            Storyboard.SetTarget(colorAnimation, e);
            storyboard.Children.Add(colorAnimation);
            return colorAnimation;
        }


    }
}
