using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Core.Helpers;
using Helpers;

namespace Core
{
    /// <summary>
    /// The View Model for the custom flat window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private Member

        /// <summary>
        /// The icons for the maximize button
        /// </summary>
        private const string restoreDownIcon = "/UI;component/Images/Buttons/RestoreDown.png";
        private const string maximizeIcon = "/UI;component/Images/Buttons/Maximize.png";

        /// <summary>
        /// The height of the top shadow of the window
        /// </summary>
        private int topShadowHeight = 5;
        private Color backColor;

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        private int resizeBorder = 6;

        /// <summary>
        /// The smallest height the window can go to
        /// </summary>
        private double windowMinimumHeight = 400;

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        private int titleHeight = 60;

        /// <summary>
        /// The height of the bottom bar / bottom of the window
        /// </summary>
        private int bottomHeight = 30;


        /// <summary>
        /// The smallest width the window can go to
        /// </summary>
        private double windowMinimumWidth = 400;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private System.Windows.Window mWindow;

        /// <summary>
        /// The window resizer helper that keeps the window size correct in various states
        /// </summary>
        private WindowResizer mWindowResizer;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;




        #endregion

        #region Public Properties

        #region Window Label Title

        public string SomeWord { get; set; }



        #endregion

        /// <summary>
        /// True if the window should be borderless because it is docked or maximized
        /// </summary>
        //public string MaximizeButtonIcon
        //{
        //    get
        //    {
        //        return mWindow.WindowState == WindowState.Maximized ? restoreDownIcon : maximizeIcon;
        //    }
        //}



        /// <summary>
        /// The smallest width the window can go to
        /// </summary>
        public double WindowMinimumWidth
        {
            get { return windowMinimumWidth; }
            set { windowMinimumWidth = value; }
        }

        /// <summary>
        /// The smallest height the window can go to
        /// </summary>
        public double WindowMinimumHeight
        {
            get { return windowMinimumHeight; }
            set { windowMinimumHeight = value; }
        }
        /// <summary>
        /// True if the window should be borderless because it is docked or maximized
        /// </summary>
        public bool Borderless { get { return (mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked); } }


        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder
        {
            get { return resizeBorder; }
            set { resizeBorder = value; }
        }

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        /// <summary>
        /// The padding of the inner content of the main window
        /// </summary>
        public Thickness InnerContentPadding { get { return new Thickness(ResizeBorder); } }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                // If it is maximized or docked, no border
                return Borderless ? 0 : mOuterMarginSize;
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            get
            {
                // If it is maximized or docked, no border
                return Borderless ? 0 : mWindowRadius;
            }
            set
            {
                mWindowRadius = value;
            }
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }


        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight
        {
            get { return titleHeight; }
            set { titleHeight = value; }
        }

        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public int BottomHeight
        {
            get { return bottomHeight; }
            set { bottomHeight = value; }
        }

        /// <summary>
        /// The height of the top shadow of the window
        /// </summary>
        public int TopShadowHeight
        {
            get { return topShadowHeight; }
            set { topShadowHeight = value; }
        }

        public Color BackColor
        {
            get { return backColor; }
            set { backColor = value; }
        }



        /// <summary>
        /// The height of the title bar / caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength
        {
            get
            {
                return new GridLength(TitleHeight + ResizeBorder);
            }
        }


        /// <summary>
        /// The height of the bottom bar / bottom of the window
        /// </summary>
        public GridLength BottomHeightGridLength { get { return new GridLength(BottomHeight + ResizeBorder); } }

        public string MaximizeButtonIcon
        {
            get
            {
                return mWindow.WindowState == WindowState.Maximized ? restoreDownIcon : maximizeIcon;
            }
        }

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show the system menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }


        /// <summary>
        /// The command to show the calculator window
        /// </summary>
        private ICommand openCalculatorCommand;
        public ICommand OpenCalculatorCommand
        {
            get
            {
                return openCalculatorCommand ??
                  (openCalculatorCommand = new RelayCommand(param =>
                  {
                      //Deactivate = true;
                      var calc = ViewModelLocator.Instance.CalculatorViewModel;
                      calc.Title = "Calculator";
                      calc.Closing += CalculatorDataContextOnClosing;
                      calc.Closed += CalculatorOnClosed;
                      //settings.BevelPanelContext.LoadAnimationSeconds = settings.BevelPanelContext.LoadAnimationSeconds * 2;
                      calc.OpenWindowFormUrl(WindowPath.CalculatorWindow,
                          calc,
                          CurrentOpenedWindow,
                          true);

                  }));

            }
        }

        /// <summary>
        /// The command to show the calculator window
        /// </summary>
        private ICommand currencyConverterCommand;
        public ICommand CurrencyConverterCommand
        {
            get
            {
                return currencyConverterCommand ??
                  (currencyConverterCommand = new RelayCommand(param =>
                  {
                      //Deactivate = true;
                      var cur = ViewModelLocator.Instance.CurrencyConverterViewModel;
                      cur.Title = "Currency Converter";
                      cur.OpenWindowFormUrl(WindowPath.CurrencyConverterWindow,
                          cur,
                          CurrentOpenedWindow,
                          true);

                  }));

            }
        }

        private void CalculatorOnClosed(object sender, EventArgs eventArgs)
        {
            Deactivate = false;
        }


        public void CalculatorDataContextOnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            var sdsd = 1;

            //CurrentOpenedWindow.Activate();
            //if (settingsDataContext.DialogResult.Value)
            //{
            //    //EquipmentId = equipSelectionList.SelectedItemId;
            //}
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            // Listen out for the window resizing
            mWindow.StateChanged += (sender, e) =>
            {
                // Fire off events for all properties that are affected by a resize
                WindowResized();
            };

            // Create commands
            MinimizeCommand = new RelayCommand(param => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(param =>
            {
                mWindow.WindowState ^= WindowState.Maximized;
                SomeWord = "qwerty";
            });
            CloseCommand = new RelayCommand(param => mWindow.Close());
            MenuCommand = new RelayCommand(param => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            // Fix window resize issue
            mWindowResizer = new WindowResizer(mWindow);

            // Listen out for dock changes
            mWindowResizer.WindowDockChanged += (dock) =>
            {
                // Store last position
                mDockPosition = dock;

                // Fire off resize events
                WindowResized();
            };
        }

        #endregion

        #region Private Helpers

        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition()
        {
            // Position of the mouse relative to the window
            var position = Mouse.GetPosition(mWindow);

            // Add the window position so its a "ToScreen"
            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        /// <summary>
        /// If the window resizes to a special position (docked or maximized)
        /// this will update all required property change events to set the borders and radius values
        /// </summary>
        private void WindowResized()
        {

            // Fire off events for all properties that are affected by a resize
            OnPropertyChanged(Helper.GetMemberName(() => Borderless));
            OnPropertyChanged(Helper.GetMemberName(() => MaximizeButtonIcon));
            OnPropertyChanged(Helper.GetMemberName(() => ResizeBorderThickness));
            OnPropertyChanged(Helper.GetMemberName(() => OuterMarginSize));
            OnPropertyChanged(Helper.GetMemberName(() => OuterMarginSizeThickness));
            OnPropertyChanged(Helper.GetMemberName(() => WindowRadius));
            OnPropertyChanged(Helper.GetMemberName(() => WindowCornerRadius));
        }


        #endregion
    }
}
