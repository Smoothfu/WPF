using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SETM.Tech.Wpf.UCListBox.Behaviors
{
    public class ListBoxAutoScrollBehavior:Behavior<ListBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
        }

        private void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lbx=sender as ListBox;
            if(lbx!=null && lbx.SelectedItem!=null)
            {
                lbx.ScrollIntoView(lbx.SelectedItem);
            }
        }

    }
}
