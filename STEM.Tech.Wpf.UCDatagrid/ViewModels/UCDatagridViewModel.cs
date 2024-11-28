using STEM.Tech.Wpf.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using STEM.Tech.Wpf.Models.Models;

namespace STEM.Tech.Wpf.UCDatagrid.ViewModels
{
    public class UCDatagridViewModel : ViewModelBase
    {
        public UCDatagridViewModel()
        {
            Init();
        }        

        private void Init()
        {
            InitData();
            InitCommands();
        }

        private void InitData()
        {
            string imgsDir = @"../../../STEM.Tech.Wpf.UCDatagrid/Resources/Images";
            if (!Directory.Exists(imgsDir))
            {
                return;
            }
            Task.Run(() =>
            {
                imgsList = new List<string>(Directory.GetFiles(imgsDir));
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
            });
        }

        private void InitCommands()
        {
            ExportAllAsJsonCommand = new DelCommand(ExportAllAsJsonCommandExecuted);
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

        private int selectedIdx = 0;
        public int SelectedIdx
        {
            get
            {
                return selectedIdx;
            }
            set
            {
                if(value!=selectedIdx)
                {
                    selectedIdx = value;
                    OnPropertyChanged(nameof(SelectedIdx));
                }
            }
        }

        private Book selectedBk;
        public Book SelectedBk
        {
            get
            {
                return selectedBk;
            }
            set
            {
                if (value!= selectedBk)
                {
                    selectedBk = value;
                    OnPropertyChanged(nameof(SelectedBk));
                }
            }
        }

        private void ExportAllAsJsonCommandExecuted(object obj)
        {
            var dg = obj as DataGrid;
            if (dg != null && dg.Items != null && dg.Items.Count > 0)
            {
                var items = (System.Collections.IList)dg.Items;
                List<Book> itemsList = items.Cast<Book>().ToList();
                string jsonFile = $"Json_{Guid.NewGuid().ToString("N")}.json";
                UtilityHelper.SerializeListTDataToJsonFile<Book>(itemsList, jsonFile);
                Global.OnUpdateStatusEvent($"Exported in {jsonFile}");
            }
        }


        public DelCommand ExportAllAsJsonCommand { get; set; }


    }
}
