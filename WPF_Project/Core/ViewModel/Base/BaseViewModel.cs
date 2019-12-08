using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Core.Helpers;

namespace Core
{
    public class BaseViewModel : BaseModel
    {
        public delegate void ClosingEventHandler(object sender, CancelEventArgs e);
        public delegate void ClosedEventHandler(object sender, EventArgs eventArgs);
        public delegate void ActivatedEventHandler(object sender, EventArgs eventArgs);
        public delegate void StateChangedEventHandler(object sender, EventArgs eventArgs);

        /// <summary>
        /// The event that is fired when a form closes
        /// </summary>
        public event ClosingEventHandler Closing;

        /// <summary>
        /// The event that is fired when a form closed
        /// </summary>
        public event ClosedEventHandler Closed;

        /// <summary>
        /// The event that is fired when a form ativated
        /// </summary>
        public event ActivatedEventHandler Activated;

        /// <summary>
        /// The event that is fired when a form changes state
        /// </summary>
        public event StateChangedEventHandler StateChanged;

        /// <summary>
        /// The detect if current window is active 
        /// </summary>
        public bool Deactivate { get; set; }

        /// <summary>
        /// Dialog Result for the ShowDialog function
        /// </summary>
        public bool? DialogResult { get; set; }


        ///// <summary>
        ///// The owner for opened Window
        ///// </summary>
        //public Window OwnerWindow { get; set; }

        /// <summary>
        /// The current opened Window
        /// </summary>
        public Window CurrentOpenedWindow { get; set; }



        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseViewModel()
        {

        }

        /// <summary>
        /// The Ok command for the dialog Window
        /// </summary>
        private ICommand okCloseDialogCommand;
        public ICommand OkCloseDialogCommand
        {
            get
            {
                return okCloseDialogCommand ??
                  (okCloseDialogCommand = new RelayCommand(param =>
                  {
                      DialogResult = true;
                  }));

            }
        }

        /// <summary>
        /// The command to cancel the dialog Window
        /// </summary>
        private ICommand cancelCloseDialogCommand;
        public ICommand CancelCloseDialogCommand
        {
            get
            {
                return cancelCloseDialogCommand ??
                  (cancelCloseDialogCommand = new RelayCommand(param =>
                  {
                      DialogResult = false;
                  }));

            }
        }


        protected void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        public virtual void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (Closing != null)
            {
                Closing(this, e);
            }
        }

        public virtual void CurrentOpenedWindowOnClosed(object sender, EventArgs e)
        {
            //Deactivate = true;
            if (Closed != null)
            {
                Closed(this, e);
            }

        }

        private void CurrentOpenedWindowOnActivated(object sender, EventArgs e)
        {
            Deactivate = false;
            if (Activated != null)
            {
                Activated(this, e);
            }
        }

        private void CurrentOpenedWindowOnStateChanged(object sender, EventArgs e)
        {
            if (StateChanged != null)
            {
                StateChanged(this, e);
            }
        }


        /// <summary>
        /// Opens window from the specified URL
        /// </summary>
        /// <param name="windowUrl">The URL for opened window</param>
        /// <param name="context">DaTaContext for the window</param>
        /// <param name="owner">The owner for the window</param>
        /// <param name="isDialog">TIs dialog window</param>
        public Window OpenWindowFormUrl(string windowUrl, object context, Window owner, bool isDialog)
        {
            if (!string.IsNullOrEmpty(windowUrl))
            {
                var uri = new Uri(windowUrl, UriKind.Relative);
                CurrentOpenedWindow = (Window)Application.LoadComponent(uri);


                //set the owner for opened window
                if (owner != null)
                {
                    //sets iniactive owner Window with gray layer
                    var ownerContext = owner.DataContext as BaseViewModel;
                    if (ownerContext != null && windowUrl != WindowPath.LoadingWindow)
                    {
                        ownerContext.Deactivate = true;
                    }

                    CurrentOpenedWindow.Owner = owner;
                    CurrentOpenedWindow.Closing += OnWindowClosing;
                    CurrentOpenedWindow.Closed += CurrentOpenedWindowOnClosed;
                    CurrentOpenedWindow.Activated += CurrentOpenedWindowOnActivated;
                    CurrentOpenedWindow.StateChanged += CurrentOpenedWindowOnStateChanged;
                }
                //set the DataContext for opened window
                if (context != null)
                {
                    CurrentOpenedWindow.DataContext = context;
                }

                if (isDialog)
                {
                    CurrentOpenedWindow.ShowDialog();
                }
                else
                {
                    CurrentOpenedWindow.Show();
                }

                return CurrentOpenedWindow;
            }
            return null;
        }
    }
}
