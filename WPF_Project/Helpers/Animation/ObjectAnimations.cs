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
    /// Helpers to animate pages in specific ways
    /// </summary>
    public static class ObjectAnimations
    {

        /// <summary>
        /// Shows a grid, fades and scales it in
        /// </summary>
        /// <param name="grid">The grid to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task ShowScaleAndFadeIn(this Grid grid, float seconds)
        {
            Storyboard s = new Storyboard();
            s.AddScaleXAnimation(grid, 0, 1, seconds);
            s.AddScaleYAnimation(grid, 0, 1, seconds);
            s.AddFadeIn(grid, 0, 1, seconds * 3);
            s.Begin();

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }


        /// <summary>
        /// Hides a grid, fades and scales it out 
        /// </summary>
        /// <param name="grid">The grid to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task HideScaleAndFadeOut(this Grid grid, float seconds)
        {
            Storyboard s = new Storyboard();
            s.AddScaleXAnimation(grid, 1, 0, seconds);
            s.AddScaleYAnimation(grid, 1, 0, seconds);
            s.AddFadeIn(grid, 1, 0, seconds);
            s.Begin();

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }


        /// <summary>
        /// Shows a grid from and fades in
        /// </summary>
        /// <param name="grid">The grid to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task ShowFadeIn(this Grid grid, float seconds)
        {
            Storyboard s = new Storyboard();
            s.AddFadeIn(grid, 0, 1, seconds * 3);
            s.Begin();

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }

        /// <summary>
        /// Hides a grid to and fades out
        /// </summary>
        /// <param name="grid">The grid to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task HideFadeOut(this Grid grid, float seconds)
        {
            Storyboard s = new Storyboard();
            s.AddFadeIn(grid, 1, 0, seconds);
            s.Begin();

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }


        /// <summary>
        /// Slides a window in from the right
        /// </summary>
        /// <param name="window">The window to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        /// 
        public static async Task SlideAndFadeInFromRight(this Window window, float millisSeconds)
        {
            var width = System.Windows.SystemParameters.PrimaryScreenWidth;
            var startPosition = window.Left;
            // Create the storyboard
            Storyboard s = new Storyboard();

            // Add slide from right animation
            s.AddSlideFromRight(window, width, startPosition, millisSeconds * 1000);

            // Add fade in animation
            s.AddFadeIn(window, 0, 1, millisSeconds * 2);

            // Start animating
            s.Begin();

            // Wait for it to finish
            await Task.Delay((int)(millisSeconds * 1000));
        }


        /// <summary>
        /// Slides a window out to the left
        /// </summary>
        /// <param name="window">The window to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToLeft(this Window window, float millisSeconds)
        {
            var startPosition = window.Left;
            // Create the storyboard
            Storyboard s = new Storyboard();

            // Add slide from right animation
            s.AddSlideFromRight(window, startPosition, -window.Width, millisSeconds * 1000);

            // Add fade in animation
            s.AddFadeIn(window, 1, 0, millisSeconds);

            // Start animating
            s.Begin();


            // Wait for it to finish
            await Task.Delay((int)(millisSeconds * 1000));
        }


        /// <summary>
        /// Fades background from pointed color to pointed color
        /// </summary>
        /// <param name="checkBox">The CheckBox to animate</param>
        /// <param name="seconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task BackgroundColorFade(this CheckBox checkBox,
            Color colorFrom,
            Color colorTo,
            float seconds)
        {
            // Create the storyboard
            Storyboard s = new Storyboard();

            // Add color fade animation
            s.AddBackgroundColorFade(checkBox, colorFrom, colorTo, seconds);

            // Start animating
            s.Begin();

            // Wait for it to finish
            await Task.Delay((int)(seconds * 1000));
        }


        /// <summary>
        /// Fading animation
        /// </summary>
        /// <param name="dependencyObject">The control to animate</param>
        /// <param name="millisSeconds">The time the animation will take</param>
        /// <returns></returns>
        public static async Task FadeIn(this DependencyObject dependencyObject,
            float millisSeconds,
            double fadeFrom,
            double fadeTo)
        {
            Storyboard s = new Storyboard();
            s.AddFadeIn(dependencyObject, fadeFrom, fadeTo, millisSeconds);
            s.Begin();

            // Wait for it to finish
            await Task.Delay((int)(millisSeconds * 1000));
        }





    }
}
