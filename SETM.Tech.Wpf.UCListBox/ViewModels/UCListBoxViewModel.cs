using STEM.Tech.Wpf.Framework.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using STEM.Tech.Wpf.Models.Models;
using System.IO;
using SETM.Tech.Wpf.UCListBox.Properties;

namespace SETM.Tech.Wpf.UCListBox.ViewModels
{
    public class UCListBoxViewModel:ViewModelBase
    {
        public UCListBoxViewModel()
        {
            Init();
        }

        private void Init()
        {
            InitData();
            InitTimer();
        }

        private void InitTimer()
        {
            System.Timers.Timer tmr = new System.Timers.Timer();
            tmr.Elapsed += Tmr_Elapsed;
            tmr.Interval = 1000;
            tmr.Start();
        }

        private void Tmr_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(++SelectedIdx>=BooksCollection.Count)
            {
                SelectedIdx = 0;
            }
            SelectedBk=BooksCollection[SelectedIdx];
        }

        private void InitData()
        {
            //D:\C\STEM.Tech.Wpf.App\SETM.Tech.Wpf.UCListBox\Resources\Images\
            //string imgsDir = @"../../../STEM.Tech.Wpf.UCDatagrid/Resources/Images";
            string imgsDir = @"../../../SETM.Tech.Wpf.UCListBox/Resources/Images";
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
                if (value != selectedIdx)
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
                if (value != selectedBk)
                {
                    selectedBk = value;
                    OnPropertyChanged(nameof(SelectedBk));
                }
            }
        }
    }
}
