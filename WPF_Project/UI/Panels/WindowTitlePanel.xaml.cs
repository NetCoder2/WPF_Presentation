using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Core.TitlePanel;
using Helpers.Animation;

namespace UI.Panels
{
    /// <summary>
    /// Interaction logic for WindowTitlePanel.xaml
    /// </summary>
    public partial class WindowTitlePanel : UserControl
    {
        private Window window;
        private bool doClose = false;
        private PanelWindowViewModel context;
        public WindowTitlePanel()
        {
            InitializeComponent();
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            window = Window.GetWindow(this);
            context = this.DataContext as PanelWindowViewModel;
            if (window != null)
            {
                window.Closing += window_Closing;
                window.Closed += WindowOnClosed;
                await AnimateIn();
            }

        }


        

        /// <summary>
        /// Animates the window in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {

            if (context == null || context.PanelLoadAnimation == WindowAnimation.None)
                return;
            var myGrid = Template.FindName("ContentGrid", this) as Grid;
            switch (context.PanelLoadAnimation)
            {
                case WindowAnimation.SlideAndFadeInFromRight:
                    await window.SlideAndFadeInFromRight(context.LoadAnimationSeconds);
                    break;
                case WindowAnimation.ShowScaleAndFadeIn:
                    await myGrid.ShowScaleAndFadeIn(context.LoadAnimationSeconds);
                    break;
                case WindowAnimation.ShowFadeIn:
                    await myGrid.ShowFadeIn(context.LoadAnimationSeconds);
                    break;
            }
        }


        /// <summary>
        /// Animates the window out
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            if (context == null || context.PanelUnloadAnimation == WindowAnimation.None)
                return;

            var myGrid = Template.FindName("ContentGrid", this) as Grid;
            switch (context.PanelUnloadAnimation)
            {
                case WindowAnimation.SlideAndFadeOutToLeft:
                    await window.SlideAndFadeOutToLeft(context.UnloadAnimationSeconds);
                    break;
                case WindowAnimation.HideScaleAndFadeOut:
                    await myGrid.HideScaleAndFadeOut(context.UnloadAnimationSeconds);
                    break;
                case WindowAnimation.HideFadeOut:
                    await myGrid.HideFadeOut(context.LoadAnimationSeconds);
                    break;
            }
        }

        private async void window_Closing(object sender, global::System.ComponentModel.CancelEventArgs e)
        {
            if (context == null)
                return;

            if (!doClose && !e.Cancel)
            {
                e.Cancel = true;
                await ClosingTasks();
            }
        }

        private void WindowOnClosed(object sender, EventArgs eventArgs)
        {

        }


        private async Task ClosingTasks()
        {
            await AnimateOut();
            doClose = true;
            window.Close();

            var owner = window.Owner;
            if (owner != null)
            {
                owner.Activate();
            }

        }

        private async void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            //var context = this.DataContext as BevelPanelWindowViewModel;


            //var slideSeconds = 0.2f;
            //var myGrid = Template.FindName("ContentGrid", this) as Grid;

            //await myGrid.HideAndFadeOut(slideSeconds);

        }

    }
}
