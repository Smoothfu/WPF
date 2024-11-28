using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STEM.Tech.Wpf.Framework.Utils
{
    public static class Global
    {
        public delegate void UpdateStatusHandler(string msg);
        public static event UpdateStatusHandler UpdateStatusEvent;
        public static void OnUpdateStatusEvent(string msg)
        {
            UpdateStatusEvent?.Invoke(msg);
        }
    }
}
