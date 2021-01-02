using AceTech.Main.ViewModel;
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
using System.Windows.Shapes;

namespace AceTech.Main.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public static LoginWindow LoginWin;
        static LoginWindow()
        {
            LoginWin = new LoginWindow();
        }

        public LoginWindow()
        {
            InitializeComponent();
            this.DataContext = LoginVM.loginVM;
        }
    }
}
