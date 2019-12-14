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
    /// The abstract class to get Items List 
    /// </summary>
    public abstract class SelectionItemsDataViewModel : PagedListItem<SelectionItem>
    {
        protected SelectionItemsDataViewModel()
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
        public abstract void GetItems(int pageSize, int pageIndex);
    }
}
