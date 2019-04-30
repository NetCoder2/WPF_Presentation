using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Core.TitlePanel;

namespace Core
{
    /// <summary>
    /// The View Model for the window with title panel
    /// </summary>
    public class WindowModel : BaseViewModel
    {

        /// <summary>
        /// The title of the window
        /// </summary>
        public string Title
        {
            get { return BevelPanelContext.TitleText; }
            set
            {
                BevelPanelContext.TitleText = value;
            }
        }

        /// <summary>
        /// The visibility of the title 
        /// </summary>
        public Visibility TitleVisibility
        {
            get { return BevelPanelContext.TitleVisibility; }
            set
            {
                BevelPanelContext.TitleVisibility = value;
            }
        }


        /// <summary>
        /// The typeface's size of the title
        /// </summary>
        public double TitleFontSize
        {
            get { return BevelPanelContext.FontSize; }
            set
            {
                BevelPanelContext.FontSize = value;
            }
        }

        /// <summary>
        /// The height of the title
        /// </summary>
        public double TitleHeight
        {
            get { return BevelPanelContext.TitleHeight; }
            set
            {
                BevelPanelContext.TitleHeight = value;
            }
        }


        /// <summary>
        /// The color of the title label
        /// </summary>
        public Brush TitleFontColor
        {
            get { return BevelPanelContext.TitleFontColor; }
            set
            {
                BevelPanelContext.TitleFontColor = value;
            }
        }

        /// <summary>
        /// The DataContext for the Beveled panel with title
        /// </summary>
        public PanelWindowViewModel BevelPanelContext { get; set; }



        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowModel()
        {
            BevelPanelContext = new PanelWindowViewModel();
        }

        #endregion
    }
}
