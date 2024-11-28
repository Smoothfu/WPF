using System;
using System.Collections.Generic;
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

namespace STEM.Tech.Wpf.UCDatagrid.UserControls
{
    /// <summary>
    /// Interaction logic for UCImgTbk.xaml
    /// </summary>
    public partial class UCImgTbk : UserControl
    {
        public UCImgTbk()
        {
            InitializeComponent();
            this.DataContext = this;
        }



        public ImageSource UCImgSource
        {
            get { return (ImageSource)GetValue(UCImgSourceProperty); }
            set { SetValue(UCImgSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UCImgSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UCImgSourceProperty =
            DependencyProperty.Register("UCImgSource", typeof(ImageSource),
                typeof(UCImgTbk), new PropertyMetadata(null));




        public string UCStr
        {
            get { return (string)GetValue(UCStrProperty); }
            set { SetValue(UCStrProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UCStr.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UCStrProperty =
            DependencyProperty.Register("UCStr", typeof(string),
                typeof(UCImgTbk), new PropertyMetadata(""));


    }
}
