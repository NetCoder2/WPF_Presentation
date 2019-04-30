using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Helpers;

namespace Core.TitlePanel
{
    /// <summary>
    /// The View Model for the title panel
    /// </summary>
    public class TitlePanelViewModel : PanelViewModel
    {
        #region Private Member

        /// <summary>
        /// The title text of the panel 
        /// </summary>
        private string titleText = "Title";


        /// <summary>
        /// The visibility of the title on the panel 
        /// </summary>
        private Visibility titleVisibility = Visibility.Visible;

        /// <summary>
        /// The typeface size of the title
        /// </summary>
        private double fontSize = 30;


        /// <summary>
        /// The height of the title
        /// </summary>
        private double titleHeight = 45;

        /// <summary>
        /// The color of the title label
        /// </summary>
        private Brush titleFontColor;

        #endregion

        #region Public Properties


        /// <summary>
        /// The color of the title label
        /// </summary>
        public Brush TitleFontColor
        {
            get { return titleFontColor; }
            set { titleFontColor = value; }
        }



        /// <summary>
        /// The title of the panel 
        /// </summary>
        public string TitleText
        {
            get { return titleText; }
            set { titleText = value; }
        }

        /// <summary>
        /// The visibility of the title on the panel 
        /// </summary>
        public Visibility TitleVisibility
        {
            get { return titleVisibility; }
            set { titleVisibility = value; }
        }


        /// <summary>
        /// The typeface size of the title
        /// </summary>
        public double FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }

        /// <summary>
        /// The height of the title
        /// </summary>
        public double TitleHeight
        {
            get { return titleHeight; }
            set { titleHeight = value; }
        }




        public double TitleLabelHeight
        {
            get;
            set;
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public TitlePanelViewModel()
        {
            titleFontColor = (Brush)"WordGreenBrush".GetResource();

        }

        #endregion
    }
}
