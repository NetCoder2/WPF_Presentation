using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Core.TitlePanel;
using Helpers;

namespace Core
{
    /// <summary>
    /// A view model for the paged items list  
    /// </summary>
    public class PagedListItem<T> : TitlePanelViewModel where T : SelectionItem, new()
    {
        private AdvancedObservableCollection<T> _items = new AdvancedObservableCollection<T>();
        private T selectedItem;
        private int? _selectedItemId;
        private int _pageCount = 1;
        private int _pageSize = 4;
        private int _pageIndex = 1;
        private ICommand _nextPageCommand;
        private ICommand _prevPageCommand;



        /// <summary>
        /// The pages count of items list
        /// </summary>
        public int PageCount
        {
            get { return _pageCount; }
            set
            {
                _pageCount = value;
            }
        }


        /// <summary>
        /// The items count per page
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        /// <summary>
        /// The index of the current page
        /// </summary>
        public int PageIndex
        {
            get { return _pageIndex; }
            set
            {
                _pageIndex = value;
            }
        }

        /// <summary>
        /// The selected item
        /// </summary>
        public T SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (value == null && selectedItem != null)
                {
                    SelectedItemId = null;
                }

                selectedItem = value;

                if (selectedItem != null && selectedItem.Id != SelectedItemId)
                {
                    SelectedItemId = selectedItem.Id;
                }
            }
        }

        /// <summary>
        /// The selected item Id
        /// </summary>
        public int? SelectedItemId
        {
            get
            {
                return _selectedItemId;
            }
            set
            {

                _selectedItemId = value;
                if (SelectedItem == null || SelectedItem.Id != _selectedItemId)
                {
                    SelectedItem = Items.SingleOrDefault(i => i.Id == value);
                }

            }
        }

        /// <summary>
        /// The items list 
        /// </summary>
        public AdvancedObservableCollection<T> Items
        {
            get { return _items; }
            set
            {
                _items = value;
            }
        }




        /// <summary>
        /// The command to go to the next page
        /// </summary>
        public ICommand NextPageCommand
        {
            get
            {
                return _nextPageCommand ??
                  (_nextPageCommand = new RelayCommand(param =>
                  {
                      PageIndex++;
                  }));

            }
        }


        /// <summary>
        /// The command to go to the prev. page
        /// </summary>
        public ICommand PrevPageCommand
        {
            get
            {
                return _prevPageCommand ??
                  (_prevPageCommand = new RelayCommand(param =>
                  {
                      PageIndex--;
                  }));

            }
        }

        public PagedListItem()
        {
            selectedItem = new T();
        }
    }
}
