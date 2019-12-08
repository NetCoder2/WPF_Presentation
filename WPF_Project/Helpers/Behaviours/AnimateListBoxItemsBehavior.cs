using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.Windows.Interactivity;

namespace Helpers.Behaviours
{
    public class AnimateListBoxItemsBehavior : Behavior<ListBox>
    {
        public DoubleAnimation Animation { get; set; }
        public DoubleAnimation OpacityAnimation { get; set; }
        public TimeSpan Tick { get; set; }


        protected override void OnAttached()
        {
            base.OnAttached();
            ((INotifyCollectionChanged)AssociatedObject.Items).CollectionChanged += OnListBoxItemsChanged;
        }


        // Re-select items when the set of items changes
        private void OnListBoxItemsChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            IEnumerable<ListBoxItem> items;
            if (AssociatedObject.ItemsSource == null)
            {
                items = AssociatedObject.Items.Cast<ListBoxItem>();
            }
            else if (AssociatedObject.Items.Count == 0)
            {


                items = AssociatedObject.Items.Cast<ListBoxItem>();
            }
            else
            {
                var itemsSource = AssociatedObject.ItemsSource;
                if (itemsSource is INotifyCollectionChanged)
                {
                    var collection = itemsSource as INotifyCollectionChanged;



                    collection.CollectionChanged += (s, cce) =>
                    {
                        if (cce.Action == NotifyCollectionChangedAction.Add)
                        {
                            var itemContainer = AssociatedObject.ItemContainerGenerator.ContainerFromItem(cce.NewItems[0]) as ListBoxItem;
                            itemContainer.BeginAnimation(ListBoxItem.OpacityProperty, OpacityAnimation);
                        }
                    };

                }

                ListBoxItem[] itemsSub = new ListBoxItem[AssociatedObject.Items.Count];
                AssociatedObject.UpdateLayout();
                AssociatedObject.ScrollIntoView(AssociatedObject.Items[0]);

                for (int i = 0; i < itemsSub.Length; i++)
                {
                    var sd = AssociatedObject.ItemContainerGenerator.ContainerFromIndex(i);
                    itemsSub[i] = AssociatedObject.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;

                }
                items = itemsSub;
            }

            foreach (var item in items)
            {
                item.Opacity = 0;
                TranslateTransform rotateTransform1 = new TranslateTransform(320, 0);
                item.RenderTransform = rotateTransform1;
            }
            var enumerator = items.GetEnumerator();
            if (enumerator.MoveNext())
            {
                DispatcherTimer timer = new DispatcherTimer() { Interval = Tick };
                timer.Tick += (s, timerE) =>
                {
                    var item = enumerator.Current;
                    item.BeginAnimation(ListBoxItem.OpacityProperty, OpacityAnimation);
                    item.RenderTransform.BeginAnimation(TranslateTransform.XProperty, Animation);
                    if (!enumerator.MoveNext())
                    {
                        timer.Stop();
                    }
                };
                timer.Start();
            }
        }

    }
}
