using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Helpers;
using Helpers.Animation;

namespace Core.TitlePanel
{
    public class PanelViewModel : BaseViewModel
    {
        #region Private Member

        /// <summary>
        /// The color of the background
        /// </summary>
        private Color backColor;

        /// <summary>
        /// The end color of the brush background
        /// </summary>
        private Color backColorEnd;

        /// <summary>
        /// The height of the shadow 
        /// </summary>
        private double shadowHeight = 8.5;

        /// <summary>
        /// The blur of the shadow 
        /// </summary>
        private double shadowBlur = 8;


        /// <summary>
        /// The time any animation takes to complete
        /// </summary>
        private float animationSeconds = 0.15f;


        /// <summary>
        /// The time any load animation takes to complete
        /// </summary>
        private float loadAnimationSeconds = 0.2f;

        /// <summary>
        /// The time any unload animation takes to complete
        /// </summary>
        private float unLoadAnimationSeconds = 0.2f;




        #endregion

        #region Public Properties

        /// <summary>
        /// The animation the play when the panel is first loaded
        /// </summary>
        public WindowAnimation PanelLoadAnimation
        {
            get;set;
        } = WindowAnimation.None;


        /// <summary>
        /// The animation the play when the panel is unloaded
        /// </summary>
        public WindowAnimation PanelUnloadAnimation
        {
            get;set;
        }   = WindowAnimation.None;


        /// <summary>
        /// The time any animation takes to complete
        /// </summary>
        public float AnimationSeconds
        {
            get { return animationSeconds; }
            set { animationSeconds = value; }
        }

        /// <summary>
        /// The time any animation takes to complete
        /// </summary>
        public float LoadAnimationSeconds
        {
            get { return loadAnimationSeconds; }
            set { loadAnimationSeconds = value; }
        }

        /// <summary>
        /// The time any animation takes to complete
        /// </summary>
        public float UnloadAnimationSeconds
        {
            get { return unLoadAnimationSeconds; }
            set { unLoadAnimationSeconds = value; }
        }


        /// <summary>
        /// The color of the background
        /// </summary>
        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }

        /// <summary>
        /// The end color of the brush background
        /// </summary>
        public Color BackColorEnd
        {
            get { return backColorEnd; }
            set { backColorEnd = value; }
        }


        /// <summary>
        /// The height of the shadow 
        /// </summary>
        public double ShadowHeight
        {
            get { return shadowHeight; }
            set { shadowHeight = value; }
        }

        /// <summary>
        /// The height of the shadow 
        /// </summary>
        public double ShadowBlur
        {
            get { return shadowBlur; }
            set { shadowBlur = value; }
        }


        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PanelViewModel()
        {
            var res = "PanelColor".GetResource();
            backColor = res != null ? (Color)res : Colors.Transparent;
            backColorEnd = Colors.White;
        }

        #endregion
    }
}
