using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class PagingViewModel : BaseModel
    {
        private ObservableCollection<PagerItem> pagerItems;
        private PagerItem selectedItem;
        private int _selectedPageIndex;

        /// <summary>
        /// The selected item
        /// </summary>
        public PagerItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
            }
        }

        /// <summary>
        /// The current page index
        /// </summary>
        public int SelectedPageIndex
        {
            get
            {
                return SelectedItem.PageIndex;
            }
            set
            {
                //_selectedPageIndex = value;
                SelectedItem = PagerItems.Where(i => i.PageIndex == value).Single();

            }
        }

        /// <summary>
        /// The items list 
        /// </summary>
        public ObservableCollection<PagerItem> PagerItems
        {
            get { return pagerItems; }
            set
            {
                pagerItems = value;
            }
        }

        public PagingViewModel()
        {
            PagerItems = new ObservableCollection<PagerItem>();
            var newItem = new PagerItem(1);
            pagerItems.Add(newItem);
            SelectedItem = newItem;
        }
    }
}
