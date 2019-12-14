using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core;

namespace UI.Controls
{
    /// <summary>
    /// Interaction logic for Pager.xaml
    /// </summary>
    public partial class Pager : UserControl
    {
        public static readonly RoutedEvent OnPageChanged;
        private class PagerItem
        {
            public int PageIndex
            {
                get;
                set;
            }

            public PagerItem(int index)
            {
                PageIndex = index;
            }
        }



       // private PagingViewModel context;
        private static int defaultPagesCount = 8;
        private static int defaultShowPagesCount = 5;
        private static int defaultCurrentPageIndex = 1;
        private bool isSelectionChanged = false;


        private ObservableCollection<PagerItem> pagerItems;

        #region Dependency properties

        public static readonly DependencyProperty IsButtonsVisibleProperty;
        public static readonly DependencyProperty PagesCountProperty;
        public static readonly DependencyProperty ShowPagesCountProperty;
        public static readonly DependencyProperty PagerFontSizeProperty;
        public static readonly DependencyProperty CurrentPageIndexProperty;
        public static readonly DependencyProperty RoundButtonRadiusProperty;

        /// <summary>
        /// The total count of the pages
        /// </summary>
        public int PagesCount
        {
            get { return (int)base.GetValue(PagesCountProperty); }
            set { base.SetValue(PagesCountProperty, value); }
        }

        /// <summary>
        /// The Pages Count to show
        /// </summary>
        public int ShowPagesCount
        {
            get { return (int)base.GetValue(ShowPagesCountProperty); }
            set { base.SetValue(ShowPagesCountProperty, value); }
        }

        /// <summary>
        /// The Current Page Number
        /// </summary>
        public int CurrentPageIndex
        {
            get { return (int)base.GetValue(CurrentPageIndexProperty); }
            set { base.SetValue(CurrentPageIndexProperty, value); }
        }

        /// <summary>
        /// The font size for the page number labels
        /// </summary>
        public double PagerFontSize
        {
            get { return (double)base.GetValue(FontSizeProperty); }
            set { base.SetValue(FontSizeProperty, value); }
        }


        /// <summary>
        /// The round radius of the buttons
        /// </summary>
        public double RoundButtonRadius
        {
            get { return (double)base.GetValue(RoundButtonRadiusProperty); }
            set { base.SetValue(RoundButtonRadiusProperty, value); }
        }

        /// <summary>
        /// Shows/Hides Prev/Next,Last/First buttons
        /// </summary>
        public bool IsButtonsVisible
        {
            get { return (bool)base.GetValue(IsButtonsVisibleProperty); }
            set { base.SetValue(IsButtonsVisibleProperty, value); }
        }

        public event RoutedEventHandler PageChanged
        {
            add
            {
                base.AddHandler(Pager.OnPageChanged, value);
            }
            remove
            {
                base.RemoveHandler(OnPageChanged, value);
            }
        }

        static Pager()
        {
            PagesCountProperty = DependencyProperty.Register("PagesCount",
                typeof(int),
                typeof(Pager),
                new PropertyMetadata(defaultPagesCount, PagesCountChanged));


            ShowPagesCountProperty = DependencyProperty.Register("ShowPagesCount",
                typeof(int),
                typeof(Pager),
                new PropertyMetadata(defaultShowPagesCount, ShowPagesCountChanged));


            PagerFontSizeProperty = DependencyProperty.Register("PagerFontSize",
                typeof(double),
                typeof(Pager),
                new PropertyMetadata(20.0));

            PagerFontSizeProperty = DependencyProperty.Register("RoundButtonRadius",
                typeof(double),
                typeof(Pager),
                new PropertyMetadata(50.0));


            CurrentPageIndexProperty = DependencyProperty.Register("CurrentPageIndex",
                typeof(int),
                typeof(Pager),
                new PropertyMetadata(defaultCurrentPageIndex, CurrentPageIndexChanged));


            IsButtonsVisibleProperty = DependencyProperty.Register("IsButtonsVisible",
                typeof(bool),
                typeof(Pager),
                new PropertyMetadata(true));

            Pager.OnPageChanged = EventManager.RegisterRoutedEvent("PageChanged",
                RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Pager));
        }

        private static void PagesCountChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            RefreshPager(sender);
        }

        private static void RefreshPager(DependencyObject sender)
        {
            var pager = sender as Pager;

            pager.RefreshPageArea(pager.CurrentPageIndex);
            var selectedItem = pager.pagerItems.Where(i => i.PageIndex == pager.CurrentPageIndex).Single();
            pager.pagerList.SelectedItem = selectedItem;
        }


        private static void ShowPagesCountChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            RefreshPager(sender);
        }


        private static void CurrentPageIndexChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            RefreshPager(sender);
        }


        #endregion

        public Pager()
        {
            InitializeComponent();

            pagerItems = new ObservableCollection<PagerItem>();
            RefreshPageArea(1);
            pagerList.ItemsSource = pagerItems;
            var selectedItem = pagerItems.Where(i => i.PageIndex == 1).Single();
            pagerList.SelectedItem = selectedItem;
        }


        public void RefreshPageArea(int index)
        {
            isSelectionChanged = true;
            var pagesToShow = ShowPagesCount > PagesCount ? PagesCount : ShowPagesCount;


            var shiftPagesCount = (int)pagesToShow / 2;


            if (index <= shiftPagesCount)
            {
                pagerItems.Clear();

                for (int i = 1; i <= pagesToShow; i++)
                {
                    pagerItems.Add(new PagerItem(i));
                }
            }

            else if (index >= (PagesCount - (shiftPagesCount - 1)))
            {
                pagerItems.Clear();

                for (int i = PagesCount - (pagesToShow - 1); i <= PagesCount; i++)
                {
                    pagerItems.Add(new PagerItem(i));
                }
            }

            else
            {
                pagerItems.Clear();

                for (int i = index - shiftPagesCount; i <= index + shiftPagesCount; i++)
                {
                    pagerItems.Add(new PagerItem(i));
                }
            }
        }


        private void pagerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pagerList.SelectedItem != null && isSelectionChanged)
            {
                var item = pagerList.SelectedItem as PagerItem;
                CurrentPageIndex = item.PageIndex;
                isSelectionChanged = false;
                pagerList.SelectedItem = pagerItems.Single(i => i.PageIndex == item.PageIndex);
                RaisePageChanged();

            }


        }

        private void pagerList_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            isSelectionChanged = true;
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (pagerItems.Count > 0)
            {
                var item = pagerList.SelectedItem as PagerItem;
                if (item.PageIndex < PagesCount)
                {
                    GotoPage(item.PageIndex + 1);
                }
            }
        }

        private void GotoPage(int index)
        {

            RefreshPageArea(index);
            var item = pagerItems.Single(i => i.PageIndex == index);
            pagerList.SelectedItem = item;

            RaisePageChanged();
        }

        private void LastPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (pagerItems.Count > 0)
            {
                GotoPage(PagesCount);
            }
        }

        private void PrevPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (pagerItems.Count > 0)
            {
                var item = pagerList.SelectedItem as PagerItem;
                if (item.PageIndex > 1)
                {
                    GotoPage(item.PageIndex - 1);
                }
            }
        }

        private void FirstPageButton_Click(object sender, RoutedEventArgs e)
        {

            if (pagerItems.Count > 0)
            {
                GotoPage(1);
            }
        }


        private void RaisePageChanged()
        {
            RoutedEventArgs args = new RoutedEventArgs(OnPageChanged);
            RaiseEvent(args);
        }


    }
}
