using AceTech.Framework.Utility;
using AceTech.Main.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AceTech.Main
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Shell shellWin = new Shell();
            Application.Current.MainWindow = shellWin;
            LoginWindow.LoginWin.Closed += LoginWin_Closed;
            LoginWindow.LoginWin.ShowDialog();
            if (LoginWindow.LoginWin.DialogResult == true)
            {
                shellWin.Show();
                LoginWindow.LoginWin.Close();
            }
            else
            {
                //if(LoginWindow.LoginWin.ShowDialog()!=false)
                //{
                //    LoginWindow.LoginWin.ShowDialog();
                //}
               
            }
        }

        private void LoginWin_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
