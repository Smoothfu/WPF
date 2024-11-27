using STEM.Tech.CS.DataModel.Models;
using STEM.Tech.CS.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;
using System.Threading;
using System.Windows.Controls;

namespace STEM.Tech.CS.WPF.ViewModels
{
    public class MainVM : ViewModelBase
    {
        public MainVM()
        {
            InitDataGrid();            
        }

        #region Datagrid

        private void InitDataGrid()
        {
            InitData();
            RefreshTime();
            InitCommands();
        }

        private void InitCommands()
        {
            ExportAllAsJsonCommand = new DelCommand(ExportAllAsJsonCommandExecuted);
        }

        private void ExportAllAsJsonCommandExecuted(object obj)
        {
            var dg = obj as DataGrid;
            if(dg!=null && dg.Items!=null && dg.Items.Count>0)
            {
                var items = (System.Collections.IList)dg.Items;
                List<Book> itemsList =items.Cast<Book>().ToList();
                string jsonFile = $"Json_{Guid.NewGuid().ToString("N")}.json";
                UtilityHelper.SerializeListTDataToJsonFile<Book>(itemsList, jsonFile);
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
                

        private void InitData()
        {
            UpdateStatusStr("Begin Init!");
            Task.Run(() =>
            {
                imgsList = new List<string>(Directory.GetFiles(@"../../Images"));
                if (imgsList.Any())
                {
                    imgsCount = imgsList.Count;
                    BooksCollection = new ObservableCollection<Book>();
                    for (int i = 0; i < 10000; i++)
                    {
                        BooksCollection.Add(new Book()
                        {
                            Id = i + 1,
                            ISBN = $"ISBN_{i + 1}",
                            Name = $"Name_{i + 1}",
                            ImgUrl = $"{imgsList[i % imgsCount]}",
                            ImgSource = GetImageSourceViaUrl(imgsList[i % imgsCount])
                        });
                    }
                }

                UpdateStatusStr("Init Finished!");
            });
        }

        private ImageSource GetImageSourceViaUrl(string imgUrl)
        {
            BitmapImage bmi = new BitmapImage();
            bmi.BeginInit();
            bmi.UriSource = new Uri(imgUrl, UriKind.RelativeOrAbsolute);
            bmi.EndInit();
            if (bmi.CanFreeze)
            {
                bmi.Freeze();
            }
            return bmi;
        }

        private List<string> imgsList { get; set; }

        private int imgsCount = 0;

        private ObservableCollection<Book> booksCollection;
        public ObservableCollection<Book> BooksCollection
        {
            get
            {
                return booksCollection;
            }
            set
            {
                if (value != booksCollection)
                {
                    booksCollection = value;
                    OnPropertyChanged(nameof(BooksCollection));
                }
            }
        }
        
        public DelCommand ExportAllAsJsonCommand { get; set; }

        #endregion

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
            #endregion
        }
    }
}
