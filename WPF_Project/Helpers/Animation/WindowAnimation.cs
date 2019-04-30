using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Animation
{
    /// <summary>
    /// Styles of window animations for appearing/disappearing
    /// </summary>
    public enum WindowAnimation
    {
        /// <summary>
        /// No animation takes place
        /// </summary>
        None = 0,

        /// <summary>
        /// The window is having shown with a scale and fade 
        /// </summary>
        ShowScaleAndFadeIn = 1,

        /// <summary>
        /// The window is having hidden wtih a scale and fade 
        /// </summary>
        HideScaleAndFadeOut = 2,

        /// <summary>
        /// The window slides in and fades in from the right
        /// </summary>
        SlideAndFadeInFromRight = 3,

        /// <summary>
        /// The window slides out and fades out to the left
        /// </summary>
        SlideAndFadeOutToLeft = 4,

        /// <summary>
        /// The window is having faded in 
        /// </summary>
        ShowFadeIn = 5,

        /// <summary>
        /// The window is having faded faded out 
        /// </summary>
        HideFadeOut = 6
    }
}
