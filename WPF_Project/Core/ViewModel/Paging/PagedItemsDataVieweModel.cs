using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace Core
{
    /// <summary>
    /// ViewModel for ListBox with paging
    /// </summary>
    public class PagedItemsDataVieweModel<V> : PagedListItem<V> where V : SelectionItem, new()
    {
        protected PagedItemsDataVieweModel()
        {
            GetItems(PageSize, 1);
            PropertyChanged += OnPropertyChangedItem;
        }

        private void OnPropertyChangedItem(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Helper.GetMemberName(() => PageIndex))
            {
                RefreshItems();
            }

        }

        private void RefreshItems()
        {
            var selectedItem = SelectedItemId;
            GetItems(PageSize, PageIndex);
            SelectedItemId = selectedItem;
            SelectedItem = Items.SingleOrDefault(i => i.Id == SelectedItemId);
        }

        /// <summary>
        /// The abstract method to get the Items List
        /// </summary>
        public virtual void GetItems(int pageSize, int pageIndex)
        {

        }
    }
}
