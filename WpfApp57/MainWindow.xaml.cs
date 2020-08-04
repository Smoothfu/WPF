using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp57
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<string> NationsList { get; set; }
        public List<User> UsersList { get; set; }
        static MainWindow()
        {
            NationsList = new List<string> { "USA", "UK", "JAPAN" };
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            InitDataSource(); 
        }

        private void InitDataSource()
        {
            UsersList = new List<User>();
            UsersList.Add(new User()
            {
                Nation = NationsList[0],
                Name = "Fred1",
                CanEnglish = true
            });

            UsersList.Add(new User()
            {
                Nation = NationsList[1],
                Name = "Fred2",
                CanEnglish = true
            });

            UsersList.Add(new User()
            {
                Nation = NationsList[2],
                Name = "Fred3",
                CanEnglish = true
            });

        }

        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string jsonValue = JsonConvert.SerializeObject(UsersList, Formatting.Indented);
            MessageBox.Show(jsonValue);
        }
    }

    public class User 
    {        
        public string Nation { get; set; }
        public string Name { get; set; }
        public bool CanEnglish { get; set; }
    }    
}
