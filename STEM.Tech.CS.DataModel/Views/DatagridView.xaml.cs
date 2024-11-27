using STEM.Tech.CS.DataModel.Models;
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
using System.Windows.Shapes;

namespace STEM.Tech.CS.DataModel.Views
{
    /// <summary>
    /// Interaction logic for DatagridView.xaml
    /// </summary>
    public partial class DatagridView : UserControl
    {
        public DatagridView()
        {
            InitializeComponent();
        }

        //public ObservableCollection<Book> UCItemsSource
        //{
        //    get { return (ObservableCollection<Book>)GetValue(UCItemsSourceProperty); }
        //    set { SetValue(UCItemsSourceProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for UCItemsSource.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty UCItemsSourceProperty =
        //    DependencyProperty.Register("UCItemsSource", typeof(ObservableCollection<Book>), 
        //        typeof(DatagridView), new PropertyMetadata(null,OnPropertyChangedCallback));

        //private static void OnPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
             
        //}
    }
}
