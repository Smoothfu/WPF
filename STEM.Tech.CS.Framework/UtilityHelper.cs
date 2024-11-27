using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace STEM.Tech.CS.Framework
{
    public static class UtilityHelper
    {
        private static readonly Object jsonWriteObj = new object();
        public static void SerializeListTDataToJsonFile<T>(IEnumerable<T> dataList,string jsonFile="JsonFile.json")
        {
            var msgBox = MessageBox.Show($"Are you sure to export in {jsonFile}?", "Export",MessageBoxButton.YesNo);
            if(msgBox==MessageBoxResult.Yes)
            {
                string jsonStr=JsonConvert.SerializeObject(dataList,Formatting.Indented);
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Json Files|*.json|All Files|*.json";
                dialog.FileName= jsonFile;
                if(dialog.ShowDialog()==true)
                {
                    using (StreamWriter jsonWriter = new StreamWriter(dialog.FileName, false, Encoding.UTF8))
                    {
                        jsonWriter.WriteLine(jsonStr);
                        MessageBox.Show($"Saved in {dialog.FileName}");
                    }
                }
            }
        }
    }
}
