using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace STEM.Tech.CS.DataModel.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public string ImgUrl { get; set; }
        public ImageSource ImgSource { get; set; }
    }
}
