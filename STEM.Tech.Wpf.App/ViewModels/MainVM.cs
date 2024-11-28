using STEM.Tech.Wpf.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace STEM.Tech.Wpf.App.ViewModels
{
    public class MainVM:ViewModelBase
    {
        public MainVM()
        {
            Init();            
        }

        private void Init()
        {
            RefreshTime();
            Global.UpdateStatusEvent += Global_UpdateStatusEvent;
        }

        private void Global_UpdateStatusEvent(string msg)
        {
            UpdateStatusStr(msg);
        }


        #region Status 
        private string statusStr;
        public string StatusStr
        {
            get
            {
                return statusStr;
            }
            set
            {
                if (value != statusStr)
                {
                    statusStr = value;
                    OnPropertyChanged(nameof(StatusStr));
                }
            }
        }

        private string statusTimeStr;
        public string StatusTimeStr
        {
            get
            {
                return statusTimeStr;
            }
            set
            {
                if (value != statusTimeStr)
                {
                    statusTimeStr = value;
                    OnPropertyChanged(nameof(StatusTimeStr));
                }
            }
            
        }

        private void RefreshTime()
        {
            Task.Run(() =>
            {
                System.Timers.Timer tmr = new System.Timers.Timer();
                tmr.Interval = 1000;
                tmr.Elapsed += Tmr_Elapsed;
                tmr.Start();
            });
        }

        private void Tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                StatusTimeStr = DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss");
            }));
        }

        private void UpdateStatusStr(string msg)
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                StatusStr = msg;
            }));
        }

        #endregion

    }
}
