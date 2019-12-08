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
            get { return PanelContext.TitleText; }
            set
            {
                PanelContext.TitleText = value;
            }
        }

        /// <summary>
        /// The visibility of the title 
        /// </summary>
        public Visibility TitleVisibility
        {
            get { return PanelContext.TitleVisibility; }
            set
            {
                PanelContext.TitleVisibility = value;
            }
        }


        /// <summary>
        /// The typeface's size of the title
        /// </summary>
        public double TitleFontSize
        {
            get { return PanelContext.FontSize; }
            set
            {
                PanelContext.FontSize = value;
            }
        }

        /// <summary>
        /// The height of the title
        /// </summary>
        public double TitleHeight
        {
            get { return PanelContext.TitleHeight; }
            set
            {
                PanelContext.TitleHeight = value;
            }
        }


        /// <summary>
        /// The color of the title label
        /// </summary>
        public Brush TitleFontColor
        {
            get { return PanelContext.TitleFontColor; }
            set
            {
                PanelContext.TitleFontColor = value;
            }
        }

        /// <summary>
        /// The DataContext for the Beveled panel with title
        /// </summary>
        public PanelWindowViewModel PanelContext { get; set; }



        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowModel()
        {
            PanelContext = new PanelWindowViewModel();
        }

        #endregion
    }
}
